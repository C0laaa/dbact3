using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Web;

namespace DBACT_
{
    public partial class frmLogIn : Form
    {
        string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cola/Downloads/DB-ACT3.mdb";
        OleDbConnection conn;
        public frmLogIn()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string query = "SELECT username, password FROM account WHERE username = @username and password = @password";
            conn = new OleDbConnection(connStr);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(query,conn);
            cmd.Parameters.AddWithValue("@username",txtUsername.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            OleDbDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                string username = rdr["username"].ToString();
                frmMain frm = new frmMain(username,conn);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Credentials are Incorrect!", "Credentials");
            }
            conn.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {


        }
    }
}
