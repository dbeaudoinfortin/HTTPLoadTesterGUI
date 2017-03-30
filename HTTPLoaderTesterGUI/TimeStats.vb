Public Class TimeStats
    Public min As Long
    Public max As Long
    Public total As Long
    Public count As Integer
    Public average As Double
    Public lastUpdated As Date
    Public rolling5 As RollingStats
    Public rolling10 As RollingStats
    Public rolling25 As RollingStats
    Public rolling50 As RollingStats
    Public rolling100 As RollingStats
    Public rolling250 As RollingStats

    Public Class RollingStats
        Public rollingAverage As Double
    End Class
End Class
