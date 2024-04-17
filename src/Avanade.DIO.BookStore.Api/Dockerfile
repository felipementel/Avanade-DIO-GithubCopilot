#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Avanade.DIO.BookStore.Api/Avanade.DIO.BookStore.Api.csproj", "Avanade.DIO.BookStore.Api/"]
COPY ["Avanade.DIO.BookStore.Application/Avanade.DIO.BookStore.Application.csproj", "Avanade.DIO.BookStore.Application/"]
COPY ["Avanade.DIO.BookStore.Domain/Avanade.DIO.BookStore.Domain.csproj", "Avanade.DIO.BookStore.Domain/"]
COPY ["Avanade.DIO.BookStore.Infra.CrossCutting/Avanade.DIO.BookStore.Infra.CrossCutting.csproj", "Avanade.DIO.BookStore.Infra.CrossCutting/"]
COPY ["Avanade.DIO.BookStore.Infra.Database/Avanade.DIO.BookStore.Infra.Database.csproj", "Avanade.DIO.BookStore.Infra.Database/"]
RUN dotnet restore "./Avanade.DIO.BookStore.Api/Avanade.DIO.BookStore.Api.csproj"
COPY . .
WORKDIR "/src/Avanade.DIO.BookStore.Api"
RUN dotnet build "./Avanade.DIO.BookStore.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Avanade.DIO.BookStore.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Avanade.DIO.BookStore.Api.dll"]