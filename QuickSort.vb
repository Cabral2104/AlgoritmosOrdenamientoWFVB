Public Class QuickSort
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
        QuickSortAlgorithm(0, array.Count - 1, steps)
        Return steps
    End Function

    Private Sub QuickSortAlgorithm(ByVal low As Integer, ByVal high As Integer, ByVal steps As List(Of List(Of Integer)))
        If low < high Then
            Dim pi As Integer = Partition(low, high, steps)

            ' Recursivamente ordenar los elementos antes y después de la partición
            QuickSortAlgorithm(low, pi - 1, steps)
            QuickSortAlgorithm(pi + 1, high, steps)
        End If
    End Sub

    Private Function Partition(ByVal low As Integer, ByVal high As Integer, ByVal steps As List(Of List(Of Integer))) As Integer
        Dim pivot As Integer = array(high)
        Dim i As Integer = low - 1

        For j As Integer = low To high - 1
            If array(j) <= pivot Then
                i += 1

                ' Intercambiar array(i) y array(j)
                Dim temp As Integer = array(i)
                array(i) = array(j)
                array(j) = temp

                steps.Add(array.ToList()) ' Agrega una copia de la lista después de cada iteración
            End If
        Next

        ' Intercambiar array(i+1) y array(high) (o el pivote)
        Dim tempPivot As Integer = array(i + 1)
        array(i + 1) = array(high)
        array(high) = tempPivot

        steps.Add(array.ToList()) ' Agrega una copia de la lista después de cada iteración

        Return i + 1
    End Function
End Class
