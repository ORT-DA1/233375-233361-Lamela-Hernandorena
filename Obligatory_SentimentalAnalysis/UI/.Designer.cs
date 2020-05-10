namespace UI
{
	partial class MainMenu
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

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnAddSentiment = new System.Windows.Forms.Button();
			this.btnAddEntity = new System.Windows.Forms.Button();
			this.btnAddPhrase = new System.Windows.Forms.Button();
			this.btnAddAlarm = new System.Windows.Forms.Button();
			this.panelMain = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// btnAddSentiment
			// 
			this.btnAddSentiment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddSentiment.Location = new System.Drawing.Point(24, 161);
			this.btnAddSentiment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnAddSentiment.Name = "btnAddSentiment";
			this.btnAddSentiment.Size = new System.Drawing.Size(213, 71);
			this.btnAddSentiment.TabIndex = 5;
			this.btnAddSentiment.Text = "Agregar sentimiento";
			this.btnAddSentiment.UseVisualStyleBackColor = true;
			this.btnAddSentiment.Click += new System.EventHandler(this.btnAddSentiment_Click);
			// 
			// btnAddEntity
			// 
			this.btnAddEntity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddEntity.Location = new System.Drawing.Point(24, 263);
			this.btnAddEntity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnAddEntity.Name = "btnAddEntity";
			this.btnAddEntity.Size = new System.Drawing.Size(213, 69);
			this.btnAddEntity.TabIndex = 6;
			this.btnAddEntity.Text = "Agregar entidad";
			this.btnAddEntity.UseVisualStyleBackColor = true;
			this.btnAddEntity.Click += new System.EventHandler(this.btnAddEntity_Click);
			// 
			// btnAddPhrase
			// 
			this.btnAddPhrase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddPhrase.Location = new System.Drawing.Point(24, 360);
			this.btnAddPhrase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnAddPhrase.Name = "btnAddPhrase";
			this.btnAddPhrase.Size = new System.Drawing.Size(213, 90);
			this.btnAddPhrase.TabIndex = 7;
			this.btnAddPhrase.Text = "Agregar frase";
			this.btnAddPhrase.UseVisualStyleBackColor = true;
			this.btnAddPhrase.Click += new System.EventHandler(this.btnAddPhrase_Click);
			// 
			// btnAddAlarm
			// 
			this.btnAddAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddAlarm.Location = new System.Drawing.Point(24, 473);
			this.btnAddAlarm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnAddAlarm.Name = "btnAddAlarm";
			this.btnAddAlarm.Size = new System.Drawing.Size(213, 71);
			this.btnAddAlarm.TabIndex = 8;
			this.btnAddAlarm.Text = "Agregar alarma";
			this.btnAddAlarm.UseVisualStyleBackColor = true;
			// 
			// panelMain
			// 
			this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelMain.Location = new System.Drawing.Point(316, 75);
			this.panelMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(680, 583);
			this.panelMain.TabIndex = 9;
			// 
			// MainMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1019, 737);
			this.Controls.Add(this.panelMain);
			this.Controls.Add(this.btnAddAlarm);
			this.Controls.Add(this.btnAddPhrase);
			this.Controls.Add(this.btnAddEntity);
			this.Controls.Add(this.btnAddSentiment);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "MainMenu";
			this.Text = "MainMenu";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnAddSentiment;
		private System.Windows.Forms.Button btnAddEntity;
		private System.Windows.Forms.Button btnAddPhrase;
		private System.Windows.Forms.Button btnAddAlarm;
		private System.Windows.Forms.Panel panelMain;
	}
}

