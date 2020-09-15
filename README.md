# vb-auth

An Empty VB.NET .NET Core project created with [x dotnet tool](https://docs.servicestack.net/dotnet-tool):

    $ md ProjectName && cd ProjectName
    $ x mix init-vb

Configured with [OrmLite + SQL Server](https://github.com/ServiceStack/ServiceStack.OrmLite), 
[ServiceStack Auth](https://docs.servicestack.net/authentication-and-authorization) including Login & Registration UIs
& integrated [JWT Auth](https://docs.servicestack.net/jwt-authprovider) showing how to manage file uploads for authenticated users.

![](https://raw.githubusercontent.com/NetCoreApps/vb-auth/master/screenshot.png)

### Plain static HTML Pages + JavaScript UI

No client or server UI Frameworks or external dependencies were used in this example which uses only Vanilla JS and functionality in the 
[Embedded UMD @servicestack/client](https://docs.servicestack.net/servicestack-client-umd).

E.g. the client HTML UI & Backend Service implementation for the Authenticated HTTP File Upload Management functionality is in:

 - [/wwwroot/files.html](https://github.com/NetCoreApps/vb-auth/blob/master/wwwroot/files.html) - static HTML UI
 - [/ServiceInterface/UploadServices.vb](https://github.com/NetCoreApps/vb-auth/blob/master/ServiceInterface/UploadServices.vb) - back-end Service

### JWT Auth

JWT Authentication is [enabled at authentication](https://docs.servicestack.net/jwt-authprovider#switching-existing-sites-to-jwt) where
the `UseTokenCookie` parameter directs ServiceStack to capture the Authenticated Session in a stateless JWT Session Cookie:

```html
<form action="/auth/credentials" method="post">
    <input type="hidden" name="UseTokenCookie" value="true" />
    ...
</form>
```

### TypeScript Generated DTOs

[TypeScript Add ServiceStack Reference](https://docs.servicestack.net/typescript-add-servicestack-reference) were used to generate the 
Typed DTOs which can be re-generated with:

    $ cd wwwroot
    $ x ts && tsc dtos.ts

### Getting Started

To use this App just configure it to use a valid SQL Server Connection String in [ConfigureDb.vb](https://github.com/NetCoreApps/vb-auth/blob/master/ConfigureDb.vb)
or **"DefaultConnection"** Connection String in appsettings.json:

```vb
Dim connString = If(Configuration.GetConnectionString("DefaultConnection"),
    "Server=localhost;Database=test;User Id=test;Password=test;MultipleActiveResultSets=True;")
```