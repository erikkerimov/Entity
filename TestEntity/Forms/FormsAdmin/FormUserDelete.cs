using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestEntity.Forms.FormsAdmin
{
    public partial class FormUserDelete : Form
    {
        private DbQuerys dbQuerys = new DbQuerys();
        public FormUserDelete()
        {
            InitializeComponent();
            LoadToDataGrid();
        }

        public void LoadToDataGrid()
        {
            List<DataUsers> dataUsers = dbQuerys.GetDataUsers();
            for (int i = 0; i < dataUsers.Count; i++)
            {
                dataGridView1.Rows.Add(dataUsers[i].Id.ToString(), dataUsers[i].Login.ToString(), 
                                       dataUsers[i].Password.ToString(), dataUsers[i].IdRole.ToString());
            }
        }
    }
}
