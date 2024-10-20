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
    public partial class frmUpdate : Form
    {
        OleDbConnection UpdateConn;
        public frmUpdate(OleDbConnection conn)
        {
            InitializeComponent();
            UpdateConn = conn;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = "UPDATE employee SET name = @name, email = @email, address = @address WHERE empid = "+txtUpdateID.Text+"";
            if (UpdateConn.State != ConnectionState.Open)
            { 
                UpdateConn.Open();
            }
            OleDbCommand cmd = new OleDbCommand(query,UpdateConn);
            cmd.Parameters.AddWithValue("@name",txtUpdateName.Text);
            cmd.Parameters.AddWithValue("@email", txtUpdateEmail.Text);
            cmd.Parameters.AddWithValue("@address", txtUpdateAddress.Text);
            cmd.ExecuteNonQuery();
            UpdateConn.Close();

            MessageBox.Show("Sucessfully Updated from to the Database!", "SUCC IT!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
