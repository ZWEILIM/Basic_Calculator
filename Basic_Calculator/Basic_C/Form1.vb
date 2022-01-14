Public Class Form1
    Dim input As Integer = 0
    Dim input2 As Integer = 0
    Dim operation, operation2 As String
    Dim expression As Boolean = False
    Dim firstnum, secondnum, q As String


    Private Sub optclick(sender As Object, e As EventArgs) Handles Button16.Click, Button14.Click, Button13.Click, Button12.Click
        TreeCat.Visible = False
        Dim btn As Button = sender
        If (input <> 0) Then

            btnEqual.PerformClick()
            operation = btn.Text
            input = Integer.Parse(display.Text)
            expression = True
            lblEquation.Text = input & " " & operation

        ElseIf (display.Text.Contains("(")) Then
            operation = btn.Text
            input = Integer.Parse(display.Text.Substring(1, 1))
            expression = True
            lblEquation.Text = input & " " & operation

        Else
            operation = btn.Text
            input = Integer.Parse(display.Text)
            expression = True
            lblEquation.Text = input & " " & operation
        End If

        q = lblEquation.Text

    End Sub

    Private Sub btnBackSpace_Click(sender As Object, e As EventArgs) Handles btnBackSpace.Click
        TreeCat.Visible = False

        If (display.Text.Length > 0) Then
            display.Text = display.Text.Remove(display.Text.Length - 1, 1)
        End If

        If (display.Text = "") Then
            display.Text = 0
        End If
    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TreeCat.Visible = False
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        TreeCat.Visible = True
    End Sub



    Private Sub CloseBracket(sender As Object, e As EventArgs) Handles R_Par.Click

        Dim btn As Button = sender
        If (input <> 0) Then

            btnEqual.PerformClick()
            expression = True
            operation = btn.Text
            lblEquation.Text = input & " " & operation
        Else
            operation = btn.Text
            input = Integer.Parse(display.Text.Substring(1, 1))
            expression = True
            lblEquation.Text = input & " " & operation
        End If

    End Sub

    Private Sub OpenFile_Click(sender As Object, e As EventArgs) Handles OpenFile.Click
        Dim myprocess As Process
        myprocess = Process.Start("calculator.txt")
    End Sub

    Private Sub openBracket(sender As Object, e As EventArgs) Handles L_Par.Click
        Dim btn As Button = sender
        display.Text = btn.Text
    End Sub

    Private Sub btnEqual_Click(sender As Object, e As EventArgs) Handles btnEqual.Click
        TreeCat.Visible = False
        secondnum = display.Text
        lblEquation.Text = ""

        Select Case operation
            Case "+"
                display.Text = (input + Integer.Parse(display.Text)).ToString()
            Case "-"
                display.Text = (input - Integer.Parse(display.Text)).ToString()
            Case "*"
                display.Text = (input * Integer.Parse(display.Text)).ToString()
            Case "/"
                display.Text = (input / Integer.Parse(display.Text)).ToString()
        End Select

        input = Integer.Parse(display.Text)
        operation = ""

        History.AppendText(q & "    " & secondnum & "  =  " & vbNewLine)
        History.AppendText(vbNewLine & vbTab & display.Text & vbNewLine)
        lblhistory.Text = ""

    End Sub


    Private Sub numberclick(sender As Object, e As EventArgs) Handles Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click, Button2.Click, Button10.Click, Button1.Click, Button11.Click
        Dim btn As Button = sender
        TreeCat.Visible = False
        If ((display.Text = "0") Or (expression)) Then
            display.Clear()
            display.Text = btn.Text
            expression = False
        ElseIf (btn.Text = ".") Then
            If (Not display.Text.Contains(".")) Then
                display.Text = display.Text + btn.Text
            End If
        Else
            display.Text = display.Text + btn.Text
        End If

    End Sub
End Class
