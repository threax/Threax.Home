FROM microsoft/dotnet:2.1.3-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM build-threax AS build
WORKDIR /src
COPY Threax.Home/Threax.Home.csproj Threax.Home/
RUN dotnet restore Threax.Home/Threax.Home.csproj
COPY . .
WORKDIR /src/Threax.Home
RUN yarn run yarn-install
RUN yarn run clean
RUN yarn run build
RUN dotnet build Threax.Home.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Threax.Home.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Threax.Home.dll"]
