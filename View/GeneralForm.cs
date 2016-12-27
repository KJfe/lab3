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
        private IValumeFigyre _figure;

        public GeneralForm()
        {
            InitializeComponent();
        }
        private List<IValumeFigyre> ListFigure = new List<IValumeFigyre>();
        private void AddFigyre_Click(object sender, EventArgs e)
        {
            AddObject AddFigure = new AddObject();
            AddFigure.Delegate=this;

            AddFigure.FormClosed += (obj, arg) =>
            {
                if (_figure != null)
                {
                    ListFigure.Add(_figure);
                    _figure = null;
                }
                Grid.Rows.Clear();
                foreach(var figure in ListFigure)
                {
                    Grid.Rows.Add(figure.TypeFigyre, figure.Valume);
                }

            };
            AddFigure.ShowDialog();
            
        }

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

        

        public void DidFinish(IValumeFigyre figure)
        {
            _figure = figure;
        }

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
            foreach (var figure in ListFigure)
            {
                Grid.Rows.Add(figure.TypeFigyre, figure.Valume);
            }
#endif
        }

        /// <summary>
        /// сохранение данных таблицы
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
                ds.Tables.Add(dt); //в ds создается таблица, с названием и колонками, созданными выше
                foreach (DataGridViewRow r in Grid.Rows) // пока в Grid есть строки
                {
                    DataRow row = ds.Tables["Figures"].NewRow(); // создаем новую строку в таблице, занесенной в ds
                    row["Figure"] = r.Cells[0].Value;  //в столбец этой строки заносим данные из первого столбца dataGridView1
                    row["Volume"] = r.Cells[1].Value; // то же самое со вторыми столбцами
                    ds.Tables["Figures"].Rows.Add(row); //добавление всей этой строки в таблицу ds.
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

        private void Open_Click(object sender, EventArgs e)
        {
            
                openDialog.ShowDialog();
                if ((File.Exists(openDialog.FileName)) && (openDialog.FileName.Length !=0)) // если существует данный файл
                {
                    DataSet ds = new DataSet(); // создаем новый пустой кэш данных
                    ds.ReadXml(openDialog.FileName); // записываем в него XML-данные из файла

                    foreach (DataRow item in ds.Tables["Figures"].Rows)
                    {
                        int n = Grid.Rows.Add(); // добавляем новую сроку в dataGridView1
                        Grid.Rows[n].Cells[0].Value = item["Figure"]; // заносим в первый столбец созданной строки данные из первого столбца таблицы ds.
                        Grid.Rows[n].Cells[1].Value = item["Volume"]; // то же самое со вторым столбцом
                    }
            }
        }

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


        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
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
    }
    }
