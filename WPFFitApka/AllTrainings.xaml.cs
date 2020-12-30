using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FitApka.Controller;

namespace WPFFitApka
{
    /// <summary>
    /// Logika interakcji dla klasy AllTrainings.xaml
    /// </summary>
    public partial class AllTrainings : Window
    {
        public int index = -1;
        public AllTrainings()
        {
            InitializeComponent();
            
        }

        private void AddTraining(object sender, RoutedEventArgs e)
        {
            if(AllTrainingsListBox.SelectedIndex>-1)
            {
                index = AllTrainingsListBox.SelectedIndex;
                DialogResult = true;
            }
            else
                DialogResult = false;

            this.Close();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
