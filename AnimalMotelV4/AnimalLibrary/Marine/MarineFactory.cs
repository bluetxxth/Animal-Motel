using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using AnimalLibrary.Enums;
using UtilitiesLibrary;

namespace AnimalLibrary
{
   public class MarineFactory
    {
        public static Marine CreateMarine(MarineSpecies species){




            //type not known at this time
            Marine animalObj = null;

            try
            {
                //type determined by late binding
                switch (species)
                {

                    case MarineSpecies.Shark:

                        animalObj = new Shark(); //late binding

                        if (animalObj == null)
                        {
                            NonExistentAnimalTypeException ex = new NonExistentAnimalTypeException();

                            throw (ex);
                        }

                        break;


                    case MarineSpecies.Turtle:

                        animalObj = new Turtle(); //late binding

                        if (animalObj == null)
                        {
                            NonExistentAnimalTypeException ex = new NonExistentAnimalTypeException();

                            throw (ex);
                        }

                        break;

                    default:

                        Debug.Assert(false, "to be completed");

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

                //set the category
                animalObj.Category = CategoryType.Marine;

            }
            return animalObj;


        }
    }
}
