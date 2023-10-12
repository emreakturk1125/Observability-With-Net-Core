#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ObservabilityExamples.ConsoleApp/ObservabilityExamples.ConsoleApp.csproj", "ObservabilityExamples.ConsoleApp/"]
RUN dotnet restore "ObservabilityExamples.ConsoleApp/ObservabilityExamples.ConsoleApp.csproj"
COPY . .
WORKDIR "/src/ObservabilityExamples.ConsoleApp"
RUN dotnet build "ObservabilityExamples.ConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ObservabilityExamples.ConsoleApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ObservabilityExamples.ConsoleApp.dll"]