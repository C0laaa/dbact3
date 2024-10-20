using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBACT_
{
    public partial class frmAdd : Form
    {
        OleDbConnection connAdd;
        public frmAdd(OleDbConnection conn)
        {
            InitializeComponent();
            connAdd = conn;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "INSERT into employee (name,email,sex,address) values(@name,@email,@sex,@address)";
            if (connAdd.State != ConnectionState.Open)
            {
                connAdd.Open();
            }
            
            OleDbCommand cmd = new OleDbCommand(query,connAdd);
            cmd.Parameters.AddWithValue("@name",txtAddName.Text);
            cmd.Parameters.AddWithValue("@email", txtAddEmail.Text);
            cmd.Parameters.AddWithValue("@sex", cboSex.Text);
            cmd.Parameters.AddWithValue("@address", txtAddAddress.Text);
            cmd.ExecuteNonQuery();
            connAdd.Close();

            MessageBox.Show("Sucessfully Added to the Database!", "SUCC IT!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
