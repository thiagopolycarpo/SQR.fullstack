namespace SQR.Frontend
{
    partial class ProductionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.ComboBox cbOrder;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.PictureBox pbProductImage;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.ComboBox cbMaterial;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Timer tmrCycleTime;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblOrder = new System.Windows.Forms.Label();
            this.cbOrder = new System.Windows.Forms.ComboBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.pbProductImage = new System.Windows.Forms.PictureBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.cbMaterial = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.tmrCycleTime = new System.Windows.Forms.Timer(this.components);
            this.btnViewApontamentos = new System.Windows.Forms.Button();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.lblFillTime = new System.Windows.Forms.Label();
            this.chkBypassCycleTime = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(12, 15);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 13);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "E-mail:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(83, 12);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 22);
            this.txtEmail.TabIndex = 1;
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder.Location = new System.Drawing.Point(12, 45);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(45, 13);
            this.lblOrder.TabIndex = 2;
            this.lblOrder.Text = "Ordem:";
            // 
            // cbOrder
            // 
            this.cbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOrder.Location = new System.Drawing.Point(83, 42);
            this.cbOrder.Name = "cbOrder";
            this.cbOrder.Size = new System.Drawing.Size(200, 21);
            this.cbOrder.TabIndex = 3;
            this.cbOrder.SelectedIndexChanged += new System.EventHandler(this.cbOrder_SelectedIndexChanged);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(12, 75);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(53, 13);
            this.lblProduct.TabIndex = 4;
            this.lblProduct.Text = "Produto:";
            // 
            // pbProductImage
            // 
            this.pbProductImage.Enabled = false;
            this.pbProductImage.Location = new System.Drawing.Point(83, 95);
            this.pbProductImage.Name = "pbProductImage";
            this.pbProductImage.Size = new System.Drawing.Size(100, 100);
            this.pbProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProductImage.TabIndex = 5;
            this.pbProductImage.TabStop = false;
            this.pbProductImage.Click += new System.EventHandler(this.pbProductImage_Click);
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterial.Location = new System.Drawing.Point(12, 205);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(53, 13);
            this.lblMaterial.TabIndex = 6;
            this.lblMaterial.Text = "Material:";
            // 
            // cbMaterial
            // 
            this.cbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaterial.Enabled = false;
            this.cbMaterial.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaterial.Location = new System.Drawing.Point(83, 202);
            this.cbMaterial.Name = "cbMaterial";
            this.cbMaterial.Size = new System.Drawing.Size(200, 21);
            this.cbMaterial.TabIndex = 7;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(12, 235);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "Data:";
            // 
            // dtpDate
            // 
            this.dtpDate.Enabled = false;
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(83, 232);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDate.TabIndex = 9;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(12, 265);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(71, 13);
            this.lblQuantity.TabIndex = 10;
            this.lblQuantity.Text = "Quantidade:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Enabled = false;
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(83, 262);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(124, 22);
            this.txtQuantity.TabIndex = 11;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSubmit.Enabled = false;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(213, 339);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 22);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "Enviar";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // tmrCycleTime
            // 
            this.tmrCycleTime.Interval = 1000;
            this.tmrCycleTime.Tick += new System.EventHandler(this.tmrCycleTime_Tick);
            // 
            // btnViewApontamentos
            // 
            this.btnViewApontamentos.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnViewApontamentos.FlatAppearance.BorderSize = 0;
            this.btnViewApontamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewApontamentos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewApontamentos.ForeColor = System.Drawing.Color.White;
            this.btnViewApontamentos.Location = new System.Drawing.Point(83, 339);
            this.btnViewApontamentos.Name = "btnViewApontamentos";
            this.btnViewApontamentos.Size = new System.Drawing.Size(124, 22);
            this.btnViewApontamentos.TabIndex = 13;
            this.btnViewApontamentos.Text = "Ver Apontamentos";
            this.btnViewApontamentos.UseVisualStyleBackColor = false;
            this.btnViewApontamentos.Click += new System.EventHandler(this.btnViewApontamentos_Click);
            // 
            // lblCountdown
            // 
            this.lblCountdown.AutoSize = true;
            this.lblCountdown.Location = new System.Drawing.Point(12, 320);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(103, 13);
            this.lblCountdown.TabIndex = 14;
            this.lblCountdown.Text = "Tempo Restante: 0s";
            // 
            // lblFillTime
            // 
            this.lblFillTime.AutoSize = true;
            this.lblFillTime.Location = new System.Drawing.Point(12, 298);
            this.lblFillTime.Name = "lblFillTime";
            this.lblFillTime.Size = new System.Drawing.Size(146, 13);
            this.lblFillTime.TabIndex = 15;
            this.lblFillTime.Text = "Tempo de Preenchimento: 0s";
            // 
            // chkBypassCycleTime
            // 
            this.chkBypassCycleTime.AutoSize = true;
            this.chkBypassCycleTime.Location = new System.Drawing.Point(138, 319);
            this.chkBypassCycleTime.Name = "chkBypassCycleTime";
            this.chkBypassCycleTime.Size = new System.Drawing.Size(145, 17);
            this.chkBypassCycleTime.TabIndex = 16;
            this.chkBypassCycleTime.Text = "Ignorar o Tempo de Ciclo";
            this.chkBypassCycleTime.UseVisualStyleBackColor = true;
            this.chkBypassCycleTime.Visible = false;
            // 
            // ProductionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 373);
            this.Controls.Add(this.chkBypassCycleTime);
            this.Controls.Add(this.lblFillTime);
            this.Controls.Add(this.lblCountdown);
            this.Controls.Add(this.btnViewApontamentos);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cbMaterial);
            this.Controls.Add(this.lblMaterial);
            this.Controls.Add(this.pbProductImage);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.cbOrder);
            this.Controls.Add(this.lblOrder);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Name = "ProductionForm";
            this.Text = "Apontamento de Produção";
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Button btnViewApontamentos;
        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.Label lblFillTime;
        private System.Windows.Forms.CheckBox chkBypassCycleTime;
    }
}