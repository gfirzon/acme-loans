using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsHarness
{
    public partial class ucA : UserControl
    {
        public ucA()
        {
            InitializeComponent();
        }

        public FullName GetValues()
        {
            FullName o = new FullName { FirstName = txtFirstName.Text, LastName = txtLastName.Text, MiddleName = txtMiddleName.Text };
            return o;
        }

        public void SetValues(FullName fullName)
        {
            ///
        }


        public void SetLastName(string value)
        {
            txtLastName.Text = value;
        }

        public void SetFirstName(string value)
        {
            txtFirstName.Text = value;
        }
        public void SetMiddleName(string value)
        {
            txtMiddleName.Text = value;
        }

        public string GetLastName()
        {
            return txtLastName.Text;
        }

        public string GetFirstName()
        {
            return txtFirstName.Text;
        }
        public string GetMiddleName()
        {
            return txtMiddleName.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
