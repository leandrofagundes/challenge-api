# Introduction 
TODO:

# Getting Started
1.	Clonar o reposit�rio
2.	Inicializar o Docker Desktop (containers Windows)
3.	Abrir a Solution src\Challenge.sln para a API. Executar e identificar a porta em que o IIS subiu a aplica��o.
4.	Abrir a Solution src\Challenge-Blazor.sln e alterar \wwwroot\appsettings.json o valor de baseUrl para o caminho/porta da aplica��o do passo 3.
5.  O Swagger da api roda na Url /swagger do endere�o:porta da aplica��o.

# Build and Test
Os testes podem ser executados diretamente do Visual Studio na Solution \src\Challenge.sln

# Observa��es

Gostaria de desenvolver v�rias pequenas melhorias ainda como:
 - Cria��o de mais testes;
 - Cria��o dos value objects para os tipos;
 - Mais valida��es de integridade de dados recebidos (inputdatas);
 - Algumas interfaces para ResponseData e RequestData;
 - Inserir o Docker ou remover ele da aplica��o API pois n�o est� em uso;
 - Retorno de mensagens mais amig�veis no Blazor;
 - Fazer a busca funcionar por nome dos pa�ses em Portugu�s (ou localizado conforme ferramenta/api);
 