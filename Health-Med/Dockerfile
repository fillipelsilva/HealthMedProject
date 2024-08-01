#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Health-Med/Health-Med.Api.csproj", "Health-Med/"]
COPY ["Health.IoC/Health.IoC.csproj", "Health.IoC/"]
COPY ["HealthMed.Application/HealthMed.Application.csproj", "HealthMed.Application/"]
COPY ["HealthMed.Domain/HealthMed.Domain.csproj", "HealthMed.Domain/"]
COPY ["HealthMed.Infraestructure/HealthMed.Infraestructure.csproj", "HealthMed.Infraestructure/"]
RUN dotnet restore "./Health-Med/Health-Med.Api.csproj"
COPY . .
WORKDIR "/src/Health-Med"
RUN dotnet build "./Health-Med.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Health-Med.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Health-Med.Api.dll"]