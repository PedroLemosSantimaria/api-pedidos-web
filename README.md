# API Pedidos Web

Sistema completo para cadastro e visualização de pedidos com autenticação JWT, feito com:

- ASP.NET Core Web API (back-end)
- HTML, CSS, JS, jQuery e Bootstrap (front-end)
- Persistência de dados em arquivos `.txt` no formato JSON
- Controle de usuários com login e registro

---

## 📁 Estrutura
📦 api-pedidos-web/
├── Backend/ (API ASP.NET Core)
│ ├── Controllers/
│ ├── Middlewares/
│ ├── Models/
│ ├── Services/
│ └── Program.cs
├── frontend-pedidos/ (View web)
│ ├── pages/
│ │ ├── login.html
│ │ ├── pedidos.html
│ │ └── register.html
│ ├── css/
│ │ ├── login.css
│ │ ├── pedidos.css
│ │ └── register.css
│ ├── js/
│ │ ├── login.js
│ │ ├── pedidos.js
│ │ └── register.js
│ ├── config.js
│ └── index.html

---

## 🚀 Como rodar o projeto

### 1. Clonar o repositório

```bash
git clone https://github.com/seu-usuario/api-pedidos-web.git
cd api-pedidos-web 
```
2. Rodar a API (.NET)
Pré-requisitos:
.NET 6 SDK ou superior

Comandos:
cd Backend
dotnet restore
dotnet run
A API será iniciada em: https://localhost:44363 (ou conforme sua porta configurada)

3. Rodar o Frontend
Pré-requisitos:
Navegador moderno (Chrome, Edge, Firefox)

Servidor local (opcional: Live Server, http-server, etc.)

Acesso direto:
Abra frontend-pedidos/index.html ou use uma extensão como Live Server no VS Code:
cd frontend-pedidos
npx http-server .

4. Acessar a aplicação
Acesse http://localhost:PORT/pages/login.html

Crie um usuário na página de registro (register.html)

Faça login

Cadastre, visualize e navegue entre pedidos

Os dados são salvos em arquivo .txt com formato JSON na API

✅ Funcionalidades
Login e registro de usuários

Autenticação com JWT

Cadastro de pedidos com múltiplos itens

Visualização com paginação

Logout e controle de sessão via token

Estilização com Bootstrap

🔐 Segurança
Autenticação via JWT protegendo endpoints

Validação de dados com ModelState.IsValid

Middleware global para tratamento de erros

📁 Dados
Os dados dos pedidos e usuários são salvos em arquivos .txt na pasta do projeto, simulando um banco local com estrutura JSON.

✍️ Autor
Feito por Pedro Henrique Lemos Santimaria 💻
GitHub: PedroLemosSanatimaria
