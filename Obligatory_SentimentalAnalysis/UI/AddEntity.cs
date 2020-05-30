using System;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain; 

namespace UI
{
	public partial class AddEntity : UserControl
	{
		private GeneralManagement generalManagement;
		public AddEntity(GeneralManagement management)
		{
			InitializeComponent();
			generalManagement = management;
			InitializeListOfEntities();
			DisplayDeleteButton();
		}


		private void InitializeListOfEntities()
		{
			listBoxEntities.DataSource = generalManagement.EntityManagement.AllEntities;
		}
		
		private void DisplayDeleteButton()
		{
			if (generalManagement.EntityManagement.AllEntities.Length > 0)
			{
				btnDelete.Enabled = true;
			}
			else
			{
				btnDelete.Enabled = false;
			}
		}

		private void btnAddEntity_Click(object sender, EventArgs e)
		{
			string entityText = textBoxEntity.Text;
			try
			{
				AddEntityUI();
				MessageBox.Show("Entidad agregada correctamente.");
				InitializeListOfEntities();
				ClearAllFields();
				DisplayDeleteButton();
			}
			catch (EntityManagementException ex)
			{
				labelError.Visible = true;
				labelError.Text = ex.Message; 
			}
			catch (Exception)
			{
				MessageBox.Show("Error interno del sistema");
			}
		}

		private void AddEntityUI()
		{
			Entity entity = new Entity()
			{
				EntityName = textBoxEntity.Text
			};
			generalManagement.EntityManagement.AddEntity(entity);
		}

		private void ClearAllFields()
		{
			textBoxEntity.Text = "";
			labelError.Visible = false;
			labelError.Text = ""; 
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (listBoxEntities.SelectedIndex == -1)
			{
				labelError.Visible = true;
				labelError.Text = "Error seleccione una entidad a eliminar"; 
			}
			else
			{
				DeleteEntityUI();
				DisplayDeleteButton();
				MessageBox.Show("La entidad se ha eliminado con exito.");
				InitializeListOfEntities();
			}
		}

		private void DeleteEntityUI()
		{
			Entity entity = (Entity)listBoxEntities.SelectedItem;
			generalManagement.EntityManagement.DeleteEntity(entity);
		}
	}
}
