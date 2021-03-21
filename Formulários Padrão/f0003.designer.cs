namespace ERP.Forms
{
    partial class f0003
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
            this.cf_Label1 = new CompSoft.cf_Bases.cf_Label();
            this.txtDescricao = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label2 = new CompSoft.cf_Bases.cf_Label();
            this.txtParentNivel = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label3 = new CompSoft.cf_Bases.cf_Label();
            this.txtNameSpace = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label4 = new CompSoft.cf_Bases.cf_Label();
            this.txtFormulario = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label5 = new CompSoft.cf_Bases.cf_Label();
            this.cf_CheckBox1 = new CompSoft.cf_Bases.cf_CheckBox();
            this.txtDescParent = new CompSoft.cf_Bases.cf_TextBox();
            this.txtMenuItem = new CompSoft.cf_Bases.cf_TextBox();
            this.cf_Label7 = new CompSoft.cf_Bases.cf_Label();
            this.cboNivel = new CompSoft.cf_Bases.cf_ComboBox();
            this.SuspendLayout();
            // 
            // cf_Label1
            // 
            this.cf_Label1.AutoSize = true;
            this.cf_Label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label1.Location = new System.Drawing.Point(19, 35);
            this.cf_Label1.Name = "cf_Label1";
            this.cf_Label1.Size = new System.Drawing.Size(57, 13);
            this.cf_Label1.TabIndex = 3;
            this.cf_Label1.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Coluna_LookUp = 0;
            this.txtDescricao.ControlSource = "Descricao";
            this.txtDescricao.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescricao.Grupo = string.Empty;
            this.txtDescricao.Incluir_QueryBy = true;
            this.txtDescricao.Location = new System.Drawing.Point(80, 31);
            this.txtDescricao.LookUp = false;
            this.txtDescricao.MensagemObrigatorio = "Campo obrigatório";
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Obrigatorio = true;
            this.txtDescricao.Qtde_Casas_Decimais = 0;
            this.txtDescricao.Size = new System.Drawing.Size(355, 20);
            this.txtDescricao.SQLStatement = string.Empty;
            this.txtDescricao.Tabela = "Menus_Itens";
            this.txtDescricao.Tabela_INNER = null;
            this.txtDescricao.TabIndex = 4;
            this.txtDescricao.TipoControles = CompSoft.TipoControle.Geral;
            this.txtDescricao.ValorAnterior = string.Empty;
            // 
            // cf_Label2
            // 
            this.cf_Label2.AutoSize = true;
            this.cf_Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label2.Location = new System.Drawing.Point(40, 62);
            this.cf_Label2.Name = "cf_Label2";
            this.cf_Label2.Size = new System.Drawing.Size(34, 13);
            this.cf_Label2.TabIndex = 5;
            this.cf_Label2.Text = "Nivel:";
            // 
            // txtParentNivel
            // 
            this.txtParentNivel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
            this.txtParentNivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParentNivel.Coluna_LookUp = 0;
            this.txtParentNivel.ControlSource = "ParentNivel";
            this.txtParentNivel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParentNivel.ForeColor = System.Drawing.Color.Black;
            this.txtParentNivel.Grupo = string.Empty;
            this.txtParentNivel.Incluir_QueryBy = true;
            this.txtParentNivel.Location = new System.Drawing.Point(200, 57);
            this.txtParentNivel.LookUp = true;
            this.txtParentNivel.MensagemObrigatorio = "Campo obrigatório";
            this.txtParentNivel.Name = "txtParentNivel";
            this.txtParentNivel.Obrigatorio = true;
            this.txtParentNivel.Qtde_Casas_Decimais = 0;
            this.txtParentNivel.Size = new System.Drawing.Size(61, 20);
            this.txtParentNivel.SQLStatement = "select Menu_Item as \'Código Menu\', Descricao as \'Descrição\' from menus_itens wher" +
                "e namespace is null and menu_item@";
            this.txtParentNivel.Tabela = "Menus_Itens";
            this.txtParentNivel.Tabela_INNER = null;
            this.txtParentNivel.TabIndex = 9;
            this.txtParentNivel.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtParentNivel.ValorAnterior = string.Empty;
            this.txtParentNivel.Validating += new System.ComponentModel.CancelEventHandler(this.txtParentNivel_Validating);
            // 
            // cf_Label3
            // 
            this.cf_Label3.AutoSize = true;
            this.cf_Label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label3.Location = new System.Drawing.Point(147, 60);
            this.cf_Label3.Name = "cf_Label3";
            this.cf_Label3.Size = new System.Drawing.Size(50, 13);
            this.cf_Label3.TabIndex = 8;
            this.cf_Label3.Text = "Item pai:";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNameSpace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNameSpace.Coluna_LookUp = 0;
            this.txtNameSpace.ControlSource = "NameSpace";
            this.txtNameSpace.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameSpace.ForeColor = System.Drawing.Color.DimGray;
            this.txtNameSpace.Grupo = string.Empty;
            this.txtNameSpace.Incluir_QueryBy = true;
            this.txtNameSpace.Location = new System.Drawing.Point(80, 83);
            this.txtNameSpace.LookUp = false;
            this.txtNameSpace.MensagemObrigatorio = "Campo obrigatório";
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Obrigatorio = false;
            this.txtNameSpace.Qtde_Casas_Decimais = 0;
            this.txtNameSpace.Size = new System.Drawing.Size(147, 20);
            this.txtNameSpace.SQLStatement = string.Empty;
            this.txtNameSpace.Tabela = "Menus_Itens";
            this.txtNameSpace.Tabela_INNER = null;
            this.txtNameSpace.TabIndex = 12;
            this.txtNameSpace.TipoControles = CompSoft.TipoControle.Geral;
            this.txtNameSpace.ValorAnterior = string.Empty;
            // 
            // cf_Label4
            // 
            this.cf_Label4.AutoSize = true;
            this.cf_Label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label4.Location = new System.Drawing.Point(7, 87);
            this.cf_Label4.Name = "cf_Label4";
            this.cf_Label4.Size = new System.Drawing.Size(67, 13);
            this.cf_Label4.TabIndex = 11;
            this.cf_Label4.Text = "NameSpace:";
            // 
            // txtFormulario
            // 
            this.txtFormulario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFormulario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFormulario.Coluna_LookUp = 0;
            this.txtFormulario.ControlSource = "Formulario";
            this.txtFormulario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFormulario.ForeColor = System.Drawing.Color.DimGray;
            this.txtFormulario.Grupo = string.Empty;
            this.txtFormulario.Incluir_QueryBy = true;
            this.txtFormulario.Location = new System.Drawing.Point(300, 83);
            this.txtFormulario.LookUp = false;
            this.txtFormulario.MensagemObrigatorio = "Campo obrigatório";
            this.txtFormulario.Name = "txtFormulario";
            this.txtFormulario.Obrigatorio = false;
            this.txtFormulario.Qtde_Casas_Decimais = 0;
            this.txtFormulario.Size = new System.Drawing.Size(135, 20);
            this.txtFormulario.SQLStatement = string.Empty;
            this.txtFormulario.Tabela = "Menus_Itens";
            this.txtFormulario.Tabela_INNER = null;
            this.txtFormulario.TabIndex = 14;
            this.txtFormulario.TipoControles = CompSoft.TipoControle.Geral;
            this.txtFormulario.ValorAnterior = string.Empty;
            // 
            // cf_Label5
            // 
            this.cf_Label5.AutoSize = true;
            this.cf_Label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label5.Location = new System.Drawing.Point(233, 87);
            this.cf_Label5.Name = "cf_Label5";
            this.cf_Label5.Size = new System.Drawing.Size(61, 13);
            this.cf_Label5.TabIndex = 13;
            this.cf_Label5.Text = "Formulário:";
            // 
            // cf_CheckBox1
            // 
            this.cf_CheckBox1.AutoSize = true;
            this.cf_CheckBox1.ControlSource = "Ativo";
            this.cf_CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cf_CheckBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_CheckBox1.Grupo = string.Empty;
            this.cf_CheckBox1.Location = new System.Drawing.Point(380, 8);
            this.cf_CheckBox1.MensagemObrigatorio = string.Empty;
            this.cf_CheckBox1.Name = "cf_CheckBox1";
            this.cf_CheckBox1.Obrigatorio = false;
            this.cf_CheckBox1.Size = new System.Drawing.Size(54, 17);
            this.cf_CheckBox1.Tabela = "Menus_Itens";
            this.cf_CheckBox1.Tabela_INNER = null;
            this.cf_CheckBox1.TabIndex = 2;
            this.cf_CheckBox1.TabStop = false;
            this.cf_CheckBox1.Text = "Ativo";
            this.cf_CheckBox1.UseVisualStyleBackColor = true;
            this.cf_CheckBox1.ValorAnterior = false;
            // 
            // txtDescParent
            // 
            this.txtDescParent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescParent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescParent.Coluna_LookUp = 0;
            this.txtDescParent.ControlSource = "Desc_Parent";
            this.txtDescParent.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescParent.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescParent.Grupo = string.Empty;
            this.txtDescParent.Incluir_QueryBy = false;
            this.txtDescParent.Location = new System.Drawing.Point(267, 57);
            this.txtDescParent.LookUp = false;
            this.txtDescParent.MensagemObrigatorio = "Campo obrigatório";
            this.txtDescParent.Name = "txtDescParent";
            this.txtDescParent.Obrigatorio = false;
            this.txtDescParent.Qtde_Casas_Decimais = 0;
            this.txtDescParent.Size = new System.Drawing.Size(168, 20);
            this.txtDescParent.SQLStatement = string.Empty;
            this.txtDescParent.Tabela = "Menus_Itens";
            this.txtDescParent.Tabela_INNER = "mi";
            this.txtDescParent.TabIndex = 10;
            this.txtDescParent.TipoControles = CompSoft.TipoControle.Geral;
            this.txtDescParent.ValorAnterior = string.Empty;
            // 
            // txtMenuItem
            // 
            this.txtMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMenuItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMenuItem.Coluna_LookUp = 0;
            this.txtMenuItem.ControlSource = "Menu_Item";
            this.txtMenuItem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.txtMenuItem.Grupo = string.Empty;
            this.txtMenuItem.Incluir_QueryBy = true;
            this.txtMenuItem.Location = new System.Drawing.Point(80, 5);
            this.txtMenuItem.LookUp = false;
            this.txtMenuItem.MensagemObrigatorio = "Campo obrigatório";
            this.txtMenuItem.Name = "txtMenuItem";
            this.txtMenuItem.Obrigatorio = true;
            this.txtMenuItem.Qtde_Casas_Decimais = 0;
            this.txtMenuItem.Size = new System.Drawing.Size(78, 20);
            this.txtMenuItem.SQLStatement = string.Empty;
            this.txtMenuItem.Tabela = "Menus_Itens";
            this.txtMenuItem.Tabela_INNER = null;
            this.txtMenuItem.TabIndex = 1;
            this.txtMenuItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMenuItem.TipoControles = CompSoft.TipoControle.Inteiro;
            this.txtMenuItem.ValorAnterior = string.Empty;
            // 
            // cf_Label7
            // 
            this.cf_Label7.AutoSize = true;
            this.cf_Label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cf_Label7.Location = new System.Drawing.Point(19, 10);
            this.cf_Label7.Name = "cf_Label7";
            this.cf_Label7.Size = new System.Drawing.Size(60, 13);
            this.cf_Label7.TabIndex = 0;
            this.cf_Label7.Text = "Menu item:";
            // 
            // cboNivel
            // 
            this.cboNivel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboNivel.ControlSource = "Nivel";
            this.cboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboNivel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNivel.ForeColor = System.Drawing.Color.DimGray;
            this.cboNivel.FormattingEnabled = true;
            this.cboNivel.Grupo = string.Empty;
            this.cboNivel.Location = new System.Drawing.Point(80, 57);
            this.cboNivel.MensagemObrigatorio = "Campo obrigatório";
            this.cboNivel.Name = "cboNivel";
            this.cboNivel.Obrigatorio = false;
            this.cboNivel.Size = new System.Drawing.Size(61, 21);
            this.cboNivel.SQLStatement = "select 0 as \'cod\', \'Root\' as \'Desc\' union select 1 as \'cod\', \'Filho\' as \'Desc\'";
            this.cboNivel.Tabela = "Menus_Itens";
            this.cboNivel.Tabela_INNER = null;
            this.cboNivel.TabIndex = 6;
            this.cboNivel.ValorAnterior = string.Empty;
            // 
            // f0003
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 111);
            this.Controls.Add(this.cboNivel);
            this.Controls.Add(this.txtMenuItem);
            this.Controls.Add(this.cf_Label7);
            this.Controls.Add(this.txtDescParent);
            this.Controls.Add(this.cf_CheckBox1);
            this.Controls.Add(this.txtFormulario);
            this.Controls.Add(this.cf_Label5);
            this.Controls.Add(this.txtNameSpace);
            this.Controls.Add(this.cf_Label4);
            this.Controls.Add(this.txtParentNivel);
            this.Controls.Add(this.cf_Label3);
            this.Controls.Add(this.cf_Label2);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.cf_Label1);
            this.MainTabela = "Menus_Itens";
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "f0003";
            this.Text = "Itens do menu";
            this.user_AfterRefreshData += new CompSoft.FormSet.AfterRefreshData(this.frmCadMenu_Item_user_AfterRefreshData);
            this.user_AfterNew += new CompSoft.FormSet.AfterNew(this.f0003_user_AfterNew);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CompSoft.cf_Bases.cf_Label cf_Label1;
        private CompSoft.cf_Bases.cf_TextBox txtDescricao;
        private CompSoft.cf_Bases.cf_Label cf_Label2;
        private CompSoft.cf_Bases.cf_TextBox txtParentNivel;
        private CompSoft.cf_Bases.cf_Label cf_Label3;
        private CompSoft.cf_Bases.cf_TextBox txtNameSpace;
        private CompSoft.cf_Bases.cf_Label cf_Label4;
        private CompSoft.cf_Bases.cf_TextBox txtFormulario;
        private CompSoft.cf_Bases.cf_Label cf_Label5;
        private CompSoft.cf_Bases.cf_CheckBox cf_CheckBox1;
        private CompSoft.cf_Bases.cf_TextBox txtDescParent;
        private CompSoft.cf_Bases.cf_TextBox txtMenuItem;
        private CompSoft.cf_Bases.cf_Label cf_Label7;
        private CompSoft.cf_Bases.cf_ComboBox cboNivel;
    }
}