# Introduction 
TODO:

# Getting Started
1.	Clonar o repositório
2.	Inicializar o Docker Desktop (containers Windows)
3.	Abrir a Solution src\Challenge.sln para a API. Executar e identificar a porta em que o IIS subiu a aplicação.
4.	Abrir a Solution src\Challenge-Blazor.sln e alterar \wwwroot\appsettings.json o valor de baseUrl para o caminho/porta da aplicação do passo 3.
5.  O Swagger da api roda na Url /swagger do endereço:porta da aplicação.

# Build and Test
Os testes podem ser executados diretamente do Visual Studio na Solution \src\Challenge.sln

# Observações

Gostaria de desenvolver várias pequenas melhorias ainda como:
 - Criação de mais testes;
 - Criação dos value objects para os tipos;
 - Mais validações de integridade de dados recebidos (inputdatas);
 - Algumas interfaces para ResponseData e RequestData;
 - Inserir o Docker ou remover ele da aplicação API pois não está em uso;
 - Retorno de mensagens mais amigáveis no Blazor;
 - Fazer a busca funcionar por nome dos países em Português (ou localizado conforme ferramenta/api);
 