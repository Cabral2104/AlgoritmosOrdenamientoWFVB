Public Class BinaryTreeSort
    Private root As Node
    Private steps As List(Of List(Of Integer))

    Public Sub New()
        root = Nothing
        steps = New List(Of List(Of Integer))()
    End Sub

    Public Sub Insert(ByVal value As Integer)
        root = InsertRec(root, value)
        CaptureStep()
    End Sub

    Private Function InsertRec(ByVal root As Node, ByVal value As Integer) As Node
        If root Is Nothing Then
            root = New Node(value)
            Return root
        End If

        If value < root.Value Then
            root.Left = InsertRec(root.Left, value)
        ElseIf value > root.Value Then
            root.Right = InsertRec(root.Right, value)
        End If

        Return root
    End Function

    Public Function InOrderTraversal() As List(Of Integer)
        Dim result As New List(Of Integer)()
        InOrderTraversalRec(root, result)
        Return result
    End Function

    Private Sub InOrderTraversalRec(ByVal root As Node, ByVal result As List(Of Integer))
        If root IsNot Nothing Then
            InOrderTraversalRec(root.Left, result)
            result.Add(root.Value)
            InOrderTraversalRec(root.Right, result)
        End If
    End Sub

    Public Function GetSortingSteps() As List(Of List(Of Integer))
        Return steps
    End Function

    Private Sub CaptureStep()
        Dim stepValues As New List(Of Integer)()
        InOrderTraversalRec(root, stepValues)
        steps.Add(New List(Of Integer)(stepValues))
    End Sub

    Public Sub Delete(ByVal value As Integer)
        root = Delete(root, value)
    End Sub

    Private Function Delete(ByVal root As Node, ByVal value As Integer) As Node
        If root Is Nothing Then
            Return root
        End If

        ' Recursivamente buscar el nodo a eliminar
        If value < root.Value Then
            root.Left = Delete(root.Left, value)
        ElseIf value > root.Value Then
            root.Right = Delete(root.Right, value)
        Else
            ' Nodo con solo un hijo o sin hijos
            If root.Left Is Nothing Then
                Return root.Right
            ElseIf root.Right Is Nothing Then
                Return root.Left
            End If

            ' Nodo con dos hijos: obtener el sucesor inorden (el menor en el subárbol derecho)
            root.Value = MinValue(root.Right)

            ' Eliminar el sucesor inorden
            root.Right = Delete(root.Right, root.Value)
        End If

        Return root
    End Function

    Private Function MinValue(ByVal root As Node) As Integer
        Dim minValuee As Integer = root.Value
        While root.Left IsNot Nothing
            minValue = root.Left.Value
            root = root.Left
        End While
        Return minValue
    End Function
End Class
