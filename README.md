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