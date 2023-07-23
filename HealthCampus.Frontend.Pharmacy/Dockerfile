#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HealthCampus.Frontend.Pharmacy/HealthCampus.Frontend.Pharmacy.csproj", "HealthCampus.Frontend.Pharmacy/"]
RUN dotnet restore "HealthCampus.Frontend.Pharmacy/HealthCampus.Frontend.Pharmacy.csproj"
COPY . .
WORKDIR "/src/HealthCampus.Frontend.Pharmacy"
RUN dotnet build "HealthCampus.Frontend.Pharmacy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HealthCampus.Frontend.Pharmacy.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HealthCampus.Frontend.Pharmacy.dll"]