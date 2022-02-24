using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EmployeeDashboard
{
    public partial class EmployeeDashboard : Form
    {
        public EmployeeDashboard()
        {

            if (!Database.IsValidConnection())
                return;
            InitializeComponent();
            DisplayRecords();
        }

        private bool ValidateInput()
        {
            bool insertEmployee = true;
            if (txtAddress.Text == "" || txtBloodgroup.Text == "" || txtContact.Text == "" || txtDOB.Text == "" || txtFirstname.Text == "" || txtLastname.Text == "" || (radioBtnMale.Checked == false && radioBtnFemale.Checked == false))
            {
                MessageBox.Show("Some fields are empty and requires user input", "UserInput Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                insertEmployee = false;
            }
            if ((txtContact.Text).Length != 10)
            {
                MessageBox.Show("Invalid Phone Number", "Contact Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Emp Id:" + empId + " is created", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Record cannot be Inserted, Try again Later!", "EmployeeData Insertion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            DisplayRecords();
        }

        private void UpdateEmployee()
        {
            var empId = txtEmpId.Text;
            SqlCommand sq = getList();
            sq.Parameters.AddWithValue("@EmployeeId", SqlDbType.VarChar).Value = txtEmpId.Text;
            DataTable resultTable = Database.ExecuteStoredProcedure("Employee_Update", sq);
            if (resultTable != null && resultTable.Rows.Count > 0)
            {
                bool employeeUpdated = Convert.ToBoolean(resultTable.Rows[0][0]);
                if (employeeUpdated)
                {
                    MessageBox.Show("Employee: " + empId + " Data is Updated", "EmployeeData Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Record cannot be Updated, Try again Later!", "EmployeeData Updated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            DisplayRecords();
        }

        private void DeleteEmployee()
        {
            DialogResult res = MessageBox.Show("Do you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (res == DialogResult.Yes)
            {
                var empId = txtEmpId.Text;
                SqlCommand para = new SqlCommand();
                para.CommandType = CommandType.StoredProcedure;
                para.Parameters.AddWithValue("@EmployeeID", SqlDbType.VarChar).Value = txtEmpId.Text;
                DataTable resultTable = Database.ExecuteStoredProcedure("Employee_Delete", para);
                if (resultTable != null && resultTable.Rows.Count > 0)
                {
                    bool employeeDeleted = Convert.ToBoolean(resultTable.Rows[0][0]);
                    if (employeeDeleted)
                    {
                        MessageBox.Show("Employee: " + empId + " Data is Deleted", "EmployeeData Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Record cannot be deleted, Try again Later!", "EmployeeData Deleted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            DisplayRecords();
        }
        public void DisplayRecords()
        {
            DataTable resultTable = Database.ExecuteStoredProcedure("Employee_Display");
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
                if(row.Cells["Gender"].Value.ToString() == "Male")
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to quit?", "Close Application", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
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
            if(!(Int64.TryParse(txtContact.Text, out output))){
                MessageBox.Show("Invalid Phone Number", "Contact Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
