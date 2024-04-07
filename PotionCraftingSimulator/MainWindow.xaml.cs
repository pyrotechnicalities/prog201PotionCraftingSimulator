using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PotionCraftingSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    enum Mode
    {
        Setup,
        Buy,
        Craft,
        Sell
    }
    public partial class MainWindow : Window
    {
        // Code framework from various examples by Janell Baxter
        // TO-DOS:
        // - basic crafting algorithm 
        // - improve basic functionality so the game is actually playable
        // - finish first prototype
        // - fix item values (rebalancing)

        Workshop workshop = new Workshop();
        Mode mode = Mode.Setup;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            SetUp();
        }
        private void RefreshInformationDisplays()
        {
            PlayerInventory.Text = workshop.ShowInventory("player");
            PlayerName.Text = workshop.ShowPlayerNameAndCurrency();
        }
        private void SetUp()
        {
            HideButtons();
            GetPlayerName();
        }
        private void GetPlayerName()
        {
            Output.Text = "Hello!\nPlease enter your name in the box below and then click the submit button.";
        }
        private void ShowMenu()
        {
            string output = $"{workshop.ShowPlayerName()}, what would you like to do?\nClick a button above to craft, trade, or see recipes.\n";
            Output.Text = output;
        }
        private void HideButtons()
        {
            Craft.Visibility = Visibility.Collapsed;
            Sell.Visibility = Visibility.Collapsed;
            Buy.Visibility = Visibility.Collapsed;
        }
        private void ShowButtons()
        {
            Craft.Visibility = Visibility.Visible;
            Sell.Visibility = Visibility.Visible;
            Buy.Visibility = Visibility.Visible;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (mode == Mode.Setup)
            {
                if (Input.Text != "")
                    workshop.SetPlayerName(Input.Text);

                mode = Mode.Buy;
                Output.Text = "";
                ShowMenu();
                RefreshInformationDisplays();
                Input.Text = "";
                ShowButtons();
                return;
            }
            else if (mode == Mode.Craft)
            {
                // on submit in craft mode
                if (workshop.CheckIfInputIsValid(Input.Text) == true)
                {
                    workshop.player.CraftItem();
                }
                else
                {
                    Output.Text = "Sorry, that's not a valid input. Try again.";
                }
            }
            else if (mode == Mode.Buy)
            {
                // on submit in buy mode
                if (workshop.CheckIfInputIsValid(Input.Text) == true)
                {
                    // add what you bought to your inventory and then subtract that amount of money
                }
                else
                {
                    Output.Text = "Sorry, that's not a valid input. Try again.";
                }
            }
            else if (mode == Mode.Sell)
            {
                // on submit in sell mode
                if (workshop.CheckIfInputIsValid(Input.Text) == true)
                {
                    // remove what you sold from your inventory and then add money to your balance
                }
                else
                {
                    Output.Text = "Sorry, that's not a valid input. Try again.";
                }
            }
            else
            {
                ShowMenu();
            }

            Input.Text = "";
        }

        private void Craft_Click(object sender, RoutedEventArgs e)
        {
            Craft.Visibility = Visibility.Collapsed;
            Sell.Visibility = Visibility.Visible;
            Buy.Visibility = Visibility.Visible;
            mode = Mode.Craft;
            Output.Text = "Select a recipe from the list to craft.\n\n" + workshop.ShowRecipes();
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            Buy.Visibility = Visibility.Collapsed;
            Craft.Visibility = Visibility.Visible;
            Sell.Visibility = Visibility.Visible;
            mode = Mode.Buy;
            Output.Text = workshop.ShowInventory("vendor");
        }

        private void Sell_Click(object sender, RoutedEventArgs e)
        {
            Sell.Visibility = Visibility.Collapsed;
            Buy.Visibility = Visibility.Visible;
            Craft.Visibility = Visibility.Visible;
            mode = Mode.Sell;
            Output.Text = "What would you like to sell?";
        }
    }
}