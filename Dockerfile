FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish "PRP.csproj" -c Release -r linux-arm64 --self-contained true -o /app/publish
RUN ls /app/publish  # Debugging step to verify files

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
RUN chmod +x PRP  # Make the file executable
RUN ls /app  # Debugging step to verify files in final image
ENTRYPOINT ["./PRP"]
