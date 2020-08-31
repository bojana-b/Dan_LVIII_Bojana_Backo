using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Dan_LVIII_Bojana_Backo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // below is the player enum which has two value
        // X and O
        public enum Player
        {
            X, O
        }

        // calling the player class
        Player currentPlayer;

        // creating a LIST of array of buttons
        List<Button> buttons;

        // importing the random number generator class
        Random rand = new Random();

        // set the player win integer to 0
        int playerWins = 0;

        // set the computer win integer to 0
        int computerWins = 0; 

        public MainWindow()
        {
            InitializeComponent();
            // call the set game function
            loadbuttons();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            var button = (Button)sender; // find which button was clicked
            currentPlayer = Player.X; // set the player to X
            button.Content = currentPlayer.ToString(); // change the button text to player X
            button.IsEnabled = false; // disable the button
            button.Foreground = Brushes.DarkBlue; // change the player colour to DarkBlue
            buttons.Remove(button); //remove the button from the list buttons so the AI can't click it either
            Check(); // check if the player won
            AImove(); // start the AI
        }
        private void AImove()
        {
            // THE CPU will randomly choose a button from the list to click.
            // While the array is greater than 0 the cpu will operate in the game
            // if the array is less than 0 it will stop playing
            if (buttons.Count > 0)
            {
                int index = rand.Next(buttons.Count); // generate a random number within the number of buttons available
                buttons[index].IsEnabled = false; // assign the number to the button
                                 // when the random number is generated then we will look into the list
                                 // for what that number is we select that button
                                 // for example if the number is 8
                                 // then we select the 8th button in the list
                currentPlayer = Player.O; // set the AI with O
                buttons[index].Content = currentPlayer.ToString(); // show O on the button
                buttons[index].Foreground = Brushes.DeepPink; // change the background of the button DeepPink colour
                buttons.RemoveAt(index); // remove that button from the list
                Check(); // check if the AI won anything
            }
        }
        private void loadbuttons()
        {
            // this the custom function which will load all the buttons 
            // from the form to the buttons list
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6,
            button7, button8, button9 };
        }

        private void Check()
        {
            //in this function we will check if the player or the AI has won
            // we have two very large if statements with the winning possibilities
            if (button1.Content.Equals("X") && button2.Content.Equals("X") && button3.Content.Equals("X")
            || button4.Content.Equals("X") && button5.Content.Equals("X") && button6.Content.Equals("X")
            || button7.Content.Equals("X") && button9.Content.Equals("X") && button8.Content.Equals("X")
            || button1.Content.Equals("X") && button4.Content.Equals("X") && button7.Content.Equals("X")
            || button2.Content.Equals("X") && button5.Content.Equals("X") && button8.Content.Equals("X")
            || button3.Content.Equals("X") && button6.Content.Equals("X") && button9.Content.Equals("X")
            || button1.Content.Equals("X") && button5.Content.Equals("X") && button9.Content.Equals("X")
            || button3.Content.Equals("X") && button5.Content.Equals("X") && button7.Content.Equals("X"))
            {
                // if any of the above conditions are met
                playerWins += 1;
                MessageBox.Show("You Won"); // show a message to the player
                resetGame(); // run the reset game function
            }
            // below if statement is for when the AI wins the game
            else if (button1.Content.Equals("O") && button2.Content.Equals("O") && button3.Content.Equals("O")
            || button4.Content.Equals("O") && button5.Content.Equals("O") && button6.Content.Equals("O")
            || button7.Content.Equals("O") && button9.Content.Equals("O") && button8.Content.Equals("O")
            || button1.Content.Equals("O") && button4.Content.Equals("O") && button7.Content.Equals("O")
            || button2.Content.Equals("O") && button5.Content.Equals("O") && button8.Content.Equals("O")
            || button3.Content.Equals("O") && button6.Content.Equals("O") && button9.Content.Equals("O")
            || button1.Content.Equals("O") && button5.Content.Equals("O") && button9.Content.Equals("O")
            || button3.Content.Equals("O") && button5.Content.Equals("O") && button7.Content.Equals("O"))
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                computerWins += 1;
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                resetGame(); // run the reset game function
            }
        }
        private void resetGame()
        {
            // run the load buttons function so all the buttons are inserted back in the array
            loadbuttons();
            //check each of the button with a tag of play
            foreach (Button X in buttons)
            {
                if (X.Tag.Equals("play"))
                {
                    X.IsEnabled = true; // change them all back to enabled or clickable
                    X.Content = "?"; // set the text to question mark
                    X.Background = Brushes.AntiqueWhite; // change the background colour to default button colors
                    X.Foreground = Brushes.RosyBrown;
                }
            }
        }
    }
}
