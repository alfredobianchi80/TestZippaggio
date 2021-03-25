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

            .ID = "xxx"
            .Nome = "PROVA1"
            .Gruppo = ""
            .Priorita = 0
            .Abilitato = True
            .UsaCopiaShadow = True
            .Tipo = cls_Task.en_TipoTask.Completo

            .Add_Origine(cls_Task.cls_percorso.en_TipoPercorso.Directory_Locale, Me.txt_origine_Percorso.Text, "C1", False, "", False)
            '.Add_Origine(cls_Task.cls_percorso.en_TipoPercorso.Directory_Locale, "E:\test_origine2", "C2", False, "", False)
            '.Add_Origine(cls_Task.cls_percorso.en_TipoPercorso.Directory_Locale, "D:\test_origine2", "C3", False, "", False)
            .Add_Destinazione(cls_Task.cls_percorso.en_TipoPercorso.Directory_Locale, Me.txt_destinazione_Percorso.Text, "", False)

            .ModalitaPianifcazione = cls_Task.en_ModalitaPianificazione.Manuale
            .Orario = Nothing
            With .Compressione
                .TipoCompressione = cls_Task.cls_task_Config_Compressione.en_TipoCompressione.CompressioneZIP
                .LivelloCompressione = cls_Task.cls_task_Config_Compressione.en_LivelloCompressione.Normale
                .MetodoCrittografia = cls_Task.cls_task_Config_Compressione.en_MetodoCrittografia.Nessuno
                .PasswordCrittografia = ""
                .UsaNomeTask = False 'Not Implemented yet
                .ControlloCRC = False 'Not Implemented yet
                '.SuddividiArchivio = False 'Not Implemented yet
                '.DimensioneSuddivisione = -1 'Not Implemented yet

            End With

            With .GlobalConfig
                .Formato_DataOra_NomeFile = "yyyy-MM-dd hh:mm:ss"
                .Formato_Data_NomeFile = "yyyy-MM-dd"
                .Formato_DataOra_Registro = "yyyy-MM-dd hh:mm:ss"
                .Formato_DataOra_NomeFileRegistro = "" 'GLOBALE APPLICATIVO
                .OmettiSpaziSuDataOra = True
                .TempOutputDirectory = "d:\temp\test"
            End With





            '.TASK_DestinazioneFileName = Me.txt_destinazione_NomeFile.Text
            .Processa()

        End With
        MessageBox.Show("Terminato.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)


        'Call ComprimiDirectory(Me.txt_origine_Percorso.Text, str_OutFile,, True, False)
    End Sub

#End Region











End Class
