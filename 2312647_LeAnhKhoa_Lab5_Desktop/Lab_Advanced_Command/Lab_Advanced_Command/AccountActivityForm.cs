using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab_Advanced_Command
{
    public partial class AccountActivityForm : Form
    {
        private string accountName;
        private DataTable billsTable;

        public AccountActivityForm(string accountName)
        {
            InitializeComponent();
            this.accountName = accountName;
            lblAccountName.Text = accountName;
            LoadInvoices();
        }

        private void LoadInvoices()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Execute GetBillsByAccount @AccountName";
                cmd.Parameters.Add("@AccountName", SqlDbType.NVarChar).Value = accountName;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                billsTable = new DataTable();

                conn.Open();
                adapter.Fill(billsTable);
                conn.Close();

                lbInvoices.Items.Clear();

                foreach (DataRow row in billsTable.Rows)
                {
                    int id = Convert.ToInt32(row["ID"]);
                    DateTime date = Convert.ToDateTime(row["InvoiceDate"]);
                    lbInvoices.Items.Add($"{id} - {date:dd/MM/yyyy}");
                }

                lblInvoiceCount.Text = billsTable.Rows.Count.ToString();

                decimal totalRevenue = 0;
                foreach (DataRow row in billsTable.Rows)
                {
                    totalRevenue += Convert.ToDecimal(row["FinalAmount"]);
                }
                lblTotalRevenue.Text = totalRevenue.ToString("N0") + " VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải hóa đơn: " + ex.Message);
            }
        }

        private void lbInvoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbInvoices.SelectedIndex < 0) return;

            string selectedText = lbInvoices.SelectedItem.ToString();
            int invoiceID = int.Parse(selectedText.Split('-')[0].Trim());

            LoadInvoiceDetails(invoiceID);
        }

        private void LoadInvoiceDetails(int invoiceID)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Execute GetBillDetailsByID @ID";
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = invoiceID;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dtDetails = new DataTable();

                conn.Open();
                adapter.Fill(dtDetails);
                conn.Close();

                dgvInvoiceDetails.DataSource = dtDetails;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết hóa đơn: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}