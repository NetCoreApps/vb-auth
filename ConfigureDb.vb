Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports ServiceStack
Imports ServiceStack.Data
Imports ServiceStack.DataAnnotations
Imports ServiceStack.OrmLite

Public Class MyTable
    <AutoIncrement>
    Public Property Id As Integer
    Public Property Name As String
End Class

Public Class ConfigureDb
    Implements IConfigureServices
    Implements IConfigureAppHost

    Private Configuration As IConfiguration
    Public Sub New(config As IConfiguration)
        Configuration = config
    End Sub

    Public Sub Configure(services As IServiceCollection) Implements IConfigureServices.Configure
        Dim connString = If(Configuration.GetConnectionString("DefaultConnection"),
            "Server=localhost;Database=test;User Id=test;Password=test;MultipleActiveResultSets=True;")
        Dim dbFactory As IDbConnectionFactory = New OrmLiteConnectionFactory(connString, SqlServer2012Dialect.Provider)
        services.AddSingleton(dbFactory)
    End Sub

    Public Sub Configure(appHost As IAppHost) Implements IConfigureAppHost.Configure

        Using db = appHost.Resolve(Of IDbConnectionFactory)().Open()
            If db.CreateTableIfNotExists(Of MyTable) Then
                db.Insert({
                    New MyTable With {.Name = "Seed Data for new MyTable 1"},
                    New MyTable With {.Name = "Seed Data for new MyTable 2"},
                    New MyTable With {.Name = "Seed Data for new MyTable 3"}
                })
            End If
        End Using

    End Sub

End Class