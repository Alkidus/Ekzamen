/*Третий вариант
Создать приложение «Список дел».
Основная задача приложения: предоставить пользователю функциональность
для создания и ведения списка дел.
Интерфейс приложения должен предоставлять такие возможности:
■■ создание конкретного дела;
■■ при создании дела можно указать: дату выполнения, время выполнения,
приоритет(высокий, средний, низкий), теги, текстовый комментарий,
прикрепленный файл;
■■ отображение списка дел на день, неделю, месяц;
■■ поиск дел по различным критериям поиска;
■■ сохранение списка дел в файл pdf-формата;
■■ создание проекта.Проект содержит набор дел;
■■ приложение должно поддерживать механизм Drag-and-Drop для переноса
дел из одного проекта в другой.*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Task_Manager
{
    public partial class Form1 : Form
    {
        int i = 0; //индекс имен добавляемых listview
        int tabSelInd; //индек выбранной закладки
        int tabPagesCount; //количество страниц tabControl
        List<ListView> listcollection = new List<ListView>(); //коллекция добавляемых 
        ListView listView;
        Dictionary<string, string> files = new Dictionary<string, string>(); // для прикрепленных файлов
        private static Timer nowTime = new Timer();
        private void ShowTime(object vobj, EventArgs e)
        {
            label1.Text = "Сегодня - " + DateTime.Now.ToLongDateString() + " время: " + DateTime.Now.ToLongTimeString();
        }
        public Form1()
        {
            InitializeComponent();
            Text = "ToDoLi";
            AddNewDo_btn.Enabled = false;
            label1.Text = "Сегодня - " + DateTime.Now.ToLongDateString() + " время: " + DateTime.Now.ToLongTimeString();
            nowTime.Tick += new EventHandler(ShowTime);
            nowTime.Interval = 500;
            nowTime.Start();

        }


        // добавляем новое событие
        private void AddNewDo_btn_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if(f2.DialogResult == DialogResult.OK)
            {
                string text = f2.textBox1.Text + " " + f2.label3.Text + " " + f2.label4.Text;
                if (f2.radioButton1.Checked)
                    text = "ВАЖНОЕ: " + text;
                else if (f2.radioButton2.Checked)
                    text = "СРЕДНЕЕ: " + text;
                else if (f2.radioButton3.Checked)
                    text = "НИЗКОЕ: " + text;

                ListViewItem viewItem = new ListViewItem(text);//создаем элемент списка с текстом text
                viewItem.SubItems.Add(f2.label8.Text);//добавляем в SubItems для дальнейшего использования при поиске по датам
                viewItem.ToolTipText = f2.textBox2.Text;//добавляем всплывающую подсказку
                viewItem.Tag = f2.textBox3.Text;//добавляем элементу тег
                tabSelInd = tabControl1.SelectedIndex;
                if (!String.IsNullOrEmpty(f2.path))
                {
                    files.Add(text, f2.path);//если был прикреплен файл добавляем в коллекцию зеленым цветом
                    listcollection[tabSelInd].Items.Add(viewItem).ForeColor = Color.Green;
                }
                else
                    listcollection[tabSelInd].Items.Add(viewItem).ForeColor = Color.Blue;

            }

        }
        // добавляем новый список дел
        private void AddNewList_btn_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
            if(f3.DialogResult == DialogResult.OK)
            {
                tabPagesCount = tabControl1.TabPages.Count;
                tabControl1.TabPages.Add(f3.textBox1.Text);
                tabControl1.AllowDrop = true;
                listView = new ListView()
                { Text = "NewListView", Name = "listView" + i, Dock = System.Windows.Forms.DockStyle.Fill };
                listcollection.Add(listView);
                tabControl1.TabPages[tabPagesCount].Controls.Add(listcollection[tabPagesCount]);
                listView.CheckBoxes = true;
                listView.View = View.List;
                listView.ForeColor = System.Drawing.Color.Blue;
                listView.Font = new System.Drawing.Font("Comic Sans MS", 14, System.Drawing.FontStyle.Bold);
                listView.Scrollable = true;
                listView.ShowItemToolTips = true;
                listView.AllowDrop = true;
                listView.ItemDrag += ListView_ItemDrag;
                listView.DragDrop += new DragEventHandler(listView_DragDrop);
                listView.DragOver += new DragEventHandler(listView_DragOver);
                listView.DoubleClick += ListView_DoubleClick;




                i++;
            }
            AddNewDo_btn.Enabled = true;
        }
        // событие переключения вкладок при перетаскивании
        private void tabControl1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
            Point clientPoint = tabControl1.PointToClient(new Point(e.X, e.Y));
            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                if (tabControl1.GetTabRect(i).Contains(clientPoint) && tabControl1.SelectedIndex != i)
                {
                    tabControl1.SelectedIndex = i;
                }
            }
        }
        // выбираем объект и начинаем перетаскивать
        private void ListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            tabSelInd = tabControl1.SelectedIndex;
            listcollection[tabSelInd].DoDragDrop(listcollection[tabSelInd].SelectedItems, DragDropEffects.Copy);
        }
        // эффект при перетаскивании
        private void listView_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
                e.Effect = e.AllowedEffect;
        }
        // завершаем перетаскивание, бросаем объект
        void listView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListView.SelectedListViewItemCollection)))
            {
                foreach (ListViewItem current in (ListView.SelectedListViewItemCollection)
                    e.Data.GetData(typeof(ListView.SelectedListViewItemCollection)))
                {
                    tabSelInd = tabControl1.SelectedIndex;
                    listcollection[tabSelInd].Items.Add((ListViewItem)current.Clone());
                }
            }
        }
        // при двойном щелчке по событию меняет цвет и шрифт
        private void ListView_DoubleClick(object sender, EventArgs e)
        {
            ListView it = (ListView)sender;
            if(it.SelectedItems[0].ForeColor == Color.Red)
            {
                it.SelectedItems[0].ForeColor = Color.Blue;
                it.SelectedItems[0].Font = new System.Drawing.Font("Comic Sans MS", 14, System.Drawing.FontStyle.Bold);
            }
            else if (it.SelectedItems[0].ForeColor == Color.Blue)
            {
                it.SelectedItems[0].ForeColor = Color.Red;
                it.SelectedItems[0].Font = new System.Drawing.Font("Comic Sans MS", 14, System.Drawing.FontStyle.Strikeout);
            }
        }
        // кнопка со знаком вопроса в правом верхнем углу
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Это простой менеджер заданий 'ToDoLi'. 
Разработан в рамках учебной программы Компьютерной Академии ШАГ в ознакомительных целях с WinForms. 
Использовался язык программирования С# и Microsoft Visual Studio Enterprise 2019.
Программист - Дьяконов Кирилл Владимирович, руководитель проекта - Горчинский Сергей Владимирович.
г. Чернигов январь 2021 год. Эта программа для бесплатного ознакомительного распространения.
Для связи - alkiddkv@gmail.com
Использование:
---Запускаете программу, создаете Список дел и добавляете необходимые События.
---Перед выходом из программы сохраните каждый Список дел.
---Запустив вновь программу загружайте раннее сохраненные Списки дел.", "О программе");

        }
        // кнопка "Сохранить список дел" сохраняет сразу в двух форматах *.txt & *.pdf
        // подключена библиотека iTextSharp через NuGet для сохранения в pdf формате
        private void Save_btn_Click(object sender, EventArgs e)
        {
            tabSelInd = tabControl1.SelectedIndex;
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = "txt";
            save.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.FileName);
                foreach (ListViewItem item in listcollection[tabSelInd].Items)
                {
                    writer.WriteLine(item.Text);
                }
                writer.Close();
                //--------------------------saving in pdf
                //Объект документа пдф
                iTextSharp.text.Document doc = new iTextSharp.text.Document();

                //Создаем объект записи пдф-документа в файл
                PdfWriter.GetInstance(doc, new FileStream(save.FileName + ".pdf", FileMode.Create));

                //Открываем документ
                doc.Open();

                //Определение шрифта необходимо для сохранения кириллического текста
                //Иначе мы не увидим кириллический текст
                //Если мы работаем только с англоязычными текстами, то шрифт можно не указывать
                BaseFont baseFont = BaseFont.CreateFont("..\\..\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

                //Создаем объект таблицы и передаем в нее число столбцов таблицы из нашего датасета
                PdfPTable table = new PdfPTable(1);

                //Добавим в таблицу общий заголовок
                PdfPCell cell = new PdfPCell(new Phrase("Список дел: " + tabControl1.SelectedTab.Text, font));

                cell.Colspan = listcollection[tabSelInd].Items.Count;
                cell.HorizontalAlignment = 1;
                //Убираем границу первой ячейки, чтобы была как заголовок
                cell.Border = 0;
                table.AddCell(cell);
                //Добавляем все остальные ячейки
                foreach (ListViewItem item in listcollection[tabSelInd].Items)
                {
                    table.AddCell(new Phrase(item.Text, font));
                }
                //Добавляем таблицу в документ
                doc.Add(table);
                //}
                //Закрываем документ
                doc.Close();

                MessageBox.Show("Pdf-документ сохранен");
            }
        }
        // кнопка "Удаление списка дел"
        private void DelList_btn_Click(object sender, EventArgs e)
        {
            tabSelInd = tabControl1.SelectedIndex;
            listcollection.RemoveAt(tabSelInd);
            tabControl1.TabPages.RemoveAt(tabSelInd);
            if(tabControl1.TabPages.Count < 1)
            {
                AddNewDo_btn.Enabled = false;
                files.Clear();
            }
        }
        // кнопка "Удаление события"
        private void DelSomeDo_btn_Click(object sender, EventArgs e)
        {
            tabSelInd = tabControl1.SelectedIndex;

            try
            {
                listcollection[tabSelInd].Items.Remove(listcollection[tabSelInd].SelectedItems[0]);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "WarningException!!!");
                MessageBox.Show("Сначала выберите событие которое хотите удалить!", "ВНИМАНИЕ!!!");
            }
        }
        // кнопка "Поиск события"
        private void Find_btn_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
            if(f4.DialogResult == DialogResult.OK)
            {
                tabSelInd = tabControl1.SelectedIndex;
                bool a = false;
                int j = 0;//переменная для правильного отображения сообщений
                foreach (ListViewItem item in listcollection[tabSelInd].Items)
                {
                    if (!String.IsNullOrEmpty(f4.textBox1.Text))
                    {
                        a = item.Text.Contains(f4.textBox1.Text);
                        if (a)
                        {
                            MessageBox.Show("Результаты поиска: " + item.Text);
                            a = true;
                            j++;
                        }
                    }
                    foreach (ListViewItem.ListViewSubItem si in item.SubItems)
                    {
                        string text = si.Text;
                        int i = String.Compare(text, f4.label4.Text);
                        if (i == 0 & String.IsNullOrEmpty(f4.textBox1.Text))
                        {
                            MessageBox.Show("Результаты поиска: " + item.Text, si.Text);
                            a = true;
                            j++;
                        }
                    }
                }
                if(!a & j == 0)
                    MessageBox.Show("Поиск результатов не дал");
            }
        }
        // кнопка "Отобразить дела за..."
        private void ShowList_btn_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.ShowDialog();
            if (f5.DialogResult == DialogResult.OK)
            {
                tabPagesCount = tabControl1.TabPages.Count;
                if (f5.radioButton1.Checked)
                {
                    tabControl1.TabPages.Add("Все события за " + f5.radioButton1.Text);
                }
                else if (f5.radioButton2.Checked)
                {
                    tabControl1.TabPages.Add("Все события за " + f5.radioButton2.Text);
                }
                else if (f5.radioButton3.Checked)
                {
                    tabControl1.TabPages.Add("Все события за " + f5.radioButton3.Text);
                }

                ListView lv = new ListView()
                { Text = "NewListView", Name = "listView" + i, Dock = System.Windows.Forms.DockStyle.Fill };
                listcollection.Add(lv);
                tabControl1.TabPages[tabPagesCount].Controls.Add(listcollection[tabPagesCount]);
                lv.CheckBoxes = true;
                lv.View = View.List;
                lv.ForeColor = System.Drawing.Color.Blue;
                lv.Font = new System.Drawing.Font("Comic Sans MS", 14, System.Drawing.FontStyle.Bold);
                lv.Scrollable = true;
                lv.ShowItemToolTips = true;
                lv.AllowDrop = true;
                lv.ItemDrag += ListView_ItemDrag;
                lv.DragDrop += new DragEventHandler(listView_DragDrop);
                lv.DragOver += new DragEventHandler(listView_DragOver);
                lv.DoubleClick += ListView_DoubleClick;
                i++;
                tabSelInd = tabControl1.SelectedIndex;
                if (f5.radioButton1.Checked)
                {
                    for (int i = 0; i < listcollection.Count; i++)
                    {
                        foreach(ListViewItem item in listcollection[i].Items)
                        {
                            foreach (ListViewItem.ListViewSubItem si in item.SubItems)
                            {
                                if (si.Text == DateTime.Now.ToShortDateString())
                                {
                                    ListViewItem newItem = new ListViewItem();
                                    newItem.Text = item.Text;
                                    lv.Items.Add(newItem);
                                }
                            }
                        }
                    }
                }
                else if (f5.radioButton2.Checked)
                {
                    for (int i = 0; i < listcollection.Count; i++)
                    {
                        foreach (ListViewItem item in listcollection[i].Items)
                        {
                            foreach (ListViewItem.ListViewSubItem si in item.SubItems)
                            {
                                try
                                {
                                    if (Convert.ToDateTime(si.Text) < DateTime.Now.AddDays(7))
                                    {
                                        ListViewItem newItem = new ListViewItem();
                                        newItem.Text = item.Text;
                                        lv.Items.Add(newItem);
                                    }
                                }
                                catch (FormatException)
                                {

                                }
                            }
                        }
                    }
                }
                else if (f5.radioButton3.Checked)
                {
                    for (int i = 0; i < listcollection.Count; i++)
                    {
                        foreach (ListViewItem item in listcollection[i].Items)
                        {
                            foreach (ListViewItem.ListViewSubItem si in item.SubItems)
                            {
                                try
                                {
                                    if (Convert.ToDateTime(si.Text) < DateTime.Now.AddDays(30))
                                    {
                                        ListViewItem newItem = new ListViewItem();
                                        newItem.Text = item.Text;
                                        lv.Items.Add(newItem);
                                    }
                                }
                                catch (FormatException)
                                {

                                }
                            }
                        }
                    }
                }
            }
        }
        // кнопка "Открыть прикрепленный файл"
        private void OpenFile_btn_Click(object sender, EventArgs e)
        {
            tabSelInd = tabControl1.SelectedIndex;
            try
            {
                foreach (ListViewItem item in listcollection[tabSelInd].Items)
                {
                    foreach (var next in files)
                    {
                        if (item.Text == next.Key)
                        {
                            if (File.Exists(next.Value))
                            {
                                Process.Start(next.Value);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WarningException!!!");
                MessageBox.Show("Сначала выберите событие!", "ВНИМАНИЕ!!!");
            }
        }
        // кнопка "Загрузить список дел"
        private void button2_Click(object sender, EventArgs e)
        {
            tabSelInd = tabControl1.SelectedIndex;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "TXT Files (*.txt)|*.txt|All Files(*.*)|*.*";
            openFile.FileName = "";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                if (openFile.FileName == "")
                {
                    return;
                }
                else
                {
                    string line; 
                    System.IO.StreamReader file = new System.IO.StreamReader(openFile.FileName);
                    tabPagesCount = tabControl1.TabPages.Count;
                    string name = Path.GetFileNameWithoutExtension(openFile.FileName);
                    tabControl1.TabPages.Add(name);
                    ListView lv = new ListView()
                    { Text = "NewListView", Name = "listView" + i, Dock = System.Windows.Forms.DockStyle.Fill };
                    listcollection.Add(lv);
                    tabControl1.TabPages[tabPagesCount].Controls.Add(listcollection[tabPagesCount]);
                    lv.CheckBoxes = true;
                    lv.View = View.List;
                    lv.ForeColor = System.Drawing.Color.Blue;
                    lv.Font = new System.Drawing.Font("Comic Sans MS", 14, System.Drawing.FontStyle.Bold);
                    lv.Scrollable = true;
                    lv.ShowItemToolTips = true;
                    lv.AllowDrop = true;
                    lv.ItemDrag += ListView_ItemDrag;
                    lv.DragDrop += new DragEventHandler(listView_DragDrop);
                    lv.DragOver += new DragEventHandler(listView_DragOver);
                    lv.DoubleClick += ListView_DoubleClick;
                    i++;
                    
                    while ((line = file.ReadLine()) != null)
                    {
                        ListViewItem newItem = new ListViewItem();
                        newItem.Text = line;
                        lv.Items.Add(newItem);
                    }
                    file.Close();
                }
            }
        }
    }
}
