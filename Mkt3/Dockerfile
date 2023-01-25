FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Mkt3/Mkt3.csproj", "Mkt3/"]
RUN dotnet restore "Mkt3/Mkt3.csproj"
COPY . .
WORKDIR "/src/Mkt3"
RUN dotnet build "Mkt3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mkt3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mkt3.dll"]
