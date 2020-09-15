Imports ServiceStack

Namespace Global.Acme.ServiceModel

    <Route("/uploads")>
    Public Class UploadFile
        Implements IReturnVoid
    End Class

    <Route("/uploads")>
    Public Class GetUploadedFiles
        Implements IReturn(Of GetUploadedFilesResponse)
    End Class

    Public Class GetUploadedFilesResponse
        Public Overridable Property Results As List(Of String)
        Public Property ResponseStatus As ResponseStatus
    End Class

    <Route("/uploads/{Name}")>
    Public Class DownloadFile
        Implements IReturn(Of Byte())
        Public Property Name As String
    End Class

    <Route("/uploads/{Name}")>
    Public Class DeleteFile
        Implements IReturnVoid
        Public Property Name As String
    End Class

End Namespace