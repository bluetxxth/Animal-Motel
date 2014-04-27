

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalLibrary.Enums;


namespace AnimalLibrary
{

    public abstract class Insect : Animal
    {

        //instance variables
        private bool m_ispoisonous;
        private bool canFly;

        /// <summary>
        /// Constructor default
        /// </summary>
        public Insect()
        {

        }

        /// <summary>
        /// Constructor2
        /// </summary>
        public Insect(string ID, string nickName, double age, CategoryType category, GenderType gender)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="category"></param>
        /// <param name="gender"></param>
        /// <param name="canFly"></param>
        /// <param name="quaranteen"></param>
        /// <param name="numberOfDays"></param>
        public Insect(string ID, string name, int age, CategoryType category, GenderType gender, bool canFly, bool quaranteen, int numberOfDays)
            : base(string.Empty, string.Empty, age, category, gender, canFly, quaranteen, numberOfDays)
        {


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="nickName"></param>
        /// <param name="age"></param>
        /// <param name="category"></param>
        /// <param name="gender"></param>
        /// <param name="canFly"></param>
        public Insect(string ID, string nickName, int age, CategoryType category, GenderType gender, bool canFly)
        {
            // TODO: Complete member initialization
            this.ID = ID;
            this.NickName = nickName;
            this.Age = age;
            this.Category = category;
            this.Gender = gender;
            this.canFly = canFly;
        }



        /// <summary>
        /// Property provides accessor and mutator
        /// for m_ispoisonous
        /// </summary>
        public bool IsPoisonous
        {
            get { return m_ispoisonous; }
            set { m_ispoisonous = value; }

        }


        //A VG (ECT A and B) part
        //An abstract method for insect sub classes
        /// <summary>
        /// For ll insects objects, info on their invasiveness and stinkynss
        /// should be provided
        /// </summary>
        public abstract string SetStinkAndInvasiveData();




        //A VG (ECT A and B) part
        //An abstract method for insect sub classes
        /// <summary>
        /// For ll insects objects, info on their invasiveness and stinkynss
        /// should be provided
        /// </summary>
        public abstract string InsectInfo();

    }
}
