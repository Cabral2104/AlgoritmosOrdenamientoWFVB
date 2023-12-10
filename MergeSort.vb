Public Class MergeSort
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
        MergeSortAlgorithm(0, array.Count - 1, steps)
        Return steps
    End Function

    Private Sub MergeSortAlgorithm(ByVal low As Integer, ByVal high As Integer, ByVal steps As List(Of List(Of Integer)))
        If low < high Then
            Dim middle As Integer = (low + high) \ 2

            MergeSortAlgorithm(low, middle, steps)
            MergeSortAlgorithm(middle + 1, high, steps)

            Merge(low, middle, high, steps)
        End If
    End Sub

    Private Sub Merge(ByVal low As Integer, ByVal middle As Integer, ByVal high As Integer, ByVal steps As List(Of List(Of Integer)))
        Dim n1 As Integer = middle - low + 1
        Dim n2 As Integer = high - middle

        Dim left As New List(Of Integer)(n1)
        Dim right As New List(Of Integer)(n2)

        Dim i, j As Integer

        For i = 0 To n1 - 1
            left.Add(array(low + i))
        Next

        For j = 0 To n2 - 1
            right.Add(array(middle + 1 + j))
        Next

        i = 0
        j = 0
        Dim k As Integer = low

        While i < n1 AndAlso j < n2
            If left(i) <= right(j) Then
                array(k) = left(i)
                i += 1
            Else
                array(k) = right(j)
                j += 1
            End If
            k += 1

            ' Agrega una copia actualizada de la lista al paso
            steps.Add(New List(Of Integer)(array))
        End While

        While i < n1
            array(k) = left(i)
            i += 1
            k += 1

            ' Agrega una copia actualizada de la lista al paso
            steps.Add(New List(Of Integer)(array))
        End While

        While j < n2
            array(k) = right(j)
            j += 1
            k += 1

            ' Agrega una copia actualizada de la lista al paso
            steps.Add(New List(Of Integer)(array))
        End While
    End Sub
End Class
