using AbstractSecurityShopServiceDAL.BindingModel;
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

namespace AbstractSecurityShopView
{
    public partial class FormWorker : Form
    {
        public int Id { set { id = value; } }
        private int? id;

        public FormWorker()
        {
            InitializeComponent();
        }

        private void FormWorker_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    WorkerViewModel imp =
                   APICustomer.GetRequest<WorkerViewModel>("api/Worker/Get/" + id.Value);
                    textBoxFIO.Text = imp.WorkerFIO;
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
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    APICustomer.PostRequest<WorkerBindingModel,
                   bool>("api/Worker/UpdElement", new WorkerBindingModel
                   {
                       Id = id.Value,
                       WorkerFIO = textBoxFIO.Text
                   });
                }
                else
                {
                    APICustomer.PostRequest<WorkerBindingModel,
                   bool>("api/Worker/AddElement", new WorkerBindingModel
                   {
                       WorkerFIO = textBoxFIO.Text
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
