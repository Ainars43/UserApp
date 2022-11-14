using System.Collections.Generic;
using System;
using System.Linq;

namespace Repositories.Models
{
    public class PersonsDA
    {
        private readonly PersonsContext _context;

        public PersonsDA(PersonsContext context)
        {
            _context = context;
        }

        public List<Persons> GetAll()
        {
            return _context.Persons.ToList();
        }

        public string Save(Persons person)
        {
            string result = string.Empty;
            try
            {
                var existingPerson =
                    _context.Persons.FirstOrDefault(u => u.FirstName == person.FirstName && u.LastName == person.LastName);
                if (existingPerson != null)
                {
                    existingPerson.FirstName = person.FirstName;
                    existingPerson.LastName = person.LastName;
                    existingPerson.BirthDate = person.BirthDate;
                    existingPerson.PhoneNumber = person.PhoneNumber;
                    existingPerson.Adress = person.Adress;
                    existingPerson.Action = person.Action;

                    _context.SaveChanges();
                    result = "pass";
                }
                else
                {
                    Persons newPerson = new Persons
                    {
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        BirthDate = person.BirthDate,
                        PhoneNumber = person.PhoneNumber,
                        Adress = person.Adress,
                        Action = person.Action
                    };

                    _context.Persons.Add(newPerson);

                    _context.SaveChanges();
                    result = "pass";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return result;
        }
    }
}