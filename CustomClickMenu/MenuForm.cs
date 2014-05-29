using CustomClickMenu.App_Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomClickMenu
{
    public partial class MenuForm : Form
    {
        public MenuForm(IEnumerable<DataGridRow> parentRows, DataGridRow row) : this(parentRows)
        {
            if (row.MenuType == "Click")
                radioButton2.Checked = true;
            else
                radioButton1.Checked = true;
            if (!String.IsNullOrEmpty(row.RootId))
                comboBox1.SelectedValue = row.RootId;
            textBox1.Text = row.Title;
            textBox2.Text = row.Key;
            textBox3.Text = row.Url;
            RowId = row.Id;
        }

        private string RowId { get; set; }

        public MenuForm(IEnumerable<DataGridRow> parentRows)
            : this()
        {
            ParentRows = parentRows;
            BindParentData();
            CheckBoxCheckChanged();
        }

        private void BindParentData()
        {
            var list = ParentRows.ToList();
            list.Add(new DataGridRow
            {
                Title = "无父类",
                Id = "0"
            });
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "Title";
            comboBox1.ValueMember = "Id";
            comboBox1.SelectedValue = "0";
        }

        private MenuForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        public DataGridRow Row { get; set; }

        private IEnumerable<DataGridRow> ParentRows { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Verfiry())
                return;

            Row = new DataGridRow();
            Row.Id = RowId;
            Row.Title = textBox1.Text;
            Row.Key = textBox2.Text;
            Row.Url = textBox3.Text;
            if (comboBox1.SelectedValue != "0")
            {
                Row.RootId = comboBox1.SelectedValue.ToString();
            }

            if (radioButton1.Checked)
                Row.MenuType = "View";
            else
                Row.MenuType = "Click";

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private bool Verfiry()
        {
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                ShowMessage("请选择类型");
                return false;
            }

            if (String.IsNullOrEmpty(textBox1.Text))
            {
                ShowMessage("请输入标题");
                return false;
            }

            if (radioButton2.Checked && String.IsNullOrEmpty(textBox2.Text))
            {
                ShowMessage("点击型菜单请设置Key");
                return false;
            }

            if(radioButton1.Checked && String.IsNullOrEmpty(textBox3.Text))
            {
                ShowMessage("链接型菜单请设置url");
                return false;
            }

            return true;
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
            return;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxCheckChanged();
        }

        private void CheckBoxCheckChanged()
        {
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
            if (radioButton1.Checked)
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
            }

            if (radioButton2.Checked)
            {
                textBox3.Enabled = false;
                textBox2.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxCheckChanged();
        }
    }
}
