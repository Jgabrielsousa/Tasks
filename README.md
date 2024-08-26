# ProjectApi - Tasks

## Descrição do Projeto

Este projeto consiste em uma API desenvolvida em C# que interage com um banco de dados SQL para gerenciar Tasks 

## Execução da Api 
Foi criado um docker-compose.yml para facilitar a subida da aplicação, o mesmo 
ja contem uma versao do sql server, a aplicação esta configurada para responder na porta 5000.

```plaintext
docker-compose up -d
```


## Tecnologias Utilizadas

- **Linguagem de Programação:** C#
- **Framework:** .NET Core
- **Banco de Dados:** SQL Server

## Estrutura do Projeto

```plaintext
.
├── src
│   ├── ProjectApi
|   ├── Application
|   ├── Domain
|   ├── CrossCutting.Ioc
|   ├── Infrastructure
|   ├── Tests
```




