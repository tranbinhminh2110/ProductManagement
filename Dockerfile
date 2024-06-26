
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app


EXPOSE 8080
EXPOSE 8081
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /srs
COPY ["SE162152.ProductManagement.API/SE162152.ProductManagement.API.csproj" , "SE162152.ProductManagement.API/"]

COPY ["SE162152.ProductManagement.Repo/SE162152.ProductManagement.Repo.csproj" , "SE162152.ProductManagement.Repo/"]
# Khôi phục các phụ thuộc cho tất cả các dự án
RUN dotnet restore "SE162152.ProductManagement.API/SE162152.ProductManagement.API.csproj"

# Sao chép toàn bộ mã nguồn vào thư mục làm việc
COPY . .
WORKDIR "/srs/SE162152.ProductManagement.API"
RUN dotnet build "SE162152.ProductManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage 2: Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SE162152.ProductManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish

# Stage 3: Create the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SE162152.ProductManagement.API.dll"]