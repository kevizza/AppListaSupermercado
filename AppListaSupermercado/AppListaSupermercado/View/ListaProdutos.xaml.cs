﻿using AppListaSupermercado.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListaSupermercado.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaProdutos : ContentPage
    {
        public ListaProdutos()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }


        protected override void OnAppearing()
        {
            ObservableCollection<Produto> produtos = new ObservableCollection<Produto>();

            System.Threading.Tasks.Task.Run(async () =>
            {
                List<Produto> temp = await App.Database.GetAllRows();

                foreach (Produto item in temp)
                {
                    produtos.Add(item);
                }

                atualizando.IsRefreshing = false;
            });

            lista.ItemsSource = produtos;
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            ObservableCollection<Produto> produtos = new ObservableCollection<Produto>();

            MenuItem disparador = (MenuItem)sender;

            Produto produto_selecionado = (Produto)disparador.BindingContext;

            bool confirmacao = await DisplayAlert("Confirmar", "Excluir Produto da Lista", "Sim", "Não");

            if (confirmacao)
            {
                await System.Threading.Tasks.Task.Run(async () =>
                {
                    await App.Database.Delete(produto_selecionado.Id);

                    List<Produto> temp = await App.Database.GetAllRows();

                    foreach (Produto item in temp)
                    {
                        produtos.Add(item);
                    }

                    atualizando.IsRefreshing = false;
                });

                lista.ItemsSource = produtos;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.FormularioCadastro());
        }

        private void lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Produto produto_selecionado = (Produto)e.SelectedItem;

            Navigation.PushAsync(new FormularioCadastro
            {
                BindingContext = produto_selecionado
            });
        }

        private void txt_busca_TextChanged(object sender, TextChangedEventArgs e)
        {
            ObservableCollection<Produto> tarefas = new ObservableCollection<Produto>();

            string q = e.NewTextValue;

            Task.Run(async () =>
            {
                List<Produto> temp = await App.Database.Search(q);

                foreach (Produto item in temp)
                {
                    tarefas.Add(item);
                }

                atualizando.IsRefreshing = false;
            });

            lista.ItemsSource = tarefas;
        }
    }
}