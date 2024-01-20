namespace TAMB
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            // iPhone 14 Pro Max dimensions
            var window = base.CreateWindow(activationState);
            window.Width = 430;
            window.Height = 932;
            return window;
        }
    }
}
