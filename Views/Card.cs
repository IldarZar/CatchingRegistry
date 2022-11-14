using DocumentFormat.OpenXml.Packaging;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Words.NET;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;


namespace CatchingRegistry.Views
{
    public partial class Card : Form
    {
        string path;
        public Card()
        {
            InitializeComponent();
        }

        private void ChangeAnimalCountLabel()
        {
            var catsCount = textBoxCatsCount.Text == "" ? "0" : textBoxCatsCount.Text;
            var dogsCount = textBoxDogsCount.Text == "" ? "0" : textBoxDogsCount.Text;
            labelAnimalsCount.Text = $"{int.Parse(catsCount) + int.Parse(dogsCount)}";
        }

        private void textBoxCatsCount_TextChanged(object sender, EventArgs e)
        {
            ChangeAnimalCountLabel();
        }

        private void textBoxDogsCount_TextChanged(object sender, EventArgs e)
        {
            ChangeAnimalCountLabel();
        }

        private void textBoxCatsCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var picture = new PictureBox();
            picture.Image = Image.FromFile(@"./images/ios.png");
            picture.Size = new Size(150, 150);

            var groupBox = new GroupBox();
            groupBox.Controls.Add(picture);
            groupBox.Size = new Size(175, 175);
            groupBox.MouseClick += new MouseEventHandler((object obj, MouseEventArgs e) =>
            {
                MessageBox.Show("123");
            });
            flowLayoutPanel1.Controls.Add(groupBox);
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                File.Copy(path, Path.Combine(@"D:\\Ed\5 семестр\ПИС2\CatchingRegistry\CatchingRegistry\CatchingRegistry\images", Path.GetFileName(path)), true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @$"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\template.docx";

            Word.Application wordApp = new Word.Application();

            Word.Document document = wordApp.Documents.OpenNoRepairDialog(path, ReadOnly: true);

            ReplaceWordStub(document, new Dictionary<string, string>
            {
                {
                    "{actNumber}", 
                    "12"
                },
                {
                    "{locality}",
                    "City"
                }
            });

            Word.Table table = document.Tables[1];
            var rowsCount = table.Rows.Count;
            var columnsCount = table.Columns.Count;
            table.Cell(2, 3).Range.Text = "123";

            document.SaveAs2(FileName: @$"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\docs\result.docx");

            document.Close();
            wordApp.Quit();
        }

        private void ReplaceWordStub(Word.Document wordDocument, Dictionary<string, string> dictionary)
        {
            foreach (var record in dictionary)
            {
                var range = wordDocument.Content;
                range.Find.ClearFormatting();
                range.Find.Execute(FindText: record.Key, ReplaceWith: record.Value);
            }


       
        }
    }
}
