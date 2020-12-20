using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestEntity
{
    public partial class FormMenu : Form
    {
        private const string Admin = "Admin";
        private DbQuerys dbQuerys = new DbQuerys();
        public FormMenu()
        {
            InitializeComponent();
            InitializeElements();
        }

        private void InitializeElements()
        {
            string Role = dbQuerys.GetRole(dbQuerys.GetUser(Properties.Settings.Default.ThisUserLogin, Properties.Settings.Default.ThisUserPassword));
            
            if(Role == Admin)
            {
                buttonAdmin.Visible = true;
            }
        }
        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            var FA = new Forms.FormAdmin();
            FA.Show();
            this.Hide();

        }
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
            var FA = new FormAuthorization();
            FA.Show();
            this.Hide();
        }
    }
}
