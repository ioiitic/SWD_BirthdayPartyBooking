#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BirthdayPartyBooking/BirthdayPartyBooking.csproj", "BirthdayPartyBooking/"]
COPY ["BusinessObject/BusinessObject.csproj", "BusinessObject/"]
COPY ["Repository/Repository.csproj", "Repository/"]
COPY ["Service/Services.csproj", "Service/"]
RUN dotnet restore "BirthdayPartyBooking/BirthdayPartyBooking.csproj"
COPY . .
WORKDIR "/src/BirthdayPartyBooking"
RUN dotnet build "BirthdayPartyBooking.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BirthdayPartyBooking.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BirthdayPartyBooking.dll"]