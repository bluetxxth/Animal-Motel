using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalLibrary.Enums;
using System.Diagnostics;
using UtilitiesLibrary;


namespace AnimalLibrary
{
    public class MammalFactory
    {
        public static Mammal CreateMammal(MammalSpecies species)
        {

   

            Mammal animalObj = null;//Object type not known at this time
            try
            {
                //Object type determined by late binding
                switch (species)
                {

                    case MammalSpecies.Cat:

                        animalObj = new Cat();//late binding

                        break;

                    case MammalSpecies.Dog:

                        animalObj = new Dog();//late binding

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
            }
            finally
            {
                //set category
                animalObj.Category = CategoryType.Mammal;
            }
            return animalObj;

        }

    }
}
