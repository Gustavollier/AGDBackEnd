# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia os arquivos de projeto e restaura depend�ncias
COPY ["AGDBackEnd/AGDBackEnd.csproj", "AGDBackEnd/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore

# Copia todo o c�digo-fonte
COPY . .

# Publica a aplica��o
WORKDIR "/src/AGDBackEnd"
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

# Exp�e as portas padr�o
EXPOSE 80
EXPOSE 443

# Inicia a aplica��o
ENTRYPOINT ["dotnet", "AGDBackEnd.dll"]