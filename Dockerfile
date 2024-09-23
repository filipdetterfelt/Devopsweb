
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Devopsweb.csproj ./
RUN dotnet restore

COPY . .

RUN dotnet build "Devopsweb.csproj" -c Release -o /app/build

RUN dotnet publish "Devopsweb.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Devopsweb.dll"]