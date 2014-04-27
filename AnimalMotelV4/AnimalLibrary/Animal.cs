
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalLibrary.Enums;
using UtilitiesLibrary;
using AnimalLibrary;

using System.Xml.Serialization;


namespace AnimalLibrary
{
    [Serializable]
    [XmlRoot("Animal")]
    [XmlInclude(typeof(Bird))]
    [XmlInclude(typeof(Mammal))]
    [XmlInclude(typeof(Insect))]
    [XmlInclude(typeof(Marine))]
    [XmlInclude(typeof(Reptile))]
    public abstract class Animal : AnimalLibrary.IAnimal
    {

        //instance fields

        private string m_animalID;
        private string m_nickName;
        private int m_animalAge;
        private AnimalLibrary.Enums.GenderType m_animalGender;
        private AnimalLibrary.Enums.CategoryType m_animalCategory;

        //these fields are exclusive for mammals
        private bool m_InQuarantine;
        private int m_NoOfTeeth;
        private int m_DaysInQuarantine;
        private bool quaranteen;

        //birds fields
        private double m_wingSpan;

        //insect fields
        private bool m_canFly;

        //marine fields
        private double m_depth;

        //reptile fields
        private bool m_poisonous;
        private string p;
        private string p_2;



        /// <summary>
        /// Constructor
        /// </summary>
        public Animal()
        {
            this.m_animalID = null;
            this.m_nickName = null;
            this.m_animalAge = 0;
            this.m_animalCategory = 0;
            this.m_animalGender = 0;

            ////fields for mammal
            //this.m_NoOfTeeth = 0;
            //this.m_InQuarantine = false;
            //this.m_DaysInQuarantine = 0;
        }




        /// <summary>
        /// Constructor 2
        /// </summary>
        public Animal(string name, int age, CategoryType category, GenderType gender, int numberOfTeeth, bool quaranteen, int numberOfDays)
            : this(string.Empty, string.Empty, age, category, gender, numberOfTeeth, quaranteen, numberOfDays)
        {

        }





        /// <summary>
        /// Constructor3- Overloaded
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="nickName"></param>
        /// <param name="age"></param>
        /// <param name="category"></param>
        /// <param name="gender"></param>
        /// <param name="numberOfTeeth"></param>
        /// <param name="quaranteen"></param>
        public Animal(string ID, string nickName, int age, CategoryType category, GenderType gender, int numberOfTeeth, bool quaranteen, int numberOfDays)
        {

            this.m_animalID = ID;
            this.m_nickName = nickName;
            this.m_animalAge = age;
            this.m_animalCategory = category;
            this.m_animalGender = gender;
            this.m_NoOfTeeth = numberOfTeeth;
            this.m_InQuarantine = quaranteen;
            this.m_DaysInQuarantine = numberOfDays;

        }


        /// <summary>
        /// Constructor4 - overloaded
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="nickName"></param>
        /// <param name="category"></param>
        /// <param name="gender"></param>
        /// <param name="wingSpan"></param>
        /// <param name="quaranteen"></param>
        /// <param name="numberOfDays"></param>
        public Animal(string ID, string nickName, CategoryType category, GenderType gender, double wingSpan, bool quaranteen, int numberOfDays)
        {

            this.m_animalID = ID;
            this.m_nickName = nickName;
            this.Category = category;
            this.Gender = gender;
            this.m_wingSpan = wingSpan;
            this.quaranteen = quaranteen;
            this.NumberOfDays = numberOfDays;
        }



        /// <summary>
        /// Constructor5 Overloaded
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <param name="category"></param>
        /// <param name="gender"></param>
        /// <param name="isPoisonous"></param>
        /// <param name="quaranteen"></param>
        /// <param name="numberOfDays"></param>
        public Animal(string p, string p_2, int age, CategoryType category, GenderType gender, bool m_canFly, bool quaranteen, int numberOfDays)
        {

            this.p = p;
            this.p_2 = p_2;
            this.Category = category;
            this.Gender = gender;
            this.m_canFly = m_canFly;
            this.quaranteen = quaranteen;
            this.NumberOfDays = numberOfDays;
            this.Age = age;
        }



         [XmlElement("ID")]
        /// <summary>
        /// Property - provides accessor and mutator
        /// for animalID
        /// </summary>
        public virtual string ID
        {

            get { return m_animalID; }
            set
            {
                //if no id
                if (value == null)
                {
                    //custome exception
                    InvalidValueException invalidID = new InvalidValueException();

                    throw (invalidID);
                }

                this.m_animalID = value;

            }

        }

        [XmlElement("NickName")]
        /// <summary>
        /// Property provides accessor and mutator
        /// for m_nickName
        /// </summary>
        public virtual string NickName
        {

            get { return m_nickName; }
            set
            {
                //if no nickname
                if (!(value == null))
                {

                    this.m_nickName = value;
                }
               
            }
        }



        /// <summary>
        /// Property - provide accessor for animalAge and
        /// provides mutator for animalAge
        /// </summary>
        //public virtual int Age
        //{
            

        //    get { return m_animalAge; }
        //    set
        //    {
        //        //if negative or no age
        //        if (!(value <= 0) || !(typeof(int).Equals(value.GetType())))
        //        {
        //            this.m_animalAge = value;
        //        }
                

        //    }

        //}

        [XmlElement("Age")]
        /// <summary>
        /// Property - provide accessor for animalAge and
        /// provides mutator for animalAge
        /// </summary>
        public virtual int Age
        {

            get { return m_animalAge; }
            set
            {
                //if negative or no age
                if (value <= 0)
                {

                    //custom exception
                    InvalidValueException invalidEx = new InvalidValueException();
                    throw (invalidEx);
                }
                this.m_animalAge = value;

            }

        }

        [XmlElement("Gender")]
        /// <summary>
        /// Property provide accessor and mutator for animalGender
        /// </summary>
        public virtual AnimalLibrary.Enums.GenderType Gender
        {

            get { return m_animalGender; }

            set
            {
                //if there is no gender
                if (!(value < 0))
                {
                    this.m_animalGender = value;
                }

                

            }
        }



        [XmlElement("Category")]
        /// <summary>
        /// Property provide accessor and mutator for animalCategory
        /// </summary>
        public virtual AnimalLibrary.Enums.CategoryType Category
        {

            get { return m_animalCategory; }
            set
            {
                if (!(value < 0))
                {

                    this.m_animalCategory = value;
                }
            }

        }



        [XmlElement("NumberOfTeeth")]
        /// <summary>
        /// Property provide accessor and mutator for NumberOfTeeth
        /// </summary>
        public virtual int NumberOfTeeth
        {
            get { return m_NoOfTeeth; }
            set
            {

                //if negative teeth
                if (!(value < 0))
                {
                    this.m_NoOfTeeth = value;
                }

            }

        }

        [XmlElement("NumberOfDays")]
        /// <summary>
        /// Property provide accessor and mutator for NumberOfDays
        /// </summary>
        public virtual int NumberOfDays
        {
            get { return m_DaysInQuarantine; }
            set
            {

                if (!(value < 0))
                {

                    this.m_DaysInQuarantine = value;

                }

            }

        }

        [XmlElement("Quarantine")]
        /// <summary>
        /// Property provide accessor and mutator for Quaranteen
        /// </summary>
        public virtual bool Quarantine
        {
            get { return m_InQuarantine; }
            set { this.m_InQuarantine = value; }

        }

        [XmlElement("WingSpan")]
        /// <summary>
        /// Property provides for accessor and mutator on wingSpan
        /// </summary>
        public double WingSpan
        {
            get { return m_wingSpan; }
            set
            {

                //if negative wingspan
                if (!(value < 0))
                {

                    this.m_wingSpan = value;

                }

            }


        }

        [XmlElement("Depth")]
        /// <summary>
        /// Property provides for accessor and mutator for depth
        /// </summary>
        public double Depth
        {
            get { return m_depth; }
            set
            {
                //if negative depth
                if (!(value < 0))
                {
                    {
                        this.m_depth = value;
                    }
                }

                this.m_depth = value;
            }


        }

        [XmlElement("Poisonous")]
        /// <summary>
        /// Property provides accesor and mutator for poisonous
        /// </summary>
        public bool Poisonous
        {
            get { return m_poisonous; }
            set { this.m_poisonous = value; }

        }

        [XmlElement("Flying")]
        /// <summary>
        /// Property provides accessor and mutator for flyight
        /// </summary>
        public bool Flying
        {
            get { return m_canFly; }
            set { this.m_canFly = value; }


        }



        /// <summary>
        /// Method Checks the data
        /// </summary>
        /// <returns></returns>
        public bool CheckData()
        {
            //ID
            if (String.IsNullOrEmpty(m_animalID))
            {
                return false;
                //last name
            }

            //name
            if (String.IsNullOrEmpty(m_nickName))
            {
                return false;

            }
            else
            {
                return true; // if all is okay then it is true
            }

        }

        /// <summary>
        /// Method - Gets the animals specific data
        /// </summary>
        /// <returns>the animals data</returns>
        public virtual string GetAnimalSpecificData()
        {
            string strOut = " ";


            return strOut;

        }

        ///// <summary>
        ///// Abstract method containing particular information about the animal
        ///// </summary>
        ///// <returns></returns>
        //public abstract string AnimalInfo();




        /// <summary>
        /// Method overrides ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string strOut = string.Format("{0,-20}{1, -20}{2, 35}{3, 15}", m_animalID.Trim() + m_animalCategory.ToString().Trim(), m_nickName.Trim(), m_animalAge.ToString().Trim(), m_animalGender.ToString().Trim());

            return strOut;
        }


        /// <summary>
        /// method returns category info
        /// </summary>
        /// <returns></returns>
        public virtual string CategoryInfo()
        {
            string strInfo = null;

           

            switch(Category)
            {
                case CategoryType.Bird:
                 strInfo = BirdData();
                 break;

                case CategoryType.Mammal:
                strInfo = MammalData();
                 break;

                case CategoryType.Marine:
                 strInfo = MarineData();
                 break;

                case CategoryType.Insect:
                 strInfo = InsectData();
                 break;

                case CategoryType.Reptile:
                 strInfo = ReptileData();
                 break;
            }

            return strInfo;
        }

        /// <summary>
        /// Method provides for mamal data
        /// </summary>
        /// <returns></returns>
        public virtual string MammalData()
        {
            string strOut = null;

            strOut += Environment.NewLine + "Quarantined:" + m_InQuarantine;
            strOut += Environment.NewLine + "Days in quarantine: " + m_DaysInQuarantine;
            strOut += Environment.NewLine + "Number of teeth: " + m_NoOfTeeth;

            return strOut;
        }




        /// <summary>
        /// Method provides insect data
        /// </summary>
        /// <returns></returns>
        public virtual string InsectData()
        {

            string strOut = null;

            if (m_canFly)
            {
                strOut = "This insect does fly";
            }
            else
            {
                strOut = "This insect does NOT fly";
            }

            return strOut;

        }

        /// <summary>
        /// Method provides marine data
        /// </summary>
        /// <returns></returns>
        public virtual string MarineData()
        {

            string strOut = null;

            strOut += Environment.NewLine + "Depth:" + m_depth;

            return strOut;
        }

        /// <summary>
        /// Method provides reptile data
        /// </summary>
        /// <returns></returns>
        public virtual string ReptileData()
        {

            string strOut = null;

            if (m_poisonous)
            {
                strOut = "This reptile is poisonous";
            }
            else
            {
                strOut = "This reptile is not poisonous";
            }

            return strOut;

        }



        /// <summary>
        /// Method provides bird data
        /// </summary>
        /// <returns></returns>
        public virtual string BirdData()
        {

            string strOut = null;

            strOut += Environment.NewLine + "Wing Span:" + m_wingSpan;

            return strOut;
        }




    }

}