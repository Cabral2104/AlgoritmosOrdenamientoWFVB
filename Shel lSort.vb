Public Class Shell_Sort
    Private values As List(Of Integer)

    Public Sub InsertValues(ByVal inputValues As Integer())
        ' Asegúrate de inicializar la lista si es necesario
        values = New List(Of Integer)(inputValues)
    End Sub

    Public Sub DeleteValue(ByVal value As Integer)
        ' Elimina un valor específico de la lista
        If values IsNot Nothing AndAlso values.Contains(value) Then
            values.Remove(value)
        End If
    End Sub

    Public Sub ClearValues()
        ' Elimina todos los valores actuales
        values.Clear()
    End Sub

    Public Function SortStepByStep() As List(Of List(Of Integer))
        Dim steps As New List(Of List(Of Integer))
        Dim sortedValues = New List(Of Integer)(values)

        ' Agrega el estado inicial a los pasos
        steps.Add(New List(Of Integer)(sortedValues))

        ' Implementa la lógica de ShellSort y agrega los pasos intermedios a 'steps'
        ' Esta es una implementación básica de ShellSort, ajusta según tu lógica específica
        Dim n = sortedValues.Count
        Dim gap = n \ 2

        While gap > 0
            For i = gap To n - 1
                Dim temp = sortedValues(i)
                Dim j = i

                While j >= gap AndAlso sortedValues(j - gap) > temp
                    sortedValues(j) = sortedValues(j - gap)
                    j -= gap
                End While

                sortedValues(j) = temp
            Next

            ' Agrega el estado actual a los pasos
            steps.Add(New List(Of Integer)(sortedValues))

            gap \= 2
        End While

        Return steps
    End Function

    Public Function GetArray() As Integer()
        ' Devuelve un array de los valores ordenados
        Return values.ToArray()
    End Function
End Class
