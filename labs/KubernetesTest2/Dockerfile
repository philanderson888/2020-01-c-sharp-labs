FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["KubernetesTest2/KubernetesTest2.csproj", "KubernetesTest2/"]

RUN dotnet restore "KubernetesTest2/KubernetesTest2.csproj"
COPY . .
WORKDIR "/src/KubernetesTest2"
RUN dotnet build "KubernetesTest2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KubernetesTest2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KubernetesTest2.dll"]