FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Pooler.Domain/Pooler.Domain.csproj", "Pooler.Domain/"]
COPY ["Pooler.Persistence/Pooler.Persistence.csproj", "Pooler.Persistence/"]
COPY ["Pooler/Pooler.csproj", "Pooler/"]
RUN dotnet restore "Pooler/Pooler.csproj"

COPY . .
WORKDIR "/src/Pooler"
RUN dotnet build "Pooler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pooler.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pooler.dll"]