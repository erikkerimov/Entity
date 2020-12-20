using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestEntity.Forms
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            var FA = new Forms.FormsAdmin.FormUserDelete();
            FA.Show();
            this.Hide();
        }
    }
}
