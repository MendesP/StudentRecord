/*
 * Author Name: Pedro Mendes
 * Matric Number: 40218056
 * Class Description: Implements a person class with the properties: first name and second name.
 * Date Last Modified: 2016-10-24
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _40218056_SoftDev2_CW1
{
    public class Person
    {
        // Definition of Class Person properties (made private)
        private string firstName;
        private string secondName;

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                // First name cannot be left blank
                if (value == "")
                {
                    throw new ArgumentException("Error: first name connot be left blank");
                }
                else
                {
                    firstName = value;
                }
            }
        }
        public string SecondName
        {
            get
            {
                return secondName;
            }
            set
            {
                // second name cannot be left blank
                if (value == "")
                {
                    throw new ArgumentException("Error: second name connot be left blank");
                }
                else
                {
                    secondName = value;
                }
            }
        }

        public Person()
        {

        }
    }
}
