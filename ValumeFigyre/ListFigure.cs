using System.Xml.Serialization;

namespace Model
{
    [XmlRoot]
    public class ListFigure
    {
        public ListOfIVolumeFigure LilstFigures { get; set; }
    }
}
