#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BackEndBase.Api/BackEndBase.Api.csproj", "BackEndBase.Api/"]
COPY ["BackEndBase.Domain/BackEndBase.Domain.csproj", "BackEndBase.Domain/"]
COPY ["BackEndBase.Infra.CrossCutting.IoC/BackEndBase.Infra.CrossCutting.IoC.csproj", "BackEndBase.Infra.CrossCutting.IoC/"]
COPY ["BackEndBase.Application/BackEndBase.Application.csproj", "BackEndBase.Application/"]
COPY ["BackEndBase.Infra.CrossCutting.Bus/BackEndBase.Infra.CrossCutting.Bus.csproj", "BackEndBase.Infra.CrossCutting.Bus/"]
COPY ["BackEndBase.DataAccess/BackEndBase.DataAccess.csproj", "BackEndBase.DataAccess/"]
RUN dotnet restore "BackEndBase.Api/BackEndBase.Api.csproj"
COPY . .
WORKDIR "/src/BackEndBase.Api"
RUN dotnet build "BackEndBase.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackEndBase.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackEndBase.Api.dll"]