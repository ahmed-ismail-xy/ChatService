#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ChatService.API/ChatService.API.csproj", "ChatService.API/"]
COPY ["ChatService.Core/ChatService.Core.csproj", "ChatService.Core/"]
COPY ["ChatService.Infrastructure/ChatService.Infrastructure.csproj", "ChatService.Infrastructure/"]
RUN dotnet restore "ChatService.API/ChatService.API.csproj"
COPY . .
WORKDIR "/src/ChatService.API"
RUN dotnet build "ChatService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChatService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChatService.API.dll"]