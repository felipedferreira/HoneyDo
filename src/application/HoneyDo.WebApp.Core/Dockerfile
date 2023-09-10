FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/application/HoneyDo.WebApp.Core/HoneyDo.WebApp.Core.csproj", "src/application/HoneyDo.WebApp.Core/"]
RUN dotnet restore "src/application/HoneyDo.WebApp.Core/HoneyDo.WebApp.Core.csproj"
COPY . .
WORKDIR "/src/src/application/HoneyDo.WebApp.Core"
RUN dotnet build "HoneyDo.WebApp.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HoneyDo.WebApp.Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HoneyDo.WebApp.Core.dll"]
