namespace SQR.Frontend.Forms
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
        private System.Windows.Forms.Button btnViewApontamentos;
        private System.Windows.Forms.GroupBox groupBoxOrder;
        private System.Windows.Forms.GroupBox groupBoxProduction;
        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.CheckBox chkBypassCycleTime;
        private System.Windows.Forms.Label lblFillTime;

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
            this.groupBoxOrder = new System.Windows.Forms.GroupBox();
            this.groupBoxProduction = new System.Windows.Forms.GroupBox();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.chkBypassCycleTime = new System.Windows.Forms.CheckBox();
            this.lblFillTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).BeginInit();
            this.groupBoxOrder.SuspendLayout();
            this.groupBoxProduction.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(10, 20);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "E-mail:";
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(100, 20);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 23);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Location = new System.Drawing.Point(10, 50);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(41, 13);
            this.lblOrder.TabIndex = 2;
            this.lblOrder.Text = "Ordem:";
            this.lblOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrder.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            // 
            // cbOrder
            // 
            this.cbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrder.Location = new System.Drawing.Point(100, 50);
            this.cbOrder.Name = "cbOrder";
            this.cbOrder.Size = new System.Drawing.Size(200, 23);
            this.cbOrder.TabIndex = 3;
            this.cbOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbOrder.SelectedIndexChanged += new System.EventHandler(this.cbOrder_SelectedIndexChanged);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(10, 80);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(47, 13);
            this.lblProduct.TabIndex = 4;
            this.lblProduct.Text = "Produto:";
            this.lblProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProduct.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            // 
            // pbProductImage
            // 
            this.pbProductImage.Location = new System.Drawing.Point(100, 100);
            this.pbProductImage.Name = "pbProductImage";
            this.pbProductImage.Size = new System.Drawing.Size(120, 120);
            this.pbProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProductImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbProductImage.TabIndex = 5;
            this.pbProductImage.TabStop = false;
            this.pbProductImage.Click += new System.EventHandler(this.pbProductImage_Click);
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(10, 20);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(47, 13);
            this.lblMaterial.TabIndex = 6;
            this.lblMaterial.Text = "Material:";
            this.lblMaterial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaterial.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            // 
            // cbMaterial
            // 
            this.cbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaterial.Enabled = false;
            this.cbMaterial.Location = new System.Drawing.Point(100, 20);
            this.cbMaterial.Name = "cbMaterial";
            this.cbMaterial.Size = new System.Drawing.Size(200, 23);
            this.cbMaterial.TabIndex = 7;
            this.cbMaterial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbMaterial.SelectedIndexChanged += new System.EventHandler(this.cbMaterial_SelectedIndexChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(10, 50);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "Data:";
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            // 
            // dtpDate
            // 
            this.dtpDate.Enabled = false;
            this.dtpDate.Location = new System.Drawing.Point(100, 50);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 23);
            this.dtpDate.TabIndex = 9;
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(10, 80);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(65, 13);
            this.lblQuantity.TabIndex = 10;
            this.lblQuantity.Text = "Quantidade:";
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQuantity.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Enabled = false;
            this.txtQuantity.Location = new System.Drawing.Point(100, 80);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 23);
            this.txtQuantity.TabIndex = 11;
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(220, 160);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(90, 30);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "Enviar";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(0, 120, 212);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.MouseEnter += new System.EventHandler(this.btnSubmit_MouseEnter);
            this.btnSubmit.MouseLeave += new System.EventHandler(this.btnSubmit_MouseLeave);
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // tmrCycleTime
            // 
            this.tmrCycleTime.Interval = 1000;
            this.tmrCycleTime.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // btnViewApontamentos
            // 
            this.btnViewApontamentos.Location = new System.Drawing.Point(100, 160);
            this.btnViewApontamentos.Name = "btnViewApontamentos";
            this.btnViewApontamentos.Size = new System.Drawing.Size(110, 30);
            this.btnViewApontamentos.TabIndex = 13;
            this.btnViewApontamentos.Text = "Ver Apontamentos";
            this.btnViewApontamentos.UseVisualStyleBackColor = false;
            this.btnViewApontamentos.BackColor = System.Drawing.Color.FromArgb(0, 120, 212);
            this.btnViewApontamentos.ForeColor = System.Drawing.Color.White;
            this.btnViewApontamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewApontamentos.FlatAppearance.BorderSize = 0;
            this.btnViewApontamentos.MouseEnter += new System.EventHandler(this.btnViewApontamentos_MouseEnter);
            this.btnViewApontamentos.MouseLeave += new System.EventHandler(this.btnViewApontamentos_MouseLeave);
            this.btnViewApontamentos.Click += new System.EventHandler(this.btnViewApontamentos_Click);
            // 
            // groupBoxOrder
            // 
            this.groupBoxOrder.Controls.Add(this.lblEmail);
            this.groupBoxOrder.Controls.Add(this.txtEmail);
            this.groupBoxOrder.Controls.Add(this.lblOrder);
            this.groupBoxOrder.Controls.Add(this.cbOrder);
            this.groupBoxOrder.Controls.Add(this.lblProduct);
            this.groupBoxOrder.Controls.Add(this.pbProductImage);
            this.groupBoxOrder.Location = new System.Drawing.Point(10, 10);
            this.groupBoxOrder.Name = "groupBoxOrder";
            this.groupBoxOrder.Size = new System.Drawing.Size(360, 230);
            this.groupBoxOrder.TabIndex = 14;
            this.groupBoxOrder.TabStop = false;
            this.groupBoxOrder.Text = "Informações da Ordem";
            this.groupBoxOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            // 
            // groupBoxProduction
            // 
            this.groupBoxProduction.Controls.Add(this.lblMaterial);
            this.groupBoxProduction.Controls.Add(this.cbMaterial);
            this.groupBoxProduction.Controls.Add(this.lblDate);
            this.groupBoxProduction.Controls.Add(this.dtpDate);
            this.groupBoxProduction.Controls.Add(this.lblQuantity);
            this.groupBoxProduction.Controls.Add(this.txtQuantity);
            this.groupBoxProduction.Controls.Add(this.btnSubmit);
            this.groupBoxProduction.Controls.Add(this.btnViewApontamentos);
            this.groupBoxProduction.Controls.Add(this.lblCountdown);
            this.groupBoxProduction.Controls.Add(this.chkBypassCycleTime);
            this.groupBoxProduction.Controls.Add(this.lblFillTime);
            this.groupBoxProduction.Location = new System.Drawing.Point(10, 250);
            this.groupBoxProduction.Name = "groupBoxProduction";
            this.groupBoxProduction.Size = new System.Drawing.Size(360, 230);
            this.groupBoxProduction.TabIndex = 15;
            this.groupBoxProduction.TabStop = false;
            this.groupBoxProduction.Text = "Detalhes do Apontamento";
            this.groupBoxProduction.Font = new System.Drawing.Font("Segoe UI", 9F);
            // 
            // lblCountdown
            // 
            this.lblCountdown.AutoSize = true;
            this.lblCountdown.Location = new System.Drawing.Point(10, 110);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(100, 13);
            this.lblCountdown.TabIndex = 16;
            this.lblCountdown.Text = "Tempo Restante: 0s";
            this.lblCountdown.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCountdown.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            // 
            // chkBypassCycleTime
            // 
            this.chkBypassCycleTime.AutoSize = true;
            this.chkBypassCycleTime.Location = new System.Drawing.Point(100, 130);
            this.chkBypassCycleTime.Name = "chkBypassCycleTime";
            this.chkBypassCycleTime.Size = new System.Drawing.Size(150, 17);
            this.chkBypassCycleTime.TabIndex = 17;
            this.chkBypassCycleTime.Text = "Ignorar Tempo de Ciclo";
            this.chkBypassCycleTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkBypassCycleTime.CheckedChanged += new System.EventHandler(this.chkBypassCycleTime_CheckedChanged);
            // 
            // lblFillTime
            // 
            this.lblFillTime.AutoSize = true;
            this.lblFillTime.Location = new System.Drawing.Point(10, 130);
            this.lblFillTime.Name = "lblFillTime";
            this.lblFillTime.Size = new System.Drawing.Size(150, 13);
            this.lblFillTime.TabIndex = 18;
            this.lblFillTime.Text = "Tempo de Preenchimento: 0s";
            this.lblFillTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFillTime.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            // 
            // ProductionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.groupBoxProduction);
            this.Controls.Add(this.groupBoxOrder);
            this.Name = "ProductionForm";
            this.Text = "Apontamento de Produção";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).EndInit();
            this.groupBoxOrder.ResumeLayout(false);
            this.groupBoxOrder.PerformLayout();
            this.groupBoxProduction.ResumeLayout(false);
            this.groupBoxProduction.PerformLayout();
            this.ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}