using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// Класс для сериализации листа
    /// </summary>
    [XmlRoot]
    public class ListFigure
    {
        /// <summary>
        /// лист сданными о фигурах
        /// </summary>
        public ListOfIVolumeFigure LilstFigures { get; set; }
    }
}
