Imports System.Configuration

Public Class ConfigSectionProtector

    #Region "Fields"

    Private m_Section As String

    #End Region 'Fields

    #Region "Constructors"

    ''' <summary>
    ''' Constructor.
    ''' </summary>
    ''' <param name="section">The section name.</param>
    Public Sub New(ByVal section As String)
        If String.IsNullOrEmpty(section) Then Throw New ArgumentNullException("ConfigurationSection")

        m_Section = section
    End Sub

    #End Region 'Constructors

    #Region "Methods"

    ''' <summary>
    ''' This method protects a section in the applications configuration file. 
    ''' </summary>
    ''' <remarks>The <seealso cref="RsaProtectedConfigurationProvider" /> is used in this implementation.</remarks>
    Public Sub ProtectSection()
        ' Get the current configuration file.
        Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Dim protectedSection As ConfigurationSection = config.GetSection(m_Section)

        ' Encrypts when possible
        If ((protectedSection IsNot Nothing) _
        AndAlso (Not protectedSection.IsReadOnly) _
        AndAlso (Not protectedSection.SectionInformation.IsProtected) _
        AndAlso (Not protectedSection.SectionInformation.IsLocked) _
        AndAlso (protectedSection.SectionInformation.IsDeclared)) Then
            ' Protect (encrypt)the section.
            protectedSection.SectionInformation.ProtectSection(Nothing)
            ' Save the encrypted section.
            protectedSection.SectionInformation.ForceSave = True
            config.Save(ConfigurationSaveMode.Full)
        End If
    End Sub

    #End Region 'Methods

End Class