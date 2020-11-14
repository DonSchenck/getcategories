FROM registry.access.redhat.com/ubi8/dotnet-31:3.1
USER 1001
RUN mkdir getcategories
WORKDIR getcategories
ADD . .

RUN dotnet publish -c Release

EXPOSE 5000

CMD ["dotnet", "./bin/Release/netcoreapp3.1/publish/getcategories.dll"]