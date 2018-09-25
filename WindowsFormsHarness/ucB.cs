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
    public delegate void AAA();

    [DefaultEvent("CatShowedUp")]
    public partial class ucB : UserControl
    {
        public AAA a = null;
        public event AAA DogShowedUp = null;
        public event AAA CatShowedUp = null;

        public ucB()
        {
            InitializeComponent();

            FullName p;
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (txtValue.Text.Contains("dog") == true)
            {
                //a.Invoke();

                //if (a != null)
                //{
                //    a();
                //}

                //a?.Invoke();

                DogShowedUp?.Invoke();
            }

            if (txtValue.Text.Contains("cat") == true)
            {
                CatShowedUp?.Invoke();
            }
        }
    }
}
