
namespace SE1438_Group2_Lab3.GUI
{
    partial class Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.tbFrom = new System.Windows.Forms.TextBox();
            this.tbTo = new System.Windows.Forms.TextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbCountry = new System.Windows.Forms.TextBox();
            this.lbFrom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dvOrder = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dvOrderDetail = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dvOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvOrderDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(18, 1);
            this.monthCalendar.MaxSelectionCount = 31;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // tbFrom
            // 
            this.tbFrom.Location = new System.Drawing.Point(100, 220);
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.Size = new System.Drawing.Size(180, 22);
            this.tbFrom.TabIndex = 1;
            // 
            // tbTo
            // 
            this.tbTo.Location = new System.Drawing.Point(100, 251);
            this.tbTo.Name = "tbTo";
            this.tbTo.Size = new System.Drawing.Size(180, 22);
            this.tbTo.TabIndex = 2;
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(100, 282);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(180, 22);
            this.tbFirstName.TabIndex = 3;
            // 
            // tbCountry
            // 
            this.tbCountry.Location = new System.Drawing.Point(100, 311);
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.Size = new System.Drawing.Size(180, 22);
            this.tbCountry.TabIndex = 4;
            // 
            // lbFrom
            // 
            this.lbFrom.AutoSize = true;
            this.lbFrom.Location = new System.Drawing.Point(38, 225);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(44, 17);
            this.lbFrom.TabIndex = 5;
            this.lbFrom.Text = "From:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "To:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "First Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Country:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(315, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Order:";
            // 
            // dvOrder
            // 
            this.dvOrder.AllowUserToAddRows = false;
            this.dvOrder.AllowUserToDeleteRows = false;
            this.dvOrder.AllowUserToResizeColumns = false;
            this.dvOrder.AllowUserToResizeRows = false;
            this.dvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvOrder.Location = new System.Drawing.Point(318, 30);
            this.dvOrder.Name = "dvOrder";
            this.dvOrder.ReadOnly = true;
            this.dvOrder.RowHeadersWidth = 51;
            this.dvOrder.RowTemplate.Height = 24;
            this.dvOrder.Size = new System.Drawing.Size(865, 178);
            this.dvOrder.TabIndex = 10;
            this.dvOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvOrder_CellClick);
            this.dvOrder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvOrder_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(315, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Order detail:";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(100, 354);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(132, 23);
            this.btnFilter.TabIndex = 13;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dvOrderDetail
            // 
            this.dvOrderDetail.AllowUserToAddRows = false;
            this.dvOrderDetail.AllowUserToDeleteRows = false;
            this.dvOrderDetail.AllowUserToResizeColumns = false;
            this.dvOrderDetail.AllowUserToResizeRows = false;
            this.dvOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvOrderDetail.Location = new System.Drawing.Point(318, 251);
            this.dvOrderDetail.Name = "dvOrderDetail";
            this.dvOrderDetail.ReadOnly = true;
            this.dvOrderDetail.RowHeadersWidth = 51;
            this.dvOrderDetail.RowTemplate.Height = 24;
            this.dvOrderDetail.Size = new System.Drawing.Size(865, 150);
            this.dvOrderDetail.TabIndex = 11;
            this.dvOrderDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvOrderDetail_CellContentClick);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 450);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dvOrderDetail);
            this.Controls.Add(this.dvOrder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbFrom);
            this.Controls.Add(this.tbCountry);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.tbTo);
            this.Controls.Add(this.tbFrom);
            this.Controls.Add(this.monthCalendar);
            this.Name = "Report";
            this.Text = "Report";
            ((System.ComponentModel.ISupportInitialize)(this.dvOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvOrderDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.TextBox tbFrom;
        private System.Windows.Forms.TextBox tbTo;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbCountry;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dvOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView dvOrderDetail;
    }
}