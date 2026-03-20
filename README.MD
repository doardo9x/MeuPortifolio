# Portfólio — ASP.NET Core MVC (.NET 10)

Portfólio pessoal migrado de HTML/Node.js puro para **ASP.NET Core MVC** no **.NET 10**.

## Estrutura do projeto

```
Portifolio/
├── Controllers/
│   ├── HomeController.cs       ← Home, Projetos, Contato
│   └── IaController.cs         ← View do chat + endpoint POST /Ia/Chat
├── Models/
│   └── ChatModels.cs           ← Records para request/response do Groq
├── Views/
│   ├── Shared/
│   │   └── _Layout.cshtml      ← Layout global (sidebar, canvas, blur)
│   ├── Home/
│   │   ├── Index.cshtml        ← Página inicial com efeito de digitação
│   │   ├── Projetos.cshtml     ← Grid de projetos
│   │   └── Contato.cshtml      ← Links de contato
│   └── Ia/
│       └── Index.cshtml        ← Chat de IA
├── wwwroot/
│   ├── css/style.css           ← Todos os estilos
│   ├── js/particles.js         ← Canvas de partículas + blur cursor
│   ├── js/site.js              ← Sidebar + animação de entrada
│   ├── js/typing.js            ← Efeito de digitação (home)
│   ├── js/chat.js              ← Lógica do chat de IA
│   └── img/                    ← Coloque sua foto aqui como foto.jpg
├── appsettings.json
├── appsettings.Development.json   ← NÃO subir no git (contém chave)
└── Program.cs
```

## Equivalência com o projeto anterior

| Antes (Node/HTML puro)         | Agora (.NET 10 MVC)                  |
|-------------------------------|--------------------------------------|
| `Site/ia-backend/server.js`   | `Controllers/IaController.cs`        |
| `Site/index.html`             | `Views/Home/Index.cshtml` + Layout   |
| `Site/script.js`              | `wwwroot/js/site.js` + `chat.js`     |
| `Site/style.css`              | `wwwroot/css/style.css`              |
| `Js/EfeitoDigitar.js`         | `wwwroot/js/typing.js`               |
| `.env` com GROQ_API_KEY       | `appsettings.Development.json`       |
| `fetch("http://localhost:3000/api/ia")` | `fetch("/Ia/Chat")` (mesmo app) |

## Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

## Como rodar

### 1. Configure sua chave do Groq

Edite `appsettings.Development.json`:

```json
{
  "GROQ_API_KEY": "sua_chave_groq_aqui"
}
```

### 3. Rode o projeto

```bash
dotnet run
```

Acesse em `https://localhost:5001` ou `http://localhost:5000`.

### 4. Build para produção

```bash
dotnet publish -c Release -o ./publish
```

## Rotas disponíveis

| Rota           | Controller | Action   | Descrição              |
|----------------|------------|----------|------------------------|
| `/`            | Home       | Index    | Página inicial         |
| `/Home/Projetos` | Home     | Projetos | Lista de projetos      |
| `/Home/Contato`  | Home     | Contato  | Formas de contato      |
| `/Ia`          | Ia         | Index    | Chat de IA             |
| `/Ia/Chat`     | Ia         | Chat     | Endpoint POST da IA    |

## Segurança

- `appsettings.Development.json` está no `.gitignore` — sua chave não vai para o repositório.
- Em produção, use variáveis de ambiente ou o [Secret Manager do .NET](https://learn.microsoft.com/aspnet/core/security/app-secrets).