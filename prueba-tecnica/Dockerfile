# no se pudo implementar docker por que no halle la forma de iniciar una database con sqlserver
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["prueba-tecnica.csproj", "./"]
RUN dotnet restore "prueba-tecnica.csproj"
COPY . .
RUN dotnet publish "prueba-tecnica.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "prueba-tecnica.dll"]