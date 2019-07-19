FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Accounts.WebApi/Accounts.WebApi.csproj", "Accounts.WebApi/"]
RUN dotnet restore "Accounts.WebApi/Accounts.WebApi.csproj"
COPY . .
WORKDIR "/src/Accounts.WebApi"
RUN dotnet build "Accounts.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Accounts.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Accounts.WebApi.dll"]