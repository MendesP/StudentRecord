/*
 * Author Name: Pedro Mendes
 * Matric Number: 40218056
 * Class Description: This class contains the functionality of main window. 
 *                    It allows entering the details of attendee (set button) and then retrieving the details (get button).
 *                    It has a button 'invoice' that opens the invoice windows
 *                    It has a button 'certificate' that opens the certificate windows
 * Date Last Modified: 2016-10-24
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _40218056_SoftDev2_CW1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Declares an instance of attendee
        Attendee confAttendee;

        private void btn_set_Click(object sender, RoutedEventArgs e)
        {
            //create instance of attendee
            confAttendee = new Attendee();
            // Throw exception (show error message) if first name is left blank
            try
            {
                confAttendee.FirstName = txt_firstName.Text;
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }


            // Throw exception (show error message) if second name is left blank
            try
            {
                confAttendee.SecondName = txt_secondName.Text;
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }


            //check for attendee ref validity (has to be between 40000 and 60000 and a numeric value)
            try
            {
                confAttendee.AttendeeRef = Int32.Parse(txt_attendeeRef.Text);
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }


            // Gets input for the field institution name (can be left blank)
            confAttendee.institution.Name = txt_institutionName.Text;


            // Gets input for the field institution address (can be left blank)
            confAttendee.institution.Address = txt_institutionAddress.Text;


            // Throw exception (show error message) if conference name is left blank
            try
            {
                confAttendee.ConferenceName = txt_conferenceName.Text;
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }


            // Throw exception (show error message) if registration type is left blank
            try
            {
                confAttendee.RegistrationType = cmbBox_registrationType.Text;
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }


            // Gets input for the field 'paid' from a check box (true if box is ticked or false if not ticked)
            confAttendee.Paid = Convert.ToBoolean(checkBox_paid.IsChecked);


            // Gets input for the field 'presenter' from a check box (true if box is ticked or false if not ticked)
            confAttendee.Presenter = Convert.ToBoolean(checkBox_presenter.IsChecked);


            // Paper title should not be blank if attendee is a presenter (presenter = true),
            // but should be blank if attendee is not a presenter (presenter = false)
            try
            {
                confAttendee.PaperTitle = txt_paperTitle.Text;
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        // Clears the content of the text boxes on the application's main window
        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            txt_firstName.Text = "";
            txt_secondName.Text = "";
            txt_attendeeRef.Text = "";
            txt_institutionName.Text = "";
            txt_institutionAddress.Text = "";
            txt_conferenceName.Text = "";
            cmbBox_registrationType.Text = "";
            checkBox_paid.IsChecked = false;
            checkBox_presenter.IsChecked = false;
            txt_paperTitle.Text = "";
        }

        // Get the properties values from the attendee object and display them on main window
        private void btn_get_Click(object sender, RoutedEventArgs e)
        {
            //check if the attendee object is null
            if (confAttendee == null)
            {
                MessageBox.Show("Can not find attendee details");
            }
            else 
            {
                txt_firstName.Text = confAttendee.FirstName;
                txt_secondName.Text = confAttendee.SecondName;
                txt_attendeeRef.Text = confAttendee.AttendeeRef.ToString();
                txt_institutionName.Text = confAttendee.institution.Name;
                txt_institutionAddress.Text = confAttendee.institution.Address;
                txt_conferenceName.Text = confAttendee.ConferenceName;
                cmbBox_registrationType.Text = confAttendee.RegistrationType;
                checkBox_paid.IsChecked = confAttendee.Paid;
                checkBox_presenter.IsChecked = confAttendee.Presenter;
                txt_paperTitle.Text = confAttendee.PaperTitle;
            }
            
        }

        // Opens a new Window (Invoice Window) to show the institution name and address, confernece 
        private void btn_invoice_Click(object sender, RoutedEventArgs e)
        {
            Invoice invoiceWin = new Invoice(); //creates an instance of invoice window
            invoiceWin.lbl_invInstitutionName.Content = confAttendee.institution.Name;
            invoiceWin.lbl_invInstitutionAddress.Content = confAttendee.institution.Address;
            invoiceWin.lbl_invConferenceName.Content = confAttendee.ConferenceName;
            invoiceWin.lbl_invCost.Content = "£" + confAttendee.getCost();
            invoiceWin.ShowDialog();
        }

        // Opens a new window (certificate window)
        private void btn_certificate_Click(object sender, RoutedEventArgs e)
        {
            Certificate certificateWin = new Certificate();//creates an instance of certificate window
            // If attendee is not presenting do not show paper title
            if (!confAttendee.Presenter)
            {
                certificateWin.lbl_certificate.Content = "This is to certify that " + confAttendee.FirstName + " " + confAttendee.SecondName + " attended \""
                    + confAttendee.ConferenceName + "\".";
            }
            // If attendee is presenting show paper title
            else
            {
                certificateWin.lbl_certificate.Content = "This is to certify that " + confAttendee.FirstName + " " + confAttendee.SecondName + " attended \""
                    + confAttendee.ConferenceName + "\"\n" + " and presented a paper entitled \"" + confAttendee.PaperTitle + "\".";
            }
            certificateWin.ShowDialog();
        }
    }
}
