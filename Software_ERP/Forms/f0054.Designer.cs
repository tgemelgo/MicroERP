namespace ERP.Forms
{
    partial class f0054
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f0054));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtRomaneio = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.txtDescricao = new CompSoft.cf_Bases.cf_TextBox();
            this.cboFuncionario = new CompSoft.cf_Bases.cf_ComboBox();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.cf_Label4 = new CompSoft.cf_Bases.cf_Label();
            this.grdPedidos = new CompSoft.cf_Bases.cf_DataGrid();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDataMovimento = new CompSoft.cf_Bases.cf_DateEdit();
            this.cf_GroupBox2 = new CompSoft.cf_Bases.cf_GroupBox();
            this.cf_Label5 = new CompSoft.cf_Bases.cf_Label();
            this.txtObs = new CompSoft.cf_Bases.cf_TextBox();
            this.txtNomeCliente = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label10 = new CompSoft.cf_Bases.cf_Label();
            this.txtCodPedido = new CompSoft.cf_Bases.cf_TextBox();
            this.grdClientesRomaneio = new CompSoft.cf_Bases.cf_DataGrid();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cf_Label6 = new CompSoft.cf_Bases.cf_Label();
            this.cmdBaixo = new CompSoft.cf_Bases.cf_Button();
            this.cmdCima = new CompSoft.cf_Bases.cf_Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataMovimento.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataMovimento.Properties)).BeginInit();
            this.cf_GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdClientesRomaneio)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRomaneio
            // 
            this.txtRomaneio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRomaneio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRomaneio.Coluna_LookUp = 0;
            this.txtRomaneio.ControlSource = "Romaneio";
            this.txtRomaneio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRomaneio.ForeColor = System.Drawing.Color.DimGray;
            this.txtRomaneio.Grupo = "";
            this.txtRomaneio.Incluir_QueryBy = true;
            this.txtRomaneio.Location = new System.Drawing.Point(64, 8);
            this.txtRomaneio.LookUp = false;
            this.txtRomaneio.MensagemObrigatorio = "Campo obrigatório";
            this.txtRomaneio.Name = "txtRomaneio";
            this.txtRomaneio.Obrigatorio = false;
            this.txtRomaneio.Qtde_Casas_Decimais = 0;
            this.txtRomaneio.Size = new System.Drawing.Size(100, 20);
            this.txtRomaneio.SQLStatement = "";
            this.txtRomaneio.Tabela = "romaneios";
            this.txtRomaneio.Tabela_INNER = "ro";
            this.txtRomaneio.TabIndex = 1;
            this.txtRomaneio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRomaneio.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtRomaneio.ValorAnterior = "";
            this.txtRomaneio.Value = "";
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cf_Label1.Location = new System.Drawing.Point(17, 11);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(44, 13);
            this.cf_Label1.TabIndex = 0;
            this.cf_Label1.Text = "Código:";
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cf_Label2.Location = new System.Drawing.Point(5, 37);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(57, 13);
            this.cf_Label2.TabIndex = 4;
            this.cf_Label2.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Coluna_LookUp = 0;
            this.txtDescricao.ControlSource = "Descricao";
            this.txtDescricao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescricao.Grupo = "";
            this.txtDescricao.Incluir_QueryBy = true;
            this.txtDescricao.Location = new System.Drawing.Point(64, 33);
            this.txtDescricao.LookUp = false;
            this.txtDescricao.MensagemObrigatorio = "Campo obrigatório";
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Obrigatorio = false;
            this.txtDescricao.Qtde_Casas_Decimais = 0;
            this.txtDescricao.Size = new System.Drawing.Size(328, 20);
            this.txtDescricao.SQLStatement = "";
            this.txtDescricao.Tabela = "romaneios";
            this.txtDescricao.Tabela_INNER = "ro";
            this.txtDescricao.TabIndex = 5;
            this.txtDescricao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDescricao.TipoControles = CompSoft.TipoControle.Geral;
            this.txtDescricao.ValorAnterior = "";
            this.txtDescricao.Value = "";
            // 
            // cboFuncionario
            // 
            this.cboFuncionario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboFuncionario.ControlSource = "Funcionario_Motorista";
            this.cboFuncionario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFuncionario.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboFuncionario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFuncionario.ForeColor = System.Drawing.Color.DimGray;
            this.cboFuncionario.FormattingEnabled = true;
            this.cboFuncionario.Grupo = "";
            this.cboFuncionario.Incluir_QueryBy = true;
            this.cboFuncionario.Location = new System.Drawing.Point(64, 59);
            this.cboFuncionario.MensagemObrigatorio = "Campo obrigatório";
            this.cboFuncionario.Name = "cboFuncionario";
            this.cboFuncionario.Obrigatorio = false;
            this.cboFuncionario.ReadOnly = false;
            this.cboFuncionario.Size = new System.Drawing.Size(328, 21);
            this.cboFuncionario.SQLStatement = "select funcionario, nome from funcionarios where motorista = 1 order by nome";
            this.cboFuncionario.Tabela = "romaneios";
            this.cboFuncionario.Tabela_INNER = "ro";
            this.cboFuncionario.TabIndex = 7;
            this.cboFuncionario.ValorAnterior = "";
            this.cboFuncionario.Value = null;
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cf_Label3.Location = new System.Drawing.Point(5, 62);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(56, 13);
            this.cf_Label3.TabIndex = 6;
            this.cf_Label3.Text = "Motorista:";
            // 
            // cf_Label4
            // 
            this.cf_Label4.AutoSize = true;
            this.cf_Label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cf_Label4.Location = new System.Drawing.Point(253, 11);
            this.cf_Label4.Name = "cf_Label4";
            this.cf_Label4.Size = new System.Drawing.Size(34, 13);
            this.cf_Label4.TabIndex = 2;
            this.cf_Label4.Text = "Data:";
            // 
            // grdPedidos
            // 
            this.grdPedidos.Allow_Alter_Value_All_StatusForm = false;
            this.grdPedidos.AllowEditRow = false;
            this.grdPedidos.AllowUserToAddRows = false;
            this.grdPedidos.AllowUserToDeleteRows = false;
            this.grdPedidos.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdPedidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdPedidos.Cancel_OnClick = true;
            this.grdPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column7,
            this.Column8,
            this.Column6,
            this.Column4,
            this.Column5,
            this.Column9});
            this.grdPedidos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdPedidos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdPedidos.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdPedidos.GridColor = System.Drawing.Color.DimGray;
            this.grdPedidos.Location = new System.Drawing.Point(3, 68);
            this.grdPedidos.MultiSelect = false;
            this.grdPedidos.Name = "grdPedidos";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPedidos.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPedidos.RowHeadersWidth = 22;
            this.grdPedidos.RowTemplate.Height = 20;
            this.grdPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPedidos.ShowCellErrors = false;
            this.grdPedidos.ShowCellToolTips = false;
            this.grdPedidos.ShowEditingIcon = false;
            this.grdPedidos.ShowRowErrors = false;
            this.grdPedidos.Size = new System.Drawing.Size(514, 128);
            this.grdPedidos.TabIndex = 5;
            this.grdPedidos.TabStop = false;
            this.toolTip1.SetToolTip(this.grdPedidos, "Para excluir item precione DELETE");
            this.grdPedidos.VirtualMode = true;
            this.grdPedidos.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grdPedidos_UserDeletingRow);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Pedido";
            this.Column2.HeaderText = "Pedido";
            this.Column2.Name = "Column2";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "razao_Social";
            this.Column1.HeaderText = "Cliente";
            this.Column1.Name = "Column1";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Endereco_Entrega";
            this.Column3.HeaderText = "Rua";
            this.Column3.Name = "Column3";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Numero_Entrega";
            this.Column7.HeaderText = "Nº";
            this.Column7.Name = "Column7";
            this.Column7.Width = 5;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Complemento_Entrega";
            this.Column8.HeaderText = "Compl.";
            this.Column8.Name = "Column8";
            this.Column8.Width = 5;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Bairro_Entrega";
            this.Column6.HeaderText = "Bairro";
            this.Column6.Name = "Column6";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Cidade_Entrega";
            this.Column4.HeaderText = "Cidade";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Estado_Entrega";
            this.Column5.HeaderText = "UF";
            this.Column5.Name = "Column5";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Observacao";
            this.Column9.HeaderText = "Obs";
            this.Column9.Name = "Column9";
            this.Column9.Width = 200;
            // 
            // txtDataMovimento
            // 
            this.txtDataMovimento.ControlSource = "Data_Romaneio";
            this.txtDataMovimento.EditValue = null;
            this.txtDataMovimento.Grupo = "";
            this.txtDataMovimento.Incluir_QueryBy = true;
            this.txtDataMovimento.Location = new System.Drawing.Point(292, 8);
            this.txtDataMovimento.MensagemObrigatorio = "Campo obrigatório";
            this.txtDataMovimento.Name = "txtDataMovimento";
            this.txtDataMovimento.Obrigatorio = true;
            this.txtDataMovimento.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDataMovimento.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.txtDataMovimento.Properties.Appearance.Options.UseBackColor = true;
            this.txtDataMovimento.Properties.Appearance.Options.UseForeColor = true;
            this.txtDataMovimento.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtDataMovimento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)), serializableAppearanceObject1, "", null, null, false)});
            this.txtDataMovimento.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.txtDataMovimento.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDataMovimento.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.txtDataMovimento.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDataMovimento.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.txtDataMovimento.Properties.LookAndFeel.SkinName = "The Asphalt World";
            this.txtDataMovimento.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtDataMovimento.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.txtDataMovimento.Properties.Mask.BeepOnError = true;
            this.txtDataMovimento.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtDataMovimento.Properties.Mask.SaveLiteral = false;
            this.txtDataMovimento.Properties.MaxValue = new System.DateTime(2158, 6, 30, 0, 0, 0, 0);
            this.txtDataMovimento.Properties.MinValue = new System.DateTime(1901, 1, 1, 0, 0, 0, 0);
            this.txtDataMovimento.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.txtDataMovimento.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDataMovimento.ReadOnly = false;
            this.txtDataMovimento.Size = new System.Drawing.Size(100, 20);
            this.txtDataMovimento.Tabela = "romaneios";
            this.txtDataMovimento.Tabela_INNER = "ro";
            this.txtDataMovimento.TabIndex = 3;
            this.txtDataMovimento.ValorAnterior = null;
            this.txtDataMovimento.Value = null;
            // 
            // cf_GroupBox2
            // 
            this.cf_GroupBox2.Controls.Add(this.cf_Label5);
            this.cf_GroupBox2.Controls.Add(this.txtObs);
            this.cf_GroupBox2.Controls.Add(this.grdPedidos);
            this.cf_GroupBox2.Controls.Add(this.txtNomeCliente);
            this.cf_GroupBox2.Controls.Add(this.cf_Label10);
            this.cf_GroupBox2.Controls.Add(this.txtCodPedido);
            this.cf_GroupBox2.ControlSource = "";
            this.cf_GroupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.cf_GroupBox2.Location = new System.Drawing.Point(8, 86);
            this.cf_GroupBox2.Name = "cf_GroupBox2";
            this.cf_GroupBox2.Size = new System.Drawing.Size(520, 199);
            this.cf_GroupBox2.Tabela = "";
            this.cf_GroupBox2.TabIndex = 9;
            this.cf_GroupBox2.TabStop = false;
            this.cf_GroupBox2.Text = "Itens do romaneio";
            this.cf_GroupBox2.Value = "";
            // 
            // cf_Label5
            // 
            this.cf_Label5.AutoSize = true;
            this.cf_Label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cf_Label5.Location = new System.Drawing.Point(15, 47);
            this.cf_Label5.Name = "cf_Label5";
            this.cf_Label5.Size = new System.Drawing.Size(34, 13);
            this.cf_Label5.TabIndex = 3;
            this.cf_Label5.Text = "Obs.:";
            // 
            // txtObs
            // 
            this.txtObs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObs.Coluna_LookUp = 0;
            this.txtObs.ControlSource = "";
            this.txtObs.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObs.ForeColor = System.Drawing.Color.DimGray;
            this.txtObs.Grupo = "";
            this.txtObs.Incluir_QueryBy = true;
            this.txtObs.Location = new System.Drawing.Point(54, 45);
            this.txtObs.LookUp = false;
            this.txtObs.MaxLength = 100;
            this.txtObs.MensagemObrigatorio = "Campo obrigatório";
            this.txtObs.Name = "txtObs";
            this.txtObs.Obrigatorio = false;
            this.txtObs.Qtde_Casas_Decimais = 0;
            this.txtObs.Size = new System.Drawing.Size(327, 20);
            this.txtObs.SQLStatement = "";
            this.txtObs.Tabela = "";
            this.txtObs.Tabela_INNER = "";
            this.txtObs.TabIndex = 4;
            this.txtObs.TipoControles = CompSoft.TipoControle.Geral;
            this.toolTip1.SetToolTip(this.txtObs, "Precione ENTER para incluir o pedido");
            this.txtObs.ValorAnterior = "";
            this.txtObs.Value = "";
            this.txtObs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObs_KeyPress);
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
            this.txtNomeCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomeCliente.Coluna_LookUp = 1;
            this.txtNomeCliente.ControlSource = "";
            this.txtNomeCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeCliente.ForeColor = System.Drawing.Color.Black;
            this.txtNomeCliente.Grupo = "";
            this.txtNomeCliente.Incluir_QueryBy = true;
            this.txtNomeCliente.Location = new System.Drawing.Point(113, 19);
            this.txtNomeCliente.LookUp = true;
            this.txtNomeCliente.MensagemObrigatorio = "Campo obrigatório";
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Obrigatorio = false;
            this.txtNomeCliente.Qtde_Casas_Decimais = 0;
            this.txtNomeCliente.Size = new System.Drawing.Size(268, 20);
            this.txtNomeCliente.SQLStatement = resources.GetString("txtNomeCliente.SQLStatement");
            this.txtNomeCliente.Tabela = "";
            this.txtNomeCliente.Tabela_INNER = null;
            this.txtNomeCliente.TabIndex = 2;
            this.txtNomeCliente.TabStop = false;
            this.txtNomeCliente.TipoControles = CompSoft.TipoControle.Geral;
            this.toolTip1.SetToolTip(this.txtNomeCliente, "Precione ENTER para incluir o pedido");
            this.txtNomeCliente.ValorAnterior = "";
            this.txtNomeCliente.Value = "";
            this.txtNomeCliente.Validating += new System.ComponentModel.CancelEventHandler(this.txtNomeCliente_Validating);
            // 
            // cf_Label10
            // 
            this.cf_Label10.AutoSize = true;
            this.cf_Label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label10.Location = new System.Drawing.Point(6, 22);
            this.cf_Label10.Name = "cf_Label10";
            this.cf_Label10.Size = new System.Drawing.Size(43, 13);
            this.cf_Label10.TabIndex = 0;
            this.cf_Label10.Text = "Pedido:";
            // 
            // txtCodPedido
            // 
            this.txtCodPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
            this.txtCodPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodPedido.Coluna_LookUp = 0;
            this.txtCodPedido.ControlSource = "";
            this.txtCodPedido.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodPedido.ForeColor = System.Drawing.Color.Black;
            this.txtCodPedido.Grupo = "";
            this.txtCodPedido.Incluir_QueryBy = true;
            this.txtCodPedido.Location = new System.Drawing.Point(54, 19);
            this.txtCodPedido.LookUp = true;
            this.txtCodPedido.MaxLength = 5;
            this.txtCodPedido.MensagemObrigatorio = "Campo obrigatório";
            this.txtCodPedido.Name = "txtCodPedido";
            this.txtCodPedido.Obrigatorio = false;
            this.txtCodPedido.Qtde_Casas_Decimais = 0;
            this.txtCodPedido.Size = new System.Drawing.Size(54, 20);
            this.txtCodPedido.SQLStatement = resources.GetString("txtCodPedido.SQLStatement");
            this.txtCodPedido.Tabela = "";
            this.txtCodPedido.Tabela_INNER = null;
            this.txtCodPedido.TabIndex = 1;
            this.txtCodPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodPedido.TipoControles = CompSoft.TipoControle.Inteiro;
            this.toolTip1.SetToolTip(this.txtCodPedido, "Precione ENTER para incluir o pedido");
            this.txtCodPedido.ValorAnterior = "";
            this.txtCodPedido.Value = "";
            this.txtCodPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodPedido_KeyPress);
            this.txtCodPedido.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodPedido_Validating);
            // 
            // grdClientesRomaneio
            // 
            this.grdClientesRomaneio.Allow_Alter_Value_All_StatusForm = false;
            this.grdClientesRomaneio.AllowEditRow = false;
            this.grdClientesRomaneio.AllowUserToAddRows = false;
            this.grdClientesRomaneio.AllowUserToDeleteRows = false;
            this.grdClientesRomaneio.BackgroundColor = System.Drawing.Color.DimGray;
            this.grdClientesRomaneio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdClientesRomaneio.Cancel_OnClick = true;
            this.grdClientesRomaneio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column11});
            this.grdClientesRomaneio.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdClientesRomaneio.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdClientesRomaneio.GridColor = System.Drawing.Color.DimGray;
            this.grdClientesRomaneio.Location = new System.Drawing.Point(8, 304);
            this.grdClientesRomaneio.MultiSelect = false;
            this.grdClientesRomaneio.Name = "grdClientesRomaneio";
            this.grdClientesRomaneio.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdClientesRomaneio.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdClientesRomaneio.RowHeadersWidth = 22;
            this.grdClientesRomaneio.RowTemplate.Height = 20;
            this.grdClientesRomaneio.ShowCellErrors = false;
            this.grdClientesRomaneio.ShowCellToolTips = false;
            this.grdClientesRomaneio.ShowRowErrors = false;
            this.grdClientesRomaneio.Size = new System.Drawing.Size(489, 113);
            this.grdClientesRomaneio.TabIndex = 10;
            this.grdClientesRomaneio.TabStop = false;
            this.grdClientesRomaneio.VirtualMode = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Ordem";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column10.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column10.HeaderText = "Ordem";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "Razao_Social";
            this.Column11.HeaderText = "Cliente";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cf_Label6
            // 
            this.cf_Label6.AutoSize = true;
            this.cf_Label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label6.Location = new System.Drawing.Point(8, 288);
            this.cf_Label6.Name = "cf_Label6";
            this.cf_Label6.Size = new System.Drawing.Size(260, 13);
            this.cf_Label6.TabIndex = 11;
            this.cf_Label6.Text = "Definição da ordem dos clientes no romaneio";
            // 
            // cmdBaixo
            // 
            this.cmdBaixo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBaixo.ForeColor = System.Drawing.Color.Black;
            this.cmdBaixo.Grupo = "";
            this.cmdBaixo.Image = global::ERP.Properties.Resources.Baixo;
            this.cmdBaixo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdBaixo.Location = new System.Drawing.Point(502, 333);
            this.cmdBaixo.Name = "cmdBaixo";
            this.cmdBaixo.ReadOnly = false;
            this.cmdBaixo.Size = new System.Drawing.Size(26, 28);
            this.cmdBaixo.TabIndex = 32;
            this.cmdBaixo.TabStop = false;
            this.cmdBaixo.UseVisualStyleBackColor = true;
            this.cmdBaixo.Click += new System.EventHandler(this.cmdBaixo_Click);
            // 
            // cmdCima
            // 
            this.cmdCima.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCima.ForeColor = System.Drawing.Color.Black;
            this.cmdCima.Grupo = "";
            this.cmdCima.Image = global::ERP.Properties.Resources.Cima;
            this.cmdCima.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdCima.Location = new System.Drawing.Point(502, 304);
            this.cmdCima.Name = "cmdCima";
            this.cmdCima.ReadOnly = false;
            this.cmdCima.Size = new System.Drawing.Size(26, 28);
            this.cmdCima.TabIndex = 31;
            this.cmdCima.TabStop = false;
            this.cmdCima.UseVisualStyleBackColor = true;
            this.cmdCima.Click += new System.EventHandler(this.cmdCima_Click);
            // 
            // f0054
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 422);
            this.Controls.Add(this.cmdBaixo);
            this.Controls.Add(this.cmdCima);
            this.Controls.Add(this.cf_Label6);
            this.Controls.Add(this.grdClientesRomaneio);
            this.Controls.Add(this.cf_GroupBox2);
            this.Controls.Add(this.txtDataMovimento);
            this.Controls.Add(this.cf_Label4);
            this.Controls.Add(this.cf_Label3);
            this.Controls.Add(this.cboFuncionario);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.cf_Label1);
            this.Controls.Add(this.txtRomaneio);
            this.MainTabela = "romaneios";
            this.Name = "f0054";
            this.Text = "Romaneio de entrega";
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.f0054_user_AfterRefreshData);
            this.user_AfterNew += new CompSoft.FormSet.AfterNew(this.f0054_user_AfterNew);
            this.user_AfterClear += new CompSoft.FormSet.AfterClear(this.f0054_user_AfterClear);
            this.Load += new System.EventHandler(this.f0054_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataMovimento.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataMovimento.Properties)).EndInit();
            this.cf_GroupBox2.ResumeLayout(false);
            this.cf_GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdClientesRomaneio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_TextBox txtRomaneio;
        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_TextBox txtDescricao;
        private CompSoft.cf_Bases.cf_ComboBox cboFuncionario;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
        private CompSoft.cf_Bases.cf_Label cf_Label4;
        private CompSoft.cf_Bases.cf_DataGrid grdPedidos;
        private CompSoft.cf_Bases.cf_DateEdit txtDataMovimento;
        private CompSoft.cf_Bases.cf_GroupBox cf_GroupBox2;
        private CompSoft.cf_Bases.cf_TextBox txtNomeCliente;
        private CompSoft.cf_Bases.cf_Label cf_Label10;
        private CompSoft.cf_Bases.cf_TextBox txtCodPedido;
        private CompSoft.cf_Bases.cf_Label cf_Label5;
        private CompSoft.cf_Bases.cf_TextBox txtObs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private CompSoft.cf_Bases.cf_DataGrid grdClientesRomaneio;
        private CompSoft.cf_Bases.cf_Label cf_Label6;
        private CompSoft.cf_Bases.cf_Button cmdCima;
        private CompSoft.cf_Bases.cf_Button cmdBaixo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
    }
}