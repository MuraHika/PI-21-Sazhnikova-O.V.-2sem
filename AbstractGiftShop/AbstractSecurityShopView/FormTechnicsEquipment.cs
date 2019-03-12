using AbstractSecurityShopServiceDAL.Interface;
using AbstractSecurityShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace AbstractSecurityShopView
{
    public partial class FormTechnicsEquipment : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public TechnicsEquipmentViewModel Model
        {
            set { model = value; }
            get
            {
                return model;
            }
        }
        private readonly IEquipmentService service;
        private TechnicsEquipmentViewModel model;

        public FormTechnicsEquipment(IEquipmentService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormTechnicsEquipment_Load(object sender, EventArgs e)
        {
            try
            {
                List<EquipmentViewModel> list = service.GetList();
                if (list != null)
                {
                    comboBoxEquipment.DisplayMember = "EquipmentName";
                    comboBoxEquipment.ValueMember = "Id";
                    comboBoxEquipment.DataSource = list;
                    comboBoxEquipment.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxEquipment.Enabled = false;
                comboBoxEquipment.SelectedValue = model.EquipmentId;
                textBoxCount.Text = model.Count.ToString();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxEquipment.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new TechnicsEquipmentViewModel
                    {
                        EquipmentId = Convert.ToInt32(comboBoxEquipment.SelectedValue),
                        EquipmentName = comboBoxEquipment.Text,
                        Count = Convert.ToInt32(textBoxCount.Text)
                    };
                }
                else
                {
                    model.Count = Convert.ToInt32(textBoxCount.Text);
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
