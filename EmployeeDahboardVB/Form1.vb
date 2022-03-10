Imports MySql.Data.MySqlClient
Imports resource = EmployeeForm.My.Resources
Imports System.Threading
Imports System.Data.SqlClient
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports Microsoft.Office.Interop.Excel

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Database.IsValidConnection() Then
            Return
        End If
        Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture
        DisplayRecords()
        setLanguage()
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim res As DialogResult = MessageBox.Show(resource.MSG_EXIST, resource.MSG_EXISTHEAD, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If res = DialogResult.Yes Then
            System.Windows.Forms.Application.Exit()
        End If
    End Sub
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        InsertEmployee()
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateEmployee()
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteEmployee()
    End Sub
    Public Sub InsertEmployee()
        If Not ValidateInput() Then
            Return
        End If
        Dim sq As SqlCommand = getList()
        Dim res As System.Data.DataTable = Database.ExecuteStoredProcedure("Employee_Insert", sq)
        Dim empId As Integer
        If res IsNot Nothing And res.Rows.Count > 0 Then
            empId = Convert.ToInt32(res.Rows(0)(0))
            If empId > 0 Then
                MessageBox.Show(resource.TXT_LBLEMPID + empId & " " + resource.MSG_INSERT, resource.MSG_INSERTHEAD, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(resource.MSG_INSERTERROR, resource.MSG_INSERTHEAD, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        DisplayRecords()
    End Sub
    Public Sub UpdateEmployee()
        Dim empId = txtEmpId.Text
        Dim sq As SqlCommand = getList()
        sq.Parameters.AddWithValue("@EmployeeId", SqlDbType.VarChar).Value = txtEmpId.Text
        Dim resultTable As System.Data.DataTable = Database.ExecuteStoredProcedure("Employee_Update", sq)
        If resultTable IsNot Nothing And resultTable.Rows.Count > 0 Then
            Dim employeeUpdated As Boolean = Convert.ToBoolean(resultTable.Rows(0)(0))

            If employeeUpdated Then
                MessageBox.Show(resource.TXT_LBLEMPID + empId & " " + resource.MSG_UPDATE, resource.MSG_UPDATEHEAD, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(resource.MSG_UPDATEERROR, resource.MSG_UPDATEHEAD, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        DisplayRecords()
    End Sub
    Public Sub DeleteEmployee()
        Dim res As DialogResult = MessageBox.Show(resource.MSG_DELETEERR, resource.MSG_DELETEHEAD, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If res = DialogResult.Yes Then
            Dim empId = txtEmpId.Text
            Dim para As SqlCommand = New SqlCommand()
            para.CommandType = CommandType.StoredProcedure
            para.Parameters.AddWithValue("@EmployeeID", SqlDbType.VarChar).Value = txtEmpId.Text
            Dim resultTable As System.Data.DataTable = Database.ExecuteStoredProcedure("Employee_Delete", para)
            If resultTable IsNot Nothing And resultTable.Rows.Count > 0 Then
                Dim employeeDeleted As Boolean = Convert.ToBoolean(resultTable.Rows(0)(0))
                If employeeDeleted Then
                    MessageBox.Show(resource.TXT_LBLEMPID + empId & " " + resource.MSG_DELETE, resource.MSG_DELETEHEAD, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(resource.MSG_DELETEERROR, resource.MSG_DELETEHEAD, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
        DisplayRecords()
    End Sub
    Public Sub DisplayRecords()
        Dim resultTable As System.Data.DataTable = Database.ExecuteStoredProcedure("Employee_Display")
        DataGridView1.DataSource = resultTable
        Reset()
    End Sub
    Public Function ValidateInput() As Boolean
        Dim insertEmployee As Boolean = True
        If txtAddress.Text = "" OrElse txtBloodgroup.Text = "" OrElse txtContact.Text = "" OrElse txtDOB.Text = "" OrElse txtFirstname.Text = "" OrElse txtLastname.Text = "" OrElse (radioBtnMale.Checked = False AndAlso radioBtnFemale.Checked = False) Then
            MessageBox.Show(resource.MSG_INPUTERROR, resource.MSG_INPUT, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            insertEmployee = False
        End If
        If (txtContact.Text).Length <> 10 Then
            MessageBox.Show(resource.MSG_INVALIDPHNO, resource.MSG_INVALDERROR, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            insertEmployee = False
        End If
        Return insertEmployee
    End Function
    Public Function getList() As SqlCommand
        Try
            Dim gender = If(radioBtnMale.Checked, "M", "F")
            Dim cmd As SqlCommand = New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = txtFirstname.Text
            cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = txtLastname.Text
            cmd.Parameters.AddWithValue("@DOB", SqlDbType.Date).Value = txtDOB.Text
            cmd.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = txtAddress.Text
            cmd.Parameters.AddWithValue("@Bloodgroup", SqlDbType.VarChar).Value = txtBloodgroup.Text
            cmd.Parameters.AddWithValue("@Contact", SqlDbType.BigInt).Value = Convert.ToInt64(txtContact.Text)
            cmd.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = gender
            Return cmd
        Catch ex As Exception
            MessageBox.Show(ex.Message, resource.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Sub Reset()
        txtAddress.Clear()
        txtBloodgroup.Text = String.Empty
        txtDOB.MaxDate = DateTime.Today
        txtDOB.Value = DateTime.Today
        txtContact.Clear()
        txtEmpId.ResetText()
        txtFirstname.Clear()
        txtLastname.Clear()
        radioBtnMale.Checked = True
        radioBtnFemale.Checked = False
        txtEmpId.Text = resource.TXT_EMPID
    End Sub
    Public Sub setLanguage()
        lblName.Text = resource.TXT_LBLNAME
        lblFirstname.Text = resource.TXT_LBLFNAME
        lblLastname.Text = resource.TXT_LBLLNAME
        lblEmpID.Text = resource.TXT_LBLEMPID
        lblDOB.Text = resource.TXT_LBLDOB
        lblAddress.Text = resource.TXT_LBLADDRESS
        lblGender.Text = resource.TXT_LBLGENDER
        lblContact.Text = resource.TXT_LBLCONTACT
        lblBloodgroup.Text = resource.TXT_LBLBLOODGROUP
        lblHead.Text = resource.TXT_LBLHEAD
        radioBtnFemale.Text = resource.TXT_RBTNFEMALE
        radioBtnMale.Text = resource.TXT_RBTNMALE
        btnInsert.Text = resource.TXT_INSERTBTN
        btnDelete.Text = resource.TXT_DELETEBTN
        btnClose.Text = resource.TXT_CLOSEBTN
        btnUpdate.Text = resource.TXT_UPDATEBTN
        btnRefreshToolTip.ToolTipTitle = resource.TXT_REFRESHBTN
        txtEmpId.Text = resource.TXT_EMPID
        btnAddToolTip.ToolTipTitle = resource.TXT_INSERTTOOLTIP
        btnUpdateToolTip.ToolTipTitle = resource.TXT_UPDATETOOLTIP
        btnDeleteToolTip.ToolTipTitle = resource.TXT_DELETETOOLTIP
        btnCloseToolTip.ToolTipTitle = resource.TXT_CLOSETOOLTIP
        btnExportToolTip.ToolTipTitle = resource.TXT_EXPORTTOOLTIP
    End Sub

    Private Sub txtRefresh_Click(sender As Object, e As EventArgs) Handles txtRefresh.Click
        DisplayRecords()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick, DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
            txtEmpId.Text = row.Cells("EmployeeId").Value.ToString()
            txtFirstname.Text = row.Cells("FirstName").Value.ToString()
            txtLastname.Text = row.Cells("LastName").Value.ToString()
            txtDOB.Text = row.Cells("DOB").Value.ToString()
            txtAddress.Text = row.Cells("Address").Value.ToString()
            txtBloodgroup.Text = row.Cells("Bloodgroup").Value.ToString()
            txtContact.Text = row.Cells("Contact").Value.ToString()

            If row.Cells("Gender").Value.ToString() = "Male" Then
                radioBtnMale.Checked = True
            Else
                radioBtnFemale.Checked = True
            End If
        End If
    End Sub
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        exportData()
    End Sub
    Public Sub exportData()
        If DataGridView1.Rows.Count > 0 Then
            Dim saveFile As SaveFileDialog = New SaveFileDialog()
            saveFile.Filter = "PDF |*.pdf|EXCEL |*.xlsx|TEXT |*.txt"
            saveFile.FileName = "Result.pdf"
            Dim fileCreated As Boolean = False

            If saveFile.ShowDialog() = DialogResult.OK Then

                Try

                    Select Case saveFile.FilterIndex
                        Case 1
                            fileCreated = CreatePdf(saveFile.FileName)
                        Case 2
                            fileCreated = CreateExcelSpreadSheet(saveFile.FileName)
                        Case 3
                            fileCreated = CreateTextFile(saveFile.FileName)
                    End Select

                Catch ex As Exception
                    MessageBox.Show(ex.Message, resource.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
                If fileCreated Then
                    MessageBox.Show(saveFile.FileName & " " + resource.TXT_FILECREATION, resource.TXT_FILEHEAD, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Else
            MessageBox.Show(resource.TXT_DATAERROR, resource.TXT_FILEHEAD, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Public Function CreatePdf(ByVal fileName As String) As Boolean
        Try
            Dim pTable As PdfPTable = New PdfPTable(DataGridView1.Columns.Count)
            pTable.WidthPercentage = 80
            Dim c As Integer = 0
            For Each col As DataGridViewColumn In DataGridView1.Columns
                Dim pCell As PdfPCell = New PdfPCell(New Phrase(col.HeaderText))
                pTable.AddCell(pCell)
            Next
            For Each viewRow As DataGridViewRow In DataGridView1.Rows
                c = 0
                For Each dcell As DataGridViewCell In viewRow.Cells
                    If c = 3 Then
                        Dim dateTime = dcell.Value.ToString()
                        Dim d1 = Convert.ToDateTime(dateTime)
                        pTable.AddCell(d1.ToString("yyyy/MM/dd"))
                    Else
                        pTable.AddCell(New Phrase(dcell.Value.ToString()))
                    End If
                    c += 1
                Next
            Next
            Using fileStream As FileStream = New FileStream(fileName, FileMode.Create)
                Dim document As iTextSharp.text.Document = New iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 15.0F, 15.0F, 15.0F, 15.0F)
                PdfWriter.GetInstance(document, fileStream)
                Dim header As String = "details of employees"
                document.Open()
                document.Add(AddHeader(header))
                document.Add(pTable)
                document.Close()
                fileStream.Close()
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, resource.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return True
    End Function
    Public Function CreateExcelSpreadSheet(ByVal fileName As String) As Boolean
        Try
            Dim Excel As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application()
            Dim workBook As Workbook = Excel.Workbooks.Add(Type.Missing)
            Dim workSheet As Worksheet = CType(workBook.ActiveSheet, Worksheet)
            Excel.Visible = False
            For i As Integer = 1 To DataGridView1.Columns.Count + 1
                workSheet.Cells(1, i) = DataGridView1.Columns(i - 1).HeaderText
            Next
            For i As Integer = 0 To DataGridView1.Rows.Count

                For j As Integer = 0 To DataGridView1.Columns.Count
                    Excel.Cells(i + 2, j + 1) = DataGridView1.Rows(i).Cells(j).Value.ToString()
                Next
            Next
            workBook.SaveAs(fileName)
            workBook.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, resource.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return False
        End Try
    End Function
    Public Function CreateTextFile(ByVal fileName As String) As Boolean
        Try
            Dim writer As TextWriter = New StreamWriter(fileName)
            writer.Write("Details of Customers")
            writer.WriteLine()
            For i As Integer = 0 To DataGridView1.Columns.Count - 1
                writer.Write(vbTab & DataGridView1.Columns(i).HeaderText & vbTab & vbTab & "|")
            Next
            writer.WriteLine()
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                For j As Integer = 0 To DataGridView1.Columns.Count
                    writer.Write(vbTab & vbTab & DataGridView1.Rows(i).Cells(j).Value.ToString() & vbTab & vbTab & vbTab & "|")
                Next
                writer.WriteLine()
            Next
            writer.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, resource.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return False
        End Try
    End Function
    Public Function AddHeader(ByVal title As String) As Paragraph
        Dim headingFont As iTextSharp.text.Font = New iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 30, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim head As Paragraph = New Paragraph(title.ToUpper(), headingFont)
        head.Alignment = Element.ALIGN_CENTER
        head.SpacingAfter = 20
        Return head
    End Function
End Class
