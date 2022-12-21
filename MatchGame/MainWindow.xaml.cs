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

namespace MatchGame
{
    using System.Threading;
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondElasped;
        int matchesFound;

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetupGame();

            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondElasped++;
            timeTextBlock.Text = (tenthsOfSecondElasped / 10F).ToString();
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }
        }


        // Method

        public void SetupGame()
        {
            List<string> animalEmoji = new List<string>
            {
                "👀","👀",
                "👽","👽",
                "😴","😴",
                "👍🏾","👍🏾",
                "👎🏾","👎🏾",
                "🦾","🦾",
                "💸","💸",
                "🙈","🙈",
            };


            Random random = new Random();

            foreach (TextBlock block in mainGrid.Children.OfType<TextBlock>())
            {
                if (block.Name != "timeTextBlock")
                {
                    int index = random.Next(animalEmoji.Count); // Creating a random integer that is b/w 0 --> emoji.Count (can not exceed max value of amount of emojois)
                    string nextEmoji = animalEmoji[index]; // created variable holding next emoji value (Result of random operation)
                    block.Text = nextEmoji; // Change value of Text Block
                    animalEmoji.RemoveAt(index); // Emoji is taken away from emojiList (animalEmoji) so it will not appear more than twice in application window. 
                }

                
            }
            timer.Start();
            tenthsOfSecondElasped = 0;
            matchesFound = 0;
        }


        TextBlock lastTextBlock;
        bool findingMatch = false; // The process for finding match is not activated at this time of code. (Bc player is just choosing a pic first)
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock block = sender as TextBlock;   // This takes the sender argument and cast it as a TextBlock data type making block a TextBlock object
            if (findingMatch == false)
            {
                block.Visibility = Visibility.Hidden; // In "Not finding match mode (findingMatch == false)" The first click on an icon will make it disappear
                lastTextBlock = block;
                findingMatch = true; // This where we get in "Finding match mode" 
            }

            else if (block.Text == lastTextBlock.Text) /* If we get to this if-statement then that means we are in "Finding match mode" and a click on an 
                                                        * element will compare it to the last element clicked. If they are the same then the code below 
                                                        * executes */

            {
                matchesFound++;
                block.Visibility = Visibility.Hidden;
                findingMatch = false; // Setting findingMatch to false will allow us to find another pair by letting us click and make disapper its first elemtn
                
            }

            // This is when an unmatched pair is selected.
            else
            {
                lastTextBlock.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }

        private void timeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound >= 7 )
            {
                InitializeComponent();
                SetupGame();
            }
        }
    }
}
