'Imports Alphaleonis.Win32.Vss


Public Class cls_VSS_14
    Private _Snaps As Dictionary(Of String, cls_VSSinfo) = Nothing

    Private _VSSImpl As Alphaleonis.Win32.Vss.IVssImplementation = Nothing
    Private _VSS As Alphaleonis.Win32.Vss.IVssBackupComponents = Nothing

    Class cls_VSSinfo
        Property Snap_ID As String = ""
        Property Snap_CreationTime As Nullable(Of DateTime) = Nothing
        Property Snap_Volume As String = ""


        Sub New()

        End Sub

        Sub New(ByVal ID As String, ByVal Volume As String,
                Optional ByVal DataOraCreazione As Nullable(Of DateTime) = Nothing,
                Optional ByVal ValorizzaDataOraAutoSeNothing As Boolean = True)

            Me.Snap_ID = ID
            Me.Snap_Volume = Volume
            If (DataOraCreazione Is Nothing) AndAlso (ValorizzaDataOraAutoSeNothing) Then
                Me.Snap_CreationTime = DateTime.Now
            Else
                Me.Snap_CreationTime = DataOraCreazione
            End If
        End Sub
    End Class

    Sub New()
        _VSSImpl = Nothing
        _VSS = Nothing
        _Snaps = New Dictionary(Of String, cls_VSSinfo)
    End Sub

    Private Sub InizializzateCheck_Objects()
        If _VSSImpl Is Nothing Then
            _VSSImpl = Alphaleonis.Win32.Vss.VssUtils.LoadImplementation()
        End If

        If _VSS Is Nothing Then
            _VSS = _VSSImpl.CreateVssBackupComponents
        End If
    End Sub

    Public Function CreateSnapshot(ByVal Volume As String, ByRef SnapID As String,
                                   ByRef VssPath As String,
                                   Optional ByVal oErrore As String = "") As Boolean
        Dim bool_Result As Boolean = False
        SnapID = ""
        VssPath = ""
        oErrore = ""
        Try
            'VSS step 1: Initialize
            Call InizializzateCheck_Objects()

            _VSS.InitializeForBackup(Nothing)



            _VSS.SetBackupState(False, True, Alphaleonis.Win32.Vss.VssBackupType.Full, False)


            'VSS step 2: Getting Metadata from all the VSS writers
            _VSS.GatherWriterMetadata()

            ' VSS step 3 VSS Configuration
            _VSS.SetContext(Alphaleonis.Win32.Vss.VssVolumeSnapshotAttributes.Persistent Or Alphaleonis.Win32.Vss.VssVolumeSnapshotAttributes.NoAutoRelease)
            _VSS.SetBackupState(False, True, Alphaleonis.Win32.Vss.VssBackupType.Full, False)


            'VSS step 4: Declaring the Volumes that we need to use in this beckup. 
            Dim MyGuid01 As Guid = _VSS.StartSnapshotSet()
            Dim MyGuid02 As Guid = _VSS.AddToSnapshotSet(Volume, Guid.Empty)

            'VSS step 5: Preparation(Writers & Provaiders need To start preparation)
            _VSS.PrepareForBackup()


            'VSS step 6 Create a Snapshot For each volume in the "Snapshot Set"
            _VSS.DoSnapshotSet()

            'VSS step 7: Expose Snapshot
            Dim oProps As Alphaleonis.Win32.Vss.VssSnapshotProperties
            oProps = _VSS.GetSnapshotProperties(MyGuid02)

            VssPath = oProps.SnapshotDeviceObject


            bool_Result = True
        Catch ex As Exception
            oErrore = ex.Message
            MessageBox.Show("[CreateSnapshot] Errore:" & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If bool_Result Then
            Try
                If _Snaps Is Nothing Then
                    _Snaps = New Dictionary(Of String, cls_VSSinfo)
                End If
                _Snaps.Add(SnapID, New cls_VSSinfo(SnapID, Volume, Nothing))
            Catch ex As Exception
                bool_Result = False
                oErrore = ex.Message
                MessageBox.Show("[CreateSnapshot] Errore:" & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

        Return bool_Result
    End Function


    Public Function Snapshot_Delete(ByVal ID As String, Optional ByRef oError As String = "") As Boolean
        Dim bool_Result As Boolean = False

        Call InizializzateCheck_Objects()

        oError = ""
        Try
            For Each prop As Alphaleonis.Win32.Vss.VssSnapshotProperties In _VSS.QuerySnapshots()
                If (prop.SnapshotId.ToString = ID) Then
                    Console.WriteLine("prop.ExposedNam Found!")
                    _VSS.DeleteSnapshot(prop.SnapshotId, True)
                    If _Snaps.ContainsKey(ID) Then
                        _Snaps.Remove(ID)
                    End If

                    bool_Result = True
                End If
            Next
        Catch ex As Exception
            oError = ex.Message
        End Try

        Return bool_Result
    End Function

End Class



