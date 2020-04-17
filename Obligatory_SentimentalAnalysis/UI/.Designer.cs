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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.txtPositiveSentiment = new System.Windows.Forms.TextBox();
			this.btnAddPositiveSentiment = new System.Windows.Forms.Button();
			this.listPositivesSentiments = new System.Windows.Forms.ListBox();
			this.btnDeletePositiveSentiment = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(763, 599);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// txtPositiveSentiment
			// 
			this.txtPositiveSentiment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
			this.txtPositiveSentiment.Location = new System.Drawing.Point(354, 89);
			this.txtPositiveSentiment.Margin = new System.Windows.Forms.Padding(2);
			this.txtPositiveSentiment.Name = "txtPositiveSentiment";
			this.txtPositiveSentiment.Size = new System.Drawing.Size(264, 20);
			this.txtPositiveSentiment.TabIndex = 1;
			// 
			// btnAddPositiveSentiment
			// 
			this.btnAddPositiveSentiment.Location = new System.Drawing.Point(622, 79);
			this.btnAddPositiveSentiment.Margin = new System.Windows.Forms.Padding(2);
			this.btnAddPositiveSentiment.Name = "btnAddPositiveSentiment";
			this.btnAddPositiveSentiment.Size = new System.Drawing.Size(131, 38);
			this.btnAddPositiveSentiment.TabIndex = 2;
			this.btnAddPositiveSentiment.Text = "Agregar";
			this.btnAddPositiveSentiment.UseVisualStyleBackColor = true;
			// 
			// listPositivesSentiments
			// 
			this.listPositivesSentiments.FormattingEnabled = true;
			this.listPositivesSentiments.Location = new System.Drawing.Point(464, 210);
			this.listPositivesSentiments.Margin = new System.Windows.Forms.Padding(2);
			this.listPositivesSentiments.Name = "listPositivesSentiments";
			this.listPositivesSentiments.Size = new System.Drawing.Size(192, 212);
			this.listPositivesSentiments.TabIndex = 3;
			// 
			// btnDeletePositiveSentiment
			// 
			this.btnDeletePositiveSentiment.Location = new System.Drawing.Point(455, 547);
			this.btnDeletePositiveSentiment.Margin = new System.Windows.Forms.Padding(2);
			this.btnDeletePositiveSentiment.Name = "btnDeletePositiveSentiment";
			this.btnDeletePositiveSentiment.Size = new System.Drawing.Size(165, 28);
			this.btnDeletePositiveSentiment.TabIndex = 4;
			this.btnDeletePositiveSentiment.Text = "Eliminar";
			this.btnDeletePositiveSentiment.UseVisualStyleBackColor = true;
			// 
			// MainMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(764, 599);
			this.Controls.Add(this.btnDeletePositiveSentiment);
			this.Controls.Add(this.listPositivesSentiments);
			this.Controls.Add(this.btnAddPositiveSentiment);
			this.Controls.Add(this.txtPositiveSentiment);
			this.Controls.Add(this.pictureBox1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MainMenu";
			this.Text = "MainMenu";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox txtPositiveSentiment;
		private System.Windows.Forms.Button btnAddPositiveSentiment;
		private System.Windows.Forms.ListBox listPositivesSentiments;
		private System.Windows.Forms.Button btnDeletePositiveSentiment;
	}
}

