using System;
using Microsoft.Maui.Controls;

namespace CalculadoraPadrao
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            OpetionSystem();
        }

        private void OpetionSystem()
        {

            // Legenda:
            // s = sender (o que vai ser enviado pelos botões da tela pro campo etrField)
            // e = eventos (adicionar expressão, mostrar resultado, limpar ultimo digito ou limpar completamente o campo)

            btnZero.Clicked += (s, e) => AddToExpression("0");
            btnUm.Clicked += (s, e) => AddToExpression("1");
            btnDois.Clicked += (s, e) => AddToExpression("2");
            btnTres.Clicked += (s, e) => AddToExpression("3");
            btnQuatro.Clicked += (s, e) => AddToExpression("4");
            btnCinco.Clicked += (s, e) => AddToExpression("5");
            btnSeis.Clicked += (s, e) => AddToExpression("6");
            btnSete.Clicked += (s, e) => AddToExpression("7");
            btnOito.Clicked += (s, e) => AddToExpression("8");
            btnNove.Clicked += (s, e) => AddToExpression("9");
            btnVirgula.Clicked += (s, e) => AddToExpression(",");

            btnSoma.Clicked += (s, e) => AddToExpression("+");
            btnSubtracao.Clicked += (s, e) => AddToExpression("-");
            btnMultiplicacao.Clicked += (s, e) => AddToExpression("*");
            btnDivisao.Clicked += (s, e) => AddToExpression("/");

            btnApagar.Clicked += (s, e) => ClearLast();
            btnC.Clicked += (s, e) => etrField.Text = string.Empty;
            btnIgual.Clicked += (s, e) => BringResult();
        }

        private void AddToExpression(string value)
        {
            etrField.Text += value;
        }

        private void ClearLast()
        {
            if (!string.IsNullOrEmpty(etrField.Text))
            {
                etrField.Text = etrField.Text.Substring(0, etrField.Text.Length - 1);
            }
        }

        private void BringResult()
        {
            try
            {
                string expressao = etrField.Text.Replace(",", ".");
                var resultado = new System.Data.DataTable().Compute(expressao, null);
                etrField.Text = resultado.ToString().Replace(".", ",");
            }
            catch
            {
                etrField.Text = "Houve um erro ao tentar calcular.";
            }
        }
    }
}

