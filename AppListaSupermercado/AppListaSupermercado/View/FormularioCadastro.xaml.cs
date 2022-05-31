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
        }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ListaProdutos());
    }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            {
                Produto t = new Produto();
                t.Nome = txt_descricao.Text;
                t.Valor_Estimado = txt_valorestimado.Text;
                t.Valor_Pago = txt_valorpago.Text;


                await App.Database.Save(t);

                await DisplayAlert("Concluido", "O Produto foi salvo", "OK");

                await Navigation.PushAsync(new ListaProdutos());
            }
        }
    }
}