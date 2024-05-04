FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ModuleBot/ModuleBot.csproj", "ModuleBot/"]
RUN dotnet restore "ModuleBot/ModuleBot.csproj"
COPY . .
WORKDIR "/src/ModuleBot"
RUN dotnet build "ModuleBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ModuleBot.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ModuleBot.dll"]
