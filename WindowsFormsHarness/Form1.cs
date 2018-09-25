using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsHarness
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSetValues_Click(object sender, EventArgs e)
        {
            ucA1.SetLastName(txtLN.Text);
            ucA1.SetFirstName(txtFN.Text);
            ucA1.SetMiddleName(txtMN.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGetValues_Click(object sender, EventArgs e)
        {
            FullName o = ucA1.GetValues();

            txtLN.Text = o.LastName;
            txtFN.Text = o.FirstName;
            txtMN.Text = o.MiddleName;


            //txtLN.Text = ucA1.GetLastName();
            //txtFN.Text = ucA1.GetFirstName();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ucB1.a = Tralala;
        }

        void Tralala()
        {
            int n = 1;
        }

        private void ucB1_Load(object sender, EventArgs e)
        {

        }

        private void ucB1_DogShowedUp()
        {

        }

        private void ucB1_CatShowedUp()
        {

        }
    }
}
