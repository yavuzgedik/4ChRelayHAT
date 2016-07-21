using Windows.UI.Xaml.Controls;
using Windows.Devices.Gpio;
using Turta;

namespace InputToOutput
{
    public sealed partial class MainPage : Page
    {
        // Röle denetleyicisini oluştur.
        static RelayController4Ch relayController = new RelayController4Ch();

        // Giriş pinlerini isimlendir.
        static GpioPin input1, input2, input3, input4;

        public MainPage()
        {
            this.InitializeComponent();

            // Uygulama kapanırken tetiklenecek event handler'ı oluştur.
            Unloaded += MainPage_Unloaded;

            GpioController gpioController = GpioController.GetDefault();

            // 12, 13, 16 ve 26. Girişleri aç.
            input1 = gpioController.OpenPin(12);
            input2 = gpioController.OpenPin(13);
            input3 = gpioController.OpenPin(16);
            input4 = gpioController.OpenPin(26);

            // Pinleri giriş moduna ayarla.
            input1.SetDriveMode(GpioPinDriveMode.Input);
            input2.SetDriveMode(GpioPinDriveMode.Input);
            input3.SetDriveMode(GpioPinDriveMode.Input);
            input4.SetDriveMode(GpioPinDriveMode.Input);

            // Röleleri korumak için en kısa açma / kapama süresini 5ms'e ayarla.
            input1.DebounceTimeout = new System.TimeSpan(0, 0, 0, 0, 5);
            input2.DebounceTimeout = new System.TimeSpan(0, 0, 0, 0, 5);
            input3.DebounceTimeout = new System.TimeSpan(0, 0, 0, 0, 5);
            input4.DebounceTimeout = new System.TimeSpan(0, 0, 0, 0, 5);

            // Giriş pinlerinde değişiklik olduğunda tetiklenecek event handler'ları oluştur.
            input1.ValueChanged += Input1_ValueChanged;
            input2.ValueChanged += Input2_ValueChanged;
            input3.ValueChanged += Input3_ValueChanged;
            input4.ValueChanged += Input4_ValueChanged;
        }

        private void Input1_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {
            // Input 1'in durumuna göre 1. röleyi aç ya da kapat.
            relayController.SetRelay(RelayController4Ch.RelayCh.Ch1,
                sender.Read() == GpioPinValue.High ? RelayController4Ch.RelayState.On : RelayController4Ch.RelayState.Off);
        }

        private void Input2_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {
            // Input 2'nin durumuna göre 2. röleyi aç ya da kapat.
            relayController.SetRelay(RelayController4Ch.RelayCh.Ch2,
                sender.Read() == GpioPinValue.High ? RelayController4Ch.RelayState.On : RelayController4Ch.RelayState.Off);
        }

        private void Input3_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {
            // Input 3'ün durumuna göre 3. röleyi aç ya da kapat.
            relayController.SetRelay(RelayController4Ch.RelayCh.Ch3,
                sender.Read() == GpioPinValue.High ? RelayController4Ch.RelayState.On : RelayController4Ch.RelayState.Off);
        }

        private void Input4_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {
            // Input 4'ün durumuna göre 4. röleyi aç ya da kapat.
            relayController.SetRelay(RelayController4Ch.RelayCh.Ch4,
                sender.Read() == GpioPinValue.High ? RelayController4Ch.RelayState.On : RelayController4Ch.RelayState.Off);
        }

        private void MainPage_Unloaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // Uygulama kapanırken röleleri pasifleştir ve pinleri serbest bırak.
            relayController.Dispose();
            input1.Dispose();
            input2.Dispose();
            input3.Dispose();
            input4.Dispose();
        }
    }
}
