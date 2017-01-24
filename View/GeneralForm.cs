using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using Model;


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
        /// Создание List для хранения данных и возможности его сериализовать
        /// </summary>
        public ListFigure ListParametrsFigures = new ListFigure
            {
                LilstFigures = new ListOfIVolumeFigure()
            };
        /// <summary>
        /// Реализация интефейса при запуске
        /// </summary>
        public GeneralForm()
        {
            InitializeComponent();
        }
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
            if((ModifyRb.Checked||Reading.Checked)&&(ListParametrsFigures.LilstFigures.Count!=0))
            {
                figure = ListParametrsFigures.LilstFigures[_rowIndexGrid];   
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
                    ListParametrsFigures.LilstFigures.Add(volumefigure);
                    Grid.Rows.Add(volumefigure.TypeFigure, volumefigure.Volume);
                }
                if (ModifyRb.Checked)
                {
                    ListParametrsFigures.LilstFigures.RemoveAt(_rowIndexGrid);
                    Grid.Rows.RemoveAt(_rowIndexGrid);
                    ListParametrsFigures.LilstFigures.Insert(_rowIndexGrid,volumefigure);
                    //надо подумать есть проблема
                    if(Grid.RowCount==1)
                    {
                        Grid.Rows.Add(volumefigure.TypeFigure, volumefigure.Volume);
                    }
                    else
                    {
                        Grid.Rows.Insert(_rowIndexGrid, volumefigure.TypeFigure, volumefigure.Volume);
                        Grid.CurrentCell = Grid.Rows[_rowIndexGrid].Cells[0];
                    }
                    //Grid.Rows[0].Cells[1].
                    /*ListParametrsFigures.LilstFigures.Insert(_rowIndexGrid, volumefigure);
                    Grid.Rows.Clear();
                    WriteInGrid();*/


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
                    ListParametrsFigures.LilstFigures.RemoveAt(Grid.CurrentRow.Index);
                    Grid.Rows.Remove(Grid.CurrentRow);
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
            try
            {
                saveDialog.ShowDialog();
                var xmlSerializer = new XmlSerializer(typeof(ListFigure));
                    using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                    {
                        xmlSerializer.Serialize(writer, ListParametrsFigures);
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
                try
                {
                    var xmlSerializer = new XmlSerializer(typeof(ListFigure));
                    //openDialog.ShowDialog();
                    var xmlReader = XmlReader.Create(openDialog.FileName);
                    var deserialization = (ListFigure)xmlSerializer.Deserialize(xmlReader);
                    foreach (var figure in deserialization.LilstFigures)
                    {
                        ListParametrsFigures.LilstFigures.Add(figure);
                    }
                    WriteInGrid();
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
            foreach (var figur in ListParametrsFigures.LilstFigures)
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
                ListParametrsFigures.LilstFigures.Clear();
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
                            Box boxVolume = new Box
                            {
                                Height = random.NextDouble() + random.Next(0, maxRandom),
                                Width = random.NextDouble() + random.Next(0, maxRandom),
                                Deep = random.NextDouble() + random.Next(0, maxRandom)
                            };
                            ListParametrsFigures.LilstFigures.Add(boxVolume);
                            break;
                        }
                    case 1:
                        {
                            Sphear sphearVolume = new Sphear
                            {
                                Radius = random.NextDouble() + random.Next(0, maxRandom)
                            };
                            ListParametrsFigures.LilstFigures.Add(sphearVolume);
                            break;
                        }
                    case 2:
                        {
                            Pyramid pyramidVolume = new Pyramid
                            {
                                Area = random.NextDouble() + random.Next(0, maxRandom),
                                Height = random.NextDouble() + random.Next(0, maxRandom)
                            };
                            ListParametrsFigures.LilstFigures.Add(pyramidVolume);
                            break;
                        }
                    default:
                        break;
                }

            }
            Grid.Rows.Clear();
            foreach (var figure in ListParametrsFigures.LilstFigures)
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
