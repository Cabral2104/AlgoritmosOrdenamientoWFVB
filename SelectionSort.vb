Public Class SelectionSort
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

    Public Function SortStepByStep() As List(Of String)
        Dim steps As New List(Of String)
        steps.Add(String.Join(", ", array)) ' Agrega la lista original como el primer paso

        Dim n As Integer = array.Count

        For i As Integer = 0 To n - 2
            Dim minIndex As Integer = i

            For j As Integer = i + 1 To n - 1
                If array(j) < array(minIndex) Then
                    minIndex = j
                End If
            Next

            ' Intercambiar elementos
            Dim temp As Integer = array(minIndex)
            array(minIndex) = array(i)
            array(i) = temp

            steps.Add(String.Join(", ", array)) ' Agrega la lista después de cada iteración
        Next

        Return steps
    End Function
End Class
