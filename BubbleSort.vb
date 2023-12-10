Public Class BubbleSort
    Private array As List(Of Integer)

    Public Sub New()
        array = New List(Of Integer)()
    End Sub

    Public Sub InsertValues(ByVal values() As Integer)
        array.Clear()
        array.AddRange(values)
    End Sub

    Public Sub InsertValue(ByVal value As Integer)
        array.Add(value)
    End Sub

    Public Sub DeleteValue(ByVal value As Integer)
        array.Remove(value)
    End Sub

    Public Function GetArray() As List(Of Integer)
        Return array.ToList()
    End Function

    Public Function SortStepByStep() As List(Of List(Of Integer))
        Dim steps As New List(Of List(Of Integer))
        steps.Add(array.ToList()) ' Agrega la lista original como el primer paso

        Dim n As Integer = array.Count
        For i As Integer = 0 To n - 2
            For j As Integer = 0 To n - i - 2
                If array(j) > array(j + 1) Then
                    ' Intercambiar array(j) y array(j+1)
                    Dim temp As Integer = array(j)
                    array(j) = array(j + 1)
                    array(j + 1) = temp

                    steps.Add(array.ToList()) ' Agrega la lista después de cada intercambio
                End If
            Next
        Next

        Return steps
    End Function
End Class
