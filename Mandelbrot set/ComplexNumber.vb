Public Class ComplexNumber
    Private r As Double
    Private i As Double

    Public Sub New(ByVal real As Double, ByVal imaginary As Double)
        r = real
        i = imaginary
    End Sub

    Public Property Real As Double
        Get
            Return r
        End Get
        Set(value As Double)
            r = value
        End Set
    End Property

    Public Property Imaginary As Double
        Get
            Return i
        End Get
        Set(value As Double)
            i = value
        End Set
    End Property

    Function square() As ComplexNumber
        Return New ComplexNumber(r ^ 2 - i ^ 2, 2 * r * i)
    End Function

    Function magnitude() As Double
        Return Math.Sqrt(r ^ 2 + i ^ 2)
    End Function

    Public Shared Operator +(ByVal num1 As ComplexNumber, ByVal num2 As ComplexNumber)
        Return New ComplexNumber(num1.Real + num2.Real, num1.Imaginary + num2.Imaginary)
    End Operator
End Class
