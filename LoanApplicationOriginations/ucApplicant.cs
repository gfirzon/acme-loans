using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcmeLoans.Common;

namespace LoanApplicationOriginations
{
    public partial class ucApplicant : UserControl
    {
        public ucApplicant()
        {
            InitializeComponent();
        }

        public void SetStateList(List<State> list)
        {
            foreach (State item in list)
            {
                cboStates.Items.Add(item);
            }
        }

        public Applicant GetApplicant()
        {
            Applicant applicant = new Applicant();
            //applicant.ApplicantId = 
            applicant.SSN = txtSSN.Text;
            applicant.LastName = txtLastName.Text;
            applicant.FirstName = txtFirstName.Text;
            //applicant.DateOfBirth = txtDateOfBirth.Text;
            applicant.DateOfBirth = new DateTime(1980, 1, 15);
            applicant.StreetAddress = txtStreet.Text;
            applicant.City = txtCity.Text;
            applicant.StateID = ((State)cboStates.SelectedItem).StateID;
            applicant.Zip = txtZIPCode.Text;
            applicant.HomePhone = txtHomePhone.Text;
            applicant.MobilePhone = txtMobilePhone.Text;
            applicant.EMail = txtEmailAddress.Text;

            return applicant;
        }

        private void ucApplicant_Load(object sender, EventArgs e)
        {

        }
    }
}
