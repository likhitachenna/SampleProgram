<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.lblHead = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtBloodgroup = New System.Windows.Forms.ComboBox()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.radioBtnFemale = New System.Windows.Forms.RadioButton()
        Me.radioBtnMale = New System.Windows.Forms.RadioButton()
        Me.txtAddress = New System.Windows.Forms.RichTextBox()
        Me.txtDOB = New System.Windows.Forms.DateTimePicker()
        Me.txtLastname = New System.Windows.Forms.TextBox()
        Me.txtFirstname = New System.Windows.Forms.TextBox()
        Me.txtEmpId = New System.Windows.Forms.Label()
        Me.lblBloodgroup = New System.Windows.Forms.Label()
        Me.lblContact = New System.Windows.Forms.Label()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblDOB = New System.Windows.Forms.Label()
        Me.lblLastname = New System.Windows.Forms.Label()
        Me.lblFirstname = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblEmpID = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.txtRefresh = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnAddToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnUpdateToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnDeleteToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCloseToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnRefreshToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnExportToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHead
        '
        Me.lblHead.AutoSize = True
        Me.lblHead.Font = New System.Drawing.Font("Rockwell", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHead.Location = New System.Drawing.Point(150, 9)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(727, 50)
        Me.lblHead.TabIndex = 0
        Me.lblHead.Text = "EMPLOYEE INFORMATION FORM"
        Me.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtBloodgroup)
        Me.Panel1.Controls.Add(Me.txtContact)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.txtAddress)
        Me.Panel1.Controls.Add(Me.txtDOB)
        Me.Panel1.Controls.Add(Me.txtLastname)
        Me.Panel1.Controls.Add(Me.txtFirstname)
        Me.Panel1.Controls.Add(Me.txtEmpId)
        Me.Panel1.Controls.Add(Me.lblBloodgroup)
        Me.Panel1.Controls.Add(Me.lblContact)
        Me.Panel1.Controls.Add(Me.lblGender)
        Me.Panel1.Controls.Add(Me.lblAddress)
        Me.Panel1.Controls.Add(Me.lblDOB)
        Me.Panel1.Controls.Add(Me.lblLastname)
        Me.Panel1.Controls.Add(Me.lblFirstname)
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Controls.Add(Me.lblEmpID)
        Me.Panel1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(34, 62)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(959, 548)
        Me.Panel1.TabIndex = 1
        '
        'txtBloodgroup
        '
        Me.txtBloodgroup.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBloodgroup.FormattingEnabled = True
        Me.txtBloodgroup.Items.AddRange(New Object() {"a+", "a-", "b+", "b-", "ab+", "ab-", "o+", "o-"})
        Me.txtBloodgroup.Location = New System.Drawing.Point(22, 512)
        Me.txtBloodgroup.Name = "txtBloodgroup"
        Me.txtBloodgroup.Size = New System.Drawing.Size(624, 25)
        Me.txtBloodgroup.TabIndex = 16
        '
        'txtContact
        '
        Me.txtContact.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContact.Location = New System.Drawing.Point(21, 451)
        Me.txtContact.Multiline = True
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(624, 22)
        Me.txtContact.TabIndex = 15
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radioBtnFemale)
        Me.GroupBox1.Controls.Add(Me.radioBtnMale)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 369)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(626, 39)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'radioBtnFemale
        '
        Me.radioBtnFemale.AutoSize = True
        Me.radioBtnFemale.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radioBtnFemale.Location = New System.Drawing.Point(134, 12)
        Me.radioBtnFemale.Name = "radioBtnFemale"
        Me.radioBtnFemale.Size = New System.Drawing.Size(72, 21)
        Me.radioBtnFemale.TabIndex = 16
        Me.radioBtnFemale.TabStop = True
        Me.radioBtnFemale.Text = "Female"
        Me.radioBtnFemale.UseVisualStyleBackColor = True
        '
        'radioBtnMale
        '
        Me.radioBtnMale.AutoSize = True
        Me.radioBtnMale.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radioBtnMale.Location = New System.Drawing.Point(11, 12)
        Me.radioBtnMale.Name = "radioBtnMale"
        Me.radioBtnMale.Size = New System.Drawing.Size(59, 21)
        Me.radioBtnMale.TabIndex = 15
        Me.radioBtnMale.TabStop = True
        Me.radioBtnMale.Text = "Male"
        Me.radioBtnMale.UseVisualStyleBackColor = True
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(22, 240)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(626, 91)
        Me.txtAddress.TabIndex = 13
        Me.txtAddress.Text = ""
        '
        'txtDOB
        '
        Me.txtDOB.CalendarFont = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDOB.CustomFormat = "yyyy-MM-dd"
        Me.txtDOB.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtDOB.Location = New System.Drawing.Point(22, 168)
        Me.txtDOB.Name = "txtDOB"
        Me.txtDOB.Size = New System.Drawing.Size(625, 27)
        Me.txtDOB.TabIndex = 12
        '
        'txtLastname
        '
        Me.txtLastname.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastname.Location = New System.Drawing.Point(521, 81)
        Me.txtLastname.Multiline = True
        Me.txtLastname.Name = "txtLastname"
        Me.txtLastname.Size = New System.Drawing.Size(411, 22)
        Me.txtLastname.TabIndex = 11
        '
        'txtFirstname
        '
        Me.txtFirstname.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstname.Location = New System.Drawing.Point(22, 81)
        Me.txtFirstname.Multiline = True
        Me.txtFirstname.Name = "txtFirstname"
        Me.txtFirstname.Size = New System.Drawing.Size(411, 22)
        Me.txtFirstname.TabIndex = 10
        '
        'txtEmpId
        '
        Me.txtEmpId.AutoSize = True
        Me.txtEmpId.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpId.Location = New System.Drawing.Point(199, 2)
        Me.txtEmpId.Name = "txtEmpId"
        Me.txtEmpId.Size = New System.Drawing.Size(105, 35)
        Me.txtEmpId.TabIndex = 9
        Me.txtEmpId.Text = "EmpId"
        '
        'lblBloodgroup
        '
        Me.lblBloodgroup.AutoSize = True
        Me.lblBloodgroup.Location = New System.Drawing.Point(17, 486)
        Me.lblBloodgroup.Name = "lblBloodgroup"
        Me.lblBloodgroup.Size = New System.Drawing.Size(110, 22)
        Me.lblBloodgroup.TabIndex = 8
        Me.lblBloodgroup.Text = "Bloodgroup:"
        '
        'lblContact
        '
        Me.lblContact.AutoSize = True
        Me.lblContact.Location = New System.Drawing.Point(18, 429)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(76, 22)
        Me.lblContact.TabIndex = 7
        Me.lblContact.Text = "Contact:"
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Location = New System.Drawing.Point(18, 350)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(74, 22)
        Me.lblGender.TabIndex = 6
        Me.lblGender.Text = "Gender:"
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(18, 215)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(82, 22)
        Me.lblAddress.TabIndex = 5
        Me.lblAddress.Text = "Address:"
        '
        'lblDOB
        '
        Me.lblDOB.AutoSize = True
        Me.lblDOB.Location = New System.Drawing.Point(18, 142)
        Me.lblDOB.Name = "lblDOB"
        Me.lblDOB.Size = New System.Drawing.Size(57, 22)
        Me.lblDOB.TabIndex = 4
        Me.lblDOB.Text = "DOB:"
        '
        'lblLastname
        '
        Me.lblLastname.AutoSize = True
        Me.lblLastname.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastname.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblLastname.Location = New System.Drawing.Point(517, 106)
        Me.lblLastname.Name = "lblLastname"
        Me.lblLastname.Size = New System.Drawing.Size(70, 17)
        Me.lblLastname.TabIndex = 3
        Me.lblLastname.Text = "LastName"
        '
        'lblFirstname
        '
        Me.lblFirstname.AutoSize = True
        Me.lblFirstname.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstname.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblFirstname.Location = New System.Drawing.Point(18, 106)
        Me.lblFirstname.Name = "lblFirstname"
        Me.lblFirstname.Size = New System.Drawing.Size(70, 17)
        Me.lblFirstname.TabIndex = 2
        Me.lblFirstname.Text = "FirstName"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(18, 55)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(62, 22)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Name:"
        '
        'lblEmpID
        '
        Me.lblEmpID.AutoSize = True
        Me.lblEmpID.Location = New System.Drawing.Point(18, 13)
        Me.lblEmpID.Name = "lblEmpID"
        Me.lblEmpID.Size = New System.Drawing.Size(115, 22)
        Me.lblEmpID.TabIndex = 0
        Me.lblEmpID.Text = "EmployeeID:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(34, 616)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(959, 162)
        Me.DataGridView1.TabIndex = 2
        '
        'btnInsert
        '
        Me.btnInsert.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInsert.Location = New System.Drawing.Point(532, 784)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(111, 57)
        Me.btnInsert.TabIndex = 3
        Me.btnInsert.Text = "Add"
        Me.btnAddToolTip.SetToolTip(Me.btnInsert, ".")
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(883, 782)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(111, 57)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnCloseToolTip.SetToolTip(Me.btnClose, ".")
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(766, 784)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(111, 57)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Delete"
        Me.btnDeleteToolTip.SetToolTip(Me.btnDelete, ".")
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(649, 784)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(111, 57)
        Me.btnUpdate.TabIndex = 6
        Me.btnUpdate.Text = "Update"
        Me.btnUpdateToolTip.SetToolTip(Me.btnUpdate, ".")
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'txtRefresh
        '
        Me.txtRefresh.Image = CType(resources.GetObject("txtRefresh.Image"), System.Drawing.Image)
        Me.txtRefresh.Location = New System.Drawing.Point(34, 782)
        Me.txtRefresh.Name = "txtRefresh"
        Me.txtRefresh.Size = New System.Drawing.Size(66, 57)
        Me.txtRefresh.TabIndex = 7
        Me.btnRefreshToolTip.SetToolTip(Me.txtRefresh, ".")
        Me.txtRefresh.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.Location = New System.Drawing.Point(106, 782)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(66, 57)
        Me.btnExport.TabIndex = 8
        Me.btnExportToolTip.SetToolTip(Me.btnExport, ".")
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1026, 851)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.txtRefresh)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnInsert)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblHead)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHead As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtContact As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents radioBtnFemale As RadioButton
    Friend WithEvents radioBtnMale As RadioButton
    Friend WithEvents txtAddress As RichTextBox
    Friend WithEvents txtDOB As DateTimePicker
    Friend WithEvents txtLastname As TextBox
    Friend WithEvents txtFirstname As TextBox
    Friend WithEvents txtEmpId As Label
    Friend WithEvents lblBloodgroup As Label
    Friend WithEvents lblContact As Label
    Friend WithEvents lblGender As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents lblDOB As Label
    Friend WithEvents lblLastname As Label
    Friend WithEvents lblFirstname As Label
    Friend WithEvents lblName As Label
    Friend WithEvents lblEmpID As Label
    Friend WithEvents txtBloodgroup As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnInsert As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents txtRefresh As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents btnAddToolTip As ToolTip
    Friend WithEvents btnCloseToolTip As ToolTip
    Friend WithEvents btnDeleteToolTip As ToolTip
    Friend WithEvents btnUpdateToolTip As ToolTip
    Friend WithEvents btnRefreshToolTip As ToolTip
    Friend WithEvents btnExportToolTip As ToolTip
End Class
