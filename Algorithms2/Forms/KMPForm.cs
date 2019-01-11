using Algorithms2.Algorithms;
using System.Windows.Forms;

namespace Algorithms2.Forms
{
    public partial class KMPForm : Form
    {
        private KMPProblem _kmpProblem;

        public KMPForm()
        {
            InitializeComponent();
        }

        public KMPForm(KMPProblem kmpProblem)
        {
            InitializeComponent();
            _kmpProblem = kmpProblem;
        }

        private void FindBtn_Click(object sender, System.EventArgs e)
        {
            var mainText = MainTextTb.Text;
            var patternText = PatternTb.Text;

            var kmpResult = _kmpProblem.LookForPattern(patternText, mainText);

            string result = string.Empty;

            kmpResult.ForEach(k => result += $"{k}; ");

            ResultTb.Text = result;
        }
    }
}