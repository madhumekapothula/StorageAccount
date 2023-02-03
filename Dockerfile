FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5287

ENV ASPNETCORE_URLS=http://+:5287

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StorageAccount.csproj", "./"]
RUN dotnet restore "StorageAccount.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "StorageAccount.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StorageAccount.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StorageAccount.dll"]
