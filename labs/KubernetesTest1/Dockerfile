FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["KubernetesTest1/KubernetesTest1.csproj", "KubernetesTest1/"]

RUN dotnet restore "KubernetesTest1/KubernetesTest1.csproj"
COPY . .
WORKDIR "/src/KubernetesTest1"
RUN dotnet build "KubernetesTest1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KubernetesTest1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KubernetesTest1.dll"]