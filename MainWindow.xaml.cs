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
using System.Windows.Interop;

namespace POC_FilRouge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int hauteur;
        public int longueur;
        public int ecartement;
  

        RowDefinition rowdef;
        ColumnDefinition coldef;
        

        public MainWindow()
        {
            InitializeComponent();

            listBox1.Visibility = Visibility.Hidden;
             
            hauteur = (int)this.ActualHeight+100;
            longueur = (int)this.ActualWidth+100;

            for (int i = 0; i < hauteur; i++)
            {
                rowdef = new RowDefinition();
                rowdef.Height = new GridLength(35);
                this.Quadrillage.RowDefinitions.Add(rowdef);
            }

            for (int i = 0; i < longueur; i++)
            {
                coldef = new ColumnDefinition();
                coldef.Width = new GridLength(35);
                this.Quadrillage.ColumnDefinitions.Add(coldef);
            }

            ecartement = 8;
            int longMurH = 1 + ecartement;
            int hautMurV = 1 + ecartement; 

            TypedButton btnN = new TypedButton(TypedButton.type.Mur);
            Grid.SetColumn(btnN, longMurH);
            Grid.SetColumnSpan(btnN, 15);
            Grid.SetRow(btnN, 1 + ecartement);
            btnN.Click += new RoutedEventHandler(Slot_Click);
            Quadrillage.Children.Add(btnN);

            TypedButton btnS = new TypedButton(TypedButton.type.Mur);
            Grid.SetColumn(btnS, longMurH);
            Grid.SetColumnSpan(btnS, 15);
            Grid.SetRow(btnS, 10 + ecartement);
            btnS.Click += new RoutedEventHandler(Slot_Click);
            Quadrillage.Children.Add(btnS);

            TypedButton btnO = new TypedButton(TypedButton.type.Mur);
            Grid.SetColumn(btnO, hautMurV);
            Grid.SetRow(btnO, 2 + ecartement);
            Grid.SetRowSpan(btnO, 8);
            btnO.Click += new RoutedEventHandler(Slot_Click);
            Quadrillage.Children.Add(btnO);

            TypedButton btnE = new TypedButton(TypedButton.type.Mur);
            Grid.SetColumn(btnE, 14 + hautMurV);
            Grid.SetRow(btnE, 2 + ecartement);
            Grid.SetRowSpan(btnE, 8);
            btnE.Click += new RoutedEventHandler(Slot_Click);
            Quadrillage.Children.Add(btnE);

            Border border = new Border();
            border.BorderThickness = new Thickness(10, 0, 0, 0);

            foreach (TypedButton btn in Quadrillage.Children)
            {
                btn.Background = Brushes.Bisque;
            }
     
        }

        private ImageBrush ConvertBitmap(System.Drawing.Bitmap bitmapobj)
        {
            var image = bitmapobj;
            var bitmap = new System.Drawing.Bitmap(image);
            var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(),
                                                                                  IntPtr.Zero,
                                                                                  Int32Rect.Empty,
                                                                                  BitmapSizeOptions.FromEmptyOptions()
                  );
            bitmap.Dispose();
            var brush = new ImageBrush(bitmapSource);
            return brush;
        }

        private void PageFunction()
        {
            int i;
            i = 10 - 1;
        }


        #region Listeners 

        private void Choix_Click(object sender, RoutedEventArgs e)
        {
            TypedButton btn = sender as TypedButton;
            TypedButton parent = btn.parent;


            if (btn.letype == TypedButton.type.Mur)
            {
                btn.parent.Background = new SolidColorBrush(btn.color);
                int row = Grid.GetRow(btn.parent);
                int column = Grid.GetColumn(btn.parent);

                if (btn.parent.slots.Count == 0)
                {
                    TypedButton P1 = new TypedButton(TypedButton.type.Porte);
                    TypedButton F2 = new TypedButton(TypedButton.type.Fenetre);
                    TypedButton F3 = new TypedButton(TypedButton.type.Fenetre);

                    parent.slots.Add(P1);
                    parent.slots.Add(F2);
                    parent.slots.Add(F3);

                    F2.Background = ConvertBitmap(POC_FilRouge.Properties.Resources.window);
                    P1.Background = ConvertBitmap(POC_FilRouge.Properties.Resources.door);
                    F3.Background = ConvertBitmap(POC_FilRouge.Properties.Resources.window);

                    F2.Click += new RoutedEventHandler(Slot_Click);
                    P1.Click += new RoutedEventHandler(Slot_Click);
                    F3.Click += new RoutedEventHandler(Slot_Click);

                    if (Grid.GetColumnSpan(btn.parent) > 1)
                    {

                        Grid.SetColumn(P1, column + 5);
                        Grid.SetRow(P1, row);
                        Grid.SetColumn(F2, column + 2);
                        Grid.SetRow(F2, row);
                        Grid.SetColumn(F3, column + 8);
                        Grid.SetRow(F3, row);
                    }
                    else
                    {
                        Grid.SetColumn(P1, column);
                        Grid.SetRow(P1, row + 3);
                        Grid.SetColumn(F2, column);
                        Grid.SetRow(F2, row + 5);
                        Grid.SetColumn(F3, column);
                        Grid.SetRow(F3, row + 7);
                    }

                    this.Quadrillage.Children.Add(P1);
                    this.Quadrillage.Children.Add(F2);
                    this.Quadrillage.Children.Add(F3);
                }

               

                btn.parent.Background = new SolidColorBrush(btn.color);
            }
            else
            {
                

                btn.parent.Background = ConvertBitmap(btn.bitmap); 
            }

            listBox1.Visibility = Visibility.Hidden;

        }
            
        private void Slot_Click(object sender, RoutedEventArgs e)
        {
            TypedButton btn = sender as TypedButton ;

            int height = 60;
            int width = 150;

            listBox1.Items.Clear();
            listBox1.Visibility = Visibility.Visible;

            if (btn.letype == TypedButton.type.Mur)
            {

                TypedButton but_wall_blue = new TypedButton(btn);
                but_wall_blue.Height = height;
                but_wall_blue.Width = width;
                but_wall_blue.bitmap = POC_FilRouge.Properties.Resources.wall_blue;
                but_wall_blue.Background = ConvertBitmap(but_wall_blue.bitmap);
                but_wall_blue.color = Color.FromRgb(131, 176, 212);
                listBox1.Items.Add(but_wall_blue);
                but_wall_blue.Click += new RoutedEventHandler(Choix_Click);


                TypedButton but_wall_brown = new TypedButton(btn);
                but_wall_brown.Height = height;
                but_wall_brown.Width = width;
                but_wall_brown.bitmap = POC_FilRouge.Properties.Resources.wall_brown;
                but_wall_brown.Background = ConvertBitmap(but_wall_brown.bitmap);
                but_wall_brown.color = Color.FromRgb(215, 157, 109);
                listBox1.Items.Add(but_wall_brown);
                but_wall_brown.Click += new RoutedEventHandler(Choix_Click);

                TypedButton but_wall_red = new TypedButton(btn);
                but_wall_red.Height = height;
                but_wall_red.Width = width;
                but_wall_red.bitmap = POC_FilRouge.Properties.Resources.wall_red;
                but_wall_red.Background = ConvertBitmap(but_wall_red.bitmap);
                but_wall_red.color = Color.FromRgb(210, 30, 30);
                listBox1.Items.Add(but_wall_red);
                but_wall_red.Click += new RoutedEventHandler(Choix_Click);

                TypedButton but_wall_white = new TypedButton(btn);
                but_wall_white.Height = height;
                but_wall_white.Width = width;
                but_wall_white.bitmap = POC_FilRouge.Properties.Resources.wall_white;
                but_wall_white.Background = ConvertBitmap(but_wall_white.bitmap);
                but_wall_white.color = Color.FromRgb(190, 190, 190);
                listBox1.Items.Add(but_wall_white);
                but_wall_white.Click += new RoutedEventHandler(Choix_Click);

            }
            else if (btn.letype == TypedButton.type.Fenetre)
            {
                TypedButton window1 = new TypedButton(btn, TypedButton.type.Fenetre);
                window1.Height = height + 25;
                window1.Width = width + 25;
                window1.bitmap = POC_FilRouge.Properties.Resources.window1;
                window1.Background = ConvertBitmap(window1.bitmap);
                listBox1.Items.Add(window1);
                window1.Click += new RoutedEventHandler(Choix_Click);

                TypedButton window2 = new TypedButton(btn, TypedButton.type.Fenetre);
                window2.Height = height +25;
                window2.Width = width + 25;
                window2.bitmap = POC_FilRouge.Properties.Resources.window2;
                window2.Background = ConvertBitmap(window2.bitmap);
                listBox1.Items.Add(window2);
                window2.Click += new RoutedEventHandler(Choix_Click);

                TypedButton window3 = new TypedButton(btn, TypedButton.type.Fenetre);
                window3.Height = height + 25;
                window3.Width = width + 25;
                window3.bitmap = POC_FilRouge.Properties.Resources.window3;
                window3.Background = ConvertBitmap(window3.bitmap);
                listBox1.Items.Add(window3);
                window3.Click += new RoutedEventHandler(Choix_Click);

            }
            else if (btn.letype == TypedButton.type.Porte)
            {
                TypedButton door1 = new TypedButton(btn, TypedButton.type.Porte);
                door1.Height = height + 75;
                door1.Width = width;
                door1.bitmap = POC_FilRouge.Properties.Resources.door1;
                door1.Background = ConvertBitmap(door1.bitmap);
                listBox1.Items.Add(door1);
                door1.Click += new RoutedEventHandler(Choix_Click);

                TypedButton door2 = new TypedButton(btn, TypedButton.type.Porte);
                door2.Height = height + 75;
                door2.Width = width;
                door2.bitmap = POC_FilRouge.Properties.Resources.door2;
                door2.Background = ConvertBitmap(door2.bitmap);
                listBox1.Items.Add(door2);
                door2.Click += new RoutedEventHandler(Choix_Click);

                TypedButton door3 = new TypedButton(btn, TypedButton.type.Porte);
                door3.Height = height + 75;
                door3.Width = width;
                door3.bitmap = POC_FilRouge.Properties.Resources.door3;
                door3.Background = ConvertBitmap(door3.bitmap);
                listBox1.Items.Add(door3);
                door3.Click += new RoutedEventHandler(Choix_Click);

                TypedButton door4 = new TypedButton(btn, TypedButton.type.Porte);
                door4.Height = height + 75;
                door4.Width = width;
                door4.bitmap = POC_FilRouge.Properties.Resources.door4;
                door4.Background = ConvertBitmap(door4.bitmap);
                listBox1.Items.Add(door4);
                door4.Click += new RoutedEventHandler(Choix_Click);
            }
            else
            {
                return;
            }

            
        }

        private void Quadrillage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (var elem in Quadrillage.Children)
            {
                TypedButton btn = elem as TypedButton;
                btn.Visibility = Visibility.Visible;
            }
        }

        #endregion
    }
}
