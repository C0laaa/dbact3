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
using static System.Net.Mime.MediaTypeNames;

namespace DBACT_
{
    public partial class frmDelete : Form
    {
        OleDbConnection dconn;
        public frmDelete(OleDbConnection conn)
        {
            InitializeComponent();
            dconn = conn;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "DELETE from employee WHERE name = @name and email = @email";

            if (dconn.State != ConnectionState.Open)
            {
                dconn.Open();
            }
            OleDbCommand cmd = new OleDbCommand(query, dconn);
            cmd.Parameters.AddWithValue("@name", txtDeleteName.Text);
            cmd.Parameters.AddWithValue("@email",txtDeleteEmail.Text);
            cmd.ExecuteNonQuery();
            dconn.Close();
            MessageBox.Show("Sucessfully Deleted from to the Database!", "SUCC IT!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
