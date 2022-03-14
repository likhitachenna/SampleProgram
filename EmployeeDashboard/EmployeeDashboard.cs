using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using resource = EmployeeDashboard.Properties.Resources;
using System.Threading;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace EmployeeDashboard
{
    public partial class EmployeeDashboard : Form
    {
        public EmployeeDashboard()
        {
            if (!Database.IsValidConnection())
                return;
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
            DisplayRecords();
            setLanguage();
        }

        private bool ValidateInput()
        {
            bool insertEmployee = true;
            if (txtAddress.Text == "" || txtBloodgroup.Text == "" || txtContact.Text == "" || txtDOB.Text == "" || txtFirstname.Text == "" || txtLastname.Text == "" || (radioBtnMale.Checked == false && radioBtnFemale.Checked == false))
            {
                MessageBox.Show(resource.MSG_INPUTERROR, resource.MSG_INPUT, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                insertEmployee = false;
            }
            if ((txtContact.Text).Length != 10)
            {
                MessageBox.Show(resource.MSG_INVALIDPHNO, resource.MSG_INVALDERROR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                insertEmployee = false;
            }
            return insertEmployee;
        }
        private void InsertEmployee()
        {
            if (!ValidateInput())
                return;
            SqlCommand sq = getList();
            var res = Database.ExecuteStoredProcedure("Employee_Insert", sq);
            int empId;
            if (res != null && res.Rows.Count > 0)
            {
                empId = Convert.ToInt32(res.Rows[0][0]);
                if (empId > 0)
                {
                    MessageBox.Show(resource.TXT_LBLEMPID + empId + " " + resource.MSG_INSERT, resource.MSG_INSERTHEAD, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(resource.MSG_INSERTERROR, resource.MSG_INSERTHEAD, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            DisplayRecords();
        }

        private void UpdateEmployee()
        {
            var empId = txtEmpId.Text;
            SqlCommand sq = getList();
            sq.Parameters.AddWithValue("@EmployeeId", SqlDbType.VarChar).Value = txtEmpId.Text;
            System.Data.DataTable resultTable = Database.ExecuteStoredProcedure("Employee_Update", sq);
            if (resultTable != null && resultTable.Rows.Count > 0)
            {
                bool employeeUpdated = Convert.ToBoolean(resultTable.Rows[0][0]);
                if (employeeUpdated)
                {
                    MessageBox.Show(resource.TXT_LBLEMPID+ empId + " " + resource.MSG_UPDATE, resource.MSG_UPDATEHEAD, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(resource.MSG_UPDATEERROR, resource.MSG_UPDATEHEAD, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            DisplayRecords();
        }

        private void DeleteEmployee()
        {
            DialogResult res = MessageBox.Show(resource.MSG_DELETEERR, resource.MSG_DELETEHEAD, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (res == DialogResult.Yes)
            {
                var empId = txtEmpId.Text;
                SqlCommand para = new SqlCommand();
                para.CommandType = CommandType.StoredProcedure;
                para.Parameters.AddWithValue("@EmployeeID", SqlDbType.VarChar).Value = txtEmpId.Text;
                System.Data.DataTable resultTable = Database.ExecuteStoredProcedure("Employee_Delete", para);
                if (resultTable != null && resultTable.Rows.Count > 0)
                {
                    bool employeeDeleted = Convert.ToBoolean(resultTable.Rows[0][0]);
                    if (employeeDeleted)
                    {
                        MessageBox.Show(resource.TXT_LBLEMPID + empId + " " + resource.MSG_DELETE, resource.MSG_DELETEHEAD, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(resource.MSG_DELETEERROR, resource.MSG_DELETEHEAD, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            DisplayRecords();
        }
        public void DisplayRecords()
        {
            System.Data.DataTable resultTable = Database.ExecuteStoredProcedure("Employee_Display");
            dataGridView1.DataSource = resultTable;
            Reset();
        }
        private void Refresh_click(object sender, EventArgs e)
        {
            DisplayRecords();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtEmpId.Text = row.Cells["EmployeeId"].Value.ToString();
                txtFirstname.Text = row.Cells["FirstName"].Value.ToString();
                txtLastname.Text = row.Cells["LastName"].Value.ToString();
                txtDOB.Text = row.Cells["DOB"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtBloodgroup.Text = row.Cells["Bloodgroup"].Value.ToString();
                txtContact.Text = row.Cells["Contact"].Value.ToString();
                if (row.Cells["Gender"].Value.ToString() == "Male")
                    radioBtnMale.Checked = true;
                else
                    radioBtnFemale.Checked = true;
            }
        }
        public SqlCommand getList()
        {
            try
            {
                var gender = radioBtnMale.Checked ? "M" : "F";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = txtFirstname.Text;
                cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = txtLastname.Text;
                cmd.Parameters.AddWithValue("@DOB", SqlDbType.Date).Value = txtDOB.Text;
                cmd.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = txtAddress.Text;
                cmd.Parameters.AddWithValue("@Bloodgroup", SqlDbType.VarChar).Value = txtBloodgroup.Text; ;
                cmd.Parameters.AddWithValue("@Contact", SqlDbType.BigInt).Value = Convert.ToInt64(txtContact.Text);
                cmd.Parameters.AddWithValue("@Gender", SqlDbType.VarChar).Value = gender;
                return cmd;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, resource.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(resource.MSG_EXIST, resource.MSG_EXISTHEAD, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (res == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }
        public void Reset()
        {
            txtAddress.Clear();
            txtBloodgroup.Text = string.Empty;
            txtDOB.MaxDate = DateTime.Today;
            txtDOB.Value = DateTime.Today;
            txtContact.Clear();
            txtEmpId.ResetText();
            txtFirstname.Clear();
            txtLastname.Clear();
            radioBtnMale.Checked = true;
            radioBtnFemale.Checked = false;
            txtEmpId.Text = resource.TXT_EMPID;
           
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertEmployee();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateEmployee();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteEmployee();
        }

        private void txtContact_Leave(object sender, EventArgs e)
        {
            long output;
            if (!(Int64.TryParse(txtContact.Text, out output))) {
                MessageBox.Show(resource.MSG_INVALIDPHNO, resource.MSG_INVALDERROR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public void setLanguage()
        {
            lblName.Text = resource.TXT_LBLNAME;
            lblFirstname.Text = resource.TXT_LBLFNAME;
            lblLastname.Text = resource.TXT_LBLLNAME;
            lblEmpID.Text = resource.TXT_LBLEMPID;
            lblDOB.Text = resource.TXT_LBLDOB;
            lblAddress.Text = resource.TXT_LBLADDRESS;
            lblGender.Text = resource.TXT_LBLGENDER;
            lblContact.Text = resource.TXT_LBLCONTACT;
            lblBloodgroup.Text = resource.TXT_LBLBLOODGROUP;
            lblHead.Text = resource.TXT_LBLHEAD;
            radioBtnFemale.Text = resource.TXT_RBTNFEMALE;
            radioBtnMale.Text = resource.TXT_RBTNMALE;
            btnInsert.Text = resource.TXT_INSERTBTN;
            btnDelete.Text = resource.TXT_DELETEBTN;
            btnClose.Text = resource.TXT_CLOSEBTN;
            btnUpdate.Text = resource.TXT_UPDATEBTN;
            btnRefreshToolTip.ToolTipTitle = resource.TXT_REFRESHBTN;
            txtEmpId.Text = resource.TXT_EMPID;
            btnAddToolTip.ToolTipTitle = resource.TXT_INSERTTOOLTIP;
            btnUpdateToolTip.ToolTipTitle = resource.TXT_UPDATETOOLTIP;
            btnDeleteToolTip.ToolTipTitle = resource.TXT_DELETETOOLTIP;
            btnCloseToolTip.ToolTipTitle = resource.TXT_CLOSETOOLTIP;
            btnExportToolTip.ToolTipTitle = resource.TXT_EXPORTTOOLTIP;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportData();
        }

        public void exportData()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "PDF |*.pdf|EXCEL |*.xlsx|TEXT |*.txt";
                saveFile.FileName = "Result.pdf";
                bool fileCreated = false;
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        switch (saveFile.FilterIndex)
                        {
                            case 1:
                                fileCreated = CreatePdf(saveFile.FileName);
                                break;
                            case 2:
                                fileCreated = CreateExcelSpreadSheet(saveFile.FileName);
                                break;
                            case 3:
                                fileCreated = CreateTextFile(saveFile.FileName);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message,resource.MSG_ERROR,MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                    if (fileCreated)
                        MessageBox.Show(saveFile.FileName+" "+resource.TXT_FILECREATION, resource.TXT_FILEHEAD, MessageBoxButtons.OK,MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show(resource.TXT_DATAERROR, resource.TXT_FILEHEAD,MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        public bool CreatePdf(string fileName)
        {
            try
            {
                PdfPTable pTable = new PdfPTable(dataGridView1.Columns.Count);
                pTable.WidthPercentage = 90;
                int c = 0;
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                    pTable.AddCell(pCell);
                }
                float[] widths = new float[] { 0.5f, 1.1f, 1.1f, 1.2f, 1.5f, 0.5f, 1.2f, 0.5f };
                pTable.SetWidths(widths);
                foreach (DataGridViewRow viewRow in dataGridView1.Rows)
                {
                    c = 0;
                    foreach (DataGridViewCell dcell in viewRow.Cells)
                    {
                        if (c == 3)
                        {
                            var d1 = Convert.ToDateTime(dcell.Value.ToString());
                            pTable.AddCell(d1.ToString("yyyy/MM/dd"));
                        }
                        else
                            pTable.AddCell(new Phrase(dcell.Value.ToString()));
                        c++;
                    }
                }
                using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
                {
                    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 20f, 20f, 20f,30f);
                    PdfWriter.GetInstance(document, fileStream);
                    string header = "details of employees";
                    document.Open();
                    document.Add(AddHeader(header));
                    document.Add(pTable);
                    document.Close();
                    fileStream.Close();
                }
                AddFooter(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, resource.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public bool CreateExcelSpreadSheet(string fileName)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                Workbook workBook = Excel.Workbooks.Add(Type.Missing);
                Worksheet workSheet = (Worksheet)workBook.ActiveSheet;
                Excel.Visible = false;
                int c = 0;
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    workSheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    c = 0;
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (c == 3)
                        {
                            var d1 = Convert.ToDateTime(dataGridView1.Rows[i].Cells[j].Value.ToString());
                            Excel.Cells[i + 2, j + 1] = d1.ToString("yyyy/MM/dd");
                        }
                        else
                            Excel.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        c++;
                    }
                }
                workBook.SaveAs(fileName);
                workBook.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, resource.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool CreateTextFile(string fileName)
        {
            try
            {
                TextWriter writer = new StreamWriter(fileName);
                writer.Write("Details of Customers");
                writer.WriteLine();
                int c = 0;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    writer.Write("\t" + dataGridView1.Columns[i].HeaderText + "\t" );
                }
                writer.WriteLine();
                for (int i = 0;i< dataGridView1.Rows.Count - 1; i++)
                {
                    c = 0;
                    for(int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (c == 3)
                        {
                            var d = Convert.ToDateTime(dataGridView1.Rows[i].Cells[j].Value.ToString());
                            writer.Write("\t" + d.ToString("yyyy/MM/dd") + "\t");
                        }
                        else
                            writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t"); ;
                        c++;
                    }
                    writer.WriteLine();    
                }
                writer.Close();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, resource.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public Paragraph AddHeader(string title)
        {
            iTextSharp.text.Font headingFont = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL,30, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            Paragraph head = new Paragraph(title.ToUpper(), headingFont);
            head.Alignment = Element.ALIGN_CENTER;
            head.SpacingAfter = 20;
            return head;
        }
        public void AddFooter(string fileName)
        {
            byte[] bytes = File.ReadAllBytes(fileName);
            using (MemoryStream stream = new MemoryStream())
            {
                PdfReader reader = new PdfReader(bytes);
                using (PdfStamper stamper = new PdfStamper(reader, stream))
                {
                    int pages = reader.NumberOfPages;
                    for (int i = 1; i <= pages; i++)
                    {
                        ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase(i.ToString()), 568f, 15f, 0);
                    }
                }
             bytes = stream.ToArray();
            }
            File.WriteAllBytes(fileName, bytes);
        }
    }
}
