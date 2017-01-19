using System;
using System.Xml.Serialization;

namespace ValumeFigyre
{
    public class Figure:IXmlSerializable
    {
        public Figure() { }

        private VolumeFigure _figure;
        public VolumeFigure Figures
        {
            get { return _figure; }
            set { _figure = value; }
        }

        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
        {
            reader.ReadStartElement("Figures");
            string strType = reader.GetAttribute("type");
            XmlSerializer serial = new XmlSerializer(Type.GetType(strType));
            _figure = (VolumeFigure)serial.Deserialize(reader);
            reader.ReadEndElement();
        }

        void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("Figures");
            string strType = _figure.GetType().FullName;
            writer.WriteAttributeString("type", strType);
            XmlSerializer serial = new XmlSerializer(Type.GetType(strType));
            serial.Serialize(writer, _figure);
            writer.WriteEndElement();
        }

    }
}
