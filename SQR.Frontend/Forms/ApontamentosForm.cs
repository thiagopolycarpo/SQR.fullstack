using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQR.Frontend.Models;

namespace SQR.Frontend
{
    public partial class ApontamentosForm : Form
    {
        private readonly HttpClient _httpClient;

        public ApontamentosForm(HttpClient httpClient)
        {
            InitializeComponent();
            _httpClient = httpClient;
            ConfigureGridColumns();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Por favor, insira um email.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var url = $"api/orders/GetProduction?email={Uri.EscapeDataString(txtEmail.Text)}";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    var errorJson = await response.Content.ReadAsStringAsync();
                    var errorResult = JsonSerializer.Deserialize<SetProductionResponse>(errorJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    MessageBox.Show(errorResult?.Description ?? $"Erro na resposta da API: {response.ReasonPhrase}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ProductionsResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (result?.Productions == null || result.Productions.Count == 0)
                {
                    MessageBox.Show("Nenhum apontamento encontrado para este email.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvProductions.DataSource = null;
                    return;
                }

                dgvProductions.DataSource = result.Productions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar apontamentos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureGridColumns()
        {
            dgvProductions.AutoGenerateColumns = false; 
            dgvProductions.Columns.Clear();

            dgvProductions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Name = "Email"
            });
            dgvProductions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Order",
                HeaderText = "Ordem",
                Name = "Order"
            });
            dgvProductions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductionDate",
                HeaderText = "Data/Hora",
                Name = "Date"
            });
            dgvProductions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Quantidade",
                Name = "Quantity"
            });
            dgvProductions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaterialCode",
                HeaderText = "Código Material",
                Name = "MaterialCode"
            });
            dgvProductions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaterialDescription",
                HeaderText = "Descrição Material",
                Name = "MaterialDescription"
            });
            dgvProductions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CycleTime",
                HeaderText = "Tempo de Ciclo (s)",
                Name = "CycleTime"
            });
        }

    }
}