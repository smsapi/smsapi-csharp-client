FROM debian:12-slim

RUN apt-get update && \
    apt-get install -y wget apt-transport-https software-properties-common curl

RUN curl https://packages.microsoft.com/keys/microsoft.asc | tee /etc/apt/trusted.gpg.d/microsoft.asc

RUN wget https://packages.microsoft.com/config/debian/12/prod.list -O /etc/apt/sources.list.d/microsoft-prod.list

RUN curl -fsSL https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor -o /usr/share/keyrings/microsoft-prod.gpg

RUN apt-get update && apt-get install -y \
    dotnet-sdk-6.0 \
    dotnet-sdk-7.0 \
    dotnet-sdk-8.0 \
    dotnet-sdk-9.0

WORKDIR /app

COPY . .

RUN dotnet restore

RUN dotnet build --configuration Release
