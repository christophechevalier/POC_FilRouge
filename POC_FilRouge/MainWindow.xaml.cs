using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using POC_FilRouge.Tools;

namespace POC_FilRouge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int hauteur;
        public int longueur;

        RowDefinition rowdef;
        ColumnDefinition coldef;
        public MainWindow( )
        {

         
            InitializeComponent();

            hauteur = (int)this.ActualHeight+100;
            longueur = (int)this.ActualWidth+100;

            int ecart = 8;

            for (int i = 0; i < hauteur; i++)
            {
                rowdef = new RowDefinition();
                rowdef.Height = new GridLength(30);

                Button btnO = new Button();
                btnO.Content = "M" + "\nu" + "\nr" + "\n " + "\nO" + "\nu" + "\ne" + "\ns" + "\nt";
                Grid.SetColumn(btnO, 1 + ecart);
                Grid.SetRow(btnO, 2 + ecart);
                Grid.SetRowSpan(btnO, 5);
                btnO.Click += new RoutedEventHandler(btnO_Click);
                Grille.Children.Add(btnO);

                Button btnE = new Button();
                btnE.Content = "M" + "\nu" + "\nr" + "\n " + "\nE" + "\ns" + "\nt";
                Grid.SetColumn(btnE, 11 + ecart);
                Grid.SetRow(btnE, 2 + ecart);
                Grid.SetRowSpan(btnE, 5);

                Grille.Children.Add(btnE);


                this.Grille.RowDefinitions.Add(rowdef);
            }

            for (int i = 0; i < longueur; i++)
            {
                coldef = new ColumnDefinition();
                coldef.Width = new GridLength(30);


                Button btnN = new Button();
                btnN.Content = "Mur Nord";
                Grid.SetColumn(btnN, 1 + ecart);
                Grid.SetColumnSpan(btnN, 11);
                Grid.SetRow(btnN, 1 + ecart);

                Grille.Children.Add(btnN);

                Button btnS = new Button();
                btnS.Content = "Mur Sud";
                Grid.SetColumn(btnS, 1 + ecart);
                Grid.SetColumnSpan(btnS, 11);
                Grid.SetRow(btnS, 7 + ecart);
                
                Grille.Children.Add(btnS);

                this.Grille.ColumnDefinitions.Add(coldef);
            }
          
            Border border = new Border();
            border.BorderThickness = new Thickness(10, 0, 0, 0);  
        }



        private void btnO_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.Content
            
        }

        private void btnE_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnS_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
