namespace Lab_Advanced_Command
{
    partial class AccountActivityForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblAccountTitle;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.ListBox lbInvoices;
        private System.Windows.Forms.DataGridView dgvInvoiceDetails;
        private System.Windows.Forms.Label lblInvoiceCountTitle;
        private System.Windows.Forms.Label lblInvoiceCount;
        private System.Windows.Forms.Label lblTotalRevenueTitle;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblAccountTitle = new System.Windows.Forms.Label();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.lbInvoices = new System.Windows.Forms.ListBox();
            this.dgvInvoiceDetails = new System.Windows.Forms.DataGridView();
            this.lblInvoiceCountTitle = new System.Windows.Forms.Label();
            this.lblInvoiceCount = new System.Windows.Forms.Label();
            this.lblTotalRevenueTitle = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAccountTitle
            // 
            this.lblAccountTitle.AutoSize = true;
            this.lblAccountTitle.Location = new System.Drawing.Point(20, 15);
            this.lblAccountTitle.Name = "lblAccountTitle";
            this.lblAccountTitle.Size = new System.Drawing.Size(74, 17);
            this.lblAccountTitle.Text = "Tài khoản:";
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Location = new System.Drawing.Point(100, 15);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(88, 17);
            this.lblAccountName.Text = "(chưa thiết lập)";
            // 
            // lbInvoices
            // 
            this.lbInvoices.FormattingEnabled = true;
            this.lbInvoices.ItemHeight = 17;
            this.lbInvoices.Location = new System.Drawing.Point(20, 45);
            this.lbInvoices.Name = "lbInvoices";
            this.lbInvoices.Size = new System.Drawing.Size(200, 276);
            this.lbInvoices.TabIndex = 0;
            this.lbInvoices.SelectedIndexChanged += new System.EventHandler(this.lbInvoices_SelectedIndexChanged);
            // 
            // dgvInvoiceDetails
            // 
            this.dgvInvoiceDetails.AllowUserToAddRows = false;
            this.dgvInvoiceDetails.AllowUserToDeleteRows = false;
            this.dgvInvoiceDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoiceDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceDetails.Location = new System.Drawing.Point(235, 45);
            this.dgvInvoiceDetails.Name = "dgvInvoiceDetails";
            this.dgvInvoiceDetails.ReadOnly = true;
            this.dgvInvoiceDetails.RowTemplate.Height = 24;
            this.dgvInvoiceDetails.Size = new System.Drawing.Size(385, 276);
            this.dgvInvoiceDetails.TabIndex = 1;
            // 
            // lblInvoiceCountTitle
            // 
            this.lblInvoiceCountTitle.AutoSize = true;
            this.lblInvoiceCountTitle.Location = new System.Drawing.Point(20, 340);
            this.lblInvoiceCountTitle.Name = "lblInvoiceCountTitle";
            this.lblInvoiceCountTitle.Size = new System.Drawing.Size(96, 17);
            this.lblInvoiceCountTitle.Text = "Số hóa đơn:";
            // 
            // lblInvoiceCount
            // 
            this.lblInvoiceCount.AutoSize = true;
            this.lblInvoiceCount.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblInvoiceCount.Location = new System.Drawing.Point(120, 340);
            this.lblInvoiceCount.Name = "lblInvoiceCount";
            this.lblInvoiceCount.Size = new System.Drawing.Size(16, 17);
            this.lblInvoiceCount.Text = "0";
            // 
            // lblTotalRevenueTitle
            // 
            this.lblTotalRevenueTitle.AutoSize = true;
            this.lblTotalRevenueTitle.Location = new System.Drawing.Point(235, 340);
            this.lblTotalRevenueTitle.Name = "lblTotalRevenueTitle";
            this.lblTotalRevenueTitle.Size = new System.Drawing.Size(109, 17);
            this.lblTotalRevenueTitle.Text = "Tổng doanh thu:";
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.Location = new System.Drawing.Point(350, 340);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(16, 17);
            this.lblTotalRevenue.Text = "0";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(545, 335);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AccountActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 380);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTotalRevenue);
            this.Controls.Add(this.lblTotalRevenueTitle);
            this.Controls.Add(this.lblInvoiceCount);
            this.Controls.Add(this.lblInvoiceCountTitle);
            this.Controls.Add(this.dgvInvoiceDetails);
            this.Controls.Add(this.lbInvoices);
            this.Controls.Add(this.lblAccountName);
            this.Controls.Add(this.lblAccountTitle);
            this.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhật ký hoạt động";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}