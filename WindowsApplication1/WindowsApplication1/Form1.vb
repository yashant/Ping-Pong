Public Class Form1
    Dim moveRight As Boolean
    Dim moveUp As Boolean
    Dim wPress As Boolean
    Dim sPress As Boolean
    Dim iPress As Boolean
    Dim kPress As Boolean
    Dim Score1 As Integer
    Dim Score2 As Integer
    Dim count As Integer = 1
    Dim difficulty As Integer = 5
    Dim compRectangleDifficulty As Integer = 300
    Dim changeServe As Boolean
    Dim serve2 As Boolean
    Dim serve1 As Boolean
    Dim gameon As Boolean = False
    Dim rectangleSpeed As Integer = 3


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        RectangleShape2Move()

        If count Mod 2 = 0 Then
            changeServe = True
        Else
            changeServe = False
        End If

        If wPress = True Then
            RectangleShape1.Top -= rectangleSpeed
        End If

        If sPress = True Then
            RectangleShape1.Top += rectangleSpeed
        End If
        If iPress = True Then
            RectangleShape2.Top -= rectangleSpeed + 1
        End If
        If kPress = True Then
            RectangleShape2.Top += rectangleSpeed + 1
        End If
        If moveRight = True Then
            OvalShape1.Left += difficulty
        Else
            OvalShape1.Left -= difficulty
        End If

        If moveUp = True Then
            OvalShape1.Top -= difficulty
        Else
            OvalShape1.Top += difficulty
        End If

        If OvalShape1.Left <= Me.ClientRectangle.Left Then
            Timer1.Enabled = False
            gameon = False
            Score2 += 1
            lblScore2.Text = Score2
            count += 1
            If Score1 < 5 And Score2 < 5 Then
                If changeServe = True Then
                    lblPlayer1.Visible = True
                Else
                    lblPlayer2.Visible = True
                End If
            Else
                IfWin()

            End If
        End If


        If OvalShape1.Left + OvalShape1.Width >= Me.ClientRectangle.Right Then
            Timer1.Enabled = False
            gameon = False
            Score1 += 1
            lblScore1.Text = Score1
            count += 1
            If Score1 < 5 And Score2 < 5 Then
                If changeServe = True Then
                    lblPlayer1.Visible = True
                Else
                    lblPlayer2.Visible = True
                End If
            Else
                IfWin()
            End If
        End If



        If OvalShape1.Left + OvalShape1.Width >= RectangleShape2.Left And OvalShape1.Top >= RectangleShape2.Top And OvalShape1.Top + OvalShape1.Height <= RectangleShape2.Top + RectangleShape2.Height Then
            moveRight = False

            'If OvalShape1.Top + OvalShape1.Height / 2 >= RectangleShape1.Top + RectangleShape1.Height / 2 Then
            '    moveUp = True
            'End If
            'If OvalShape1.Top + OvalShape1.Height / 2 < RectangleShape1.Top + RectangleShape1.Height / 2 Then
            '    moveUp = False
            'End If
            'If OvalShape1.Top + OvalShape1.Height / 2 >= RectangleShape2.Top + RectangleShape2.Height / 2 Then
            '    moveUp = False
            'End If
            'If OvalShape1.Top + OvalShape1.Height / 2 < RectangleShape2.Top + RectangleShape2.Height / 2 Then
            '    moveUp = True
            'End If
        End If

        If OvalShape1.Left <= RectangleShape1.Left + RectangleShape1.Width And OvalShape1.Top >= RectangleShape1.Top And OvalShape1.Top + OvalShape1.Height <= RectangleShape1.Top + RectangleShape1.Height Then
            moveRight = True
            'If OvalShape1.Top + OvalShape1.Height / 2 >= RectangleShape1.Top + RectangleShape1.Height / 2 Then
            '    moveUp = False
            'End If
            'If OvalShape1.Top + OvalShape1.Height / 2 < RectangleShape1.Top + RectangleShape1.Height / 2 Then
            '    moveUp = True
            'End If
            'If OvalShape1.Top + OvalShape1.Height / 2 >= RectangleShape2.Top + RectangleShape2.Height / 2 Then
            '    moveUp = False
            'End If
            'If OvalShape1.Top + OvalShape1.Height / 2 < RectangleShape2.Top + RectangleShape2.Height / 2 Then
            '    moveUp = True
            'End If
        End If

        If OvalShape1.Top <= Me.ClientRectangle.Top Then
            moveUp = False

        ElseIf OvalShape1.Top + OvalShape1.Height >= Me.ClientRectangle.Bottom Then
            moveUp = True
        Else

        End If
    End Sub


    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim moveUp1 As Boolean = True
        Dim moveUp2 As Boolean = True

        If RectangleShape1.Top <= Me.ClientRectangle.Top Then
            moveUp1 = False
            RectangleShape1.Top = Me.ClientRectangle.Top + 1
        ElseIf RectangleShape1.Top + RectangleShape1.Height >= Me.ClientRectangle.Bottom Then
            moveUp1 = False
            RectangleShape1.Top = Me.ClientRectangle.Bottom - (1 + RectangleShape1.Height)
            moveUp1 = True
        End If
        If RectangleShape2.Top <= Me.ClientRectangle.Top Then
            moveUp2 = False
            RectangleShape2.Top = Me.ClientRectangle.Top + 1
        ElseIf RectangleShape2.Top + RectangleShape2.Height >= Me.ClientRectangle.Bottom Then
            moveUp2 = False
            RectangleShape2.Top = Me.ClientRectangle.Bottom - (1 + RectangleShape2.Height)
            moveUp2 = True
        End If

        If e.KeyCode = Keys.W And moveUp1 <> False Then
            wPress = True
            sPress = False

        End If
        If e.KeyCode = Keys.S And moveUp1 <> False Then
            sPress = True
            wPress = False

        End If

        'If e.KeyCode = Keys.I Then
        '    iPress = True
        '    kPress = False

        'End If
        'If e.KeyCode = Keys.K Then
        '    kPress = True
        '    iPress = False

        'End If
        moveUp1 = True
    End Sub

    Private Sub lblStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblStart.Click
        lblStart.Enabled = False
        lblStart.Visible = False
        lblEasy.Enabled = False
        lblEasy.Visible = False
        Label1.Visible = False
        Label1.Enabled = False
        lblPlayer1.Visible = True
        OvalShape1.Top = 116
        OvalShape1.Left = 19
        wPress = False
        sPress = False
        iPress = False
        kPress = False
        RectangleShape1.Top = 94
        RectangleShape2.Left = 6

        RectangleShape2.Top = 84

        RectangleShape2.Left = 600
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.W Then
            wPress = False
        End If
        If e.KeyCode = Keys.S Then
            sPress = False
        End If
        'If e.KeyCode = Keys.I Then
        '    iPress = False
        'End If
        'If e.KeyCode = Keys.K Then
        '    kPress = False
        'End If

        If gameon = False Then
            If e.KeyCode = Keys.L And lblPlayer2.Visible = True Then
                serve2 = True
                lblPlayer2.Visible = False
                activateServe2()
                gameon = True
            End If
            If e.KeyCode = Keys.D And lblPlayer1.Visible = True Then
                serve1 = True
                lblPlayer1.Visible = False
                activateServe1()
                gameon = True
            End If
        End If
    End Sub

    Private Sub Form1_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lblEasy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEasy.Click
        compRectangleDifficulty = 300
        rectangleSpeed = 3
        difficulty = 5
        lblStart.Enabled = False
        lblStart.Visible = False
        lblEasy.Enabled = False
        lblEasy.Visible = False
        Label1.Visible = False
        Label1.Enabled = False
        lblPlayer1.Visible = True
        OvalShape1.Top = 116
        OvalShape1.Left = 19
        wPress = False
        sPress = False
        iPress = False
        kPress = False
        RectangleShape1.Top = 94
        RectangleShape2.Left = 6

        RectangleShape2.Top = 84

        RectangleShape2.Left = 600

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        compRectangleDifficulty = 300
        rectangleSpeed = 4
        difficulty = 8
        lblStart.Enabled = False
        lblStart.Visible = False
        lblEasy.Enabled = False
        lblEasy.Visible = False
        Label1.Visible = False
        Label1.Enabled = False
        lblPlayer1.Visible = True
        OvalShape1.Top = 116
        OvalShape1.Left = 19
        wPress = False
        sPress = False
        iPress = False
        kPress = False
        RectangleShape1.Top = 94
        RectangleShape2.Left = 6

        RectangleShape2.Top = 84

        RectangleShape2.Left = 600

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPlayer1.Click

        lblPlayer1.Visible = False
        activateServe1()

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPlayer2.Click
        lblPlayer2.Visible = False
        activateServe2()
    End Sub

    Private Sub activateServe1()
        Timer1.Enabled = True
        OvalShape1.Top = 116
        OvalShape1.Left = 19
        wPress = False
        sPress = False
        iPress = False
        kPress = False
        RectangleShape1.Top = 94
        RectangleShape2.Left = 6

        RectangleShape2.Top = 84

        RectangleShape2.Left = 600
    End Sub

    Private Sub activateServe2()
        Timer1.Enabled = True
        OvalShape1.Top = 106
        OvalShape1.Left = 583
        wPress = False
        sPress = False
        iPress = False
        kPress = False
        RectangleShape1.Top = 94
        RectangleShape2.Left = 6

        RectangleShape2.Top = 84

        RectangleShape2.Left = 600
    End Sub

    Private Sub IfWin()
        If Score1 = 5 Then
            Timer1.Enabled = False
            MessageBox.Show("Player 1 Wins")
            lblStart.Enabled = True
            lblStart.Visible = True
            lblEasy.Enabled = True
            lblEasy.Visible = True
            Label1.Visible = True
            Label1.Enabled = True
            Score1 = 0
            Score2 = 0
            count = 1
            lblScore1.Text = 0
            lblScore2.Text = 0
        ElseIf Score2 = 5 Then
            Timer1.Enabled = False
            MessageBox.Show("Player 2 Wins")
            lblStart.Enabled = True
            lblStart.Visible = True
            lblEasy.Enabled = True
            lblEasy.Visible = True
            Label1.Visible = True
            Label1.Enabled = True
            lblScore1.Text = 0
            lblScore2.Text = 0
            Score1 = 0
            Score2 = 0
            count = 1
        End If
    End Sub

    Private Sub RectangleShape2Move()

        If RectangleShape2.Left - OvalShape1.Location.X <= 300 And (OvalShape1.Top < RectangleShape2.Top + 20 Or OvalShape1.Bottom > RectangleShape2.Bottom - 20) Then
            If moveUp = True Then
                iPress = True
                kPress = False
            Else
                iPress = False
                kPress = True
            End If
        Else
            iPress = False
            kPress = False
        End If
    End Sub


End Class
