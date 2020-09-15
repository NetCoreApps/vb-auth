Imports System
Imports ServiceStack
Imports Acme.ServiceModel
Imports ServiceStack.OrmLite

Namespace Global.Acme.ServiceInterface

    Public Class MyServices
        Inherits Service

        Public Function Any(request As Hello) As Object
            Return New HelloResponse With {.Result = $"Hello, {request.Name}!"}
        End Function

        Public Function Any(request As MyTables) As Object
            Return New MyTablesResponse With {
                .Results = Db.Select(Of MyTable)
            }
        End Function

    End Class

End Namespace