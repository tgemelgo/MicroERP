using CompSoft.compFrameWork;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using System;
using System.Windows.Forms;

namespace CompSoft.cf_Bases.cf_DataGridView
{
    internal class cf_DataGridViewDatePikerEditControl : cf_DateEdit, IDataGridViewEditingControl
    {
        private DataGridView dataGridView;
        private bool valueChanged = false;
        private int rowIndex;

        #region Propriedades padrão do controle

        private void Set_Propriedades_Padrao()
        {
            this.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;

            this.Properties.Buttons.Clear();
            this.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo
                    , ""
                    , -1
                    , true
                    , true
                    , false
                    , DevExpress.Utils.HorzAlignment.Center
                    , null
                    , new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)))});

            this.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Properties.Mask.EditMask = "dd/MM/yyyy";
            compFrameWork.Funcoes func;
            this.Properties.MaxValue = func.Ultimo_Dia_Mes(Funcoes.Tipo_Dia.Dias_Corrido, DateTime.Now.AddYears(150));
            this.Properties.MinValue = Convert.ToDateTime("01/01/1901");

            this.Properties.LookAndFeel.UseWindowsXPTheme = true;
            this.Properties.LookAndFeel.SkinName = "The Asphalt World";
            this.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Properties.Mask.BeepOnError = true;
            this.Properties.Mask.SaveLiteral = false;
            this.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton()});

            this.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
        }

        #endregion Propriedades padrão do controle

        protected override PopupBaseForm CreatePopupForm()
        {
            PopupDateEditForm form = base.CreatePopupForm() as PopupDateEditForm;

            form.Calendar.ClearButton.Appearance.TextOptions.Trimming = Trimming.EllipsisCharacter;
            form.Calendar.ClearButton.Text = "Limpar";

            form.Calendar.TodayButton.Appearance.TextOptions.Trimming = Trimming.EllipsisCharacter;
            form.Calendar.TodayButton.Text = "Hoje";

            return form;
        }

        public cf_DataGridViewDatePikerEditControl()
        {
            this.Set_Propriedades_Padrao();
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue
        // property.
        public object EditingControlFormattedValue
        {
            get
            {
                if (this.EditValue == null || string.IsNullOrEmpty(this.EditValue.ToString()) || this.EditValue == DBNull.Value)
                    return DBNull.Value;
                else
                    return Convert.ToDateTime(this.EditValue);
            }
            set
            {
                if (value == null || string.IsNullOrEmpty(value.ToString()) || this.EditValue == DBNull.Value)
                    this.EditValue = null;
                else
                    this.EditValue = value;
            }
        }

        // Implements the
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // Implements the
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
        }

        // Implements the IDataGridViewEditingControl.EditingControlRowIndex
        // property.
        public int EditingControlRowIndex
        {
            get { return rowIndex; }
            set { rowIndex = value; }
        }

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey
        // method.
        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                case Keys.Tab:
                    return true;

                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit
        // method.
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            /*p = new PopupDateEditForm(this);
            p.Calendar.ClearButton.Text = "Limpar";
            p.Calendar.TodayButton.Text = "Hoje";*/
        }

        // Implements the IDataGridViewEditingControl
        // .RepositionEditingControlOnValueChange property.
        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlDataGridView property.
        public DataGridView EditingControlDataGridView
        {
            get { return dataGridView; }
            set { dataGridView = value; }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlValueChanged property.
        public bool EditingControlValueChanged
        {
            get { return valueChanged; }
            set { valueChanged = value; }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingPanelCursor property.
        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        protected override void OnEditValueChanged()
        {
            base.OnEditValueChanged();
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            valueChanged = true;
        }

        protected override void OnEditValueChanging(DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            base.OnEditValueChanging(e);
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            valueChanged = true;
        }
    }
}