using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CategoryHierarchy
{
    public partial class Category_Hierarchy : Form
    {
        public Category_Hierarchy()
        {
            InitializeComponent();
            PopulateData();
            SetColumns();
        }
        DataTable table = new DataTable();
        int rowCount = 1;
        public void PopulateData()
        {
            treeView1.Nodes.Clear();
            SqlCommand parameter = new SqlCommand();
            int c = 0;
            parameter.CommandType = CommandType.StoredProcedure;
            parameter.Parameters.AddWithValue("ParentId", SqlDbType.Int).Value = c;
            DataTable resultTable = Database.ExecuteStoredProcedure("GetData", parameter);
            BindTreeview(resultTable, 0, null);
            treeView1.SelectedNode = null;
        }
        public void BindTreeview(DataTable dtParent, int parentId, TreeNode treeNode)
        {
            foreach (DataRow row in dtParent.Rows)
            {
                TreeNode child = new TreeNode
                {
                    Text = row["String"].ToString(),
                    Tag = row["ID"].ToString()
                };
                if (parentId == 0)
                {
                    treeView1.Nodes.Add(child);
                }
                else
                {
                    treeNode.Nodes.Add(child);
                }
                int id = Convert.ToInt32(row["ID"]);
                SqlCommand parameter = new SqlCommand();
                parameter.CommandType = CommandType.StoredProcedure;
                parameter.Parameters.AddWithValue("ParentId", SqlDbType.Int).Value = id;
                DataTable dtChild = Database.ExecuteStoredProcedure("GetData", parameter);
                if (dtChild.Rows.Count == 0)
                    continue;
                else
                    BindTreeview(dtChild, id, child);
            }
        }
        public void AddNode()
        {
            var tag = treeView1.SelectedNode.Tag;
            int id = Convert.ToInt32(tag);
            if (LevelCheck(id))
            {
                TreeNode child = new TreeNode("NewNode");
                treeView1.SelectedNode.Nodes.Add(child);
                treeView1.SelectedNode.Expand();
                treeView1.LabelEdit = true;
                DataRow dr = table.NewRow();
                dr["SNo"] = rowCount;
                dr["ID"] = id;
                dr["String"] = child.Text;
                dr["Operation"] = "A";
                table.Rows.Add(dr);
                rowCount++;
            }
            else
            {
                MessageBox.Show("Cannot be added, It is 6-Level hirerchary", "Added Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        public void DeleteNode(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                int id = Convert.ToInt32(row["ID"]);
                DataRow dr = table.NewRow();
                dr["SNo"] = rowCount;
                dr["ID"] = id;
                dr["String"] = string.Empty;
                dr["Operation"] = "D";
                table.Rows.Add(dr);
                rowCount++;
                SqlCommand parameter = new SqlCommand();
                parameter.CommandType = CommandType.StoredProcedure;
                parameter.Parameters.AddWithValue("ParentId", SqlDbType.Int).Value = id;
                DataTable dtChild = Database.ExecuteStoredProcedure("GetData",parameter);
                if (dtChild.Rows.Count == 0)
                    continue;
                else
                    DeleteNode(dtChild);
            }
        }
        public void Selected()
        {
            var v = treeView1.SelectedNode.Tag;
            string query = "select * from FST_STRING where ID ='" + v + "'";
            DataTable resultTable = Database.ExecuteQuery(query);
            DeleteNode(resultTable);
            treeView1.SelectedNode.Remove();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selected();
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNode();
        }
        public bool LevelCheck(int ID)
        {
            int id = ID;
            int level = 0;
            while(id != 0)
            {
                level++;
                string query = "select ParentID from FST_HIERARCHY where ID = '" + id + "'";
                DataTable resultTable = Database.ExecuteQuery(query);
                id = Convert.ToInt32(resultTable.Rows[0][0]);
            }
            if(level < 6)
            {
                return true;
            }
            return false;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditNode();
        }
        public void EditNode()
        {
            treeView1.LabelEdit = true;
            var tag = treeView1.SelectedNode.Tag;
            int id = Convert.ToInt32(tag);
            DataRow dr = table.NewRow();
            dr["SNo"] = rowCount;
            dr["ID"] = id;
            dr["String"] = treeView1.SelectedNode.Name;
            dr["Operation"] = "E";
            table.Rows.Add(dr);
            rowCount++;

        }
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ImageIndex = 1;
        }

        private void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ImageIndex = 0;
        }
        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            this.BeginInvoke(new Action(() => afterAfterEdit(e.Node)));
        }
        private void afterAfterEdit(TreeNode node)
        {
            string txt = node.Text;
            var l = table.Rows.Count;
            table.Rows[l - 1][2] = txt;
        }
        public void SetColumns()
        {
            table.Columns.Add("SNo");
            table.Columns.Add("ID");
            table.Columns.Add("String");
            table.Columns.Add("Operation");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
            PopulateData();
        }
        public void SaveChanges()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@datatable", SqlDbType.Structured).Value = table;
            var res = Database.ExecuteStoredProcedure("AddDeleteEdit_Data", cmd);
            if (res != null && res.Rows.Count > 0)
            {
                bool saved = Convert.ToBoolean(res.Rows[0][0]);
                if (saved)
                {
                    MessageBox.Show("Saved Successfully", "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else
                {
                    MessageBox.Show("Cannot be saved! try again", "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public void Reset()
        {
            PopulateData();
            treeView1.LabelEdit = false;
            table.Rows.Clear();
            rowCount = 1;
        }
        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            treeView1.SelectedNode = null;
        }
    }
}
