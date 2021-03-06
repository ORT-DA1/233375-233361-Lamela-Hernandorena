﻿namespace UI
{
	partial class AddEntity
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
			this.textBoxEntity = new System.Windows.Forms.TextBox();
			this.btnAddEntity = new System.Windows.Forms.Button();
			this.listBoxEntities = new System.Windows.Forms.ListBox();
			this.btnDelete = new System.Windows.Forms.Button();
			this.labelError = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBoxEntity
			// 
			this.textBoxEntity.Location = new System.Drawing.Point(169, 76);
			this.textBoxEntity.Name = "textBoxEntity";
			this.textBoxEntity.Size = new System.Drawing.Size(270, 20);
			this.textBoxEntity.TabIndex = 1;
			// 
			// btnAddEntity
			// 
			this.btnAddEntity.BackColor = System.Drawing.Color.Transparent;
			this.btnAddEntity.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnAddEntity.FlatAppearance.BorderSize = 0;
			this.btnAddEntity.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btnAddEntity.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btnAddEntity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAddEntity.Location = new System.Drawing.Point(132, 119);
			this.btnAddEntity.Name = "btnAddEntity";
			this.btnAddEntity.Size = new System.Drawing.Size(163, 42);
			this.btnAddEntity.TabIndex = 2;
			this.btnAddEntity.UseVisualStyleBackColor = false;
			this.btnAddEntity.Click += new System.EventHandler(this.btnAddEntity_Click);
			// 
			// listBoxEntities
			// 
			this.listBoxEntities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxEntities.FormattingEnabled = true;
			this.listBoxEntities.Location = new System.Drawing.Point(132, 258);
			this.listBoxEntities.Name = "listBoxEntities";
			this.listBoxEntities.Size = new System.Drawing.Size(195, 264);
			this.listBoxEntities.TabIndex = 3;
			// 
			// btnDelete
			// 
			this.btnDelete.BackColor = System.Drawing.Color.Transparent;
			this.btnDelete.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
			this.btnDelete.FlatAppearance.BorderSize = 0;
			this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDelete.Location = new System.Drawing.Point(149, 537);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(162, 34);
			this.btnDelete.TabIndex = 4;
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// labelError
			// 
			this.labelError.AutoSize = true;
			this.labelError.ForeColor = System.Drawing.Color.Red;
			this.labelError.Location = new System.Drawing.Point(146, 103);
			this.labelError.Name = "labelError";
			this.labelError.Size = new System.Drawing.Size(33, 13);
			this.labelError.TabIndex = 5;
			this.labelError.Visible = false;
			// 
			// AddEntity
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::UI.Properties.Resources.AgregarEntidades1;
			this.Controls.Add(this.labelError);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.listBoxEntities);
			this.Controls.Add(this.btnAddEntity);
			this.Controls.Add(this.textBoxEntity);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "AddEntity";
			this.Size = new System.Drawing.Size(460, 638);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
        private System.Windows.Forms.TextBox textBoxEntity;
        private System.Windows.Forms.Button btnAddEntity;
        private System.Windows.Forms.ListBox listBoxEntities;
        private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Label labelError;
	}
}
