# 🧪 Como rodar os testes funcionais

Os testes funcionais simulam o comportamento real da aplicação, garantindo que os endpoints e integrações (como o banco de dados) estejam funcionando corretamente.

---

## ⚙️ Pré-requisitos

Antes de rodar os testes, certifique-se de ter instalado:

- **[WSL 2](https://learn.microsoft.com/pt-br/windows/wsl/install)** (para rodar containers no Windows)
- **[Docker Desktop](https://www.docker.com/products/docker-desktop/)**

---

## 🐳 Subindo o ambiente com Docker

Na raiz do projeto, execute o comando:

```bash
docker-compose up -d
```

Esse comando inicializa o container do **MySQL**, definido no arquivo `docker-compose.yml`.

Para verificar se o container está em execução:

```bash
docker ps
```

Você deverá ver algo semelhante a:

```
CONTAINER ID   IMAGE     PORTS                    NAMES
abcd1234       mysql     0.0.0.0:3306->3306/tcp   agdbackend-mysql
```

---

## 🗄️ Criando o banco de dados e tabelas

Após confirmar que o container do MySQL está ativo, conecte-se ao banco (via terminal, DBeaver, ou outro cliente) e execute os seguintes comandos SQL para criar o schema e as tabelas necessárias:

```sql
CREATE DATABASE IF NOT EXISTS AGD;

USE AGD;

CREATE TABLE IF NOT EXISTS PARTNER (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS COMPLAINT (
    id INT AUTO_INCREMENT PRIMARY KEY,
    category INT NOT NULL,
    description VARCHAR(150) NOT NULL,
    emailPartner VARCHAR(30) NULL
);
```

---

## 🔑 Ajustando a conexão com o banco de dados

Verifique o arquivo `appsettings.json` (ou `appsettings.Testing.json`, se estiver rodando com o `WebApplicationFactory`) e ajuste a connection string conforme necessário:

```json
"ConnectionStrings": {
  "MySqlDb": "Server=127.0.0.1;Port=3306;Database=AGD;Uid=root;Pwd=root_pass;SslMode=None;AllowPublicKeyRetrieval=True;"
}
```

> ⚠️ Caso o MySQL esteja em um container e você esteja executando os testes localmente (fora do Docker), **use `127.0.0.1`** como host.  
> Evite usar `Server=mysql`, pois esse nome só funciona dentro da rede interna do Docker Compose.

---

## 🧭 Executando os testes funcionais

Com o ambiente configurado e o banco criado, basta executar os testes funcionais via terminal, Visual Studio ou CLI do .NET:

```bash
dotnet test
```

O `WebApplicationFactory` inicializará a API localmente em modo `Testing` e executará os testes simulando chamadas reais aos endpoints da aplicação.

---

## ✅ Resumo do fluxo

1. Instale o **WSL** e **Docker Desktop**.  
2. Rode `docker-compose up -d` na raiz do projeto.  
3. Verifique o container com `docker ps`.  
4. Crie o banco e as tabelas com os scripts acima.  
5. Ajuste a `ConnectionStrings` no `appsettings.json`.  
6. Execute `dotnet test` para rodar os testes funcionais.
