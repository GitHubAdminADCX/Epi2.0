using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebClient.Controllers
{
   // FRM036
    public class XMLClassSerializer
    {
        #region Methods

        public static bool SerializeObject(string filename, object obj)
        {
            if (string.IsNullOrEmpty(filename))
                return false;

            FileInfo fi = new FileInfo(filename);

            if (fi.Directory == null)
                return false;

            if (fi.Exists)
            {
                if (fi.IsReadOnly)
                    return false;
            }

            if (obj == null)
                return false;


            if (!fi.Directory.Exists)
            {
                DirectoryInfo di = fi.Directory;
                di.Create();
            }

            using (var writer = new StreamWriter(filename))
            {
                XmlSerializer x = new XmlSerializer(obj.GetType());

                try
                {
                    x.Serialize(writer, obj);
                }
                catch
                {
                    return false;
                }

            }

            return true;
        }

        public static string SerializeXML(object obj)
        {
            string ret;

            if (obj == null)
                return null;

            XmlSerializer x = new XmlSerializer(obj.GetType());
            StringWriter writer = new StringWriter();

            try
            {
                x.Serialize(writer, obj);
                ret = writer.ToString();
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                writer.Close();
            }

            return ret;
        }

        public static object DeSerializeObject<T>(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                return null;

            FileInfo fi = new FileInfo(filename);

            if (!fi.Exists)
                return null;

            XmlSerializer x = new XmlSerializer(typeof(T));

            TextReader reader = new StreamReader(filename);

            try
            {
                object obj = x.Deserialize(reader);
                reader.Close();
                return obj;
            }
            catch
            {
                reader.Close();
                return null;
            }

        }

        public static object DeSerializeXML<T>(string strXML)
        {
            if (string.IsNullOrEmpty(strXML))
                return null;

            XmlSerializer x = new XmlSerializer(typeof(T));
            StringReader reader = new StringReader(strXML);

            try
            {
                object obj = x.Deserialize(reader);
                reader.Close();
                return obj;
            }
            catch
            {
                reader.Close();
                return null;
            }
        }

        #endregion

    }
}
