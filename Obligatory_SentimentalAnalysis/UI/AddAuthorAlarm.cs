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
using Domain;
using BusinessLogicExceptions;

namespace UI
{
    public partial class AddAuthorAlarm : UserControl
    {
        private GeneralManagement generalManagement;
        
        public AddAuthorAlarm(GeneralManagement management)
        {
            InitializeComponent();
            generalManagement = management;
			InitializeAlarms();
			ClearAllFields();
		}

		private void InitializeAlarms()
        {
            listBoxAuthorAlarms.Items.Clear();
            foreach (IAlarm alarm in generalManagement.AlarmManagement.AllAlarms)
            {
                listBoxAuthorAlarms.Items.Add(alarm.Show());
            }
        }

        private void ClearAllFields()
        {
            textBoxQuantityPost.Text = "";
            textBoxQuantityTime.Text = "";
            labelError.Text = "";
            labelError.Visible = true;
        }

        private void addAlarm_Click(object sender, EventArgs e)
        {
			
			if (!IsCheckedTypeOfAlarm())
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
					ClearAllFields();
				}
				catch (FormatException)
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

			AuthorAlarm alarmToAdd = new AuthorAlarm()
			{
				QuantityPost = int.Parse(textBoxQuantityPost.Text),
				QuantityTime = int.Parse(textBoxQuantityTime.Text),
				TypeOfAlarm = TypeOfAlarmChecked(),
				IsInHours = IsInHoursTimeFrame()
			};
			generalManagement.AlarmManagement.AddAlarm(alarmToAdd);
			InitializeAlarms();
		}

		private AuthorAlarm.TypeOfNewAlarm TypeOfAlarmChecked()
		{
			if (radioButtonPositive.Checked)
			{
				return AuthorAlarm.TypeOfNewAlarm.Positive;
			}
			else
			{
				return AuthorAlarm.TypeOfNewAlarm.Negative;
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

		private bool NotIsNumeric(KeyPressEventArgs e)
		{
			return !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-');
		}


		private void TextBoxQuantityPost_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (NotIsNumeric(e))
			{
				e.Handled = true;
				MessageBox.Show("Debe ingresar solo numeros");
			}
		}

		private void TextBoxQuantityTime_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (NotIsNumeric(e))
			{
				e.Handled = true;
				MessageBox.Show("Debe ingresar solo numeros");
			}
		}

	}



}
