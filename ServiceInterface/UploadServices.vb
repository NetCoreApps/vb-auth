Imports System
Imports ServiceStack
Imports Acme.ServiceModel
Imports ServiceStack.IO
Imports ServiceStack.Web

Namespace Global.Acme.ServiceInterface

    <Authenticate()>
    Public Class UploadServices
        Inherits Service

        Function GetUserDir() As String
            Dim session = SessionAs(Of CustomUserSession)()
            Return "/App_Data/uploads/" + session.UserAuthId + "/"
        End Function

        Public Sub Post(request As ServiceModel.UploadFile)
            Dim userDir = GetUserDir()
            For Each httpFile As IHttpFile In MyBase.Request.Files
                VirtualFiles.WriteFile(userDir + httpFile.FileName, httpFile.InputStream)
            Next
        End Sub

        Public Function [Get](request As GetUploadedFiles) As Object
            Dim userDir = GetUserDir()
            Return New GetUploadedFilesResponse With {
                .Results = If(VirtualFiles.GetDirectory(userDir)?.GetFiles().Map(Function(x) x.Name), New List(Of String))
            }
        End Function

        Public Function [Get](request As DownloadFile) As Object
            Dim userDir = GetUserDir()
            Dim file = VirtualFiles.GetFile(userDir + request.Name)
            If file Is Nothing Then
                Throw HttpError.NotFound(request.Name)
            End If

            Return New HttpResult(file, asAttachment:=True)
        End Function

        Public Sub [Delete](request As DeleteFile)
            Dim userDir = GetUserDir()
            VirtualFiles.DeleteFile(userDir + request.Name)
        End Sub

    End Class

End Namespace