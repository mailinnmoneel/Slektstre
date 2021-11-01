using System;
using System.Collections.Generic;

namespace Slektstre
{
    public class Person
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public int? BirthYear;
        public int? DeathYear;

        public Person Father;
        public Person Mother;

        public string GetDescription()
        {
            var text = "";
            if (FirstName != null) text += $"{FirstName} ";
            if (LastName != null) text += $"{LastName} ";
            text += $"(Id={Id}) ";
            if (BirthYear != null) text += $"Født: {BirthYear} ";
            if (DeathYear != null) text += $"Død: {DeathYear} ";

            if (Father != null) text += $"Far: {GetParentDescription()}";
            if (Mother != null) text += $"Mor: {GetParentDescription(false)}";
            return text.Trim();
        }
        public string GetParentDescription(bool isFather = true)
        {
            var text = "";
            var parent = isFather ? Father : Mother;
            text += $"{parent.FirstName} ";
            text += $"(Id={parent.Id}) ";
            return text;
        }
    } 
}
