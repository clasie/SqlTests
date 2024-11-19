using SqlTests.Data;

namespace SqlTests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadDataBtn_Click(object sender, EventArgs e)
        {
            LoadDataAction();
        }

        private void UpdateDataBtn_Click(object sender, EventArgs e)
        {
            SqlServer.UpdateData();
            LoadDataAction();
        }
        private void LoadDataAction()
        {
            ResultRequest.Clear();
            var res = SqlServer.ReadData();
            ResultRequest.Text = res;
        }

        private void InsertDataBtn_Click(object sender, EventArgs e)
        {
            ResultRequest.Clear();
            var res = SqlServer.InsertData();
            LoadDataAction();
            MessageBox.Show($"ID added element: {res}");
        }
    }
}
