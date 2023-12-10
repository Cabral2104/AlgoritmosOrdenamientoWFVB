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
            ' Llama al método DeleteValue de Shell_Sort
            shellSort.DeleteValue(valor)

            ' Obtén la lista actualizada después de eliminar el valor
            Dim listaDespuesEliminar As List(Of Integer) = shellSort.GetArray().ToList()

            ' Muestra la lista actualizada en el ListBox
            MostrarListaEnListBox(lstAntesOrdenar, listaDespuesEliminar)
        Else
            MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnOrdenarShellSort_Click_1(sender As Object, e As EventArgs) Handles btnOrdenarShellSort.Click
        ' Insertar todos los valores en la instancia de ShellSort y luego obtener los pasos de ordenamiento
        shellSort.InsertValues(valoresIngresados.ToArray())
        Dim steps = shellSort.SortStepByStep()

        For Each stepList In steps
            ' Construir una cadena para representar la fila actual
            Dim rowString As String = String.Join(" ", stepList)

            ' Agregar la cadena al ListBox
            lstDespuesOrdenar.Items.Add(rowString)

            ' Esperar un tiempo antes de mostrar el siguiente paso (mejor manejo de la interfaz de usuario)
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

    Private Sub BtnInsertarSelectionSort_Click_1(sender As Object, e As EventArgs) Handles BtnInsertarSelectionSort.Click
        If Integer.TryParse(txtValorAInsertarSelectionSort.Text, valor) Then
            valoresIngresadosSelectionSort.Add(valor)
            MostrarListaEnListBoxSelectionSort(lstAntesOrdenarSelectionSort, valoresIngresadosSelectionSort)
            txtValorAInsertarSelectionSort.Clear()
        Else
            MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnEliminarSelectionSort_Click_1(sender As Object, e As EventArgs) Handles BtnEliminarSelectionSort.Click
        If Integer.TryParse(txtValorAEliminarSelectionSort.Text, valor) Then
            valoresIngresadosSelectionSort.Remove(valor)
            MostrarListaEnListBoxSelectionSort(lstAntesOrdenarSelectionSort, valoresIngresadosSelectionSort)
        Else
            MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnOrdenarSelectionSort_Click_1(sender As Object, e As EventArgs) Handles BtnOrdenarSelectionSort.Click
        selectionSort.InsertValues(valoresIngresadosSelectionSort.ToArray())
        Dim steps = selectionSort.SortStepByStep()

        ' Limpiar el ListBox antes de comenzar
        lstDespuesOrdenarSelectionSort.Items.Clear()

        For Each currentStep In steps
            ' Convertir el arreglo de cadenas a una lista de enteros
            Dim integerList As New List(Of Integer)

            For Each s As String In currentStep
                Dim intValue As Integer
                If Integer.TryParse(s, intValue) Then
                    ' La conversión fue exitosa, agregar el valor a la lista
                    integerList.Add(intValue)
                Else
                    ' Manejar el caso en el que la conversión falla (por ejemplo, cadena no numérica)
                    ' Puedes mostrar un mensaje de error, omitir el valor, o hacer algo más según tus necesidades
                End If
            Next

            ' Construir una cadena para representar la fila actual
            Dim rowString As String = String.Join(" ", integerList)

            ' Agregar la cadena al ListBox
            lstDespuesOrdenarSelectionSort.Items.Add(rowString)

            ' Esperar un tiempo antes de mostrar el siguiente paso (mejor manejo de la interfaz de usuario)
            Application.DoEvents()
            System.Threading.Thread.Sleep(500)
        Next
    End Sub

    Private Sub BtnLimpiarSelectionSort_Click_1(sender As Object, e As EventArgs) Handles BtnLimpiarSelectionSort.Click
        lstAntesOrdenarSelectionSort.Items.Clear()
        lstDespuesOrdenarSelectionSort.Items.Clear()
        valoresIngresadosSelectionSort.Clear()
    End Sub

    'Método Auxiliar para Mostrar la Lista en un ListBox para Selection Sort
    Private Sub MostrarListaEnListBoxSelectionSort(listBox As ListBox, lista As List(Of Integer))
        listBox.Items.Clear()
        listBox.Items.Add(String.Join(", ", lista))
    End Sub

    ''HEAPSORT

    Private Sub BtnInsertarHeapSort_Click_1(sender As Object, e As EventArgs) Handles BtnInsertarHeapSort.Click
        If Integer.TryParse(txtValorAInsertarHeapSort.Text, valor) Then
            valoresIngresadosHeapSort.Add(valor)
            MostrarListaEnListBoxHeapSort(lstAntesOrdenarHeapSort, valoresIngresadosHeapSort)
            txtValorAInsertarHeapSort.Clear()
        Else
            MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnEliminarHeapSort_Click_1(sender As Object, e As EventArgs) Handles BtnEliminarHeapSort.Click
        If Integer.TryParse(txtValorAEliminarHeapSort.Text, valor) Then
            valoresIngresadosHeapSort.Remove(valor)
            MostrarListaEnListBoxHeapSort(lstAntesOrdenarHeapSort, valoresIngresadosHeapSort)
        Else
            MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnOrdenarHeapSort_Click_1(sender As Object, e As EventArgs) Handles BtnOrdenarHeapSort.Click
        ' Insertar todos los valores en la instancia de HeapSort y obtener los pasos de ordenamiento
        heapSort.InsertValues(valoresIngresadosHeapSort.ToArray())
        Dim steps = heapSort.SortStepByStep()

        ' Limpiar el ListBox antes de comenzar
        lstDespuesOrdenarHeapSort.Items.Clear()

        For Each currentStep In steps
            ' Convertir el arreglo de cadenas a una lista de enteros
            Dim integerList As New List(Of Integer)

            For Each s As String In currentStep
                Dim intValue As Integer
                If Integer.TryParse(s, intValue) Then
                    ' La conversión fue exitosa, agregar el valor a la lista
                    integerList.Add(intValue)
                Else
                    ' Manejar el caso en el que la conversión falla (por ejemplo, cadena no numérica)
                    ' Puedes mostrar un mensaje de error, omitir el valor, o hacer algo más según tus necesidades
                End If
            Next

            ' Construir una cadena para representar la fila actual
            Dim rowString As String = String.Join(" ", integerList)

            ' Agregar la cadena al ListBox
            lstDespuesOrdenarHeapSort.Items.Add(rowString)

            ' Esperar un tiempo antes de mostrar el siguiente paso (mejor manejo de la interfaz de usuario)
            Application.DoEvents()
            System.Threading.Thread.Sleep(500)
        Next
    End Sub

    Private Sub BtnLimpiarHeapSort_Click_1(sender As Object, e As EventArgs) Handles BtnLimpiarHeapSort.Click
        lstAntesOrdenarHeapSort.Items.Clear()
        lstDespuesOrdenarHeapSort.Items.Clear()
        valoresIngresadosHeapSort.Clear()
    End Sub

    'Método Auxiliar para Mostrar la Lista en un ListBox para Heap Sort
    Private Sub MostrarListaEnListBoxHeapSort(listBox As ListBox, lista As List(Of Integer))
        listBox.Items.Clear()
        listBox.Items.Add(String.Join(", ", lista))
    End Sub

    'QUICKSORT
    Private Sub BtnInsertarQuickSort_Click_1(sender As Object, e As EventArgs) Handles BtnInsertarQuickSort.Click
        If Integer.TryParse(txtValorAInsertarQuickSort.Text, valor) Then
            valoresIngresadosQuickSort.Add(valor)
            MostrarListaEnListBoxQuickSort(lstAntesOrdenarQuickSort, valoresIngresadosQuickSort)
            txtValorAInsertarQuickSort.Clear()
        Else
            MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnEliminarQuickSort_Click_1(sender As Object, e As EventArgs) Handles BtnEliminarQuickSort.Click
        If Integer.TryParse(txtValorAEliminarQuickSort.Text, valor) Then
            valoresIngresadosQuickSort.Remove(valor)
            MostrarListaEnListBoxQuickSort(lstAntesOrdenarQuickSort, valoresIngresadosQuickSort)
        Else
            MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnOrdenarQuickSort_Click_1(sender As Object, e As EventArgs) Handles BtnOrdenarQuickSort.Click
        ' Insertar todos los valores en la instancia de QuickSort y obtener los pasos de ordenamiento
        quickSort.InsertValues(valoresIngresadosQuickSort.ToArray())
        Dim steps = quickSort.SortStepByStep()

        ' Limpiar el ListBox antes de comenzar
        lstDespuesOrdenarQuickSort.Items.Clear()

        For Each currentStep In steps
            ' Convertir el arreglo de cadenas a una lista de enteros
            Dim integerList As New List(Of Integer)

            For Each s As String In currentStep
                Dim intValue As Integer
                If Integer.TryParse(s, intValue) Then
                    ' La conversión fue exitosa, agregar el valor a la lista
                    integerList.Add(intValue)
                Else
                    ' Manejar el caso en que la conversión falla (por ejemplo, cadena no numérica)
                    ' Puedes mostrar un mensaje de error, omitir el valor, o hacer algo más según tus necesidades
                End If
            Next

            ' Construir una cadena para representar la fila actual
            Dim rowString As String = String.Join(" ", integerList)

            ' Agregar la cadena al ListBox
            lstDespuesOrdenarQuickSort.Items.Add(rowString)

            ' Esperar un tiempo antes de mostrar el siguiente paso (mejor manejo de la interfaz de usuario)
            Application.DoEvents()
            System.Threading.Thread.Sleep(500)
        Next
    End Sub

    Private Sub BtnLimpiarQuickSort_Click_1(sender As Object, e As EventArgs) Handles BtnLimpiarQuickSort.Click
        lstAntesOrdenarQuickSort.Items.Clear()
        lstDespuesOrdenarQuickSort.Items.Clear()
        valoresIngresadosQuickSort.Clear()
    End Sub

    ' Método Auxiliar para Mostrar la Lista en un ListBox para Quicksort
    Private Sub MostrarListaEnListBoxQuickSort(listBox As ListBox, lista As List(Of Integer))
        listBox.Items.Clear()

        For Each item In lista
            ' Agrega cada elemento como un nuevo renglón
            listBox.Items.Add(item.ToString())
        Next
    End Sub

    'BUBBLESORT

    Private Sub BtnInsertarBubbleSort_Click_1(sender As Object, e As EventArgs) Handles BtnInsertarBubbleSort.Click
        If Integer.TryParse(txtValorInsertarBubbleSort.Text, valor) Then
            bubbleSort.InsertValue(valor)
            MostrarListaBubbleSort(lstAntesOrdenarBubbleSort, bubbleSort.GetArray())
            txtValorInsertarBubbleSort.Clear()
        Else
            MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnEliminarBubbleSort_Click_1(sender As Object, e As EventArgs) Handles BtnEliminarBubbleSort.Click
        If Integer.TryParse(txtValorEliminarBubbleSort.Text, valor) Then
            bubbleSort.DeleteValue(valor)
            MostrarListaBubbleSort(lstAntesOrdenarBubbleSort, bubbleSort.GetArray())
        Else
            MessageBox.Show("Ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnOrdenarBubbleSort_Click_1(sender As Object, e As EventArgs) Handles BtnOrdenarBubbleSort.Click
        ' Obtener los pasos de ordenamiento usando BubbleSort
        Dim steps = bubbleSort.SortStepByStep()

        ' Limpiar el ListBox antes de comenzar
        lstDespuesOrdenarBubbleSort.Items.Clear()

        For Each currentStep In steps
            ' Convertir el arreglo de cadenas a una lista de enteros
            Dim integerList As New List(Of Integer)

            For Each s As String In currentStep
                Dim intValue As Integer
                If Integer.TryParse(s, intValue) Then
                    ' La conversión fue exitosa, agregar el valor a la lista
                    integerList.Add(intValue)
                Else
                    ' Manejar el caso en que la conversión falla (por ejemplo, cadena no numérica)
                    ' Puedes mostrar un mensaje de error, omitir el valor, o hacer algo más según tus necesidades
                End If
            Next

            ' Construir una cadena para representar la fila actual
            Dim rowString As String = String.Join(" ", integerList)

            ' Agregar la cadena al ListBox
            lstDespuesOrdenarBubbleSort.Items.Add(rowString)

            ' Esperar un tiempo antes de mostrar el siguiente paso (mejor manejo de la interfaz de usuario)
            Application.DoEvents()
            System.Threading.Thread.Sleep(500)
        Next
    End Sub

    Private Sub BtnLimpiarBubbleSort_Click_1(sender As Object, e As EventArgs) Handles BtnLimpiarBubbleSort.Click
        lstAntesOrdenarBubbleSort.Items.Clear()
        lstDespuesOrdenarBubbleSort.Items.Clear()
        txtValorInsertarBubbleSort.Clear()
        txtValorEliminarBubbleSort.Clear()
        bubbleSort = New BubbleSort() ' Reiniciar la instancia de BubbleSort
    End Sub

    Private Sub MostrarListaBubbleSort(listBox As ListBox, lista As List(Of Integer))
        listBox.Items.Clear()
        listBox.Items.Add(String.Join(", ", lista))
    End Sub

    'COCKTAILSORT

    Private Sub BtnInsertarCocktailSort_Click_1(sender As Object, e As EventArgs) Handles BtnInsertarCocktailSort.Click
        If Integer.TryParse(txtValorInsertarCocktailSort.Text, valor) Then
            cocktailSort.InsertValue(valor)
            MostrarListaCocktailSort(lstAntesOrdenarCocktailSort, cocktailSort.GetArray())
            txtValorInsertarCocktailSort.Clear()
        Else
            MessageBox.Show("Ingrese un valor numérico para insertar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnEliminarCocktailSort_Click_1(sender As Object, e As EventArgs) Handles BtnEliminarCocktailSort.Click
        If Integer.TryParse(txtValorEliminarCocktailSort.Text, valor) Then
            cocktailSort.DeleteValue(valor)
            MostrarListaCocktailSort(lstAntesOrdenarCocktailSort, cocktailSort.GetArray())
        Else
            MessageBox.Show("Ingrese un valor numérico para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnOrdenarCocktailSort_Click_1(sender As Object, e As EventArgs) Handles BtnOrdenarCocktailSort.Click
        ' Obtener los pasos de ordenamiento usando CocktailSort
        Dim steps = cocktailSort.SortStepByStep()

        ' Limpiar el ListBox antes de comenzar
        lstDespuesOrdenarCocktailSort.Items.Clear()

        ' Iterar a través de cada paso en reversa para mostrar hacia abajo
        For i As Integer = steps.Count - 1 To 0 Step -1
            ' Convertir el arreglo de cadenas a una lista de enteros
            Dim integerList As New List(Of Integer)(steps(i))

            ' Construir una cadena para representar la fila actual
            Dim rowString As String = String.Join(" ", integerList)

            ' Agregar la cadena al ListBox
            lstDespuesOrdenarCocktailSort.Items.Add(rowString)

            ' Esperar un tiempo antes de mostrar el siguiente paso (mejor manejo de la interfaz de usuario)
            Application.DoEvents()
            System.Threading.Thread.Sleep(500)
        Next
    End Sub

    Private Sub BtnLimpiarCocktailSort_Click_1(sender As Object, e As EventArgs) Handles BtnLimpiarCocktailSort.Click
        lstAntesOrdenarCocktailSort.Items.Clear()
        lstDespuesOrdenarCocktailSort.Items.Clear()
        txtValorInsertarCocktailSort.Clear()
        txtValorEliminarCocktailSort.Clear()
        cocktailSort = New CocktailSort() ' Reiniciar la instancia de CocktailSort
    End Sub

    Private Sub MostrarListaCocktailSort(listBox As ListBox, lista As List(Of Integer))
        listBox.Items.Clear()
        listBox.Items.Add(String.Join(", ", lista))
    End Sub

    Private Sub MostrarPasoCocktailSort(listBox As ListBox, paso As List(Of Integer))
        listBox.Items.Add(String.Join(", ", paso))
    End Sub

    'INSERTIONSORT

    Private Sub BtnInsertarInsertionSort_Click_1(sender As Object, e As EventArgs) Handles BtnInsertarInsertionSort.Click
        If Integer.TryParse(txtValorInsertarInsertionSort.Text, valor) Then
            insertionSort.InsertValue(valor)
            MostrarListaInsertionSort(lstAntesOrdenarInsertionSort, insertionSort.GetArray())
            txtValorInsertarInsertionSort.Clear()
        Else
            MessageBox.Show("Ingrese un valor numérico para insertar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnEliminarInsertionSort_Click_1(sender As Object, e As EventArgs) Handles BtnEliminarInsertionSort.Click
        If Integer.TryParse(txtValorEliminarInsertionSort.Text, valor) Then
            insertionSort.DeleteValue(valor)
            MostrarListaInsertionSort(lstAntesOrdenarInsertionSort, insertionSort.GetArray())
        Else
            MessageBox.Show("Ingrese un valor numérico para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnOrdenarInsertionSort_Click_1(sender As Object, e As EventArgs) Handles BtnOrdenarInsertionSort.Click
        ' Obtener los valores ingresados para ordenar
        Dim valoresIngresadosInsertionSort As List(Of Integer) = ObtenerValoresIngresados()

        ' Insertar los valores en la instancia de InsertionSort
        For Each valor In valoresIngresadosInsertionSort
            insertionSort.InsertValue(valor)
        Next

        ' Limpiar el ListBox antes de comenzar
        lstDespuesOrdenarInsertionSort.Items.Clear()

        ' Obtener los pasos de ordenamiento paso a paso
        Dim steps = insertionSort.SortStepByStep()

        ' Iterar a través de cada paso
        For Each currentStep In steps
            ' Mostrar el paso en el ListBox
            MostrarPasoInsertionSort(lstDespuesOrdenarInsertionSort, currentStep)

            ' Esperar un tiempo antes de mostrar el siguiente paso (mejor manejo de la interfaz de usuario)
            Application.DoEvents()
            System.Threading.Thread.Sleep(500)
        Next
    End Sub

    Private Sub BtnLimpiarInsertionSort_Click_1(sender As Object, e As EventArgs) Handles BtnLimpiarInsertionSort.Click
        lstAntesOrdenarInsertionSort.Items.Clear()
        lstDespuesOrdenarInsertionSort.Items.Clear()
        txtValorInsertarInsertionSort.Clear()
        txtValorEliminarInsertionSort.Clear()
        insertionSort = New InsertionSort()
    End Sub

    ' Método Auxiliar para Mostrar la Lista en un ListBox para InsertionSort
    Private Sub MostrarListaInsertionSort(listBox As ListBox, lista As List(Of Integer))
        listBox.Items.Clear()

        For Each item In lista
            ' Agrega cada elemento como un nuevo renglón
            listBox.Items.Add(item.ToString())
        Next
    End Sub

    ' Método Auxiliar para Mostrar un Paso en un ListBox para InsertionSort
    Private Sub MostrarPasoInsertionSort(listBox As ListBox, paso As List(Of Integer))
        listBox.Items.Add(String.Join(", ", paso))
    End Sub

    Private Function ObtenerValoresIngresados() As List(Of Integer)
        ' Aquí debes obtener la lista de valores ingresados, por ejemplo, desde TextBoxes u otro control
        ' Este es un ejemplo simple, ajusta según tus necesidades
        Dim valores As New List(Of Integer)()
        valores.Add(5)
        valores.Add(3)
        valores.Add(8)
        ' ... Agrega más valores según sea necesario
        Return valores
    End Function

    'COUNTINGSORT

    Private Sub BtnInsertarCountingSort_Click_1(sender As Object, e As EventArgs) Handles BtnInsertarCountingSort.Click
        Dim value As Integer

        If Integer.TryParse(txtValorInsertarCountingSort.Text, value) Then
            countingSort.InsertValue(value)
            MostrarListaEnListBoxCountingSort(lstAntesOrdenarCountingSort, countingSort.GetArray())
            txtValorInsertarCountingSort.Clear()
        Else
            MessageBox.Show("Por favor, ingrese un valor numérico válido.")
        End If
    End Sub

    Private Sub BtnEliminarCountingSort_Click_1(sender As Object, e As EventArgs) Handles BtnEliminarCountingSort.Click
        Dim value As Integer

        If Integer.TryParse(txtValorEliminarCountingSort.Text, value) Then
            countingSort.DeleteValue(value)
            MostrarListaEnListBoxCountingSort(lstAntesOrdenarCountingSort, countingSort.GetArray())
        Else
            MessageBox.Show("Por favor, ingrese un valor numérico válido.")
        End If
    End Sub

    Private Sub BtnOrdenarCountingSort_Click_1(sender As Object, e As EventArgs) Handles BtnOrdenarCountingSort.Click
        ' Obtener los valores ingresados para ordenar
        Dim valoresIngresadosCountingSort As List(Of Integer) = ObtenerValoresIngresados()

        ' Insertar los valores en la instancia de CountingSort
        For Each valor In valoresIngresadosCountingSort
            countingSort.InsertValue(valor)
        Next

        ' Limpiar el ListBox antes de comenzar
        lstDespuesOrdenarCountingSort.Items.Clear()

        ' Obtener los pasos de ordenamiento paso a paso
        Dim steps = countingSort.SortStepByStep()

        ' Iterar a través de cada paso
        For Each currentStep In steps
            ' Construir una cadena para representar el paso actual
            Dim rowString As String = String.Join(" ", currentStep)

            ' Agregar la cadena al ListBox
            lstDespuesOrdenarCountingSort.Items.Add(rowString)

            ' Esperar un tiempo antes de mostrar el siguiente paso (mejor manejo de la interfaz de usuario)
            Application.DoEvents()
            System.Threading.Thread.Sleep(500)
        Next
    End Sub

    Private Sub BtnLimpiarCountingSort_Click_1(sender As Object, e As EventArgs) Handles BtnLimpiarCountingSort.Click
        countingSort = New CountingSort()
        LimpiarListBoxCountingSort(lstAntesOrdenarCountingSort)
        LimpiarListBoxCountingSort(lstDespuesOrdenarCountingSort)
    End Sub

    Private Sub MostrarListaEnListBoxCountingSort(listBox As ListBox, lista As List(Of Integer))
        listBox.Items.Clear()
        listBox.Items.AddRange(lista.Select(Function(item) item.ToString()).ToArray())
    End Sub

    Private Sub LimpiarListBoxCountingSort(listBox As ListBox)
        listBox.Items.Clear()
    End Sub

    'MERGESORT

    Private Sub BtnInsertarMergeSort_Click_1(sender As Object, e As EventArgs) Handles BtnInsertarMergeSort.Click
        Dim value As Integer

        ' Verifica si el valor ingresado es un número válido
        If Integer.TryParse(txtValorInsertarMergeSort.Text, value) Then
            mergeSort.InsertValue(value)
            MostrarListaEnListBoxMergeSort(lstAntesOrdenarMergeSort, mergeSort.GetArray())
        Else
            MessageBox.Show("Por favor, ingrese un valor numérico válido.")
        End If
    End Sub

    Private Sub BtnEliminarMergeSort_Click_1(sender As Object, e As EventArgs) Handles BtnEliminarMergeSort.Click
        Dim value As Integer

        ' Verifica si el valor ingresado es un número válido
        If Integer.TryParse(txtValorEliminarMergeSort.Text, value) Then
            mergeSort.DeleteValue(value)
            MostrarListaEnListBoxMergeSort(lstAntesOrdenarMergeSort, mergeSort.GetArray())
        Else
            MessageBox.Show("Por favor, ingrese un valor numérico válido.")
        End If
    End Sub

    Private Sub BtnOrdenarMergeSort_Click_1(sender As Object, e As EventArgs) Handles BtnOrdenarMergeSort.Click
        ' Obtén los valores del ListBox y agrégales a la instancia de MergeSort
        For Each item As Object In lstDespuesOrdenarMergeSort.Items
            Dim value As Integer
            If Integer.TryParse(item.ToString(), value) Then
                mergeSort.InsertValue(value)
            Else
                ' Maneja el caso en el que la conversión no fue exitosa
                ' Puedes mostrar un mensaje de error, omitir el valor, o hacer algo más según tus necesidades
            End If
        Next

        ' Obtener pasos del algoritmo
        Dim steps = mergeSort.SortStepByStep()

        ' Limpiar el ListBox antes de comenzar
        lstDespuesOrdenarMergeSort.Items.Clear()

        ' Velocidad de visualización en milisegundos
        Dim speed = 500

        ' Iterar a través de los pasos y mostrar en el ListBox
        For Each currentStep In steps
            ' Construir una cadena para representar la fila actual
            Dim rowString As String = String.Join(" ", currentStep)

            ' Agregar la cadena al ListBox
            lstDespuesOrdenarMergeSort.Items.Add(rowString)

            ' Esperar un tiempo antes de mostrar el siguiente paso
            System.Threading.Thread.Sleep(speed)

            ' Actualizar la interfaz de usuario
            Application.DoEvents()
        Next
    End Sub

    Private Sub BtnLimpiarMergeSort_Click_1(sender As Object, e As EventArgs) Handles BtnLimpiarMergeSort.Click
        mergeSort = New MergeSort()
        LimpiarListBoxMergeSort(lstAntesOrdenarMergeSort)
        LimpiarListBoxMergeSort(lstDespuesOrdenarMergeSort)
    End Sub

    Private Sub LimpiarListBoxMergeSort(listBox As ListBox)
        listBox.Items.Clear()
    End Sub

    ' Método para mostrar una lista en un ListBox asociado a Merge Sort
    Private Sub MostrarListaEnListBoxMergeSort(listBox As ListBox, lista As List(Of Integer))
        listBox.Items.Clear()
        listBox.Items.AddRange(lista.Select(Function(item) item.ToString()).ToArray())
    End Sub

    'BINARYTREESORT

    Private Sub BtnInsertarBinaryTreeSort_Click_1(sender As Object, e As EventArgs) Handles BtnInsertarBinaryTreeSort.Click
        Dim value As Integer

        If Integer.TryParse(txtValorInsertarBinaryTreeSort.Text, value) Then
            binaryTreeSort.Insert(value)
            MostrarListaEnListBoxBinaryTreeSort(lstAntesOrdenarBinaryTreeSort, binaryTreeSort.InOrderTraversal())
            txtValorInsertarBinaryTreeSort.Clear()
        Else
            MessageBox.Show("Por favor, ingrese un valor numérico válido.")
        End If
    End Sub

    Private Sub BtnEliminarBinaryTreeSort_Click_1(sender As Object, e As EventArgs) Handles BtnEliminarBinaryTreeSort.Click
        Dim value As Integer

        If Integer.TryParse(txtValorEliminarBinaryTreeSort.Text, value) Then
            binaryTreeSort.Delete(value)
            MostrarListaEnListBoxBinaryTreeSort(lstAntesOrdenarBinaryTreeSort, binaryTreeSort.InOrderTraversal())
        Else
            MessageBox.Show("Por favor, ingrese un valor numérico válido.")
        End If
    End Sub

    Private Sub BtnOrdenarBinaryTreeSort_Click_1(sender As Object, e As EventArgs) Handles BtnOrdenarBinaryTreeSort.Click
        MostrarListaEnListBoxBinaryTreeSort(lstDespuesOrdenarBinaryTreeSort, binaryTreeSort.InOrderTraversal())
    End Sub

    Private Sub BtnLimpiarBinaryTreeSort_Click(sender As Object, e As EventArgs) Handles btnLimpiarBinaryTreeSort.Click
        binaryTreeSort = New BinaryTreeSort()
        LimpiarListBoxBinaryTreeSort(lstAntesOrdenarBinaryTreeSort)
        LimpiarListBoxBinaryTreeSort(lstDespuesOrdenarBinaryTreeSort)
    End Sub

    Private Sub LimpiarListBoxBinaryTreeSort(listBox As ListBox)
        listBox.Items.Clear()
    End Sub

    ' Método para mostrar una lista en un ListBox asociado a Binary Tree Sort
    Private Sub MostrarListaEnListBoxBinaryTreeSort(listBox As ListBox, lista As List(Of Integer))
        listBox.Items.Clear()
        listBox.Items.AddRange(lista.Select(Function(item) item.ToString()).ToArray())
    End Sub

    'RADIXSORT

    Private Sub BtnInsertarRadixSort_Click_1(sender As Object, e As EventArgs) Handles BtnInsertarRadixSort.Click
        If Integer.TryParse(txtValorInsertarRadixSort.Text, valor) Then
            numbersToSort.Add(valor)
            MostrarListaEnListBoxRadixSort(lstAntesOrdenarRadixSort, numbersToSort)
            txtValorInsertarRadixSort.Clear()
        Else
            MessageBox.Show("Por favor, ingrese un valor numérico válido.")
        End If
    End Sub

    Private Sub BtnEliminarRadixSort_Click_1(sender As Object, e As EventArgs) Handles BtnEliminarRadixSort.Click
        If Integer.TryParse(txtValorEliminarRadixSort.Text, valor) Then
            numbersToSort.Remove(valor)
            MostrarListaEnListBoxRadixSort(lstAntesOrdenarRadixSort, numbersToSort)
        Else
            MessageBox.Show("Por favor, ingrese un valor numérico válido.")
        End If
    End Sub

    Private Sub BtnOrdenarRadixSort_Click_1(sender As Object, e As EventArgs) Handles BtnOrdenarRadixSort.Click
        ' Obtener los pasos del algoritmo Radix Sort
        sortingSteps = radixSort.SortStepByStep(numbersToSort)

        ' Limpiar el ListBox antes de comenzar
        lstDespuesOrdenarRadixSort.Items.Clear()

        ' Velocidad de visualización en milisegundos
        Dim speed = 500

        ' Iterar a través de los pasos y mostrar en el ListBox
        For Each currentStep In sortingSteps
            ' Convertir el arreglo de cadenas a una lista de enteros
            Dim integerList As New List(Of Integer)

            For Each s As String In currentStep
                Dim intValue As Integer
                If Integer.TryParse(s, intValue) Then
                    ' La conversión fue exitosa, agregar el valor a la lista
                    integerList.Add(intValue)
                Else
                    ' Manejar el caso en el que la conversión falla (por ejemplo, cadena no numérica)
                    ' Puedes mostrar un mensaje de error, omitir el valor, o hacer algo más según tus necesidades
                End If
            Next

            ' Construir una cadena para representar la fila actual
            Dim rowString As String = String.Join(" ", integerList)

            ' Agregar la cadena al ListBox
            lstDespuesOrdenarRadixSort.Items.Add(rowString)

            ' Esperar un tiempo antes de mostrar el siguiente paso
            Application.DoEvents()
            System.Threading.Thread.Sleep(speed)
        Next
    End Sub

    Private Sub BtnLimpiarRadixSort_Click_1(sender As Object, e As EventArgs) Handles BtnLimpiarRadixSort.Click
        numbersToSort.Clear()
        LimpiarListBoxRadixSort(lstAntesOrdenarRadixSort)
        LimpiarListBoxRadixSort(lstDespuesOrdenarRadixSort)
    End Sub

    Private Sub MostrarListaEnListBoxRadixSort(listBox As ListBox, lista As List(Of Integer))
        listBox.Items.Clear()
        listBox.Items.AddRange(lista.Select(Function(item) item.ToString()).ToArray())
    End Sub

    Private Sub LimpiarListBoxRadixSort(listBox As ListBox)
        listBox.Items.Clear()
    End Sub

    'GNOMESORT

    ' Método para mostrar una lista en un ListBox asociado a Gnome Sort
    Private Sub MostrarListaEnListBoxGnomeSort(listBox As ListBox, lista As List(Of Integer))
        listBox.Items.Clear()
        listBox.Items.AddRange(lista.Select(Function(item) item.ToString()).ToArray())
    End Sub

    ' Método para limpiar un ListBox asociado a Gnome Sort
    Private Sub LimpiarListBoxGnomeSort(listBox As ListBox)
        listBox.Items.Clear()
    End Sub

    Private Sub BtnInsertarGnomeSort_Click_1(sender As Object, e As EventArgs) Handles BtnInsertarGnomeSort.Click
        Dim value As Integer

        ' Verifica si el valor ingresado es un número válido
        If Integer.TryParse(txtValorInsertarGnomeSort.Text, value) Then
            gnomeSort.InsertValue(value)
            MostrarListaEnListBoxGnomeSort(lstAntesOrdenarGnomeSort, gnomeSort.GetArray())
            txtValorInsertarGnomeSort.Clear()
        Else
            MessageBox.Show("Por favor, ingrese un valor numérico válido.")
        End If
    End Sub

    Private Sub BtnOrdenarGnomeSort_Click_1(sender As Object, e As EventArgs) Handles BtnOrdenarGnomeSort.Click
        ' Obtener los pasos del algoritmo Gnome Sort
        Dim steps = gnomeSort.SortStepByStep()

        ' Limpiar el ListBox antes de comenzar
        lstDespuesOrdenarGnomeSort.Items.Clear()

        ' Velocidad de visualización en milisegundos
        Dim speed = 500

        ' Iterar a través de los pasos y mostrar en el ListBox
        For Each currentStep In steps
            ' Convertir el arreglo de cadenas a una lista de enteros
            Dim integerList As New List(Of Integer)

            For Each s As String In currentStep
                Dim intValue As Integer
                If Integer.TryParse(s, intValue) Then
                    ' La conversión fue exitosa, agregar el valor a la lista
                    integerList.Add(intValue)
                Else
                    ' Manejar el caso en el que la conversión falla (por ejemplo, cadena no numérica)
                    ' Puedes mostrar un mensaje de error, omitir el valor, o hacer algo más según tus necesidades
                End If
            Next

            ' Construir una cadena para representar la fila actual
            Dim rowString As String = String.Join(" ", integerList)

            ' Agregar la cadena al ListBox
            lstDespuesOrdenarGnomeSort.Items.Add(rowString)

            ' Esperar un tiempo antes de mostrar el siguiente paso
            Application.DoEvents()
            System.Threading.Thread.Sleep(speed)
        Next
    End Sub

    Private Sub BtnLimpiarGnomeSort_Click_1(sender As Object, e As EventArgs) Handles BtnLimpiarGnomeSort.Click
        gnomeSort = New GnomeSort()
        LimpiarListBoxGnomeSort(lstAntesOrdenarGnomeSort)
        LimpiarListBoxGnomeSort(lstDespuesOrdenarGnomeSort)
    End Sub

    'MEZCLANATURAL

    ' Método para limpiar un ListBox asociado a Mezcla Natural
    Private Sub LimpiarListBoxMezclaNatural(listBox As ListBox)
        listBox.Items.Clear()
    End Sub

    ' Método para mostrar una lista en un ListBox asociado a Mezcla Natural
    Private Sub MostrarListaEnListBoxMezclaNatural(listBox As ListBox, lista As List(Of Integer))
        listBox.Items.Clear()
        listBox.Items.AddRange(lista.Select(Function(item) item.ToString()).ToArray())
    End Sub

    Private Sub BtnInsertarMezclaNatural_Click_1(sender As Object, e As EventArgs) Handles BtnInsertarMezclaNatural.Click
        Dim value As Integer

        ' Verifica si el valor ingresado es un número válido
        If Integer.TryParse(txtValorInsertarMezclaNatural.Text, value) Then
            mezclaNatural.InsertValue(value)
            MostrarListaEnListBoxMezclaNatural(lstAntesOrdenarMezclaNatural, mezclaNatural.GetArray())
            txtValorInsertarMezclaNatural.Clear()
        Else
            MessageBox.Show("Por favor, ingrese un valor numérico válido.")
        End If
    End Sub

    Private Sub BtnOrdenarMezclaNatural_Click_1(sender As Object, e As EventArgs) Handles BtnOrdenarMezclaNatural.Click
        ' Inicia el proceso de ordenamiento
        mezclaNatural.Sort()

        ' Muestra el resultado en ListBox
        MostrarListaEnListBoxMezclaNatural(lstDespuesOrdenarMezclaNatural, mezclaNatural.GetArray())
    End Sub

    Private Sub BtnLimpiarMezclaNatural_Click_1(sender As Object, e As EventArgs) Handles BtnLimpiarMezclaNatural.Click
        mezclaNatural = New MezclaNatural()
        LimpiarListBoxMezclaNatural(lstAntesOrdenarMezclaNatural)
        LimpiarListBoxMezclaNatural(lstDespuesOrdenarMezclaNatural)
    End Sub
End Class
