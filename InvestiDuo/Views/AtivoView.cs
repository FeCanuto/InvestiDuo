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
        private IContainer components;
        private ToolStripMenuItem ArquivoToolStripMenuItem;
        private ToolStripMenuItem detalhesToolStripMenuItem;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button CancelButton;
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
        private Button button3;
        private Button button2;
        private MenuStrip menuStrip1;
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
           //btnClose.Click += delegate { this.Close(); };
        }

        private void AssociateAndRaiseViewEvents()
        {
            BuscarButton.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            searchBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        private void BuscarButton_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
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
        public bool IsSucessful { get => isSucessful; set => isSucessful = value; }
        


        private void InitializeComponent()
        {
            System.Windows.Forms.TabControl tabControl1;
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.BuscarLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ArquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detalhesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quantidadeUpDown = new System.Windows.Forms.NumericUpDown();
            this.valorUpDown = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantidadeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valorUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(this.tabPage1);
            tabControl1.Controls.Add(this.tabPage2);
            tabControl1.Location = new System.Drawing.Point(0, 27);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(661, 317);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.searchBox);
            this.tabPage1.Controls.Add(this.dataGridView);
            this.tabPage1.Controls.Add(this.BuscarLabel);
            this.tabPage1.Controls.Add(this.CancelButton);
            this.tabPage1.Controls.Add(this.EditButton);
            this.tabPage1.Controls.Add(this.AddButton);
            this.tabPage1.Controls.Add(this.BuscarButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(653, 289);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ativos da carteira";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(8, 31);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(304, 23);
            this.searchBox.TabIndex = 6;
            // 
            // dataGridView
            // 
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
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(570, 136);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancelar";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(570, 107);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 2;
            this.EditButton.Text = "Editar";
            this.EditButton.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(570, 78);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Adicionar";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // button1
            // 
            this.BuscarButton.Location = new System.Drawing.Point(318, 31);
            this.BuscarButton.Name = "button1";
            this.BuscarButton.Size = new System.Drawing.Size(75, 23);
            this.BuscarButton.TabIndex = 0;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.numericUpDown1);
            this.tabPage2.Controls.Add(this.valorUpDown);
            this.tabPage2.Controls.Add(this.quantidadeUpDown);
            this.tabPage2.Controls.Add(this.totalLabel);
            this.tabPage2.Controls.Add(this.totalBox);
            this.tabPage2.Controls.Add(this.dataLabel);
            this.tabPage2.Controls.Add(this.dateTimePicker);
            this.tabPage2.Controls.Add(this.valorLabel);
            this.tabPage2.Controls.Add(this.quantityLabel);
            this.tabPage2.Controls.Add(this.ticketLabel);
            this.tabPage2.Controls.Add(this.empresaLabel);
            this.tabPage2.Controls.Add(this.idLabel);
            this.tabPage2.Controls.Add(this.textBox5);
            this.tabPage2.Controls.Add(this.ticketBox);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(653, 289);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detalhes do ativo";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(570, 260);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(473, 260);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Salvar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ArquivoToolStripMenuItem,
            this.detalhesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(661, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ArquivoToolStripMenuItem
            // 
            this.ArquivoToolStripMenuItem.Name = "ArquivoToolStripMenuItem";
            this.ArquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.ArquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // detalhesToolStripMenuItem
            // 
            this.detalhesToolStripMenuItem.Name = "detalhesToolStripMenuItem";
            this.detalhesToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.detalhesToolStripMenuItem.Text = "Detalhes";
            // 
            // quantidadeUpDown
            // 
            this.quantidadeUpDown.Location = new System.Drawing.Point(14, 158);
            this.quantidadeUpDown.Name = "quantidadeUpDown";
            this.quantidadeUpDown.Size = new System.Drawing.Size(100, 23);
            this.quantidadeUpDown.TabIndex = 16;
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
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(14, 34);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(100, 23);
            this.numericUpDown1.TabIndex = 18;
            // 
            // AtivoView
            // 
            this.ClientSize = new System.Drawing.Size(661, 349);
            this.Controls.Add(tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AtivoView";
            tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantidadeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valorUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void AddButtonClick(object sender, EventArgs e)
        {

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
        private static AtivoView? instance;
        public static AtivoView GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new AtivoView();
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
