/*
 * Author Name: Pedro Mendes
 * Matric Number: 40218056
 * Class Description: Inherits from Person and implements conference attendee with the properties: attendee reference,
 * conference name, registration type, paid, presenter, paper title, institution. It implements the method getCost() which returns 
 * the conference fee for the particular attendee.
 * Date Last Modified: 2016-10-24
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _40218056_SoftDev2_CW1
{
    class Attendee : Person
    {
        // Definition of Class Attendee properties (made private)
        private int attendeeRef;
        private string conferenceName;
        private string registrationType;
        private bool paid;
        private bool presenter;
        private string paperTitle;
        public Institution institution = new Institution();

        // Definition of get() and set() methods for all the properties of Attendee class (made public)
        public int AttendeeRef
        {
            get
            {
                return attendeeRef;
            }
            set
            {
                //attendeeRef must be a value between 40000 and 60000
                if (value < 40000 || value > 60000)
                {
                    throw new ArgumentException("Error: Attendee Reference should be between 40000 and 60000!");
                }
                else
                {
                    attendeeRef = value;
                }
            }
        }
        public string ConferenceName
        {
            get
            {
                return conferenceName;
            }
            set
            {
                // conference name cannot be left blank
                if (value == "")
                {
                    throw new ArgumentException("Error: conference name connot be left blank!");
                }
                else
                {
                    conferenceName = value;
                }
            }
        }
        public string RegistrationType
        {
            get
            {
                return registrationType;
            }
            set
            {
                // Registration type cannot be left blank
                if (value != "full" && value != "student" && value != "organiser")
                {
                    throw new ArgumentException("Error: registration type can not be left blank!");
                }
                else
                {
                    registrationType = value;
                }
            }
        }
        public bool Paid
        {
            get
            {
                return paid;
            }
            set
            {
                paid = value;
            }
        }
        public bool Presenter
        {
            get
            {
                return presenter;
            }
            set
            {
                presenter = value;
            }
        }
        public string PaperTitle
        {
            get
            {
                return paperTitle;
            }
            set
            {
                //If attendee is presenting, paper title cannot be left blank
                if (value == "" && presenter)
                {
                    throw new ArgumentException("Error: paper title can not be blank if attendee is presenting!");
                }
                //If attendee is not presenting, paper title must be left blank
                else if (value != "" && !presenter)
                {
                    throw new ArgumentException("Error: paper title should be blank if attendee is not presenting!");
                }
                else
                {
                    paperTitle = value;
                }
            }
        }

        // Contructors for Class Attendee(Dont know if I need constructors)
        public Attendee()
        {
            FirstName = "Enter first name";
            SecondName = "Enter second name";
            attendeeRef = 40000;
            institution.Name = "";
            institution.Address = "";
            ConferenceName = "Enter conference name";
            RegistrationType = "full";
            Paid = false;
            Presenter = false;
            PaperTitle = "";
        }

        // getCost method takes the attendee's registration type as parameters and returns the cost
        public double getCost()
        {
            double cost = 0;
            //cost is 500 for "full" registration
            if (registrationType == "full")
            {
                cost = 500;
            }
            //cost is 300 for "student" registration
            else if (registrationType == "student")
            {
                cost = 300;
            }
            //free for organizers
            else
            {

            }

            //10% discount for presenters
            if (presenter)
            {
                cost = cost * 0.9;
            }

            return cost;
        }
    }
}
