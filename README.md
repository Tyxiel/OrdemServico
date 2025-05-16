# Sistema de Gerenciamento de Ordens de Serviço (ASP.NET Core MVC)

Uma aplicação web desenvolvida em ASP.NET Core 6.0 com arquitetura MVC para realizar operações CRUD (Criar, Ler, Atualizar, Deletar) em Ordens de Serviço. Utiliza Entity Framework Core para interação com banco de dados SQL Server, Bootstrap para o design e DataTables para uma melhor visualização e interação com os dados.

## Sobre o Projeto

Este projeto é um sistema completo para o gerenciamento de ordens de serviço. Ele permite o cadastro, visualização, edição e exclusão de ordens, facilitando o controle e acompanhamento dos serviços. A arquitetura MVC garante uma separação clara de responsabilidades, tornando o código mais organizado e manutenível.

## Funcionalidades Principais

* **CRUD Completo para Ordens de Serviço:**
    * Criação de novas ordens de serviço com os detalhes necessários.
    * Listagem de todas as ordens de serviço com paginação, busca e ordenação (via DataTables).
    * Visualização dos detalhes de uma ordem de serviço específica.
    * Atualização das informações de ordens de serviço existentes.
    * Exclusão de ordens de serviço.
* Interface de usuário responsiva utilizando Bootstrap.
* Tabelas de dados interativas com DataTables.
* [Adicionar outras funcionalidades específicas do seu sistema, ex: Gerenciamento de Clientes, Técnicos, Status da OS, etc.]

## Tecnologias Utilizadas

* **Backend:**
    * **ASP.NET Core 6.0 (C#)**: Framework para construção da aplicação web.
    * **Arquitetura MVC**: Padrão de design para organizar a aplicação.
    * **Entity Framework Core**: ORM para mapeamento objeto-relacional e acesso a dados.
* **Banco de Dados:**
    * **SQL Server**: Sistema de gerenciamento de banco de dados relacional.
* **Frontend:**
    * **HTML5, CSS3, JavaScript**
    * **Bootstrap**: Framework CSS para design responsivo e componentes de UI.
    * **DataTables (jQuery)**: Plugin para criação de tabelas dinâmicas e interativas.
    * **Razor Pages/Views**: Para renderização das views no lado do servidor.

## Pré-requisitos

* [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
* [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) (Express, Developer ou outra edição)
* [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms) ou outra ferramenta de gerenciamento de banco de dados.

## Configuração e Execução

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/seu-usuario/nome-do-repositorio.git](https://github.com/seu-usuario/nome-do-repositorio.git)
    cd nome-do-repositorio
    ```

2.  **Configure a Connection String:**
    * Abra o arquivo `appsettings.json`.
    * Modifique a `ConnectionString` chamada "Default" (ou o nome que você utilizou) para apontar para sua instância do SQL Server e o banco de dados desejado. Exemplo:
      ```json
      {
        "ConnectionStrings": {
          "Default": "Server=(localdb)\\mssqllocaldb;Database=DBSenaiTech;Trusted_Connection=True;MultipleActiveResultSets=true"
        },
        // ... outras configurações
      }
      ```

3.  **Aplique as Migrations (Entity Framework Core):**
    * Abra um terminal ou prompt de comando na raiz do projeto.
    * Execute os seguintes comandos para criar o banco de dados e aplicar as migrações (schema):
      ```bash
      dotnet tool install --global dotnet-ef # Se ainda não tiver o EF Core tools instalado
      dotnet ef database update
      ```
    * Se você não tiver migrações ainda, precisará criá-las primeiro a partir dos seus `DbContext` e modelos:
      ```bash
      dotnet ef migrations add InitialCreate
      dotnet ef database update
      ```

4.  **Execute a Aplicação:**
    ```bash
    dotnet run
    ```
    A aplicação estará acessível em `https://localhost:<porta>` ou `http://localhost:<porta>` (verifique o output do console).

## Estrutura do Projeto (Simplificada)

* `/Controllers`: Contém os controladores MVC.
* `/Models`: Contém as classes de modelo (entidades do banco) e ViewModels.
* `/Views`: Contém os arquivos Razor (.cshtml) para a interface do usuário.
* `Program.cs`: Arquivo principal de configuração e inicialização da aplicação.
* `appsettings.json`: Arquivo de configurações da aplicação.
