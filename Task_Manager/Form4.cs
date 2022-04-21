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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            monthCalendar1.DateChanged += MonthCalendar1_DateChanged;
        }

        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            label4.Text = String.Format(e.Start.ToShortDateString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
