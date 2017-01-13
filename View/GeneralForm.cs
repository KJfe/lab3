using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValumeFigyre;


namespace View
{
    public partial class GeneralForm : Form, IAddObjectDelegate
    {
        /// <summary>
        /// Приватное поле
        /// </summary>
        private IValumeFigyre _figure;
        private DataGridViewCellEventArgs _e;
        /// <summary>
        /// Реализация интефейса при запуске
        /// </summary>
        public GeneralForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Создание List<> для хранения данных в системе и работой с ними
        /// </summary>
        private List<IValumeFigyre> listFigure = new List<IValumeFigyre>();
        /// <summary>
        /// Вызов формы для создания фигуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFigyre_Click(object sender, EventArgs e)
        {
            AddOrModify addFigure = new AddOrModify(false,null);
            addFigure.Delegate = this;
            addFigure.FormClosed += (obj, arg) =>
            {
                if (_figure != null)
                {
                    listFigure.Add(_figure);
                    _figure = null;
                }
                WriteInGrid(); // Запись данных Таблицу
            };
            addFigure.ShowDialog();
        }
        /// <summary>
        /// Вызов формы для редактирования данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Modify_Click(object sender, EventArgs e)
        {
            if (_e == null)
                return;
            
            int index = _e.RowIndex;
            AddOrModify modifyFigure = new AddOrModify(CheckOrModify.Checked, listFigure[index]);
            modifyFigure.Delegate = this;
            modifyFigure.FormClosed += (obj, arg) =>
            {
                if (_figure != null)
                {
                    listFigure.RemoveAt(index);
                    listFigure.Insert(index, _figure);
                    Grid.Rows.RemoveAt(index);
                    Grid.Rows.Insert(index, _figure.TypeFigyre, _figure.Valume);
                    _figure = null;
                }
            };
            modifyFigure.ShowDialog();
        }
        /// <summary>
        /// Удаление построчно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveFigyre_Click(object sender, EventArgs e)
        {
            if (Grid.CurrentRow != null)
            {
                try
                {
                    listFigure.RemoveAt(Grid.CurrentRow.Index);
                    Grid.Rows.Remove(Grid.CurrentRow);
                    if (listFigure.Count == 0)
                        Modify.Enabled = false;
                }
                catch (System.InvalidOperationException)  { }
            }
        }
        /// <summary>
        /// Сохранения делегата
        /// </summary>
        /// <param name="figure"></param>
        public void DidFinish(IValumeFigyre figure)
        {
            _figure = figure;
        }
        /// <summary>
        /// Создание случайных данных, 10 фигур
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Random_Click(object sender, EventArgs e)
        {
#if DEBUG
            Random random = new Random();
            //double randomValue;
            int maxRandom;
            int maxGridSize;
            maxRandom = 10;
            maxGridSize = 10;

            for (int i = 0; i < maxGridSize; i++)
            {
                switch (random.Next(0, 3))
                {
                    case 0:
                        {
                            Box boxVolume = new Box(height: random.NextDouble() + random.Next(0, maxRandom),
                                width: random.NextDouble() + random.Next(0, maxRandom),
                                deep: random.NextDouble() + random.Next(0, maxRandom));
                            listFigure.Add(boxVolume);
                            break;
                        }
                    case 1:
                        {
                            Sphear sphearVolume = new Sphear(radius: random.NextDouble() + random.Next(0, maxRandom));
                            listFigure.Add(sphearVolume);
                            break;
                        }
                    case 2:
                        {
                            Pyramid pyramidVolume = new Pyramid(area: random.NextDouble() + random.Next(0, maxRandom),
                                height: random.NextDouble() + random.Next(0, maxRandom));
                            listFigure.Add(pyramidVolume);
                            break;
                        }
                    default:
                        break;
                }

            }
            Grid.Rows.Clear();
            foreach (var figure in listFigure)
            {
                Grid.Rows.Add(figure.TypeFigyre, figure.Valume);
            }
#endif
        }
        /// <summary>
        /// сохранение данных таблицы в XML файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dataSet = new DataSet(); // создаем пока что пустой кэш данных
                DataTable dataTabel = new DataTable(); // создаем пока что пустую таблицу данных
                dataTabel.TableName = "Figures"; // название таблицы
                dataTabel.Columns.Add("Figure"); // название колонок
                dataTabel.Columns.Add("Volume");
                dataTabel.Columns.Add("Width");
                dataTabel.Columns.Add("Height");
                dataTabel.Columns.Add("Deep");
                dataSet.Tables.Add(dataTabel); //в ds создается таблица, с названием и колонками, созданными выше
                foreach(var figures in listFigure)
                {
                    DataRow daraRow = dataSet.Tables["Figures"].NewRow();
                    daraRow["Figure"] = figures.TypeFigyre;  //в столбец этой строки заносим данные из первого столбца dataGridView1
                    daraRow["Volume"] = figures.Valume; // то же самое со вторыми столбцами
                    if (figures.TypeFigyre=="Parallepiped")
                    {
                        daraRow["Width"] = figures.Parametr[0];
                        daraRow["Height"] = figures.Parametr[1];
                        daraRow["Deep"] = figures.Parametr[2];
                    }
                    else if(figures.TypeFigyre == "Sphear")
                    {
                        daraRow["Width"] = figures.Parametr[0];
                        daraRow["Height"] = "";
                        daraRow["Deep"] = "";
                    }
                    else
                    {
                        daraRow["Width"] = figures.Parametr[0];
                        daraRow["Height"] = figures.Parametr[1];
                        daraRow["Deep"] = "";
                    }
                    dataSet.Tables["Figures"].Rows.Add(daraRow);
                }
                saveDialog.ShowDialog();
                dataSet.WriteXml(saveDialog.FileName);
                MessageBox.Show("Vol file successfully saved.", "Complete");
            }
            catch
            {
                MessageBox.Show("Unable to save file Vol", "Error");
            }
        }
        /// <summary>
        /// Запись и проверка данных с XML файла в List<>
        /// </summary>
        /// <param name="item"></param>
        private void WrittenInList(DataSet dataSet)
        {
            foreach (DataRow item in dataSet.Tables["Figures"].Rows)
            {
                try
                {
                    if (item["Figure"].ToString() == "Parallepiped")
                    {

                        listFigure.Add(new Box(
                            InspectionParametr.ParametrObject(item["Height"], "Height"),
                            InspectionParametr.ParametrObject(item["Width"], "Width"),
                            InspectionParametr.ParametrObject(item["Deep"], "Deep")));
                    }
                    else if (item["Figure"].ToString() == "Sphear")
                    {
                        listFigure.Add(new Sphear(
                            InspectionParametr.ParametrObject(item["Width"], "Radius")
                            ));
                    }
                    else
                    {
                        listFigure.Add(new Pyramid(
                            InspectionParametr.ParametrObject(item["Width"], "Area"),
                            InspectionParametr.ParametrObject(item["Height"], "Height")));
                    }
                }
                catch (CellOutOfRangeExxeption cellOutOfRangeExxeption)
                {
                    MessageBox.Show(cellOutOfRangeExxeption.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (CellFormatException cellFormatError)
                {
                    MessageBox.Show(cellFormatError.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        /// <summary>
        /// Открытие сохраненных данных в XML разметке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_Click(object sender, EventArgs e)
        {
            // openDialog.ShowDialog();
            if (openDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else if ((File.Exists(openDialog.FileName)) && (openDialog.FileName.Length != 0)) // если существует данный файл
            {
                DataSet dataSet = new DataSet(); // создаем новый пустой кэш данных
                try
                {
                    dataSet.ReadXml(openDialog.FileName); // записываем в него XML-данные из файла                                             
                    WrittenInList(dataSet);
                    WriteInGrid();// Запись данных Таблицу
                }
                catch (Exception)
                {
                    MessageBox.Show("Error reading file, the file is corrupted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Запись данных с List<> в Таблицу
        /// </summary>
        private void WriteInGrid()
        {
            Grid.Rows.Clear();
            foreach (var figur in listFigure)
            {
                Grid.Rows.Add(figur.TypeFigyre, figur.Valume);
            }
        }
        /// <summary>
        /// Очиста данных таблицы и List<>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Click(object sender, EventArgs e)
        {
            if (Grid.Rows.Count > 0)
            {
                Grid.Rows.Clear();
                listFigure.Clear();
                Modify.Enabled = false;
            }
            else
            {
                MessageBox.Show("Table is empty", "Error");
            }
        }
        /// <summary>
        /// Отображение подробных данных в таблице
        /// </summary>
        
        /// <summary>
        /// объявление Подписей к TextBox
        /// </summary>
        private BindingList<Label> labelList = new BindingList<Label>();
        /// <summary>
        /// Объявление подписй к Label
        /// </summary>
        private BindingList<TextBox> textBoxList = new BindingList<TextBox>();
        /// <summary>
        /// Отображение параметров, если выбран элемент в Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            _e = e;
            Modify.Enabled = true;
            TypeFigure.Text = listFigure[e.RowIndex].TypeFigyre;
            if (listFigure[e.RowIndex].TypeFigyre == "Sphear")
            {
                XParametr.Text = listFigure[e.RowIndex].Parametr[0].ToString();
                YParametr.Text = "";
                ZParametr.Text = "";
            }
            else if (listFigure[e.RowIndex].TypeFigyre == "Box")
            {
                XParametr.Text = listFigure[e.RowIndex].Parametr[0].ToString();
                YParametr.Text = listFigure[e.RowIndex].Parametr[1].ToString();
                ZParametr.Text = listFigure[e.RowIndex].Parametr[2].ToString();
            }
            else
            {
                XParametr.Text = listFigure[e.RowIndex].Parametr[0].ToString();
                YParametr.Text = listFigure[e.RowIndex].Parametr[1].ToString();
                ZParametr.Text = "";
            }
            // возможно переделать под динамическое создание текст боксов для отображения свойств выбранного объекта в Grid
            /*List<System.Windows.Forms.Control.ControlCollection> listContol = new List<System.Windows.Forms.Control.ControlCollection>();
            listContol.Add(Controls);
            listContol.Add(groupBox1.Controls);
            CreateElementForm textBox = new CreateElementForm();
            textBox.CreatingTextBox(ListFigure[e.RowIndex].TypeFigyre, TextBoxList, listContol);
            try
            {
                TextBoxList = textBox.CreatingTextBox(ListFigure[e.RowIndex].TypeFigyre, TextBoxList, listContol);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("The size of the parameters of the first figure more than necessary", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }*/
        }
        
    }
}
