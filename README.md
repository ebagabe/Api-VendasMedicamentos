# API de Vendas de Medicamentos

## Descrição
A API de Vendas de Medicamentos é uma aplicação desenvolvida em ASP.NET Core 7 que facilita a gestão e venda de medicamentos em uma farmácia ou estabelecimento similar. Ela oferece endpoints para realizar operações relacionadas à gestão de medicamentos, clientes, representantes e vendas.

## Problema Resolvido
A API resolve o problema de gestão de vendas de medicamentos em estabelecimentos farmacêuticos. Ela permite o cadastro de medicamentos, clientes e representantes, facilitando a organização e controle das vendas. Além disso, oferece funcionalidades para registrar vendas, gerar relatórios e acompanhar o desempenho de vendas ao longo do tempo.

## Banco de Dados
A API utiliza o banco de dados PostgreSQL para armazenar os dados relacionados aos medicamentos, clientes, representantes e vendas.

## Tecnologias Utilizadas
.NET Core 7
ASP.NET Core MVC Web API
PostgreSQL
Instalação e Uso
Para utilizar a API de Vendas de Medicamentos, siga os passos abaixo:

- Certifique-se de ter o .NET Core 7 instalado em sua máquina.
- Clone o repositório da API.
- Configure a conexão com o banco de dados PostgreSQL no arquivo appsettings.json.
- Execute as migrações para criar o esquema do banco de dados utilizando o comando dotnet ef database update.
- Inicie a aplicação executando o comando dotnet run.
- Acesse a API através dos endpoints disponíveis para realizar operações relacionadas à gestão de medicamentos, clientes, representantes e vendas.
