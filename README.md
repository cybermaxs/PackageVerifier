# PackageVerifier
Command line tool that lists all versions of nuget pacakges in TFS or file system to avoid obsolete dependencies.
A mismatch between packages version into your projects, branches, ... is very common and can lead to several weird situations

Sample output for https://github.com/filipw/AspNetWebApi-OutputCache and package 'Newtonsoft.Json'


##Examples


#### List all versions for a given package in a Git remote repository
```

> PackageVerifier.exe -h filipw/AspNetWebApi-OutputCache -s git -p Newtonsoft.Json 

Scanned 7 packages.config at git => filipw/AspNetWebApi-OutputCache

**************************************
Newtonsoft.Json - Lastest Version 6.0.8
Summary :
**************************************

Found 2 versions of 'Newtonsoft.Json'

  => Version 6.0.4
    sample/WebApi.OutputCache.V2.Demo/packages.config
    src/WebApi.OutputCache.V2/packages.config

  => Version 4.5.11
    sample/WebAPI.OutputCache.Demo/packages.config
    src/WebAPI.OutputCache/packages.config
    test/WebAPI.OutputCache.Tests/packages.config
    test/WebApi.OutputCache.V2.Tests/packages.config

```

#### Check version of all packages on the file system

```
> PackageVerifier.exe -h C:\_git\SignalR -s file 

Scanned 32 packages.config at file => C:\_git\SignalR

OUTDATED (Current stable 1.1.10) - Package 'Microsoft.Bcl' has 1 version(s) (1.1.9)
OUTDATED (Current stable 1.0.21) - Package 'Microsoft.Bcl.Build' has 1 version(s) (1.0.14)
OUTDATED (Current stable 4.5.3723) - Package 'OpenCover' has 1 version(s) (4.5.1403)
OUTDATED (Current stable 2.1.3.0) - Package 'ReportGenerator' has 1 version(s) (1.7.3.0)
OUTDATED (Current stable 2.0.0) - Package 'xunit.runners' has 2 version(s) (1.9.1, 2.0.0-beta4-build2738)
OUTDATED (Current stable 2.0.0) - Package 'xunit.core' has 1 version(s) (2.0.0-beta4-build2738)
OUTDATED (Current stable 5.2.3) - Package 'Microsoft.AspNet.Cors' has 2 version(s) (5.0.0, 5.2.2)
OUTDATED (Current stable 3.0.1) - Package 'Microsoft.Owin' has 2 version(s) (2.1.0, 3.0.0)
OUTDATED (Current stable 3.0.1) - Package 'Microsoft.Owin.Cors' has 2 version(s) (2.1.0, 3.0.0)
OUTDATED (Current stable 3.0.1) - Package 'Microsoft.Owin.Diagnostics' has 1 version(s) (2.1.0)
OUTDATED (Current stable 3.0.1) - Package 'Microsoft.Owin.Host.HttpListener' has 1 version(s) (2.1.0)
OUTDATED (Current stable 3.0.1) - Package 'Microsoft.Owin.Hosting' has 1 version(s) (2.1.0)
OUTDATED (Current stable 3.0.1) - Package 'Microsoft.Owin.SelfHost' has 1 version(s) (2.1.0)
OUTDATED (Current stable 6.0.8) - Package 'Newtonsoft.Json' has 1 version(s) (6.0.4)
LATEST - Package 'Owin' has 1 version(s) (1.0)
OUTDATED (Current stable 1.0.168) - Package 'Microsoft.Bcl.Async' has 1 version(s) (1.0.16)
OUTDATED (Current stable 2.2.29) - Package 'Microsoft.Net.Http' has 1 version(s) (2.2.28)
OUTDATED (Current stable 2.1.3) - Package 'jQuery' has 3 version(s) (1.6.2, 1.8.2, 2.0.0)
OUTDATED (Current stable 2.1.2) - Package 'jQuery.Color' has 1 version(s) (2.1.0)
OUTDATED (Current stable 1.11.4) - Package 'jQuery.UI.Combined' has 1 version(s) (1.9.0)
OUTDATED (Current stable 3.3.0) - Package 'knockoutjs' has 1 version(s) (2.1.0)
OUTDATED (Current stable 3.0.1) - Package 'Microsoft.Owin.Host.SystemWeb' has 2 version(s) (2.1.0, 3.0.0)
OUTDATED (Current stable 1.4.0) - Package 'jquery.cookie' has 1 version(s) (1.0)
OUTDATED (Current stable 1.4.5) - Package 'jquery.mobile' has 1 version(s) (1.2.0)
LATEST - Package 'jQuery.Templates' has 1 version(s) (0.1)
LATEST - Package 'json2' has 1 version(s) (1.0.2)
OUTDATED (Current stable 3.0.1) - Package 'Microsoft.Owin.Security' has 2 version(s) (2.1.0, 3.0.0)
OUTDATED (Current stable 3.0.1) - Package 'Microsoft.Owin.Security.Cookies' has 2 version(s) (2.1.0, 3.0.0)
OUTDATED (Current stable 3.0.1.1) - Package 'Twitter.Bootstrap' has 1 version(s) (2.1.1)
LATEST - Package 'CmdLine' has 1 version(s) (1.0.7.509)
OUTDATED (Current stable 1.0.394) - Package 'StackExchange.Redis.StrongName' has 1 version(s) (1.0.320)
OUTDATED (Current stable 2.0.3) - Package 'Microsoft.WindowsAzure.ConfigurationManager' has 1 version(s) (2.0.0.0)
OUTDATED (Current stable 2.6.4) - Package 'WindowsAzure.ServiceBus' has 1 version(s) (2.1.2.0)
OUTDATED (Current stable 4.2.1502.0911) - Package 'Moq' has 2 version(s) (4.0.10827, 4.2.1402.2112)
OUTDATED (Current stable 2.0.0) - Package 'xunit' has 2 version(s) (1.9.1, 2.0.0-beta4-build2738)
OUTDATED (Current stable 2.0.0) - Package 'xunit.abstractions' has 1 version(s) (2.0.0-beta4-build2738)
OUTDATED (Current stable 2.0.0) - Package 'xunit.assert' has 1 version(s) (2.0.0-beta4-build2738)
OUTDATED (Current stable 2.0.0) - Package 'xunit.runner.visualstudio' has 1 version(s) (0.99.8)
OUTDATED (Current stable 2.0.0) - Package 'xunit.extensions' has 1 version(s) (1.9.1)
OUTDATED (Current stable 3.0.1) - Package 'Microsoft.Owin.Testing' has 1 version(s) (2.1.0)

```