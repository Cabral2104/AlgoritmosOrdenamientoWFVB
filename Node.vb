Public Class Node
    Public Property Value As Integer
    Public Property Left As Node
    Public Property Right As Node

    Public Sub New(ByVal value As Integer)
        Me.Value = value
        Left = Nothing
        Right = Nothing
    End Sub
End Class
