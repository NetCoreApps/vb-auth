Imports System
Imports ServiceStack
Imports Acme.ServiceModel
Imports ServiceStack.IO
Imports ServiceStack.Web

Namespace Global.Acme.ServiceInterface

    <Authenticate()>
    Public Class UploadServices
        Inherits Service

        Public Sub Post(request As ServiceModel.UploadFile)
            Dim session = SessionAs(Of CustomUserSession)()
            Dim userDir = "/App_Data/uploads/" + session.UserAuthId + "/"

            For Each httpFile As IHttpFile In MyBase.Request.Files
                VirtualFiles.WriteFile(userDir + httpFile.FileName, httpFile.InputStream)
            Next

        End Sub

        Public Function [Get](request As GetUploadedFiles) As Object
            Dim session = SessionAs(Of CustomUserSession)()
            Dim userDir = "/App_Data/uploads/" + session.UserAuthId + "/"

            Return New GetUploadedFilesResponse With {
                .Results = If(VirtualFiles.GetDirectory(userDir)?.GetFiles().Map(Function(x) x.Name), New List(Of String))
            }
        End Function

        Public Function [Get](request As DownloadFile) As Object
            Dim session = SessionAs(Of CustomUserSession)()
            Dim userDir = "/App_Data/uploads/" + session.UserAuthId + "/"

            Dim file = VirtualFiles.GetFile(userDir + request.Name)
            If file Is Nothing Then
                Throw HttpError.NotFound(request.Name)
            End If

            Return New HttpResult(file, asAttachment:=True)
        End Function

        Public Sub [Delete](request As DeleteFile)
            Dim session = SessionAs(Of CustomUserSession)()
            Dim userDir = "/App_Data/uploads/" + session.UserAuthId + "/"

            VirtualFiles.DeleteFile(userDir + request.Name)
        End Sub

    End Class

End Namespace