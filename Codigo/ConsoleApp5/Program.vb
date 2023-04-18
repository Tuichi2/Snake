Module Module1

    Dim x As Integer = 0
    Dim y As Integer = 0
    Dim foodX As Integer = 10
    Dim foodY As Integer = 10
    Dim width As Integer = 20
    Dim height As Integer = 20
    Dim snakeLength As Integer = 1
    Dim snakeX(50) As Integer
    Dim snakeY(50) As Integer
    Dim direction As Char = "R"
    Dim gameOver As Boolean = False

    Sub Main()
        Console.SetWindowSize(40, 22)
        Console.CursorVisible = False
        snakeX(0) = x
        snakeY(0) = y
        Draw()
        While Not gameOver
            Update()
            Draw()
            Threading.Thread.Sleep(100)
        End While
        Console.SetCursorPosition(0, 21)
        Console.WriteLine("GAME OVER")
        Console.ReadLine()
    End Sub

    Sub Update()
        If Console.KeyAvailable Then
            Dim key As ConsoleKeyInfo = Console.ReadKey(True)
            Select Case key.Key
                Case ConsoleKey.LeftArrow
                    If Not direction = "R" Then
                        direction = "L"
                    End If
                Case ConsoleKey.RightArrow
                    If Not direction = "L" Then
                        direction = "R"
                    End If
                Case ConsoleKey.UpArrow
                    If Not direction = "D" Then
                        direction = "U"
                    End If
                Case ConsoleKey.DownArrow
                    If Not direction = "U" Then
                        direction = "D"
                    End If
            End Select
        End If
        Select Case direction
            Case "L"
                x -= 1
            Case "R"
                x += 1
            Case "U"
                y -= 1
            Case "D"
                y += 1
        End Select
        If x < 0 Or x >= width Or y < 0 Or y >= height Then
            gameOver = True
        End If
        If x = foodX And y = foodY Then
            snakeLength += 1
            foodX = CInt(Math.Floor(Rnd() * width))
            foodY = CInt(Math.Floor(Rnd() * height))
        End If
        For i = snakeLength - 1 To 1 Step -1
            snakeX(i) = snakeX(i - 1)
            snakeY(i) = snakeY(i - 1)
        Next
        snakeX(0) = x
        snakeY(0) = y
        For i = 1 To snakeLength - 1
            If x = snakeX(i) And y = snakeY(i) Then
                gameOver = True
            End If
        Next
    End Sub

    Sub Draw()
        Console.Clear()
        Console.ForegroundColor = ConsoleColor.Red
        Console.SetCursorPosition(foodX, foodY)
        Console.Write("O")
        Console.ForegroundColor = ConsoleColor.Green
        For i = 0 To snakeLength - 1
            Console.SetCursorPosition(snakeX(i), snakeY(i))
            Console.Write("S")
        Next
    End Sub

End Module
