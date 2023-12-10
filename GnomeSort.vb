Public Class GnomeSort
    Private array As List(Of Integer)

    Public Sub New()
        array = New List(Of Integer)()
    End Sub

    Public Sub InsertValue(ByVal value As Integer)
        array.Add(value)
    End Sub

    Public Function GetArray() As List(Of Integer)
        Return New List(Of Integer)(array)
    End Function

    Public Function SortStepByStep() As List(Of List(Of Integer))
        Dim steps As New List(Of List(Of Integer))()

        Dim n As Integer = array.Count
        Dim index As Integer = 0

        While index < n
            If index = 0 Then
                index += 1
            End If

            If array(index) >= array(index - 1) Then
                index += 1
            Else
                ' Intercambiar si el elemento actual es menor que el anterior
                Dim temp As Integer = array(index)
                array(index) = array(index - 1)
                array(index - 1) = temp

                index -= 1

                steps.Add(New List(Of Integer)(array))
            End If
        End While

        Return steps
    End Function
End Class
