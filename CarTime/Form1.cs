using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//需要添加的

using System.Xml;

using System.IO;

namespace CarTime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            getDataResult();

            DataTable dt = XmlToExcel();
            this.dataGridView1.DataSource = dt;
        }
        /// <summary>
        /// 上传结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Upload_Click(object sender, EventArgs e)
        {
            CarTime ct = new CarTime();
            ct.Mypk = Guid.NewGuid().ToString();
            ct.Lbstart = lb_Start.SelectedItem.ToString();
            ct.Lbend = lb_End.SelectedItem.ToString();
            ct.Dtstart = this.dateTimePicker1.Value.ToString();
            ct.Dtend = this.dateTimePicker2.Value.ToString();
            ct.Licheng = this.textBox1.Text;
            ct.Costtime = this.textBox2.Text;
            ct.Jine = this.textBox3.Text;
            ct.Demo = this.textBox8.Text;

            saveToXml(ct);
        }
        string path = @"config.xml";

        #region 把数据保存至xml文件

        /// <summary>
        /// 保存至xml文件
        /// </summary>
        /// <param name="ct"></param>
        private void saveToXml(CarTime ct)
        {
            //path = System.IO.Directory.GetCurrentDirectory() + "\\CarTime\\Data\\config.xml";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            XmlElement n = xmlDoc.CreateElement("CarTime");
            // n.InnerText = DateTime.Now.ToString("yyyy-MM-dd");
            xmlDoc.SelectSingleNode("config").AppendChild(n);

            //添加子级 遍历类的属性
            System.Reflection.PropertyInfo[] properties =
               ct.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            XmlElement cn = null;
            foreach (System.Reflection.PropertyInfo item in properties)
            {
                cn = xmlDoc.CreateElement(item.Name);
                cn.InnerText = item.GetValue(ct, null).ToString();
                n.AppendChild(cn);
            }
            //保存数据
            xmlDoc.Save(path);

            MessageBox.Show("上传成功");
        }

        #endregion

        #region 从xml获得数据，并加载

        /// <summary>
        /// 统计结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            getDataResult();
        }

        /// <summary>
        /// 统计结果
        /// </summary>
        public void getDataResult()
        {
            DataTable dt = XmlToExcel();
            float temp1 = 0, temp2 = 0, temp3 = 0;
            foreach (DataRow dr in dt.Rows)
            {
                temp1 += float.Parse(dr["Licheng"].ToString());
                temp2 += float.Parse(dr["Costtime"].ToString());
                temp3 += float.Parse(dr["Jine"].ToString());
            }
            this.textBox4.Text = temp1.ToString();
            this.textBox5.Text = temp2.ToString();
            this.textBox6.Text = temp3.ToString();
            this.textBox7.Text = dt.Rows.Count.ToString();
        }

        /// <summary>
        /// 从xml获得数据，并加载 暂未成功
        /// </summary>
        public DataTable XmlToExcel()
        {
            //获得数据
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            DataTable dt = new DataTable();
            DataRow dr = null;
            XmlNodeList nodes = xmlDoc.SelectNodes("config/CarTime");

            //生成列
            foreach (XmlElement xe in nodes[0].ChildNodes)
                dt.Columns.Add(xe.Name);

            //提取数据集合
            foreach (XmlNode node in nodes)
            {
                dr = dt.Rows.Add();
                foreach (DataColumn dc in dt.Columns)
                    dr[dc.ColumnName] = node.SelectSingleNode(dc.ColumnName).InnerText;

            }
            //导出excel文件
            // ExcelOperate.DataSetToExcel(dt, true);
            return dt;
        }
        #endregion



    }
}
