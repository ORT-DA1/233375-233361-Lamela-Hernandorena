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

namespace UI
{
	public partial class AddAlarm : UserControl
	{
		private GeneralManagement generalManagement;
		public AddAlarm(GeneralManagement management)
		{
			InitializeComponent();
			generalManagement = management;
			InitializeEntities();
			RefreshGridAlarms();
			ChangeNameOfColumnGrid();
			DeleteText();
		}

		private void InitializeEntities()
		{
			cmbEntities.DataSource = generalManagement.EntityManagement.AllEntities;
		}
		
		private void RefreshGridAlarms()
		{
			grdAlarms.DataSource = generalManagement.AlarmManagement.AllAlarms;
			//ChangeValuesOfGrid();
		}

		private void ChangeNameOfColumnGrid()
		{
			for (int i = 0; i < grdAlarms.Columns.Count; i++)
			{

				string str = grdAlarms.Columns[i].HeaderText;
				if (str == "Entity")
				{
					grdAlarms.Columns[i].HeaderText = "Entidad";
					grdAlarms.Columns[i].Name = "Entidad";
				}

				if (str == "TypeOfAlarm")
				{
					grdAlarms.Columns[i].HeaderText = "Tipo de alarma";
					grdAlarms.Columns[i].Name = "Tipo de alarma";
				
				}

				if (str == "QuantityPost")
				{
					grdAlarms.Columns[i].HeaderText = "Cantidad de posts";
					grdAlarms.Columns[i].Name = "Cantidad de posts";
				}

				if (str == "QuantityTime")
				{
					grdAlarms.Columns[i].HeaderText = "Cantidad de tiempo";
					grdAlarms.Columns[i].Name = "Cantidad de tiempo";
				}

				if (str == "Active")
				{
					grdAlarms.Columns[i].HeaderText = "Estado";
					grdAlarms.Columns[i].Name = "Estado";
				}

				if (str == "IsInHours")
				{
					grdAlarms.Columns[i].HeaderText = "En horas";
					grdAlarms.Columns[i].Name = "En horas";
				}
			}
		}

		/*

		private void ChangeValuesOfGrid()
		{
			DataGridViewColumn TipoDeAlarma = new DataGridViewColumn();


			TipoDeAlarma.Name("Tipo de alarma"); 

			grdAlarms.Columns.Add()


			for (int column = 0; column < grdAlarms.Columns.Count; column++)
			{
				for (int row = 0; row < grdAlarms.Rows.Count; row++)
				{

					if (grdAlarms.Columns[column].Name.Equals("Tipo de alarma"))
					{
						string typeAlarm = grdAlarms.Rows[row].Cells[column].FormattedValue.ToString();

						if (typeAlarm.Equals("Positive"))
						{
							grdAlarms.Rows[row].Cells[column].Value = "Positivo";
						}
						else
						{
							grdAlarms.Rows[row].Cells[column].Value = "Negativo";
						}

					}
				}
			}
		}

	*/ 


		private void DeleteText()
		{
			if (generalManagement.EntityManagement.AllEntities.Length > 0)
			{
				cmbEntities.SelectedIndex = 0;
			}
			CleanRadioButtons();
			textBoxQuantityPost.Text = "";
			textBoxQuantityTime.Text = "";
			labelError.Text = "";
			labelError.Visible = true; 
		}

		private void CleanRadioButtons()
		{
			radioButtonDays.Checked = false;
			radioButtonHours.Checked = false;
			radioButtonNegative.Checked = false;
			radioButtonPositive.Checked = false;
		}

		private void BtnAddAlarm_Click(object sender, EventArgs e)
		{
			if (cmbEntities.SelectedIndex == -1)
			{
				labelError.Visible = true;
				labelError.Text = "Error. Debe seleccionar una entidad"; 
			}
			else if (!IsCheckedTypeOfAlarm())
			{
				labelError.Visible = true;
				labelError.Text = "Error. Debe seleccionar un tipo de alarma"; 

			}
			else if (!IsCheckedQuantityTime())
			{
				labelError.Visible = true;
				labelError.Text = "Error. Debe seleccionar dias u horas."; 
			}
			else if (textBoxQuantityPost.Text.Equals(""))
			{
				labelError.Visible = true;
				labelError.Text = "Error. Debe seleccionar la cantidad de posts."; 
			}
			else if (textBoxQuantityTime.Text.Equals(""))
			{
				labelError.Visible = true;
				labelError.Text = "Error. Debe seleccionar un plazo de tiempo."; 
			}
			else
			{
				try
				{
					AddAlarmUI();
					MessageBox.Show("Alarma agregada con exito");
					DeleteText();
					RefreshGridAlarms();

				}
				catch (FormatException ex)
				{
					labelError.Text = "El campo debe ser numerico";
				}

				catch (AlarmManagementException exc)
				{
					labelError.Visible = true;
					labelError.Text = exc.Message; 
				}
				catch (Exception)
				{
					MessageBox.Show("Error interno en el sistema");
				}
			}
		}

		private void AddAlarmUI()
		{

			Alarm alarmToAdd = new Alarm()
			{
				Entity = (Entity)cmbEntities.SelectedItem,
				QuantityPost = int.Parse(textBoxQuantityPost.Text),
				QuantityTime = int.Parse(textBoxQuantityTime.Text),
				TypeOfAlarm = TypeOfAlarmChecked(),
				IsInHours = IsInHoursTimeFrame()
			};
			generalManagement.AlarmManagement.AddAlarm(alarmToAdd);
		}

		private Alarm.Type TypeOfAlarmChecked()
		{
			if (radioButtonPositive.Checked)
			{
				return Alarm.Type.Positive;
			}
			else
			{
				return Alarm.Type.Negative;
			}
		}

		private bool IsInHoursTimeFrame()
		{
			return radioButtonHours.Checked;
		}


		private bool IsCheckedTypeOfAlarm()
		{
			return radioButtonPositive.Checked || radioButtonNegative.Checked;
		}

		private bool IsCheckedQuantityTime()
		{
			return radioButtonDays.Checked || radioButtonHours.Checked;
		}

		private void TextBoxQuantityPost_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
			{
				e.Handled = true;
				MessageBox.Show("Debe ingresar solo numeros");
			}
		}

		private void TextBoxQuantityTime_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-') && (e.KeyChar != '.'))
			{
				e.Handled = true;
				MessageBox.Show("Debe ingresar solo numeros");
			}
		}
	}
}


