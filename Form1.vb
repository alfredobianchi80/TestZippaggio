'Imports System.IO
Imports System.IO.Compression

Public Class Form1


#Region "Interfaccia"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txt_origine_Percorso.Text = "E:\test_origine1"
        Me.txt_destinazione_Percorso.Text = "E:\test_fine"

    End Sub

    Private Sub cmd_Esci_Click(sender As Object, e As EventArgs) Handles cmd_Esci.Click
        Me.Close()
    End Sub

    Private Sub cmd_origine_Sfoglia_Click(sender As Object, e As EventArgs) Handles cmd_origine_Sfoglia.Click

        Using obj_folserSelect As New FolderBrowserDialog
            With obj_folserSelect
                .ShowNewFolderButton = False
                .SelectedPath = "F:\"
                '.RootFolder = "F:\"
                If .ShowDialog() = DialogResult.OK Then
                    Me.txt_origine_Percorso.Text = .SelectedPath
                End If
            End With
        End Using
        'Using obj_Selector As New OpenFileDialog
        '    With obj_Selector
        '        .CheckFileExists = False
        '        .CheckPathExists = True
        '        .ValidateNames = False

        '        .InitialDirectory = "F:\"
        '        .Multiselect = False
        '        .FileName = "Folder Selection."
        '        If .ShowDialog = DialogResult.OK Then
        '            Me.txt_origine_Percorso.Text = .FileName
        '        End If
        '    End With
        'End Using
    End Sub

    Private Sub cmd_destinazione_Sfoglia_Click(sender As Object, e As EventArgs) Handles cmd_destinazione_Sfoglia.Click
        Using obj_folserSelect As New FolderBrowserDialog
            With obj_folserSelect
                .ShowNewFolderButton = True
                .SelectedPath = "F:\"
                '.RootFolder = "F:\"
                If .ShowDialog() Then
                    Me.txt_destinazione_Percorso.Text = .SelectedPath
                End If
            End With
        End Using
    End Sub

    Private Sub cmd_Esegui_Click(sender As Object, e As EventArgs) Handles cmd_Esegui.Click

        Dim obj_Task As cls_Task = Nothing

        obj_Task = New cls_Task

        With obj_Task

            .TASK_ID = "xxx"
            .TASK_NAME = "PROVA1"
            .TASK_Tipo = cls_Task.en_task_TipoTask.Completo
            With .TASK_Configuration
                .ProcessaSottoDirectory = True
                .OutputFileNamePattern = "[%TASK-NAME]_[%TASK-TIPO]_[%CURRENT-TIME].zip"
                .TempOutputDirectory = ""
                .DateTimeFormat = "yyyy-mm-dd_hhmmss"
            End With

            .TASK_Origine.Add(New cls_Task.cls_task_percorso(cls_Task.cls_task_percorso.en_TipoPercorso.Cartella, Me.txt_origine_Percorso.Text))
            .TASK_Origine.Add(New cls_Task.cls_task_percorso(cls_Task.cls_task_percorso.en_TipoPercorso.Cartella, "E:\test_origine2"))



            .TASK_DestinazionePath = Me.txt_destinazione_Percorso.Text
            '.TASK_DestinazioneFileName = Me.txt_destinazione_NomeFile.Text
            .Processa()

        End With
        MessageBox.Show("Terminato.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)


        'Call ComprimiDirectory(Me.txt_origine_Percorso.Text, str_OutFile,, True, False)
    End Sub

#End Region











End Class
