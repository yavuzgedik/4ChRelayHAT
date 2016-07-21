using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Turta;

namespace ButtonControl
{
    public sealed partial class MainPage : Page
    {
        // Röle denetleyicisini oluştur.
        static RelayController4Ch relayController = new RelayController4Ch();
        
        public MainPage()
        {
            this.InitializeComponent();

            // Uygulama kapanırken tetiklenecek event handler'ı oluştur.
            Unloaded += MainPage_Unloaded;
        }

        private void toggleSwitch1_Toggled(object sender, RoutedEventArgs e)
        {
            // Switch 1'in durumuna göre 1. röleyi aç ya da kapat.
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;

            if (toggleSwitch != null)
                relayController.SetRelay(RelayController4Ch.RelayCh.Ch1,
                    toggleSwitch.IsOn ? RelayController4Ch.RelayState.On : RelayController4Ch.RelayState.Off);
        }

        private void toggleSwitch2_Toggled(object sender, RoutedEventArgs e)
        {
            // Switch 2'nin durumuna göre 2. röleyi aç ya da kapat.
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;

            if (toggleSwitch != null)
                relayController.SetRelay(RelayController4Ch.RelayCh.Ch2,
                    toggleSwitch.IsOn ? RelayController4Ch.RelayState.On : RelayController4Ch.RelayState.Off);
        }

        private void toggleSwitch3_Toggled(object sender, RoutedEventArgs e)
        {
            // Switch 3'ün durumuna göre 3. röleyi aç ya da kapat.
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;

            if (toggleSwitch != null)
                relayController.SetRelay(RelayController4Ch.RelayCh.Ch3,
                    toggleSwitch.IsOn ? RelayController4Ch.RelayState.On : RelayController4Ch.RelayState.Off);
        }

        private void toggleSwitch4_Toggled(object sender, RoutedEventArgs e)
        {
            // Switch 4'ün durumuna göre 4. röleyi aç ya da kapat.
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;

            if (toggleSwitch != null)
                relayController.SetRelay(RelayController4Ch.RelayCh.Ch4,
                    toggleSwitch.IsOn ? RelayController4Ch.RelayState.On : RelayController4Ch.RelayState.Off);
        }

        private void MainPage_Unloaded(object sender, RoutedEventArgs e)
        {
            // Uygulama kapanırken röleleri pasifleştir ve pinleri serbest bırak.
            relayController.Dispose();
        }
    }
}
