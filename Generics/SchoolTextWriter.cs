using System.Collections.Generic;
using System.Text;

namespace Training.Csharp.Generics
{
    public class SchoolTextWriter<T> where T : Person
    {
        IEnumerable<T> _personCollection;

        public SchoolTextWriter(IEnumerable<T> personCollection)
        {
            _personCollection = personCollection;
        }

        public string WriteNames()
        {
            StringBuilder text = new StringBuilder();

            foreach (var person in _personCollection)
            {
                text.AppendLine(GetName(person));
            }

            return text.ToString();
        }

        public string WriteEmployeeNames<T2>() where T2 : T, ISchoolEmployee
        {
            StringBuilder text = new StringBuilder();

            foreach (var person in _personCollection)
            {
                if (person is T2)
                    text.AppendLine(GetName(person as T));
            }

            return text.ToString();
        }

        protected string GetName(T person)
        {
            return string.Format("{0}, {1}", person.LastName, person.FirstName);
        }
    }
}
