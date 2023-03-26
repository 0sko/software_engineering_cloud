FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["CarRentalSystem/CarRentalSystem.csproj", "CarRentalSystem/"]
COPY ["CarRentalSystem/Setup.sh", "CarRentalSystem/"]

RUN dotnet tool install --global dotnet-ef

RUN dotnet restore "CarRentalSystem/CarRentalSystem.csproj"
COPY . .
WORKDIR "/src/CarRentalSystem"

RUN chmod +x ./Setup.sh
CMD /bin/bash ./Setup.sh