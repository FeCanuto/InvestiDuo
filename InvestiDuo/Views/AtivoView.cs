using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestiDuo.Views
{
    public partial class AtivoView : Form, IAtivoView
    {
        private static AtivoView? instance;
        private TabControl tabControl1;
        private TabPage ativoListPage;
        private TabPage editPage;
        private Button? DeleteButton;
        private Button? EditButton;
        private Button? AddButton;
        private Button? BuscarButton;
        private TextBox searchBox;
        private DataGridView dataGridView;
        private Label BuscarLabel;
        private Label valorLabel;
        private Label quantityLabel;
        private Label ticketLabel;
        private Label empresaLabel;
        private Label idLabel;
        private Label dataLabel;
        private Label totalLabel;
        private TextBox empresaNameBox;
        private TextBox ticketBox;
        private Button CancelButton;
        private Button SaveButton;
        private DateTimePicker dateTimePicker;
        private bool isSucessful;
        private bool isEdit;
        private string message;
        private NumericUpDown valorUpDown;
        private NumericUpDown quantidadeUpDown;
        public NumericUpDown idUpDown;
        private Label ativoLabel;
        private Button buttonClose;
        private NumericUpDown totalUpDown;

        public event EventHandler SearchEvent;
        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        partial void InitializeOtherComponents();


        public AtivoView()
        {
            InitializeComponent();
            InitializeOtherComponents();
            AssociateAndRaiseViewEvents();

            buttonClose.Click += delegate { this.Close(); };
        }

        public int Id { get => (int)idUpDown.Value; set => idUpDown.Value = value; }
        public new string? Name { get => empresaNameBox.Text; set => empresaNameBox.Text = value; }
        public int Quantity { get => (int)quantidadeUpDown.Value; set => quantidadeUpDown.Value = value; }
        public decimal Value { get => valorUpDown.Value; set => valorUpDown.Value = value; }
        public decimal Total { get => totalUpDown.Value; set => totalUpDown.Value = value; }
        public DateTime Date { get => dateTimePicker.Value; set => dateTimePicker.Value = value; }
        public string SearchValue { get => searchBox.Text; set => searchBox.Text = value; }
        public string Message { get => message; set => message = value; }
        public string? Ticket { get => ticketBox.Text; set => ticketBox.Text = value; }
        public bool IsEdit { get => isEdit; set => isEdit = value; }
        public bool IsSuccessful { get => isSucessful; set => isSucessful = value; }

        private void InitializeComponent()
        {
            TabControl tabControl1;
            ativoListPage = new TabPage();
            searchBox = new TextBox();
            dataGridView = new DataGridView();
            BuscarLabel = new Label();
            DeleteButton = new Button();
            EditButton = new Button();
            AddButton = new Button();
            BuscarButton = new Button();
            editPage = new TabPage();
            totalUpDown = new NumericUpDown();
            idUpDown = new NumericUpDown();
            valorUpDown = new NumericUpDown();
            quantidadeUpDown = new NumericUpDown();
            totalLabel = new Label();
            dataLabel = new Label();
            dateTimePicker = new DateTimePicker();
            valorLabel = new Label();
            quantityLabel = new Label();
            ticketLabel = new Label();
            empresaLabel = new Label();
            idLabel = new Label();
            empresaNameBox = new TextBox();
            ticketBox = new TextBox();
            CancelButton = new Button();
            SaveButton = new Button();
            ativoLabel = new Label();
            buttonClose = new Button();
            tabControl1 = new TabControl();
            tabControl1.SuspendLayout();
            ativoListPage.SuspendLayout();
            ((ISupportInitialize)dataGridView).BeginInit();
            editPage.SuspendLayout();
            ((ISupportInitialize)totalUpDown).BeginInit();
            ((ISupportInitialize)idUpDown).BeginInit();
            ((ISupportInitialize)valorUpDown).BeginInit();
            ((ISupportInitialize)quantidadeUpDown).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(ativoListPage);
            tabControl1.Controls.Add(editPage);
            tabControl1.Location = new Point(0, 33);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(661, 311);
            tabControl1.TabIndex = 3;
            // 
            // ativoListPage
            // 
            ativoListPage.Controls.Add(searchBox);
            ativoListPage.Controls.Add(dataGridView);
            ativoListPage.Controls.Add(BuscarLabel);
            ativoListPage.Controls.Add(DeleteButton);
            ativoListPage.Controls.Add(EditButton);
            ativoListPage.Controls.Add(AddButton);
            ativoListPage.Controls.Add(BuscarButton);
            ativoListPage.Location = new Point(4, 24);
            ativoListPage.Name = "ativoListPage";
            ativoListPage.Padding = new Padding(3);
            ativoListPage.Size = new Size(653, 283);
            ativoListPage.TabIndex = 0;
            ativoListPage.Text = "Ativos da carteira";
            ativoListPage.UseVisualStyleBackColor = true;
            // 
            // searchBox
            // 
            searchBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchBox.Location = new Point(8, 31);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(293, 23);
            searchBox.TabIndex = 6;
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(8, 60);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(556, 222);
            dataGridView.TabIndex = 5;
            // 
            // BuscarLabel
            // 
            BuscarLabel.AutoSize = true;
            BuscarLabel.Location = new Point(8, 13);
            BuscarLabel.Name = "BuscarLabel";
            BuscarLabel.Size = new Size(73, 15);
            BuscarLabel.TabIndex = 4;
            BuscarLabel.Text = "Buscar Ativo";
            // 
            // DeleteButton
            // 
            DeleteButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DeleteButton.AutoSize = true;
            DeleteButton.BackColor = Color.FromArgb(255, 128, 128);
            DeleteButton.Location = new Point(570, 136);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 25);
            DeleteButton.TabIndex = 3;
            DeleteButton.Text = "Deletar";
            DeleteButton.UseVisualStyleBackColor = false;
            // 
            // EditButton
            // 
            EditButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            EditButton.AutoSize = true;
            EditButton.BackColor = Color.FromArgb(255, 255, 128);
            EditButton.Location = new Point(570, 107);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(75, 25);
            EditButton.TabIndex = 2;
            EditButton.Text = "Editar";
            EditButton.UseVisualStyleBackColor = false;
            // 
            // AddButton
            // 
            AddButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AddButton.AutoSize = true;
            AddButton.BackColor = Color.FromArgb(128, 255, 128);
            AddButton.Location = new Point(570, 78);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(75, 25);
            AddButton.TabIndex = 1;
            AddButton.Text = "Adicionar";
            AddButton.UseVisualStyleBackColor = false;
            // 
            // BuscarButton
            // 
            BuscarButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BuscarButton.AutoSize = true;
            BuscarButton.BackColor = Color.FromArgb(255, 192, 128);
            BuscarButton.Location = new Point(318, 31);
            BuscarButton.Name = "BuscarButton";
            BuscarButton.Size = new Size(75, 25);
            BuscarButton.TabIndex = 0;
            BuscarButton.Text = "Buscar";
            BuscarButton.UseVisualStyleBackColor = false;
            // 
            // editPage
            // 
            editPage.Controls.Add(totalUpDown);
            editPage.Controls.Add(idUpDown);
            editPage.Controls.Add(valorUpDown);
            editPage.Controls.Add(quantidadeUpDown);
            editPage.Controls.Add(totalLabel);
            editPage.Controls.Add(dataLabel);
            editPage.Controls.Add(dateTimePicker);
            editPage.Controls.Add(valorLabel);
            editPage.Controls.Add(quantityLabel);
            editPage.Controls.Add(ticketLabel);
            editPage.Controls.Add(empresaLabel);
            editPage.Controls.Add(idLabel);
            editPage.Controls.Add(empresaNameBox);
            editPage.Controls.Add(ticketBox);
            editPage.Controls.Add(CancelButton);
            editPage.Controls.Add(SaveButton);
            editPage.Location = new Point(4, 24);
            editPage.Name = "editPage";
            editPage.Padding = new Padding(3);
            editPage.Size = new Size(653, 283);
            editPage.TabIndex = 1;
            editPage.Text = "Detalhes do ativo";
            editPage.UseVisualStyleBackColor = true;
            // 
            // totalUpDown
            // 
            totalUpDown.DecimalPlaces = 2;
            totalUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            totalUpDown.Location = new Point(270, 158);
            totalUpDown.Name = "totalUpDown";
            totalUpDown.Size = new Size(100, 23);
            totalUpDown.TabIndex = 19;
            // 
            // idUpDown
            // 
            idUpDown.Location = new Point(14, 34);
            idUpDown.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            idUpDown.Minimum = new decimal(new int[] { 100000, 0, 0, 0 });
            idUpDown.Name = "idUpDown";
            idUpDown.ReadOnly = true;
            idUpDown.Size = new Size(100, 23);
            idUpDown.TabIndex = 18;
            idUpDown.Value = new decimal(new int[] { 100000, 0, 0, 0 });
            // 
            // valorUpDown
            // 
            valorUpDown.DecimalPlaces = 2;
            valorUpDown.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            valorUpDown.Location = new Point(139, 158);
            valorUpDown.Name = "valorUpDown";
            valorUpDown.Size = new Size(100, 23);
            valorUpDown.TabIndex = 17;
            // 
            // quantidadeUpDown
            // 
            quantidadeUpDown.Location = new Point(14, 158);
            quantidadeUpDown.Name = "quantidadeUpDown";
            quantidadeUpDown.Size = new Size(100, 23);
            quantidadeUpDown.TabIndex = 16;
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Location = new Point(270, 139);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(131, 15);
            totalLabel.TabIndex = 15;
            totalLabel.Text = "Total investido no Ativo";
            // 
            // dataLabel
            // 
            dataLabel.AutoSize = true;
            dataLabel.Location = new Point(270, 75);
            dataLabel.Name = "dataLabel";
            dataLabel.Size = new Size(31, 15);
            dataLabel.TabIndex = 13;
            dataLabel.Text = "Data";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(270, 93);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(247, 23);
            dateTimePicker.TabIndex = 12;
            // 
            // valorLabel
            // 
            valorLabel.AutoSize = true;
            valorLabel.Location = new Point(139, 139);
            valorLabel.Name = "valorLabel";
            valorLabel.Size = new Size(33, 15);
            valorLabel.TabIndex = 11;
            valorLabel.Text = "Valor";
            // 
            // quantityLabel
            // 
            quantityLabel.AutoSize = true;
            quantityLabel.Location = new Point(14, 139);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new Size(69, 15);
            quantityLabel.TabIndex = 10;
            quantityLabel.Text = "Quantidade";
            // 
            // ticketLabel
            // 
            ticketLabel.AutoSize = true;
            ticketLabel.Location = new Point(139, 75);
            ticketLabel.Name = "ticketLabel";
            ticketLabel.Size = new Size(38, 15);
            ticketLabel.TabIndex = 9;
            ticketLabel.Text = "Ticket";
            // 
            // empresaLabel
            // 
            empresaLabel.AutoSize = true;
            empresaLabel.Location = new Point(14, 75);
            empresaLabel.Name = "empresaLabel";
            empresaLabel.Size = new Size(52, 15);
            empresaLabel.TabIndex = 8;
            empresaLabel.Text = "Empresa";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(14, 16);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(18, 15);
            idLabel.TabIndex = 7;
            idLabel.Text = "ID";
            // 
            // empresaNameBox
            // 
            empresaNameBox.Location = new Point(14, 93);
            empresaNameBox.Name = "empresaNameBox";
            empresaNameBox.Size = new Size(100, 23);
            empresaNameBox.TabIndex = 5;
            // 
            // ticketBox
            // 
            ticketBox.Location = new Point(139, 93);
            ticketBox.Name = "ticketBox";
            ticketBox.RightToLeft = RightToLeft.Yes;
            ticketBox.Size = new Size(100, 23);
            ticketBox.TabIndex = 2;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(570, 260);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancelar";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(473, 260);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 0;
            SaveButton.Text = "Salvar";
            SaveButton.UseVisualStyleBackColor = true;
            // 
            // ativoLabel
            // 
            ativoLabel.AutoSize = true;
            ativoLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            ativoLabel.Location = new Point(4, 0);
            ativoLabel.Name = "ativoLabel";
            ativoLabel.Size = new Size(75, 30);
            ativoLabel.TabIndex = 4;
            ativoLabel.Text = "Ativos";
            // 
            // buttonClose
            // 
            buttonClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonClose.BackColor = SystemColors.ActiveCaption;
            buttonClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonClose.Location = new Point(631, 6);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(26, 26);
            buttonClose.TabIndex = 7;
            buttonClose.Text = "x";
            buttonClose.UseVisualStyleBackColor = false;
            // 
            // AtivoView
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(661, 349);
            Controls.Add(buttonClose);
            Controls.Add(ativoLabel);
            Controls.Add(tabControl1);
            Name = "AtivoView";
            tabControl1.ResumeLayout(false);
            ativoListPage.ResumeLayout(false);
            ativoListPage.PerformLayout();
            ((ISupportInitialize)dataGridView).EndInit();
            editPage.ResumeLayout(false);
            editPage.PerformLayout();
            ((ISupportInitialize)totalUpDown).EndInit();
            ((ISupportInitialize)idUpDown).EndInit();
            ((ISupportInitialize)valorUpDown).EndInit();
            ((ISupportInitialize)quantidadeUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void AssociateAndRaiseViewEvents()
        {
            //Buscar
            BuscarButton.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            searchBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            //Adicionar
            AddButton.Click += delegate
            {
                AddEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(editPage);
                tabControl1.TabPages.Add(editPage);
                editPage.Text = "Adicionar ativo";
            };

            //Editar
            EditButton.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                this.tabControl1.TabPages.Remove(editPage);
                this.tabControl1.TabPages.Add(editPage);
                editPage.Text = "Editar ativo";
            };

            //Salvar
            SaveButton.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (IsSuccessful)
                {
                    tabControl1.TabPages.Remove(editPage);
                    tabControl1.TabPages.Add(ativoListPage);
                }
                MessageBox.Show(Message);
            };

            CancelButton.Click += delegate
            {
                CancelEvent?.Invoke(this, global::System.EventArgs.Empty);
                this.tabControl1.TabPages.Remove(this.editPage);
                this.tabControl1.TabPages.Add(this.ativoListPage);
            };

            DeleteButton.Click += delegate
            {
                DialogResult result = MessageBox.Show("Tem certeza que deseja deletar esse ativo?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }

            };

        }

        public void SetAssetListBindingSource(BindingSource assetList)
        {
            dataGridView.DataSource = assetList;
        }

        private void TotalBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        //Singleton Pattern
        public static AtivoView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new AtivoView();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if(instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
    }
}
