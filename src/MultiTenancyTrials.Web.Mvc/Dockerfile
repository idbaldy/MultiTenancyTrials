FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/MultiTenancyTrials.Web.Mvc/MultiTenancyTrials.Web.Mvc.csproj", "src/MultiTenancyTrials.Web.Mvc/"]
COPY ["src/MultiTenancyTrials.Web.Core/MultiTenancyTrials.Web.Core.csproj", "src/MultiTenancyTrials.Web.Core/"]
COPY ["src/MultiTenancyTrials.Application/MultiTenancyTrials.Application.csproj", "src/MultiTenancyTrials.Application/"]
COPY ["src/MultiTenancyTrials.Core/MultiTenancyTrials.Core.csproj", "src/MultiTenancyTrials.Core/"]
COPY ["src/MultiTenancyTrials.EntityFrameworkCore/MultiTenancyTrials.EntityFrameworkCore.csproj", "src/MultiTenancyTrials.EntityFrameworkCore/"]
WORKDIR "/src/src/MultiTenancyTrials.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/MultiTenancyTrials.Web.Mvc", "src/MultiTenancyTrials.Web.Mvc"]
COPY ["src/MultiTenancyTrials.Web.Core", "src/MultiTenancyTrials.Web.Core"]
COPY ["src/MultiTenancyTrials.Application", "src/MultiTenancyTrials.Application"]
COPY ["src/MultiTenancyTrials.Core", "src/MultiTenancyTrials.Core"]
COPY ["src/MultiTenancyTrials.EntityFrameworkCore", "src/MultiTenancyTrials.EntityFrameworkCore"]
WORKDIR "/src/src/MultiTenancyTrials.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "MultiTenancyTrials.Web.Mvc.dll"]
