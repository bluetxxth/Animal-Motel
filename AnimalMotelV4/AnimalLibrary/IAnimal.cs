
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalLibrary.Enums;



namespace AnimalLibrary
{
    public interface IAnimal
    {

        string ID { get; set; }

        GenderType Gender { get; set;}

        int Age { get; set; }

        CategoryType Category { get; set;}

        string GetAnimalSpecificData();

    }

}