Imports ServiceStack

Namespace Global.Acme.ServiceModel

    <Route("/data")>
    Partial Public Class MyTables
        Implements IReturn(Of MyTablesResponse)
    End Class

    Partial Public Class MyTablesResponse
        Public Overridable Property Results As List(Of MyTable)
        Public Property ResponseStatus As ResponseStatus
    End Class

End Namespace