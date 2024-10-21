using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _045_ACT3_RAMOS_ReyChrstian
{
    public partial class frmMain : Form
    {
        string _username;
        
        OleDbConnection _conn;
        public frmMain(string username, OleDbConnection conn)
        {
            InitializeComponent();
            _username = username;
            _conn = conn;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = "Welcome " + _username;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtKeyword.Text == "")
            {
                MessageBox.Show("Please Enter A Name", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cboGender.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select A Gender", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                
                string query = "select name as NAME, email as EMAIL,sex as SEX, address as ADDRESS from employee where name like'%" + txtKeyword.Text + "%' and sex = '" + cboGender.Text + "'";
                
                if (_conn.State != ConnectionState.Open)
                {
                    _conn.Open();
                }

                OleDbDataAdapter adapter = new OleDbDataAdapter(query, _conn);
                adapter.Fill(dt);
                
                grdData.DataSource = dt;

                _conn.Close();
            }
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
           
                DataTable dt = new DataTable();

                string query = "select name as NAME, email as EMAIL,sex as SEX, address as ADDRESS from employee where name like'%" + txtKeyword.Text + "%'";

                if (_conn.State != ConnectionState.Open)
                {
                    _conn.Open();
                }

                OleDbDataAdapter adapter = new OleDbDataAdapter(query, _conn);
                adapter.Fill(dt);

                grdData.DataSource = dt;

                _conn.Close();
            
      
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
          frmAdd frm = new frmAdd(_conn);
            frm.Show(); 
        }

        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (cboGender.SelectedIndex == 0)
            {
                string query = "SELECT name as NAME, email as EMAIL, sex as SEX, address as ADDRESS FROM employee ";
                if (_conn.State != ConnectionState.Open)
                {
                    _conn.Open();
                }
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, _conn);
                adapter.Fill(dt);

                _conn.Close();

                grdData.DataSource = dt;
            }
            else if (cboGender.SelectedIndex == 1)
            {
                string query = "SELECT name as NAME, email as EMAIL, sex as SEX, address as ADDRESS FROM employee WHERE  sex = 'Male'";
                if (_conn.State != ConnectionState.Open)
                {
                    _conn.Open();
                }
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, _conn);
                adapter.Fill(dt);

                _conn.Close();

                grdData.DataSource = dt;
            }
            else
            {
                string query = "SELECT name as NAME, email as EMAIL, sex as SEX, address as ADDRESS FROM employee WHERE  sex = 'Female'";
                if (_conn.State != ConnectionState.Open)
                {
                    _conn.Open();
                }
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, _conn);
                adapter.Fill(dt);

                _conn.Close();

                grdData.DataSource = dt;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEdit frm = new frmEdit(_conn);
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            frmDelete frm = new frmDelete(_conn);
            frm.ShowDialog();
        }
    }
}
