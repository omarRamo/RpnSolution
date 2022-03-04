#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Rpn.API/Rpn.API.csproj", "Rpn.API/"]
COPY ["Rpn.DAL/Rpn.DAL.csproj", "Rpn.DAL/"]
RUN dotnet restore "Rpn.API/Rpn.API.csproj"
COPY . .
WORKDIR "/src/Rpn.API"
RUN dotnet build "Rpn.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rpn.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rpn.API.dll"]