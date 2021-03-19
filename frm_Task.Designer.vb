<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Task
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Task))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chk_Gen_Abilitato = New System.Windows.Forms.CheckBox()
        Me.chk_Gen_CopiaShadow = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Gen_ID = New System.Windows.Forms.TextBox()
        Me.txt_Gen_Nome = New System.Windows.Forms.TextBox()
        Me.txt_Gen_Gruppo = New System.Windows.Forms.TextBox()
        Me.txt_Gen_Priorita = New System.Windows.Forms.TextBox()
        Me.cbo_Gen_Tipo = New System.Windows.Forms.ComboBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ImageList = Me.ImageList1
        Me.TabControl1.Location = New System.Drawing.Point(12, 29)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(776, 461)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cbo_Gen_Tipo)
        Me.TabPage1.Controls.Add(Me.txt_Gen_Priorita)
        Me.TabPage1.Controls.Add(Me.txt_Gen_Gruppo)
        Me.TabPage1.Controls.Add(Me.txt_Gen_Nome)
        Me.TabPage1.Controls.Add(Me.txt_Gen_ID)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.chk_Gen_CopiaShadow)
        Me.TabPage1.Controls.Add(Me.chk_Gen_Abilitato)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.ImageKey = "GENERALE"
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(768, 432)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Generale"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.ImageKey = "PERCORSI"
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(634, 468)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Percorsi"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "GENERALE")
        Me.ImageList1.Images.SetKeyName(1, "PERCORSI")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(21, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Identificativo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(21, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nome:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(21, 211)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Gruppo:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(21, 274)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 18)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Priorità:"
        '
        'chk_Gen_Abilitato
        '
        Me.chk_Gen_Abilitato.AutoSize = True
        Me.chk_Gen_Abilitato.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Gen_Abilitato.ForeColor = System.Drawing.Color.Blue
        Me.chk_Gen_Abilitato.Location = New System.Drawing.Point(456, 324)
        Me.chk_Gen_Abilitato.Name = "chk_Gen_Abilitato"
        Me.chk_Gen_Abilitato.Size = New System.Drawing.Size(84, 22)
        Me.chk_Gen_Abilitato.TabIndex = 4
        Me.chk_Gen_Abilitato.Text = "Abilitato"
        Me.chk_Gen_Abilitato.UseVisualStyleBackColor = True
        '
        'chk_Gen_CopiaShadow
        '
        Me.chk_Gen_CopiaShadow.AutoSize = True
        Me.chk_Gen_CopiaShadow.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Gen_CopiaShadow.ForeColor = System.Drawing.Color.Blue
        Me.chk_Gen_CopiaShadow.Location = New System.Drawing.Point(456, 352)
        Me.chk_Gen_CopiaShadow.Name = "chk_Gen_CopiaShadow"
        Me.chk_Gen_CopiaShadow.Size = New System.Drawing.Size(163, 22)
        Me.chk_Gen_CopiaShadow.TabIndex = 5
        Me.chk_Gen_CopiaShadow.Text = "Usa Copia Shadow"
        Me.chk_Gen_CopiaShadow.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(21, 146)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 18)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Tipo:"
        '
        'txt_Gen_ID
        '
        Me.txt_Gen_ID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt_Gen_ID.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Gen_ID.ForeColor = System.Drawing.Color.Blue
        Me.txt_Gen_ID.Location = New System.Drawing.Point(42, 45)
        Me.txt_Gen_ID.Name = "txt_Gen_ID"
        Me.txt_Gen_ID.ReadOnly = True
        Me.txt_Gen_ID.Size = New System.Drawing.Size(538, 26)
        Me.txt_Gen_ID.TabIndex = 7
        '
        'txt_Gen_Nome
        '
        Me.txt_Gen_Nome.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Gen_Nome.ForeColor = System.Drawing.Color.Blue
        Me.txt_Gen_Nome.Location = New System.Drawing.Point(42, 108)
        Me.txt_Gen_Nome.Name = "txt_Gen_Nome"
        Me.txt_Gen_Nome.Size = New System.Drawing.Size(538, 26)
        Me.txt_Gen_Nome.TabIndex = 8
        '
        'txt_Gen_Gruppo
        '
        Me.txt_Gen_Gruppo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Gen_Gruppo.ForeColor = System.Drawing.Color.Blue
        Me.txt_Gen_Gruppo.Location = New System.Drawing.Point(42, 232)
        Me.txt_Gen_Gruppo.Name = "txt_Gen_Gruppo"
        Me.txt_Gen_Gruppo.Size = New System.Drawing.Size(538, 26)
        Me.txt_Gen_Gruppo.TabIndex = 9
        '
        'txt_Gen_Priorita
        '
        Me.txt_Gen_Priorita.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Gen_Priorita.ForeColor = System.Drawing.Color.Blue
        Me.txt_Gen_Priorita.Location = New System.Drawing.Point(42, 295)
        Me.txt_Gen_Priorita.Name = "txt_Gen_Priorita"
        Me.txt_Gen_Priorita.Size = New System.Drawing.Size(77, 26)
        Me.txt_Gen_Priorita.TabIndex = 10
        '
        'cbo_Gen_Tipo
        '
        Me.cbo_Gen_Tipo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_Gen_Tipo.ForeColor = System.Drawing.Color.Blue
        Me.cbo_Gen_Tipo.FormattingEnabled = True
        Me.cbo_Gen_Tipo.Location = New System.Drawing.Point(40, 171)
        Me.cbo_Gen_Tipo.Name = "cbo_Gen_Tipo"
        Me.cbo_Gen_Tipo.Size = New System.Drawing.Size(173, 26)
        Me.cbo_Gen_Tipo.TabIndex = 12
        '
        'frm_Task
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 549)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_Task"
        Me.Text = "frm_Task"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents cbo_Gen_Tipo As ComboBox
    Friend WithEvents txt_Gen_Priorita As TextBox
    Friend WithEvents txt_Gen_Gruppo As TextBox
    Friend WithEvents txt_Gen_Nome As TextBox
    Friend WithEvents txt_Gen_ID As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents chk_Gen_CopiaShadow As CheckBox
    Friend WithEvents chk_Gen_Abilitato As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ImageList1 As ImageList
End Class
