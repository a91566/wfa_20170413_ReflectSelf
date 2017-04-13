using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfa_20170413_ReflectSelf
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.init();
			this.button1.Click += Button1_Click;
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			//1
			var o = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
			this.textBox1.Text += $"GetTypes(){Environment.NewLine}";
			foreach (var item in o)
			{
				this.textBox1.Text += item.Name + Environment.NewLine;
			}

			//2 与 1相同
			//this.textBox1.Text += $"{Environment.NewLine}GetModules()[0].FindTypes(){Environment.NewLine}";
			//var o2 = System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FindTypes(null, null);
			//foreach (var item in o2)
			//{
			//	this.textBox1.Text += item.Name + Environment.NewLine;
			//}

			//3 调用静态
			this.textBox1.Text += $"{Environment.NewLine}GetTypes() 调用静态方法{Environment.NewLine}";
			var o3 = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()[0].GetMethods().Where(i => i.Name.StartsWith("sf"));
			foreach (var item in o3)
			{
				this.textBox1.Text += item.Name + Environment.NewLine + Environment.NewLine;
				//静态方法
				string result = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()[0].InvokeMember(item.Name, BindingFlags.Default | BindingFlags.InvokeMethod, null, null, new object[] { }).ToString();
				MessageBox.Show($"{item.Name}方法被调用,结果为:{result}");
			}

			//4 调用动态方法 
			this.textBox1.Text += $"GetTypes() 调用动态方法{Environment.NewLine}";
			var o4 = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()[0].GetMethods().Where(i => i.Name.StartsWith("f"));
			foreach (var item in o4)
			{
				System.Reflection.Assembly.GetExecutingAssembly().GetTypes()[0].InvokeMember(item.Name, BindingFlags.Default | BindingFlags.InvokeMethod, null, this, new object[] { item.Name });
			}

		}

		public void init()
		{
			for (int i = 0; i < 10; i++)
			{
				CheckBox ckb = new CheckBox();
				ckb.Text = i.ToString("D3");
				ckb.Parent = this.flowLayoutPanel1;
			}			
		}

		

		public static string sfunc001()
		{
			return "static func001";
		}

		public void func002(string funcName)
		{
			this.textBox1.Text += $"{funcName}:call{Environment.NewLine}";
		}

		public void func003(string funcName)
		{
			this.textBox1.Text += $"{funcName}:call{Environment.NewLine}";
		}

		public void func004(string funcName)
		{
			this.textBox1.Text += $"{funcName}:call{Environment.NewLine}";
		}

		public void func005(string funcName)
		{
			this.textBox1.Text += $"{funcName}:call{Environment.NewLine}";
		}

		public void func006(string funcName)
		{
			this.textBox1.Text += $"{funcName}:call{Environment.NewLine}";
		}

	}
}
