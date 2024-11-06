namespace CustomControl.Commons
{
    partial class VoicePlayerCommon
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonVoicePlayer = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTimer = new System.Windows.Forms.Label();
            this.progressBarVoice = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.buttonVoicePlayer)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonVoicePlayer
            // 
            this.buttonVoicePlayer.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonVoicePlayer.Image = global::CustomControl.Properties.Resources.sound_wave;
            this.buttonVoicePlayer.Location = new System.Drawing.Point(6, 10);
            this.buttonVoicePlayer.Margin = new System.Windows.Forms.Padding(0);
            this.buttonVoicePlayer.Name = "buttonVoicePlayer";
            this.buttonVoicePlayer.Size = new System.Drawing.Size(60, 40);
            this.buttonVoicePlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonVoicePlayer.TabIndex = 15;
            this.buttonVoicePlayer.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.progressBarVoice, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTimer, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(66, 10);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(383, 40);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTimer.ForeColor = System.Drawing.Color.White;
            this.labelTimer.Location = new System.Drawing.Point(4, 20);
            this.labelTimer.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.labelTimer.Size = new System.Drawing.Size(379, 20);
            this.labelTimer.TabIndex = 1;
            this.labelTimer.Text = "00:30";
            // 
            // progressBarVoice
            // 
            this.progressBarVoice.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarVoice.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.progressBarVoice.Location = new System.Drawing.Point(4, 16);
            this.progressBarVoice.Margin = new System.Windows.Forms.Padding(0);
            this.progressBarVoice.Name = "progressBarVoice";
            this.progressBarVoice.Size = new System.Drawing.Size(379, 4);
            this.progressBarVoice.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarVoice.TabIndex = 0;
            // 
            // VoicePlayerCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonVoicePlayer);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.Name = "VoicePlayerCommon";
            this.Padding = new System.Windows.Forms.Padding(6, 10, 6, 10);
            this.Size = new System.Drawing.Size(455, 60);
            ((System.ComponentModel.ISupportInitialize)(this.buttonVoicePlayer)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox buttonVoicePlayer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.ProgressBar progressBarVoice;
    }
}
