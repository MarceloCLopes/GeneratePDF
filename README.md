# GeneratePDF

Um projeto fullstack moderno para geração e gerenciamento de recibos em PDF, desenvolvido com **.NET 10** e **Blazor WebAssembly**.

## 📋 Descrição

O **GeneratePDF** é uma aplicação web que permite criar recibos em formato PDF dinamicamente. O sistema recebe dados de um formulário, processa um template HTML com as informações do recibo e converte para PDF, oferecendo também a funcionalidade de download.

## 🛠️ Tecnologias Utilizadas

### Backend
- **ASP.NET Core 10.0** - Framework web de alta performance
- **C# 13** - Linguagem moderna com recursos avançados
- **Select.HtmlToPdf.NetCore** - Biblioteca para conversão de HTML para PDF

### Frontend
- **Blazor WebAssembly** - Framework SPA rodando no navegador com C#
- **HTML5 & CSS3** - Markup e estilos
- **.NET 10.0** - Runtime do cliente

### Arquitetura
- **Arquitetura em Camadas** (Client-Server)
- **API RESTful** para comunicação
- **CORS** habilitado para integração entre Client e Server

## 📁 Estrutura do Projeto

```
GeneratePDF/
├── Server/                      # Backend ASP.NET Core
│   ├── Controllers/
│   │   └── PdfController.cs    # Endpoints para PDF
│   ├── Dtos/
│   │   └── ReceiptDto.cs       # DTO para dados de recibo
│   ├── wwwroot/
│   │   └── Templates/
│   │       ├── modelo.html     # Template do recibo
│   │       └── result.pdf      # PDF gerado
│   ├── Program.cs              # Configuração da aplicação
│   └── appsettings.json        # Configurações
│
├── Client/                      # Frontend Blazor WebAssembly
│   ├── Components/
│   ├── Pages/
│   ├── wwwroot/
│   └── App.razor
│
└── GeneratePDF.slnx            # Solution file
```

## 🚀 Como Executar

### Pré-requisitos
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2026 (Community ou superior) ou VS Code

### Passos

1. **Clone o repositório**
```bash
git clone https://github.com/MarceloCLopes/GeneratePDF.git
cd GeneratePDF
```

2. **Abra a solução**
```bash
# Com Visual Studio
start GeneratePDF.slnx

# Ou com CLI
dotnet sln list
```

3. **Execute o Backend (Server)**
```bash
cd Server
dotnet run
```
O servidor será iniciado em: `http://localhost:5247`

4. **Execute o Frontend (Client)**
Em outro terminal:
```bash
cd Client
dotnet run
```
O cliente será iniciado em: `http://localhost:5150`

## 📡 API Endpoints

### Criar PDF
```http
POST /api/pdf/create-pdf
Content-Type: application/json

{
  "name": "John Doe",
  "receiptId": "123452345",
  "price1": 10.50,
  "price2": 20.50
}
```

**Resposta (201 Created):**
```json
{
  "message": "PDF criado com sucesso",
  "filePath": "result.pdf"
}
```

### Baixar PDF
```http
GET /api/pdf/fetch-pdf
```

Retorna o arquivo PDF para download.

### Listar Produtos
```http
GET /api/pdf
```

Retorna lista de produtos disponíveis.

## 🔧 Configuração

### Server (appsettings.json)
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### CORS
O servidor está configurado para aceitar requisições do frontend em `http://localhost:5150`

## 📝 Modelos de Dados

### ReceiptDto
```csharp
public record ReceiptDto(
    string ReceiptId,
    string Name,
    decimal Price1,
    decimal Price2
);
```

## ✨ Funcionalidades

✅ Geração dinâmica de PDFs a partir de templates HTML  
✅ Sistema de substituição de variáveis (placeholders)  
✅ API assíncrona e não-bloqueante  
✅ Tratamento de erros  
✅ Frontend interativo com Blazor WebAssembly  
✅ CORS configurado para integração fullstack  

## 🔄 Fluxo de Funcionamento

1. **Usuário** preenche formulário no Blazor Client
2. **Client** envia dados via POST para `/api/pdf/create-pdf`
3. **Server** recebe DTO com informações do recibo
4. **Server** carrega template HTML (`modelo.html`)
5. **Server** substitui placeholders com dados reais
6. **Select.HtmlToPdf.NetCore** converte HTML para PDF
7. **Server** retorna sucesso (201) com caminho do arquivo
8. **Usuário** pode baixar via GET `/api/pdf/fetch-pdf`

## 🛡️ Boas Práticas Implementadas

- ✓ Async/Await para operações I/O
- ✓ DTOs para transferência de dados
- ✓ Paths para FileSystem

## 📚 Documentação Adicional

- [Documentação ASP.NET Core](https://learn.microsoft.com/aspnet/core)
- [Guia Blazor WebAssembly](https://learn.microsoft.com/aspnet/core/blazor)

## 👤 Autor

**Marcelo C. Lopes**

## 📄 Licença

Este projeto está licenciado sob a MIT License.

## 🤝 Contribuindo

Sinta-se livre para abrir issues e pull requests!

---

**Desenvolvido com ❤️ usando .NET 10**