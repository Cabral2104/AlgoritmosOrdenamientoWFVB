Public Class Form1
    Private shellSort As Shell_Sort
    Private valoresIngresados As List(Of Integer)
    Private selectionSort As SelectionSort
    Private valoresIngresadosSelectionSort As List(Of Integer)
    Private heapSort As HeapSort
    Private valoresIngresadosHeapSort As List(Of Integer)
    Private quickSort As QuickSort
    Private valoresIngresadosQuickSort As List(Of Integer)
    Private bubbleSort As BubbleSort
    Private cocktailSort As CocktailSort
    Private insertionSort As InsertionSort
    Private countingSort As CountingSort
    Private mergeSort As New MergeSort()
    Private binaryTreeSort As New BinaryTreeSort()
    Private radixSort As New RadixSort()
    Private numbersToSort As New List(Of Integer)()
    Private sortingSteps As New List(Of List(Of Integer))()
    Private gnomeSort As New GnomeSort()
    Private mezclaNatural As New MezclaNatural()
    Private valor As Integer ' Declaración de la variable valor
    Public Sub New()
        InitializeComponent()
        shellSort = New Shell_Sort()
        valoresIngresados = New List(Of Integer)()
        selectionSort = New SelectionSort()
        valoresIngresadosSelectionSort = New List(Of Integer)()
        heapSort = New HeapSort()
        valoresIngresadosHeapSort = New List(Of Integer)()
        quickSort = New QuickSort()
        valoresIngresadosQuickSort = New List(Of Integer)()
        bubbleSort = New BubbleSort()
        cocktailSort = New CocktailSort()
        insertionSort = New InsertionSort()
        countingSort = New CountingSort()
        mergeSort = New MergeSort()
        binaryTreeSort = New BinaryTreeSort()
        radixSort = New RadixSort()
        numbersToSort = New List(Of Integer)()
        sortingSteps = New List(Of List(Of Integer))()
        gnomeSort = New GnomeSort()
        mezclaNatural = New MezclaNatural()
    End Sub

    'SHELL SORT
    Private Sub btnInsertar_Click_1(sender As Object, e As EventArgs) Handles btnInsertar.Click
        If Integer.TryParse(txtValorAInsertar.Text, valor) Then
            valoresIngresados.Add(valor)
            MostrarListaEnListBox(lstAntesOrdenar, valoresIngresados)
            txtValorAInsertar.Clear()  ' Limpiar el cuadro de texto después de insertar
        Else
            MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnEliminar_Click_1(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Integer.TryParse(txtValorAEliminar.Text, valor) Then
            shellSort.DeleteValue(valor)
            MostrarListaEnListBox(lstAntesOrdenar, shellSort.GetArray())
        Else
            MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnOrdenarShellSort_Click_1(sender As Object, e As EventArgs) Handles btnOrdenarShellSort.Click
        ' Insertar todos los valores en la instancia de ShellSort y luego obtener los pasos de ordenamiento
        shellSort.InsertValues(valoresIngresados.ToArray())
        Dim steps = shellSort.SortStepByStep()

        For Each stepList In steps
            Dim flattenedList As New List(Of Integer) ' Ajusta el tipo según tus datos

            For Each value In stepList
                ' Agregar cada valor individual a la lista
                flattenedList.Add(value)
            Next

            MostrarListaEnListBox(lstDespuesOrdenar, flattenedList)
            Application.DoEvents()
            System.Threading.Thread.Sleep(500)
        Next
    End Sub

    Private Sub btnLimpiar_Click_1(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        lstAntesOrdenar.Items.Clear()
        lstDespuesOrdenar.Items.Clear()
    End Sub

    ' Método auxiliar para mostrar la lista en un ListBox
    Private Sub MostrarListaEnListBox(listBox As ListBox, lista As List(Of Integer))
        listBox.Items.Add(String.Join(", ", lista))
    End Sub

    ''SELECTIONSORT

    'Private Sub BtnInsertarSelectionSort_Click_1(sender As Object, e As EventArgs) Handles BtnInsertarSelectionSort.Click
    '    If Integer.TryParse(txtValorAInsertarSelectionSort.Text, valor) Then
    '        valoresIngresadosSelectionSort.Add(valor)
    '        MostrarListaEnListBoxSelectionSort(lstAntesOrdenarSelectionSort, valoresIngresadosSelectionSort)
    '        txtValorAInsertarSelectionSort.Clear()
    '    Else
    '        MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End If
    'End Sub

    'Private Sub BtnEliminarSelectionSort_Click_1(sender As Object, e As EventArgs) Handles BtnEliminarSelectionSort.Click
    '    If Integer.TryParse(txtValorAEliminarSelectionSort.Text, valor) Then
    '        valoresIngresadosSelectionSort.Remove(valor)
    '        MostrarListaEnListBoxSelectionSort(lstAntesOrdenarSelectionSort, valoresIngresadosSelectionSort)
    '    Else
    '        MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End If
    'End Sub

    'Private Sub BtnOrdenarSelectionSort_Click_1(sender As Object, e As EventArgs) Handles BtnOrdenarSelectionSort.Click
    '    selectionSort.InsertValues(valoresIngresadosSelectionSort.ToArray())
    '    Dim steps = selectionSort.SortStepByStep()

    '    For Each step In steps
    '        ' Corregir aquí: Convertir la cadena a lista de enteros antes de mostrarla en el ListBox
    '        MostrarListaEnListBoxSelectionSort(lstDespuesOrdenarSelectionSort, step.Split(","c).Select(Function(s) Integer.Parse(s)).ToList())
    '    Application.DoEvents()
    '        System.Threading.Thread.Sleep(500)
    '    Next
    'End Sub

    'Private Sub BtnLimpiarSelectionSort_Click_1(sender As Object, e As EventArgs) Handles BtnLimpiarSelectionSort.Click
    '    lstAntesOrdenarSelectionSort.Items.Clear()
    '    lstDespuesOrdenarSelectionSort.Items.Clear()
    '    valoresIngresadosSelectionSort.Clear()
    'End Sub

    ''Método Auxiliar para Mostrar la Lista en un ListBox para Selection Sort
    'Private Sub MostrarListaEnListBoxSelectionSort(listBox As ListBox, lista As List(Of Integer))
    '    listBox.Items.Clear()
    '    listBox.Items.Add(String.Join(", ", lista))
    'End Sub

    ''HEAPSORT

    'Private Sub BtnInsertarHeapSort_Click_1(sender As Object, e As EventArgs) Handles BtnInsertarHeapSort.Click
    '    If Integer.TryParse(txtValorAInsertarHeapSort.Text, valor) Then
    '        valoresIngresadosHeapSort.Add(valor)
    '        MostrarListaEnListBoxHeapSort(lstAntesOrdenarHeapSort, valoresIngresadosHeapSort)
    '        txtValorAInsertarHeapSort.Clear()
    '    Else
    '        MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End If
    'End Sub

    'Private Sub BtnEliminarHeapSort_Click_1(sender As Object, e As EventArgs) Handles BtnEliminarHeapSort.Click
    '    If Integer.TryParse(txtValorAEliminarHeapSort.Text, valor) Then
    '        valoresIngresadosHeapSort.Remove(valor)
    '        MostrarListaEnListBoxHeapSort(lstAntesOrdenarHeapSort, valoresIngresadosHeapSort)
    '    Else
    '        MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End If
    'End Sub

    'Private Sub BtnOrdenarHeapSort_Click_1(sender As Object, e As EventArgs) Handles BtnOrdenarHeapSort.Click
    '    heapSort.InsertValues(valoresIngresadosHeapSort.ToArray())
    '    Dim steps = heapSort.SortStepByStep()

    '    For Each step In steps
    '        ' Convierte la lista de enteros a una cadena antes de agregarla al ListBox
    '        lstDespuesOrdenarHeapSort.Items.Add(String.Join(", ", step))
    '        Application.DoEvents()
    '        System.Threading.Thread.Sleep(500)
    '    Next
    'End Sub

    'Private Sub BtnLimpiarHeapSort_Click_1(sender As Object, e As EventArgs) Handles BtnLimpiarHeapSort.Click
    '    lstAntesOrdenarHeapSort.Items.Clear()
    '    lstDespuesOrdenarHeapSort.Items.Clear()
    '    valoresIngresadosHeapSort.Clear()
    'End Sub

    ''Método Auxiliar para Mostrar la Lista en un ListBox para Heap Sort
    'Private Sub MostrarListaEnListBoxHeapSort(listBox As ListBox, lista As List(Of Integer))
    '    listBox.Items.Clear()
    '    listBox.Items.Add(String.Join(", ", lista))
    'End Sub

End Class
