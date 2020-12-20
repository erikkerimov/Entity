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
    public partial class FormRegistration : Form
    {
        private DbQuerys dbQuerys = new DbQuerys();
        public FormRegistration()
        {
            InitializeComponent();
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "" || textBoxPassword.Text == "" || textBoxPasswordRepeat.Text == "")
            {
                MessageBox.Show("Необходимо заполнить все поля!");
            }    
            else
            {
                if(textBoxPassword.TextLength < 5)
                {
                    MessageBox.Show("Длинна пароля должна быть более 5-ти символов");
                }
                else
                {
                    if (textBoxPassword.Text == textBoxPasswordRepeat.Text)
                    {
                        dbQuerys.RegistrationUser(textBoxLogin.Text, textBoxPassword.Text);
                        MessageBox.Show("Регистрация прошла успешно!");
                    }
                }
            }
        }

        private void buttonBackToMainForm_Click(object sender, EventArgs e)
        {
            var FA = new FormAuthorization();
            FA.Show();
            this.Hide();
        }
    }
}
