# LsCode-Test-API.NET
# Sistema de Empacotamento de Pedidos

Este projeto é uma API desenvolvida em ASP.NET Core para empacotar produtos em caixas conforme suas dimensões.

---

## Tecnologias Utilizadas

- ASP.NET Core
- Docker
- Docker Compose

---

##  Pré-requisitos

- [Docker]  instalado
- [ Docker Compose ] instalado

---

## Configuração do Ambiente

Antes de rodar a aplicação, configure o arquivo `appsettings.json` com os dados do seu banco de dados, na seção `ConnectionStrings`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MeuBanco;User Id=usuario;Password=senha;"
  }
}

```

## Como rodar o projeto com Docker Compose

 Clone este repositorio: 

```bash
-git clone https://github.com/dgbarros/LsCode-Test-API.NET.git
-cd LsCode.API 

```
Após clonar o repostório, construa e suba os containers usando:

- docker-compose up --build

## Rodando projeto 

Dotnet run  

## Exemplo de JSON para requisição no Swagger

A API espera que o corpo da requisição seja um JSON contendo uma lista de pedidos, onde cada pedido tem um `pedidoId` e uma lista de `produtos`. Cada produto deve conter um `id`, `nome` e suas `dimensoes` (altura, largura e comprimento em centímetros).

Formato esperado para o corpo da requisição:

```json
[
  {
    "pedidoId": 1,
    "produtos": [
      {
        "id": 1,
        "nome": "Controle",
        "dimensoes": {
          "altura": 80,
          "largura": 49,
          "comprimento": 39
        }
      },
      {
        "id": 2,
        "nome": "Cabo HDMI",
        "dimensoes": {
          "altura": 5,
          "largura": 5,
          "comprimento": 15
        }
      }
    ]
  },
  {
    "pedidoId": 2,
    "produtos": [
      {
        "id": 3,
        "nome": "Teclado Gamer",
        "dimensoes": {
          "altura": 30,
          "largura": 40,
          "comprimento": 80
        }
      }
    ]
  }
]






