Public Class InsertionSort
    Private array As List(Of Integer)

    Public Sub New()
        array = New List(Of Integer)()
    End Sub

    Public Sub InsertValue(ByVal value As Integer)
        array.Add(value)
    End Sub

    Public Sub DeleteValue(ByVal value As Integer)
        array.Remove(value)
    End Sub

    Public Function GetArray() As List(Of Integer)
        Return New List(Of Integer)(array)
    End Function

    Public Function SortStepByStep() As List(Of List(Of Integer))
        Dim steps As New List(Of List(Of Integer))

        For i As Integer = 1 To array.Count - 1
            Dim key As Integer = array(i)
            Dim j As Integer = i - 1

            While j >= 0 AndAlso array(j) > key
                array(j + 1) = array(j)
                j = j - 1
            End While

            array(j + 1) = key
            steps.Add(New List(Of Integer)(array))
        Next

        Return steps
    End Function
End Class
