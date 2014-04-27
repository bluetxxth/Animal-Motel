using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using AnimalLibrary.Enums;
using UtilitiesLibrary;

namespace AnimalLibrary
{
    public class InsectFactory
    {

        //instance variables

        public static Insect CreateInsect(InsectSpecies species)
        {

 

            //type not known at this time 
            Insect animalObj = null;

            try
            {
                //type determined by late binding - species is an enumeration
                switch (species)
                {
                    case InsectSpecies.Bee:

                        //ID, nickName, age, category, gender
                        animalObj = new Bee(); //late binding

                        if (animalObj == null)
                        {
                            NonExistentAnimalTypeException ex = new NonExistentAnimalTypeException();

                            throw (ex);
                        }
                        break;

                    //continue with the rest
                    case InsectSpecies.Butterfly:

                        animalObj = new Butterfly(); //late binding

                        if (animalObj == null)
                        {
                            NonExistentAnimalTypeException ex = new NonExistentAnimalTypeException();

                            throw (ex);
                        }
                        break;

                    default:
                        Debug.Assert(false, "To be completed!");
                        break;

                }
            }
            //custom exception
            catch (Exception e)
            {
                e.Message.ToString();
                NonExistentAnimalTypeException ex = new NonExistentAnimalTypeException();

                throw (ex);
            }
            finally
            {

                //Set the category
                animalObj.Category = CategoryType.Insect;
            }
            return animalObj;
        }

    }
}
