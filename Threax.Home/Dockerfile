FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app

FROM threax/build-dotnet:10.0 AS build
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1
WORKDIR /src
COPY . .
WORKDIR /src/Threax.Home
RUN --mount=type=cache,target=node_modules,id=threax-build-home npm install
RUN --mount=type=cache,target=/root/.nuget/packages,id=threax-build-dotnet-nuget dotnet restore Threax.Home.csproj
RUN --mount=type=cache,target=/root/.nuget/packages,id=threax-build-dotnet-nuget dotnet build Threax.Home.csproj -c Release -o /app
RUN --mount=type=cache,target=node_modules,id=threax-build-home npm run clean
RUN --mount=type=cache,target=node_modules,id=threax-build-home npm run build

FROM build AS publish
RUN --mount=type=cache,target=/root/.nuget/packages,id=threax-build-dotnet-nuget dotnet publish Threax.Home.csproj -c Release -o /app

FROM base AS final
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Threax.Home.dll"]
