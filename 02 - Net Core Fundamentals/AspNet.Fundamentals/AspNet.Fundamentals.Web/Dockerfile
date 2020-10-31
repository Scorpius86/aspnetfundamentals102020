#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["AspNet.Fundamentals.Web/AspNet.Fundamentals.Web.csproj", "AspNet.Fundamentals.Web/"]
RUN dotnet restore "AspNet.Fundamentals.Web/AspNet.Fundamentals.Web.csproj"
COPY . .
WORKDIR "/src/AspNet.Fundamentals.Web"
RUN dotnet build "AspNet.Fundamentals.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspNet.Fundamentals.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspNet.Fundamentals.Web.dll"]