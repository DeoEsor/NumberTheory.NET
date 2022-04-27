FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CryptoServer/CryptoServer.csproj", "CryptoServer/"]
RUN dotnet restore "CryptoServer/CryptoServer.csproj"
COPY . .
WORKDIR "/src/CryptoServer"
RUN dotnet build "CryptoServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CryptoServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CryptoServer.dll"]
