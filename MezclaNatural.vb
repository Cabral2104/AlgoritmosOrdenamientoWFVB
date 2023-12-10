Public Class MezclaNatural
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

    ' Método para ordenar sin mostrar pasos intermedios
    Public Sub Sort()
        Dim n As Integer = array.Count
        MezclaNaturalSort(0, n - 1)
    End Sub

    Private Sub MezclaNaturalSort(ByVal start As Integer, ByVal [end] As Integer)
        If start < [end] Then
            Dim middle As Integer = (start + [end]) \ 2

            MezclaNaturalSort(start, middle)
            MezclaNaturalSort(middle + 1, [end])

            Merge(start, middle, [end])
        End If
    End Sub

    Private Sub Merge(ByVal start As Integer, ByVal middle As Integer, ByVal [end] As Integer)
        Dim temp As New List(Of Integer)()

        Dim i As Integer = start
        Dim j As Integer = middle + 1

        ' Fusiona las dos secuencias ordenadas
        While i <= middle AndAlso j <= [end]
            If array(i) <= array(j) Then
                temp.Add(array(i))
                i += 1
            Else
                temp.Add(array(j))
                j += 1
            End If
        End While

        ' Agrega los elementos restantes de la primera secuencia
        While i <= middle
            temp.Add(array(i))
            i += 1
        End While

        ' Agrega los elementos restantes de la segunda secuencia
        While j <= [end]
            temp.Add(array(j))
            j += 1
        End While

        ' Copia los elementos fusionados de nuevo al array original
        For k As Integer = 0 To temp.Count - 1
            array(start + k) = temp(k)
        Next
    End Sub
End Class
