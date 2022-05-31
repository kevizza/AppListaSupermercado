using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppListaSupermercado.Model;

namespace AppListaSupermercado.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProdutoAberto : ContentPage
    {
        public ProdutoAberto()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Produto t = new Produto
            {
                Id = Convert.ToInt16(lbl_id.Text),
                Nome = txt_nome.Text,
                Valor_Estimado = txt_valorestimado.Text,
                Valor_Pago = txt_valorpago.Text


            };

            await App.Database.Update(t);

            await DisplayAlert("Sucesso", "O Produto Foi atualizado", "OK");

            await Navigation.PushAsync(new ListaProdutos());
        }

    }
}