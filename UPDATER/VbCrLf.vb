Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports Newtonsoft.Json.Linq

Public Class treyrteyu

    Public ExeName = "00"
    Public read_code As String = ""
    Public locked As Boolean = True 'Activer button start (True = verouiller)
    Public loaded As Boolean = False
    Public findex As Integer = 0
    Public ini As New clsIni(Environment.CurrentDirectory & "\data\conf.ini")
    Public LKINI_LINK As String = _standalone
    Public WELCOME_MSG As String
    Public selectedGAME = 0
    Public File_00 As String
    Public ProcessName As String = "".ToLower
    Public cdn = "EyZNR0ygT7BUnEDTzcLRvje5es1b6syJim9AKNqhzoDKCKTv"
    Public randomEXE As String
    Public msgbox_showed = False
    Public AVmsgBOX = "You have launched the software too many times, please wait ~15 minutes and retry again"
    Public BasicColor01 = Color.FromArgb(64, 191, 223)
    Public BasicColor02 = Color.FromArgb(255, 128, 0)
    Public BasicColor03 = Color.FromArgb(111, 183, 46)
    Public qprocess() As Process
    Public log_result = True
    Public timerImage As Integer = 0
    Public numberBG As Integer = 1
    Public newsL As String
    Public t As Integer = 0
    Public getinfopourcentage As Integer, getinfobytestoreceives As Double, getinfobytesreceives As Double
    Public files As String = ""
    Public NeedRestart As Boolean = False
    Public laddress As String = "http://api.vecrproject.com"
    Public MYCODE As String
    Public EnteredIntoHWIDMenu As Boolean = False
    Public cdnn = "kYiXykL64YOUY8AdMCrtpOtvNZybP9"
    Public cdnnn = "4G8949fdg4d9g4DFG4DF6541651v5df61v651erg84g89er4hgerF564"
    Public debug As Integer = 0

    Private Async Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            changename()

            qfsdqf.Text = "Version:" & My.Application.Info.Version.ToString


            'RESOLVE ADDRESS
            If (debug = 0) Then
                Dim WebRequest As HttpWebRequest = WebRequest.Create(laddress)
                WebRequest.AllowAutoRedirect = False
                Dim WebResponse As HttpWebResponse = WebRequest.GetResponse()
                Dim str = WebResponse.Headers.GetValues("Location")
                laddress = str(0)
            Else
                laddress = "http://127.0.0.1:5000"
            End If
            'END RESOLVE

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 'FOCE SSL/TLS PROTOCOL
            Download.webclients.CachePolicy = New System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore) 'CLEAR CACHE
            Download.webclients.Headers.Add("User-Agent: Other")

            BG_MOVING()


            fdshdfj.VerticalScroll.Visible = False
            fdshdfj.AutoScroll = True

            ' put panel2 inside panel3
            fdshdfj.Parent = sqdfsdqf
            fdshdfj.Location = New Point(0, 0)

            ' resize panel3 to panel2 size minus width of vert scroll bar
            sqdfsdqf.Size = New Size(fdshdfj.Width - SystemInformation.VerticalScrollBarWidth, fdshdfj.Height)

            Await AnimationForms.open_form(Me)

        Catch ex As Exception

            Application.Exit()

        End Try

    End Sub

    Public Async Function Waiting_to_load() As Task

        While 1

            Await Task.Delay(100)

            If locked = False And log_result = False Then

                If File.Exists("LICENSE") = True Then
                    If (qsdfqsdf.ini_token.GetString("LICENSE", "License", "") <> Nothing) And
                        qsdfqsdf.ini_token.GetString("LICENSE", "License", "").Length = 8 Then
                        qsgsdqg.Text = "ʀᴇꜱᴇᴛ ʟɪᴄᴇɴꜱᴇ"
                    End If
                Else
                    BlinkingText(qsgsdqg)
                End If

                fdfqsdf.Text = "START"
                hhrtezh.Text = "● Select your game"
                loaded = True

                Exit While

            End If

        End While

    End Function

    Public Async Function security() As Task
        While 1
            Await Task.Delay(1000)

            Dim k As String() = {"hack", "cheat", "ollydbg", "hxd", "x32dbg", "ida64"}
            For i = 0 To k.Count() - 1

                Dim result As String = k(i)

                For Each p In Process.GetProcesses()
                    If (p.ProcessName.IndexOf(result, StringComparison.CurrentCultureIgnoreCase) >= 0) Then
                        p.Kill()
                        p.WaitForExit()
                        Application.Exit()
                    End If
                Next

            Next
        End While
    End Function

    Public Sub OpenShowDialog(TextHere As String, ButtonRestarting As Boolean)
        sdfhfdshdfs.WantApplicationExit = ButtonRestarting
        locked = True
        NeedRestart = True
        sdfhfdshdfs.ezrtezrt.Visible = False 'Button Close
        sdfhfdshdfs.jtjtyjktyjkty.Visible = True
        sdfhfdshdfs.thjytyrjktyrj.Text = TextHere
        sdfhfdshdfs.ShowDialog()
    End Sub

    Public Sub OpenShowDialogInserAccessCode()
        locked = True
        sdfhfdshdfs.jtjtyjktyjkty.Visible = True 'Button Close
        sdfhfdshdfs.jtjtyjktyjkty.Visible = False
        sdfhfdshdfs.thjytyrjktyrj.Text = TextHere
        sdfhfdshdfs.ShowDialog()
    End Sub

    Public Async Function BG_MOVING() As Task
        Waiting_to_load()

        hhrtezh.Text = "● Getting config file"

        IO.Directory.CreateDirectory("data")

        'Image LK
        'Dim infofile = IO.File.GetLastWriteTime("data/conf.ini")
        'If File.Exists("data/conf.ini") = False Or infofile.Minute > DateTime.Now.Minute + 5 Or infofile.Minute < DateTime.Now.Minute - 5 Then

        File.Delete("data\conf.ini")

        'DOWNLOAD
        Try
            Download.webclients.DownloadFile(Decode2(LKINI_LINK), "data\conf.ini")
        Catch ex As Exception
            msgbox_showed = True
            OpenShowDialog(AVmsgBOX, True)
            Return
        End Try
        'Image LK
        'End If

        File_00 = ini.GetString("LINK", "F01", "")
        Download.update_version = Decode3(ini.GetString("LINK", "UV", ""))
        WELCOME_MSG = Decode3(ini.GetString("LINK", "WMSG", ""))

        'CODE
        Try

            Dim endPoint As String = laddress & "/api/ReadAccessCode/" & DECRYPTO(Decode2(qsdfqsdf.encryptac))
            Dim client = New HttpClient()
            Dim data = {New KeyValuePair(Of String, String)(DECRYPTO(Decode2(qsdfqsdf.encryptacKEY)), "")}
            Dim POST = client.PostAsync(endPoint, New FormUrlEncodedContent(data)).GetAwaiter().GetResult()
            Dim json As String = POST.Content.ReadAsStringAsync().Result
            read_code = JObject.Parse(json)("data").ToString().Trim()
            sdfhfdshdfs.access = 1

        Catch ex As Exception
            Application.Exit()
        End Try
        'CODE

        Await Task.Delay(2500)

        'WELCOME MSG
        hhrtezh.Text = "● Getting data file"
        AddHandler Download.webclients.DownloadDataCompleted, AddressOf Download.LOG_DownloadDataCompletedAsync
        Download.webclients.DownloadDataAsync(New Uri(WELCOME_MSG))
        'WELCOME MSG
    End Function

    ''MOUVE FORM WITH MOUSE'
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles fezfzef.MouseDown, qfsdqf.MouseDown

        drag = True
        mousex = System.Windows.Forms.Cursor.Position.X - Me.Left
        mousey = System.Windows.Forms.Cursor.Position.Y - Me.Top

    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles fezfzef.MouseMove, qfsdqf.MouseMove

        If drag Then

            Me.Top = System.Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = System.Windows.Forms.Cursor.Position.X - mousex

        End If

    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles fezfzef.MouseUp, qfsdqf.MouseUp
        drag = False
    End Sub
    'MOUVE FORM WITH MOUSE'


    'ANIMATION FORM'
    Private Async Sub form_close_animation_button(sender As Object, e As EventArgs) Handles ezrtezrt.Click
        Await AnimationForms.close_form(Me)
        Application.Exit()
    End Sub

    Private Async Sub form_show_animation(sender As Object, e As EventArgs) Handles MyBase.Activated
        If Me.WindowState = FormWindowState.Minimized Then
            Await AnimationForms.open_form(Me)
        End If
    End Sub
    'ANIMATION FORM'

    'MAJ CHECK
    Private Async Function MAJCHECK() As Task
        Try

            hhrtezh.Text = "● Preparation in progress"

            'DELETE FILE

            Await Task.Delay(1000)
            hhrtezh.Text = "● Cleaning conf.ini"

            File.Delete("data\conf.ini") 'reinitialisation des liens de telechargement
            'DELETE FILE

            Await Task.Delay(1000)

            hhrtezh.Text = "● Preparing downloading file"
            Await Task.Delay(1000)
            hhrtezh.Text = "● Starting..."

            Await MAJDOWNLOAD()

        Catch ex As Exception

            Application.Exit()

        End Try
    End Function
    'MAJ CHECK

    Private Async Sub Button7_Click(sender As Object, e As EventArgs) Handles erzgerzg.Click
        Await AnimationForms.close_form(Me)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles fdfqsdf.Click
        If locked = True Or loaded = False Then
            Exit Sub
        End If

        Try

            If File.Exists("LICENSE") = False Then
                hhrtezh.Text = "● First insert your license !"
                Exit Sub
            End If

            If ini.GetString("LINK", "START_KEY", "") = read_code Then

                If locked = False And selectedGAME > 0 Then

                    qprocess = Process.GetProcessesByName(ProcessName)
                    If qprocess.Count > 0 Then

                    Else

                        hhrtezh.Text = "● First start your game !"
                        Exit Sub

                    End If

                    locked = True

                    fdfqsdf.Text = "LOADING"

                    Await MAJCHECK()

                Else

                    hhrtezh.Text = "● First select your game !"
                    Exit Sub

                End If

            Else

                If (NeedRestart = True) Then
                    OpenShowDialog("A older process was not saved. The launcher going to restart for changes to take effect.", False)
                Else
                    OpenShowDialogInserAccessCode()
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles fdfqsdf.MouseEnter, qsgsdqg.MouseEnter
        AnimationForms.ChangeToOrangeColor(sender)
    End Sub


    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles fdfqsdf.MouseLeave, qsgsdqg.MouseLeave
        AnimationForms.ChangeToWhiteColor(sender)
    End Sub

    Public Sub load_bg()
        If wxcvwxc.BackgroundImage Is Nothing Then
        Else
            wxcvwxc.BackgroundImage.Dispose()
        End If

        If ExeName = "01" Then
            wxcvwxc.BackgroundImage = My.Resources.tersdfsdfyertj
        ElseIf ExeName = "02" Then
            wxcvwxc.BackgroundImage = My.Resources.teryertj
        ElseIf ExeName = "03" Then
            wxcvwxc.BackgroundImage = My.Resources.trejtrj
        End If

        locked = False
    End Sub


    Private Sub Button8_MouseEnter(sender As Object, e As EventArgs) Handles ezgzergr.MouseEnter, qsdfsdqf.MouseEnter, qsdhgdfh.MouseEnter
        CleanImage(sender) 'Optimization clean backgroundimage from the memory

        If sender.name = ezgzergr.Name Then
            sender.BackgroundImage = My.Resources.olioy
        ElseIf sender.name = qsdfsdqf.Name Then
            sender.BackgroundImage = My.Resources.iuluil
        ElseIf sender.name = qsdhgdfh.Name Then
            sender.BackgroundImage = My.Resources.ezfezf
        End If
    End Sub

    Private Sub Button8_MouseLeave(sender As Object, e As EventArgs) Handles ezgzergr.MouseLeave, qsdfsdqf.MouseLeave, qsdhgdfh.MouseLeave
        CleanImage(sender) 'Optimization clean backgroundimage from the memory

        If sender.name = ezgzergr.Name Then
            sender.BackgroundImage = My.Resources.kjuyk
        ElseIf sender.name = qsdfsdqf.Name Then
            sender.BackgroundImage = My.Resources.dsfgsfdg
        ElseIf sender.name = qsdhgdfh.Name Then
            sender.BackgroundImage = My.Resources.vdssdv
        End If
    End Sub

    Private Sub Button8910_Click(sender As Object, e As EventArgs) Handles ezgzergr.Click, qsdfsdqf.Click, qsdhgdfh.Click
        If locked = True Then
            Exit Sub
        End If

        If sender.name = ezgzergr.Name Then
            Process.Start("https://discord.gg/" & dscCode)
        ElseIf sender.name = qsdfsdqf.Name Then
            Process.Start("https://www.youtube.com/c/probablyvecr/videos")
        ElseIf sender.name = qsdhgdfh.Name Then
            Process.Start("https://twitter.com/comingsoon")
        End If
    End Sub

    Private Sub Buttonselected_Click(sender As Object, e As EventArgs) Handles rg7re4g8.Click, rg7re4g9.Click, Mdgerherh.Click
        If locked = True Then
            Exit Sub
        End If

        locked = True

        Mdgerherh.NormalBorderColor = Color.FromArgb(64, 64, 64)
        rg7re4g8.NormalBorderColor = Color.FromArgb(64, 64, 64)
        rg7re4g9.NormalBorderColor = Color.FromArgb(64, 64, 64)

        If sender.Name = Mdgerherh.Name Then
            ExeName = "01"
            selectedGAME = 1
            ProcessName = "plutonium-bootstrapper-win32"
            hhrtezh.Text = "● Selected Game: " & ExeName
            Mdgerherh.NormalBorderColor = BasicColor01
            BackColor = BasicColor01
        ElseIf sender.Name = rg7re4g8.Name Then
            ExeName = "02"
            selectedGAME = 2
            ProcessName = "plutonium-bootstrapper-win32"
            hhrtezh.Text = "● Selected Game: " & ExeName
            rg7re4g8.NormalBorderColor = BasicColor02
            BackColor = BasicColor02
        ElseIf sender.Name = rg7re4g9.Name Then
            ExeName = "03"
            selectedGAME = 3
            ProcessName = "plutonium-bootstrapper-win32"
            hhrtezh.Text = "● Selected Game: " & ExeName
            rg7re4g9.NormalBorderColor = BasicColor03
            BackColor = BasicColor03
        End If

        load_bg()
    End Sub



    Private Async Sub Button10_Click(sender As Object, e As EventArgs) Handles qsgsdqg.Click
        If locked = True Then
            Exit Sub
        End If

        Await Task.Delay(100)

        If (sender.Text = "ɢᴇᴛ ᴜᴘɢʀᴀᴅᴇ") Then
            qsdfqsdf.Show()
        ElseIf (sender.Text = "ʀᴇꜱᴇᴛ ʟɪᴄᴇɴꜱᴇ") Then
            File.Delete("LICENSE")
            Application.Restart()
        End If
    End Sub











    Public Sub CleanImage(sender As Object)
        sender.BackgroundImage.Dispose()
        sender.BackgroundImage = Nothing
    End Sub

    Private Sub Button7_MouseEnter(sender As Object, e As EventArgs) Handles erzgerzg.MouseEnter, ezrtezrt.MouseEnter
        CleanImage(sender) 'Optimization clean backgroundimage from the memory

        If sender.Name = erzgerzg.Name Then
            sender.backgroundimage = My.Resources.ioymioym
        ElseIf sender.Name = ezrtezrt.Name Then
            sender.backgroundimage = My.Resources.hgjhgj
        End If
    End Sub

    Private Sub Button7_MouseLeave(sender As Object, e As EventArgs) Handles erzgerzg.MouseLeave, ezrtezrt.MouseLeave
        CleanImage(sender) 'Optimization clean backgroundimage from the memory

        If sender.Name = erzgerzg.Name Then
            sender.backgroundimage = My.Resources.errthrtjh
        ElseIf sender.Name = ezrtezrt.Name Then
            sender.backgroundimage = My.Resources.azetazet
        End If
    End Sub






    Private Sub LabelINFO_TextChanged(sender As Object, e As EventArgs) Handles hhrtezh.TextChanged
        Dim numlines As Integer = hhrtezh.Text.Split(vbCrLf).Length
        Dim resulttxt As String = ""

        If numlines = 12 Then

            Dim sr As New IO.StringReader(hhrtezh.Text)

            For i As Integer = 1 To numlines

                resulttxt = sr.ReadLine()

            Next

            hhrtezh.ResetText()

            hhrtezh.Text = resulttxt

        End If
    End Sub

    Public Function CheckColor(sender As Object)

        If (ExeName = "00") Then
            sender.ForeColor = BasicColor02
        ElseIf (ExeName = "01") Then
            sender.ForeColor = BasicColor01
        ElseIf (ExeName = "02") Then
            sender.ForeColor = BasicColor02
        ElseIf (ExeName = "03") Then
            sender.ForeColor = BasicColor03
        End If

    End Function

    Public Async Function BlinkingText(sender As Object) As Task

        While 1

            Await Task.Delay(350)

            If sender.ForeColor = BasicColor01 Or sender.ForeColor = BasicColor02 Or sender.ForeColor = BasicColor03 Then
                sender.ForeColor = Color.White
            Else
                CheckColor(sender)
            End If
        End While

    End Function

    Public Async Function changename() As Task

        Await Task.Delay(100)

        Try

            For Each frm In Application.OpenForms

                frm.Name = generateRandomCombination()
                frm.Text = generateRandomCombination()

            Next

        Catch ex As Exception

        End Try

    End Function

End Class