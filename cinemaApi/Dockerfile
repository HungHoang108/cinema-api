FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5034

ENV ASPNETCORE_URLS=http://+:5034

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["cinemaApi/cinemaApi.csproj", "cinemaApi/"]
RUN dotnet restore "cinemaApi\cinemaApi.csproj"
COPY . .
WORKDIR "/src/cinemaApi"
RUN dotnet build "cinemaApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "cinemaApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cinemaApi.dll"]
