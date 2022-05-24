using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppListaSupermercado.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListaSupermercado.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormularioCadastro : ContentPage
    {
        public FormularioCadastro()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            Produto t = new Produto
            {
                Id = Convert.ToInt16(lbl_id.Text),
                NomeProduto = txt_name.Text,
                Quantidade = txt_quant.Text,
                PrecoEstimado = txt_precoEstim.Date,
                PrecoPago = txt_precoPago.Date,
            };

            await App.Database.Update(t);

            await DisplayAlert("Sucesso", "Atualizado no SQLite", "OK");

            await Navigation.PushAsync(new ListaProdutos());
        }
    }
}