Public Class AdvancedView

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        If MsgBox("Generate synchronously? Do not use unless necessary!", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        ProgressBar1.Value = 0
        time = 0
        Try
            mandelbrot = New MandelbrotSet(numPrecision.Value, numIterations.Value)
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        ProgressBar1.Maximum = mandelbrot.Size.Height
        btnGenerate.Enabled = False
        btnGenerateAsync.Enabled = False
        btnMode.Enabled = False
        Timer1.Enabled = True
        mandelbrot.generate()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If SaveFileDialog1.FileName.EndsWith("bmp") Then
                final.Save(SaveFileDialog1.FileName)
            Else
                mandelbrot.saveRawData(SaveFileDialog1.FileName, CheckBox1.Checked)
            End If

        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        time = time + 1
        ProgressBar1.Value = mandelbrot.Progress
        lblStatus.Text = "Processed " & mandelbrot.Progress & " out of " & mandelbrot.Size.Height & " lines in " & time / 4 & " seconds."
        If mandelbrot.Progress = mandelbrot.Size.Height Then
            final = mandelbrot.getImage()
            PictureBox1.Image = final
            Timer1.Enabled = False
            btnGenerate.Enabled = True
            btnGenerateAsync.Enabled = True
            btnMode.Enabled = True
        End If
    End Sub

    Private Sub btnGenerateAsync_Click(sender As Object, e As EventArgs) Handles btnGenerateAsync.Click
        ProgressBar1.Value = 0
        time = 0
        Try
            mandelbrot = New MandelbrotSet(numPrecision.Value, numIterations.Value)
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        ProgressBar1.Maximum = mandelbrot.Size.Height
        btnGenerate.Enabled = False
        btnGenerateAsync.Enabled = False
        btnMode.Enabled = False
        Timer1.Enabled = True
        mandelbrot.generateAsync()
    End Sub

    Private Sub btnEstimate_Click(sender As Object, e As EventArgs) Handles btnEstimate.Click
        If time <> 0 Then
            Dim speed As Integer
            Dim possibleMandelbrot As MandelbrotSet
            Try
                possibleMandelbrot = New MandelbrotSet(numPrecision.Value, numIterations.Value)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
            speed = mandelbrot.Size.Width * mandelbrot.Size.Height / (time / 4)
            Dim eta As Date
            eta = eta.AddSeconds(possibleMandelbrot.Size.Width * possibleMandelbrot.Size.Height / speed)
            Dim lenght As Integer = possibleMandelbrot.Size.Width * possibleMandelbrot.Size.Height
            Dim units As String() = {" B", " KB", " MB", " GB"}
            Dim sizeInfo As String
            sizeInfo = vbCrLf & "Size of uncompressed data: " & possibleMandelbrot.Size.Width * possibleMandelbrot.Size.Height & " bytes." & vbCrLf & "That is approx. "
            For i As Integer = 0 To 3
                If lenght < 1024 Then
                    sizeInfo &= lenght & units(i) & "."
                    Exit For
                Else
                    lenght = Math.Floor(lenght / 1024)
                End If
            Next
            MsgBox("Estimated time of calculation: " & eta.Hour & ":" & eta.Minute & ":" & eta.Second & sizeInfo)
        Else
            MsgBox("Not enough data to calculate")
        End If
    End Sub

    Private Sub btnMode_Click(sender As Object, e As EventArgs) Handles btnMode.Click
        SimpleView.PictureBox1.Image = final
        SimpleView.ProgressBar1.Value = ProgressBar1.Value
        SimpleView.lblStatus.Text = lblStatus.Text
        SimpleView.Show()
        Me.Close()
    End Sub

    Private Sub radBMP_CheckedChanged(sender As Object, e As EventArgs) Handles radBMP.CheckedChanged
        SaveFileDialog1.Filter = "Bitmap|*.bmp"
        OpenFileDialog1.Filter = "Bitmap|*.bmp"
    End Sub

    Private Sub radRaw_CheckedChanged(sender As Object, e As EventArgs) Handles radRaw.CheckedChanged
        SaveFileDialog1.Filter = "Raw data|*.dat"
        OpenFileDialog1.Filter = "Raw data|*.dat"
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If OpenFileDialog1.FileName.EndsWith("bmp") Then

            Else
                If mandelbrot Is Nothing Then
                    mandelbrot = New MandelbrotSet()
                End If
                mandelbrot.openRawData(OpenFileDialog1.FileName, CheckBox1.Checked)
            End If
            final = mandelbrot.getImage
            PictureBox1.Image = final
        End If
    End Sub
End Class