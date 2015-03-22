<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SimpleView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numPrecision = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numIterations = New System.Windows.Forms.NumericUpDown()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnGenerateAsync = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnEstimate = New System.Windows.Forms.Button()
        Me.btnMode = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPrecision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numIterations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 88)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(750, 500)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(223, 7)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(227, 28)
        Me.btnGenerate.TabIndex = 1
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(643, 7)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(119, 23)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.FileName = "Mandelbrot set"
        Me.SaveFileDialog1.Filter = "Bitmap|*.bmp"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Precision:"
        '
        'numPrecision
        '
        Me.numPrecision.DecimalPlaces = 6
        Me.numPrecision.Increment = New Decimal(New Integer() {1, 0, 0, 393216})
        Me.numPrecision.Location = New System.Drawing.Point(66, 14)
        Me.numPrecision.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numPrecision.Minimum = New Decimal(New Integer() {1, 0, 0, 393216})
        Me.numPrecision.Name = "numPrecision"
        Me.numPrecision.Size = New System.Drawing.Size(68, 20)
        Me.numPrecision.TabIndex = 4
        Me.numPrecision.Value = New Decimal(New Integer() {4, 0, 0, 196608})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Max number of iterations:"
        '
        'numIterations
        '
        Me.numIterations.Location = New System.Drawing.Point(140, 48)
        Me.numIterations.Maximum = New Decimal(New Integer() {250, 0, 0, 0})
        Me.numIterations.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.numIterations.Name = "numIterations"
        Me.numIterations.Size = New System.Drawing.Size(53, 20)
        Me.numIterations.TabIndex = 6
        Me.numIterations.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(456, 46)
        Me.ProgressBar1.Maximum = 500
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(307, 23)
        Me.ProgressBar1.TabIndex = 7
        '
        'btnGenerateAsync
        '
        Me.btnGenerateAsync.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateAsync.Location = New System.Drawing.Point(223, 41)
        Me.btnGenerateAsync.Name = "btnGenerateAsync"
        Me.btnGenerateAsync.Size = New System.Drawing.Size(227, 28)
        Me.btnGenerateAsync.TabIndex = 8
        Me.btnGenerateAsync.Text = "Generate Async"
        Me.btnGenerateAsync.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 250
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(456, 31)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(38, 13)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.Text = "Ready"
        '
        'btnEstimate
        '
        Me.btnEstimate.Location = New System.Drawing.Point(562, 7)
        Me.btnEstimate.Name = "btnEstimate"
        Me.btnEstimate.Size = New System.Drawing.Size(75, 23)
        Me.btnEstimate.TabIndex = 10
        Me.btnEstimate.Text = "Estimate"
        Me.btnEstimate.UseVisualStyleBackColor = True
        '
        'btnMode
        '
        Me.btnMode.Location = New System.Drawing.Point(459, 7)
        Me.btnMode.Name = "btnMode"
        Me.btnMode.Size = New System.Drawing.Size(97, 23)
        Me.btnMode.TabIndex = 11
        Me.btnMode.Text = "Advanced mode"
        Me.btnMode.UseVisualStyleBackColor = True
        '
        'SimpleView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 597)
        Me.Controls.Add(Me.btnMode)
        Me.Controls.Add(Me.btnEstimate)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnGenerateAsync)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.numIterations)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.numPrecision)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "SimpleView"
        Me.Text = "Mandelbrot set"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPrecision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numIterations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents numPrecision As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents numIterations As System.Windows.Forms.NumericUpDown
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnGenerateAsync As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents btnEstimate As System.Windows.Forms.Button
    Friend WithEvents btnMode As System.Windows.Forms.Button

End Class
