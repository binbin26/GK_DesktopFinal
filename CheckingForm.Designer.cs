namespace GK_Desktop
{
    partial class CheckingForm
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
            this.btnDes = new System.Windows.Forms.Button();
            this.btnDis = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDes
            // 
            this.btnDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDes.Location = new System.Drawing.Point(108, 348);
            this.btnDes.Name = "btnDes";
            this.btnDes.Size = new System.Drawing.Size(92, 33);
            this.btnDes.TabIndex = 0;
            this.btnDes.Text = "Deposit";
            this.btnDes.UseVisualStyleBackColor = true;
            this.btnDes.Click += new System.EventHandler(this.btnDes_Click);
            // 
            // btnDis
            // 
            this.btnDis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDis.Location = new System.Drawing.Point(519, 348);
            this.btnDis.Name = "btnDis";
            this.btnDis.Size = new System.Drawing.Size(164, 33);
            this.btnDis.TabIndex = 1;
            this.btnDis.Text = "Display Transaction";
            this.btnDis.UseVisualStyleBackColor = true;
            this.btnDis.Click += new System.EventHandler(this.btnDis_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblName.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblName.Location = new System.Drawing.Point(123, 45);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(46, 17);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "label1";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblID.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblID.Location = new System.Drawing.Point(123, 99);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(46, 17);
            this.lblID.TabIndex = 3;
            this.lblID.Text = "label2";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblAddress.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblAddress.Location = new System.Drawing.Point(123, 151);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(46, 17);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "label3";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPhone.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblPhone.Location = new System.Drawing.Point(123, 197);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(46, 17);
            this.lblPhone.TabIndex = 5;
            this.lblPhone.Text = "label4";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblBalance.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblBalance.Location = new System.Drawing.Point(123, 247);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(46, 17);
            this.lblBalance.TabIndex = 6;
            this.lblBalance.Text = "label5";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblType.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblType.Location = new System.Drawing.Point(123, 292);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(46, 17);
            this.lblType.TabIndex = 7;
            this.lblType.Text = "label6";
            // 
            // CheckingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnDis);
            this.Controls.Add(this.btnDes);
            this.Name = "CheckingForm";
            this.Text = "HomeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDes;
        private System.Windows.Forms.Button btnDis;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblType;
    }
}