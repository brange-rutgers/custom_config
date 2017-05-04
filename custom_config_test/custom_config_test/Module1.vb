Imports System.Configuration
Imports ClassLibrary1
Imports ClassLibrary2

Public Class SomeSettings
    Inherits ConfigurationSection

    Private Sub SomeSettings()

    End Sub

    <ConfigurationProperty("FillColor", DefaultValue:="Cyan")>
    Public Property FillColor As System.Drawing.Color

        Get
            Return Me("FillColor")
        End Get
        Set(value As System.Drawing.Color)
            Me("FillColor") = value
        End Set
    End Property

    <ConfigurationProperty("TextSize", DefaultValue:="8.5")>
    Public Property TextSize As Double
        Get
            Return Me("TextSize")
        End Get
        Set(value As Double)
            Me("TextSize") = value
        End Set
    End Property

    <ConfigurationProperty("FillOpacity", DefaultValue:="40")>
    Public Property FillOpacity As Byte
        Get
            Return Me("FillOpacity")
        End Get
        Set(value As Byte)
            Me("FillOpacity") = value
        End Set
    End Property
End Class

Module Module1

    Sub Main()
        Dim x As New Class1 With {
            .foo = 1
        }

        Dim y As New Class2 With {
            .foo = 2
        }

        Dim instance As New SomeSettings
        Dim config As Configuration =
            ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        'Dim section = config.GetSection("SomeSettings")
        'Dim section2 = config.Sections("SomeSettings")
        'Dim info = section.SectionInformation

        If IsNothing(config.Sections("dev1")) Then
            instance = New SomeSettings()
            config.Sections.Add("MySection", instance)
            config.Save(ConfigurationSaveMode.Modified)
        Else
            'instance = New SomeSettings()
            'config.Sections.Add("MySection", instance)
            'config.Save(ConfigurationSaveMode.Modified)
        End If

        Dim gui As SomeSettings = config.Sections("dev1")
        Dim gui2 As SomeSettings = config.Sections("dev2")
        Dim fSize As Double = gui.TextSize
    End Sub
End Module
