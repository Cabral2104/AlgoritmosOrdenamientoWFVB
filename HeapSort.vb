
Public Class HeapSort
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

            For i As Integer = n \ 2 - 1 To 0 Step -1
                Heapify(n, i, steps)
            Next

            For i As Integer = n - 1 To 1 Step -1
                ' Intercambiar el elemento actual con el primero de la heap
                Dim temp As Integer = array(0)
                array(0) = array(i)
                array(i) = temp

                steps.Add(array.ToList()) ' Agrega la lista después de cada iteración

                ' Llamar a Heapify en la heap reducida
                Heapify(i, 0, steps)
            Next

            Return steps
        End Function

        Private Sub Heapify(ByVal n As Integer, ByVal i As Integer, ByVal steps As List(Of List(Of Integer)))
            Dim largest As Integer = i
            Dim left As Integer = 2 * i + 1
            Dim right As Integer = 2 * i + 2

            If left < n AndAlso array(left) > array(largest) Then
                largest = left
            End If

            If right < n AndAlso array(right) > array(largest) Then
                largest = right
            End If

            If largest <> i Then
                ' Intercambiar el elemento actual con el más grande encontrado
                Dim swap As Integer = array(i)
                array(i) = array(largest)
                array(largest) = swap

                steps.Add(array.ToList()) ' Agrega la lista después de cada iteración

                ' Llamar a Heapify en la sub-heap afectada
                Heapify(n, largest, steps)
            End If
        End Sub
    End Class
