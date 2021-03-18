<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.cmd_Esci = New System.Windows.Forms.Button()
        Me.cmd_Esegui = New System.Windows.Forms.Button()
        Me.txt_destinazione_Percorso = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmd_destinazione_Sfoglia = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmd_origine_Sfoglia = New System.Windows.Forms.Button()
        Me.txt_origine_Percorso = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmd_Esci
        '
        Me.cmd_Esci.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Esci.ForeColor = System.Drawing.Color.Blue
        Me.cmd_Esci.Location = New System.Drawing.Point(668, 23)
        Me.cmd_Esci.Name = "cmd_Esci"
        Me.cmd_Esci.Size = New System.Drawing.Size(102, 77)
        Me.cmd_Esci.TabIndex = 0
        Me.cmd_Esci.Text = "&Esci"
        Me.cmd_Esci.UseVisualStyleBackColor = True
        '
        'cmd_Esegui
        '
        Me.cmd_Esegui.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Esegui.ForeColor = System.Drawing.Color.Blue
        Me.cmd_Esegui.Location = New System.Drawing.Point(633, 156)
        Me.cmd_Esegui.Name = "cmd_Esegui"
        Me.cmd_Esegui.Size = New System.Drawing.Size(137, 62)
        Me.cmd_Esegui.TabIndex = 1
        Me.cmd_Esegui.Text = "Esegui"
        Me.cmd_Esegui.UseVisualStyleBackColor = True
        '
        'txt_destinazione_Percorso
        '
        Me.txt_destinazione_Percorso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_destinazione_Percorso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_destinazione_Percorso.ForeColor = System.Drawing.Color.Blue
        Me.txt_destinazione_Percorso.Location = New System.Drawing.Point(91, 34)
        Me.txt_destinazione_Percorso.Name = "txt_destinazione_Percorso"
        Me.txt_destinazione_Percorso.Size = New System.Drawing.Size(388, 26)
        Me.txt_destinazione_Percorso.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Percorso:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmd_destinazione_Sfoglia)
        Me.GroupBox1.Controls.Add(Me.txt_destinazione_Percorso)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(17, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(529, 108)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Destinazione"
        '
        'cmd_destinazione_Sfoglia
        '
        Me.cmd_destinazione_Sfoglia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_destinazione_Sfoglia.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_destinazione_Sfoglia.ForeColor = System.Drawing.Color.Blue
        Me.cmd_destinazione_Sfoglia.Location = New System.Drawing.Point(485, 31)
        Me.cmd_destinazione_Sfoglia.Name = "cmd_destinazione_Sfoglia"
        Me.cmd_destinazione_Sfoglia.Size = New System.Drawing.Size(38, 28)
        Me.cmd_destinazione_Sfoglia.TabIndex = 11
        Me.cmd_destinazione_Sfoglia.Text = "..."
        Me.cmd_destinazione_Sfoglia.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmd_origine_Sfoglia)
        Me.GroupBox2.Controls.Add(Me.txt_origine_Percorso)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox2.Location = New System.Drawing.Point(17, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(529, 75)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Origine"
        '
        'cmd_origine_Sfoglia
        '
        Me.cmd_origine_Sfoglia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd_origine_Sfoglia.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_origine_Sfoglia.ForeColor = System.Drawing.Color.Blue
        Me.cmd_origine_Sfoglia.Location = New System.Drawing.Point(485, 22)
        Me.cmd_origine_Sfoglia.Name = "cmd_origine_Sfoglia"
        Me.cmd_origine_Sfoglia.Size = New System.Drawing.Size(38, 28)
        Me.cmd_origine_Sfoglia.TabIndex = 10
        Me.cmd_origine_Sfoglia.Text = "..."
        Me.cmd_origine_Sfoglia.UseVisualStyleBackColor = True
        '
        'txt_origine_Percorso
        '
        Me.txt_origine_Percorso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_origine_Percorso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_origine_Percorso.ForeColor = System.Drawing.Color.Blue
        Me.txt_origine_Percorso.Location = New System.Drawing.Point(91, 25)
        Me.txt_origine_Percorso.Name = "txt_origine_Percorso"
        Me.txt_origine_Percorso.Size = New System.Drawing.Size(388, 26)
        Me.txt_origine_Percorso.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Percorso:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmd_Esegui)
        Me.Controls.Add(Me.cmd_Esci)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmd_Esci As Button
    Friend WithEvents cmd_Esegui As Button
    Friend WithEvents txt_destinazione_Percorso As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txt_origine_Percorso As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmd_destinazione_Sfoglia As Button
    Friend WithEvents cmd_origine_Sfoglia As Button
End Class
