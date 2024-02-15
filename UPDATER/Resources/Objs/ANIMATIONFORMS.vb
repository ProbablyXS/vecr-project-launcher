Module AnimationForms

    Public Async Function close_form(frm As Form) As Task

        Try

            Await Task.Delay(100)

            While frm.Opacity >= 0

                Await Task.Delay(8)

                If (frm.Opacity <= 1) Then

                    frm.Opacity -= 0.1

                    If (frm.Opacity = 0) Then

                        Await Task.Delay(10)
                        Exit Function

                    End If

                End If

            End While

        Catch ex As Exception

        End Try

    End Function

    Public Async Function open_form(frm As Form) As Task

        Try

            Await Task.Delay(100)

            While frm.Opacity <= 1

                Await Task.Delay(8)

                If (frm.Opacity <= 1) Then

                    frm.Opacity += 0.1

                    If (frm.Opacity = 1) Then

                        Exit Function

                    End If

                Else

                    Exit Function

                End If

            End While

        Catch ex As Exception

        End Try

    End Function

    Public Sub ChangeToWhiteColor(sender As Object)
        sender.ForeColor = System.Drawing.Color.WhiteSmoke
    End Sub

    Public Sub ChangeToOrangeColor(sender As Object)
        If (treyrteyu.ExeName = 1) Then
            sender.ForeColor = treyrteyu.BasicColor01
        ElseIf (treyrteyu.ExeName = 2) Then
            sender.ForeColor = treyrteyu.BasicColor02
        ElseIf (treyrteyu.ExeName = 3) Then
            sender.ForeColor = treyrteyu.BasicColor03
        End If
    End Sub

End Module