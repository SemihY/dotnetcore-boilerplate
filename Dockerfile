FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

COPY ./src/CreditApi.csproj ./src/CreditApi.csproj
COPY ./tests/CreditApi.Tests.csproj ./tests/CreditApi.Tests.csproj

RUN dotnet restore "./src/CreditApi.csproj"
RUN dotnet restore "./tests/CreditApi.Tests.csproj"

COPY . .

RUN dotnet build "./src/CreditApi.csproj" -c Release -o /app/build
RUN dotnet test ./tests/Xeon.B2bApi.Tests.csproj

FROM build AS publish
RUN dotnet publish "./src/CreditApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CreditApi.dll"]