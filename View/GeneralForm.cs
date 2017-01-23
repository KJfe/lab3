using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using VolumeFigyre;


namespace View
{
    public partial class GeneralForm : Form
    {
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
        private List<IVolumeFigure> ListFigure = new List<IVolumeFigure>();
        /// <summary>
        /// Вызов формы для создания, редактирования или чтения фигуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFigyre_Click(object sender, EventArgs e)
        {
            bool enabledTextBox = true;
            IVolumeFigure figure=null;
            if (_rowIndexGrid == -1)
                return;
            if (Creating.Checked || ModifyRb.Checked)
            {
                enabledTextBox = false;
            }
            if((ModifyRb.Checked||Reading.Checked)&&(ListFigure.Count!=0))
            {
                figure = ListFigure[_rowIndexGrid];   
            }
            else if (!Creating.Checked) return;
            AddOrModify FormAddOrModifyFigure = new AddOrModify(enabledTextBox, figure);
            FormAddOrModifyFigure.onMakeFigure += DidFinish;
            FormAddOrModifyFigure.ShowDialog();
        }

        /// <summary>
        /// метод срабатывающий на событи при нажатии в другой форме на Ок
        /// </summary>
        /// <param name="volumefigure"></param>
        private void DidFinish(IVolumeFigure volumefigure)
        {
            if (volumefigure != null)
            {
                if (Creating.Checked)
                {
                    ListFigure.Add(volumefigure);
                    Grid.Rows.Add(volumefigure.TypeFigure, volumefigure.Volume);
                }
                if (ModifyRb.Checked)
                {
                    ListFigure.RemoveAt(_rowIndexGrid);
                    Grid.Rows.RemoveAt(_rowIndexGrid);
                    ListFigure.Insert(_rowIndexGrid,volumefigure);
                    //надо подумать есть проблема
                    if(Grid.RowCount==1)
                    {
                        Grid.Rows.Add(volumefigure.TypeFigure, volumefigure.Volume);
                    }
                    else
                    {
                        Grid.Rows.Insert(_rowIndexGrid, volumefigure.TypeFigure, volumefigure.Volume);
                        Grid.CurrentCell = Grid.Rows[_rowIndexGrid-1].Cells[0];
                    }
                        
                }
                volumefigure = null;
            }
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
                }
                catch (System.InvalidOperationException)  { }
            }
        }
        //public static FigureCollection list = new FigureCollection();
        /// <summary>
        /// сохранение данных таблицы в XML файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(IVolumeFigure));
            saveDialog.ShowDialog();
            //formatter.Serialize(File.Create(saveDialog.FileName), ListFigure[0]);

            using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
            {
                formatter.Serialize(writer, ListFigure[0]);
                writer.Close();
            }
            MessageBox.Show("Vol file successfully saved.", "Complete");
            /*try
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
                    daraRow["Figure"] = figures.TypeFigure;  //в столбец этой строки заносим данные из первого столбца dataGridView1
                    daraRow["Volume"] = figures.Volume; // то же самое со вторыми столбцами
                    if (figures.TypeFigure=="Parallepiped")
                    {
                        daraRow["Width"] = figures.Parametr[0];
                        daraRow["Height"] = figures.Parametr[1];
                        daraRow["Deep"] = figures.Parametr[2];
                    }
                    else if(figures.TypeFigure == "Sphear")
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
            }*/

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(IVolumeFigure));
                //SaveFileDialog sfd = new SaveFileDialog();
                saveDialog.ShowDialog();
                    using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                    {
                        serializer.Serialize(writer, ListFigure);
                        writer.Close();
                    }
                MessageBox.Show("Vol file successfully saved.", "Complete");
            }
            catch
            {
                MessageBox.Show("Unable to save file.", "Error.");
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
                            InspectionParametr.Parametr(item["Height"], "Height"),
                            InspectionParametr.Parametr(item["Width"], "Width"),
                            InspectionParametr.Parametr(item["Deep"], "Deep")));
                    }
                    else if (item["Figure"].ToString() == "Sphear")
                    {
                        ListFigure.Add(new Sphear(
                            InspectionParametr.Parametr(item["Width"], "Radius")
                            ));
                    }
                    else
                    {
                        ListFigure.Add(new Pyramid(
                            InspectionParametr.Parametr(item["Width"], "Area"),
                            InspectionParametr.Parametr(item["Height"], "Height")));
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
                Grid.Rows.Add(figur.TypeFigure, figur.Volume);
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
            }
            else
            {
                MessageBox.Show("Table is empty", "Error");
            }
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
                Grid.Rows.Add(figure.TypeFigure, figure.Volume);
            }
#endif
        }
        /// <summary>
        /// Отображение параметров, если выбран элемент в Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            _rowIndexGrid = e.RowIndex;
            if (_rowIndexGrid == -1)
                return;
        }
    }
}
