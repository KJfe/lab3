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
            AddOrModify AddFigure = new AddOrModify(false,null);
            AddFigure.Delegate = this;
            AddFigure.FormClosed += (obj, arg) =>
            {
                if (_figure != null)
                {
                    ListFigure.Add(_figure);
                    _figure = null;
                }
                WriteInGrid(); // Запись данных Таблицу
            };
            AddFigure.ShowDialog();
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
                            Box BoxVolume = new Box(height: random.NextDouble() + random.Next(0, maxRandom),
                                width: random.NextDouble() + random.Next(0, maxRandom),
                                deep: random.NextDouble() + random.Next(0, maxRandom));
                            ListFigure.Add(BoxVolume);
                            break;
                        }
                    case 1:
                        {
                            Sphear SphearVolume = new Sphear(radius: random.NextDouble() + random.Next(0, maxRandom));
                            ListFigure.Add(SphearVolume);
                            break;
                        }
                    case 2:
                        {
                            Pyramid PyramidVolume = new Pyramid(area: random.NextDouble() + random.Next(0, maxRandom),
                                height: random.NextDouble() + random.Next(0, maxRandom));
                            ListFigure.Add(PyramidVolume);
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
        /// <summary>
        /// сохранение данных таблицы в XML файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet(); // создаем пока что пустой кэш данных
                DataTable dt = new DataTable(); // создаем пока что пустую таблицу данных
                dt.TableName = "Figures"; // название таблицы
                dt.Columns.Add("Figure"); // название колонок
                dt.Columns.Add("Volume");
                dt.Columns.Add("Width");
                dt.Columns.Add("Height");
                dt.Columns.Add("Deep");
                ds.Tables.Add(dt); //в ds создается таблица, с названием и колонками, созданными выше
                foreach(var fig in ListFigure)
                {
                    DataRow row = ds.Tables["Figures"].NewRow();
                    row["Figure"] = fig.TypeFigyre;  //в столбец этой строки заносим данные из первого столбца dataGridView1
                    row["Volume"] = fig.Valume; // то же самое со вторыми столбцами
                    if (fig.TypeFigyre=="Parallepiped")
                    {
                        row["Width"] = fig.Parametr[0];
                        row["Height"] = fig.Parametr[1];
                        row["Deep"] = fig.Parametr[2];
                    }
                    else if(fig.TypeFigyre == "Sphear")
                    {
                        row["Width"] = fig.Parametr[0];
                        row["Height"] = "";
                        row["Deep"] = "";
                    }
                    else
                    {
                        row["Width"] = fig.Parametr[0];
                        row["Height"] = fig.Parametr[1];
                        row["Deep"] = "";
                    }
                    ds.Tables["Figures"].Rows.Add(row);
                }
                saveDialog.ShowDialog();
                ds.WriteXml(saveDialog.FileName);
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
        private void WrittenInList(DataSet ds)
        {
            foreach (DataRow item in ds.Tables["Figures"].Rows)
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
            openDialog.ShowDialog();
            if ((File.Exists(openDialog.FileName)) && (openDialog.FileName.Length !=0)) // если существует данный файл
                {
                    DataSet ds = new DataSet(); // создаем новый пустой кэш данных
                    ds.ReadXml(openDialog.FileName); // записываем в него XML-данные из файла
                    WrittenInList(ds);
                    WriteInGrid();// Запись данных Таблицу
                }
        }
        /// <summary>
        /// Запись данных с List<> в Таблицу
        /// </summary>
        private void WriteInGrid()
        {
            Grid.Rows.Clear();
            foreach (var figure in ListFigure)
            {
                Grid.Rows.Add(figure.TypeFigyre, figure.Valume);
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
        /// Отображение подробных данных в таблице
        /// </summary>
        private DataGridViewCellEventArgs _e;
        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            _e = e;
            Modify.Enabled = true;
            TypeFigure.Text = ListFigure[e.RowIndex].TypeFigyre;
            if (ListFigure[e.RowIndex].TypeFigyre == "Sphear")
            {
                XParametr.Text = ListFigure[e.RowIndex].Parametr[0].ToString();
                YParametr.Text = "";
                ZParametr.Text = "";
            }
            else if (ListFigure[e.RowIndex].TypeFigyre == "Parallepiped")
            {
                XParametr.Text = ListFigure[e.RowIndex].Parametr[0].ToString();
                YParametr.Text = ListFigure[e.RowIndex].Parametr[1].ToString();
                ZParametr.Text = ListFigure[e.RowIndex].Parametr[2].ToString();
            }
            else
            {
                XParametr.Text = ListFigure[e.RowIndex].Parametr[0].ToString();
                YParametr.Text = ListFigure[e.RowIndex].Parametr[1].ToString();
                ZParametr.Text = "";
            }
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
            AddOrModify ModifyFigure = new AddOrModify(false, ListFigure[index]);
            ModifyFigure.Delegate = this;
            ModifyFigure.FormClosed += (obj, arg) =>
            {
                if (_figure != null)
                {
                    ListFigure.RemoveAt(index);
                    ListFigure.Add(_figure);
                    Grid.Rows.RemoveAt(index);
                    Grid.Rows.Insert(index, _figure.TypeFigyre, _figure.Valume);
                    _figure = null;
                }    
            };
            ModifyFigure.ShowDialog();
        }
    }
}
