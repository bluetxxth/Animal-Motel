using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalLibrary.Enums;
using UtilitiesLibrary;


namespace AnimalLibrary
{
  public  class ReptileFactory
    {


        public static Reptile CreateReptile(ReptileSpecies species)
        {


            // Object type not known at this time
            Reptile animalObj = null;

            try
            {
                switch (species)
                {

                    case ReptileSpecies.Boa:

                        animalObj = new Boa();//late binding

                        if(animalObj == null){

                            NonExistentAnimalTypeException ex = new NonExistentAnimalTypeException();
                            throw (ex);
                        }

                        break;

                    case ReptileSpecies.Chamaleon:

                        animalObj = new Chamaleon();//late binding

                        if (animalObj == null)
                        {

                            NonExistentAnimalTypeException ex = new NonExistentAnimalTypeException();
                            throw (ex);
                        }

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


                animalObj.Category = CategoryType.Reptile;
            }

            return animalObj;



        }
    }
}
