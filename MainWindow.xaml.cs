/*
* Filename		:	MainWindow.xaml.cs
* Project		:	Assignment 02 
* Programmer	:	Deep Kalpeshkumar Patel
* First Version	:	25/09/2021
* Description	:	It contains functions that are creating features of Notepad
*                   such as New, Open, Save As, Close and About Notepad. User can 
*                   can open, save and edit files in Windows.
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
using Microsoft.Win32;






namespace creatingNotepad
{



    /* Name     : Notepad
    * Purpose   : Notepad is used to design a real application similiar to Notepad.
    *            It will have features of Notepad like "New", "Open", "Save As",
    *            "Close"and "Cancel". Each method will represent 1 feature as 
    *            mentioned above.    
    */
    public partial class Notepad : Window
    {
        //String that will hold the file location.
        string fileLocation="default"; 
        
        


        /*  -- Method Header Comment
	        Name	:	MainWindow --- CONSTRUCTOR 
	        Purpose :	To instantiate all the components of MainWindow().
	        Inputs	:	NONE
	        Returns	:	Nothing
        */
        public Notepad()
        {
            InitializeComponent();
        }



        /*  -- Method Header Comment
	        Name	:	MenuNew_Click 
	        Purpose :	To instantiate MenuNew_Click method.
	        Inputs	:	sender				object				
                        e                   RoutedEventArgs
	        Returns	:	Nothing
        */
        private void MenuNew_Click(object sender, RoutedEventArgs e)
        {
            //Instantiating save file dialog box.
            SaveFileDialog sfdNew = new SaveFileDialog();
            sfdNew.Filter = "Text Documents (*.txt)|*.txt|All Files|*.*";
            sfdNew.Title = "Save As";
            sfdNew.FileName = "*.txt";

            //If text box is not empty and file is not saved then it will prompt user an "Save As" box.
            if (richText.Text != "" && fileLocation == "default")
            {

                //Prompts the user if they want to save the file.
                MessageBoxResult result = MessageBox.Show("Do you want to save changes to Untitled?", "Notepad", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                switch (result)
                {

                    //If user clicks "Yes" button, it will act as an "Save As" option.
                    case MessageBoxResult.Yes:


                        //If user clicks "OK" button, it will return true.
                        bool? fileClicked = sfdNew.ShowDialog();
                        if (fileClicked == true)
                        {

                            //It will write all the text from text box to the file location user chooses.
                            System.IO.File.WriteAllText(sfdNew.FileName, richText.Text);
                            
                        }
                        else
                        {
                            return;
                        }

                        //It will set fileLocation to default and it will clear text box.
                        fileLocation = "default";
                        richText.Clear();
                        break;

                    //If the users will click "NO" button, it will clear the rich box and it will change the file location to deault.
                    case MessageBoxResult.No:
                        richText.Clear();
                        fileLocation = "default";
                        break;

                    //If the user will click "Cancel" button, it will bring user to the main window.
                    case MessageBoxResult.Cancel:
                        break;

                    default:
                        break;
                }
                
            }
            else if(richText.Text == "" && fileLocation == "default")
            {

                //If text box is empty then it will clear the rich text box.
                richText.Clear();

            }
            else
            {

                //It checks if the file location has changed from default.
                if (fileLocation != "default")
                {

                    //It will compare the content of current rich text box to the fileLocation.
                    if (richText.Text != System.IO.File.ReadAllText(fileLocation))
                    {

                        //If the contents have changed, it will prompt the user to save the file to that location.
                        MessageBoxResult result1 = MessageBox.Show("Do you want to save changes to " + fileLocation+" ?", "Notepad", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                        switch(result1)
                        {

                            //If user clicks "Yes" button, it will act as an "Save" option.
                            case MessageBoxResult.Yes:
                                //It will write all the text from text box to the file location user chooses.
                                System.IO.File.WriteAllText(fileLocation, richText.Text);

                                //It will clean the rich text box and set the fileLocation to "default".
                                fileLocation = "default";
                                richText.Clear();
                                break;

                            //If the users will click "NO" button, it will clear rich text box and set the fileLocation to "default".
                            case MessageBoxResult.No:
                                richText.Clear();
                                fileLocation = "default";
                                break;

                            //If the user will click "Cancel" button, it will bring user to the main window.
                            case MessageBoxResult.Cancel:
                                break;

                        }
                    }
                    else
                    {
                        //If the contents are same, it will clear the rich box and will set the fileLocation string to "default".
                        richText.Clear();
                        fileLocation = "default";
                    }
                }      
            }           
        }





        /*  -- Method Header Comment
	        Name	:	MenuOpen_Click 
	        Purpose :	To instantiate MenuOpen_Click method.
	        Inputs	:	sender				object				
                        e                   RoutedEventArgs
	        Returns	:	Nothing
        */
        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {

            //Instantiating open file dialog box.
            OpenFileDialog ofd = new OpenFileDialog();
            SaveFileDialog sfd = new SaveFileDialog();

            //Adding filter to Open File Dialog Box and Save File Dialog Box.
            ofd.Filter = "Text Documents (*.txt)|*.txt|All Files|*.*";
            sfd.FileName = "*.txt";
            sfd.Filter = "Text Documents (*.txt)|*.txt|All Files|*.*";
            sfd.Title = "Save As";


            //If text box is not empty and file is not saved then it will prompt user an "Save As" box.
            if (richText.Text != "" && fileLocation == "default") 
            {

                //Prompts the user if they want to save the file.
                MessageBoxResult result = MessageBox.Show("Do you want to save changes to Untitled?", "Notepad", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                switch (result)
                {

                    //If user clicks "Yes" button, it will act as an "Save As" option.
                    case MessageBoxResult.Yes:


                        //If user clicks "OK" button, it will return true.
                        bool? fileClicked = sfd.ShowDialog();
                        if (fileClicked == true)
                        {

                            //It will write all the text from text box to the file location user chooses.
                            System.IO.File.WriteAllText(sfd.FileName, richText.Text);

                        }
                        else
                        {
                            return;
                        }
                        ofd.Title = "Open";

                        if(fileClicked == true)
                        {
                            //If user clicks "OK" button, it will return true.
                            bool? fileClicked2 = ofd.ShowDialog();
                            if (fileClicked2 == true)
                            {
                                //It will read all the text from the file location user chooses.
                                richText.Text = System.IO.File.ReadAllText(ofd.FileName);

                                //It will store the location of file into a string named as fileLocation.
                                fileLocation = ofd.FileName;
                            }
                        }
                       

                        break;

                    //If the users will click "NO" button, it will open Open File Dialog Box.
                    case MessageBoxResult.No:


                        //If user clicks "OK" button, it will return true.
                        bool? fileClickedNewOpen = ofd.ShowDialog();
                        if (fileClickedNewOpen == true)
                        {

                            //It will read all the text from the file location user chooses.
                            richText.Text = System.IO.File.ReadAllText(ofd.FileName);

                            //It will store the location of file into a string named as fileLocation.
                            fileLocation = ofd.FileName;

                        }
                        break;

                    //If the user will click "Cancel" button, it will bring user to the main window.
                    case MessageBoxResult.Cancel:
                        break;

                    default:
                        break;
                }
                

            }
            else if (richText.Text == "" && fileLocation == "default")
            {

                //If text box is empty then it will directly prompt the Open File Dialog Box.
                bool? fileClickedNewOpen = ofd.ShowDialog();
                if (fileClickedNewOpen == true)
                {

                    //It will read all the text from the file location user chooses.
                    richText.Text = System.IO.File.ReadAllText(ofd.FileName);

                    //It will store the location of file into a string named as fileLocation.
                    fileLocation = ofd.FileName;

                }

            }
            else
            {

                //It checks if the file location has changed from default.
                if (fileLocation != "default")
                {

                    //It will compare the content of current rich text box to the fileLocation.
                    if (richText.Text != System.IO.File.ReadAllText(fileLocation))
                    {

                        //If the contents have changed, it will prompt the user to save the file to that location.
                        MessageBoxResult result2 = MessageBox.Show("Do you want to save changes to " + fileLocation + " ?", "Notepad", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                        switch(result2)
                        {

                            //If user clicks "Yes" button, it will act as an "Save" option.
                            case MessageBoxResult.Yes:

                                System.IO.File.WriteAllText(fileLocation, richText.Text);
                                fileLocation = "default";


                                //If user clicks "OK" button, it will return true.
                                bool? fileClicked2 = ofd.ShowDialog();
                                if (fileClicked2 == true)
                                {
                                    //It will read all the text from the file location user chooses.
                                    richText.Text = System.IO.File.ReadAllText(ofd.FileName);

                                    //It will store the location of file into a string named as fileLocation.
                                    fileLocation = ofd.FileName;
                                }
                                break;

                            case MessageBoxResult.No:


                                //If user clicks "OK" button, it will return true.
                                bool? fileClicked3 = ofd.ShowDialog();
                                if (fileClicked3 == true)
                                {

                                    //It will read all the text from the file location user chooses.
                                    richText.Text = System.IO.File.ReadAllText(ofd.FileName);

                                    //It will store the location of file into a string named as fileLocation.
                                    fileLocation = ofd.FileName;

                                }
                                break;

                            case MessageBoxResult.Cancel:
                                break;
                        }


                    }
                    else
                    {
                        //If the contents are same, then it will directly prompt user to Open File Dialog Box.


                        //If user clicks "OK" button, it will return true.
                        bool? fileClicked4 = ofd.ShowDialog();
                        if (fileClicked4 == true)
                        {

                            //It will read all the text from the file location user chooses.
                            richText.Text = System.IO.File.ReadAllText(ofd.FileName);

                            //It will store the location of file into a string named as fileLocation.
                            fileLocation = ofd.FileName;

                        }
                    }
               

                }
            }
            
        }





        /*  -- Method Header Comment
	        Name	:	MenuSaveAs_Click 
	        Purpose :	To instantiate MenuSaveAs_Click method.
	        Inputs	:	sender				object				
                        e                   RoutedEventArgs
	        Returns	:	Nothing
        */
        private void MenuSaveAs_Click(object sender, RoutedEventArgs e)
        {
            //Instantiating save file dialog box.
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "*.txt";
            sfd.Filter = "Text Documents (*.txt)|*.txt|All Files|*.*";
            bool? fileClicked3 = sfd.ShowDialog();
           

            //If users click the OK button, then it will return true.
            if (fileClicked3 == true)
            {

                //It will write all the text from text box to the file location user chooses.
                System.IO.File.WriteAllText(sfd.FileName, richText.Text);

                //It will also save the location of the file in a string.
                fileLocation = sfd.FileName;

            }


        }





        /*  -- Method Header Comment
	        Name	:	MenuClose_Click 
	        Purpose :	To instantiate MenuClose_Click method.
	        Inputs	:	sender				object				
                        e                   RoutedEventArgs
	        Returns	:	Nothing
        */
        private void MenuClose_Click(object sender, RoutedEventArgs e)
        {
            //Instantiating save file dialog box.
            SaveFileDialog sfd = new SaveFileDialog();

            //Setting up Save File Dialog Box
            sfd.FileName = "*.txt";
            sfd.Filter = "Text Documents (*.txt)|*.txt|All Files|*.*";
            sfd.Title = "Save As";

            //If text box is not empty and file is not saved then it will prompt user an "Save As" box.
            if (richText.Text != "" && fileLocation == "default") 
            {

                //Prompts the user if they want to save the file.
                MessageBoxResult result = MessageBox.Show("Do you want to save changes to Untitled?", "Notepad", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                switch (result)
                {

                    //If user clicks "Yes" button, it will act as an "Save As" option.
                    case MessageBoxResult.Yes:

                        //If user clicks "OK" button, it will return true.
                        bool? fileClicked4 = sfd.ShowDialog();
                        if (fileClicked4 == true)
                        {
                            //It will write all the text from text box to the file location user chooses.
                            System.IO.File.WriteAllText(sfd.FileName, richText.Text);
                        }
                        else
                        {
                            return;
                        }

                        //It will change the file location to default and will close the window.
                        fileLocation = "default";
                        richText.Clear();
                        Close();
                        break;

                    //If user clicks "No" button, it will clear text box,close the main window and will set file location to "default".
                    case MessageBoxResult.No:
                        richText.Clear();
                        fileLocation = "default";
                        Close();
                        break;

                    //If the user will click "Cancel" button, it will bring user to the main window.
                    case MessageBoxResult.Cancel:
                        break;

                    default:
                        break;
                }
            }
            else if(richText.Text == "" && fileLocation == "default")   
            {
                //If text box is empty then it will close the window.
                Close();
            }
            else
            {
                //It checks if the file location has changed from default.
                if (fileLocation != "default")
                {

                    //It will compare the content of current rich text box to the fileLocation.
                    if (richText.Text != System.IO.File.ReadAllText(fileLocation))
                    {

                        //If the contents have changed, it will prompt the user to save the file to that location.
                        MessageBoxResult result1 = MessageBox.Show("Do you want to save changes to " + fileLocation + " ?", "Notepad", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                        switch (result1)
                        {

                            //If user clicks "Yes" button, it will act as an "Save" option then will close the main window.
                            case MessageBoxResult.Yes:
                                System.IO.File.WriteAllText(fileLocation, richText.Text);
                                fileLocation = "default";
                                richText.Clear();
                                Close();
                                break;

                            //If user clicks "No" button, it will clear text box,close the main window and will set file location to "default".
                            case MessageBoxResult.No:
                                richText.Clear();
                                fileLocation = "default";
                                Close();
                                break;

                            //If the user will click "Cancel" button, it will bring user to the main window.
                            case MessageBoxResult.Cancel:
                                break;

                        }


                    }
                    else
                    {
                        //If the contents are same, it will clear rich box, will set file location to default and will close Main Window.
                        richText.Clear();
                        fileLocation = "default";
                        Close();
                    }
                }
            }
            
        }





        /*  -- Method Header Comment
	        Name	:	MenuAbout_Click 
	        Purpose :	To instantiate MenuAbout_Click method.
	        Inputs	:	sender				object				
                        e                   RoutedEventArgs
	        Returns	:	Nothing
        */
        private void MenuAbout_Click(object sender, RoutedEventArgs e)
        {

            //It will open  another window that will show details "About Notepad".
            Window1 aboutWindow = new Window1();
            aboutWindow.ShowDialog();
         
        }





        /*  -- Method Header Comment
	        Name	:	wordCount_SelectionChanged 
	        Purpose :	To instantiate wordCount_SelectionChanged method.
	        Inputs	:	sender				object				
                        e                   RoutedEventArgs
	        Returns	:	Nothing
        */
        private void characterCount_SelectionChanged(object sender, RoutedEventArgs e)
        {

            //It will print out character count in bottom in status bar.
            characterCount.Text = "Character Count: " + richText.Text.Length;

        }





        /*  -- Method Header Comment
	        Name	:	Window_Closing 
	        Purpose :	To instantiate Window_Closing method.
	        Inputs	:	sender				object				
                        e                   RoutedEventArgs
	        Returns	:	Nothing
        */
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Instantiating save file dialog box.
            SaveFileDialog sfd = new SaveFileDialog();


            //Setting up Save File Dialog Box
            sfd.Filter = "Text Documents (*.txt)|*.txt|All Files|*.*";
            sfd.Title = "Save As";
            sfd.FileName = "*.txt";


            //If text box is not empty and file is not saved then it will prompt user an "Save As" box.
            if (richText.Text != "" && fileLocation == "default")
            {

                //Prompts the user if they want to save the file.
                MessageBoxResult result = MessageBox.Show("Do you want to save changes to Untitled?", "Notepad", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                switch (result)
                {

                    //If user clicks "Yes" button, it will act as an "Save As" option.
                    case MessageBoxResult.Yes:

                        //If user clicks "OK" button, it will return true.
                        bool? fileClicked4 = sfd.ShowDialog();
                        if (fileClicked4 == true)
                        {
                            //It will write all the text from text box to the file location user chooses.
                            System.IO.File.WriteAllText(sfd.FileName, richText.Text);
                        }
                        else
                        {
                            e.Cancel = true;
                            return;
                        }

                        //It will change the file location to default and will close the window.
                        fileLocation = "default";
                        richText.Clear();
                        break;

                    //If user clicks "No" button, it will clear text box,close the main window and will set file location to "default".
                    case MessageBoxResult.No:
                        richText.Clear();
                        fileLocation = "default";
                        break;

                    //If the user will click "Cancel" button, it will bring user to the main window.
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;

                    default:
                        e.Cancel = true;
                        break;

                }
            }
            else if (richText.Text == "" && fileLocation == "default")
            {
                //If text box is empty then it will close the window.
            }
            else
            {
                //It checks if the file location has changed from default.
                if (fileLocation != "default")
                {

                    //It will compare the content of current rich text box to the fileLocation.
                    if (richText.Text != System.IO.File.ReadAllText(fileLocation))
                    {

                        //If the contents have changed, it will prompt the user to save the file to that location.
                        MessageBoxResult result1 = MessageBox.Show("Do you want to save changes to " + fileLocation + " ?", "Notepad", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                        switch (result1)
                        {

                            //If user clicks "Yes" button, it will act as an "Save" option then will close the main window.
                            case MessageBoxResult.Yes:
                                System.IO.File.WriteAllText(fileLocation, richText.Text);
                                fileLocation = "default";
                                richText.Clear();
                                break;

                            //If user clicks "No" button, it will clear text box,close the main window and will set file location to "default".
                            case MessageBoxResult.No:
                                richText.Clear();
                                fileLocation = "default";
                                break;

                            //If the user will click "Cancel" button, it will bring user to the main window.
                            case MessageBoxResult.Cancel:
                                e.Cancel = true;
                                break;

                            default:
                                e.Cancel = true;
                                break;

                        }


                    }
                    else
                    {
                        //If the contents are same, it will clear rich box, will set file location to default and will close Main Window.
                        richText.Clear();
                        fileLocation = "default";
                    }
                }
            }
        }
    }


}

