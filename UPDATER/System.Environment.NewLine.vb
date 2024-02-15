Imports System.Net

Public Class sdfhfdshdfs

    Dim ini As New clsIni(Environment.CurrentDirectory & "\data\conf.ini")

    ''MOUVE FORM WITH MOUSE'
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Public WantApplicationExit = False
    Public access As Integer = 0

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

    Private Sub Button7_MouseEnter(sender As Object, e As EventArgs) Handles ezrtezrt.MouseEnter
        treyrteyu.CleanImage(sender) 'Optimization clean backgroundimage from the memory

        If sender.Name = ezrtezrt.Name Then
            sender.backgroundimage = My.Resources.hgjhgj
        End If
    End Sub

    Private Sub Button7_MouseLeave(sender As Object, e As EventArgs) Handles ezrtezrt.MouseLeave
        treyrteyu.CleanImage(sender) 'Optimization clean backgroundimage from the memory

        If sender.Name = ezrtezrt.Name Then
            sender.backgroundimage = My.Resources.azetazet
        End If
    End Sub

    Private Sub fdfqsdf_Click(sender As Object, e As EventArgs) Handles fdfqsdf.Click

        If access = 1 Then
            If yrjuytrj.Text = treyrteyu.read_code Then

                ini.WriteString("LINK", "START_KEY", yrjuytrj.Text)
                treyrteyu.locked = False
                Me.Close()

            Else

                ghjghfkj.Text = "Status: Wrong code"
                ghjghfkj.ForeColor = Color.DarkRed

            End If
        End If
    End Sub

    Private Sub ezrtezrt_Click(sender As Object, e As EventArgs) Handles ezrtezrt.Click

        treyrteyu.locked = False
        Me.Close()

    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles fdfqsdf.MouseEnter
        sender.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0)
    End Sub


    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles fdfqsdf.MouseLeave
        sender.ForeColor = System.Drawing.Color.WhiteSmoke
    End Sub

    Private Sub sdfhfdshdfs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Owner = treyrteyu
        Me.Owner = qsdfqsdf
        treyrteyu.SendToBack()
        qsdfqsdf.SendToBack()

        Me.BackColor = treyrteyu.BackColor()

        access = 1
    End Sub

    Private Sub sdfgdfhdh_Click(sender As Object, e As EventArgs) Handles sdfgdfhdh.Click

        If WantApplicationExit = True Then
            Application.Exit()
        Else
            Application.Restart()
        End If
    End Sub

    Private Sub sdfgdfhdh_MouseEnter(sender As Object, e As EventArgs) Handles sdfgdfhdh.MouseEnter
        sender.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0)
    End Sub

    Private Sub sdfgdfhdh_MouseLeave(sender As Object, e As EventArgs) Handles sdfgdfhdh.MouseLeave
        sender.ForeColor = System.Drawing.Color.WhiteSmoke
    End Sub

    Private Sub sdfhfdshdfs_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        treyrteyu.locked = False
    End Sub
End Class