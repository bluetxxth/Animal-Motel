using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;


namespace DALLayer
{
    class DataAccess
    {
        private SqlConnection mConnection;
        private SqlDataAdapter mDataAdapterAnimals;
        private SqlDataAdapter mDataAdapterMammals;
        private DataSet mDataSet;




        public int AnimalsDbCount
        {


        }



        /// <summary>
        /// 
        /// </summary>
        public void DeleteAnimalData()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet LoadAnimalData()
        {
            try
            {
                using (mConnection = new SqlConnection())
                {
                    mConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Assignment3CS.Properties.Settings.AnimalsDBConnectionString"].ConnectionString;
                    mConnection.Open();

                    sqlQuery = "SELECT * FROM tblAnimal";
                    mDataAdapterAnimals = new SqlDataAdapter(sqlQuery, mConnection);
                    mDataSet = new DataSet();
                    animalAdapter.Fill(mDataSet, "tblAnimal");

                    sqlCommands = new SqlCommandBuilder(animalAdapter);
                    DataTable tblData = mDataSet.Tables["tblAnimal"];

                    return mDataSet;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                mConnection.Close();
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        /// <param name="category"></param>
        /// <param name="info"></param>
        public void SaveMammalAnimal(string id, string name, int age, string gender, string category, string info)
        {

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        /// <param name="category"></param>
        /// <param name="info"></param>
        public void NewRowInAnimals(string id, string name, int age, string gender, string category, string info)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="species"></param>
        /// <param name="teeth"></param>
        /// <param name="quarantine"></param>
        public void NewRowMammals(string species, int teeth, int quarantine)
        {


        }





        /// <summary>
        /// 
        /// </summary>
        public void SetupDataAdapters()
        {

        }


    }

}