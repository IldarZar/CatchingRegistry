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
using CatchingRegistry.Models;
using Microsoft.EntityFrameworkCore;
using CatchingRegistry.Controllers;

namespace CatchingRegistry.Views
{
    public partial class Card : Form
    {
        private readonly Context context = new Context();
        private readonly CardController cardController;
        private readonly RegistryController registryController;

        Dictionary<string, string> attachments = new Dictionary<string, string>();

        public Card()
        {
            InitializeComponent();

            this.cardController = new CardController(this);
            this.registryController = new RegistryController(this);
        }

        public Card(int id)
        {
            InitializeComponent();

            textBoxCatchingActNumber.Text = $"{id}";


            var query = context.Animals.Select(animal => new
            {
                Id = animal.Id,
                Category = animal.Category,
                Gender = animal.Gender,
                Size = animal.Size,
                Features = animal.Features
            });

            dataGridViewAnimals.DataSource = query.ToList();


            var organisation = context
                .Organisations
                .Where(organisation => organisation.Employee.Id == Employee.currentId)
                .First();

            var municipalContract = context
                .MunicipalContracts
                .Where(contract => 
                    (contract.Organisation.Id == organisation.Id) && (contract.CatchingAct.Id == id)
                )
                .First();

            comboBoxMunicipalContractNumber.DataSource = context.MunicipalContracts.Where(contract => contract.Organisation.Id == organisation.Id).Select(contract => contract.Id).ToList();
            textBoxMunicipalName.Text = municipalContract.MunicipalName;
            textBoxLocalGovernment.Text = municipalContract.LocalGovernment;
            dateTimePickerMunicipalContractDate.Text = municipalContract.ContractDate.ToString();
            textBoxOrganisation.Text = municipalContract.Organisation.Name;
            textBoxLocality.Text = municipalContract.Locality;


        }

        private void ChangeAnimalCountLabel()
        {
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
            picture.Image = Image.FromFile(@$"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\images\ios.png");
            picture.Size = new Size(150, 150);

            var groupBox = new GroupBox();
            groupBox.Controls.Add(picture);
            groupBox.Size = new Size(175, 175);
            groupBox.Controls[0].MouseClick += new MouseEventHandler((object obj, MouseEventArgs e) =>
            {
                MessageBox.Show(groupBox.Controls[0].Name);
            });

            groupBox.Controls[0].Name = $"test{flowLayoutAttachmentsPanel.Controls.Count}";

            flowLayoutAttachmentsPanel.Controls.Add(groupBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Выделить отдельный метод для экспорта 

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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var animals = new List<Animal>();
            foreach (DataGridViewRow row in dataGridViewAnimals.Rows)
            {
                animals.Add(new Animal
                {
                    Id = (string)row.Cells["ColumnId"].Value,
                    Category = (string)row.Cells["ColumnCategory"].Value,
                    Gender = (string)row.Cells["ColumnGender"].Value,
                    Size = (string)row.Cells["ColumnSize"].Value,
                    Features = (string)row.Cells["ColumnFeatures"].Value
                });
            }

            context.CatchingActs.Add(new CatchingAct
            {
                DateTime = DateTime.Parse(dateTimePickerCatchingDate.Text),
                Animal = animals,
                CatchingPurpose = richTextBoxCatchingPurpose.Text
            });

            context.SaveChanges();

            Close();
        }

        private void buttonAddAnimal_Click(object sender, EventArgs e)
        {
            dataGridViewAnimals.Rows.Add(
                textBoxCheapNumber.Text,
                comboBoxCategory.Text,
                comboBoxGender.Text,
                textBoxSize.Text,
                textBoxFeatures.Text
            );
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            int catchingActNumber = int.Parse(textBoxCatchingActNumber.Text);
            CatchingAct newCatchingAct = new CatchingAct
            {
                CatchingPurpose = richTextBoxCatchingPurpose.Text,
                // ...
            };


            registryController.UpdateCatchingAct(catchingActNumber, newCatchingAct);
        }
    }
}
