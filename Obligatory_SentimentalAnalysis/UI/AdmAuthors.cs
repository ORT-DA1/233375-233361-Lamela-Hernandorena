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

namespace UI
{
    public partial class AdmAuthors : UserControl
    {
        private GeneralManagement generalManagement; 

        public AdmAuthors(GeneralManagement management)
        {
            InitializeComponent();
            generalManagement = management;
            InitializeListOfAuthors();
            DisplayDeleteAndModifyButton();
            ClearAllFields();
            InitializeCalendar(); 
        }

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            try
            {
                AddAuthorUI();
                MessageBox.Show("Author agregado correctamente.");
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

        private void AddAuthorUI()
        {
            Author author = new Author()
            {
                UserName = textBoxUserName.Text,
                Name = textBoxName.Text, 
                LastName = textBoxLastname.Text,
                BirthDate= dateTimePickerBirth.Value
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
            generalManagement.DeleteAuthorPhrases(author); 
        }

        private void InitializeCalendar()
        {
            dateTimePickerBirth.Value = DateTime.Now.AddYears(-13);
            dateTimePickerBirth.MinDate = DateTime.Now.AddYears(-100); 
            dateTimePickerBirth.MaxDate = DateTime.Now.AddYears(-13);
        }
        
    }
}
