# Tryitter

## Objetivos do projeto
Construir uma API em que um usuário consiga se cadastrar com nome, e-mail, módulo atual que estão estudando na Trybe, status personalizado e senha para se autenticar. 
Deve ser possível também alterar essa conta a qualquer momento, desde que a pessoa usuária esteja autenticada.

## :sparkles: Funcionalidades

* C.R.U.D. para as contas de pessoas estudantes.
* C.R.U.D. para um post de uma pessoa estudante.

## 🛠 Tecnologias

As seguintes ferramentas foram usadas no desenvolvimento do projeto:

- SDK .NET Core 6.0
- Microsoft SQL Server
- Entity Framework Core
- JwtBearer
- xUnit
- GWTDO
- FluentAssertions

## Para rodar em sua máquina

### Pré-requisitos gerais

Antes de começar, você vai precisar ter instalado em sua máquina:

* SDK .NET Core 6.0
* Microsoft SQL Server

<details>
  <summary><strong> :computer: Rodando localmente </strong></summary><br />    

  - Clone o repositório com `git@github.com:moraeslua/Tryitter.git`
  
  - Entre no diretório que acabou de ser criado
  
  - Faça o build da aplicação com `dotnet build`
  
  - Rode as migrations do banco de dados `dotnet ef database update`
  
  - Inicialize o projeto `dotnet run`
  
  - Você pode acessar a documentação swagger no navegador em `https://localhost:7241/swagger/index.html`
      
</details>
