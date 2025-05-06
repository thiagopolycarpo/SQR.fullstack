using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQR.Frontend.Models;
using System.Configuration;
using System.Globalization;

namespace SQR.Frontend
{
    public partial class ProductionForm : Form
    {
        private readonly HttpClient _httpClient;
        private List<OrderResponse> _orders;
        private DateTime _orderSelectionTime;
        private DateTime _fillStartTime; // Novo: para rastrear início do preenchimento
        private decimal _requiredCycleTime;

        public ProductionForm()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"]);
            _orders = new List<OrderResponse>();
            _requiredCycleTime = 0;
            LoadOrders();
        }

        private async void LoadOrders()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/orders/GetOrders");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<OrdersResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                _orders = result.Orders;

                cbOrder.Items.Clear();
                foreach (var order in _orders)
                {
                    cbOrder.Items.Add(order.Order);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar ordens: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOrder.SelectedIndex >= 0)
            {
                var selectedOrder = _orders[cbOrder.SelectedIndex];
                _orderSelectionTime = DateTime.Now;
                _fillStartTime = DateTime.Now; // Inicia contagem do preenchimento
                _requiredCycleTime = selectedOrder.CycleTime;
                lblCountdown.Text = chkBypassCycleTime.Checked ? "Bypass Ativado" : $"Tempo Restante: {(int)_requiredCycleTime}s";
                lblFillTime.Text = "Tempo de Preenchimento: 0s"; // Reseta
                tmrCycleTime.Enabled = !chkBypassCycleTime.Checked;
                btnSubmit.Enabled = chkBypassCycleTime.Checked;

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
            }
            else
            {
                lblProduct.Text = "Produto:";
                pbProductImage.Image = null;
                cbMaterial.Items.Clear();
                cbMaterial.Enabled = false;
                txtQuantity.Enabled = false;
                dtpDate.Enabled = false;
                btnSubmit.Enabled = false;
                lblCountdown.Text = "Tempo Restante: 0s";
                lblFillTime.Text = "Tempo de Preenchimento: 0s";
                tmrCycleTime.Enabled = false;
            }
        }

        private void tmrCycleTime_Tick(object sender, EventArgs e)
        {
            var elapsedSeconds = (DateTime.Now - _orderSelectionTime).TotalSeconds;
            var remainingSeconds = (int)(_requiredCycleTime - (decimal)elapsedSeconds);
            var fillSeconds = (int)(DateTime.Now - _fillStartTime).TotalSeconds;

            lblFillTime.Text = $"Tempo de Preenchimento: {fillSeconds}s"; // Atualiza tempo de preenchimento

            if (remainingSeconds > 0)
            {
                lblCountdown.Text = $"Tempo Restante: {remainingSeconds}s";
                btnSubmit.Enabled = false;
            }
            else
            {
                lblCountdown.Text = "Pronto!";
                btnSubmit.Enabled = true;
                tmrCycleTime.Enabled = false;
            }
        }

        private void chkBypassCycleTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBypassCycleTime.Checked)
            {
                tmrCycleTime.Enabled = false;
                btnSubmit.Enabled = true;
                lblCountdown.Text = "Bypass Ativado";
            }
            else if (cbOrder.SelectedIndex >= 0)
            {
                _orderSelectionTime = DateTime.Now;
                _fillStartTime = DateTime.Now; // Reseta preenchimento
                tmrCycleTime.Enabled = true;
                lblCountdown.Text = $"Tempo Restante: {(int)_requiredCycleTime}s";
                lblFillTime.Text = "Tempo de Preenchimento: 0s";
            }
        }

        private void pbProductImage_Click(object sender, EventArgs e)
        {
            if (pbProductImage.Image != null && cbOrder.SelectedIndex >= 0)
            {
                var selectedOrder = _orders[cbOrder.SelectedIndex];
                MessageBox.Show($"Imagem do produto '{selectedOrder.ProductDescription}' clicada!",
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cbOrder.SelectedIndex < 0 || cbMaterial.SelectedIndex < 0 || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedOrder = _orders[cbOrder.SelectedIndex];
                var selectedMaterial = selectedOrder.Materials[cbMaterial.SelectedIndex];
                var cycleTime = (decimal)(DateTime.Now - _orderSelectionTime).TotalSeconds;
                var fillTime = (int)(DateTime.Now - _fillStartTime).TotalSeconds; // Calcula tempo final

                if (!decimal.TryParse(txtQuantity.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal quantity))
                {
                    MessageBox.Show("Quantidade deve ser um número válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var request = new SetProductionRequest
                {
                    Email = txtEmail.Text,
                    Order = selectedOrder.Order,
                    ProductionDate = dtpDate.Value.ToString("yyyy-MM-dd"),
                    ProductionTime = dtpDate.Value.ToString("HH:mm:ss"),
                    Quantity = quantity,
                    MaterialCode = selectedMaterial.MaterialCode,
                    CycleTime = cycleTime
                };

                var json = JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/orders/SetProduction", content);

                if (!response.IsSuccessStatusCode)
                {
                    try
                    {
                        var errorJson = await response.Content.ReadAsStringAsync();
                        var errorResult = JsonSerializer.Deserialize<SetProductionResponse>(errorJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        if (errorResult != null)
                        {
                            MessageBox.Show(errorResult.Description, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show($"Erro na resposta da API: {response.ReasonPhrase}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                var responseJson = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<SetProductionResponse>(responseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (result == null)
                {
                    MessageBox.Show("Resposta inválida da API", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Exibe tempo de preenchimento na mensagem de sucesso
                var message = result.Type == "S" ? $"{result.Description}\nTempo de Preenchimento: {fillTime}s" : result.Description;
                MessageBox.Show(message, result.Type == "S" ? "Sucesso" : "Erro", MessageBoxButtons.OK, result.Type == "S" ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result.Type == "S")
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
                    tmrCycleTime.Enabled = false;
                    lblCountdown.Text = "Tempo Restante: 0s";
                    lblFillTime.Text = "Tempo de Preenchimento: 0s";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao enviar apontamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewApontamentos_Click(object sender, EventArgs e)
        {
            using (var apontamentosForm = new ApontamentosForm(_httpClient))
            {
                apontamentosForm.ShowDialog();
            }
        }

        private class OrdersResponse
        {
            public List<OrderResponse> Orders { get; set; }
        }
    }
}