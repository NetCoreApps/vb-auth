Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports ServiceStack
Imports ServiceStack.Auth
Imports ServiceStack.Configuration
Imports ServiceStack.Data
Imports ServiceStack.OrmLite
Imports ServiceStack.Web

Public Class AppUser
    Inherits UserAuth

    Public Property ProfileUrl As String
    Public Property LastLoginIp As String
    Public Property LastLoginDate As DateTime?

End Class

' Add any additional metadata properties you want to store in the Users Typed Session
Public Class CustomUserSession
    Inherits AuthUserSession

End Class

Public Class AppUserAuthEvents
    Inherits AuthEvents

    Public Overrides Sub OnAuthenticated(req As IRequest, session As IAuthSession, authService As IServiceBase,
                                         tokens As IAuthTokens, authInfo As Dictionary(Of String, String))

        Dim authRepo = HostContext.AppHost.GetAuthRepository(req)
        Using TryCast(authRepo, IDisposable)
            Dim userAuth = CType(authRepo.GetUserAuth(session.UserAuthId), AppUser)
            userAuth.ProfileUrl = session.GetProfileUrl()
            userAuth.LastLoginIp = req.UserHostAddress
            userAuth.LastLoginDate = DateTime.UtcNow
            authRepo.SaveUserAuth(userAuth)
        End Using

    End Sub

End Class

Public Class ConfigureAuth
    Implements IConfigureServices
    Implements IPreInitPlugin
    Implements IConfigureAppHost

    Public Sub Configure(services As IServiceCollection) Implements IConfigureServices.Configure
        services.AddSingleton(Of IAuthRepository)(Function(c) New OrmLiteAuthRepository(Of AppUser, UserAuthDetails)(
            c.Resolve(Of IDbConnectionFactory)()) With {
            .UseDistinctRoleTables = True
        })
    End Sub

    Public Sub BeforePluginsLoaded(appHost As IAppHost) Implements IPreInitPlugin.BeforePluginsLoaded
        appHost.AssertPlugin(Of AuthFeature)().AuthEvents.Add(New AppUserAuthEvents())
    End Sub

    Public Sub Configure(appHost As IAppHost) Implements IConfigureAppHost.Configure

        Dim appSettings = appHost.AppSettings
        appHost.Plugins.Add(New AuthFeature(Function() New CustomUserSession(), {
            New CredentialsAuthProvider(appSettings), ' Sign In with Username / Password credentials
            New JwtAuthProvider(appSettings) With {
                .AuthKey = AesUtils.CreateKey()       ' TODO replace with persistent key https://docs.servicestack.net/jwt-authprovider
            }
        }))

        appHost.Plugins.Add(New RegistrationFeature())

        Dim authRepo = appHost.Resolve(Of IAuthRepository)()
        Using TryCast(authRepo, IDisposable)

            authRepo.InitSchema()

            CreateUser(authRepo, "admin@email.com", "Admin User", "p@55wOrd", {RoleNames.Admin})

        End Using
    End Sub

    Sub CreateUser(authRepo As IAuthRepository, email As String, name As String, password As String, roles() As String)
        If authRepo.GetUserAuthByUserName(email) Is Nothing Then
            Dim newAdmin = New AppUser With {.Email = email, .DisplayName = name}
            Dim user = authRepo.CreateUserAuth(newAdmin, password)
            authRepo.AssignRoles(user, roles)
        End If
    End Sub

End Class