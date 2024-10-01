
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
EXPOSE 8080

COPY ["Devopsweb.csproj", "./"]
COPY ["./DevopswebTests", "./"]
RUN dotnet restore "./Devopsweb.csproj"

COPY . .
RUN dotnet build "Devopsweb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Devopsweb.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Devopsweb.dll"]


