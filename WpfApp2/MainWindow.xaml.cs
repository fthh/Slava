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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autofac;
using BLL;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static IContainer AutofacContainer { get; set; }

        public MainWindow()
        {
            AutofacContainer = ConfigureContainer();

            InitializeComponent();
        }

        private static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new BLL.ServiceModule());
            return builder.Build();
        }

    }
}
