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
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
        }

        private void btnViewOrders_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Execute GetBillsByDate @FromDate, @ToDate";

            cmd.Parameters.Add("@FromDate", SqlDbType.SmallDateTime).Value = dtpFromDate.Value;
            cmd.Parameters.Add("@ToDate", SqlDbType.SmallDateTime).Value = dtpToDate.Value;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            conn.Open();
            adapter.Fill(dt);
            conn.Close();

            dgvOrders.DataSource = dt;

            //Tính tổng
            decimal totalAmount = 0, totalDiscount = 0, totalFinal = 0;
            foreach (DataRow row in dt.Rows)
            {
                decimal amount = Convert.ToDecimal(row["Amount"]);
                decimal discountRate = Convert.ToDecimal(row["Discount"]);
                decimal discountMoney = amount * discountRate;
                decimal finalAmount = Convert.ToDecimal(row["FinalAmount"]);

                totalAmount += amount;
                totalDiscount += discountMoney;
                totalFinal += finalAmount;
            }

            lblTotalAmount.Text = totalAmount.ToString("N0");
            lblDiscount.Text = totalDiscount.ToString("N0");
            lblFinalAmount.Text = totalFinal.ToString("N0");
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int invoiceID = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["ID"].Value);
                OrderDetailsForm detailsForm = new OrderDetailsForm(invoiceID);
                detailsForm.ShowDialog();
            }
        }
    }
}
