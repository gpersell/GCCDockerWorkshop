# GCC Docker Workshop

This sample application demonstrates on how a dotnet core application can be build as a container image using docker technologies. It also shows  how the application can connect with other services/applications running on other containers.

# Prerequisites

Docker for Desktop
Visual Studio Code

# How Docker Image is built
The sample builds the application in a container based on the larger [.NET Core SDK Docker image](https://hub.docker.com/_/microsoft-dotnet-core-sdk/). It builds the application and then copies the final build result into a Docker image based on the smaller [ASP.NET Core Docker Runtime image](https://hub.docker.com/_/microsoft-dotnet-core-aspnet/).

# To Build And Run This project
From the local git workspace, run `docker-compose up --build`
Then in a browser, go to http://localhost:5055/
