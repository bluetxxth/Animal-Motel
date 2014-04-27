
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalLibrary.Enums;


namespace AnimalLibrary
{

    public abstract class Bird : Animal
    {
        //instance variables

        private string p;
        private string p_2;
        private double wingSpan;
        private bool quaranteen;

        /// <summary>
        /// Constructor default
        /// </summary>
        public Bird()
        {

        }

        /// <summary>
        /// Constructor overloaded
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="category"></param>
        /// <param name="gender"></param>
        /// <param name="wingSpan"></param>
        /// <param name="quaranteen"></param>
        /// <param name="numberOfDays"></param>
        public Bird(string ID, string name, double age, CategoryType category, GenderType gender, double wingSpan, bool quaranteen, int numberOfDays)
        : base(string.Empty, string.Empty, category, gender, wingSpan, quaranteen, numberOfDays)

        {


        }


        /// <summary>
        /// Constructor overloaded
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <param name="category"></param>
        /// <param name="gender"></param>
        /// <param name="wingSpan"></param>
        /// <param name="quaranteen"></param>
        /// <param name="numberOfDays"></param>
        public Bird(string p, string p_2, CategoryType category, GenderType gender, double wingSpan, bool quaranteen, int numberOfDays)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.p_2 = p_2;
            this.Category = category;
            this.Gender = gender;
            this.wingSpan = wingSpan;
            this.quaranteen = quaranteen;
            this.NumberOfDays = numberOfDays;
        }
            

        /// <summary>
        /// Abstract method establishes feeding data
        /// </summary>
        /// <returns></returns>
        public abstract string SetFeedingData();


        /// <summary>
        /// Abstract method string representation of bird infor
        /// </summary>
        /// <returns></returns>
        public abstract string BirdInfo();


    }

}