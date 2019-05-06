using AbstractSecurityShopServiceDAL.BindingModel;
using AbstractSecurityShopServiceDAL.Interface;
using AbstractSecurityShopServiceDAL.ViewModel;
using System;
using System.Windows.Forms;

namespace AbstractSecurityShopView
{
    public partial class FormEquipment : Form
    {
        public int Id { set { id = value; } }
        private int? id;

        public FormEquipment()
        {
            InitializeComponent();
        }

        private void FormEquipment_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    EquipmentViewModel equipment =
                   APICustomer.GetRequest<EquipmentViewModel>("api/Equipment/Get/" + id.Value);
                    textBoxName.Text = equipment.EquipmentName;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните Название материала", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    APICustomer.PostRequest<EquipmentBindingModel,
                    bool>("api/Equipment/UpdElement", new EquipmentBindingModel
                    {
                        Id = id.Value,
                        EquipmentName = textBoxName.Text
                    });
                }
                else
                {
                    APICustomer.PostRequest<EquipmentBindingModel,
                   bool>("api/Equipment/AddElement", new EquipmentBindingModel
                   {
                       EquipmentName = textBoxName.Text
                   });
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
