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
        enum HierarchyType
        {
            CATEGORY=6,
            STORE=4,
            PRODUCT=3
        }
        public Category_Hierarchy()
        {
            InitializeComponent();
            PopulateRootNodes();
            comboBox1.Text = "CATEGORY";
        }
        DataTable table = new DataTable(); 
        string HierType = "CATEGORY";
        int LevelCount = 6;
        int CUR_ID = -1;
        int Count = 1;
        List<int> List = new List<int>();
        public  void GetHierachyData()
        {
            SqlCommand parameter = new SqlCommand();
            parameter.CommandType = CommandType.StoredProcedure;
            parameter.Parameters.AddWithValue("HierType", SqlDbType.NVarChar).Value = HierType;
            DataSet resultsDS = Database.ExecuteStoredProcedure("GetData", parameter);
            table = resultsDS.Tables[0];
            CUR_ID = Convert.ToInt32(resultsDS.Tables[1].Rows[0][0]);
        }
        public void PopulateRootNodes()
        {
            treeViewHierarchyEditor.Nodes.Clear();
            GetHierachyData();
            foreach (DataRow row in table.Rows)
            {
                if(Convert.ToInt32(row["ParentID"]) == 0)
                {
                    int id = Convert.ToInt32(row["ID"]);
                    TreeNode child = new TreeNode
                    {
                        Text = row["String"].ToString(),
                        Tag = row["ID"].ToString()
                    };
                    treeViewHierarchyEditor.Nodes.Add(child);
                    PopulateChildNodes(table, id, child);
                }
            }
        }
        public void PopulateChildNodes(DataTable dtParent, int parentId, TreeNode treeNode)
        {
            foreach (DataRow row in dtParent.Rows)
            {
                int id = Convert.ToInt32(row["ID"]);
                 if (row["ParentID"].ToString() == parentId.ToString())
                 {
                     TreeNode child = new TreeNode
                     {
                         Text = row["String"].ToString(),
                         Tag = row["ID"].ToString()
                     };
                     treeNode.Nodes.Add(child);
                     PopulateChildNodes(dtParent, id, child);
                }
            }
        }
        public void AddNode()
        {
            CUR_ID++;
            var tag = treeViewHierarchyEditor.SelectedNode.Tag;
            int id = Convert.ToInt32(tag);
            TreeNode child = new TreeNode
            {
                Text = "NewNode" + Count.ToString(),
                Tag = CUR_ID.ToString()
            };
            treeViewHierarchyEditor.SelectedNode.Nodes.Add(child);
            treeViewHierarchyEditor.SelectedNode.Expand();
            treeViewHierarchyEditor.LabelEdit = true;
            DataRow dr = table.NewRow();
            dr["ID"] = CUR_ID;
            dr["String"] = child.Text;
            dr["ParentID"] = id;
            dr["ACTION"] = "A";
            table.Rows.Add(dr);
            Count++;
        }
        public void DeleteNode(int id)
        {
            int c = 0;
            foreach (DataRow dataRow in table.Rows)
            {
                if (Convert.ToInt32(dataRow["ID"]) == id)
                    if(dataRow["ACTION"].ToString() == "A")
                    {
                        RemoveRows(Convert.ToInt32(dataRow["ID"]));
                        return;

                    }
                    else
                        dataRow["ACTION"] = "D";
            }
            foreach (DataRow dataRow in table.Rows)
            {
                if (dataRow["ParentID"].ToString() == id.ToString())
                {
                    DeleteNode(Convert.ToInt32(dataRow["ID"]));
                    c++;
                }
            }
            if (c == 0)
               return;
        }
        public void RemoveRows(int pid)
        {
            List.Add(pid);
            int id;
            int c = 0;
            foreach (DataRow row in table.Rows)
            {
                id = Convert.ToInt32(row["ID"]);
                if ((row["ACTION"].ToString()) == "A" && Convert.ToInt32(row["ParentID"]) == pid)
                {
                    RemoveRows(id);
                    c++;
                }
            }
            if (c == 0)
                return;
        }
        public void Selected()
        {
            int id = Convert.ToInt32(treeViewHierarchyEditor.SelectedNode.Tag);
            TreeNode treeNode = treeViewHierarchyEditor.SelectedNode;
            if (treeNode.GetNodeCount(true) == 0)
            {
                treeViewHierarchyEditor.SelectedNode.Remove();
                int c = 0;
                foreach(DataRow row in table.Rows)
                {
                    if (Convert.ToInt32(row["ID"]) == id && (row["ACTION"].ToString()) == "A")
                    {
                        List.Add(id);
                        c++;
                        break;
                    }
                }
                if (c == 0)
                {
                    foreach(DataRow dataRow in table.Rows)
                    {
                        if (Convert.ToInt32(dataRow["ID"]) == id)
                            dataRow["ACTION"] = "D";
                    }
                }
            }
            else
            {
                DialogResult res = MessageBox.Show("The selected node is not a leaf node and has children. Are you sure you want delete?", "Cannot be deleted", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(res == DialogResult.Yes)
                {
                    treeViewHierarchyEditor.SelectedNode.Remove();
                    int c = 0;
                    foreach (DataRow row in table.Rows)
                    {
                        if (Convert.ToInt32(row["ID"]) == id && (row["ACTION"].ToString()) == "A")
                        {
                            RemoveRows(id);
                            c++;
                            break;
                        }
                    }
                    if (c == 0)
                    {
                        DeleteNode(id);
                    }
                }
            }
            RemoveID();
        }
        public void RemoveID()
        {
            foreach(int n in List)
            {
                foreach (DataRow dr in table.Rows)
                {
                    if (Convert.ToInt32(dr["ID"]) == n)
                    {
                        table.Rows.Remove(dr);
                        break;
                    }
                }
            }
            ResetID();
        }
        public void ResetID()
        {
            int c = 0;
            List.Sort();
            for (var i = 0; i < List.Count; i++)
            {
                foreach (DataRow dr in table.Rows)
                {
                    if (Convert.ToInt32(dr["ID"]) > List[i] && dr["ACTION"].ToString() == "A")
                    {
                        int id = Convert.ToInt32(dr["ID"]);
                        dr["ID"] = List[i];
                        SetPID(id, List[i]);
                        List.RemoveAt(i);
                        List.Add(id);
                        ResetID();
                        c++;
                    }

                }
                if (c == 0)
                   return;
            }
        }
        public void SetPID(int oldId, int newId)
        {
            foreach (DataRow dr in table.Rows)
            {
                if (dr["ACTION"].ToString() == "A" && Convert.ToInt32(dr["ParentID"]) == oldId)
                {
                    dr["ParentID"] = newId;
                }
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selected();
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNode();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditNode();
        }
        public void EditNode()
        {
            treeViewHierarchyEditor.LabelEdit = true;
            var tag = treeViewHierarchyEditor.SelectedNode.Tag;
            int id = Convert.ToInt32(tag);
            DataRow dr = table.NewRow();
            dr["ID"] = id;
            dr["String"] = treeViewHierarchyEditor.SelectedNode.Name;
            dr["ACTION"] = "E";
            table.Rows.Add(dr);
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
            var n = table.Rows.Count;
            table.Rows[n - 1]["String"] = txt;
            treeViewHierarchyEditor.LabelEdit = false;
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
            PopulateRootNodes();
        }
        public void SaveChanges()
        {
            DataRow[] result = table.Select("[ACTION] <> ''");
            DataTable data = result.CopyToDataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@datatable", SqlDbType.Structured).Value = data;
            cmd.Parameters.AddWithValue("@Hiertype", SqlDbType.NVarChar).Value = HierType;
            var dataSet = Database.ExecuteStoredProcedure("AddDeleteEdit_Data", cmd);
            var res = dataSet.Tables[0];
            if (res != null && res.Rows.Count > 0)
            {
                bool saved = Convert.ToBoolean(res.Rows[0]["val"]);
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
            PopulateRootNodes();
            treeViewHierarchyEditor.LabelEdit = false;
            LevelCount = Convert.ToInt32(Enum.Parse(typeof(HierarchyType), HierType));
            lblLevel.Text = $"( { LevelCount } -Level Hierarchy)";
            Count = 1;
            List.Clear();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRow[] result = table.Select("[ACTION] <> ''");
            if (result.Length > 0)
            {
                DialogResult res = MessageBox.Show("There are some unchanged changes in " +
                    HierType + " hierarchy. Do you want save changes?", "Save changes", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (res == DialogResult.Yes)
                {
                    SaveChanges();
                }
            }
            HierType = comboBox1.Text;
            Reset();
        }
        void treeViewHierarchyEditor_AfterSelect(object sender, TreeViewEventArgs e)
        {
            popUpMenu.Items["addToolStripMenuItem"].Enabled = (treeViewHierarchyEditor.SelectedNode.Level + 1) < LevelCount;
        }

    }
}
