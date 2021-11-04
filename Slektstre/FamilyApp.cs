using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slektstre
{
    public class FamilyApp
    {
        public List<Person> PersonList; 
      
        public string WelcomeMessage = "Velkommen til FamilyApp!";
        public string CommandPrompt = "Skriv inn kommando: ";
        private string response;

        public FamilyApp(params Person[] people)
        {
            PersonList = new List<Person>(people); 
        }
        public string HandleCommand(string command)
        { 
            char space = (char)32;
            var splitCommand = command.Split(space);

            if (command == "hjelp")
            {
                response = "Tilgjengelige kommandoer er hjelp, liste og id. ";
                return response;
            }
            if ( splitCommand[0] == "vis")
            {
                response = "";
                Person thePerson = null;
                thePerson = FindPerson(splitCommand);
                if (thePerson == null) return "";
                response += thePerson.GetDescription();
                //Søk på personer med/uten barn
                if (FindChildern(thePerson).Length == 0) return response;
                response += "\n  Barn:\n";
                string result = response;
                foreach (var person in FindChildern(thePerson)) result = result + $"    {person.FirstName} (Id={person.Id}) Født: {person.BirthYear}\n";
                response = result;
                return response;
            }
            if ( command == "liste")
            {
                response = "";
                foreach (var person in PersonList)
                {
                    response += person.GetDescription();
                    response += "\n";
                }
                return response;
            }
            return " ";
        }
        private Person[] FindChildern(Person thePerson)
        {
            var children = new List<Person>();
            foreach (var people in PersonList)
            {
                if (thePerson.Id == people.Father?.Id || thePerson.Id == people.Mother?.Id)
                {
                    children.Add(people);
                }
            }
            return children.ToArray();
        }
        private Person FindPerson(string[] splitCommand)
        {
            Person foundPerson = null;
            foreach (var person in PersonList)
            {
                if (person.Id != Convert.ToInt32(splitCommand[1])) continue;
                foundPerson = person;
            }
            return foundPerson;
        }
    }
}
