FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

COPY *.sln .
COPY GCCDockerWorkshop/*.csproj ./GCCDockerWorkshop/
RUN dotnet restore

COPY GCCDockerWorkshop/. ./GCCDockerWorkshop/
WORKDIR /app/GCCDockerWorkshop
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY --from=build /app/GCCDockerWorkshop/out ./
ENTRYPOINT ["dotnet", "GCCDockerWorkshop.dll"]
