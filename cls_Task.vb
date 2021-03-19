Public Class cls_Task

#Region "Dati Generali"
    Property ID As String = ""
    Property Nome As String = ""
    Property Gruppo As String = ""
    Property Priorita As Int32 = 0
    Property Abilitato As Boolean = False
    Property UsaCopiaShadow As Boolean = False
    Property Tipo As en_TipoTask = en_TipoTask.NonDefinito

    Enum en_TipoTask
        NonDefinito = 0
        Completo = 1
        Differenziale = 2
    End Enum

#End Region '"Dati Generali"


#Region "Dettaglio Percorsi di ORIGINE e DESTINAZIONE"
    Property Percorsi_Origine As Dictionary(Of String, cls_percorso) = Nothing
    Property Percorso_Destinazione As cls_percorso = Nothing

    Public Function Add_Origine(ByVal Tipo As cls_percorso.en_TipoPercorso, ByVal Path As String, ByVal PercorsoID As String,
                                ByVal Processa_SottoDirectory As Boolean,
                                Optional ByVal ParametriConnessione As String = "",
                                Optional ByVal CambiaIDSeEsistente As Boolean = False) As Boolean
        Dim bool_Result As Boolean = False
        Dim int_prog As Int32 = 0
        Dim str_temp_ID As String = ""
        Dim bool_inserisci As Boolean = False
        Dim bool_EsciCiclo As Boolean = False

        'Inizializza
        If Percorsi_Origine Is Nothing Then
            Percorsi_Origine = New Dictionary(Of String, cls_percorso)
        End If

        PercorsoID = PercorsoID.Trim.ToUpper
        If PercorsoID = "" Then
            PercorsoID = "DEFAULT"
        End If

        'Determina se il percorso è o meno inseribile (Gestisci parametro 'CambiaIDSeEsistente' ed aggiorna l'ID del percorso nel caso)
        str_temp_ID = PercorsoID
        bool_EsciCiclo = False
        Do
            bool_inserisci = Not (Percorsi_Origine.ContainsKey(str_temp_ID))
            If bool_inserisci Then
                bool_EsciCiclo = True
            Else
                If CambiaIDSeEsistente Then
                    str_temp_ID = PercorsoID & "_" & int_prog.ToString("0000")
                    bool_EsciCiclo = False
                Else
                    bool_EsciCiclo = True
                End If
            End If
        Loop Until (bool_EsciCiclo = False)
        If PercorsoID <> str_temp_ID Then
            PercorsoID = str_temp_ID
        End If

        If bool_inserisci Then
            Try
                Percorsi_Origine.Add(PercorsoID, New cls_percorso(Tipo, Path, Processa_SottoDirectory, PercorsoID, ParametriConnessione))
                bool_Result = True
            Catch ex As Exception

            End Try
        End If

        Return bool_Result
    End Function

    Public Function Remove_Origine(ByVal PercorsoID As String,
                                   Optional ByVal ReturnValueIfNotExist As Boolean = False) As Boolean
        Dim bool_Result As Boolean = False
        PercorsoID = PercorsoID.ToUpper.Trim

        If Percorsi_Origine.ContainsKey(PercorsoID) Then
            Try
                Percorsi_Origine.Remove(PercorsoID)
                bool_Result = True
            Catch ex As Exception

            End Try

        Else
            bool_Result = ReturnValueIfNotExist
        End If

        Return bool_Result
    End Function

    Public Function Add_Destinazione(ByVal Tipo As cls_percorso.en_TipoPercorso, ByVal Path As String,
                                Optional ByVal ParametriConnessione As String = "",
                                Optional ByVal CambiaIDSeEsistente As Boolean = False) As Boolean
        Dim bool_Result As Boolean = False

        'Inizializza
        If Percorso_Destinazione Is Nothing Then
            Percorso_Destinazione = New cls_percorso
        End If

        Try
            With Percorso_Destinazione
                .Tipo = Tipo
                .Percorso = Path
                .ParametriConnessione = ParametriConnessione
                .IDPercorso = ""
            End With

            bool_Result = True
        Catch ex As Exception

        End Try

        Return bool_Result
    End Function

    Class cls_percorso
        Property Tipo As en_TipoPercorso = en_TipoPercorso.NonDefinito
        Property Percorso As String = ""
        Property ParametriConnessione As String = ""
        Property IDPercorso As String = ""
        Property Processa_SottoDirectory As Boolean = False
        Sub New()

        End Sub
        Sub New(ByVal Tipo As en_TipoPercorso, ByVal Percorso As String, ByVal Processa_SottoDirectory As Boolean, ByVal IDPercorso As String, Optional ByVal ParametriConnessione As String = "")
            Me.Tipo = Tipo
            Me.Percorso = Percorso
            Me.IDPercorso = IDPercorso
            Me.ParametriConnessione = ParametriConnessione
            Me.Processa_SottoDirectory = Processa_SottoDirectory
        End Sub

        Public Enum en_TipoPercorso
            NonDefinito = 0
            Directory_Locale = 1
            Directory_Remota = 2
            FTP = 4
        End Enum
    End Class

#End Region '"Dettaglio Percorsi di ORIGINE e DESTINAZIONE"


#Region "Dettaglio Pianificazione"
    Property ModalitaPianifcazione As en_ModalitaPianificazione = en_ModalitaPianificazione.NonDefinito

    Property Orario As Nullable(Of DateTime) = Nothing


    Enum en_ModalitaPianificazione
        NonDefinito = 0
        Manuale = 1
        Giornaliero = 2
        Mensile = 4
    End Enum


#End Region '"Dettaglio Pianificazione"


#Region "Dettaglio Compressione"
    Property Compressione As cls_task_Config_Compressione = Nothing
    Class cls_task_Config_Compressione
        'Specifica Tipologia (e livello) di compressione dei file
        Property TipoCompressione As en_TipoCompressione = en_TipoCompressione.NonCompresso
        Property LivelloCompressione As en_LivelloCompressione = en_LivelloCompressione.Normale

        'Determina se l'eventuale archivio è o meno protetto da password
        'La password è salvata in maniera criptatta
        Property MetodoCrittografia As en_MetodoCrittografia = en_MetodoCrittografia.Nessuno
        Property PasswordCrittografia As String = ""

        Property UsaNomeTask As Boolean = True
        Property ControlloCRC As Boolean = False

        'Gestisce una eventuale suddivisione dell'archivio in più parti in base ad una dimensione massima
        'Opzioni non gestite
        ReadOnly Property SuddividiArchivio As Boolean = False
        ReadOnly Property DimensioneSuddivisione As UInt64 = 0

        Sub New()
            TipoCompressione = en_TipoCompressione.NonCompresso
            LivelloCompressione = en_LivelloCompressione.Normale
            MetodoCrittografia = en_MetodoCrittografia.Nessuno
            PasswordCrittografia = ""
            SuddividiArchivio = False
            DimensioneSuddivisione = 0
        End Sub

        Public Enum en_TipoCompressione
            NonDefinito = 0
            NonCompresso = 1
            CompressioneZIP = 2
        End Enum
        Public Enum en_LivelloCompressione
            NonDefinito = 0
            Normale = 1
            Alto = 2
            Basso = 4
        End Enum
        Public Enum en_MetodoCrittografia
            NonDefinito = 0
            Nessuno = 1
            Altro = 1024
        End Enum
    End Class

#End Region '"Dettaglio Compressione"



#Region "Dettaglio Formati e Formattazioni"

    Property GlobalConfig As cls_Task_Config_Global = Nothing

    Class cls_Task_Config_Global
        Property Formato_DataOra_NomeFile As String = "yyyy-MM-dd hh:mm:ss"
        Property Formato_Data_NomeFile As String = "yyyy-MM-dd"
        Property Formato_DataOra_Registro As String = "yyyy-MM-dd hh:mm:ss"
        Property Formato_DataOra_NomeFileRegistro As String = "" 'GLOBALE APPLICATIVO
        Property OmettiSpaziSuDataOra As Boolean = True

        Property TempOutputDirectory As String = ""

    End Class

#End Region '"Dettaglio Formati e Formattazioni"


#Region "Dettaglio Esecuzione"
    Private Property ParametriEsecuzione As cls_ExecuteValue = Nothing

    Class cls_ExecuteValue
        Property DataRiferimento As DateTime
        Property Destinazione_NomeFile As String = ""
        Property AppoggioOUT_NomeFile As String = ""
        Property Esecuzione_MultiSorgente As Boolean = False
        Property OutputFileNamePattern As String = "[%TASK-NAME]_[%DATA_RIF]_[%TASK-TIPO]_[%CURRENT-TIME].zip"

    End Class


#End Region '"Dettaglio Esecuzione"



    Sub New()
        Me.ID = ""
        Me.Nome = ""
        Me.Gruppo = ""
        Me.Priorita = 0
        Me.Abilitato = False
        Me.UsaCopiaShadow = False
        Me.Tipo = en_TipoTask.NonDefinito
        Me.Percorsi_Origine = New Dictionary(Of String, cls_percorso)
        Me.Percorso_Destinazione = New cls_percorso
        Me.ModalitaPianifcazione = en_ModalitaPianificazione.NonDefinito
        Me.Orario = Nothing
        Me.Compressione = New cls_task_Config_Compressione
        Me.GlobalConfig = New cls_Task_Config_Global
        Me.ParametriEsecuzione = New cls_ExecuteValue
    End Sub






#Region "Private Function"

    Private Function Zippa(ListaFile As cls_Task.cls_task_ListaInfoFile) As Boolean
        Dim bool_Result As Boolean = False
        Dim obj_ZipFile As Ionic.Zip.ZipFile = Nothing
        Dim str_temp_percorso As String = ""
        Dim str_temp As String = ""


        'Determina Nome File ( e percorsi Full) file di Out  (TODO) Trasformare in funzione separata e poi richiamarla alla bisogna
        str_temp = ParametriEsecuzione.OutputFileNamePattern
        str_temp = str_temp.Replace("[%TASK-NAME]", Me.Nome)
        str_temp = str_temp.Replace("[%TASK-TIPO]", Me.Tipo.ToString)
        str_temp = str_temp.Replace("[%DATA_RIF]", Me.ParametriEsecuzione.DataRiferimento.ToString(GlobalConfig.Formato_Data_NomeFile))
        str_temp = str_temp.Replace("[%CURRENT-TIME]", DateTime.Now.ToString(GlobalConfig.Formato_DataOra_NomeFile))
        Me.ParametriEsecuzione.Destinazione_NomeFile = System.IO.Path.Combine(Me.Percorso_Destinazione.Percorso, str_temp)
        Me.ParametriEsecuzione.AppoggioOUT_NomeFile = System.IO.Path.Combine(Me.GlobalConfig.TempOutputDirectory, str_temp)

        'Tenta lo zippaggio...

        Try
            obj_ZipFile = New Ionic.Zip.ZipFile
            For Each obj_file As cls_Task.cls_task_ListaInfoFile.cls_task_InfoFile In ListaFile.Incluso_ListaFile
                Dim str_NomeFile As String = ""
                str_NomeFile = obj_file.FileName
                Dim fileInfoInZip As New System.IO.FileInfo(str_NomeFile)
                'lo aggiungo al file zip e comprimo
                Try
                    str_temp_percorso = System.IO.Path.GetDirectoryName(str_NomeFile)
                    If Me.ParametriEsecuzione.Esecuzione_MultiSorgente Then
                    Else
                        str_temp_percorso = str_temp_percorso.Substring(obj_file.PercorsoOrigine.Length)
                    End If
                    obj_ZipFile.AddFile(str_NomeFile, str_temp_percorso)
                Catch ex As Exception
                    'MessageBox.Show(ex.Message)
                    ListaFile.Errore_AddFile(str_NomeFile, ex.Message, obj_file.DimensioneByte, obj_file.PercorsoOrigine)
                End Try
            Next
            obj_ZipFile.Save(Me.ParametriEsecuzione.AppoggioOUT_NomeFile)

            bool_Result = True
        Catch ex As Exception

        End Try

        Return bool_Result
    End Function

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

#End Region '"Private Function"


#Region "Public Function"
    Public Function Processa() As Boolean
        Dim bool_Result As Boolean = False
        Dim ListaFile As cls_Task.cls_task_ListaInfoFile = Nothing

        Dim pattern As String = "*.*"


        'Determina NomeFile Output





        ListaFile = New cls_Task.cls_task_ListaInfoFile
        Me.ParametriEsecuzione.Esecuzione_MultiSorgente = True


        'Determina elenco File da processare
        For Each obj_path As KeyValuePair(Of String, cls_percorso) In Me.Percorsi_Origine
            Select Case obj_path.Value.Tipo
                Case cls_percorso.en_TipoPercorso.Directory_Locale
                    Get_FileList(ListaFile, obj_path.Value.Percorso, obj_path.Value.Percorso, pattern, obj_path.Value.Processa_SottoDirectory, (Me.Tipo = en_TipoTask.Differenziale))
            End Select
        Next

        'Processa i file
        Select Case Me.Compressione.TipoCompressione
            Case cls_task_Config_Compressione.en_TipoCompressione.NonDefinito
                '(TODO) Gestione ERRORE
            Case cls_task_Config_Compressione.en_TipoCompressione.NonCompresso
                '(TODO)
            Case cls_task_Config_Compressione.en_TipoCompressione.CompressioneZIP
                bool_Result = Zippa(ListaFile)
        End Select


        Return bool_Result
    End Function

#End Region '"Public Function"





#Region "SUB-CLASS"

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









End Class
