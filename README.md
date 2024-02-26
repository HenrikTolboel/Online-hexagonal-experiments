# markdown

```
mkdir src tests
dotnet new gitignore
dotnet new classlib -n Online.Application -o src/Online.Application
dotnet new classlib -n Online.Domain -o src/Online.Domain
dotnet new webapi --use-controllers --use-program-main -n Online.Input.Rest -o src/Online.Input.Rest

dotnet new classlib -n Online.Output.MemoryPersistence -o src/Online.Output.MemoryPersistence
```

in Solution explorer, add each project as "existing Project" to the sln file


## Docker

To run the service in docker, Do this:

```
docker init
Welcome to the Docker Init CLI!

This utility will walk you through creating the following files with sensible defaults for your project:
  - .dockerignore
  - Dockerfile
  - compose.yaml
  - README.Docker.md

Let's get started!

? What application platform does your project use? ASP.NET Core
? What's the name of your solution's main project? Online.Input.Rest
? What version of .NET do you want to use? 8.0
? What local port do you want to use to access your server? 8080
```

This will generate the needed Dockerfile.

You can then run

```
 docker compose up --build -d
```

and The appllication will be available on `http://localhost:8080/Online`

