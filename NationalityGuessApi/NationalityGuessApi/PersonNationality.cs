using System;
using System.Dynamic;

namespace NationalityGuessApi
{
    public class PersonNationality
    {
        public int Id { get; private set; }
        public NationalityEnum Nationality { get; private set; }
        public string ImagePath { get; private set; }

        public PersonNationality()
        {

        }

        public static PersonNationality CreateInstance(int id, NationalityEnum nationality, string imagePath)
        {
            if (id < 0)
            {
                throw new Exception("Id can not be negative");
            }
            if (nationality == 0)
            {
                throw new Exception("Nationality can not be in range");
            }

            var person = new PersonNationality();
            person.Id = id;
            person.Nationality = nationality;
            person.ImagePath = imagePath;

            return person;
        }
    }

    public enum NationalityEnum
    {
        KOREAN = 1,
        JAPANESE = 2,
        CHINESE = 3,
        THAI = 4,
    }
}
