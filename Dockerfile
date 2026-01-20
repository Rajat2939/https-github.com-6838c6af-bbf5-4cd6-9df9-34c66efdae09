FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything
COPY . .

# Restore, build, test
RUN dotnet restore
RUN dotnet build --configuration Release --no-restore
RUN dotnet test --configuration Release --no-build --verbosity normal

# Publish
RUN dotnet publish "src/Console/LongestIncreasingSubsequence.Console.csproj" -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/runtime:6.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "LongestIncreasingSubsequence.Console.dll"]