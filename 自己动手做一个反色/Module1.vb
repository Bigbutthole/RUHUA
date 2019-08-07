Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms
Imports 反色模块
Module Module1
    Public Declare Function GetWindowDC Lib "user32" (ByVal hwnd As Long) As Long '获得整个屏幕绘制
    Public Declare Function GetDesktopWindow Lib "user32" () As Long '获得整个桌面绘制
    Private App As AppDomain = AppDomain.CurrentDomain
    Function 加载屏幕反色模块(sender As Object, e As ResolveEventArgs) As Assembly
        If New AssemblyName(e.Name).Name = "反色模块" Then
            Return Assembly.Load(My.Resources.Resource1.反色模块)
        End If
    End Function
    Sub New()
        AddHandler App.AssemblyResolve, AddressOf Module1.加载屏幕反色模块
    End Sub
    Sub Main()
        Dim newthread As New Threading.Thread(AddressOf Main2)
        newthread.Start()
        Do
            Dim www As Graphics = Graphics.FromHdc(ApiClass.GetWindowDC(ApiClass.GetDesktopWindow))
            Dim scr As Windows.Forms.Screen = Screen.PrimaryScreen
            Dim temp1 As New Bitmap(scr.WorkingArea.Width, scr.WorkingArea.Height)
            Dim ww As Graphics = Graphics.FromImage(temp1)
            ww.CopyFromScreen(New Point, New Point, scr.WorkingArea.Size)
            Dim handle As IntPtr = Class1.PContray(temp1).GetHicon
            www.DrawIcon(Icon.FromHandle(handle), scr.WorkingArea)
            Threading.Thread.Sleep(1000)
        Loop
    End Sub
    Sub Main2()
        Dim ico1 As Bitmap = My.Resources.Resource1.a.ToBitmap
        Dim ico2 As Bitmap = My.Resources.Resource1.b.ToBitmap
        Dim ico3 As Bitmap = My.Resources.Resource1.c.ToBitmap
        Dim ico4 As Bitmap = My.Resources.Resource1.d.ToBitmap
        Dim screen As Graphics = Graphics.FromHdc(GetWindowDC(GetDesktopWindow()))
        Do
            screen.DrawImage(ico1, Rnd() * System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, Rnd() * System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height)
            Threading.Thread.Sleep(500)
            screen.DrawImage(ico2, Rnd() * System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, Rnd() * System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height)
            Threading.Thread.Sleep(500)
            screen.DrawImage(ico3, Rnd() * System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, Rnd() * System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height)
            Threading.Thread.Sleep(500)
            screen.DrawImage(ico4, Rnd() * System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, Rnd() * System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height)
            Threading.Thread.Sleep(1000)
        Loop
    End Sub
End Module
