FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/MultiTenancyTrials.Web.Host/MultiTenancyTrials.Web.Host.csproj", "src/MultiTenancyTrials.Web.Host/"]
COPY ["src/MultiTenancyTrials.Web.Core/MultiTenancyTrials.Web.Core.csproj", "src/MultiTenancyTrials.Web.Core/"]
COPY ["src/MultiTenancyTrials.Application/MultiTenancyTrials.Application.csproj", "src/MultiTenancyTrials.Application/"]
COPY ["src/MultiTenancyTrials.Core/MultiTenancyTrials.Core.csproj", "src/MultiTenancyTrials.Core/"]
COPY ["src/MultiTenancyTrials.EntityFrameworkCore/MultiTenancyTrials.EntityFrameworkCore.csproj", "src/MultiTenancyTrials.EntityFrameworkCore/"]
WORKDIR "/src/src/MultiTenancyTrials.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/MultiTenancyTrials.Web.Host", "src/MultiTenancyTrials.Web.Host"]
COPY ["src/MultiTenancyTrials.Web.Core", "src/MultiTenancyTrials.Web.Core"]
COPY ["src/MultiTenancyTrials.Application", "src/MultiTenancyTrials.Application"]
COPY ["src/MultiTenancyTrials.Core", "src/MultiTenancyTrials.Core"]
COPY ["src/MultiTenancyTrials.EntityFrameworkCore", "src/MultiTenancyTrials.EntityFrameworkCore"]
WORKDIR "/src/src/MultiTenancyTrials.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "MultiTenancyTrials.Web.Host.dll"]
