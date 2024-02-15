Module Random

    Public rand_val As New System.Random

    Public Function generateRandomCombination() As String
        Dim alphabet As String = "abcdefghijklmnopqrstuvwxyz"
        Dim randomNumber As New System.Random
        Dim result As String
        For x As Integer = 1 To 14

            If (randomNumber.Next(0, 1)) Then
                result &= randomNumber.Next(0, 26).ToString
            Else
                result &= alphabet.Substring(randomNumber.Next(0, 26), 1).ToUpper
            End If
        Next

        Return result
    End Function

    Public Function generateRandomCombinationforMACHINEID() As String
        Dim alphabet As String = "123456789"
        Dim randomNumber As New System.Random
        Dim result As String

        For x As Integer = 1 To 8

            If (randomNumber.Next(0, 1)) Then
                result &= randomNumber.Next(0, 9).ToString
            Else
                result &= alphabet.Substring(randomNumber.Next(0, 9), 1).ToUpper
            End If

        Next

        result += "-"

        For i As Integer = 1 To 3

            For x As Integer = 1 To 4

                If (randomNumber.Next(0, 1)) Then
                    result &= randomNumber.Next(0, 9).ToString
                Else
                    result &= alphabet.Substring(randomNumber.Next(0, 9), 1).ToUpper
                End If
            Next

            result += "-"

        Next

        For x As Integer = 1 To 12

            If (randomNumber.Next(0, 1)) Then
                result &= randomNumber.Next(0, 9).ToString
            Else
                result &= alphabet.Substring(randomNumber.Next(0, 9), 1).ToUpper
            End If
        Next

        Return result
    End Function

End Module
