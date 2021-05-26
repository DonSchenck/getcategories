# getcategories
Retrieves an alphabetical list of distinct Product Categories from database CandyDB, table Categories

## To create an OCI-compliant (e.g. docker or podman) image:

### Step 1: Publish the application on your local machine  
 `dotnet publish -r rhel.8-x64 -p:PublishSingleFile=true -c Release --self-contained true`  

### Step 2: Build the image  
 If using podman:  
 `podman build -t getcategories:v1 -f ./DockerfileUBI .`  

 If using docker:  
 `docker build -t getcategories:v1 -f ./DockerfileUBI .`
