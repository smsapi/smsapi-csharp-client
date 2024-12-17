FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

RUN apt-get update \
    && apt-get install -y wget \
    && wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh \
    && chmod +x dotnet-install.sh \
    && ./dotnet-install.sh --runtime aspnetcore --version 6.0.0 --install-dir /usr/share/dotnet \
    && ./dotnet-install.sh --runtime aspnetcore --version 7.0.0 --install-dir /usr/share/dotnet \
    && ./dotnet-install.sh --runtime aspnetcore --version 8.0.0 --install-dir /usr/share/dotnet \
    && rm dotnet-install.sh

WORKDIR /app

COPY . .

RUN dotnet restore

RUN dotnet build --configuration Release
