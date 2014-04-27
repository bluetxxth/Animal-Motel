using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using UtilitiesLibrary;
using AnimalLibrary.Enums;
using DataAccessLayer;


using System.Data;


namespace AnimalLibrary
{
    [Serializable]
    public class AnimalManager
    {

        //instance variables
        private List<Animal> m_animals;
        private bool dataIsSaved;

        //From DALLayer
        private DataBaseAccess m_dataBase = new DataBaseAccess();


        /// <summary>
        /// Constructor1 default
        /// </summary>
        public AnimalManager()
        {
            m_animals = new List<Animal>();
        }


        /// <summary>
        /// Property provides read and write for m_animals
        /// to the list of animals
        /// </summary>
        public List<Animal> Animals
        {
            get { return this.m_animals; }
            set { this.m_animals = value; }
        }

        
        /// <summary>
        /// Method saves to database
        /// </summary>
        public void SaveToDatabase()
        {
            foreach (Animal animal in m_animals)
            {
               
                m_dataBase.NewRowInAnimals(animal.ID, animal.NickName, animal.Age, animal.Gender.ToString(), animal.Category.ToString(), animal.GetAnimalSpecificData()); 
            }
        }

        /// <summary>
        /// Method throw Animals to list from Database
        /// </summary>
        /// <returns></returns>
        public List<Animal> GetAnimals()
        {

            m_dataBase = new DataBaseAccess();
            DataTable tblData = m_dataBase.LoadAnimalData();

            return CreateAnimals(tblData);
        }

        /// <summary>
        /// Method creates animal table
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<Animal> CreateAnimals(DataTable table)
        {
            
            foreach (DataRow row in table.Rows)
            {
                m_animals.Add(CreateAnimal(row));
            }

            return m_animals;
        }

        /// <summary>
        /// Method creates animal
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public Animal CreateAnimal(DataRow row)
        {
            string creature = null;

            string objID = row["ID"].ToString();
            string objName = row["Name"].ToString();
            int objAge = int.Parse(row["Age"].ToString());
            GenderType objGender = (GenderType)row["Gender"];
            CategoryType objCategory = (CategoryType)row["Category"];
            string objInfo = row["ExtraInfo"].ToString();

            //type now known at this time
            Animal animalObject = null;


            string ID = animalObject.ID; 
            string nickName = animalObject.NickName;
            int age = animalObject.Age;
            CategoryType category = animalObject.Category;
;
            GenderType gender = animalObject.Gender;
            int numberOfTeeth = animalObject.NumberOfTeeth; 
            bool quaranteen = animalObject.Quarantine;
            int numberOfDays = animalObject.NumberOfDays;


            if (creature == "Dog")
            {
                animalObject = new Dog(ID, nickName, age, category,  gender, numberOfTeeth,  quaranteen,  numberOfDays);
            }
            else if (creature == "Cat")
            {
                animalObject = new Cat();
            }

            return animalObject; 
        }



        /// <summary>
        /// Property provides read only for m_animals.
        /// </summary>
        public int Count
        {

            get
            {
                if (m_animals != null)
                {
                    return m_animals.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Method resets counter
        /// </summary>
        public void ResetAnimalList()
        {

            m_animals.Clear();
        }

        /// <summary>
        /// Property provides read and write to dataIsSaved
        /// </summary>
        public bool DataIsSaved
        {
            get { return dataIsSaved; }
            set { dataIsSaved = value; }
        }


        /// <summary>
        /// Property provides get for ID
        /// </summary>
        public int GetNewID
        {
            get { return Count + 100; }

        }

        /// <summary>
        /// Method gets new ID
        /// </summary>
        /// <returns>An ID</returns>
        public int GetNewId()
        {
            int id = GetNewID;

            return id;

        }


        /// <summary>
        /// Add a new object to the list.
        /// The object will be appended to the 
        /// end of the list.
        /// </summary>
        /// <param name="FoodItem">The object to be added.</param>
        /// <returns>The number of items in the list - as an extra info.</returns>
        /// <remarks></remarks>
        public int Add(Animal animalItem)
        {

            string newID = GetNewID.ToString();
            m_animals.Add(animalItem);
            return m_animals.Count;
        }



        /// <summary>
        /// Retrieve an item from the list at position = index.
        /// Check the value of the index so it is within the range
        /// </summary>
        /// <param name="index">the index in question</param>
        /// <returns>The reference to the object at the position = index.</returns>
        /// <remarks>Send a copy of the object  instead of the refference would have been
        /// simpler </remarks>>
        public Animal GetAnimal(int index)
        {
            if (CheckIndex(index))
            {
                return this.m_animals[index];
            }
            else
            {
                return null;
            }
        }





        /// <summary>
        /// Method Adds animal overriden
        /// </summary>
        /// <param name="customerIn"></param>
        /// <returns>true if the customer added successfully</returns>
        public bool AddAnimal(Animal animalItem)
        {
            if (Count + 2 >= 0 && Convert.ToInt32(animalItem.ID) < m_animals.Count)
            {

                m_animals.Add(animalItem);

                animalItem.ID = GetNewID.ToString();

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method serializes object
        /// </summary>
        public Object SerializeObject(string fileName)
        {

            Object serializedObject = m_animals;
            BinarySerialization.BinaryFileSerialize(serializedObject, fileName);


            return serializedObject;
        }

        /// <summary>
        /// Method deserializes object
        /// </summary>
        /// <returns></returns>
        public Object DeserializeObject(string fileName)
        {

            Object deserializedObject =
                //BinarySerialization.BinaryFileDeserialize<Animal[]>(fileName).ToList();
                   BinarySerialization.BinaryFileDeserialize<List<Animal>>(fileName);



            return deserializedObject;
        }



        /// <summary>
        /// Check so index is with the allowed range of the colelction boundaries.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>True if index is valid, false otherwise</returns>
        /// <remarks>This function may be useful for client objects and therefore is
        /// declared public.</remarks>
        public bool CheckIndex(int index)
        {
            return (m_animals != null) & (index < m_animals.Count) & (index >= 0);
        }

        /// <summary>
        ///Method gets the animal info
        /// </summary>
        /// <returns>the customer data</returns>
        public string[] GetAnimalInfo()
        {
            string[] getAnimal = new string[m_animals.Count];

            for (int index = 0; index < (m_animals.Count); index++)
            {
                getAnimal[index] = m_animals[index].ToString();

            }

            return getAnimal;
        }


    }
}
