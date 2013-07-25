namespace Atlantis.Framework.TestLogging
{
  partial class TestLogForm
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
      this.label1 = new System.Windows.Forms.Label();
      this.ShopperId = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.OrderId = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.Pathway = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.SourceURL = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.HelpText = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.LogException = new System.Windows.Forms.Button();
      this.cmdLogDirect = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(15, 20);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(62, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Shopper &Id:";
      // 
      // ShopperId
      // 
      this.ShopperId.Location = new System.Drawing.Point(83, 17);
      this.ShopperId.Name = "ShopperId";
      this.ShopperId.Size = new System.Drawing.Size(143, 20);
      this.ShopperId.TabIndex = 1;
      this.ShopperId.Text = "822497";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(250, 20);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(48, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "&Order Id:";
      // 
      // OrderId
      // 
      this.OrderId.Location = new System.Drawing.Point(315, 17);
      this.OrderId.MaxLength = 6;
      this.OrderId.Name = "OrderId";
      this.OrderId.Size = new System.Drawing.Size(121, 20);
      this.OrderId.TabIndex = 3;
      this.OrderId.Text = "142796";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(15, 55);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(51, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "&Pathway:";
      // 
      // Pathway
      // 
      this.Pathway.Location = new System.Drawing.Point(83, 48);
      this.Pathway.Name = "Pathway";
      this.Pathway.Size = new System.Drawing.Size(353, 20);
      this.Pathway.TabIndex = 5;
      this.Pathway.Text = "{00000000-0000-0000-0000-000000000000}";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.cmdLogDirect);
      this.groupBox1.Controls.Add(this.SourceURL);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.HelpText);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.LogException);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.Pathway);
      this.groupBox1.Controls.Add(this.ShopperId);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.OrderId);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(451, 249);
      this.groupBox1.TabIndex = 6;
      this.groupBox1.TabStop = false;
      // 
      // SourceURL
      // 
      this.SourceURL.Location = new System.Drawing.Point(83, 79);
      this.SourceURL.Name = "SourceURL";
      this.SourceURL.Size = new System.Drawing.Size(353, 20);
      this.SourceURL.TabIndex = 7;
      this.SourceURL.Text = "Atlantis Framework Exception Log Test";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(15, 82);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(69, 13);
      this.label5.TabIndex = 6;
      this.label5.Text = "&Source URL:";
      // 
      // HelpText
      // 
      this.HelpText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.HelpText.Location = new System.Drawing.Point(18, 144);
      this.HelpText.Multiline = true;
      this.HelpText.Name = "HelpText";
      this.HelpText.ReadOnly = true;
      this.HelpText.Size = new System.Drawing.Size(418, 64);
      this.HelpText.TabIndex = 9;
      this.HelpText.Text = "An invalid request is sent to the Framework DataProvider component casuing an exc" +
          "eption to be raised and logged.";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(15, 138);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(0, 13);
      this.label4.TabIndex = 7;
      // 
      // LogException
      // 
      this.LogException.Location = new System.Drawing.Point(18, 110);
      this.LogException.Name = "LogException";
      this.LogException.Size = new System.Drawing.Size(114, 23);
      this.LogException.TabIndex = 8;
      this.LogException.Text = "&Log Exception";
      this.LogException.UseVisualStyleBackColor = true;
      this.LogException.Click += new System.EventHandler(this.LogException_Click);
      // 
      // cmdLogDirect
      // 
      this.cmdLogDirect.Location = new System.Drawing.Point(229, 110);
      this.cmdLogDirect.Name = "cmdLogDirect";
      this.cmdLogDirect.Size = new System.Drawing.Size(207, 23);
      this.cmdLogDirect.TabIndex = 10;
      this.cmdLogDirect.Text = "&Log Direct";
      this.cmdLogDirect.UseVisualStyleBackColor = true;
      this.cmdLogDirect.Click += new System.EventHandler(this.cmdLogDirect_Click);
      // 
      // TestLogForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(475, 273);
      this.Controls.Add(this.groupBox1);
      this.Name = "TestLogForm";
      this.Text = "Atlantis Framework Exception Log Test";
      this.Load += new System.EventHandler(this.TestLogForm_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox ShopperId;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox OrderId;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox Pathway;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button LogException;
    private System.Windows.Forms.TextBox HelpText;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox SourceURL;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button cmdLogDirect;
  }
}

