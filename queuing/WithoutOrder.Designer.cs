namespace queuing
{
    partial class WithoutOrder
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
            this.btnTicket = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIDCard = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTicket
            // 
            this.btnTicket.Location = new System.Drawing.Point(129, 185);
            this.btnTicket.Name = "btnTicket";
            this.btnTicket.Size = new System.Drawing.Size(152, 65);
            this.btnTicket.TabIndex = 0;
            this.btnTicket.Text = "出号";
            this.btnTicket.UseVisualStyleBackColor = true;
            this.btnTicket.Click += new System.EventHandler(this.btnTicket_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "身份证号：";
            // 
            // lblIDCard
            // 
            this.lblIDCard.AutoSize = true;
            this.lblIDCard.Location = new System.Drawing.Point(72, 9);
            this.lblIDCard.Name = "lblIDCard";
            this.lblIDCard.Size = new System.Drawing.Size(41, 12);
            this.lblIDCard.TabIndex = 2;
            this.lblIDCard.Text = "label2";
            // 
            // WithoutOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 262);
            this.Controls.Add(this.lblIDCard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTicket);
            this.Name = "WithoutOrder";
            this.Text = "WithoutOrder";
            this.Load += new System.EventHandler(this.WithoutOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTicket;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIDCard;
    }
}