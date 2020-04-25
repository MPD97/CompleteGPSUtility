#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Reciver/Reciver.csproj", "Reciver/"]
RUN dotnet restore "Reciver/Reciver.csproj"
COPY . .
WORKDIR "/src/Reciver"
RUN dotnet build "Reciver.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Reciver.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reciver.dll"]