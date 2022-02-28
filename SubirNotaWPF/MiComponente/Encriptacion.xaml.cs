using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

namespace SubirNotaWPF.MiComponente
{
    /// <summary>
    /// Interaction logic for Encriptacion.xaml
    /// </summary>
    public partial class Encriptacion : UserControl, INotifyPropertyChanged
    {
        public string tipo_encriptacion { get; set; }
        private String input = "";
        private String output = "";
        public Encriptacion()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void encriptar_Button_Click(object sender, RoutedEventArgs e)
        {
            Output = LogicaEncriptacion.encriptar(Input, tipo_encriptacion, txt_key.Text);
        }

        private void desencriptar_Button_Click(object sender, RoutedEventArgs e)
        {
            Output = LogicaEncriptacion.desencriptar(Input, tipo_encriptacion, txt_key.Text);
        }

        public String Input
        {
            get
            {
                return this.input;
            }

            set
            {
                if (value != this.input)
                {
                    this.input = value;
                    OnPropertyChanged("Input");
                }
            }
        }

        public String Output
        {
            get
            {
                return this.output;
            }

            set
            {
                if (value != this.output)
                {
                    this.output = value;
                    OnPropertyChanged("Output");
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
