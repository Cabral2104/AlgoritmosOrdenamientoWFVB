Public Class RadixSort
    Public Function SortStepByStep(ByVal inputList As List(Of Integer)) As List(Of List(Of Integer))
        Dim steps As New List(Of List(Of Integer))

        Dim maxDigits As Integer = GetMaxDigits(inputList)

        For digitPlace As Integer = 1 To maxDigits
            CountingSortByDigit(inputList, digitPlace)

            ' Agrega una copia de la lista actual a los pasos
            steps.Add(New List(Of Integer)(inputList))
        Next

        Return steps
    End Function

    Private Sub CountingSortByDigit(ByVal inputList As List(Of Integer), ByVal digitPlace As Integer)
        Const baseValue As Integer = 10 ' Consideramos números en base 10

        Dim buckets(baseValue - 1) As List(Of Integer)

        For i As Integer = 0 To baseValue - 1
            buckets(i) = New List(Of Integer)()
        Next

        For Each num As Integer In inputList
            Dim digit As Integer = GetDigit(num, digitPlace)
            buckets(digit).Add(num)
        Next

        ' Concatena los buckets en la lista original
        inputList.Clear()
        For Each bucket As List(Of Integer) In buckets
            inputList.AddRange(bucket)
        Next
    End Sub

    Private Function GetDigit(ByVal number As Integer, ByVal digitPlace As Integer) As Integer
        Return (number \ CInt(Math.Pow(10, digitPlace - 1))) Mod 10
    End Function

    Private Function GetMaxDigits(ByVal inputList As List(Of Integer)) As Integer
        Dim maxDigits As Integer = 0

        For Each num As Integer In inputList
            Dim numDigits As Integer = CInt(Math.Floor(Math.Log10(num) + 1))
            maxDigits = Math.Max(maxDigits, numDigits)
        Next

        Return maxDigits
    End Function
End Class
