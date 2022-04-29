# Docker-Kubernetes

## This tutorial is to deploy containerized .netAPI image into the kubernetes cluster. 

Create an ASP.NET Core API api from Visual studio and enable docket support and Open API specification while  creating the API project. 

Lets examine Docker file: Below is the docker file that is enabled while creating the API project (we enabled intetionally while creating the API project)

make few changes in default docker file to avoid docker image build errors as below 
```
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base  // This is the base image that application  is used in the runtime
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build // this is the image 
WORKDIR /src
COPY ["NetCore5API.csproj", "."]
RUN dotnet restore "./NetCore5API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "NetCore5API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCore5API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCore5API.dll"]
```

#### Navigte the file folder location where docker file resides and  Run the Build command in Poweshell 
```
docker image build -t vijaychamp/netinmemoryapi:0.0.1 .
```
Where 
```
-t --> Tag helper
vijaychamp --> docker reposirtory
netinmemoryapi--> image name
0.0.1 --> tag id
. --> copy all files (The directory where the Docker File is present.)
```

#### once you run the build command, the image is build locally on docker desktop as below and its ready to be pused to docker hub registry

![image](https://user-images.githubusercontent.com/49226342/165945645-75005d01-6258-46f3-8de0-d693af17eee3.png)

Command to push the image

```
docker image push vijaychamp/netinmemoryapi:0.0.1
```
![image](https://user-images.githubusercontent.com/49226342/165946136-990a08ce-b117-41ac-abf3-851d22f768e6.png)

Once the process is completed it will push the image to docker hub as shown below.

![image](https://user-images.githubusercontent.com/49226342/165946300-7e3ba749-df99-4474-8fe6-1e2d9349519e.png)

### Since I already logged in into docker hub, push wil automatically take care of that. 
Now you have image of your .net core api in your docket repository. Now you can deploy this image using kubernetes. 


