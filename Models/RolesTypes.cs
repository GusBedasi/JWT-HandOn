using System.Collections.Generic;

namespace Shop.Models
{
    public static class RolesTypes
    {
        public const string Employee = "employee";
        public const string Boss = "boss";

        public static IEnumerable<string> GetValues()
        {
            yield return Employee;
            yield return Boss;
        }
    }
}