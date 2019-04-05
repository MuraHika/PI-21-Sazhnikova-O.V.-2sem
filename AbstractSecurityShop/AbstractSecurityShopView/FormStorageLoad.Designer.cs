namespace AbstractSecurityShopView
{
    partial class FormStorageLoad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSaveInExcel = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnStorage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEquipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSaveInExcel
            // 
            this.buttonSaveInExcel.Location = new System.Drawing.Point(7, 12);
            this.buttonSaveInExcel.Name = "buttonSaveInExcel";
            this.buttonSaveInExcel.Size = new System.Drawing.Size(329, 38);
            this.buttonSaveInExcel.TabIndex = 0;
            this.buttonSaveInExcel.Text = "Сохранить в Excel";
            this.buttonSaveInExcel.UseVisualStyleBackColor = true;
            this.buttonSaveInExcel.Click += new System.EventHandler(this.buttonSaveInExcel_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStorage,
            this.ColumnEquipment,
            this.ColumnCount});
            this.dataGridView.Location = new System.Drawing.Point(7, 59);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(648, 390);
            this.dataGridView.TabIndex = 0;
            // 
            // ColumnStorage
            // 
            this.ColumnStorage.FillWeight = 200F;
            this.ColumnStorage.HeaderText = "Хранилище";
            this.ColumnStorage.Name = "ColumnStorage";
            this.ColumnStorage.ReadOnly = true;
            this.ColumnStorage.Width = 200;
            // 
            // ColumnEquipment
            // 
            this.ColumnEquipment.FillWeight = 200F;
            this.ColumnEquipment.HeaderText = "Оборудование";
            this.ColumnEquipment.Name = "ColumnEquipment";
            this.ColumnEquipment.ReadOnly = true;
            this.ColumnEquipment.Width = 200;
            // 
            // ColumnCount
            // 
            this.ColumnCount.FillWeight = 200F;
            this.ColumnCount.HeaderText = "Количество";
            this.ColumnCount.Name = "ColumnCount";
            this.ColumnCount.ReadOnly = true;
            this.ColumnCount.Width = 200;
            // 
            // FormStorageLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonSaveInExcel);
            this.Name = "FormStorageLoad";
            this.Text = "Загруженность хранилищ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveInExcel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStorage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
    }
}