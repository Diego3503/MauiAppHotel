namespace MauiAppHotel
{
    public partial class MainPage : ContentPage
    {
        private int adultsCount = 0;
        private int childrenCount = 0;

        public MainPage()
        {
            InitializeComponent();
        }

       
        private void OnSaveReservation(object sender, EventArgs e)
        {
  
            if (decimal.TryParse(DailyRateEntry.Text, out decimal dailyRate))
            {
              
                int totalDays = (CheckOutDatePicker.Date - CheckInDatePicker.Date).Days;

              
                if (totalDays > 0)
                {
                   
                    decimal totalCost = totalDays * dailyRate;

                    ConfirmationLabel.Text = $"Reserva feita com sucesso! \n" +
                                             $"Obrigado por se hospedar conosco.\n" +
                                             $"Valor total da estadia: R$ {totalCost:F2}";
                }
                else
                {
                    ConfirmationLabel.Text = "A data de saída deve ser posterior à data de entrada.";
                }
            }
            else
            {
                ConfirmationLabel.Text = "Por favor, insira um valor válido para a diária.";
            }
        }

       
        private void OnIncreaseAdultsClicked(object sender, EventArgs e)
        {
            adultsCount++;
            AdultsCountLabel.Text = adultsCount.ToString();
        }

       
        private void OnDecreaseAdultsClicked(object sender, EventArgs e)
        {
            if (adultsCount > 0)
            {
                adultsCount--;
                AdultsCountLabel.Text = adultsCount.ToString();
            }
        }

     
        private void OnIncreaseChildrenClicked(object sender, EventArgs e)
        {
            childrenCount++;
            ChildrenCountLabel.Text = childrenCount.ToString();
        }

        private void OnDecreaseChildrenClicked(object sender, EventArgs e)
        {
            if (childrenCount > 0)
            {
                childrenCount--;
                ChildrenCountLabel.Text = childrenCount.ToString();
            }
        }

        private async void OnAboutClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }
    }
}
