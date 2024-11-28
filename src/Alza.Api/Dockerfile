FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Alza.Api/Alza.Api.csproj", "Alza.Api/"]
RUN dotnet restore "Alza.Api/Alza.Api.csproj"

COPY . .

WORKDIR "/src/Alza.Api"
RUN dotnet publish "Alza.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false /p:DebugType=None /p:DebugSymbols=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Alza.Api.dll"]
