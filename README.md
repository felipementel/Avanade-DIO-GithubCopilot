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

2. Criando os projetos de testes
```
dotnet new xunit -o .\src\Tests\Avanade.DIO.BookStore.Api.Tests -n Avanade.DIO.BookStore.Api.Tests
```
```
dotnet add .\src\Tests\Avanade.DIO.BookStore.Api.Tests reference .\src\Avanade.DIO.BookStore.Api
```
```
dotnet add .\src\Tests\Avanade.DIO.BookStore.Api.Tests reference .\src\Avanade.DIO.BookStore.Application
```
```
dotnet add .\src\Tests\Avanade.DIO.BookStore.Api.Tests reference .\src\Avanade.DIO.BookStore.Domain
```
```
dotnet sln .\src\Avanade.DIO.BookStore.sln add .\src\Tests\Avanade.DIO.BookStore.Api.Tests
```
```
dotnet add .\src\Tests\Avanade.DIO.BookStore.Api.Tests package Moq --version 4.20.70
```
```
dotnet add .\src\Tests\Avanade.DIO.BookStore.Api.Tests package Bogus --version 35.5.0
```
```
dotnet add .\src\Tests\Avanade.DIO.BookStore.Api.Tests package FluentAssertions --version 7.0.0-alpha.3
```
```
dotnet add .\src\Tests\Avanade.DIO.BookStore.Api.Tests package coverlet.msbuild --version 6.0.2
```
```
dotnet add .\src\Tests\Avanade.DIO.BookStore.Api.Tests package coverlet.collector --version 6.0.2
```

# 3. Testes de unidade

3.1. Instalar os seguintes pacotes utilizando powershell

```
dotnet tool install --global dotnet-reportgenerator-globaltool
```

```
dotnet tool install --global dotnet-coverage
```

3.2 Geração dos relatórios

### Como Executar:
   3.2.1 A partir da pasta **_src_** execute o comando:

```
dotnet test
```

3.3. Geração de relatório de testes

   3.3.1. A partir da pasta **_src_** execute o comando:

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

4. Para executar o projeto

```
dotnet run --project .\src\Avanade.DIO.BookStore.Api\Avanade.DIO.BookStore.Api.csproj --launch-profile Avanade.DIO.BookStore.Api
```
