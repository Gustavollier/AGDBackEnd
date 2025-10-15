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
