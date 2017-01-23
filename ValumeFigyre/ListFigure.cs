using System.Xml.Serialization;

namespace VolumeFigyre
{
    [XmlRoot]
    public class ListFigure
    {
        public ListOfIVolumeFigure LilstFigures { get; set; }
    }
}
