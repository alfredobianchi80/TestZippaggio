Public Class cls_Task


    Property TASK_ID As String = ""
    Property TASK_NAME As String = ""
    Property TASK_Tipo As en_task_TipoTask = en_task_TipoTask.NonDefinito

    Property TASK_Origine As List(Of cls_task_percorso) = Nothing
    Property TASK_DestinazionePath As String = ""
    'Property TASK_DestinazioneFileName As String = ""

    Property TASK_Configuration As cls_Task_Config = Nothing


    Private Property Exec_OutFileName As String = ""
    Private Property Exec_temp_OutFileName As String = ""

    Private Property Exec_MultiSource As Boolean = False

    Sub New()
        TASK_Origine = New List(Of cls_task_percorso)
        TASK_Configuration = New cls_Task_Config
    End Sub


    Enum en_task_TipoTask
        NonDefinito = 0
        Completo = 1
        SoloNonArchiviati = 2
    End Enum




    Private Function Zippa(ListaFile As cls_Task.cls_task_ListaInfoFile)

        Dim obj_ZipFile As Ionic.Zip.ZipFile = Nothing
        Dim str_temp_percorso As String = ""

        obj_ZipFile = New Ionic.Zip.ZipFile
        For Each obj_file As cls_Task.cls_task_ListaInfoFile.cls_task_InfoFile In ListaFile.Incluso_ListaFile
            Dim str_NomeFile As String = ""
            str_NomeFile = obj_file.FileName
            Dim fileInfoInZip As New System.IO.FileInfo(str_NomeFile)
            'lo aggiungo al file zip e comprimo
            Try
                str_temp_percorso = System.IO.Path.GetDirectoryName(str_NomeFile)

                If Exec_MultiSource Then

                Else
                    str_temp_percorso = str_temp_percorso.Substring(obj_file.PercorsoOrigine.Length)
                End If


                obj_ZipFile.AddFile(str_NomeFile, str_temp_percorso)
            Catch ex As Exception
                'MessageBox.Show(ex.Message)
                ListaFile.Errore_AddFile(str_NomeFile, ex.Message, obj_file.DimensioneByte, obj_file.PercorsoOrigine)

            End Try
        Next
        obj_ZipFile.Save(Exec_temp_OutFileName)

        Return True
    End Function

    Public Function Processa() As Boolean
        Dim bool_Result As Boolean = False
        Dim ListaFile As cls_Task.cls_task_ListaInfoFile = Nothing

        Dim pattern As String = "*.*"


        'Determina NomeFile Output

        Dim str_temp As String = ""

        str_temp = TASK_Configuration.OutputFileNamePattern '& ".zip"
        str_temp = str_temp.Replace("[%TASK-NAME]", TASK_NAME)
        str_temp = str_temp.Replace("[%TASK-TIPO]", TASK_Tipo.ToString)
        str_temp = str_temp.Replace("[%CURRENT-TIME]", DateTime.Now.ToString(TASK_Configuration.DateTimeFormat))

        '[%TASK-NAME]_[%TASK-TIPO]_[%CURRENT-TIME]

        Exec_temp_OutFileName = System.IO.Path.Combine(TASK_DestinazionePath, str_temp)

        ListaFile = New cls_Task.cls_task_ListaInfoFile
        Exec_MultiSource = True


        For Each obj_path As cls_task_percorso In TASK_Origine
            Select Case obj_path.Tipo
                Case cls_task_percorso.en_TipoPercorso.Cartella

                    Get_FileList(ListaFile, obj_path.percorso, obj_path.percorso, pattern, TASK_Configuration.ProcessaSottoDirectory, (TASK_Tipo = en_task_TipoTask.SoloNonArchiviati))

            End Select
        Next

        Zippa(ListaFile)









        Return bool_Result
    End Function















#Region "SUB-CLASS"

    Class cls_Task_Config
        Property ProcessaSottoDirectory As Boolean = False
        Property TempOutputDirectory As String = ""
        Property OutputFileNamePattern As String = ""

        Property DateTimeFormat As String = ""
    End Class

    Class cls_task_percorso
        Public Enum en_TipoPercorso
            NonDefinito = 0
            Cartella = 1
        End Enum

        Property Tipo As en_TipoPercorso = en_TipoPercorso.NonDefinito
        Property percorso As String = ""

        Sub New()

        End Sub
        Sub New(ByVal Tipo As en_TipoPercorso, ByVal Path As String)
            Me.Tipo = Tipo
            Me.percorso = Path
        End Sub

    End Class

    Class cls_task_ListaInfoFile
        Private _Lista_FileInclusi As List(Of cls_task_InfoFile) = Nothing
        Private _Lista_FileEslusi As List(Of cls_task_InfoFile) = Nothing
        Private _Lista_FileErrore As List(Of cls_task_InfoFile) = Nothing

        Sub New()
            '_lista = New List(Of cls_InfoFile)
            _Lista_FileInclusi = New List(Of cls_task_InfoFile)
            _Lista_FileEslusi = New List(Of cls_task_InfoFile)
            _Lista_FileErrore = New List(Of cls_task_InfoFile)
        End Sub

#Region "ERRORE functions"
        Public Function Errore_ListaFile() As List(Of cls_task_InfoFile)
            Return _Lista_FileErrore
        End Function

        Public Sub Errore_AddFile(ByVal FullNameFile As String, ByVal Motivo As String, ByVal DimensioneByte As Long, ByVal BasePercorso As String)
            _Lista_FileErrore.Add(New cls_task_InfoFile(FullNameFile, Motivo, DimensioneByte, BasePercorso))
        End Sub

        Public Function Errore_Count() As Long
            If _Lista_FileErrore IsNot Nothing Then
                Return _Lista_FileErrore.Count
            Else
                Return 0
            End If
        End Function

        Public Function Errore_TotalByte() As Long
            Dim lng_Result As Long = 0
            For Each obj_x As cls_task_InfoFile In _Lista_FileErrore
                lng_Result += obj_x.DimensioneByte
            Next
            Return lng_Result
        End Function

#End Region


#Region "INCLUSO functions"

        Public Function Incluso_ListaFile() As List(Of cls_task_InfoFile)
            Return _Lista_FileInclusi
        End Function

        Public Sub Incluso_AddFile(ByVal FullNameFile As String, ByVal Motivo As String, ByVal DimensioneByte As Long, ByVal BasePercorso As String)
            _Lista_FileInclusi.Add(New cls_task_InfoFile(FullNameFile, Motivo, DimensioneByte, BasePercorso))
        End Sub

        Public Function Incluso_Count() As Long
            If _Lista_FileInclusi IsNot Nothing Then
                Return _Lista_FileInclusi.Count
            Else
                Return 0
            End If
        End Function

        Public Function Incluso_TotalByte() As Long
            Dim lng_Result As Long = 0
            For Each obj_x As cls_task_InfoFile In _Lista_FileInclusi
                lng_Result += obj_x.DimensioneByte
            Next
            Return lng_Result
        End Function

#End Region '"INCLUSO functions"


#Region "ESCLUSO functions"

        Public Sub Escluso_AddFile(ByVal FullNameFile As String, ByVal Motivo As String, ByVal DimensioneByte As Long, ByVal BasePercorso As String)
            _Lista_FileInclusi.Add(New cls_task_InfoFile(FullNameFile, Motivo, DimensioneByte, BasePercorso))
        End Sub

        Public Function Escluso_Count() As Long
            If _Lista_FileEslusi IsNot Nothing Then
                Return _Lista_FileEslusi.Count
            Else
                Return 0
            End If
        End Function

        Public Function Escluso_TotalByte() As Long
            Dim lng_Result As Long = 0
            For Each obj_x As cls_task_InfoFile In _Lista_FileEslusi
                lng_Result += obj_x.DimensioneByte
            Next
            Return lng_Result
        End Function

#End Region '"ESCLUSO functions"

        Class cls_task_InfoFile
            Property FileName As String = ""
            Property Motivo As String = ""
            Property DimensioneByte As Long = 0
            Property PercorsoOrigine As String = ""

            Sub New()

            End Sub
            Sub New(ByVal File As String, Optional ByVal Motivo As String = "", Optional ByVal DimensioneByte As Long = 0, Optional ByVal PercorsoOrigine As String = "")
                Me.FileName = File
                Me.Motivo = Motivo
                Me.DimensioneByte = DimensioneByte
                Me.PercorsoOrigine = PercorsoOrigine
            End Sub
        End Class

    End Class

#End Region '"SUB-CLASS"






    Private Function Get_FileList(ByRef ListaFile As cls_task_ListaInfoFile, ByVal PercorsoAnalisi As String, ByVal PercorsoBase As String,
                                  Optional ByVal Pattern As String = "*.*",
                                  Optional ByVal ProcessaSottoDirectory As Boolean = True,
                                  Optional ByVal ProcessaSoloNonArchiviati As Boolean = False) As Boolean
        Dim bool_Result As Boolean = False
        Dim obj_FileAttribute As System.IO.FileAttributes = Nothing
        Dim obj_FileInfo As System.IO.FileInfo = Nothing
        Dim bool_AccodaFile As Boolean = False
        Dim str_Motivo As String = ""
        Dim lng_FileDimension As Long

        If ListaFile Is Nothing Then
            ListaFile = New cls_task_ListaInfoFile
        End If


        Try
            For Each str_NomeFile As String In IO.Directory.GetFiles(PercorsoAnalisi, Pattern)
                str_Motivo = ""
                bool_AccodaFile = False

                'Processa per Attributi
                'obj_FileAttribute = IO.File.GetAttributes(str_NomeFile)

                obj_FileInfo = New IO.FileInfo(str_NomeFile)
                obj_FileAttribute = obj_FileInfo.Attributes
                lng_FileDimension = obj_FileInfo.Length

                If ProcessaSoloNonArchiviati Then
                    If ((obj_FileAttribute And System.IO.FileAttributes.Archive) = System.IO.FileAttributes.Archive) Then
                        bool_AccodaFile = False
                        str_Motivo = "Archiviato"
                    Else
                        bool_AccodaFile = True
                    End If
                Else
                    bool_AccodaFile = True
                End If

                'Verifica per Pattern di esclusione (DA IMPLEMENTARE)
                If bool_AccodaFile Then
                    '(TODO)
                End If

                If bool_AccodaFile Then
                    ListaFile.Incluso_AddFile(str_NomeFile, "", lng_FileDimension, PercorsoBase)
                Else
                    ListaFile.Escluso_AddFile(str_NomeFile, str_Motivo, lng_FileDimension, PercorsoBase)
                End If
            Next
            If ProcessaSottoDirectory Then
                For Each str_Directory As String In IO.Directory.GetDirectories(PercorsoAnalisi)
                    Get_FileList(ListaFile, str_Directory, PercorsoBase, Pattern, ProcessaSottoDirectory, ProcessaSoloNonArchiviati)
                Next
            End If
            bool_Result = True
        Catch ex As Exception
        End Try

        Return bool_Result
    End Function

    'Private Function ComprimiDirectory(ByVal PercorsoOrigine As String, ByVal DestFileFullName As String,
    '                                  Optional ByVal FilterValue As String = "*.*",
    '                                  Optional ByVal ProcessaSottoDirectory As Boolean = True,
    '                                  Optional ByVal ProcessoSoloNonArchiviati As Boolean = False) As Boolean
    '    Dim bool_result As Boolean = False
    '    Dim obj_ZipFile As Ionic.Zip.ZipFile = Nothing
    '    Dim str_Percorso As String = ""
    '    'Dim filesDaComprimere As List(Of String) = Nothing
    '    Dim ListaFile As cls_Task.cls_task_ListaInfoFile = Nothing

    '    Dim lng_NumeroFileProcessati As Long = 0
    '    Dim lng_NumeroFileTotali As Long = 0
    '    Dim lng_NumeroFileErrore As Long = 0


    '    'Inizializza Variabili
    '    ListaFile = New cls_Task.cls_task_ListaInfoFile


    '    'Recupera Lista File da comprimere
    '    Get_FileList(ListaFile, PercorsoOrigine, FilterValue, ProcessaSottoDirectory, ProcessoSoloNonArchiviati)


    '    If ListaFile IsNot Nothing Then

    '        lng_NumeroFileTotali = ListaFile.Incluso_Count + ListaFile.Escluso_Count
    '    Else
    '        lng_NumeroFileTotali = 0
    '    End If



    '    'Crea ZIP e procedi all'aggiunta dei file
    '    obj_ZipFile = New Ionic.Zip.ZipFile



    '    For Each obj_file As cls_Task.cls_task_ListaInfoFile.cls_task_InfoFile In ListaFile.Incluso_ListaFile
    '        Dim str_NomeFile As String = ""
    '        str_NomeFile = obj_file.FileName
    '        Dim fileInfoInZip As New System.IO.FileInfo(str_NomeFile)
    '        'lo aggiungo al file zip e comprimo
    '        Try
    '            str_Percorso = System.IO.Path.GetDirectoryName(str_NomeFile)
    '            str_Percorso = str_Percorso.Substring(PercorsoOrigine.Length)
    '            obj_ZipFile.AddFile(str_NomeFile, str_Percorso)
    '        Catch ex As Exception
    '            'MessageBox.Show(ex.Message)
    '            ListaFile.Errore_AddFile(str_NomeFile, ex.Message, obj_file.DimensioneByte, obj_file.PercorsoOrigine)

    '        End Try
    '    Next
    '    obj_ZipFile.Save(DestFileFullName)

    '    If ListaFile IsNot Nothing Then
    '        lng_NumeroFileErrore = ListaFile.Errore_Count
    '    End If

    '    Return bool_result
    'End Function

End Class
