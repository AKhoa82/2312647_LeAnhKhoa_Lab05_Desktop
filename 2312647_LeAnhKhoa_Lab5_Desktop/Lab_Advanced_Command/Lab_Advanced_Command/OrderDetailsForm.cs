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
    public partial class OrderDetailsForm : Form
    {
        private int _invoiceID;
        public OrderDetailsForm(int invoiceID)
        {
            InitializeComponent();
            _invoiceID = invoiceID;
            LoadBillDetails();
        }

        private void LoadBillDetails()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Execute GetBillDetailsByID @InvoiceID";

            cmd.Parameters.Add("@InvoiceID", SqlDbType.Int).Value = _invoiceID;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            conn.Open();
            adapter.Fill(dt);
            conn.Close();

            dgvOrderDetails.DataSource = dt;
        }
    }
}
