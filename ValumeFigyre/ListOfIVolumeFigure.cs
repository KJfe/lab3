using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// клас интерфейса IXmlSerializable, серализация и десериализация литса 
    /// </summary>
    public class ListOfIVolumeFigure:List<IVolumeFigure>,IXmlSerializable
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public ListOfIVolumeFigure() : base() { }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public XmlSchema GetSchema()
        {
            return null;
        }
        /// <summary>
        /// Десерализаця
        /// </summary>
        /// <param name="reader"></param>
        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("LilstFigures");
            while (reader.IsStartElement("IVolumeFigure"))
            {
                Type type = Type.GetType(reader.GetAttribute("AssemblyQualifiedName"));
                XmlSerializer serial = new XmlSerializer(type);
                reader.ReadStartElement("IVolumeFigure");
                this.Add((IVolumeFigure)serial.Deserialize(reader));
                reader.ReadEndElement();
            }
            reader.ReadEndElement();
        }
        /// <summary>
        /// Серализация
        /// </summary>
        /// <param name="writer"></param>
        public void WriteXml(XmlWriter writer)
        {
            foreach(IVolumeFigure figure in this)
            {
                writer.WriteStartElement("IVolumeFigure");
                writer.WriteAttributeString("AssemblyQualifiedName", figure.GetType().AssemblyQualifiedName);
                XmlSerializer xmlSerializer = new XmlSerializer(figure.GetType());
                xmlSerializer.Serialize(writer, figure);
                writer.WriteEndElement();
            }
           
        }
    }
}
