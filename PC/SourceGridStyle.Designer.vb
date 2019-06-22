Partial Class SourceGridStyle
    Inherits System.ComponentModel.Component

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Windows.Forms 클래스 컴퍼지션 디자이너 지원에 필요합니다.
        Container.Add(Me)

    End Sub

    '<System.Diagnostics.DebuggerNonUserCode()> _
    'Public Sub New()
    '    MyBase.New()

    '    '이 호출은 구성 요소 디자이너에 필요합니다.
    '    InitializeComponent()

    'End Sub

    'Component는 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    '구성 요소 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 구성 요소 디자이너에 필요합니다.
    '구성 요소 디자이너를 사용하여 수정할 수 있습니다.
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

End Class
