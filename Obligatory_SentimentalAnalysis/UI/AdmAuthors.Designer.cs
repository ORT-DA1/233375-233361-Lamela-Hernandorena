namespace UI
{
    partial class AdmAuthors
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxLastname = new System.Windows.Forms.TextBox();
            this.dateTimePickerBirth = new System.Windows.Forms.DateTimePicker();
            this.btnAddAuthor = new System.Windows.Forms.Button();
            this.btnDeleteAuthor = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.listBoxAuthors = new System.Windows.Forms.ListBox();
            this.labelError = new System.Windows.Forms.Label();
            this.btnModifyAuthor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(150, 82);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(223, 20);
            this.textBoxUserName.TabIndex = 0;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(91, 120);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(196, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // textBoxLastname
            // 
            this.textBoxLastname.Location = new System.Drawing.Point(91, 163);
            this.textBoxLastname.Name = "textBoxLastname";
            this.textBoxLastname.Size = new System.Drawing.Size(196, 20);
            this.textBoxLastname.TabIndex = 2;
            // 
            // dateTimePickerBirth
            // 
            this.dateTimePickerBirth.Location = new System.Drawing.Point(186, 201);
            this.dateTimePickerBirth.Name = "dateTimePickerBirth";
            this.dateTimePickerBirth.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerBirth.TabIndex = 3;
            // 
            // btnAddAuthor
            // 
            this.btnAddAuthor.BackColor = System.Drawing.Color.Transparent;
            this.btnAddAuthor.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnAddAuthor.FlatAppearance.BorderSize = 0;
            this.btnAddAuthor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddAuthor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddAuthor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAuthor.Location = new System.Drawing.Point(150, 238);
            this.btnAddAuthor.Name = "btnAddAuthor";
            this.btnAddAuthor.Size = new System.Drawing.Size(163, 42);
            this.btnAddAuthor.TabIndex = 4;
            this.btnAddAuthor.UseVisualStyleBackColor = false;
            this.btnAddAuthor.Click += new System.EventHandler(this.btnAddAuthor_Click);
            // 
            // btnDeleteAuthor
            // 
            this.btnDeleteAuthor.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteAuthor.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnDeleteAuthor.FlatAppearance.BorderSize = 0;
            this.btnDeleteAuthor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteAuthor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteAuthor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAuthor.Location = new System.Drawing.Point(236, 541);
            this.btnDeleteAuthor.Name = "btnDeleteAuthor";
            this.btnDeleteAuthor.Size = new System.Drawing.Size(163, 42);
            this.btnDeleteAuthor.TabIndex = 5;
            this.btnDeleteAuthor.UseVisualStyleBackColor = false;
            this.btnDeleteAuthor.Click += new System.EventHandler(this.btnDeleteAuthor_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.Transparent;
            this.btnModify.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnModify.FlatAppearance.BorderSize = 0;
            this.btnModify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnModify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.Location = new System.Drawing.Point(58, 541);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(163, 42);
            this.btnModify.TabIndex = 6;
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // listBoxAuthors
            // 
            this.listBoxAuthors.FormattingEnabled = true;
            this.listBoxAuthors.Location = new System.Drawing.Point(21, 323);
            this.listBoxAuthors.Name = "listBoxAuthors";
            this.listBoxAuthors.Size = new System.Drawing.Size(408, 212);
            this.listBoxAuthors.TabIndex = 7;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(147, 283);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 13);
            this.labelError.TabIndex = 8;
            // 
            // btnModifyAuthor
            // 
            this.btnModifyAuthor.BackgroundImage = global::UI.Properties.Resources.btnModificar;
            this.btnModifyAuthor.FlatAppearance.BorderSize = 0;
            this.btnModifyAuthor.Location = new System.Drawing.Point(150, 238);
            this.btnModifyAuthor.Name = "btnModifyAuthor";
            this.btnModifyAuthor.Size = new System.Drawing.Size(163, 42);
            this.btnModifyAuthor.TabIndex = 9;
            this.btnModifyAuthor.UseVisualStyleBackColor = true;
            this.btnModifyAuthor.Click += new System.EventHandler(this.btnModifyAuthor_Click);
            // 
            // AdmAuthors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UI.Properties.Resources.AgregadoAutores;
            this.Controls.Add(this.btnModifyAuthor);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.listBoxAuthors);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnDeleteAuthor);
            this.Controls.Add(this.btnAddAuthor);
            this.Controls.Add(this.dateTimePickerBirth);
            this.Controls.Add(this.textBoxLastname);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxUserName);
            this.Name = "AdmAuthors";
            this.Size = new System.Drawing.Size(460, 638);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxLastname;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirth;
        private System.Windows.Forms.Button btnAddAuthor;
        private System.Windows.Forms.Button btnDeleteAuthor;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.ListBox listBoxAuthors;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button btnModifyAuthor;
    }
}
