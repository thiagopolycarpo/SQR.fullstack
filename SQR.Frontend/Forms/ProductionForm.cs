using System;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;
using SQR.Frontend.ViewModels;
using SQR.Frontend.Models;

namespace SQR.Frontend.Forms
{
    public partial class ProductionForm : Form
    {
        private readonly ProductionViewModel _viewModel;
        private readonly Timer _timer;

        public ProductionForm()
        {
            InitializeComponent();
            _viewModel = new ProductionViewModel(new HttpClient());
            _timer = new Timer { Interval = 1000 };
            _timer.Tick += Timer_Tick;
            LoadOrdersAsync();
        }

        private async void LoadOrdersAsync()
        {
            try
            {
                await _viewModel.LoadOrdersAsync();
                cbOrder.Items.Clear();
                foreach (var order in _viewModel.Orders)
                {
                    cbOrder.Items.Add(order.Order);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOrder.SelectedIndex >= 0)
            {
                var selectedOrder = _viewModel.Orders[cbOrder.SelectedIndex];
                _viewModel.OrderSelectionTime = DateTime.Now;
                _viewModel.FillStartTime = DateTime.Now;
                _viewModel.RequiredCycleTime = selectedOrder.CycleTime;
                _viewModel.IsFormFilled = false;
                _viewModel.FillTimeSeconds = 0;
                _viewModel.BypassCycleTime = chkBypassCycleTime.Checked;
                lblCountdown.Text = _viewModel.BypassCycleTime ? "Bypass Ativado" : $"Tempo Restante: {(int)_viewModel.RequiredCycleTime}s";
                lblFillTime.Text = "Tempo de Preenchimento: 0s";
                _timer.Enabled = !_viewModel.BypassCycleTime;
                btnSubmit.Enabled = _viewModel.BypassCycleTime;

                lblProduct.Text = $"Produto: {selectedOrder.ProductDescription}";
                try
                {
                    if (!string.IsNullOrEmpty(selectedOrder.Image))
                    {
                        if (selectedOrder.Image.StartsWith("http"))
                        {
                            using (var client = new HttpClient())
                            {
                                var imageBytes = client.GetByteArrayAsync(selectedOrder.Image).Result;
                                using (var ms = new System.IO.MemoryStream(imageBytes))
                                {
                                    pbProductImage.Image = Image.FromStream(ms);
                                }
                            }
                        }
                        else
                        {
                            byte[] imageBytes = Convert.FromBase64String(selectedOrder.Image);
                            using (var ms = new System.IO.MemoryStream(imageBytes))
                            {
                                pbProductImage.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    else
                    {
                        pbProductImage.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pbProductImage.Image = null;
                }

                cbMaterial.Items.Clear();
                foreach (var material in selectedOrder.Materials)
                {
                    cbMaterial.Items.Add($"{material.MaterialDescription} ({material.MaterialCode})");
                }
                cbMaterial.Enabled = true;
                txtQuantity.Enabled = true;
                dtpDate.Enabled = true;
                CheckFormFilled();
            }
            else
            {
                ResetForm();
            }
        }

        private void CheckFormFilled()
        {
            _viewModel.CheckFormFilled(txtEmail.Text, cbOrder.SelectedIndex, cbMaterial.SelectedIndex, txtQuantity.Text);
            if (_viewModel.IsFormFilled)
            {
                lblFillTime.Text = $"Tempo de Preenchimento: {_viewModel.FillTimeSeconds}s";
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            CheckFormFilled();
        }

        private void cbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckFormFilled();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            CheckFormFilled();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQuantity.Text) && !decimal.TryParse(txtQuantity.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out _))
            {
                txtQuantity.BackColor = Color.FromArgb(255, 204, 204);
            }
            else
            {
                txtQuantity.BackColor = Color.White;
            }
            CheckFormFilled();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var elapsedSeconds = (DateTime.Now - _viewModel.OrderSelectionTime).TotalSeconds;
            var remainingSeconds = (int)(_viewModel.RequiredCycleTime - (decimal)elapsedSeconds);

            if (!_viewModel.IsFormFilled)
            {
                var fillSeconds = (int)(DateTime.Now - _viewModel.FillStartTime).TotalSeconds;
                lblFillTime.Text = $"Tempo de Preenchimento: {fillSeconds}s";
            }

            if (remainingSeconds > 0)
            {
                lblCountdown.Text = $"Tempo Restante: {remainingSeconds}s";
                btnSubmit.Enabled = false;
            }
            else
            {
                lblCountdown.Text = "Pronto!";
                btnSubmit.Enabled = true;
                _timer.Enabled = false;
            }
        }

        private void chkBypassCycleTime_CheckedChanged(object sender, EventArgs e)
        {
            _viewModel.BypassCycleTime = chkBypassCycleTime.Checked;
            if (_viewModel.BypassCycleTime)
            {
                _timer.Enabled = false;
                btnSubmit.Enabled = true;
                lblCountdown.Text = "Bypass Ativado";
                if (!_viewModel.IsFormFilled)
                {
                    _viewModel.FillTimeSeconds = (int)(DateTime.Now - _viewModel.FillStartTime).TotalSeconds;
                    lblFillTime.Text = $"Tempo de Preenchimento: {_viewModel.FillTimeSeconds}s";
                    _viewModel.IsFormFilled = true;
                }
            }
            else if (cbOrder.SelectedIndex >= 0)
            {
                _viewModel.OrderSelectionTime = DateTime.Now;
                _viewModel.FillStartTime = DateTime.Now;
                _viewModel.IsFormFilled = false;
                _viewModel.FillTimeSeconds = 0;
                _timer.Enabled = true;
                lblCountdown.Text = $"Tempo Restante: {(int)_viewModel.RequiredCycleTime}s";
                lblFillTime.Text = "Tempo de Preenchimento: 0s";
                CheckFormFilled();
            }
        }

        private void pbProductImage_Click(object sender, EventArgs e)
        {
            if (pbProductImage.Image != null && cbOrder.SelectedIndex >= 0)
            {
                var selectedOrder = _viewModel.Orders[cbOrder.SelectedIndex];
                MessageBox.Show($"Imagem do produto '{selectedOrder.ProductDescription}' clicada!",
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!_viewModel.IsFormFilled)
            {
                MessageBox.Show("Preencha todos os campos obrigatórios!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedOrder = _viewModel.Orders[cbOrder.SelectedIndex];
            var selectedMaterial = selectedOrder.Materials[cbMaterial.SelectedIndex];
            var cycleTime = (decimal)(DateTime.Now - _viewModel.OrderSelectionTime).TotalSeconds;

            var result = await _viewModel.SubmitProductionAsync(
                txtEmail.Text,
                selectedOrder.Order,
                dtpDate.Value,
                decimal.Parse(txtQuantity.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture),
                selectedMaterial.MaterialCode,
                cycleTime);

            MessageBox.Show(
                result.Type == "S" ? $"{result.Description}\nTempo de Preenchimento: {_viewModel.FillTimeSeconds}s" : result.Description,
                result.Type == "S" ? "Sucesso" : "Erro",
                MessageBoxButtons.OK,
                result.Type == "S" ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (result.Type == "S")
            {
                ResetForm();
            }
        }

        private void ResetForm()
        {
            txtEmail.Clear();
            txtQuantity.Clear();
            cbOrder.SelectedIndex = -1;
            cbMaterial.Items.Clear();
            cbMaterial.Enabled = false;
            txtQuantity.Enabled = false;
            dtpDate.Enabled = false;
            btnSubmit.Enabled = false;
            lblProduct.Text = "Produto:";
            pbProductImage.Image = null;
            _timer.Enabled = false;
            lblCountdown.Text = "Tempo Restante: 0s";
            lblFillTime.Text = "Tempo de Preenchimento: 0s";
            _viewModel.IsFormFilled = false;
            _viewModel.FillTimeSeconds = 0;
        }

        private void btnViewApontamentos_Click(object sender, EventArgs e)
        {
            using (var apontamentosForm = new ApontamentosForm(new HttpClient()))
            {
                apontamentosForm.ShowDialog();
            }
        }

        private void btnSubmit_MouseEnter(object sender, EventArgs e)
        {
            btnSubmit.BackColor = Color.FromArgb(30, 144, 255);
        }

        private void btnSubmit_MouseLeave(object sender, EventArgs e)
        {
            btnSubmit.BackColor = Color.FromArgb(0, 120, 212);
        }

        private void btnViewApontamentos_MouseEnter(object sender, EventArgs e)
        {
            btnViewApontamentos.BackColor = Color.FromArgb(30, 144, 255);
        }

        private void btnViewApontamentos_MouseLeave(object sender, EventArgs e)
        {
            btnViewApontamentos.BackColor = Color.FromArgb(0, 120, 212);
        }
    }
}