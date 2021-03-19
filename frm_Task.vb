Public Class frm_Task


#Region "Dichiarazioni"
    Private _SchedaCorrente As cls_Task = Nothing
    Private _ModificheNonSalvate As Boolean = False
#End Region '"Dichiarazioni"


#Region "Funzioni Interfaccia"
    Private Sub frm_Task_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call Inizializza_Controlli()
    End Sub

#End Region '"Funzioni Interfaccia"


#Region "Funzioni Pubbliche"
    Public Function Nuova_Scheda() As Boolean
        Dim bool_Result As Boolean = False
        _SchedaCorrente = Nothing
        bool_Result = Visualizza_Scheda_Corrente(True)
        Return bool_Result
    End Function

    Public Function Carica_Scheda(ByVal Scheda As cls_Task) As Boolean
        Dim bool_Result As Boolean = False
        _SchedaCorrente = Scheda

        bool_Result = Visualizza_Scheda_Corrente()

        Return bool_Result
    End Function

    Public Function Carica_Scheda_FromFile(ByVal NomeFile As String) As Boolean
        Dim bool_Result As Boolean = False
        _SchedaCorrente = Nothing
        Throw New NotImplementedException

        '(TODO) Impelementare caricamento dati da file XML..

        bool_Result = Visualizza_Scheda_Corrente()

        Return bool_Result
    End Function

#End Region '"Funzioni Pubbliche"


#Region "Funzioni Private"
    Private Sub Inizializza_Controlli()
        With Me.cbo_Gen_Tipo.Items
            .Clear()
            .Add("CMP - COMPLETO")
            .Add("DIF - DIFFERENZIALE")
        End With
    End Sub

    Private Function Visualizza_Scheda_Corrente(Optional ByVal ValoreSeSchedaVuota As Boolean = False) As Boolean
        Dim bool_Result As Boolean = False
        Call Reset_Dati_Visualizzati()

        If _SchedaCorrente Is Nothing Then
            bool_Result = ValoreSeSchedaVuota
        Else

            Try
                Me.txt_Gen_ID.Text = _SchedaCorrente.ID
                Me.txt_Gen_Nome.Text = _SchedaCorrente.Nome
                Me.txt_Gen_Gruppo.Text = _SchedaCorrente.Gruppo
                Me.txt_Gen_Priorita.Text = _SchedaCorrente.Priorita

                Me.chk_Gen_Abilitato.Checked = _SchedaCorrente.Abilitato
                Me.chk_Gen_CopiaShadow.Checked = _SchedaCorrente.UsaCopiaShadow

                Select Case _SchedaCorrente.Tipo
                    Case cls_Task.en_TipoTask.Completo
                        Me.cbo_Gen_Tipo.Text = "CMP - COMPLETO"
                    Case cls_Task.en_TipoTask.Differenziale
                        Me.cbo_Gen_Tipo.Text = "DIF - DIFFERENZIALE"
                    Case Else
                End Select

                bool_Result = True
            Catch ex As Exception

            End Try
        End If
        Return bool_Result
    End Function


    Private Sub Reset_Dati_Visualizzati()

    End Sub

#End Region '"Funzioni Private"

End Class