using AbstractSecurityShopServiceDAL.BindingModel;
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
    public partial class FormTechnics : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly ITechnicsService service;
        private int? id;
        private List<TechnicsEquipmentViewModel> technicsEquipment;

        public FormTechnics(ITechnicsService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormTechnics_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    TechnicsViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.TechnicsName;
                        textBoxPrice.Text = view.Price.ToString();
                        technicsEquipment = view.TechnicsEquipment;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                technicsEquipment = new List<TechnicsEquipmentViewModel>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (technicsEquipment != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = technicsEquipment;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTechnicsEquipment>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.TechnicsId = id.Value;
                    }
                    technicsEquipment.Add(form.Model);
                }
                LoadData();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormTechnicsEquipment>();
                form.Model = technicsEquipment[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    technicsEquipment[dataGridView.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        technicsEquipment.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (technicsEquipment == null || technicsEquipment.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<TechnicsEquipmentBindingModel> TechnicsEquipmentBM = new List<TechnicsEquipmentBindingModel>();
                for (int i = 0; i < technicsEquipment.Count; ++i)
                {
                    TechnicsEquipmentBM.Add(new TechnicsEquipmentBindingModel
                    {
                        Id = technicsEquipment[i].Id,
                        TechnicsId = technicsEquipment[i].TechnicsId,
                        EquipmentId = technicsEquipment[i].EquipmentId,
                        Count = technicsEquipment[i].Count
                    });
                }
                if (id.HasValue)
                {
                    service.UpdElement(new TechnicsBindingModel
                    {
                        Id = id.Value,
                        TechnicsName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        TechnicsEquipment = TechnicsEquipmentBM
                    });
                }
                else
                {
                    service.AddElement(new TechnicsBindingModel
                    {
                        TechnicsName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        TechnicsEquipment = TechnicsEquipmentBM
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
