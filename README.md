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





