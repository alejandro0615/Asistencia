namespace Asistencia
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aLUMNOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gstionDeAlumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aSIGNATURAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDeAsignaturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aSISTENCIAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDeAsistenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gENERALToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aCUDIENTEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pROFESORESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gRADOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hISTORIALASISTENCIASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarAcudienteDeAlumnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aLUMNOSToolStripMenuItem,
            this.aSIGNATURAToolStripMenuItem,
            this.aSISTENCIAToolStripMenuItem,
            this.gENERALToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1314, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aLUMNOSToolStripMenuItem
            // 
            this.aLUMNOSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gstionDeAlumnosToolStripMenuItem});
            this.aLUMNOSToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aLUMNOSToolStripMenuItem.Image")));
            this.aLUMNOSToolStripMenuItem.Name = "aLUMNOSToolStripMenuItem";
            this.aLUMNOSToolStripMenuItem.Size = new System.Drawing.Size(137, 29);
            this.aLUMNOSToolStripMenuItem.Text = "ALUMNOS";
            // 
            // gstionDeAlumnosToolStripMenuItem
            // 
            this.gstionDeAlumnosToolStripMenuItem.Name = "gstionDeAlumnosToolStripMenuItem";
            this.gstionDeAlumnosToolStripMenuItem.Size = new System.Drawing.Size(272, 34);
            this.gstionDeAlumnosToolStripMenuItem.Text = "Gestion de alumnos";
            this.gstionDeAlumnosToolStripMenuItem.Click += new System.EventHandler(this.gstionDeAlumnosToolStripMenuItem_Click);
            // 
            // aSIGNATURAToolStripMenuItem
            // 
            this.aSIGNATURAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDeAsignaturasToolStripMenuItem});
            this.aSIGNATURAToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aSIGNATURAToolStripMenuItem.Image")));
            this.aSIGNATURAToolStripMenuItem.Name = "aSIGNATURAToolStripMenuItem";
            this.aSIGNATURAToolStripMenuItem.Size = new System.Drawing.Size(159, 29);
            this.aSIGNATURAToolStripMenuItem.Text = "ASIGNATURA";
            // 
            // gestionDeAsignaturasToolStripMenuItem
            // 
            this.gestionDeAsignaturasToolStripMenuItem.Name = "gestionDeAsignaturasToolStripMenuItem";
            this.gestionDeAsignaturasToolStripMenuItem.Size = new System.Drawing.Size(294, 34);
            this.gestionDeAsignaturasToolStripMenuItem.Text = "Gestion de asignaturas";
            this.gestionDeAsignaturasToolStripMenuItem.Click += new System.EventHandler(this.gestionDeAsignaturasToolStripMenuItem_Click);
            // 
            // aSISTENCIAToolStripMenuItem
            // 
            this.aSISTENCIAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDeAsistenciaToolStripMenuItem});
            this.aSISTENCIAToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aSISTENCIAToolStripMenuItem.Image")));
            this.aSISTENCIAToolStripMenuItem.Name = "aSISTENCIAToolStripMenuItem";
            this.aSISTENCIAToolStripMenuItem.Size = new System.Drawing.Size(148, 29);
            this.aSISTENCIAToolStripMenuItem.Text = "ASISTENCIA";
            this.aSISTENCIAToolStripMenuItem.Click += new System.EventHandler(this.aSISTENCIAToolStripMenuItem_Click);
            // 
            // gestionDeAsistenciaToolStripMenuItem
            // 
            this.gestionDeAsistenciaToolStripMenuItem.Name = "gestionDeAsistenciaToolStripMenuItem";
            this.gestionDeAsistenciaToolStripMenuItem.Size = new System.Drawing.Size(282, 34);
            this.gestionDeAsistenciaToolStripMenuItem.Text = "Gestion de Asistencia";
            this.gestionDeAsistenciaToolStripMenuItem.Click += new System.EventHandler(this.gestionDeAsistenciaToolStripMenuItem_Click);
            // 
            // gENERALToolStripMenuItem
            // 
            this.gENERALToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aCUDIENTEToolStripMenuItem,
            this.pROFESORESToolStripMenuItem,
            this.gRADOToolStripMenuItem,
            this.hISTORIALASISTENCIASToolStripMenuItem,
            this.buscarAcudienteDeAlumnoToolStripMenuItem});
            this.gENERALToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("gENERALToolStripMenuItem.Image")));
            this.gENERALToolStripMenuItem.Name = "gENERALToolStripMenuItem";
            this.gENERALToolStripMenuItem.Size = new System.Drawing.Size(126, 29);
            this.gENERALToolStripMenuItem.Text = "GENERAL";
            // 
            // aCUDIENTEToolStripMenuItem
            // 
            this.aCUDIENTEToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aCUDIENTEToolStripMenuItem.Image")));
            this.aCUDIENTEToolStripMenuItem.Name = "aCUDIENTEToolStripMenuItem";
            this.aCUDIENTEToolStripMenuItem.Size = new System.Drawing.Size(342, 34);
            this.aCUDIENTEToolStripMenuItem.Text = "ACUDIENTE";
            this.aCUDIENTEToolStripMenuItem.Click += new System.EventHandler(this.aCUDIENTEToolStripMenuItem_Click);
            // 
            // pROFESORESToolStripMenuItem
            // 
            this.pROFESORESToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pROFESORESToolStripMenuItem.Image")));
            this.pROFESORESToolStripMenuItem.Name = "pROFESORESToolStripMenuItem";
            this.pROFESORESToolStripMenuItem.Size = new System.Drawing.Size(342, 34);
            this.pROFESORESToolStripMenuItem.Text = "PROFESORES";
            this.pROFESORESToolStripMenuItem.Click += new System.EventHandler(this.pROFESORESToolStripMenuItem_Click);
            // 
            // gRADOToolStripMenuItem
            // 
            this.gRADOToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("gRADOToolStripMenuItem.Image")));
            this.gRADOToolStripMenuItem.Name = "gRADOToolStripMenuItem";
            this.gRADOToolStripMenuItem.Size = new System.Drawing.Size(342, 34);
            this.gRADOToolStripMenuItem.Text = "GRADO";
            this.gRADOToolStripMenuItem.Click += new System.EventHandler(this.gRADOToolStripMenuItem_Click);
            // 
            // hISTORIALASISTENCIASToolStripMenuItem
            // 
            this.hISTORIALASISTENCIASToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hISTORIALASISTENCIASToolStripMenuItem.Image")));
            this.hISTORIALASISTENCIASToolStripMenuItem.Name = "hISTORIALASISTENCIASToolStripMenuItem";
            this.hISTORIALASISTENCIASToolStripMenuItem.Size = new System.Drawing.Size(342, 34);
            this.hISTORIALASISTENCIASToolStripMenuItem.Text = "HISTORIAL ASISTENCIAS";
            this.hISTORIALASISTENCIASToolStripMenuItem.Click += new System.EventHandler(this.hISTORIALASISTENCIASToolStripMenuItem_Click);
            // 
            // buscarAcudienteDeAlumnoToolStripMenuItem
            // 
            this.buscarAcudienteDeAlumnoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("buscarAcudienteDeAlumnoToolStripMenuItem.Image")));
            this.buscarAcudienteDeAlumnoToolStripMenuItem.Name = "buscarAcudienteDeAlumnoToolStripMenuItem";
            this.buscarAcudienteDeAlumnoToolStripMenuItem.Size = new System.Drawing.Size(342, 34);
            this.buscarAcudienteDeAlumnoToolStripMenuItem.Text = "Buscar Acudiente de Alumno";
            this.buscarAcudienteDeAlumnoToolStripMenuItem.Click += new System.EventHandler(this.buscarAcudienteDeAlumnoToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1314, 620);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "GESTION DE ASISTENCIAS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aLUMNOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aSIGNATURAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aSISTENCIAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gENERALToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aCUDIENTEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pROFESORESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gRADOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gstionDeAlumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDeAsignaturasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDeAsistenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hISTORIALASISTENCIASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarAcudienteDeAlumnoToolStripMenuItem;
    }
}

