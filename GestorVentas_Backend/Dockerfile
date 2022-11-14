#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GestorVentas_Backend/GestorVentas_Backend.csproj", "GestorVentas_Backend/"]
RUN dotnet restore "GestorVentas_Backend/GestorVentas_Backend.csproj"
COPY . .
WORKDIR "/src/GestorVentas_Backend"
RUN dotnet build "GestorVentas_Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GestorVentas_Backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GestorVentas_Backend.dll"]
