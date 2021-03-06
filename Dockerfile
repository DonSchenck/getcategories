FROM registry.access.redhat.com/ubi8/dotnet-31
#USER 1001
RUN mkdir getcategories
WORKDIR /getcategories
ADD . .

RUN dotnet publish -c Release

EXPOSE 8080

CMD ["dotnet", "./bin/Release/netcoreapp3.1/publish/getcategories.dll"]