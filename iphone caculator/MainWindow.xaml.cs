using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;


namespace iphone_caculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string working = "";

        public MainWindow()
        {
            InitializeComponent();
        }
        private double Evaluate(string expression)
        {
            var loDataTable = new DataTable();
            var loDataColumn = new DataColumn("Eval", typeof(double), expression);
            loDataTable.Columns.Add(loDataColumn);
            loDataTable.Rows.Add(0);
            return (double)(loDataTable.Rows[0]["Eval"]);
        }
        private bool validInput()
        {
            int count = 0;
            List<int> funcCahrIndexes = new List<int>();


            foreach (char c in working)
            {
                if (specialCharecter(charecter: c))
                {
                    funcCahrIndexes.Add(count);
                }
                count++;
            }
            int pervious = -1;
            foreach (int index in funcCahrIndexes)
            {
                if (index == 0)
                {
                    return false;
                }
                if (index == working.Length - 1)
                {
                    return false;
                }
                if (pervious != -1)
                {
                    if (index - pervious == 1)
                    {
                        return false;
                    }
                }
                pervious = index;
            }
            return true;
        }
        private bool specialCharecter(char charecter)
        {
            if (charecter == '*') return true;
            if (charecter == '/') return true;
            if (charecter == '+') return true;
            if (charecter == '-') return true;
            if (charecter == '.') return true;
            if (charecter == '%') return true;
            else return false;
        }
        private string fomatResult(double result)
        {
            if (result % 1 == 0)
            {
                return result.ToString("0.#");
            }
            else
            {
                return result.ToString("0.##");
            }
        }
        private void clearAll()
        {
            working = "";
            workingMonitor.Text = "";
            resultMonitor.Text = "0";
        }
        private void addToWorking(string vlue)
        {
            working += vlue;
            workingMonitor.Text = working;
        }
        private void equal_Click(object sender, RoutedEventArgs e)
        {
            for (int i = working.Length; i > 0; i--)
            {
                if (working[i - 1] == ')' && !specialCharecter(working[i]))
                {
                    working = working.Insert(i, "*");
                    workingMonitor.Text = working;
                }
            }
            if (validInput())
            {
                string checkedWorkingForPercent = working.Replace('%'.ToString(), "*0.01");
                var expression = Evaluate(checkedWorkingForPercent);
                string resultString = fomatResult(result: expression);
                working = "(" + working + ")";
                workingMonitor.Text = working;
                resultMonitor.Text = resultString;
            }
            else
            {
                clearAll();
                MessageBox.Show("Calculator unable to do match based on input", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dot_Click(object sender, RoutedEventArgs e)
        {
            addToWorking(vlue: ".");
        }
        private void _0_Click(object sender, RoutedEventArgs e)
        {
            addToWorking(vlue: "0");

        }
        private void _1_Click(object sender, RoutedEventArgs e)
        {
            addToWorking(vlue: "1");
        }
        private void _2_Click(object sender, RoutedEventArgs e)
        {
            addToWorking(vlue: "2");
        }
        private void _3_Click(object sender, RoutedEventArgs e)
        {
            addToWorking(vlue: "3");
        }
        private void _4_Click(object sender, RoutedEventArgs e)
        {
            addToWorking(vlue: "4");
        }
        private void _5_Click(object sender, RoutedEventArgs e)
        {
            addToWorking(vlue: "5");
        }
        private void _6_Click(object sender, RoutedEventArgs e)
        {
            addToWorking(vlue: "6");
        }
        private void _7_Click(object sender, RoutedEventArgs e)
        {
            addToWorking(vlue: "7");
        }
        private void _8_Click(object sender, RoutedEventArgs e)
        {
            addToWorking(vlue: "8");
        }
        private void _9_Click(object sender, RoutedEventArgs e)
        {
            addToWorking(vlue: "9");
        }
        private void bacTap_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(working))
            {
                if (working.Last() == ')')
                {
                    clearAll();
                }
                else
                {
                    working = working.Remove(working.Length - 1);
                    workingMonitor.Text = working;
                }

            }
        }
        private void percentage_Click(object sender, RoutedEventArgs e)
        {
            addToWorking(vlue: "%");
        }
        private void plus_Click(object sender, RoutedEventArgs e)
        {
            addToWorking(vlue: "+");
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            addToWorking(vlue: "*");
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            addToWorking(vlue: "-");
        }
        private void divide_Click(object sender, RoutedEventArgs e)
        {
            addToWorking(vlue: "/");
        }
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            clearAll();
        }
    }
}
