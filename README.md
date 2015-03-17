# PackageVerifier
Command line tool that lists all versions of nuget pacakges in TFS or file system to avoid obsolete dependencies.
A mismatch between packages version into your projects, branches, ... is very common and can lead to several weird situations

Sample output for my https://github.com/filipw/AspNetWebApi-OutputCache local Repo for package Newtonsoft.Json


```

>PackageVerifier.exe -h filipw/AspNetWebApi-OutputCache -s git -p Newtonsoft.Json

**************************************
Newtonsoft.Json - Last Version 6.0.8
Summary :
**************************************

Scanned 7 packages.config at git=>filipw/AspNetWebApi-OutputCache
Found 2 versions of 'Newtonsoft.Json'

   =>Version 4.5.11
      sample/WebAPI.OutputCache.Demo/packages.config
      src/WebAPI.OutputCache/packages.config
      test/WebAPI.OutputCache.Tests/packages.config
      test/WebApi.OutputCache.V2.Tests/packages.config

   =>Version 6.0.4
      sample/WebApi.OutputCache.V2.Demo/packages.config
      src/WebApi.OutputCache.V2/packages.config

```

