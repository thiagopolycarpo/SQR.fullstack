# Instruções de Execução - SQR Solution

## Pré-requisitos
- .NET 6.0 SDK
- SQL Server (instância LAPTOP-UTH4Q39O\SQLEXPRESS)
- Visual Studio 2022 (opcional, para desenvolvimento e testes)

## Configuração do Banco
1. Execute o script `SQR.TestData.sql` no SQL Server para criar o banco `SQRPRODUCTION` e inserir dados de teste (ordens 111 e 222, produtos, materiais).
2. Verifique a string de conexão em `SQR.Backend/appsettings.json`.

## Estrutura do Projeto
- **SQR.Backend**: API RESTful em ASP.NET Core, usando MVC.
  - `Controllers/`: Contém `OrdersController` para endpoints.
  - `Services/`: Lógica de negócio em `ProductionService`.
  - `Repositories/`: Acesso ao banco em `ProductionRepository`.
  - `Models/`: Classes de dados como `Production`, `Order`.
  - `Data/`: Contexto do Entity Framework (`ProductionContext`).
- **SQR.Frontend**: Aplicativo Windows Forms.
  - `Forms/`: Telas `ProductionForm` e `ApontamentosForm`.
  - `ViewModels/`: Lógica de apresentação em `ProductionViewModel`.
  - `Models/`: Classes para respostas da API.
- **SQR.Tests**: Testes unitários com xUnit, cobrindo `OrdersController`.

## Executando o SQR.Backend
1. Navegue até `C:\SQRSolution\SQR.Backend.Publish`
2. Execute: `"C:\Program Files\dotnet\dotnet.exe" SQR.Backend.dll`
3. API disponível em `http://localhost:11100/`

## Executando o SQR.Frontend
1. Navegue até `C:\SQRSolution\SQR.Frontend.Publish`
2. Execute `SQR.Frontend.exe`
3. Verifique `App.config` (`ApiBaseUrl = http://localhost:11100/`)

## Funcionalidades
- **ProductionForm**: Cria apontamentos com:
  - `lblFillTime`: Tempo de preenchimento, para ao completar os campos (e-mail, ordem, material, quantidade).
  - `lblCountdown`: Tempo restante até habilitar o botão `Enviar`, baseado no `CycleTime`.
  - Validação visual: `txtQuantity` fica vermelho se inválido.
- **ApontamentosForm**: Consulta apontamentos por e-mail, exibindo no `DataGridView`.
- **Interface**: Moderna com Segoe UI, fundo claro, botões flat com hover, controles agrupados.
- **Back-end**: Validações robustas (e-mail, ordem, quantidade, ciclo) em `ProductionService`.

## Testes Unitários
1. Abra `SQR.Tests` no Visual Studio.
2. Execute os testes no Test Explorer (cobrem `SetProduction` válido/inválido).

## Notas
- Após dois anos usando VB.NET, consultei Grok para refrescar C# (e.g., eventos Windows Forms, async/await). Todas as soluções foram adaptadas e testadas por mim.
- O feedback da entrevista destacou que a estruturação precisava de melhorias. Reorganizei o projeto com serviços, repositórios, e view models, além de adicionar testes unitários, para maior modularidade e alinhamento com Clean Architecture.
- Estou estudando práticas como .NET MAUI e CI/CD para projetos futuros.

## Contato
Para dúvidas ou esclarecimentos, estou à disposição para explicar o código ou realizar modificações.