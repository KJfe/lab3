using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValumeFigyre;


namespace View
{
    [Serializable]
    public partial class GeneralForm : Form, IAddObjectDelegate
    {
        /// <summary>
        /// Приватные поля
        /// </summary>
        private IValumeFigyre _figure;
        private int _rowIndexGrid;
        /// <summary>
        /// объявление Подписей к TextBox
        /// </summary>
        private BindingList<Label> LabelList = new BindingList<Label>();
        /// <summary>
        /// Объявление подписй к Label
        /// </summary>
        private BindingList<TextBox> TextBoxList = new BindingList<TextBox>();

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
       
        private List<IValumeFigyre> ListFigure = new List<IValumeFigyre>();
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
                    ListFigure.Add(_figure);
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
            if (_rowIndexGrid == -1)
                return;
            //int index = _e.RowIndex;
            AddOrModify modifyFigure = new AddOrModify(CheckOrModify.Checked, ListFigure[_rowIndexGrid]);
            modifyFigure.Delegate = this;
            modifyFigure.FormClosed += (obj, arg) =>
            {
                if (_figure != null)
                {
                    ListFigure.RemoveAt(_rowIndexGrid);
                    ListFigure.Insert(_rowIndexGrid, _figure);
                    Grid.Rows.RemoveAt(_rowIndexGrid);
                    Grid.Rows.Insert(_rowIndexGrid, _figure.TypeFigyre, _figure.Valume);
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
                    ListFigure.RemoveAt(Grid.CurrentRow.Index);
                    Grid.Rows.Remove(Grid.CurrentRow);
                    if (ListFigure.Count == 0)
                        Modify.Enabled = false;
                }
                catch (System.InvalidOperationException)  { }
            }
        }
        /// <summary>
        /// сохранение данных таблицы в XML файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            /*XmlSerializer formatter = new XmlSerializer(typeof(IValumeFigyre), new Type[] { typeof(List<IValumeFigyre>) });
            saveDialog.ShowDialog();
            formatter.Serialize(File.Create(saveDialog.FileName), listFigure);
            MessageBox.Show("Vol file successfully saved.", "Complete");*/
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
                
                foreach (var figures in ListFigure)
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

                        ListFigure.Add(new Box(
                            InspectionParametr.ParametrObject(item["Height"], "Height"),
                            InspectionParametr.ParametrObject(item["Width"], "Width"),
                            InspectionParametr.ParametrObject(item["Deep"], "Deep")));
                    }
                    else if (item["Figure"].ToString() == "Sphear")
                    {
                        ListFigure.Add(new Sphear(
                            InspectionParametr.ParametrObject(item["Width"], "Radius")
                            ));
                    }
                    else
                    {
                        ListFigure.Add(new Pyramid(
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
            if (openDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else if ((File.Exists(openDialog.FileName)) && (openDialog.FileName.Length != 0)) // если существует данный файл
            {
                /*XmlSerializer formatter = new XmlSerializer(typeof(List<IValumeFigyre>));
                saveDialog.ShowDialog();
                listFigure.Add(formatter.Deserialize(File.Create(saveDialog.FileName))as IValumeFigyre);
                WriteInGrid();
                MessageBox.Show("Vol file successfully saved.", "Complete");*/
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
            foreach (var figur in ListFigure)
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
                ListFigure.Clear();
                Modify.Enabled = false;
            }
            else
            {
                MessageBox.Show("Table is empty", "Error");
            }
        }
        /// <summary>
        /// Отображение параметров, если выбран элемент в Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _rowIndexGrid = e.RowIndex;
            if (_rowIndexGrid == -1)
                return;            
            Modify.Enabled = true;
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
                            ListFigure.Add(boxVolume);
                            break;
                        }
                    case 1:
                        {
                            Sphear sphearVolume = new Sphear(radius: random.NextDouble() + random.Next(0, maxRandom));
                            ListFigure.Add(sphearVolume);
                            break;
                        }
                    case 2:
                        {
                            Pyramid pyramidVolume = new Pyramid(area: random.NextDouble() + random.Next(0, maxRandom),
                                height: random.NextDouble() + random.Next(0, maxRandom));
                            ListFigure.Add(pyramidVolume);
                            break;
                        }
                    default:
                        break;
                }

            }
            Grid.Rows.Clear();
            foreach (var figure in ListFigure)
            {
                Grid.Rows.Add(figure.TypeFigyre, figure.Valume);
            }
#endif
        }
    }
}
