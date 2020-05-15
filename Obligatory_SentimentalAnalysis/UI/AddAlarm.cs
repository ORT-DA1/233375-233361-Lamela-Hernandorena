using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain;

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
			InitializeAlarms(); 
			DeleteText();
		}



		private void InitializeEntities()
		{
			cmbEntities.DataSource = generalManagement.EntityManagement.AllEntities;
		}

		private void InitializeAlarms()
		{
			listBoxAlarms.Items.Clear();
			foreach(IAlarm alarm in generalManagement.AlarmManagement.AllAlarms)
			{
				listBoxAlarms.Items.Add(alarm.Show()); 
			}
		}

		private void DeleteText()
		{
			if (generalManagement.EntityManagement.AllEntities.Length > 0)
			{
				cmbEntities.SelectedIndex = 0;
			}
			textBoxQuantityPost.Text = "";
			textBoxQuantityTime.Text = "";
			labelError.Text = "";
			labelError.Visible = true; 
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
			InitializeAlarms(); 
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


