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
        private IContainer components;
        private TabControl tabControl1;
        private TabPage ativoListPage;
        private TabPage editPage;
        private Button DeleteButton;
        private Button EditButton;
        private Button AddButton;
        private Button BuscarButton;
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
        private TextBox totalBox;
        private TextBox textBox5;
        private TextBox ticketBox;
        private Button CancelButton;
        private Button SaveButton;
        private DateTimePicker dateTimePicker;
        private DateTime date;
        private bool isSucessful;
        private bool isEdit;
        private string message;
        private string searchValue;
        private string? ticket;
        private decimal total;
        private decimal valor;
        private int quantity;
        private NumericUpDown valorUpDown;
        private NumericUpDown quantidadeUpDown;
        private NumericUpDown numericUpDown1;
        private Label ativoLabel;
        private Button buttonClose;
        private int id;

        public event EventHandler SearchEvent;
        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public AtivoView()
        {
           InitializeComponent();
           AssociateAndRaiseViewEvents();

            buttonClose.Click += delegate { this.Close(); };
        }

        public int Id { get => id; set => id = value; }
        public int Quantity { get => (int)quantidadeUpDown.Value; set => quantidadeUpDown.Value = value; }
        public decimal Value { get => valorUpDown.Value; set => valorUpDown.Value = value; }
        public decimal Total { get => decimal.Parse(totalBox.Text); }
        public DateTime Date { get => dateTimePicker.Value; set => dateTimePicker.Value = value; }
        public string SearchValue { get => searchBox.Text; set => searchBox.Text = value; }
        public string Message { get => message; set => message = value; }
        public string? Ticket { get => ticketBox.Text; set => ticketBox.Text = value; }
        public bool IsEdit { get => isEdit; set => isEdit = value; }
        public bool IsSuccessful { get => isSucessful; set => isSucessful = value; }
        


        private void InitializeComponent()
        {
            System.Windows.Forms.TabControl tabControl1;
            this.ativoListPage = new System.Windows.Forms.TabPage();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.BuscarLabel = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.editPage = new System.Windows.Forms.TabPage();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.valorUpDown = new System.Windows.Forms.NumericUpDown();
            this.quantidadeUpDown = new System.Windows.Forms.NumericUpDown();
            this.totalLabel = new System.Windows.Forms.Label();
            this.totalBox = new System.Windows.Forms.TextBox();
            this.dataLabel = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.valorLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.ticketLabel = new System.Windows.Forms.Label();
            this.empresaLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.ticketBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ativoLabel = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabControl1.SuspendLayout();
            this.ativoListPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.editPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valorUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidadeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tabControl1.Controls.Add(this.ativoListPage);
            tabControl1.Controls.Add(this.editPage);
            tabControl1.Location = new System.Drawing.Point(0, 33);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(661, 311);
            tabControl1.TabIndex = 3;
            // 
            // ativoListPage
            // 
            this.ativoListPage.Controls.Add(this.searchBox);
            this.ativoListPage.Controls.Add(this.dataGridView);
            this.ativoListPage.Controls.Add(this.BuscarLabel);
            this.ativoListPage.Controls.Add(this.DeleteButton);
            this.ativoListPage.Controls.Add(this.EditButton);
            this.ativoListPage.Controls.Add(this.AddButton);
            this.ativoListPage.Controls.Add(this.BuscarButton);
            this.ativoListPage.Location = new System.Drawing.Point(4, 24);
            this.ativoListPage.Name = "ativoListPage";
            this.ativoListPage.Padding = new System.Windows.Forms.Padding(3);
            this.ativoListPage.Size = new System.Drawing.Size(653, 283);
            this.ativoListPage.TabIndex = 0;
            this.ativoListPage.Text = "Ativos da carteira";
            this.ativoListPage.UseVisualStyleBackColor = true;
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Location = new System.Drawing.Point(8, 31);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(304, 23);
            this.searchBox.TabIndex = 6;
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(8, 60);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(556, 222);
            this.dataGridView.TabIndex = 5;
            // 
            // BuscarLabel
            // 
            this.BuscarLabel.AutoSize = true;
            this.BuscarLabel.Location = new System.Drawing.Point(8, 13);
            this.BuscarLabel.Name = "BuscarLabel";
            this.BuscarLabel.Size = new System.Drawing.Size(73, 15);
            this.BuscarLabel.TabIndex = 4;
            this.BuscarLabel.Text = "Buscar Ativo";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.AutoSize = true;
            this.DeleteButton.Location = new System.Drawing.Point(570, 136);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 25);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Deletar";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditButton.AutoSize = true;
            this.EditButton.Location = new System.Drawing.Point(570, 107);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 25);
            this.EditButton.TabIndex = 2;
            this.EditButton.Text = "Editar";
            this.EditButton.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.AutoSize = true;
            this.AddButton.Location = new System.Drawing.Point(570, 78);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 25);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Adicionar";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // BuscarButton
            // 
            this.BuscarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BuscarButton.AutoSize = true;
            this.BuscarButton.Location = new System.Drawing.Point(318, 31);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(75, 25);
            this.BuscarButton.TabIndex = 0;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            // 
            // editPage
            // 
            this.editPage.Controls.Add(this.numericUpDown1);
            this.editPage.Controls.Add(this.valorUpDown);
            this.editPage.Controls.Add(this.quantidadeUpDown);
            this.editPage.Controls.Add(this.totalLabel);
            this.editPage.Controls.Add(this.totalBox);
            this.editPage.Controls.Add(this.dataLabel);
            this.editPage.Controls.Add(this.dateTimePicker);
            this.editPage.Controls.Add(this.valorLabel);
            this.editPage.Controls.Add(this.quantityLabel);
            this.editPage.Controls.Add(this.ticketLabel);
            this.editPage.Controls.Add(this.empresaLabel);
            this.editPage.Controls.Add(this.idLabel);
            this.editPage.Controls.Add(this.textBox5);
            this.editPage.Controls.Add(this.ticketBox);
            this.editPage.Controls.Add(this.CancelButton);
            this.editPage.Controls.Add(this.SaveButton);
            this.editPage.Location = new System.Drawing.Point(4, 24);
            this.editPage.Name = "editPage";
            this.editPage.Padding = new System.Windows.Forms.Padding(3);
            this.editPage.Size = new System.Drawing.Size(653, 283);
            this.editPage.TabIndex = 1;
            this.editPage.Text = "Detalhes do ativo";
            this.editPage.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(14, 34);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(100, 23);
            this.numericUpDown1.TabIndex = 18;
            // 
            // valorUpDown
            // 
            this.valorUpDown.DecimalPlaces = 2;
            this.valorUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.valorUpDown.Location = new System.Drawing.Point(139, 158);
            this.valorUpDown.Name = "valorUpDown";
            this.valorUpDown.Size = new System.Drawing.Size(100, 23);
            this.valorUpDown.TabIndex = 17;
            // 
            // quantidadeUpDown
            // 
            this.quantidadeUpDown.Location = new System.Drawing.Point(14, 158);
            this.quantidadeUpDown.Name = "quantidadeUpDown";
            this.quantidadeUpDown.Size = new System.Drawing.Size(100, 23);
            this.quantidadeUpDown.TabIndex = 16;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(270, 139);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(131, 15);
            this.totalLabel.TabIndex = 15;
            this.totalLabel.Text = "Total investido no Ativo";
            // 
            // totalBox
            // 
            this.totalBox.Location = new System.Drawing.Point(270, 157);
            this.totalBox.Name = "totalBox";
            this.totalBox.Size = new System.Drawing.Size(100, 23);
            this.totalBox.TabIndex = 14;
            this.totalBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TotalBox_KeyPress);
            // 
            // dataLabel
            // 
            this.dataLabel.AutoSize = true;
            this.dataLabel.Location = new System.Drawing.Point(270, 75);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Size = new System.Drawing.Size(31, 15);
            this.dataLabel.TabIndex = 13;
            this.dataLabel.Text = "Data";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(270, 93);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(247, 23);
            this.dateTimePicker.TabIndex = 12;
            // 
            // valorLabel
            // 
            this.valorLabel.AutoSize = true;
            this.valorLabel.Location = new System.Drawing.Point(139, 139);
            this.valorLabel.Name = "valorLabel";
            this.valorLabel.Size = new System.Drawing.Size(33, 15);
            this.valorLabel.TabIndex = 11;
            this.valorLabel.Text = "Valor";
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(14, 139);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(69, 15);
            this.quantityLabel.TabIndex = 10;
            this.quantityLabel.Text = "Quantidade";
            // 
            // ticketLabel
            // 
            this.ticketLabel.AutoSize = true;
            this.ticketLabel.Location = new System.Drawing.Point(139, 75);
            this.ticketLabel.Name = "ticketLabel";
            this.ticketLabel.Size = new System.Drawing.Size(38, 15);
            this.ticketLabel.TabIndex = 9;
            this.ticketLabel.Text = "Ticket";
            // 
            // empresaLabel
            // 
            this.empresaLabel.AutoSize = true;
            this.empresaLabel.Location = new System.Drawing.Point(14, 75);
            this.empresaLabel.Name = "empresaLabel";
            this.empresaLabel.Size = new System.Drawing.Size(52, 15);
            this.empresaLabel.TabIndex = 8;
            this.empresaLabel.Text = "Empresa";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(14, 16);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(18, 15);
            this.idLabel.TabIndex = 7;
            this.idLabel.Text = "ID";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(14, 93);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 23);
            this.textBox5.TabIndex = 5;
            // 
            // ticketBox
            // 
            this.ticketBox.Location = new System.Drawing.Point(139, 93);
            this.ticketBox.Name = "ticketBox";
            this.ticketBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ticketBox.Size = new System.Drawing.Size(100, 23);
            this.ticketBox.TabIndex = 2;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(570, 260);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancelar";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(473, 260);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Salvar";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // ativoLabel
            // 
            this.ativoLabel.AutoSize = true;
            this.ativoLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ativoLabel.Location = new System.Drawing.Point(4, 0);
            this.ativoLabel.Name = "ativoLabel";
            this.ativoLabel.Size = new System.Drawing.Size(75, 30);
            this.ativoLabel.TabIndex = 4;
            this.ativoLabel.Text = "Ativos";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonClose.Location = new System.Drawing.Point(631, 6);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(26, 26);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "x";
            this.buttonClose.UseVisualStyleBackColor = false;
            // 
            // AtivoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(661, 349);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.ativoLabel);
            this.Controls.Add(tabControl1);
            this.Name = "AtivoView";
            tabControl1.ResumeLayout(false);
            this.ativoListPage.ResumeLayout(false);
            this.ativoListPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.editPage.ResumeLayout(false);
            this.editPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valorUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidadeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
                tabControl1.TabPages.Remove(editPage);
                tabControl1.TabPages.Add(editPage);
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

        private void TotalBox_KeyPress(object sender, KeyPressEventArgs e)
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
