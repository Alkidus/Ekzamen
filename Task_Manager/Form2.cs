using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_Manager
{
    public partial class Form2 : Form
    {
        private static Timer nowTime = new Timer();
        private void ShowTime (object vobj, EventArgs e)
        {
            button3.Text = DateTime.Now.ToLongTimeString();
        }
        public string path;
        public Form2()
        {
            InitializeComponent();
            path = null;
            button3.Text = DateTime.Now.ToLongTimeString();
            nowTime.Tick += new EventHandler(ShowTime);
            nowTime.Interval = 500;
            nowTime.Start();
            monthCalendar1.DateChanged += MonthCalendar1_DateChanged;
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label4.Text = String.Format(dateTimePicker1.Value.ToLongTimeString());
        }

        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            label3.Text = String.Format(e.Start.ToLongDateString());
            label8.Text = String.Format(e.Start.ToShortDateString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "TXT Files (*.txt)|*.txt|All Files(*.*)|*.*";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName == "")
                {
                    return;
                }
                else
                {
                    path = openFileDialog1.FileName;
                    MessageBox.Show(path, "Прикреплен файл:");
                }
            }
        }
    }
}
