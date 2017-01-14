using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ValumeFigyre
{
    public class FigureCollection
    {
        private List<IVolumeFigure> _collection;
        /// <summary>
        /// Коллекция сотрудников
        /// </summary>
        [XmlArray("Collection"),
        XmlArrayItem("Box", typeof(Box)),
        XmlArrayItem("Sphear", typeof(Sphear)),
        XmlArrayItem("Pyramid", typeof(Pyramid))]
        public List<IVolumeFigure> Collection
        {
            get
            {
                return _collection;
            }
        }
        /// <summary>
        /// Конструктор для создания коллекции
        /// </summary>
        public FigureCollection()
        {
            _collection = new List<IVolumeFigure>();
        }
    }
}
