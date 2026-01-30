Imports System.Data.SqlClient

Public Class Takeaway
    Dim totalAmount As Decimal = 0




    ' Form Load Event
    Private Sub RestaurantBillingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmbVegItems.Items.AddRange(New String() {"Paneer Butter Masala - ₹200", "Veg Biryani - ₹150", "daltadka - ₹100", "Aalu gobhi - ₹150"})
        cmbNonVegItems.Items.AddRange(New String() {"Chicken Curry - ₹250", "Mutton Biryani - ₹300"})
        Waterbox.Items.AddRange(New String() {"Mineral Water - ₹20", "Soda - ₹30"})
        regular.Items.AddRange(New String() {"roti - ₹15", "bhaker - ₹30", "fulka roti - ₹20", "Butter Roti - ₹25", "Sweet - ₹60"})
    End Sub

    ' Add Item Button Click Event
    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        ' Add selected items to ListBox
        AddItemToListBox(cmbVegItems, numQuantity)
        AddItemToListBox(cmbNonVegItems, numQuantity)
        AddItemToListBox(Waterbox, numQuantity)
        AddItemToListBox(regular, numQuantity)
        ' Update total amount
        LabelTotal.Text = "Total Amount: ₹" & totalAmount.ToString()
        cmbVegItems.SelectedIndex = -1
        cmbNonVegItems.SelectedIndex = -1
        Waterbox.SelectedIndex = -1
        regular.SelectedIndex = -1
        numQuantity.Value = 1

    End Sub

    ' Method to add item to ListBox
    Private Sub AddItemToListBox(cmb As ComboBox, nud As NumericUpDown)
        If cmb.SelectedItem IsNot Nothing AndAlso nud.Value > 0 Then
            Dim item As String = cmb.SelectedItem.ToString()
            Dim price As Decimal = Decimal.Parse(item.Split("₹")(1))
            Dim quantity As Integer = nud.Value
            Dim total As Decimal = price * quantity
            NoItem.Items.Add(item & " --- " & quantity & " === ₹" & total)
            totalAmount += total
        End If
    End Sub

    ' Remove Item Button Click Event
    Private Sub ButtonRemove_Click(sender As Object, e As EventArgs) Handles ButtonRemove.Click
        If NoItem.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = NoItem.SelectedItem.ToString()
            Dim total As Decimal = Decimal.Parse(selectedItem.Split("₹")(2))
            totalAmount -= total
            NoItem.Items.Remove(NoItem.SelectedItem)
            LabelTotal.Text = "Total Amount: ₹" & totalAmount.ToString()
        End If
    End Sub

    ' Save Button Click Event
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Save bill logic here
        MessageBox.Show("Bill saved successfully!")
    End Sub

    ' Clear Button Click Event
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        ' Clear all fields


        Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\fooddey\fooddey\fooddey\Database1.mdf;Integrated Security=True"
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO SaleReport (OrderType, WaiterName, CaptainName, CustomerName, CustomerContact, CustomerAddress, Amount) VALUES (@OrderType, @WaiterName, @CaptainName, @CustomerName, @CustomerContact, @CustomerAddress, @Amount)"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@OrderType", Label7.Text)
                command.Parameters.AddWithValue("@WaiterName", Waiter.Text)
                command.Parameters.AddWithValue("@CaptainName", Capain.Text)
                command.Parameters.AddWithValue("@CustomerName", txtCustomer.Text)
                command.Parameters.AddWithValue("@CustomerContact", txtContact.Text)
                command.Parameters.AddWithValue("@CustomerAddress", txtAddress.Text)
                command.Parameters.AddWithValue("@Amount", LabelTotal.Text)

                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
                MessageBox.Show("Settalment successfully!")
                NoItem.Items.Clear()
                LabelTotal.Text = "Total Amount: ₹0"
                Waiter.Clear()
                Capain.Clear()
                txtCustomer.Clear()
                txtContact.Clear()
                txtAddress.Clear()
                cmbVegItems.SelectedIndex = -1
                cmbNonVegItems.SelectedIndex = -1
                Waterbox.SelectedIndex = -1
                regular.SelectedIndex = -1
                numQuantity.Value = 1

            End Using
        End Using


    End Sub


End Class