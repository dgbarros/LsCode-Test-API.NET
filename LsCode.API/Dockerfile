# Imagem base do runtime para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Imagem base do SDK para build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copia o arquivo do projeto e restaura dependências
COPY ["LsCode.API.csproj", "./"]
RUN dotnet restore "./LsCode.API.csproj"

# Copia tudo para a imagem
COPY . .

# Build da aplicação em Release
RUN dotnet build "LsCode.API.csproj" -c Release -o /app/build

# Publica a aplicação (gera os arquivos finais para rodar)
FROM build AS publish
RUN dotnet publish "LsCode.API.csproj" -c Release -o /app/publish

# Imagem final para rodar a aplicação
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LsCode.API.dll"]
