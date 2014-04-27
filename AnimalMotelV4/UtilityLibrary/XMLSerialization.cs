using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace UtilitiesLibrary
{
   public class XMLSerialization
    {

       /// <summary>
       /// Method to serialize with xml
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="filePath"></param>
       /// <param name="obj"></param>
       public static void XmlFileSerialize<T>(string filePath, T obj)
       {
           XmlSerializer s = new XmlSerializer(typeof(T));
           TextWriter w = new StreamWriter(filePath);
           try
           {
               s.Serialize(w, obj);
           }
           catch
           {
               throw;
           }
           finally
           {
               if (w != null) w.Close();
           }
       }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<T> XmlFileDeserialize<T>(string fileName)
        {
           
            try
            {
                using (FileStream w = new FileStream(fileName, FileMode.Open))
                {
                    XmlSerializer xmlData = new XmlSerializer(typeof(T));
                    List<T> listObj = (List<T>)xmlData.Deserialize(w);
                    return listObj;
                }
            }
            catch(IOException ex)
            {
                throw new IOException("Unable to open file", ex) ;
            }

        }//End function

    }
}
