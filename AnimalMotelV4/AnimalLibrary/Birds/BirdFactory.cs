using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using AnimalLibrary.Enums;
using UtilitiesLibrary;

namespace AnimalLibrary
{
  public class BirdFactory
    {

    
      public static Bird CreateBird(BirdSpecies species)
      {
          
            //type not known at this time
            Bird animalObj = null;

            try
            {

                //type determined by late binding
                switch (species)
                {
                    case BirdSpecies.Eagle:


                         animalObj = new Eagle();//late binding

                        if (animalObj == null)
                        {
                            NonExistentAnimalTypeException ex = new NonExistentAnimalTypeException();

                            throw (ex);
                        }
          

                        break;

                    case BirdSpecies.Falcon:

                        animalObj = new Falcon();//late binding

                        if (animalObj == null)
                        {
                            NonExistentAnimalTypeException ex = new NonExistentAnimalTypeException();

                            throw (ex);
                        }
                 

                        break;

                    case BirdSpecies.Duck:

                        animalObj = null;

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
            
                //set the category
                animalObj.Category = CategoryType.Bird;

       

            return animalObj;
        }
    }
}
