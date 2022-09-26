FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR webapp

EXPOSE 80
EXPOSE 5024

COPY ./*.csproj
RUN dotnet restore

copy . . 

RUN dotnet publish  -Release -o out

FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /webapp
COPY --from =build /webapp/out .
ENTRYPOINT["dotnet", "Presentacion.ApiManager.dll"]


