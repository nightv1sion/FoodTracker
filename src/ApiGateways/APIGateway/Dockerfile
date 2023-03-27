FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source
EXPOSE 80

COPY . ./gatewayapp
WORKDIR /source/gatewayapp
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "APIGateway.dll"]