Public Class CountingSort
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

        ' Implementación del algoritmo Counting Sort
        Dim max As Integer = array.Max()
        Dim min As Integer = array.Min()
        Dim range As Integer = max - min + 1

        Dim countingArray(range - 1) As Integer
        Dim sortedArray As New List(Of Integer)()

        For Each value In array
            countingArray(value - min) += 1
        Next

        For i As Integer = min To max
            While countingArray(i - min) > 0
                sortedArray.Add(i)
                countingArray(i - min) -= 1
            End While

            ' Agregar una copia del estado actual de sortedArray en cada paso
            steps.Add(New List(Of Integer)(sortedArray))
        Next

        Return steps
    End Function
End Class
