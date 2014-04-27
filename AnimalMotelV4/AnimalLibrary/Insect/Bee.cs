
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalLibrary.Enums;

namespace AnimalLibrary
{

    public class Bee : Insect
    {

        private bool m_canFly;


              public Bee():base()
        {

        }


                /// <summary>
        /// Constructor1 - default
        /// </summary>
        public Bee(string ID, string nickName, int age, CategoryType category, GenderType gender, bool canFly ):base(ID,  nickName, age, category,  gender, canFly)
        {

        }


        /// <summary>
        /// Put your documentation here
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool CanFly
        {
            get { return m_canFly; }
            set { m_canFly = value; }
        }



        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public override string GetAnimalSpecificData()
        {
     
            string strout = null;

            if (m_canFly)
            {
               
                strout += Environment.NewLine + InsectInfo();
            }
            strout += Environment.NewLine + SetStinkAndInvasiveData();
            strout += (IsPoisonous ? "This bee type is poisonous." : "This bee type is not poisonous.");
            strout += Environment.NewLine + InsectInfo();
            return strout;
        }


        //A VG (ECT A and B) part
        //An abstract method for insect sub classes
        /// <summary>
        /// For ll insects objects, info on their invasiveness and stinkynss
        /// should be provided
        /// </summary>
        public override string SetStinkAndInvasiveData()
        {
            string strOut = null;
            strOut = "Bees can sting special. Take special care if allergic";

            return strOut;
        }


        //A VG (ECT A and B) part
        //An abstract method for sub classes
        /// <summary>
        /// For ll insects objects, info on their fligh ability
        /// should be provided
        /// </summary>
        public override string InsectInfo()
        {
            string strOut = null;


            strOut = base.InsectData();

            return strOut;
        }






        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public override string AnimalInfo()
        //{
        //    string strOut = null;

        //    strOut = string.Format("\t{0,-20}{1, -20}{2, -3}{3, -5}", m_animalID, m_nickName, m_animalAge, m_animalCategory, m_animalGender);

        //    return strOut;

        //}

    }

}