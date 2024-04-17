![ArrayAllocation](./docs/Avanade-DIO-GithubCopilot.png?raw=true)

Projeto criado para demonstração em Live na DIO de algumas capacidades do Github Copilot.
Data: 17/4/2024

# 1. Como montar o ambiente local

Pré-requisito: .NET 8, Docker, Docker-Compose, WSL2
Pacotes:

1.1. Clone o repositorio

```
git clone https://github.com/felipementel/Avanade-DIO-GithubCopilot.git
```

1.2. Dentro da pasta da aplicação, no root, execute o seguinte comando para provisionar o Mongodb e o Mongo-Express

```
docker-compose -f docker-infra.yml up -d
```

# 2. Testes de unidade

2.1. Instalar os seguintes pacotes utilizando powershell

```
dotnet tool install --global dotnet-reportgenerator-globaltool
```

```
dotnet tool install --global dotnet-coverage
```

2.2 Geração dos relatórios

1. Como Executar:
   1.1 A partir da pasta **_src_** execute o comando:

```
dotnet test
```

2. Geração de relatório de testes

   1.1 A partir da pasta **_src_** execute o comando:

```
dotnet test --collect:"XPlat Code Coverage" --logger "console;verbosity=detailed" --results-directory ..\TestResults\XPlatCodeCoverage\
```

e depois execute:

```
reportgenerator -reports:..\TestResults\XPlatCodeCoverage\**\coverage.cobertura.xml  -targetdir:..\TestResults\XPlatCodeCoverage\CoverageReport -reporttypes:"Html;SonarQube;JsonSummary;Badges" -classfilters:"-*.Migrations.*" -verbosity:Verbose -title:Avanade.DIO.BookStore -tag:canal-deploy
```

ou

```
$var = (Get-Date).ToString("yyyyMMdd-HHmmss"); dotnet-coverage collect "dotnet test" -f xml -o "..\TestResults\DotnetCoverageCollect\$var\coverage.cobertura.xml"
```

e depois execute:

```
reportgenerator -reports:..\TestResults\DotnetCoverageCollect\**\coverage.cobertura.xml  -targetdir:..\TestResults\DotnetCoverageCollect\CoverageReport -reporttypes:"Html;SonarQube;JsonSummary;Badges" -verbosity:Verbose -title:Avanade.DIO.BookStore -tag:canal-deploy
```
