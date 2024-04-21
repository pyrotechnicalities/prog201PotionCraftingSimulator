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
        // - fix item values (rebalancing)
        // - items randomly worth more 
        // - investigate money not working, vendor inventory issue
        // - add items to existing stash if they're already in the inventory

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
            PlayerInventory.Text = workshop.player.ShowInventory();
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
                if (int.TryParse(Input.Text, out int value))
                {
                    if (value >= 0 && value <= workshop.RecipeCount())
                    {
                        Output.Text = $"{workshop.player.CraftItem(workshop.Recipes[value-1])}";
                        RefreshInformationDisplays();
                        Craft.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        Output.Text = "Sorry, that's not a valid input. Try again.";
                        Craft.Visibility = Visibility.Visible;
                    }
                }
            }
            else if (mode == Mode.Buy)
            {
                // on submit in buy mode
                if (int.TryParse(Input.Text, out int value))
                {
                    // add what you bought to your inventory and then subtract that amount of money
                    if (value >= 0 && value <= workshop.vendor.Inventory.Count() && workshop.HasMoney(workshop.vendor.Inventory[value - 1]) == true)
                    {
                        workshop.player.AddItem(workshop.player.Inventory[value - 1]);
                        workshop.player.RemoveCurrency(workshop.vendor.Inventory[value - 1]);
                        workshop.vendor.RemoveItem(workshop.vendor.Inventory[value - 1]);
                        RefreshInformationDisplays();
                        Output.Text = workshop.vendor.ShowInventory();
                        Buy.Visibility = Visibility.Visible;
                    }
                    else if (value >= 0 && value <= workshop.vendor.Inventory.Count() && workshop.HasMoney(workshop.vendor.Inventory[value - 1]) == false)
                    {
                        Output.Text = "Sorry, you don't have enough money to buy that.";
                        Buy.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        Output.Text = "Sorry, that's not a valid input. Try again.";
                        Buy.Visibility = Visibility.Visible;
                    }
                }
            }
            else if (mode == Mode.Sell)
            {
                // on submit in sell mode
                if (int.TryParse(Input.Text, out int value))
                {
                    // remove what you sold from your inventory and then add money to your balance
                    if (value >= 0 && value <= workshop.player.Inventory.Count())
                    {
                        workshop.player.AddCurrency(workshop.player.Inventory[value - 1]);
                        workshop.player.RemoveItem(workshop.player.Inventory[value - 1]);
                        RefreshInformationDisplays();
                        Sell.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        Output.Text = "Sorry, that's not a valid input. Try again.";
                        Sell.Visibility = Visibility.Visible;
                    }
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
            PlayerInventory.Text = workshop.player.ShowInventory();
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            Buy.Visibility = Visibility.Collapsed;
            Craft.Visibility = Visibility.Visible;
            Sell.Visibility = Visibility.Visible;
            mode = Mode.Buy;
            Output.Text = workshop.vendor.ShowInventory();
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