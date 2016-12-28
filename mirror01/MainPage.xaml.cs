using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace mirror01
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //ATTRIBUTS
        //private string report;
        private ViewModel viewModel;
        private int counter;


        // CONSTRUCTEUR
        public MainPage()
        {
            this.counter = 0;

            this.InitializeComponent();

            viewModel = new ViewModel(new Model());
            this.DataContext = viewModel;

            //subscription of classes to events
            viewModel.textChanged += this.OnTextChanged;


        }

        // METHODES

        //EVENTS LISTENED AND EXECUTED
        private void ClickMe_Click(object sender, RoutedEventArgs e)
        {
            stateButton.Text = "Charlotte";
        }

        private async void OnTextChanged(string e)
        {
            counter++;

            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                textBlock.Text = e;
            });
        }
    }
}
