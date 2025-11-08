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
    public partial class AddCategoryForm : Form
    {
        public bool IsAdded = false;
        public AddCategoryForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            SqlCommand checkCmd = new SqlCommand("Select count(*) from Category where Name = @Name", conn);
            checkCmd.Parameters.AddWithValue("@Name", txtName.Text);
            int exists = (int)checkCmd.ExecuteScalar();

            if (exists > 0)
            {
                MessageBox.Show("Tên loại món ăn đã tồn tại! Vui lòng nhập tên khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtName.Clear();
                txtType.Clear();
                txtName.Focus();

                conn.Close();
                return;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "EXEC InsertCategory @ID output, @Name, @Type";

            cmd.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 1000).Value = txtName.Text;
            cmd.Parameters.Add("@Type", SqlDbType.Int).Value = int.Parse(txtType.Text);

            int num = cmd.ExecuteNonQuery();
            conn.Close();

            if (num > 0)
            {
                MessageBox.Show("Thêm nhóm món ăn thành công, ID = " + cmd.Parameters["@ID"].Value);
                IsAdded = true;
                this.Close();
            }
            else
                MessageBox.Show("Thêm thất bại");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
