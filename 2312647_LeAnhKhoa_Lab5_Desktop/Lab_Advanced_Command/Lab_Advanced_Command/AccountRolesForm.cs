using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Advanced_Command
{
    public partial class AccountRolesForm : Form
    {
        private string accountName;

        public AccountRolesForm(string accountName)
        {
            InitializeComponent();
            this.accountName = accountName;
            lblAccountName.Text = "Tài khoản: " + accountName;
            LoadRoles();
        }

        private void LoadRoles()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmdAllRoles = conn.CreateCommand();
                cmdAllRoles.CommandText = "Execute GetAllRoles";

                SqlDataAdapter adapter = new SqlDataAdapter(cmdAllRoles);
                DataTable dtRoles = new DataTable();

                conn.Open();
                adapter.Fill(dtRoles);

                dtRoles.Columns.Add("IsAssigned", typeof(bool));

                SqlCommand cmdRolesByAccount = conn.CreateCommand();
                cmdRolesByAccount.CommandText = "Execute GetRolesByAccount @AccountName";
                cmdRolesByAccount.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = accountName;

                SqlDataAdapter adapter2 = new SqlDataAdapter(cmdRolesByAccount);
                DataTable dtAssignedRoles = new DataTable();
                adapter2.Fill(dtAssignedRoles);

                foreach (DataRow role in dtRoles.Rows)
                {
                    string roleName = role["RoleName"].ToString();
                    bool isAssigned = dtAssignedRoles.Select($"RoleName = '{roleName}'").Length > 0;
                    role["IsAssigned"] = isAssigned;
                }

                conn.Close();

                dgvRoles.DataSource = dtRoles;
                dgvRoles.Columns["IsAssigned"].DisplayIndex = 0;
                dgvRoles.Columns["IsAssigned"].HeaderText = "Gán";
                dgvRoles.Columns["RoleName"].HeaderText = "Tên vai trò";
            }
            catch (Exception excp)
            {
                MessageBox.Show("Lỗi tải vai trò: " + excp.Message);
            }
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            RoleForm roleForm = new RoleForm();
            roleForm.ShowDialog();
            LoadRoles();
        }

        private void btnUpdateRoles_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Execute UpdateAccountRoles @AccountName";

                cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = accountName;

                conn.Open();
                cmd.ExecuteNonQuery();

                foreach (DataGridViewRow row in dgvRoles.Rows)
                {
                    bool isAssigned = Convert.ToBoolean(row.Cells["IsAssigned"].Value);
                    if (isAssigned)
                    {
                        SqlCommand cmdAssign = conn.CreateCommand();
                        cmdAssign.CommandText = "INSERT INTO RoleAccount (AccountName, RoleID) VALUES (@AccountName, @RoleID)";
                        cmdAssign.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = accountName;
                        cmdAssign.Parameters.Add("@RoleID", SqlDbType.Int).Value = row.Cells["ID"].Value;
                        cmdAssign.ExecuteNonQuery();
                    }
                }

                conn.Close();
                MessageBox.Show("Cập nhật vai trò thành công!");
                this.Close();
            }
            catch (Exception excp)
            {
                MessageBox.Show("Lỗi cập nhật: " + excp.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
