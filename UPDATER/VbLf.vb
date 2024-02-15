Imports System.IO
Imports System.Net.Http
Imports System.Net.NetworkInformation
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class qsdfqsdf

    Dim valmessage As Integer = 0
    Dim waitSend As Boolean = False
    Dim UUID As String
    Dim MACHINEID = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Cryptography", "MachineGuid", Nothing)
    Dim PCNAME = My.Computer.Name
    Dim MACADDRESS As String
    Public ini_token As New clsIni(Environment.CurrentDirectory & "\LICENSE")
    Dim encryptval As String = "UzJGdkc1SE9mcW5wM1huUzJOMWcrbXJBQVd0ajBQZDc="
    Public encryptac As String = "aEVsbFE3c0lHR0lhdjQrWmJDb0d2RG8rSXp4eXhKWVRjeE0xNUJaQW1RZG5Ba0I5NmdXM05NME8zQjlZSldFYUkwMDU3dFhlekJjPQ=="
    Public encryptacKEY As String = "UzJGdkc1SE9mcW5wM1huUzJOMWcrbXJBQVd0ajBQZDc="
    Public encryptacKEY8 As String = "c2tkZmI4a1VFOWRZQURGZjM5L0Y5cjlNRXMrNzZIV0J2ZTdlZTlabXRYND0="
    Public encryptacKEY9 As String = "dlorbnJoaGRXNlN4ZlcrVitPaXRCZz09"

    Private Async Sub FGetPremium_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point((treyrteyu.Width - Me.Width) / 2 + treyrteyu.Location.X, (treyrteyu.Height - Me.Height) / 2 + treyrteyu.Location.Y)

        Me.BackColor = treyrteyu.BackColor()
        dsfgdfsh.FlatAppearance.BorderColor = treyrteyu.BackColor()

        If treyrteyu.EnteredIntoHWIDMenu = False Then

            Try

                Dim p As New Process()
                p.StartInfo.RedirectStandardOutput = True
                p.StartInfo.UseShellExecute = False
                p.StartInfo.CreateNoWindow = True
                p.StartInfo.Arguments = "/C wmic path win32_computersystemproduct get uuid"
                p.StartInfo.FileName = "cmd.exe"
                p.Start()
                p.WaitForExit()

                Dim resultat As String = p.StandardOutput.ReadToEnd

                resultat = resultat.Remove(0, 69).Trim

                UUID = resultat


                Dim MYUUID As String = UUID 'UUID
                MYUUID = MYUUID.Replace("#", Nothing) 'UUID

                If (MACHINEID = "" Or MACHINEID = Nothing) Then
                    My.Computer.Registry.SetValue(
    "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Cryptography", "MachineGuid", generateRandomCombinationforMACHINEID)

                    MACHINEID = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Cryptography", "MachineGuid", Nothing)
                End If

                MACADDRESS = GetMacAddress()

                treyrteyu.MYCODE = (MYUUID & vbCrLf & PCNAME & vbCrLf & MACHINEID & vbCrLf & MACADDRESS)

                Dim endPoint As String = treyrteyu.laddress & "/api/encrypt"
                Dim client = New HttpClient()
                Dim data = {New KeyValuePair(Of String, String)(DECRYPTO(Decode2(encryptval)), treyrteyu.MYCODE)}
                Dim POST = client.PostAsync(endPoint, New FormUrlEncodedContent(data)).GetAwaiter().GetResult()
                Dim ReturnMessage As String = POST.Content.ReadAsStringAsync().Result
                Dim json As String = ReturnMessage
                treyrteyu.MYCODE = JObject.Parse(json)("data").ToString().Trim()

            Catch ex As Exception
                treyrteyu.OpenShowDialog("Cannot configure your PC for activation", True)
                Return
            End Try

        End If

        qfbdbqdf.Text += treyrteyu.MYCODE.Substring(0, 50) & "..."

        Await AnimationForms.open_form(Me)

        Me.Owner = treyrteyu
        treyrteyu.SendToBack()
        treyrteyu.EnteredIntoHWIDMenu = True

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles xcvbxcvb.Click

        If sender.name = xcvbxcvb.Name Then
            Process.Start("https://discord.gg/" & dscCode)
        End If

    End Sub

    Private Async Sub B_MENU_Click(sender As Object, e As EventArgs) Handles sdqfdsqf.Click

        If locked = True Then
            Exit Sub
        End If

        Await Task.Delay(500)

        Await close_form(Me)

        Await Task.Delay(100)
        Close()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles yrjuytrj.KeyPress

        If e.KeyChar <> ControlChars.Back Then

            e.Handled = Not (Char.IsDigit(e.KeyChar))

        End If

        If e.KeyChar = Chr(Keys.Enter) Then

            SendTKN()

        End If

    End Sub

    Private Sub SendTKN() Handles dsfgdfsh.Click

        Try

            If yrjuytrj.Text = "" Or yrjuytrj.Text = "token" Then
                Exit Sub
            End If

            If (qsdzafazgazg.Checked = True) Then
                If gazegdghdf.Text = "" Or
                   gazegdghdf.Text = "discordId" Or
                   fsgsfhdfh.Text = "" Or
                   fsgsfhdfh.Text = "email" Then

                    Exit Sub

                End If

                If gazegdghdf.Text.Length < 17 Then
                    Exit Sub
                ElseIf fsgsfhdfh.Text.Contains("@") = False Or
                    fsgsfhdfh.Text.Contains(".") = False Then
                    Exit Sub
                End If

            End If

            If yrjuytrj.Text.Length < 7 Then
                Exit Sub
            End If

            If (qsdzafazgazg.Checked = True) Then
                Dim endPoint As String = treyrteyu.laddress & "/api/" & DECRYPTO(Decode2(encryptacKEY9)) & "/" & DECRYPTO(Decode2(encryptacKEY8))
                Dim client = New HttpClient()
                Dim dataList = New List(Of KeyValuePair(Of String, String))()
                dataList.Add(New KeyValuePair(Of String, String)("token", yrjuytrj.Text))
                dataList.Add(New KeyValuePair(Of String, String)("prevHWID", treyrteyu.MYCODE))
                dataList.Add(New KeyValuePair(Of String, String)("discordId", gazegdghdf.Text))
                dataList.Add(New KeyValuePair(Of String, String)("email", fsgsfhdfh.Text))
                Dim POST = client.PostAsync(endPoint, New FormUrlEncodedContent(dataList)).GetAwaiter().GetResult()
                Dim ReturnMessage As String = POST.Content.ReadAsStringAsync().Result

                Dim parsejson As JObject = JObject.Parse(ReturnMessage)
                Dim value = parsejson.Properties().[Select](Function(p) p.Value).FirstOrDefault().ToString()

                If (ReturnMessage.Contains("error")) Then
                    sdgsdgfdg.Text = value
                    Exit Sub
                End If
            End If

            ini_token.WriteString("LICENSE", "License", yrjuytrj.Text)
            ini_token.WriteString("LICENSE", "HWID", treyrteyu.MYCODE)

            Dim writeOLDWHID As New StreamWriter("BACKUP.ini")
            writeOLDWHID.WriteLine("TOKEN=" & ini_token.GetString("LICENSE", "License", ""))
            writeOLDWHID.WriteLine("OLDHWID=" & ini_token.GetString("LICENSE", "HWID", ""))
            writeOLDWHID.Close()

            sdgsdgfdg.Text = "Info: Done"

            treyrteyu.OpenShowDialog("Your license have been saved.
The launcher going to restart for changes to take effect.", False)

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
            sdgsdgfdg.Text = "Info: A error was occured..."
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles sdfhsdfh.Click, qfbdbqdf.Click
        My.Computer.Clipboard.SetText(treyrteyu.MYCODE)
        qfbdbqdf.ForeColor = Color.LimeGreen
    End Sub

    Private Sub Button8_MouseEnter(sender As Object, e As EventArgs) Handles xcvbxcvb.MouseEnter
        If sender.name = xcvbxcvb.Name Then
            sender.BackgroundImage = My.Resources.olioy
        End If
    End Sub

    Private Sub Button8_MouseLeave(sender As Object, e As EventArgs) Handles xcvbxcvb.MouseLeave
        If sender.name = xcvbxcvb.Name Then
            sender.BackgroundImage = My.Resources.kjuyk

        End If
    End Sub

    Private Sub Button2_MouseEnter(sender As Object, e As EventArgs) Handles sdfhsdfh.MouseEnter, dsfgdfsh.MouseEnter

        treyrteyu.CheckColor(sender)

    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles sdfhsdfh.MouseLeave, dsfgdfsh.MouseLeave
        sender.ForeColor = System.Drawing.Color.WhiteSmoke
    End Sub

    Private Sub B_MENU_MouseEnter(sender As Object, e As EventArgs) Handles sdqfdsqf.MouseEnter

        treyrteyu.CleanImage(sender)

        If sender.name = sdqfdsqf.Name Then
            sender.BackgroundImage = My.Resources.hgjhgj
        End If

    End Sub

    Private Sub B_MENU_MouseLeave(sender As Object, e As EventArgs) Handles sdqfdsqf.MouseLeave

        treyrteyu.CleanImage(sender)

        If sender.name = sdqfdsqf.Name Then
            sender.BackgroundImage = My.Resources.azetazet

        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles fdgnfgdnfgn.LinkClicked, gfd4gdf8g04.LinkClicked

        If sender.Name = fdgnfgdnfgn.Name Then
            Process.Start("https://discord.gg/" & dscCode)
        ElseIf sender.Name = gfd4gdf8g04.Name Then
            Process.Start("https://discord.gg/" & dscCode)
        End If

    End Sub


    Private Function GetMacAddress() As String
        Try
            Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            Dim adapter As NetworkInterface
            Dim myMac As String = String.Empty

            For Each adapter In adapters
                Select Case adapter.NetworkInterfaceType
                'Exclude Tunnels, Loopbacks and PPP
                    Case NetworkInterfaceType.Tunnel,
                         NetworkInterfaceType.Loopback,
                         NetworkInterfaceType.Ppp,
                         NetworkInterfaceType.Unknown
                    Case Else
                        If Not adapter.GetPhysicalAddress.ToString = String.Empty And Not adapter.GetPhysicalAddress.ToString = "00000000000000E0" Then
                            myMac = adapter.GetPhysicalAddress.ToString
                            Exit For
                        End If
                End Select
            Next
            Return myMac
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Private Sub yrjuytrj_Enter(sender As Object, e As EventArgs) Handles yrjuytrj.Enter, gazegdghdf.Enter, fsgsfhdfh.Enter

        If (sender.Text.ToLower() = "token".ToLower() Or
            sender.Text.ToLower() = "discordId".ToLower() Or
            sender.Text.ToLower() = "email".ToLower()) Then

            sender.Text = ""

        End If

        If (sender.Name = "yrjuytrj") Then
            vcbcvfgd.Visible = True
        ElseIf (sender.Name = "gazegdghdf") Then
            sdfsdfsdf.Visible = True
        ElseIf (sender.Name = "fsgsfhdfh") Then
            sdgzg.Visible = True
        End If

    End Sub

    Private Sub yrjuytrj_Leave(sender As Object, e As EventArgs) Handles yrjuytrj.Leave, gazegdghdf.Leave, fsgsfhdfh.Leave

        If (sender.Text.Length() = 0) Then

            If (sender.Name = "yrjuytrj") Then
                sender.Text = "token"
            ElseIf sender.Name = "gazegdghdf" Then
                sender.Text = "discordId"
            ElseIf sender.Name = "fsgsfhdfh" Then
                sender.Text = "email"
            End If

        End If

        If (sender.Name = "yrjuytrj") Then
            vcbcvfgd.Visible = False
        ElseIf (sender.Name = "gazegdghdf") Then
            sdfsdfsdf.Visible = False
        ElseIf (sender.Name = "fsgsfhdfh") Then
            sdgzg.Visible = False
        End If

    End Sub

    Private Sub gazegdghdf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gazegdghdf.KeyPress
        If e.KeyChar <> ControlChars.Back Then

            e.Handled = Not (Char.IsDigit(e.KeyChar))

        End If
    End Sub

    Private Sub qsdzafazgazg_CheckedChanged(sender As Object, e As EventArgs) Handles qsdzafazgazg.CheckedChanged
        If (qsdzafazgazg.Checked = True) Then

            qsdzafazgazg.Text = "Back"

            qsdzafazgazg.Top = 114
            qsdzafazgazg.Left = 338
            yrjuytrj.Top = 143
            vcbcvfgd.Top = 147

            gazegdghdf.Visible = True
            fsgsfhdfh.Visible = True
        Else

            qsdzafazgazg.Text = "Register"

            qsdzafazgazg.Top = 142
            qsdzafazgazg.Left = 329
            yrjuytrj.Top = 171
            vcbcvfgd.Top = 175

            gazegdghdf.Visible = False
            fsgsfhdfh.Visible = False
        End If
    End Sub
End Class