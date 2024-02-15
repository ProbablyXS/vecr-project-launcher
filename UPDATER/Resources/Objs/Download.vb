Imports System.IO
Imports System.Net

Module Download

    Public data
    Public version As String = 0
    Public webclients As New WebClient
    Public update_version As String
    Public retryError As Integer = 0

    Public Async Function MAJDOWNLOAD() As Task
        Await Task.Delay(1000)

        'ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        AddHandler webclients.DownloadProgressChanged, AddressOf Getdownloadfilesasyncs
        AddHandler webclients.DownloadFileCompleted, AddressOf FileDownloadCompletedAsyncs

        treyrteyu.Text = "● Downloading:" & treyrteyu.ExeName & ".exe"

        'FIX LK.INI
        webclients.DownloadFile(Decode2(treyrteyu.LKINI_LINK), "data/conf.ini")

        If treyrteyu.selectedGAME = 1 Then
            treyrteyu.File_00 = Decode3(treyrteyu.ini.GetString("LINK", "F01", ""))
        ElseIf treyrteyu.selectedGAME = 2 Then
            treyrteyu.File_00 = Decode3(treyrteyu.ini.GetString("LINK", "F02", ""))
        ElseIf treyrteyu.selectedGAME = 3 Then
            treyrteyu.File_00 = Decode3(treyrteyu.ini.GetString("LINK", "F03", ""))
        End If
        update_version = Decode3(treyrteyu.ini.GetString("LINK", "UV", ""))
        treyrteyu.WELCOME_MSG = Decode3(treyrteyu.ini.GetString("LINK", "WMSG", ""))
        'FIX LK.INI

        Dim dlinkfile As New Uri(DECRYPTO(treyrteyu.File_00))
        webclients.DownloadFileAsync(dlinkfile, Path.GetTempPath & treyrteyu.ExeName & ".exe")
    End Function

    Public Sub Getdownloadfilesasyncs(sender As Object, e As DownloadProgressChangedEventArgs)
        Dim calc01 As Double = e.TotalBytesToReceive / 1024 / 10 ^ 3
        Dim calc02 As Double = e.BytesReceived / 1024 / 10 ^ 3

        treyrteyu.getinfopourcentage = e.ProgressPercentage
        treyrteyu.getinfobytestoreceives = Math.Round(calc01, 2)
        treyrteyu.getinfobytesreceives = Math.Round(calc02, 2)
    End Sub

    Private Async Sub FileDownloadCompletedAsyncs(sender As Object, e As ComponentModel.AsyncCompletedEventArgs)
        If e.Cancelled Then

            treyrteyu.hhrtezh.Text = "● Download has been canceled"

        ElseIf Not e.Error Is Nothing Then

            treyrteyu.hhrtezh.Text = "● Error 11 !"

        Else

            treyrteyu.hhrtezh.Text = "● Download finished"

            Await Task.Delay(4500)

            Try

                treyrteyu.randomEXE = generateRandomCombination() & ".exe"
                If (File.Exists(Path.GetTempPath & treyrteyu.ExeName & ".exe")) Then

                    treyrteyu.hhrtezh.Text = "● Replacing " & treyrteyu.ExeName & ".exe"
                    My.Computer.FileSystem.RenameFile(Path.GetTempPath & treyrteyu.ExeName & ".exe", treyrteyu.randomEXE)
                    Await Task.Delay(1500)

                Else

                    My.Computer.FileSystem.RenameFile(Path.GetTempPath & treyrteyu.ExeName & ".exe", treyrteyu.randomEXE)
                    Await Task.Delay(1500)

                End If

            Catch ex As Exception

                treyrteyu.hhrtezh.Text = "● Error 14 !"

            End Try

            Try

                treyrteyu.hhrtezh.Text = "● Starting " & treyrteyu.ExeName & ".exe"
                Await Task.Delay(1000)

                Try
                    treyrteyu.qprocess = Process.GetProcessesByName(treyrteyu.ProcessName)
                    If treyrteyu.qprocess.Count > 0 Then

                        For Each p As Process In Process.GetProcessesByName(treyrteyu.ProcessName.ToLower)

                            AppActivate(p.Id)
                            Await Task.Delay(200)

                        Next

                    Else

                        Application.Exit()

                    End If

                Catch ex As Exception

                End Try

                If (treyrteyu.selectedGAME = 1) Then

                    Process.Start(Path.GetTempPath & treyrteyu.randomEXE, treyrteyu.cdnn)

                ElseIf (treyrteyu.selectedGAME = 2) Then

                    Process.Start(Path.GetTempPath & treyrteyu.randomEXE, treyrteyu.cdn)

                ElseIf (treyrteyu.selectedGAME = 3) Then

                    Process.Start(Path.GetTempPath & treyrteyu.randomEXE, treyrteyu.cdnnn)

                End If

                Application.Exit()

            Catch ex As Exception

                Application.Exit()

            End Try

        End If
    End Sub


    Public Async Function LOG_DownloadDataCompletedAsync(sender As Object, e As DownloadDataCompletedEventArgs) As Task

        If e.Cancelled = False AndAlso e.Error Is Nothing Then

            data = e.Result

            Dim textTEST = System.Text.UTF8Encoding.UTF8.GetString(data)
            'WELCOME_MSG = tClient.DownloadString(textTEST).Trim()
            treyrteyu.gvvdfsv.Text = textTEST

            treyrteyu.log_result = False

            Await Task.Delay(1200)

            treyrteyu.hhrtezh.Text = "● Getting update file"

            AddHandler webclients.DownloadStringCompleted, AddressOf DownloadStringCompletedAsync
            webclients.DownloadStringAsync(New Uri(update_version))

        Else

            If treyrteyu.msgbox_showed = False And retryError >= 14 Then
                treyrteyu.msgbox_showed = True
                treyrteyu.OpenShowDialog("A problem has occurred with reading data ! " + treyrteyu.AVmsgBOX, True)
                Application.Exit()
            Else
                retryError += 1 'ADD 1 error
                webclients = New WebClient()
                AddHandler Download.webclients.DownloadDataCompleted, AddressOf LOG_DownloadDataCompletedAsync
                Download.webclients.DownloadDataAsync(New Uri(treyrteyu.WELCOME_MSG))
            End If

        End If
    End Function

    Public Function DownloadStringCompletedAsync(sender As Object, e As DownloadStringCompletedEventArgs) As Task

        If e.Cancelled = False AndAlso e.Error Is Nothing Then

            version = e.Result.Trim

            'MAJ
            Try
                If version <> My.Application.Info.Version.ToString Then
                    treyrteyu.msgbox_showed = True
                    treyrteyu.OpenShowDialog("Update available now for the launcher." & vbCrLf & "Please download the last version.", True)
                    Application.Exit()
                End If
            Catch ex As Exception
                Application.Exit()
            End Try
            'MAJ

            treyrteyu.locked = False

        Else

            If treyrteyu.msgbox_showed = False And retryError >= 14 Then
                treyrteyu.msgbox_showed = True
                treyrteyu.OpenShowDialog("A problem has occurred with checking update ! " + treyrteyu.AVmsgBOX, True)
                Application.Exit()
            Else
                retryError += 1 'ADD 1 error
                webclients = New WebClient()
                AddHandler webclients.DownloadStringCompleted, AddressOf DownloadStringCompletedAsync
                webclients.DownloadStringAsync(New Uri(update_version))
            End If
        End If

    End Function

End Module
