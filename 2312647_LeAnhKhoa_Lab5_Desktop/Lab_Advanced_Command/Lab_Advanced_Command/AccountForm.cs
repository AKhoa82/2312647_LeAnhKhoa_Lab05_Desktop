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
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
            LoadAccountList();
        }
        
        private void LoadAccountList()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Execute GetAllAccounts";

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                conn.Open();
                adapter.Fill(dt);
                conn.Close();

                dgvAccounts.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách tài khoản: " + ex.Message);
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            AccountInfoForm infoForm = new AccountInfoForm();
            if (infoForm.ShowDialog() == DialogResult.OK)
                LoadAccountList();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn tài khoản để reset mật khẩu");
                return;
            }

            string accountName = dgvAccounts.SelectedRows[0].Cells["AccountName"].Value.ToString();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Execute ResetAccountPassword @AccountName";

                cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = accountName;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Reset mật khẩu thành công (mặc định: 123456)");
            }
            catch (Exception excp)
            {
                MessageBox.Show("Lỗi reset mật khẩu: " + excp.Message);
            }
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản để cập nhật!");
                return;
            }

            DataRowView rowView = dgvAccounts.SelectedRows[0].DataBoundItem as DataRowView;
            AccountInfoForm infoForm = new AccountInfoForm(rowView);

            if (infoForm.ShowDialog() == DialogResult.OK)
                LoadAccountList();
        }

        private void tsmViewRoles_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count > 0)
            {
                string accountName = dgvAccounts.SelectedRows[0].Cells["AccountName"].Value.ToString();
                AccountRolesForm rolesForm = new AccountRolesForm(accountName);
                rolesForm.ShowDialog();
            }
        }

        private void tsmViewActivity_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count > 0)
            {
                string accountName = dgvAccounts.SelectedRows[0].Cells["AccountName"].Value.ToString();
                AccountActivityForm activityForm = new AccountActivityForm(accountName);
                activityForm.ShowDialog();
            }
        }
    }
}
