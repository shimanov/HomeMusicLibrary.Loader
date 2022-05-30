FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HomeMusicLibrary/HomeMusicLibrary.csproj", "HomeMusicLibrary/"]
RUN dotnet restore "HomeMusicLibrary/HomeMusicLibrary.csproj"
COPY . .
WORKDIR "/src/HomeMusicLibrary"
RUN dotnet build "HomeMusicLibrary.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeMusicLibrary.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeMusicLibrary.dll"]
