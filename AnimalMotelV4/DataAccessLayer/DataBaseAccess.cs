using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DataAccessLayer
{
    public class DataBaseAccess
    {


        
        private SqlConnection mConnection;
        private SqlDataAdapter mDataAdapterAnimals;
        private SqlDataAdapter mDataAdapterMammals;
        private DataSet mDataSet;
        private  int m_dbCount;
        private string m_connString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\AnimalDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";

             
                            

        /// <summary>
        /// Constructor1 default
        /// </summary>
        public DataBaseAccess()
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
        public void SaveMammalAnimal(string AnimalID, string name, int age, string gender, string category, string AnimalType, string ExtraInfo)
        {

            try
            {
                //instantiate a sql connection
                using (mConnection = new SqlConnection(m_connString))
                {
                    //open the connection
                    mConnection.Open();
                    
                    //instantiate an adapter
                    mDataAdapterAnimals = new SqlDataAdapter("select * from tblAnimal", mConnection);

                    //instantiate dataset
                    mDataSet = new DataSet();

                    //fill adapter with dataset
                    mDataAdapterAnimals.Fill(mDataSet, "tblAnimal");


                    //isntantiate a Data row
                    DataRow row = mDataSet.Tables["tblAnimal"].NewRow();
                    
                    //bind rows to parameters
                    row["AnimalID"] = AnimalID;
                    row["Name"] = name;
                    row["Age"] = age;
                    row["Gender"] = gender;
                    row["Category"] = category;
                    row["ExtraInfo"] = ExtraInfo;

                    mDataSet.Tables["tblAnimal"].Rows.Add(row);

                    new SqlCommandBuilder(mDataAdapterAnimals);
                    mDataAdapterAnimals.Update(mDataSet.Tables["tblAnimal"]);

                }

            }
            catch
            {
                throw;
            }
            finally
            {
                //Close database connection
                mConnection.Close();
            }

        }//End function



        /// <summary>
        /// Method load animal data conects to database using connection string
        /// </summary>
        /// <returns></returns>
        public DataTable LoadAnimalData()
        {
            try
            {
                using (mConnection = new SqlConnection(m_connString))
                {
                    //connect to database
                    //mConnection.ConnectionString = 
                    //  ConfigurationManager.ConnectionStrings[m_connString].ConnectionString;
                   
                   
                    mConnection.Open();

                  string  sqlQuery = "SELECT * FROM tblAnimal";
                    mDataAdapterAnimals = new SqlDataAdapter(sqlQuery, mConnection);
                    mDataSet = new DataSet();
                    mDataAdapterAnimals.Fill(mDataSet, "tblAnimal");


                   SqlCommandBuilder sqlCommands = new SqlCommandBuilder(mDataAdapterAnimals);
                    DataTable tblData = mDataSet.Tables["tblAnimal"];

                    return tblData;
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
        public void NewRowInAnimals(string id, string name, int age, string gender, string category, string extraInfo)
        {
            try
            {


                //Should be a relaive path  to the database.
                mConnection.ConnectionString = m_connString;

                //Open database connection
                mConnection.Open();

                //The table with the animal (in the AnimalDB database)
                string sqlQuery = "SELECT * FROM tblAnimal";


                //Create an adapter to deal with the data transfer between the database and the dataset.
                mDataAdapterAnimals = new SqlDataAdapter(sqlQuery, mConnection);

                //create dataset
                mDataSet = new DataSet();


                //fill the dataset with data from the table tblAnimal
                mDataAdapterAnimals.Fill(mDataSet, "tblAnimal");

                //create a command that executes sqlQuery
                SqlCommandBuilder com = new SqlCommandBuilder(mDataAdapterAnimals);

                // Take the animal table in the dataset
                DataTable table = mDataSet.Tables["tblAnimal"];


                //Create a new row for the table in the dataset
                DataRow row = table.NewRow();

                // Add the animals attributes to corresponding column
                //All these will be found in the table in the database
                row["ID"] = Convert.ToInt32(id);
                row["Name"] = name;
                row["Age"] = age;
                row["Gender"] = gender;
                row["Category"] = category;
                // row["AnimalType"] = animalType;
                row["ExtraInfo"] = extraInfo;

                //Add the row in the database 
                table.Rows.Add(row);

                // Adapter updates the database with the data from the dataset.
                mDataAdapterAnimals.Update(mDataSet, "tblAnimal");
            }
            catch
            {
                throw;
            }
            finally
            {
                //Close database connection
                mConnection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int AnimalsDbCount
        {
            get { return this.m_dbCount; }

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
