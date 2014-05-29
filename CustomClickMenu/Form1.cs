using CustomClickMenu.App_Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WX.Api;
using WX.Framework;
using WX.Model;
using WX.Model.ApiRequests;

namespace CustomClickMenu
{


    public partial class Form1 : Form
    {
        private static string s_menufilepath = ConfigurationManager.AppSettings["menufile"];
        private static string s_appfilename;


        private List<DataGridRow> Rows { get; set; }

        public Form1()
        {
            InitializeComponent();
            ReadMenuXml();
            RefreshGrid();
            LoadAppId();
        }

        private void LoadAppId()
        {
            FileInfo fi = new FileInfo(s_menufilepath);
            s_appfilename = fi.DirectoryName + "\\app.txt";
            if (File.Exists(s_appfilename))
            {
                var content = File.ReadAllText(s_appfilename).Trim();
                if (content.IndexOf("|") > -1)
                {
                    var sub = content.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    tb_appId.Text = sub[0];
                    tb_appSecret.Text = sub[1];
                }
            }
        }

        private void ReadMenuXml()
        {
            Rows = new List<DataGridRow>();
            if (File.Exists(s_menufilepath))
            {
                ReadXmlToList(s_menufilepath);
            }
        }

        private void ReadXmlToList(string s_menufilepath)
        {
            XDocument doc = XDocument.Load(s_menufilepath);
            var elements = doc.Element("NewDataSet").Elements();
            if (elements.Any())
            {
                foreach (var e in elements)
                {
                    var row = new DataGridRow();
                    if (e.Element("Id") != null)
                    {
                        row.Id = e.Element("Id").Value;
                        if (e.Element("Title") != null)
                            row.Title = e.Element("Title").Value;
                        if (e.Element("Key") != null)
                            row.Key = e.Element("Key").Value;
                        if (e.Element("RootId") != null)
                            row.RootId = e.Element("RootId").Value;
                        if (e.Element("Url") != null)
                            row.Url = e.Element("Url").Value;

                        if (e.Element("MenuType") != null)
                            row.MenuType = e.Element("MenuType").Value;

                        Rows.Add(row);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new MenuForm(Rows.Where(r => String.IsNullOrEmpty(r.RootId)));
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                form.Row.Id = GetMaxId().ToString();
                Rows.Add(form.Row);
            }
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            if (Rows != null && Rows.Count > 0)
            {
                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = Rows;
                this.dataGridView1.Refresh();
            }
            else
            {
                this.dataGridView1.DataSource = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExportToXml();
            MessageBox.Show("数据成功保存到" + s_menufilepath, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportToXml()
        {
            if (File.Exists(s_menufilepath))
                File.Delete(s_menufilepath);

            DataTable dt = ToDataTable(Rows);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            ds.WriteXml(s_menufilepath);
        }

        public static DataTable ToDataTable(IList list)
        {
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    result.Columns.Add(pi.Name, pi.PropertyType);
                }

                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExportToXml();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                var id = this.dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString();
                if (MessageBox.Show(this, "是否删除此菜单", "", MessageBoxButtons.YesNoCancel) == System.Windows.Forms.DialogResult.Yes)
                {
                    Rows.RemoveAll(r => r.RootId == id || r.Id == id);
                }
            }

            RefreshGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                var id = this.dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString();
                var row = Rows.FirstOrDefault(r => r.Id == id);
                if (row != null)
                {
                    var form = new MenuForm(Rows.Where(r => String.IsNullOrEmpty(r.RootId)), row);
                    if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        row.Title = form.Row.Title;
                        row.MenuType = form.Row.MenuType;
                        row.Key = form.Row.Key;
                        row.Url = form.Row.Url;
                        row.RootId = form.Row.RootId;
                    }
                    RefreshGrid();
                }
            }
        }

        private int GetMaxId()
        {
            return Rows.Any() ? Rows.Max(r => int.Parse(r.Id)) + 1 : 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var appId = tb_appId.Text.Trim();
            var appSecret = tb_appSecret.Text.Trim();
            if (String.IsNullOrEmpty(appId) || String.IsNullOrEmpty(appSecret))
            {
                MessageBox.Show("请输入appId和appSecret");
                return;
            }
            if (Rows == null || !Rows.Any())
            {
                MessageBox.Show("请添加菜单");
                return;
            }
            ApiAccessTokenManager.Instance.SetAppIdentity(appId, appSecret);

            IApiClient client = new DefaultApiClient();
            var request = new MenuCreateRequest()
            {
                AccessToken = ApiAccessTokenManager.Instance.GetCurrentToken(),
                Buttons = BuildButton()
            };

            var response = client.Execute(request);
            if (response.IsError)
            {
                MessageBox.Show(response.ToString());
                return;
            }
            else
            {
                MessageBox.Show("菜单生成成功，一般有24小时缓存时间，也可以直接取消关注再关注直接查看效果");
            }
        }

        private IEnumerable<ClickButton> BuildButton()
        {
            var result = new List<ClickButton>();
            foreach (var r in Rows.Where(r => String.IsNullOrEmpty(r.RootId)))
            {
                var button = new ClickButton
                {
                    Name = r.Title,
                    Key = r.Key,
                    Type = r.MenuType == "View" ? ClickButtonType.view : ClickButtonType.click
                };

                if (button.Type == ClickButtonType.view)
                {
                    button.Url = r.Url;
                }

                var subButton = Rows.Where(s => s.RootId == r.Id);
                if (subButton.Any())
                {
                    button.SubButton = subButton.Select(s => new ClickButton
                    {
                        Name = s.Title,
                        Key = s.Key,
                        Type = s.MenuType == "View" ? ClickButtonType.view : ClickButtonType.click,
                        Url = s.MenuType == "View" ? s.Url : ""
                    }).Take(5);
                }

                result.Add(button);
            }

            return result.Take(3);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var appId = tb_appId.Text.Trim();
            var appSecret = tb_appSecret.Text.Trim();
            if (String.IsNullOrEmpty(appId) || String.IsNullOrEmpty(appSecret))
            {
                MessageBox.Show("请输入appId和appSecret");
                return;
            }
            
            File.WriteAllText(s_appfilename, appId + "|" + appSecret);
            MessageBox.Show("保存文件成功");
        }
    }
}
