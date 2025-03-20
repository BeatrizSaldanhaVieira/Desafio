 Desafio Full-Stack - Sistema de Fornecedores

 Descrição

Este projeto consiste em um sistema de gerenciamento de empresas e fornecedores, permitindo realizar operações de cadastro e listagem de empresas e fornecedores, 
com filtros e validações. A aplicação utiliza **C# (Entity Framework)** no Back-end e **Angular** no Front-end.

 Funcionalidades

- **Cadastro e Listagem de Empresas**: CNPJ, Nome Fantasia e CEP.
- **Cadastro e Listagem de Fornecedores**: CPF/CNPJ, Nome, E-mail, CEP, RG (se pessoa física), Data de Nascimento (se pessoa física).
- **Validação de Dados**: 
  - O CNPJ/CPF deve ser único.
  - Não é permitido cadastrar fornecedores menores de idade no Paraná.
  - Validação de CEP através da API
- **Relacionamento**: Uma empresa pode ter vários fornecedores e um fornecedor pode trabalhar para várias empresas.
- **Filtros**: Pesquisa de fornecedores por nome ou CPF/CNPJ.

 Requisitos

 Back-End

- **C# com Entity Framework** para persistência de dados.
- **API** para manipulação de fornecedores e empresas.
- **Validação de Dados**: CNPJ/CPF único, menoridade para empresas no Paraná.

 Front-End

- **Angular** para a interface de usuário.
- **Formulários** para cadastro de empresas e fornecedores.
- **Filtros** para pesquisa de fornecedores por nome e CPF/CNPJ.

 Como Rodar

1. Back-End (C#)
   - Instale as dependências com o `dotnet restore`.
   - Execute o projeto com `dotnet run`.

2. Front-End (Angular
   - Navegue até a pasta do projeto Angular.
   - Instale as dependências com `npm install`.
   - Execute o servidor com `ng serve`.

Acesse a aplicação no navegador em [http://localhost:4200](http://localhost:4200).

 Tecnologias Usadas

- C# (Back-End)
- Entity Framework Core
- Angular (Front-End)
- API de CEP (`cep.la`)

