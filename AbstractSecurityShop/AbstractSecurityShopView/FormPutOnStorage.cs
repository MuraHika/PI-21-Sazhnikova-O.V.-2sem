using AbstractSecurityShopServiceDAL.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using AbstractSecurityShopServiceDAL.ViewModel;
using AbstractSecurityShopServiceDAL.BindingModel;

namespace AbstractSecurityShopView
{
    public partial class FormPutOnStorage : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IStorageService serviceS;
        private readonly IEquipmentService serviceE;
        private readonly IMainService serviceM;
        public FormPutOnStorage(IStorageService serviceS, IEquipmentService serviceE, IMainService serviceM)
        {
            InitializeComponent();
            this.serviceS = serviceS;
            this.serviceE = serviceE;
            this.serviceM = serviceM;
        }

        private void FormPutOnStorage_Load(object sender, EventArgs e)
        {
            try
            {
                List<EquipmentViewModel> listE = serviceE.GetList();
                if (listE != null)
                {
                    comboBoxEquipment.DisplayMember = "EquipmentName";
                    comboBoxEquipment.ValueMember = "Id";
                    comboBoxEquipment.DataSource = listE;
                    comboBoxEquipment.SelectedItem = null;
                }
                List<StorageViewModel> listS = serviceS.GetList();
                if (listS != null)
                {
                    comboBoxStorage.DisplayMember = "StorageName";
                    comboBoxStorage.ValueMember = "Id";
                    comboBoxStorage.DataSource = listS;
                    comboBoxStorage.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
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
                MessageBox.Show("Выберите оборудование", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxStorage.SelectedValue == null)
            {
                MessageBox.Show("Выберите хранилище", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                serviceM.PutEquipmentOnStorage(new StorageEquipmentBindingModel
                {
                    EquipmentId = Convert.ToInt32(comboBoxEquipment.SelectedValue),
                    StorageId = Convert.ToInt32(comboBoxStorage.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });
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
