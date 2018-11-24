using System;
using System.Windows.Forms;
using Algorithms2.Algorithms;

namespace Algorithms2.Forms
{
    public partial class HashFunctionForm : Form
    {
        private HashFunction function;

        public HashFunctionForm(HashFunction function)
        {
            InitializeComponent();

            this.function = function;
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            var message = "Dodanie wartosci ";

            var nullableValue = GetValueFromUser();

            if (nullableValue != null)
            {
                int value = nullableValue ?? default(int);

                var result = function.Insert(value);
                message += result ? "powiodło się!" : "nie powiodło się!";
                MessageBox.Show(message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var message = "Usunięcie wartosci ";

            var nullableValue = GetValueFromUser();

            if (nullableValue != null)
            {
                int value = nullableValue ?? default(int);

                var result = function.Delete(value);
                message += result ? "powiodło się!" : "nie powiodło się!";
                MessageBox.Show(message);
            }
        }

        private void MemberBtn_Click(object sender, EventArgs e)
        {
            var message = "Wartość: ";

            var nullableValue = GetValueFromUser();

            if (nullableValue != null)
            {
                int value = nullableValue ?? default(int);

                var result = function.Member(value);
                message += result ? "istnieje!" : "nie istnieje!";
                MessageBox.Show(message);
            }
        }

        private int? GetValueFromUser()
        {
            var errorMessage = string.Empty;

            int value = 0;

            if (!Int32.TryParse(ValueTb.Text, out value))
            {
                errorMessage += "Wartość powinna być liczbą naturalną\n";
            }
            else if (value < 0)
            {
                errorMessage += "Wartoć powinna być dodatnia\n";
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);

                return null;
            }

            return value;
        }
    }
}