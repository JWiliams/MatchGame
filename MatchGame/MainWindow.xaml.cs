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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetupGame();
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
                "🐱‍","🐱",
                "🦾","🦾",
                "💸","💸",
                "🙈","🙈",
            };


            Random random = new Random();

            foreach (TextBlock block in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(animalEmoji.Count); // Creating a random integer that is b/w 0 --> emoji.Count (can not exceed max value of amount of emojois)
                string nextEmoji = animalEmoji[index]; // created variable holding next emoji value (Result of random operation)
                block.Text = nextEmoji; // Change value of Text Block
                animalEmoji.RemoveAt(index); // Emoji is taken away so it will not appear more than twice in application window. 
            }
        }
    }
}
