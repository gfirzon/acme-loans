using AcmeLoans.Common;
using AcmeLoans.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanApplicationOriginations
{
    public partial class Form1 : Form
    {
        private bool isNew = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoanTypeManager accessor = new LoanTypeManager();
            List<LoanType> list = accessor.GetLoanTypes();

            foreach (LoanType item in list)
            {
                //Console.WriteLine("ID: {0} Desc: {1}", item.LoanTypeId, item.Description);
                ddlPurposes.Items.Add(item);
            }
            // get list of states and pass it to Applicant User Control
            StateManager sm = new StateManager();
            List<State> stateList = sm.GetStates();

            ucApplicant1.SetStateList(stateList);
        }

        private void DoInsert()
        {
            //application related

            LoanType t = ddlPurposes.SelectedItem as LoanType;

            LoanApplication app = new LoanApplication
            {
                LoanTypeId = t.LoanTypeId,
                Amount = Convert.ToDecimal( txtAmount.Text),
                IsProcessed = false,
                Created = DateTime.Now
            };

            LoanApplicationsManager accessor = new LoanApplicationsManager();
            int appId = accessor.InsertApplication(app);

            txtAppId.Text = appId.ToString();

            //applicant related

            Applicant applicant = ucApplicant1.GetApplicant();
            ApplicantsManager mgr = new ApplicantsManager();

            int applicantId = mgr.InsertApplicant(applicant);
        }

        private void DoUpdate()
        {
            LoanApplicationsManager accessor = new LoanApplicationsManager();

            LoanType t = ddlPurposes.SelectedItem as LoanType;

            LoanApplication app = new LoanApplication
            {
                ApplicationId = Convert.ToInt32(txtAppId.Text),
                LoanTypeId = t.LoanTypeId,
                Amount = Convert.ToDecimal(txtAmount.Text),
                IsProcessed = false,
                ProcessedDate = null //  DateTime.Now
            };
            accessor.UpdateLoanApplication(app);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(isNew == true)
            {
                DoInsert();
            }
            else
            {
                DoUpdate();
            }
        }

        private void txtAppId_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEdit.Checked == true)
            {
                btnFind.Visible = true;
                txtAppId.ReadOnly = false;

                isNew = false;
            }
            if (chkEdit.Checked == false)
            {
                btnFind.Visible = false;
                txtAppId.ReadOnly = true;
                isNew = true;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string a = txtAppId.Text;
            int appId = Convert.ToInt32(a);

            LoanApplicationsManager accessor = new LoanApplicationsManager();
            LoanApplication app = accessor.GetApplicationById(appId);
            if (app != null)
            {
                txtAmount.Text = app.Amount.ToString();
                lblFindStatus.Text = string.Empty;

                for (int i = 0; i < ddlPurposes.Items.Count; i++)
                {
                    LoanType lt = (LoanType)ddlPurposes.Items[i];
                    if (lt.LoanTypeId == app.LoanTypeId)
                    {
                        ddlPurposes.SelectedIndex = i;
                    }
                }
            }
            else
            {
                lblFindStatus.Text = "Application not found";
            }
        }

    }
}
