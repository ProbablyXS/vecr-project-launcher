Imports System.Text
Imports System.Security.Cryptography

Public Module ENCRYDECRYPTO


    'ENCRYPT
    Public Function ENCRYPTO(keys)

        Dim TextInBytes() As Byte = Encoding.ASCII.GetBytes(keys)
        Dim crypt As New DESCryptoServiceProvider()
        Dim KEYB() As Byte = Encoding.ASCII.GetBytes(Decode(_busy))
        crypt.Key = KEYB
        crypt.IV = KEYB
        Dim Icrypt As ICryptoTransform = crypt.CreateEncryptor()
        Dim result() As Byte = Icrypt.TransformFinalBlock(TextInBytes, 0, TextInBytes.Length)
        keys = Convert.ToBase64String(result)

        Return keys

    End Function

    Public _busy As String = "_1Z00@1-" _
& "0à@19-1" _
& "9(@01àn90J-10-i9à@1c-100à@1-G" _
& "101(90à-t@t_àb1)@90à2-19" _
& ")à9-@8-1="

    Public dscCode As String = "cwpTzD3Bwn"

    Public _standalone As String = "aHR0cHM6Ly9yYXcuZ2l0aHVidXNlcmNvbnRlbnQuY29tL0FybWFkYUZyZWV6ZS9Bcm1hZGFGcmVlemUvbWFpbi9jb25maWc=" 'b64

    Public Function DECRYPTO(keys) As String

        Dim Resultat() As Byte = Convert.FromBase64String(keys)
        Dim crypt As New DESCryptoServiceProvider()
        Dim KEYB() As Byte = Encoding.ASCII.GetBytes(Decode(_busy))
        crypt.Key = KEYB
        crypt.IV = KEYB
        Dim Icrypt As ICryptoTransform = crypt.CreateDecryptor()
        Dim données() As Byte = Icrypt.TransformFinalBlock(Resultat, 0, Resultat.Length)
        keys = Encoding.UTF8.GetString(données)

        Return keys

    End Function

    Public Function Decode(text As String)

        text = text.Replace("_", Nothing).Replace("-", Nothing).Replace("(", Nothing).Replace(")", Nothing).Replace("0", Nothing).Replace("1", Nothing).Replace("9", Nothing).Replace("@", Nothing).Replace("à", Nothing)
        Return Encoding.UTF8.GetString(Convert.FromBase64String(text))

    End Function

    Public Function Decode3(text As String)

        text = text.Replace("_", Nothing).Replace("-", Nothing).Replace("(", Nothing).Replace(")", Nothing).Replace("@", Nothing).Replace("à", Nothing)
        Return Encoding.UTF8.GetString(Convert.FromBase64String(text))

    End Function

    Public Function Decode2(text As String)

        Return Encoding.UTF8.GetString(Convert.FromBase64String(text))

    End Function

    'Public Function Encode2(text)

    '    Dim base64Encoded As String = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(text))

    '    Return base64Encoded

    'End Function

End Module

