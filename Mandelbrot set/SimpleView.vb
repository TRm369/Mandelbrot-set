Public Class SimpleView

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
            final.Save(SaveFileDialog1.FileName)
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
            MsgBox("Estimated time of calculation: " & eta.Hour & ":" & eta.Minute & ":" & eta.Second)
        Else
            MsgBox("Not enough data to calculate")
        End If
    End Sub

    Private Sub btnMode_Click(sender As Object, e As EventArgs) Handles btnMode.Click
        AdvancedView.PictureBox1.Image = final
        AdvancedView.ProgressBar1.Value = ProgressBar1.Value
        AdvancedView.lblStatus.Text = lblStatus.Text
        AdvancedView.Show()
        Me.Close()
    End Sub
End Class