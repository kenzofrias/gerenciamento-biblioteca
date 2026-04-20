# 📚 Gerenciamento de Biblioteca API (.NET)

API REST desenvolvida em .NET para gerenciamento de uma biblioteca, permitindo o controle de livros, usuários e empréstimos, com regras de negócio e validações aplicadas.

## ⚡ Tecnologias Utilizadas
* .NET 8/9/10
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Swagger (OpenAPI)
* Injeção de Dependência
LINQ

## 📁 Estrutura do Projeto
```
GerenciamentoBiblioteca/
│
├── 📂 Controllers/
│   ├── 📄 UsuarioController.cs
│   ├── 📄 LivroController.cs
│   └── 📄 EmprestimoController.cs
│
├── 📂 Services/
│   ├── 📄 UsuarioService.cs
│   ├── 📄 LivroService.cs
│   └── 📄 EmprestimoService.cs
│
├── 📂 Models/
│   ├── 📂 Entities/
│   ├── 📂 DTOs/
│   └── 📂 Enums/
│
├── 📂 Data/
│   └── 📄 AppDbContext.cs
│
├── 📄 Program.cs
└── 📄 appsettings.json
```

## 🧠 Arquitetura
🔹 Controller

Responsável por receber as requisições HTTP e retornar respostas ao cliente.

🔹 Service

Contém a lógica de negócio da aplicação (regras de empréstimo, validações, etc).

🔹 Data (DbContext)

Responsável pela comunicação com o banco de dados via Entity Framework.

🔹 Models

Define as entidades e DTOs utilizados na aplicação.

## 🎯 Funcionalidades
- 📖 Cadastro de livros
- 👤 Cadastro de usuários (Aluno/Professor)
- 🔄 Empréstimo de livros
- ✅ Devolução de livros
- 🔍 Consulta de dados (livros e usuários)
- ⚠️ Validação de regras de negócio

## 🔗 Endpoints
### 📚 Livros

|Método|	Rota |	Descrição|
|---|---|---|
|GET|/Livro/ObterTodos|Lista todos os livros|
|GET|/Livro/ObterLivroPorId/{id}|Busca livro por ID|
|POST|/Livro/CadastrarLivro|Cadastra novo livro|
|PATCH|/Livro/AtualizarLivro/{id}|Atualiza livro|
|DELETE|/Livro/AtualizarLivro/{id}|Remove livro|

---

### 👤 Usuários
|Método|	Rota	|Descrição|
|---|---|---|
|GET/POST/PATCH/DELETE	|/Usuarios/Aluno.../|	Métodos para usuários alunos|
|GET/POST/PATCH/DELETE	|/Usuarios/Professor/...|	Métodos para usuários professores|
|GET	|/Usuario/Usuarios/ObterTodos	|Listar todos os usuários cadastrados no sistema|

---

### 🔄 Empréstimos
|Método	|Rota|	Descrição|
|---|---|---|
|POST|	/Emprestar/RealizarEmprestimo|	Realiza empréstimo|
|POST|	/Emprestar/RealizarDevolucao |Realiza devolução|
|GET|	/Emprestar/RealizarDevolucao|	Lista empréstimos|

## 🧠 Regras de Negócio
* Um usuário só pode pegar livros se estiver ativo
* Um livro não pode ser emprestado se já estiver em uso
* Tipos de usuário possuem regras diferentes:
  - 👨‍🎓 Aluno → limite menor de empréstimos
  - 👨‍🏫 Professor → limite maior

## 🧾 Modelo de Dados (Exemplo)

```csharp
public class Emprestimo
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public TipoUsuario TipoUsuario { get; set; }
    public int LivroId { get; set; }
    public Livro Livro { get; set; }
    public DateTime DataEmprestimo { get; set; }
}
```

## ❗ Tratamento de Erros

A API retorna um modelo de respostas padronizadas:
```csharp
{
  public bool Sucesso { get; set; }
  public string Mensagem { get; set; } = string.Empty;
  public object Dados { get; set; } = new { };

  public static ResultadoDto Ok(object dados) => new ResultadoDto { Sucesso = true, Dados = dados };
  public static ResultadoDto Erro(string mensagem) => new ResultadoDto { Sucesso = false, Mensagem = mensagem };
}
```


## 🚀 Boas Práticas Aplicadas
- Separação de responsabilidades (Controller / Service)
- Uso de DTOs para evitar exposição de entidades
- Injeção de dependência
- Validações de negócio centralizadas
- Código limpo e organizado


## ⚙️ Como Executar
1. Clonar repositório
```
git clone https://github.com/kenzofrias/gerenciamento-biblioteca.git
```
---
2. Acessar pasta
```
cd gerenciamento-biblioteca
```
---
3. Restaurar dependências
```
dotnet restore
```
---
4. Atualizar banco de dados
```
dotnet ef database update
```
---
5. Executar projeto
```
dotnet run
```

## 🌐 Acessar Swagger
```
http://localhost:xxxx/swagger
```


## 🔮 Melhorias Futuras
- 🔐 Autenticação e autorização (JWT)
- 📊 Paginação de resultados
- 🧪 Testes automatizados (xUnit)
- ⚡ Cache de consultas
- 📅 Controle de atraso e multas
- 📈 Logs estruturados


## 🤝 Contribuições e Feedback
Este projeto ainda está em evolução e há diversas melhorias que podem ser implementadas.

Fico aberto a sugestões, críticas construtivas e contribuições que possam ajudar a melhorar a qualidade do código e da arquitetura.

Se quiser contribuir:
- Abra uma issue com sugestões
- Envie um pull request
- Ou entre em contato para trocar ideias

Toda ajuda é bem-vinda 🚀

## 📌 Considerações
Este projeto foi desenvolvido com foco em consolidar conhecimentos em:
- Arquitetura em camadas
- Regras de negócio reais
- Desenvolvimento de APIs REST
- Boas práticas com .NET

---
<div align="center">
  
  **Obrigado pela visita!**  
  [Kenzo Friás](https://www.github.com/kenzofrias) © 2026
  
</div>
