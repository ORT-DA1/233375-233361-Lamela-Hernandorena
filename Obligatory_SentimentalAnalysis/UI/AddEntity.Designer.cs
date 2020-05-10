namespace UI
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
            this.lblAddEntity = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEntity = new System.Windows.Forms.TextBox();
            this.btnAddEntity = new System.Windows.Forms.Button();
            this.listBoxEntities = new System.Windows.Forms.ListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAddEntity
            // 
            this.lblAddEntity.AutoSize = true;
            this.lblAddEntity.Location = new System.Drawing.Point(225, 9);
            this.lblAddEntity.Name = "lblAddEntity";
            this.lblAddEntity.Size = new System.Drawing.Size(82, 13);
            this.lblAddEntity.TabIndex = 1;
            this.lblAddEntity.Text = "Agregar entidad";
            this.lblAddEntity.Click += new System.EventHandler(this.lblAddSentiment_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Entidad";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxEntity
            // 
            this.textBoxEntity.Location = new System.Drawing.Point(132, 60);
            this.textBoxEntity.Name = "textBoxEntity";
            this.textBoxEntity.Size = new System.Drawing.Size(270, 20);
            this.textBoxEntity.TabIndex = 3;
            this.textBoxEntity.TextChanged += new System.EventHandler(this.textBoxEntity_TextChanged);
            // 
            // btnAddEntity
            // 
            this.btnAddEntity.Location = new System.Drawing.Point(205, 107);
            this.btnAddEntity.Name = "btnAddEntity";
            this.btnAddEntity.Size = new System.Drawing.Size(102, 23);
            this.btnAddEntity.TabIndex = 4;
            this.btnAddEntity.Text = "Agregar";
            this.btnAddEntity.UseVisualStyleBackColor = true;
            this.btnAddEntity.Click += new System.EventHandler(this.btnAddEntity_Click);
            // 
            // listBoxEntities
            // 
            this.listBoxEntities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxEntities.FormattingEnabled = true;
            this.listBoxEntities.Location = new System.Drawing.Point(132, 167);
            this.listBoxEntities.Name = "listBoxEntities";
            this.listBoxEntities.Size = new System.Drawing.Size(245, 199);
            this.listBoxEntities.TabIndex = 5;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(185, 396);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(132, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // AddEntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.listBoxEntities);
            this.Controls.Add(this.btnAddEntity);
            this.Controls.Add(this.textBoxEntity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAddEntity);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AddEntity";
            this.Size = new System.Drawing.Size(510, 474);
            this.Load += new System.EventHandler(this.AddEntity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblAddEntity;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEntity;
        private System.Windows.Forms.Button btnAddEntity;
        private System.Windows.Forms.ListBox listBoxEntities;
        private System.Windows.Forms.Button btnDelete;
    }
}
