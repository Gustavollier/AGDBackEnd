Projeto - AGDBackend

Para executar localmente precisamos ter o docker instalado na maquina.
Partindo do principio de que temos o docker instalado em nossa maquina, podemos erguer nossa aplicação com docker-compose up para subir nossa imagem do MySQL e em seguida podemos dar um dotnet run

A nossa pipeline roda apenas para a branch master

E as etapas da pipeline são:
CI:
 - Log in no docker
 - Build and push da image
 - Post Build and push image
 - Post log in to Docker Hub
 - Post Set up docker Buildx
CD:
 - Deploy to azure Web

Nosso Dockerfile:

# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia os arquivos de projeto e restaura dependências
COPY ["AGDBackEnd/Api.csproj", "AGDBackEnd/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "AGDBackEnd/Api.csproj"
# Copia todo o código-fonte
COPY . .
# Publica a aplicação
WORKDIR "/src/AGDBackEnd"
RUN dotnet publish "Api.csproj" -c Release -o /app/publish
# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
# Expõe as portas padrão
EXPOSE 80
EXPOSE 443
# Inicia a aplicação
ENTRYPOINT ["dotnet", "Api.dll"]

Primeira etapa é a etapa de build aonde fazemos o restore do nosso projeto, em segundo vem a nossa etapa de runtime aonde expomos a nossa portas padão e inicamos a nossa aplicação em produção

 Tecnologias utilizadas:

 Usamos o .NET 9.0 como framework para desenvolvermos nossa pequena API 
