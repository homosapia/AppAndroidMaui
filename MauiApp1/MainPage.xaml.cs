using MauiApp1.Interfase;
using MauiApp1.Model;
using MauiApp1.ViewModel;
using testKyzia;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        private readonly HttpDataServices _httpData;
        private readonly ITreeBuilderServices _treeBuilder;

        public MainPage(ITreeBuilderServices treeBuilder)
        {
            InitializeComponent();
            _httpData = new HttpDataServices("484A2F3CA04D4922ADB7A0F402849DA5");
            _treeBuilder = treeBuilder;
        }

        private async void MainPage_Loaded(object sender, EventArgs e)
        {
            var responses = await _httpData.GetLocationsAsync(17);
            IEnumerable<TreeNode> nodes = _treeBuilder.BuildTree(responses);
            MainViewModel mainView = new MainViewModel();
            foreach (TreeNode node in nodes) 
            {
                mainView.Nodes.Add(node);
            }

            BindingContext = mainView;
        }

    }

}
