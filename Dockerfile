FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Origin.Web/Origin.Web.csproj", "Origin.Web/"]
COPY ["Origin.Domain/Origin.Domain.csproj", "Origin.Domain/"]
COPY ["Origin.Common/Origin.Common.csproj", "Origin.Common/"]
COPY ["Origin.Application/Origin.Application.csproj", "Origin.Application/"]
RUN dotnet restore "Origin.Web/Origin.Web.csproj"
COPY . .
WORKDIR "/src/Origin.Web"
RUN dotnet build "Origin.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Origin.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Origin.Web.dll"]