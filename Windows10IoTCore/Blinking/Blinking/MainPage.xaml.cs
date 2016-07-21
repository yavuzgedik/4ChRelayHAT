using Windows.UI.Xaml.Controls;
using System.Threading;
using Turta;

namespace Blinking
{
    public sealed partial class MainPage : Page
    {
        // Röle denetleyicisini oluştur.
        static RelayController4Ch relayController = new RelayController4Ch();

        // Röleleri açıp kapatmak için kullanılacak timer.
        // Bağlangıçta 2000ms ertelemeyle, 500ms'de bir tetiklenir.
        Timer timer = new Timer(new TimerCallback(TimerTick), null, 2000, 500);

        static int counter = 1;

        public MainPage()
        {
            this.InitializeComponent();

            // Uygulama kapanırken tetiklenecek event handler'ı oluştur.
            Unloaded += MainPage_Unloaded;
        }

        private static void TimerTick(object state)
        {
            // Röle çıkışlarını güncelle.
            relayController.SetRelay(RelayController4Ch.RelayCh.Ch1,
                counter == 2 ? RelayController4Ch.RelayState.On : RelayController4Ch.RelayState.Off);

            relayController.SetRelay(RelayController4Ch.RelayCh.Ch2,
                counter == 4 ? RelayController4Ch.RelayState.On : RelayController4Ch.RelayState.Off);

            relayController.SetRelay(RelayController4Ch.RelayCh.Ch3,
                counter == 6 ? RelayController4Ch.RelayState.On : RelayController4Ch.RelayState.Off);

            relayController.SetRelay(RelayController4Ch.RelayCh.Ch4,
                counter == 8 ? RelayController4Ch.RelayState.On : RelayController4Ch.RelayState.Off);

            // Sayacı artır.
            counter++;
            if (counter > 8)
                counter = 1;
        }

        private void MainPage_Unloaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // Uygulama kapanırken röleleri pasifleştir ve pinleri serbest bırak.
            relayController.Dispose();
        }
    }
}