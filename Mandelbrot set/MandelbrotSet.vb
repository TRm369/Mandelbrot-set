Public Class MandelbrotSet
    Private Const compressConst As Byte = 255
    Private Const compressConst1 As Byte = 254
    Private Const compressConst2 As Byte = 253
    Private Const compressConst3 As Byte = 252
    Private Const compressConst4 As Byte = 251

    Private position As ComplexNumber
    Private precision As Double
    Private values() As Byte
    Private resolution As Size
    Private maxIteration As Integer
    Private t As New Threading.Thread(AddressOf generate)
    Private done As Integer

    Public Sub New(Optional ByVal precision As Double = 0.004, Optional ByVal maxIteration As Integer = 100)
        If (1 / precision Mod 1) <> 0 Then
            Throw New Exception("Wrong precision")
        End If
        Me.maxIteration = maxIteration
        Me.precision = precision
        resolution = New Size(3 / precision, 2 / precision)
        ReDim values(resolution.Height * resolution.Width)
    End Sub

    Public Sub generate()
        Dim index As Integer = 0
        Dim real As Double = -2
        Dim imaginary As Double = -1

        Debug.WriteLine(resolution.ToString)

        For i As Integer = 1 To resolution.Height
            real = -2
            For r As Integer = 1 To resolution.Width
                values(index) = checkNumber(New ComplexNumber(real, imaginary))
                real = real + precision
                index += 1
            Next
            imaginary = imaginary + precision
            done = done + 1
        Next
    End Sub

    Sub generateAsync()
        t.Start()
    End Sub

    Sub saveRawData(ByVal path As String, ByVal compress As Boolean)
        Dim file As New IO.FileStream(path, IO.FileMode.Create)
        Dim num As Integer
        Dim header(8) As Byte
        num = resolution.Width
        header(0) = Math.Floor(num / 256 ^ 3)
        num = num Mod 256 ^ 3
        header(1) = Math.Floor(num / 256 ^ 2)
        num = num Mod 256 ^ 2
        header(2) = Math.Floor(num / 256)
        num = num Mod 256
        header(3) = num Mod 256
        num = resolution.Height
        header(4) = Math.Floor(num / 256 ^ 3)
        num = num Mod 256 ^ 3
        header(5) = Math.Floor(num / 256 ^ 2)
        num = num Mod 256 ^ 2
        header(6) = Math.Floor(num / 256)
        num = num Mod 256
        header(7) = num Mod 256
        file.Write(header, 0, 8)


        If compress Then
            Dim compressing As Integer = -1
            Dim lenght As Integer = 1
            For index As Integer = 0 To values.Length - 1
                If compressing <> -1 Then
                    If values(index) = compressing Then
                        lenght += 1
                        If lenght = 65535 Then
                            file.Write(New Byte() {255, 255}, 0, 2)
                            'check for compress
                            If values(index) = values(index + 1) And values(index) = values(index + 2) And values(index) = values(index + 3) And values(index) = values(index + 4) Then
                                lenght = 1
                                compressing = values(index)
                                Select Case compressing
                                    Case 1
                                        file.Write(New Byte() {compressConst1}, 0, 1)
                                    Case 2
                                        file.Write(New Byte() {compressConst2}, 0, 1)
                                    Case 3
                                        file.Write(New Byte() {compressConst3}, 0, 1)
                                    Case 4
                                        file.Write(New Byte() {compressConst4}, 0, 1)
                                    Case Else
                                        file.Write(New Byte() {compressConst, compressing}, 0, 2)
                                End Select
                            Else
                                compressing = -1
                                file.Write(New Byte() {values(index)}, 0, 1)
                                Continue For
                            End If
                        End If
                    Else 'end of compress
                        file.Write(New Byte() {Math.Floor(lenght / 256), lenght Mod 256}, 0, 2)
                        compressing = -1
                        file.Write(New Byte() {values(index)}, 0, 1)
                        Continue For
                    End If
                Else
                    If values(index) = values(index + 1) And values(index) = values(index + 2) And values(index) = values(index + 3) And values(index) = values(index + 4) Then
                        lenght = 1
                        compressing = values(index)
                        Select Case compressing
                            Case 1
                                file.Write(New Byte() {compressConst1}, 0, 1)
                            Case 2
                                file.Write(New Byte() {compressConst2}, 0, 1)
                            Case 3
                                file.Write(New Byte() {compressConst3}, 0, 1)
                            Case 4
                                file.Write(New Byte() {compressConst4}, 0, 1)
                            Case Else
                                file.Write(New Byte() {compressConst, compressing}, 0, 2)
                        End Select
                        Continue For
                    Else
                        file.Write(New Byte() {values(index)}, 0, 1)
                    End If
                End If
            Next
            file.Flush()
        Else
            file.Write(values, 0, values.Length)
            file.Flush()
        End If
        file.Close()
    End Sub

    Sub openRawData(ByVal path As String, ByVal compress As Boolean)
        Dim file As New IO.FileStream(path, IO.FileMode.Open)
        resolution.Width = file.ReadByte * 256 ^ 3 + file.ReadByte * 256 ^ 2 + file.ReadByte * 256 + file.ReadByte
        resolution.Height = file.ReadByte * 256 ^ 3 + file.ReadByte * 256 ^ 2 + file.ReadByte * 256 + file.ReadByte
        precision = resolution.Height / 2
        ReDim values(resolution.Height * resolution.Width)

        If compress Then
            Dim index As Integer = 0
            Dim value As Byte
            Dim compression As Integer = 0
            Dim lenght As Integer = 0

            value = file.ReadByte
            While index < resolution.Width * resolution.Height
                If value < 251 Then
                    values(index) = value
                    index += 1
                Else
                    Select Case value
                        Case 251
                            compression = 4
                        Case 252
                            compression = 3
                        Case 253
                            compression = 2
                        Case 254
                            compression = 1
                        Case 255
                            compression = file.ReadByte
                    End Select
                    lenght = file.ReadByte * 256 + file.ReadByte
                    For i As Integer = 1 To lenght
                        values(index) = compression
                        index += 1
                    Next
                End If
                value = file.ReadByte
            End While
        Else
            For index As Integer = 1 To resolution.Width * resolution.Height - 1
                values(index) = file.ReadByte
            Next
        End If
        file.Close()
    End Sub

    Function checkNumber(ByVal C As ComplexNumber) As Integer
        Dim iteration As Integer = 0
        Dim Z As New ComplexNumber(0, 0)
        For iteration = 1 To maxIteration
            Z = Z.square + C
            If Z.magnitude > 2 Then
                Return iteration
            End If
        Next
        Return 0
    End Function

    Function getImage() As Bitmap
        Dim x As Integer = resolution.Width
        Dim y As Integer = resolution.Height
        Dim BMP As New Bitmap(x, y)

        Dim rect As New Rectangle(0, 0, x, y)
        Dim bmpData As System.Drawing.Imaging.BitmapData = BMP.LockBits(rect, Drawing.Imaging.ImageLockMode.ReadWrite, BMP.PixelFormat)
        Dim ptr As IntPtr = bmpData.Scan0
        Dim bytes As Integer = bmpData.Stride * y
        Dim rgbValues(bytes - 1) As Byte

        System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes)
        Dim secondcounter As Integer = 0

        Dim tempred As Integer
        Dim tempblue As Integer
        Dim tempgreen As Integer
        Dim tempalpha As Integer
        Dim tempx As Integer
        Dim tempy As Integer

        While secondcounter < rgbValues.Length
            tempblue = rgbValues(secondcounter)
            tempgreen = rgbValues(secondcounter + 1)
            tempred = rgbValues(secondcounter + 2)
            tempalpha = rgbValues(secondcounter + 3)
            tempalpha = 255
            tempy = ((secondcounter * 0.25) / x)
            tempx = (secondcounter * 0.25) - (tempy * x)
            If tempx < 0 Then
                tempx = tempx + x
            End If

            'Code
            tempred = Math.Floor((255 / maxIteration) * values(secondcounter * 0.25))
            tempgreen = tempred
            If values(secondcounter * 0.25) = 0 Then
                tempblue = 128
            End If

            rgbValues(secondcounter) = tempblue
            rgbValues(secondcounter + 1) = tempgreen
            rgbValues(secondcounter + 2) = tempred
            rgbValues(secondcounter + 3) = tempalpha
            secondcounter = secondcounter + 4
        End While
        System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes)
        BMP.UnlockBits(bmpData)
        Return BMP
    End Function

    Public ReadOnly Property Size As Size
        Get
            Return resolution
        End Get
    End Property

    Public ReadOnly Property Progress As Integer
        Get
            Return done
        End Get
    End Property
End Class
