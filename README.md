# SQR.fullstack

1. Back-End
   
Desenvolver uma API que contenha os seguintes métodos:
  1. GetOrders
    Retornar uma lista de Ordens de Produção, utilizando o Json de exemplo da seção 3.1.
    A rota para esse end-point deverá ser 'api/orders/GetOrders'.
  2. GetProduction
    Retornar a lista de produções de um e-mail, utilizando o Json de exemplo da seção 3.2. Caso não exista produções para aquele     e-mail, retornar uma lista vazia.
    A rota para esse end-point deverá ser 'api/orders/GetProduction?email='.
  3. SetProduction
    Receber o apontamento de produção através do Json de exemplo da seção 3.3.
    A rota para esse end-point deverá ser 'api/orders/SetProduction'.
  Validações:
    E-mail:O email deve constar no cadastro de usuário.
    Ordem: A ordem selecionada deve constar no cadastro de ordens.
    Data Apontamento: A data de apontamento deve ser validada com a data de inicio e fim cadastradas para o usuário.
    Quantidade: Deve ser maior que 0 e menor ou igual a quantidade da Ordem selecionada.
    Material: Deve constar na lista de materiais da Ordem selecionada.
    Tempo de ciclo: Deve ser maior que 0. Caso o tempo de ciclo informado seja menor do que o tempo cadastrado no produto,               permitir o apontamento mas retornar mensagem informativa de que o tempo é menor que o cadastrado.
    Retorno: O Retorno, de acordo com o Json de exemplo da seção 3.3 :
    Status: Código do status do envio: 200 - OK ou 201 - NOK
    Type: S = Success ou E = Error
    Description:Mensagem informativa do retorno.

2. Front-End
   Desenvolver uma tela que receberá uma lista de Ordens de Produção e que o usuário poderá realizar um apontamento de produção     para a Ordem selecionada.
    1. E-mail: Inserir o e-mail informado à Sequor para seleção.
    2. Lista de Ordens para seleção: O usuário deverá selecionar uma Ordem de Produção a partir de uma lista oriunda do Json
    GetOrders (http://demo-coleta.brazilsouth.cloudapp.azure.com:2070/api/orders/GetOrders), da seção 2.1.
    3. Data de apontamento: Data em que foi realizado o apontamento de produção.
    4. Quantidade: Quantidade apontada de produção.
    5. Material utilizado: O usuário deverá selecionar um Material a partir da lista de materiais presentes na Ordem
    selecionada.
    6. Tempo de ciclo: Não será preenchido pelo usuário. Deverá ser feito um cálculo de tempo em segundos a partir do momento da       seleção de Ordem de Produção até o momento de enviar o apontamento. Ou seja, o usuário selecionou uma ordem, começa a            contar o tempo. Ao enviar o dado, fazer o cálculo de quanto tempo em segundos foi levado para preencher o formulário e           enviar esse tempo.
    
    Requisitos
      >> Após a seleção da Ordem de Produção, o sistema deverá exibir o produto referente à Ordem, bem como sua imagem.
      >> O botão de envio dos dados só deve ser habilitado após o Tempo de ciclo calculado ser maior ou igual ao tempo de ciclo           referente à Ordem selecionada no cadastro inicial.
      >> Enviar o apontamento utilizando o método SetProduction        (http://democoleta.brazilsouth.cloudapp.azure.com:2070/api/orders/SetProduction), utilizando o
        Json padrão da seção 2.2.
      >> O Sistema deverá exibir o status do retorno do envio dos dados, conforme json da seção 2.3. Caso retorno OK, limpar os           campos após o envio.
      >> Opcional
          Para consultar os apontamentos realizados, está disponível o endpoint (http://demo-coleta.brazilsouth.cloudapp.azure.com:2070/api/orders/GetProduction). Basta passar o email como parâmetro, conforme exemplo     abaixo.
    (http://demo- coleta.brazilsouth.cloudapp.azure.com:2070/api/orders/GetProduction?email=teste@ email.com.br)
    O retorno deste endpoint é baseado no Json padrão da seção 2.4.
    
