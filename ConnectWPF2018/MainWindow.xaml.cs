using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

// IAsyncEnumerator --- Fix con il file esterno
using System.Threading.Tasks;

namespace ConnectWPF2018
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NullReference_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            System.Diagnostics.Debug.WriteLine($"The first letter of {s} is {s[0]}");
        }

        // <NullableReferenceTypes>true</NullableReferenceTypes>
        private void NullReferenceNullable_Click(object sender, RoutedEventArgs e)
        {
            string? s = null;
            if (s != null) System.Diagnostics.Debug.WriteLine($"The first letter of {s} is {s[0]}");
        }

        // <NullableReferenceTypes>true</NullableReferenceTypes>
        private void NullReferenceOperator_Click(object sender, RoutedEventArgs e)
        {
            string? s = null;
            // null conditional indexing operator
            System.Diagnostics.Debug.WriteLine($"The first letter of {s} is {s?[0] ?? '?'}");
        }


        private void Range_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(" -- ");
            foreach (var name in GetNames())
            {
                System.Diagnostics.Debug.WriteLine(name);
            }
        }

        private void RangeExample1_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(" -- ");
            var names = GetNames().ToArray();
            Range range = 1..4;
            foreach (var name in names[range])
            {
                System.Diagnostics.Debug.WriteLine(name);
            }
        }

        private void RangeExample2_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(" -- ");
            var names = GetNames().ToArray();
            // Fino a 1 elemento dalla fine dell'array
            /*
             * Range expressions can be open at either or both ends. ..^1 means the same as 0..^1. 
             * 1.. means the same as 1..^0. 
             * And .. means the same as 0..^0: beginning to end. 
             */
            Range range = 1..^1;
            foreach (var name in names[range])
            {
                System.Diagnostics.Debug.WriteLine(name);
            }
        }
        private void AsyncStream_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(async () =>
            {
                await foreach (var name in GetNamesAsync())
                {
                    System.Diagnostics.Debug.WriteLine(name);
                }
            })
            .ConfigureAwait(false).GetAwaiter().GetResult();            
        }


        static IEnumerable<string> GetNames()
        {
            string[] names =
            {
                "Archimedes", "Pythagoras", "Euclid", "Socrates", "Plato"
            };
            foreach (var name in names)
            {
                yield return name;
            }
        }

        static async IAsyncEnumerable<string> GetNamesAsync()
        {
            string[] names =
            {
                "Archimedes", "Pythagoras", "Euclid", "Socrates", "Plato"
            };
            foreach (var name in names)
            {
                await Task.Delay(1000);
                yield return name;
            }
        }
    }
}
