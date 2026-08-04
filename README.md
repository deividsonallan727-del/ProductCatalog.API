# ProductCatalog.API

## 📌 Sobre o projeto

O **ProductCatalog.API** é uma API REST desenvolvida em **C# utilizando ASP.NET Core 10**, com o objetivo de criar um catálogo de produtos.

O projeto permite realizar operações de cadastro, consulta, atualização e remoção de produtos utilizando uma arquitetura organizada, integração com banco de dados SQL Server e persistência através do Entity Framework Core.

O desenvolvimento do projeto teve como foco aplicar conceitos fundamentais de desenvolvimento backend, como:

* Programação Orientada a Objetos (POO)
* API REST
* Entity Framework Core
* Banco de dados relacional
* Injeção de Dependência
* Separação de responsabilidades
* Boas práticas de organização de código

---

# 🚀 Tecnologias utilizadas

## Linguagem

* **C#**

Linguagem principal utilizada no desenvolvimento da API.

---

## Framework

* **.NET 10**
* **ASP.NET Core Web API**

Responsáveis pela criação da aplicação backend e disponibilização dos endpoints HTTP.

---

## Banco de Dados

* **SQL Server**

Banco utilizado para armazenamento das informações dos produtos.

---

## ORM / Persistência

* **Entity Framework Core**
* **Microsoft.EntityFrameworkCore.SqlServer**

Utilizado para realizar o mapeamento entre as classes C# e as tabelas do banco de dados.

Recursos utilizados:

* DbContext
* DbSet
* Mapeamento de entidades
* Configurações de tabelas
* Migrations

---

## Documentação da API

* **Swagger / OpenAPI**

Utilizado para documentar e testar os endpoints da API.

---

## Controle de versão

* **Git**
* **GitHub**

Utilizados para versionamento do código e armazenamento remoto do projeto.

---

## Ferramentas utilizadas

* Visual Studio
* Git Bash
* Postman
* SQL Server

---

# 🏗️ Estrutura do projeto

```
ProductCatalog.API

│
├── Controllers
│   └── Responsáveis pelos endpoints HTTP da API
│
├── Entities
│   └── Classes que representam as entidades do sistema
│
├── Services
│   └── Contém as regras de negócio da aplicação
│
├── Configurations
│   └── Configurações do Entity Framework
│
├── Data
│   └── Contexto de conexão com o banco de dados
│
├── Program.cs
│   └── Configuração da aplicação
│
└── appsettings.json
    └── Configurações da aplicação e banco de dados
```

---

# 🧱 Modelagem do projeto

A entidade principal do sistema é a classe:

## Product

Representa um produto genérico.

Possui informações como:

* Id
* Name
* Description
* Price
* Quantity
* Type

---

## Herança

O projeto utiliza herança para criar diferentes tipos de produtos.

A classe:

```
Product
```

é a classe base.

A partir dela foram criadas:

---

## 📚 Book

Representa produtos do tipo livro.

Possui propriedades adicionais:

* Author
* Pages

Exemplo:

```
Book : Product
```

---

## 🎮 Game

Representa produtos do tipo jogo.

Possui propriedades adicionais:

* Platform
* Genre

Exemplo:

```
Game : Product
```

---

# 🧠 Conceitos de Programação utilizados

## Programação Orientada a Objetos

Foram aplicados conceitos como:

### Encapsulamento

Utilização de propriedades e controle de acesso aos dados das entidades.

---

### Herança

Reutilização de código através da relação:

```
Product
   |
   ├── Book
   |
   └── Game
```

---

### Interfaces

Utilizadas para definir contratos entre serviços e suas implementações.

Exemplo:

```
IProductServices
```

---

### Injeção de Dependência

Utilizada para disponibilizar serviços dentro dos Controllers através do sistema nativo do ASP.NET Core.

---

# 🔥 Funcionalidades

## CRUD de produtos

A API possui as operações:

### Criar produto

```
POST /api/products
```

---

### Listar produtos

```
GET /api/products
```

---

### Buscar produto por ID

```
GET /api/products/{id}
```

---

### Atualizar produto

```
PUT /api/products/{id}
```

---

### Remover produto

```
DELETE /api/products/{id}
```

---

# 🗄️ Banco de dados

A aplicação utiliza SQL Server para persistência dos dados.

O acesso ao banco é realizado através do:

```
MSSQLContext
```

que utiliza:

```
Entity Framework Core
```

para realizar as operações no banco.

---

# ⚙️ Como executar o projeto

## Clonar o repositório

```
git clone git@github.com:deividsonallan727-del/ProductCatalog.API.git
```

---

## Entrar na pasta do projeto

```
cd ProductCatalog.API
```

---

## Restaurar dependências

```
dotnet restore
```

---

## Executar a aplicação

```
dotnet run
```

---

Após iniciar, acessar o Swagger:

```
https://localhost:7178/swagger
```

ou:

```
http://localhost:5211/swagger
```

---

# 📚 Aprendizados aplicados no projeto

Durante o desenvolvimento foram praticados:

* Criação de uma API REST completa
* Criação de Controllers
* Criação de Services
* Comunicação com banco SQL Server
* Mapeamento objeto-relacional com Entity Framework Core
* Organização de código backend
* Versionamento utilizando Git e GitHub

---

# 👨‍💻 Autor

Desenvolvido por **Deividson Allan**.

Projeto criado com foco em aprendizado e construção de portfólio backend utilizando tecnologias do ecossistema .NET.
