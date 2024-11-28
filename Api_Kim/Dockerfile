FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["project/project.csproj", "./"]
COPY ["BusinessLogic/BusinessLogic.csproj", "../BusinessLogic/"]
COPY ["Domain/Domain.csproj", "../Domain/"]
COPY ["DataAccess/DataAccess.csproj", "../DataAccess/"]
RUN dotnet restore "project/project.csproj"
COPY project/. .
WORKDIR "/src/"
RUN dotnet build "project.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "project/project.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "project.dll"]
