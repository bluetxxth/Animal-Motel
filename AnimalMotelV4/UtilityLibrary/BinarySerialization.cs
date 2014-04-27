using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;







namespace UtilitiesLibrary
{
    public class BinarySerialization
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        //public static void BinaryFileSerialize <T>(T obj, string filePath){
        public static void BinaryFileSerialize(Object obj, string filePath){

            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(filePath, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fileStream, obj);



            }
            catch
            {
                throw;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }


            }

        }//end function

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T BinaryFileDeserialize<T>(string filePath)
        {

            FileStream fileStream = null;
            Object obj=null;
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("The file" + "was not found", filePath);

                }
                fileStream = new FileStream(filePath, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                obj = bf.Deserialize(fileStream);
            }
            catch
            {
                throw;
            }
            finally
            {

                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }

            return (T)obj;
        }//end function
    }
}
