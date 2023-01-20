#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CostCalculator.Web/CostCalculator.Web.csproj", "CostCalculator.Web/"]
COPY ["CostCalculator.Core/CostCalculator.Core.csproj", "CostCalculator.Core/"]
RUN dotnet restore "CostCalculator.Web/CostCalculator.Web.csproj"
COPY . .
WORKDIR "/src/CostCalculator.Web"
RUN dotnet build "CostCalculator.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CostCalculator.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CostCalculator.Web.dll"]