using System;
using System.Runtime.InteropServices.ComTypes;
using MongoDB.Bson;

namespace NoSql.Core.Domain
{
    [MongoCollection("people")]
    public class Person : BaseDocument
    {

        public Person()
        {
            
        }

        public Person(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}