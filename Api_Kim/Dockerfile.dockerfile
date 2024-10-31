# Step 1: Use the SDK image for building the project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Set the working directory in the container
WORKDIR /src

# Copy only the project files to minimize Docker caching issues
COPY ["project/project.csproj", "project/"]
COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]

# Restore dependencies for each project
RUN dotnet restore "project/project.csproj"

# Copy the rest of the project files
COPY . .

# Build and publish the project to the /app/publish folder
RUN dotnet publish "project/project.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Step 2: Use the ASP.NET Core runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set environment variables for the application
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Development

# Set the working directory in the container
WORKDIR /app

# Expose port 80 for the application
EXPOSE 80

# Copy the published app from the build environment
COPY --from=build-env /app/publish .

# Define the entry point for the application
ENTRYPOINT ["dotnet", "project.dll"]












# #Используемый образ (OS) + установленная платформа .NET
# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# EXPOSE 80
# ENV ASPNETCORE_URLS http://+:80    
# ENV ASPNETCORE_ENVIRONMENT Development  

# WORKDIR /app

# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS build
# WORKDIR /src

# COPY ["project/project.csproj", "project/"]
# COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
# COPY ["Domain/Domain.csproj", "Domain/"]
# COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
# RUN dotnet restore "project/project.csproj"

# COPY . .
# FROM build AS publish 
# RUN dotnet publish "project/project.csproj" -c Release -o /app/publish /p:UseAppHost=false

# FROM base AS final
# WORKDIR /app

# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "project.dll"]











# # Первый этап: установка SDK для сборки проекта
# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# WORKDIR /src

# COPY ["project/project.csproj", "project/"]
# COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
# COPY ["Domain/Domain.csproj", "Domain/"]
# COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
# RUN dotnet restore "project/project.csproj"

# COPY . .
# RUN dotnet publish "project/project.csproj" -c Release -o /app/publish /p:UseAppHost=false

# # Второй этап: создание контейнера с образом ASP.NET для выполнения приложения
# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# WORKDIR /app
# COPY --from=build /app/publish .

# EXPOSE 80
# ENV ASPNETCORE_URLS=http://+:80    
# ENV ASPNETCORE_ENVIRONMENT=Development  

# ENTRYPOINT ["dotnet", "project.dll"]
