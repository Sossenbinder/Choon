FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Applications/Choon.Api/Choon.Api.csproj", "src/Applications/Choon.Api/"]
COPY ["src/Domains/Domains.FormCheck/Domains.FormCheck.csproj", "src/Domains/Domains.FormCheck/"]
COPY ["src/Common/Common.csproj", "src/Common/"]
COPY ["src/Infrastructure/Infrastructure/Infrastructure.csproj", "src/Infrastructure/Infrastructure/"]
RUN dotnet restore "src/Applications/Choon.Api/Choon.Api.csproj"
COPY . .
WORKDIR "/src/src/Applications/Choon.Api"
RUN dotnet build "Choon.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Choon.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Choon.Api.dll"]
