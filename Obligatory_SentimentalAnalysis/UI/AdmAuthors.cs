using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain;
using System.Threading;
using System.Text.RegularExpressions;

namespace UI
{
    public partial class AdmAuthors : UserControl
    {
        private GeneralManagement generalManagement;

        private Author authorToModify;

        public AdmAuthors(GeneralManagement management)
        {
            InitializeComponent();
            generalManagement = management;
            InitializeListOfAuthors();
            DisplayDeleteAndModifyButton();
            ClearAllFields();
            InitializeCalendar();
            DisableModifyAuthorButton();
        }


        private void DisableModifyAuthorButton()
        {
            btnModifyAuthor.Visible = false;
            btnModifyAuthor.Enabled = false;
        }

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {

            if (ContainNumeric(textBoxName.Text))
            {
                labelError.Visible = true;
                labelError.Text = "El nombre no puede contener caracteres numericos.";
            }
            else if (ContainNumeric(textBoxLastname.Text))
            {
                labelError.Visible = true;
                labelError.Text = "El apellido no puede contener caracteres numericos.";
            }
            else
            {
                try
                {
                    AddAuthorUI();
                    MessageBox.Show("Autor agregado correctamente.");
                    InitializeListOfAuthors();
                    ClearAllFields();
                    DisplayDeleteAndModifyButton();
                }
                catch (AuthorException ex)
                {
                    labelError.Visible = true;
                    labelError.Text = ex.Message;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error interno del sistema");
                }
            }
        }

        private void AddAuthorUI()
        {
            Author author = new Author()
            {
                UserName = textBoxUserName.Text,
                Name = textBoxName.Text,
                LastName = textBoxLastname.Text,
                BirthDate = dateTimePickerBirth.Value
            };
            generalManagement.AuthorManagement.AddAuthor(author);
        }

        private void DisplayDeleteAndModifyButton()
        {
            if (generalManagement.AuthorManagement.AllAuthors.Length > 0)
            {
                btnDeleteAuthor.Enabled = true;
                btnModify.Enabled = true;
            }
            else
            {
                btnDeleteAuthor.Enabled = false;
                btnModify.Enabled = false;
            }
        }

        private void InitializeListOfAuthors()
        {
            listBoxAuthors.DataSource = generalManagement.AuthorManagement.AllAuthors;
        }

        private void ClearAllFields()
        {
            textBoxUserName.Text = "";
            textBoxName.Text = "";
            textBoxLastname.Text = "";
            labelError.Visible = false;
        }

        private void btnDeleteAuthor_Click(object sender, EventArgs e)
        {
            if (listBoxAuthors.SelectedIndex == -1)
            {
                labelError.Visible = true;
                labelError.Text = "Error seleccione un autor a eliminar.";
            }
            else
            {
                DeleteAuthorUI();
                DisplayDeleteAndModifyButton();
                MessageBox.Show("El autor se ha eliminado con exito.");
                InitializeListOfAuthors();
            }
        }

        private void DeleteAuthorUI()
        {
            Author author = (Author)listBoxAuthors.SelectedItem;
            generalManagement.AuthorManagement.DeleteAuthor(author);
            generalManagement.PhraseManagement.DeletePhrasesOfAuthor(author);
            generalManagement.SentimentManagement.UpdateSentiments(generalManagement.PhraseManagement.AllPhrases); 
            generalManagement.UpdateAlarms(new RealTimeProvider());
        }

        private void InitializeCalendar()
        {
            dateTimePickerBirth.Value = DateTime.Now.AddYears(-13);
            dateTimePickerBirth.MinDate = DateTime.Now.AddYears(-100);
            dateTimePickerBirth.MaxDate = DateTime.Now.AddYears(-13);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (listBoxAuthors.SelectedIndex == -1)
            {
                labelError.Visible = true;
                labelError.Text = "Error seleccione un autor a modificar.";
            }

            else
            {
                authorToModify = (Author)listBoxAuthors.SelectedItem;
                ChargeAuthorInformation(authorToModify);
                btnModifyAuthor.Visible = true;
                btnModifyAuthor.Enabled = true;
                btnAddAuthor.Visible = false;
                btnAddAuthor.Enabled = false;
            }
        }

        private void ChargeAuthorInformation(Author aAuthor)
        {
            textBoxUserName.Text = aAuthor.UserName;
            textBoxName.Text = aAuthor.Name;
            textBoxLastname.Text = aAuthor.LastName;


            if (dateTimePickerBirth.MaxDate.Year == aAuthor.BirthDate.Year
                && dateTimePickerBirth.MaxDate.Month == aAuthor.BirthDate.Month
                && dateTimePickerBirth.MaxDate.Day == aAuthor.BirthDate.Day && dateTimePickerBirth.MaxDate.Year == DateTime.Now.AddYears(-13).Year)
            {
                dateTimePickerBirth.Value = dateTimePickerBirth.MaxDate;
            }
            else
            {
                if (dateTimePickerBirth.MaxDate.Year == aAuthor.BirthDate.Year
                && dateTimePickerBirth.MaxDate.Month == aAuthor.BirthDate.Month
                && dateTimePickerBirth.MaxDate.Day == aAuthor.BirthDate.Day && dateTimePickerBirth.MaxDate.Year == DateTime.Now.AddYears(-100).Year)
                {
                    dateTimePickerBirth.Value = dateTimePickerBirth.MinDate;
                }
                else
                {
                    dateTimePickerBirth.Value = aAuthor.BirthDate;
                }
            }
        }



        private void modifyAuthorUI()
        {
            Author copyAutor = new Author()
            {
                Name = textBoxName.Text,
                LastName = textBoxLastname.Text,
                UserName = textBoxUserName.Text,
                BirthDate = dateTimePickerBirth.Value
            };
            generalManagement.AuthorManagement.UpdateAuthorInformation(authorToModify, copyAutor);
        }

        public void DisplayAddButton()
        {
            btnAddAuthor.Visible = true;
            btnAddAuthor.Enabled = true;
            btnModifyAuthor.Visible = false;
            btnModifyAuthor.Enabled = false;
        }


        private void btnModifyAuthor_Click(object sender, EventArgs e)
        {

            if (ContainNumeric(textBoxName.Text))
            {
                labelError.Visible = true;
                labelError.Text = "El nombre no puede contener caracteres numericos.";
            }
            else if (ContainNumeric(textBoxLastname.Text))
            {
                labelError.Visible = true;
                labelError.Text = "El apellido no puede contener caracteres numericos.";
            }
            else
            {
                try
                {
                    modifyAuthorUI();
                    MessageBox.Show("Autor modificado correctamente.");
                    InitializeListOfAuthors();
                    ClearAllFields();
                    DisplayDeleteAndModifyButton();
                    DisplayAddButton();
                }
                catch (AuthorException ex)
                {
                    labelError.Visible = true;
                    labelError.Text = ex.Message;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error interno del sistema");
                }
            }
        }


        private bool ContainNumeric(String text)
        {
            if (!text.Trim().Equals(""))
            {
                return !Regex.IsMatch(text.Replace(" ", ""), @"^[a-zA-Z]+$");
            }
            return false; 
        }

    }
}
