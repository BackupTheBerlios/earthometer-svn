/*
 * Erstellt mit SharpDevelop.
 * Benutzer: flammensboeck
 * Datum: 29.01.2008
 * Zeit: 10:51
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
namespace Sosp.EarthOMeter.WFGUI
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.einfügenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.distancesGridView = new System.Windows.Forms.DataGridView();
			this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.distancesGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.bearbeitenToolStripMenuItem,
									this.hilfeToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(712, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// bearbeitenToolStripMenuItem
			// 
			this.bearbeitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.öffnenToolStripMenuItem,
									this.einfügenToolStripMenuItem});
			this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
			this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.bearbeitenToolStripMenuItem.Text = "Bearbeiten";
			// 
			// öffnenToolStripMenuItem
			// 
			this.öffnenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("öffnenToolStripMenuItem.Image")));
			this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
			this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.öffnenToolStripMenuItem.Text = "Öffnen";
			this.öffnenToolStripMenuItem.ToolTipText = "KML-Datei öffnen";
			this.öffnenToolStripMenuItem.Click += new System.EventHandler(this.ÖffnenToolStripMenuItemClick);
			// 
			// einfügenToolStripMenuItem
			// 
			this.einfügenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("einfügenToolStripMenuItem.Image")));
			this.einfügenToolStripMenuItem.Name = "einfügenToolStripMenuItem";
			this.einfügenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.einfügenToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.einfügenToolStripMenuItem.Text = "Einfügen";
			this.einfügenToolStripMenuItem.ToolTipText = "Aus Zwischenablage einfügen";
			this.einfügenToolStripMenuItem.Click += new System.EventHandler(this.EinfügenToolStripMenuItemClick);
			// 
			// hilfeToolStripMenuItem
			// 
			this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.infoToolStripMenuItem});
			this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
			this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.hilfeToolStripMenuItem.Text = "Hilfe";
			// 
			// infoToolStripMenuItem
			// 
			this.infoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("infoToolStripMenuItem.Image")));
			this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
			this.infoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.infoToolStripMenuItem.Text = "Info...";
			this.infoToolStripMenuItem.Click += new System.EventHandler(this.InfoToolStripMenuItemClick);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripButton1,
									this.toolStripButton2});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(712, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "toolStripButton1";
			this.toolStripButton1.ToolTipText = "KML-Datei öffnen";
			this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1Click);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton2.Text = "toolStripButton2";
			this.toolStripButton2.ToolTipText = "Aus Zwischenablage einfügen";
			this.toolStripButton2.Click += new System.EventHandler(this.ToolStripButton2Click);
			// 
			// distancesGridView
			// 
			this.distancesGridView.AllowUserToAddRows = false;
			this.distancesGridView.AllowUserToDeleteRows = false;
			this.distancesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.distancesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.colName,
									this.colLength});
			this.distancesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.distancesGridView.Location = new System.Drawing.Point(0, 49);
			this.distancesGridView.Name = "distancesGridView";
			this.distancesGridView.ReadOnly = true;
			this.distancesGridView.Size = new System.Drawing.Size(712, 374);
			this.distancesGridView.TabIndex = 2;
			this.distancesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellContentClick);
			// 
			// colName
			// 
			this.colName.HeaderText = "Name";
			this.colName.MinimumWidth = 150;
			this.colName.Name = "colName";
			this.colName.ReadOnly = true;
			this.colName.Width = 200;
			// 
			// colLength
			// 
			this.colLength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colLength.HeaderText = "Streckenlänge";
			this.colLength.Name = "colLength";
			this.colLength.ReadOnly = true;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "kml";
			this.openFileDialog1.Filter = "KML files (*.kml)|*.kml";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(712, 423);
			this.Controls.Add(this.distancesGridView);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "EarthOMeter";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.distancesGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.DataGridView distancesGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
		private System.Windows.Forms.DataGridViewTextBoxColumn colName;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem einfügenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
	}
}
