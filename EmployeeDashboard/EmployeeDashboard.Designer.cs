namespace EmployeeDashboard
{
    partial class EmployeeDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeDashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtBloodgroup = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBtnMale = new System.Windows.Forms.RadioButton();
            this.radioBtnFemale = new System.Windows.Forms.RadioButton();
            this.lblName = new System.Windows.Forms.Label();
            this.txtEmpId = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.txtDOB = new System.Windows.Forms.DateTimePicker();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblBloodgroup = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.lblLastname = new System.Windows.Forms.Label();
            this.lblEmpID = new System.Windows.Forms.Label();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.lblFirstname = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.lblHead = new System.Windows.Forms.Label();
            this.btnRefreshToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnAddToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnUpdateToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnDeleteToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnCloseToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnExportToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnExport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.txtBloodgroup);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.txtEmpId);
            this.panel1.Controls.Add(this.lblGender);
            this.panel1.Controls.Add(this.txtDOB);
            this.panel1.Controls.Add(this.txtContact);
            this.panel1.Controls.Add(this.lblContact);
            this.panel1.Controls.Add(this.lblBloodgroup);
            this.panel1.Controls.Add(this.lblAddress);
            this.panel1.Controls.Add(this.lblDOB);
            this.panel1.Controls.Add(this.txtLastname);
            this.panel1.Controls.Add(this.lblLastname);
            this.panel1.Controls.Add(this.lblEmpID);
            this.panel1.Controls.Add(this.txtFirstname);
            this.panel1.Controls.Add(this.lblFirstname);
            this.panel1.Location = new System.Drawing.Point(10, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1039, 550);
            this.panel1.TabIndex = 4;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.Location = new System.Drawing.Point(24, 226);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(626, 91);
            this.txtAddress.TabIndex = 65;
            // 
            // txtBloodgroup
            // 
            this.txtBloodgroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBloodgroup.FormattingEnabled = true;
            this.txtBloodgroup.Items.AddRange(new object[] {
            "a+",
            "a-",
            "b+",
            "b-",
            "ab+",
            "ab-",
            "o+",
            "o-"});
            this.txtBloodgroup.Location = new System.Drawing.Point(24, 511);
            this.txtBloodgroup.Name = "txtBloodgroup";
            this.txtBloodgroup.Size = new System.Drawing.Size(624, 24);
            this.txtBloodgroup.TabIndex = 58;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioBtnMale);
            this.groupBox1.Controls.Add(this.radioBtnFemale);
            this.groupBox1.Location = new System.Drawing.Point(24, 360);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(626, 37);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            // 
            // radioBtnMale
            // 
            this.radioBtnMale.AutoSize = true;
            this.radioBtnMale.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnMale.Location = new System.Drawing.Point(11, 10);
            this.radioBtnMale.Name = "radioBtnMale";
            this.radioBtnMale.Size = new System.Drawing.Size(59, 21);
            this.radioBtnMale.TabIndex = 15;
            this.radioBtnMale.TabStop = true;
            this.radioBtnMale.Text = "Male";
            this.radioBtnMale.UseVisualStyleBackColor = true;
            this.radioBtnMale.UseWaitCursor = true;
            // 
            // radioBtnFemale
            // 
            this.radioBtnFemale.AutoSize = true;
            this.radioBtnFemale.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnFemale.Location = new System.Drawing.Point(183, 10);
            this.radioBtnFemale.Name = "radioBtnFemale";
            this.radioBtnFemale.Size = new System.Drawing.Size(72, 21);
            this.radioBtnFemale.TabIndex = 16;
            this.radioBtnFemale.TabStop = true;
            this.radioBtnFemale.Text = "Female";
            this.radioBtnFemale.UseVisualStyleBackColor = true;
            this.radioBtnFemale.UseWaitCursor = true;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(20, 51);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(62, 22);
            this.lblName.TabIndex = 72;
            this.lblName.Text = "Name:";
            this.lblName.UseWaitCursor = true;
            // 
            // txtEmpId
            // 
            this.txtEmpId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmpId.AutoSize = true;
            this.txtEmpId.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpId.Location = new System.Drawing.Point(197, 14);
            this.txtEmpId.Name = "txtEmpId";
            this.txtEmpId.Size = new System.Drawing.Size(85, 25);
            this.txtEmpId.TabIndex = 71;
            this.txtEmpId.Text = "EmpID";
            this.txtEmpId.UseWaitCursor = true;
            // 
            // lblGender
            // 
            this.lblGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(20, 335);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(74, 22);
            this.lblGender.TabIndex = 70;
            this.lblGender.Text = "Gender:";
            // 
            // txtDOB
            // 
            this.txtDOB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDOB.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDOB.CustomFormat = "yyyy-MM-dd";
            this.txtDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDOB.Location = new System.Drawing.Point(24, 157);
            this.txtDOB.MaxDate = new System.DateTime(2029, 12, 31, 0, 0, 0, 0);
            this.txtDOB.MinDate = new System.DateTime(1945, 1, 1, 0, 0, 0, 0);
            this.txtDOB.Name = "txtDOB";
            this.txtDOB.Size = new System.Drawing.Size(625, 27);
            this.txtDOB.TabIndex = 69;
            this.txtDOB.Value = new System.DateTime(2022, 2, 14, 0, 0, 0, 0);
            // 
            // txtContact
            // 
            this.txtContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContact.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContact.Location = new System.Drawing.Point(24, 442);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(624, 22);
            this.txtContact.TabIndex = 68;
            this.txtContact.Leave += new System.EventHandler(this.txtContact_Leave);
            // 
            // lblContact
            // 
            this.lblContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(20, 417);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(81, 22);
            this.lblContact.TabIndex = 67;
            this.lblContact.Text = "Contact :";
            // 
            // lblBloodgroup
            // 
            this.lblBloodgroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBloodgroup.AutoSize = true;
            this.lblBloodgroup.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBloodgroup.Location = new System.Drawing.Point(20, 486);
            this.lblBloodgroup.Name = "lblBloodgroup";
            this.lblBloodgroup.Size = new System.Drawing.Size(110, 22);
            this.lblBloodgroup.TabIndex = 66;
            this.lblBloodgroup.Text = "Bloodgroup:";
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(20, 201);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(82, 22);
            this.lblAddress.TabIndex = 64;
            this.lblAddress.Text = "Address:";
            // 
            // lblDOB
            // 
            this.lblDOB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDOB.AutoSize = true;
            this.lblDOB.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOB.Location = new System.Drawing.Point(20, 134);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(51, 20);
            this.lblDOB.TabIndex = 63;
            this.lblDOB.Text = "DOB:";
            // 
            // txtLastname
            // 
            this.txtLastname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLastname.Location = new System.Drawing.Point(557, 76);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(419, 22);
            this.txtLastname.TabIndex = 62;
            // 
            // lblLastname
            // 
            this.lblLastname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastname.AutoSize = true;
            this.lblLastname.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLastname.Location = new System.Drawing.Point(554, 101);
            this.lblLastname.Name = "lblLastname";
            this.lblLastname.Size = new System.Drawing.Size(69, 16);
            this.lblLastname.TabIndex = 61;
            this.lblLastname.Text = "LastName";
            this.lblLastname.UseWaitCursor = true;
            // 
            // lblEmpID
            // 
            this.lblEmpID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmpID.AutoSize = true;
            this.lblEmpID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpID.Location = new System.Drawing.Point(20, 17);
            this.lblEmpID.Name = "lblEmpID";
            this.lblEmpID.Size = new System.Drawing.Size(115, 22);
            this.lblEmpID.TabIndex = 60;
            this.lblEmpID.Text = "EmployeeID:";
            this.lblEmpID.UseWaitCursor = true;
            // 
            // txtFirstname
            // 
            this.txtFirstname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFirstname.Location = new System.Drawing.Point(24, 76);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(411, 22);
            this.txtFirstname.TabIndex = 59;
            // 
            // lblFirstname
            // 
            this.lblFirstname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFirstname.AutoSize = true;
            this.lblFirstname.BackColor = System.Drawing.SystemColors.Control;
            this.lblFirstname.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFirstname.Location = new System.Drawing.Point(24, 101);
            this.lblFirstname.Name = "lblFirstname";
            this.lblFirstname.Size = new System.Drawing.Size(69, 16);
            this.lblFirstname.TabIndex = 57;
            this.lblFirstname.Text = "FirstName";
            this.lblFirstname.UseWaitCursor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 613);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1039, 165);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(938, 784);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 57);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnCloseToolTip.SetToolTip(this.btnClose, ".");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(10, 784);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(66, 57);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefreshToolTip.SetToolTip(this.btnRefresh, ".");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.Refresh_click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(821, 784);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 57);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDeleteToolTip.SetToolTip(this.btnDelete, ".");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(704, 784);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(111, 57);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdateToolTip.SetToolTip(this.btnUpdate, ".");
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsert.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnInsert.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(587, 784);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(111, 57);
            this.btnInsert.TabIndex = 8;
            this.btnInsert.Text = "Add";
            this.btnAddToolTip.SetToolTip(this.btnInsert, ".");
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // lblHead
            // 
            this.lblHead.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHead.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead.Location = new System.Drawing.Point(227, 9);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(593, 41);
            this.lblHead.TabIndex = 22;
            this.lblHead.Text = "EMPLOYEE INFORMATION FORM";
            this.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHead.UseWaitCursor = true;
            // 
            // btnRefreshToolTip
            // 
            this.btnRefreshToolTip.ToolTipTitle = "Refresh";
            // 
            // btnAddToolTip
            // 
            this.btnAddToolTip.ToolTipTitle = "Add Employee";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.AutoSize = true;
            this.btnExport.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(82, 785);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(66, 57);
            this.btnExport.TabIndex = 24;
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportToolTip.SetToolTip(this.btnExport, ".");
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // EmployeeDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 853);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblHead);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EmployeeDashboard";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Dashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.ComboBox txtBloodgroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtnMale;
        private System.Windows.Forms.RadioButton radioBtnFemale;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label txtEmpId;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.DateTimePicker txtDOB;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblBloodgroup;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.Label lblLastname;
        private System.Windows.Forms.Label lblEmpID;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.Label lblFirstname;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label lblHead;
        private System.Windows.Forms.ToolTip btnRefreshToolTip;
        private System.Windows.Forms.ToolTip btnAddToolTip;
        private System.Windows.Forms.ToolTip btnCloseToolTip;
        private System.Windows.Forms.ToolTip btnDeleteToolTip;
        private System.Windows.Forms.ToolTip btnUpdateToolTip;
        private System.Windows.Forms.ToolTip btnExportToolTip;
        private System.Windows.Forms.Button btnExport;
    }
}

