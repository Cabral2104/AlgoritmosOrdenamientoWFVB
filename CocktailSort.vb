Public Class CocktailSort
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
        Dim n As Integer = array.Count
        Dim swapped As Boolean = True
        Dim start As Integer = 0
        Dim [end] As Integer = n - 1

        While swapped
            ' Pase hacia adelante
            swapped = False
            For i As Integer = start To [end] - 1
                If array(i) > array(i + 1) Then
                    Swap(i, i + 1)
                    swapped = True
                    steps.Add(New List(Of Integer)(array))
                End If
            Next

            If Not swapped Then
                Exit While
            End If

            ' Pase hacia atrás
            swapped = False
            [end] -= 1

            For i As Integer = [end] - 1 To start Step -1
                If array(i) > array(i + 1) Then
                    Swap(i, i + 1)
                    swapped = True
                    steps.Add(New List(Of Integer)(array))
                End If
            Next

            start += 1
        End While

        Return steps
    End Function

    Private Sub Swap(ByVal i As Integer, ByVal j As Integer)
        Dim temp As Integer = array(i)
        array(i) = array(j)
        array(j) = temp
    End Sub
End Class
