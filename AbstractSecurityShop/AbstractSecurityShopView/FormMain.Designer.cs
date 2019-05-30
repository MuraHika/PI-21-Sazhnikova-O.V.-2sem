namespace AbstractSecurityShopView
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказчикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оборудованиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.техникаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.хранилищеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.работникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьХранилищеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прайсТехникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загруженностьХранилищToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыЗаказчиковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускРаботToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonAcceptedOrder = new System.Windows.Forms.Button();
            this.buttonOrderPaid = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.запускРаботToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.письмаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнитьХранилищеToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.запускРаботToolStripMenuItem1,
            this.письмаToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(943, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.заказчикиToolStripMenuItem,
            this.оборудованиеToolStripMenuItem,
            this.техникаToolStripMenuItem,
            this.хранилищеToolStripMenuItem,
            this.работникиToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // заказчикиToolStripMenuItem
            // 
            this.заказчикиToolStripMenuItem.Name = "заказчикиToolStripMenuItem";
            this.заказчикиToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.заказчикиToolStripMenuItem.Text = "Заказчики";
            this.заказчикиToolStripMenuItem.Click += new System.EventHandler(this.заказчикиToolStripMenuItem_Click);
            // 
            // оборудованиеToolStripMenuItem
            // 
            this.оборудованиеToolStripMenuItem.Name = "оборудованиеToolStripMenuItem";
            this.оборудованиеToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.оборудованиеToolStripMenuItem.Text = "Оборудование";
            this.оборудованиеToolStripMenuItem.Click += new System.EventHandler(this.оборудованиеToolStripMenuItem_Click);
            // 
            // техникаToolStripMenuItem
            // 
            this.техникаToolStripMenuItem.Name = "техникаToolStripMenuItem";
            this.техникаToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.техникаToolStripMenuItem.Text = "Техника";
            this.техникаToolStripMenuItem.Click += new System.EventHandler(this.техникаToolStripMenuItem_Click);
            // 
            // хранилищеToolStripMenuItem
            // 
            this.хранилищеToolStripMenuItem.Name = "хранилищеToolStripMenuItem";
            this.хранилищеToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.хранилищеToolStripMenuItem.Text = "Хранилище";
            this.хранилищеToolStripMenuItem.Click += new System.EventHandler(this.хранилищеToolStripMenuItem_Click);
            // 
            // работникиToolStripMenuItem
            // 
            this.работникиToolStripMenuItem.Name = "работникиToolStripMenuItem";
            this.работникиToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.работникиToolStripMenuItem.Text = "Работники";
            this.работникиToolStripMenuItem.Click += new System.EventHandler(this.работникиToolStripMenuItem_Click);
            // 
            // пополнитьХранилищеToolStripMenuItem
            // 
            this.пополнитьХранилищеToolStripMenuItem.Name = "пополнитьХранилищеToolStripMenuItem";
            this.пополнитьХранилищеToolStripMenuItem.Size = new System.Drawing.Size(147, 20);
            this.пополнитьХранилищеToolStripMenuItem.Text = "Пополнить хранилище";
            this.пополнитьХранилищеToolStripMenuItem.Click += new System.EventHandler(this.пополнитьХранилищеToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.прайсТехникиToolStripMenuItem,
            this.загруженностьХранилищToolStripMenuItem,
            this.заказыЗаказчиковToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // прайсТехникиToolStripMenuItem
            // 
            this.прайсТехникиToolStripMenuItem.Name = "прайсТехникиToolStripMenuItem";
            this.прайсТехникиToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.прайсТехникиToolStripMenuItem.Text = "Прайс техники";
            this.прайсТехникиToolStripMenuItem.Click += new System.EventHandler(this.прайсТехникиToolStripMenuItem_Click);
            // 
            // загруженностьХранилищToolStripMenuItem
            // 
            this.загруженностьХранилищToolStripMenuItem.Name = "загруженностьХранилищToolStripMenuItem";
            this.загруженностьХранилищToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.загруженностьХранилищToolStripMenuItem.Text = "Загруженность хранилищ";
            this.загруженностьХранилищToolStripMenuItem.Click += new System.EventHandler(this.загруженностьХранилищToolStripMenuItem_Click);
            // 
            // заказыЗаказчиковToolStripMenuItem
            // 
            this.заказыЗаказчиковToolStripMenuItem.Name = "заказыЗаказчиковToolStripMenuItem";
            this.заказыЗаказчиковToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.заказыЗаказчиковToolStripMenuItem.Text = "Заказы заказчиков";
            this.заказыЗаказчиковToolStripMenuItem.Click += new System.EventHandler(this.заказыЗаказчиковToolStripMenuItem_Click);
            // 
            // запускРаботToolStripMenuItem1
            // 
            this.запускРаботToolStripMenuItem1.Name = "запускРаботToolStripMenuItem1";
            this.запускРаботToolStripMenuItem1.Size = new System.Drawing.Size(92, 20);
            this.запускРаботToolStripMenuItem1.Text = "Запуск работ";
            this.запускРаботToolStripMenuItem1.Click += new System.EventHandler(this.запускРаботToolStripMenuItem1_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(10, 33);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(745, 369);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonAcceptedOrder
            // 
            this.buttonAcceptedOrder.Location = new System.Drawing.Point(782, 37);
            this.buttonAcceptedOrder.Name = "buttonAcceptedOrder";
            this.buttonAcceptedOrder.Size = new System.Drawing.Size(140, 45);
            this.buttonAcceptedOrder.TabIndex = 2;
            this.buttonAcceptedOrder.Text = "Создать заказ";
            this.buttonAcceptedOrder.UseVisualStyleBackColor = true;
            this.buttonAcceptedOrder.Click += new System.EventHandler(this.buttonAcceptedOrder_Click);
            // 
            // buttonOrderPaid
            // 
            this.buttonOrderPaid.Location = new System.Drawing.Point(782, 277);
            this.buttonOrderPaid.Name = "buttonOrderPaid";
            this.buttonOrderPaid.Size = new System.Drawing.Size(140, 45);
            this.buttonOrderPaid.TabIndex = 5;
            this.buttonOrderPaid.Text = "Заказ оплачен";
            this.buttonOrderPaid.UseVisualStyleBackColor = true;
            this.buttonOrderPaid.Click += new System.EventHandler(this.buttonOrderPaid_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(782, 357);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(140, 45);
            this.buttonUpdate.TabIndex = 6;
            this.buttonUpdate.Text = "Обновить список";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // запускРаботToolStripMenuItem
            // 
            this.запускРаботToolStripMenuItem.Name = "запускРаботToolStripMenuItem";
            this.запускРаботToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.запускРаботToolStripMenuItem.Text = "Запуск работ";
            // 
            // письмаToolStripMenuItem
            // 
            this.письмаToolStripMenuItem.Name = "письмаToolStripMenuItem";
            this.письмаToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.письмаToolStripMenuItem.Text = "Письма";
            this.письмаToolStripMenuItem.Click += new System.EventHandler(this.письмаToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 450);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonOrderPaid);
            this.Controls.Add(this.buttonAcceptedOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Магазин систем безопасности";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказчикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оборудованиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem техникаToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonAcceptedOrder;
        private System.Windows.Forms.Button buttonOrderPaid;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.ToolStripMenuItem хранилищеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнитьХранилищеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прайсТехникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загруженностьХранилищToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказыЗаказчиковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem работникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускРаботToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem запускРаботToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem письмаToolStripMenuItem;
    }
}

