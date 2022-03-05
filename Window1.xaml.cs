/*
* Filename		:	Window1.xaml.cs
* Project		:	Assignment 02 
* Programmer	:	Deep Kalpeshkumar Patel
* First Version	:	25/09/2021
* Description	:	It contains a second window that will close the "About Notepad"
*                   window if user clicks the "OK" button in second window.
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
using System.Windows.Shapes;

namespace creatingNotepad
{

    /* Name     : Window1
    * Purpose   : Window1 is used to design a real application similiar to Notepad.
    *            It will have only 1 feature of Notepad that is "About Notepad". 
    *            There is 1 method in Window1 class that will describe about Notepad.    
    */
    public partial class Window1 : Window
    {

        /*  -- Method Header Comment
           Name	:	Window1 --- CONSTRUCTOR 
           Purpose :	To instantiate all the components of Window1().
           Inputs	:	NONE
           Returns	:	Nothing
       */
        public Window1()
        {
            InitializeComponent();
           
        }




        /*  -- Method Header Comment
           Name	    :	Button_Click 
           Purpose  :	To instantiate Button_Click method.
           Inputs	:	sender				object				
                        e                   RoutedEventArgs
           Returns	:	Nothing
       */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //When the user will click the "Ok" button in Window1(). It will close the whole window.
            Close();
        }
    }
}
