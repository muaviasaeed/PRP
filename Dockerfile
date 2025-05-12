FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src

COPY ["PRP/PRP.csproj", "./"]

RUN dotnet restore "PRP.csproj"

COPY . .

RUN dotnet publish "PRP.csproj" -c Release -r linux-arm64 --self-contained true -o /app/publish

FROM mcr.microsoft.com/dotnet/runtime:7.0

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "PRP.dll"]
