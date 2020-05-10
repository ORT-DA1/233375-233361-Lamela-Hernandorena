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
            DeleteText();
        }

        private void InitializeEntities()
        {
            cmbEntities.DataSource = generalManagement.EntityManagement.AllEntities;
        }

        private void AddAlarm_Load(object sender, EventArgs e)
        {

        }

        private void LblAddSentiment_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void CmbEntities_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DeleteText()
        {
            if (generalManagement.EntityManagement.AllEntities.Length > 0)
            {
                cmbEntities.SelectedIndex = 0;
            }
            CleanRadioButtons();
            textBoxQuantityPost.Text = "";
            textBoxQuantityTime.Text = "";
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
                MessageBox.Show("Error. Debe seleccionar una entidad");
            }
            else if (!IsCheckedTypeOfAlarm())
            {
                MessageBox.Show("Error. Debe seleccionar un tipo de alarma");

            }
            else if (!IsCheckedQuantityTime())
            {
                MessageBox.Show("Error. Debe seleccionar dias u horas.");
            }
            else if (textBoxQuantityPost.Text.Equals(""))
            {
                MessageBox.Show("Error. Debe seleccionar la cantidad de posts.");
            }
            else if (textBoxQuantityTime.Text.Equals(""))
            {
                MessageBox.Show("Error. Debe seleccionar un plazo de tiempo.");
            }
            else
            { 
                try
                {
                    AddAlarmUI();
                    MessageBox.Show("Alarma agregada con exito");
                    DeleteText();
                }
                catch (AlarmManagementException exc)
                {
                    MessageBox.Show(exc.Message);
                }
                catch (Exception exc)
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-' ) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Debe ingresar solo numeros");
            }
        }
    }
}


