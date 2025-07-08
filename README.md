# Vendas Microservices - ASP.NET Core 9.0

Este é um sistema de vendas desenvolvido com foco em **arquitetura de microsserviços** utilizando o padrão **DDD (Domain-Driven Design)**. A solução está organizada em múltiplas camadas e projetos para garantir **separação de responsabilidades**, **testabilidade** e **manutenibilidade**.

## 🛠 Tecnologias Utilizadas

- [.NET 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- C#
- ASP.NET Core Web API
- SQL Server
- Entity Framework Core
- Autenticação via **Windows Authentication**
- Padrão DDD (Domain-Driven Design)
- Injeção de Dependência

---

## 📁 Estrutura dos Projetos

```
Vendas-app/
│
├── Vendas.API/                # Camada de apresentação (Web API)
│   ├── Controllers            # Controllers REST
│   ├── DependencyInjections   # Configurações de DI
│   └── Properties
│
├── Vendas.Application/       # Camada de aplicação (Casos de uso)
│   ├── Commands              # Comandos para ações (CQRS)
│   ├── DTOs                  # Objetos de transferência de dados
│   ├── Handlers              # Manipuladores dos comandos e queries
│   ├── Querys                # Queries para leitura (CQRS)
│   ├── Responses             # Estruturas de resposta
│   └── Services              # Serviços auxiliares
│
├── Vendas.Domain/            # Camada de domínio (regras de negócio)
│   ├── Entitys               # Entidades de negócio
│   ├── Interfaces            # Interfaces dos repositórios e serviços
│   └── UseCases              # Casos de uso principais do domínio
│
└── Vendas.Infraestrutura/    # Infraestrutura (banco, repositórios, etc.)
    ├── Contexts              # DbContext e configurações do EF Core
    ├── Configure             # Configurações gerais
    ├── Migrations            # Migrations do EF Core
    └── Repositories          # Implementações dos repositórios
```

---

## 💾 Banco de Dados

- **Sistema de Gerenciamento**: SQL Server  
- **Autenticação**: Windows Authentication  
- **Gerenciamento de Migrations**: Entity Framework Core  
- As configurações estão centralizadas na camada `Vendas.Infraestrutura`.

---

## 🔧 Como Executar Localmente

### Pré-requisitos

- .NET SDK 9.0+
- SQL Server instalado e rodando
- Visual Studio 2022+ ou VS Code com extensão C#
- Git

### 1. Clone o repositório

```bash
git clone https://https://github.com/RangelMonteiroDev/Vendas
cd Vendas-app
```

### 2. Configure o `appsettings.json`

Vá até o projeto `Vendas.API` e edite o arquivo `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=VendasDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 3. Execute as Migrations

```bash
cd Vendas.Infraestrutura
dotnet ef database update
```

### 4. Execute a API

```bash
cd ../Vendas.API
dotnet run
```

---

## 🔒 Autenticação

A aplicação utiliza autenticação integrada do Windows, ideal para ambientes corporativos com domínio interno (Active Directory).  
Você não precisa configurar usuários e senhas no código, apenas garantir que a aplicação será executada com um usuário que tenha permissão no SQL Server.

---

## 📦 Padrões e Boas Práticas

- **DDD**: Separação clara entre domínio, aplicação e infraestrutura.
- **CQRS**: Comandos e queries separados para melhor organização e performance.
- **SOLID**: Código orientado a interfaces, injeção de dependência e responsabilidade única.

---

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.
