namespace View
{
    partial class Home
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
            this.btnCadastrarPaciente = new System.Windows.Forms.Button();
            this.btnBuscarPaciente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCadastrarPaciente
            // 
            this.btnCadastrarPaciente.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCadastrarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrarPaciente.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnCadastrarPaciente.Location = new System.Drawing.Point(130, 178);
            this.btnCadastrarPaciente.Name = "btnCadastrarPaciente";
            this.btnCadastrarPaciente.Size = new System.Drawing.Size(159, 45);
            this.btnCadastrarPaciente.TabIndex = 0;
            this.btnCadastrarPaciente.Text = "Cadastrar um paciente";
            this.btnCadastrarPaciente.UseVisualStyleBackColor = false;
            this.btnCadastrarPaciente.Click += new System.EventHandler(this.btnCadastrarPaciente_Click);
            // 
            // btnBuscarPaciente
            // 
            this.btnBuscarPaciente.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBuscarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPaciente.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnBuscarPaciente.Location = new System.Drawing.Point(346, 178);
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.Size = new System.Drawing.Size(159, 45);
            this.btnBuscarPaciente.TabIndex = 1;
            this.btnBuscarPaciente.Text = "Buscar paciente";
            this.btnBuscarPaciente.UseVisualStyleBackColor = false;
            this.btnBuscarPaciente.Click += new System.EventHandler(this.btnBuscarPaciente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(632, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sistema de Registros de Pacientes";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(670, 296);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscarPaciente);
            this.Controls.Add(this.btnCadastrarPaciente);
            this.Name = "Home";
            this.Text = "Tela Inicial";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCadastrarPaciente;
        private System.Windows.Forms.Button btnBuscarPaciente;
        private System.Windows.Forms.Label label1;
    }
}

