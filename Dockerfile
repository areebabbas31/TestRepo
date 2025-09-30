# Stage 1: Build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src


COPY ./*.sln ./
COPY Test/Test.csproj BulkyBookWeb/BulkyBookWeb.csproj
RUN  dotnet restore ./Test/Test.csproj


WORKDIR /src
COPY . ./
RUN  dotnet restore ./Test/Test.csproj


# Build and publish the solution
RUN dotnet publish Test/Test.csproj -c Release -o /app/publish

# Stage 2: Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Test.dll"]
