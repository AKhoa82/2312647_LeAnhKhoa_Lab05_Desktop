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
    public partial class AccountInfoForm : Form
    {
        private bool isUpdateMode = false;
        private string currentAccountName = "";
        public AccountInfoForm()
        {
            InitializeComponent();
            isUpdateMode = false;
            btnSave.Text = "Thêm";
        }

        public AccountInfoForm(DataRowView rowView)
        {
            InitializeComponent();
            isUpdateMode = true;

            currentAccountName = rowView["AccountName"].ToString();

            txtAccountName.Text = currentAccountName;
            txtFullName.Text = rowView["FullName"].ToString();
            txtEmail.Text = rowView["Email"].ToString();
            txtTell.Text = rowView["Tell"].ToString();

            txtAccountName.ReadOnly = true;
            txtPassword.Visible = false;
            lblPassword.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isUpdateMode)
            {
                if (string.IsNullOrWhiteSpace(txtAccountName.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text) ||
                    string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    MessageBox.Show("Vui lòng nhập: Tên đăng nhập, Mật khẩu, Họ tên!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connectionString);

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Execute InsertAccount @AccountName, @Password, @FullName, @Email, @Tell";

                    cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = txtAccountName.Text;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = txtPassword.Text;
                    cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = txtFullName.Text;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text;
                    cmd.Parameters.Add("@Tell", SqlDbType.NVarChar).Value = txtTell.Text;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Thêm tài khoản thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi SQL: Có thể tên tài khoản đã tồn tại!\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    MessageBox.Show("Họ tên không được để trống!",
                                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connectionString);

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Execute UpdateAccount @AccountName, @FullName, @Email, @Tell";

                    cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = currentAccountName;
                    cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = txtFullName.Text;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text;
                    cmd.Parameters.Add("@Tell", SqlDbType.NVarChar).Value = txtTell.Text;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Cập nhật thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
