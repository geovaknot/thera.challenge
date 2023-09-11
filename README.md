# Projeto .NET Framework 4.8 com PostgreSQL

Este arquivo fornece informações sobre como configurar e executar o projeto.

## Pré-requisitos

- [Visual Studio](https://visualstudio.microsoft.com/) (ou outra IDE compatível com .NET Framework 4.8)
- [PostgreSQL](https://www.postgresql.org/) instalado e configurado
- [Npgsql](https://www.npgsql.org/) (biblioteca de acesso ao PostgreSQL para .NET) instalado via NuGet

## Configuração do Banco de Dados

1. Crie um banco de dados no PostgreSQL para o seu projeto.

2. Atualize a string de conexão no arquivo `app.config` (ou `web.config` se for um projeto da Web) com as informações do seu banco de dados. Substitua `<sua_string_de_conexao>` pelo valor apropriado:

   ```xml
   <connectionStrings>
     <add name="DefaultConnection" connectionString="Server=seuservidor;Port=suaporta;Database=seubanco;User Id=seuusuario;Password=suasenha;" providerName="Npgsql" />
   </connectionStrings>

## Executando o Projeto

1. Abra o projeto no Visual Studio.
2. Compile o projeto para garantir que todas as dependências sejam baixadas e que não haja erros de compilação.
3. Execute o projeto a partir do Visual Studio.
