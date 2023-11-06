# Stage 1 - Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy over everything else and build app
COPY MorningstarSearch.sln .
COPY MorningstarSearch/. ./MorningstarSearch/
COPY MorningstarSearch.Tests/. ./MorningstarSearch.Tests/

WORKDIR /app/MorningstarSearch.Tests
RUN dotnet test

WORKDIR /app/MorningstarSearch
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

WORKDIR /app
COPY --from=build /app/MorningstarSearch/out ./

ENTRYPOINT ["dotnet", "MorningstarSearch.dll", "--urls", "http://0.0.0.0:5005"]
