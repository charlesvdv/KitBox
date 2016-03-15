namespace Interface_commande
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Order = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Cancel2 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.AddElement = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.ClickHere = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.Delivery = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.StockUpdating = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Element2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reference2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityOrdered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityDeliver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Element3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reference3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityInCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Suppliers = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.Reference4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dimensions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Depth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delay1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delay2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerOrder = new System.Windows.Forms.TabPage();
            this.GO = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.Element4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reference5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.CustomerFirstName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Element = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.Order.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Delivery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.Stock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.Suppliers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.CustomerOrder.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Order);
            this.tabControl1.Controls.Add(this.Delivery);
            this.tabControl1.Controls.Add(this.Stock);
            this.tabControl1.Controls.Add(this.Suppliers);
            this.tabControl1.Controls.Add(this.CustomerOrder);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(33, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(711, 333);
            this.tabControl1.TabIndex = 0;
            // 
            // Order
            // 
            this.Order.Controls.Add(this.panel1);
            this.Order.Controls.Add(this.label2);
            this.Order.Controls.Add(this.ClickHere);
            this.Order.Controls.Add(this.label1);
            this.Order.Location = new System.Drawing.Point(4, 25);
            this.Order.Name = "Order";
            this.Order.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Order.Size = new System.Drawing.Size(703, 304);
            this.Order.TabIndex = 0;
            this.Order.Text = "Commande";
            this.Order.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.Cancel2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.AddElement);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(13, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 251);
            this.panel1.TabIndex = 3;
            this.panel1.Visible = false;
            // 
            // Cancel2
            // 
            this.Cancel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Cancel2.Location = new System.Drawing.Point(409, 217);
            this.Cancel2.Name = "Cancel2";
            this.Cancel2.Size = new System.Drawing.Size(83, 26);
            this.Cancel2.TabIndex = 7;
            this.Cancel2.Text = "ANNULER";
            this.Cancel2.UseVisualStyleBackColor = true;
            this.Cancel2.Click += new System.EventHandler(this.Cancel2_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(223, 217);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 26);
            this.button2.TabIndex = 6;
            this.button2.Text = "VALIDER LA COMMANDE";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // AddElement
            // 
            this.AddElement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddElement.Location = new System.Drawing.Point(38, 217);
            this.AddElement.Name = "AddElement";
            this.AddElement.Size = new System.Drawing.Size(179, 26);
            this.AddElement.TabIndex = 5;
            this.AddElement.Text = "AJOUTER UN ELEMENT";
            this.AddElement.UseVisualStyleBackColor = true;
            this.AddElement.Click += new System.EventHandler(this.AddElement_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Element,
            this.Reference,
            this.Quantity,
            this.Supplier,
            this.Price});
            this.dataGridView1.Location = new System.Drawing.Point(38, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(585, 161);
            this.dataGridView1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(114, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(486, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "afin d\'obtenir un bon de commande basé sur les statistiques des 6 derniers mois.";
            // 
            // ClickHere
            // 
            this.ClickHere.AutoSize = true;
            this.ClickHere.Location = new System.Drawing.Point(96, 31);
            this.ClickHere.Name = "ClickHere";
            this.ClickHere.Size = new System.Drawing.Size(21, 16);
            this.ClickHere.TabIndex = 1;
            this.ClickHere.TabStop = true;
            this.ClickHere.Text = "ici";
            this.ClickHere.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ClickHere_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliquer";
            // 
            // Delivery
            // 
            this.Delivery.Controls.Add(this.label3);
            this.Delivery.Controls.Add(this.StockUpdating);
            this.Delivery.Controls.Add(this.dataGridView2);
            this.Delivery.Location = new System.Drawing.Point(4, 25);
            this.Delivery.Name = "Delivery";
            this.Delivery.Size = new System.Drawing.Size(703, 304);
            this.Delivery.TabIndex = 3;
            this.Delivery.Text = "Livraisons";
            this.Delivery.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(368, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sélectionner les éléments livrés afin de mettre le stock à jour:";
            // 
            // StockUpdating
            // 
            this.StockUpdating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StockUpdating.Location = new System.Drawing.Point(30, 260);
            this.StockUpdating.Name = "StockUpdating";
            this.StockUpdating.Size = new System.Drawing.Size(205, 26);
            this.StockUpdating.TabIndex = 3;
            this.StockUpdating.Text = "METTRE LE STOCK A JOUR";
            this.StockUpdating.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Element2,
            this.Reference2,
            this.QuantityOrdered,
            this.QuantityDeliver});
            this.dataGridView2.Location = new System.Drawing.Point(30, 47);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(642, 207);
            this.dataGridView2.TabIndex = 2;
            // 
            // Element2
            // 
            this.Element2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Element2.HeaderText = "Elément";
            this.Element2.Name = "Element2";
            // 
            // Reference2
            // 
            this.Reference2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Reference2.HeaderText = "Référence";
            this.Reference2.Name = "Reference2";
            // 
            // QuantityOrdered
            // 
            this.QuantityOrdered.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QuantityOrdered.HeaderText = "Quantité commandée";
            this.QuantityOrdered.Name = "QuantityOrdered";
            // 
            // QuantityDeliver
            // 
            this.QuantityDeliver.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QuantityDeliver.HeaderText = "Quantité reçue";
            this.QuantityDeliver.Name = "QuantityDeliver";
            // 
            // Stock
            // 
            this.Stock.Controls.Add(this.label4);
            this.Stock.Controls.Add(this.dataGridView3);
            this.Stock.Location = new System.Drawing.Point(4, 25);
            this.Stock.Name = "Stock";
            this.Stock.Size = new System.Drawing.Size(703, 304);
            this.Stock.TabIndex = 5;
            this.Stock.Text = "Stock";
            this.Stock.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Apperçu du stock";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Element3,
            this.Reference3,
            this.StockQuantity,
            this.QuantityInCommand});
            this.dataGridView3.Location = new System.Drawing.Point(30, 47);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(642, 207);
            this.dataGridView3.TabIndex = 0;
            // 
            // Element3
            // 
            this.Element3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Element3.HeaderText = "Elément";
            this.Element3.Name = "Element3";
            // 
            // Reference3
            // 
            this.Reference3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Reference3.HeaderText = "Référence";
            this.Reference3.Name = "Reference3";
            // 
            // StockQuantity
            // 
            this.StockQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StockQuantity.HeaderText = "Quantité en stock ";
            this.StockQuantity.Name = "StockQuantity";
            // 
            // QuantityInCommand
            // 
            this.QuantityInCommand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QuantityInCommand.HeaderText = "Quantité commandée ";
            this.QuantityInCommand.Name = "QuantityInCommand";
            // 
            // Suppliers
            // 
            this.Suppliers.Controls.Add(this.label5);
            this.Suppliers.Controls.Add(this.dataGridView4);
            this.Suppliers.Location = new System.Drawing.Point(4, 25);
            this.Suppliers.Name = "Suppliers";
            this.Suppliers.Size = new System.Drawing.Size(703, 304);
            this.Suppliers.TabIndex = 4;
            this.Suppliers.Text = "Fournisseurs";
            this.Suppliers.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(387, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Liste des éléments disponnibles chez les différents fournisseurs:";
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Reference4,
            this.Code,
            this.Dimensions,
            this.Depth,
            this.Price1,
            this.Price2,
            this.Delay1,
            this.Delay2});
            this.dataGridView4.Location = new System.Drawing.Point(30, 47);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(642, 207);
            this.dataGridView4.TabIndex = 0;
            // 
            // Reference4
            // 
            this.Reference4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Reference4.HeaderText = "Référence";
            this.Reference4.Name = "Reference4";
            // 
            // Code
            // 
            this.Code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            // 
            // Dimensions
            // 
            this.Dimensions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Dimensions.HeaderText = "Dimensions";
            this.Dimensions.Name = "Dimensions";
            // 
            // Depth
            // 
            this.Depth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Depth.HeaderText = "Profondeur";
            this.Depth.Name = "Depth";
            // 
            // Price1
            // 
            this.Price1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Price1.HeaderText = "Prix fournisseur A";
            this.Price1.Name = "Price1";
            // 
            // Price2
            // 
            this.Price2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Price2.HeaderText = "Prix fournisseur B";
            this.Price2.Name = "Price2";
            // 
            // Delay1
            // 
            this.Delay1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Delay1.HeaderText = "Délai fournisseur A";
            this.Delay1.Name = "Delay1";
            // 
            // Delay2
            // 
            this.Delay2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Delay2.HeaderText = "Délai fournisseur B";
            this.Delay2.Name = "Delay2";
            // 
            // CustomerOrder
            // 
            this.CustomerOrder.Controls.Add(this.GO);
            this.CustomerOrder.Controls.Add(this.panel2);
            this.CustomerOrder.Controls.Add(this.CustomerFirstName);
            this.CustomerOrder.Controls.Add(this.label6);
            this.CustomerOrder.Location = new System.Drawing.Point(4, 25);
            this.CustomerOrder.Name = "CustomerOrder";
            this.CustomerOrder.Size = new System.Drawing.Size(703, 304);
            this.CustomerOrder.TabIndex = 6;
            this.CustomerOrder.Text = "Retrait commande client";
            this.CustomerOrder.UseVisualStyleBackColor = true;
            // 
            // GO
            // 
            this.GO.Location = new System.Drawing.Point(368, 27);
            this.GO.Name = "GO";
            this.GO.Size = new System.Drawing.Size(40, 23);
            this.GO.TabIndex = 3;
            this.GO.Text = "GO";
            this.GO.UseVisualStyleBackColor = true;
            this.GO.Click += new System.EventHandler(this.GO_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.dataGridView5);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(14, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(675, 214);
            this.panel2.TabIndex = 2;
            this.panel2.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(14, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "VALIDER LE RETRAIT";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView5
            // 
            this.dataGridView5.AllowUserToAddRows = false;
            this.dataGridView5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Element4,
            this.Reference5,
            this.Supplier2,
            this.Price3});
            this.dataGridView5.Location = new System.Drawing.Point(14, 37);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(642, 120);
            this.dataGridView5.TabIndex = 1;
            // 
            // Element4
            // 
            this.Element4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Element4.HeaderText = "Elément";
            this.Element4.Name = "Element4";
            // 
            // Reference5
            // 
            this.Reference5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Reference5.HeaderText = "Référence";
            this.Reference5.Name = "Reference5";
            // 
            // Supplier2
            // 
            this.Supplier2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Supplier2.HeaderText = "Fournisseur";
            this.Supplier2.Name = "Supplier2";
            // 
            // Price3
            // 
            this.Price3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Price3.HeaderText = "Prix";
            this.Price3.Name = "Price3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Détails de la commande :";
            // 
            // CustomerFirstName
            // 
            this.CustomerFirstName.Location = new System.Drawing.Point(248, 27);
            this.CustomerFirstName.Name = "CustomerFirstName";
            this.CustomerFirstName.Size = new System.Drawing.Size(114, 22);
            this.CustomerFirstName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(215, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Entrer le numéro de la commande: ";
            // 
            // Element
            // 
            this.Element.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Element.HeaderText = "Elément";
            this.Element.Name = "Element";
            this.Element.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Reference
            // 
            this.Reference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Reference.HeaderText = "Référence";
            this.Reference.Name = "Reference";
            // 
            // Quantity
            // 
            this.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Quantity.HeaderText = "Quantité à commander";
            this.Quantity.Name = "Quantity";
            // 
            // Supplier
            // 
            this.Supplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Supplier.HeaderText = "Fournisseur";
            this.Supplier.Name = "Supplier";
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Price.HeaderText = "Prix";
            this.Price.Name = "Price";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 365);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.Order.ResumeLayout(false);
            this.Order.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.Delivery.ResumeLayout(false);
            this.Delivery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.Stock.ResumeLayout(false);
            this.Stock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.Suppliers.ResumeLayout(false);
            this.Suppliers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.CustomerOrder.ResumeLayout(false);
            this.CustomerOrder.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Order;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel ClickHere;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage Delivery;
        private System.Windows.Forms.TabPage Suppliers;
        private System.Windows.Forms.Button StockUpdating;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage Stock;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Cancel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button AddElement;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Element2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reference2;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityOrdered;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityDeliver;
        private System.Windows.Forms.DataGridViewTextBoxColumn Element3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reference3;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityInCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reference4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dimensions;
        private System.Windows.Forms.DataGridViewTextBoxColumn Depth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delay1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delay2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage CustomerOrder;
        private System.Windows.Forms.Button GO;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Element4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reference5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox CustomerFirstName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Element;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}

