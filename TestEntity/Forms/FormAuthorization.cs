using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestEntity
{
    public partial class FormAuthorization : Form
    {
        private DbQuerys dbQuerys = new DbQuerys();
        public FormAuthorization()
        {
            InitializeComponent();
        }

        private void buttonIdentification_Click(object sender, EventArgs e)
        {
            if(textBoxLogin.Text == ""|| textBoxPassword.Text == "")
            {
                MessageBox.Show("Все поля обязательны к заполнению");
            }  
            else
            {
                var ThisUser = dbQuerys.GetUser(textBoxLogin.Text, textBoxPassword.Text);
                if (ThisUser.Id == 0)
                {
                    MessageBox.Show("Пользователя с такими данными не существует!");
                    textBoxPassword.Text = "";
                }
                else
                {
                    var Ban = dbQuerys.CheckBan(dbQuerys.GetUser(textBoxLogin.Text, textBoxPassword.Text));
                    if(Ban.Id != 0)
                    {
                        MessageBox.Show("К сожалению вы забанены. Причина: " + Ban.Comment);
                    }
                    else
                    {
                        MessageBox.Show("Вы авторизовались!");
                        Properties.Settings.Default.ThisUserLogin = ThisUser.Login;
                        Properties.Settings.Default.ThisUserPassword = ThisUser.Password;
                        Properties.Settings.Default.Save();

                        var FM = new FormMenu();
                        FM.Show();
                        this.Hide();
                    }
                    
                }
            }
        }

        private void buttonToRegistration_Click(object sender, EventArgs e)
        {
            var FR = new FormRegistration();
            FR.Show();
            this.Hide();
        }
    }
}
