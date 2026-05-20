using System;
using System.Collections.Generic;

namespace MyChessProj;

internal class Program
{
    static void Main(string[] args)
    {
        //glxavor ankyunacgcy #, mnacacy *
        int n = 8;
        char[,] matrix = new char[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j)
                {
                    matrix[i, j] = '#';
                }
                else
                {
                    matrix[i, j] = '*';
                }
            }
        }


        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }


        Console.WriteLine("\n=== NAVAKI EV DZIU ARDYUNQNER ===");

        Console.WriteLine($"Navaki qayly (1,2)-ic (1,5): {CanRookMove(1, 2, 1, 5)}");

        Console.WriteLine($"Dziu 1 qayly (4,4)-ic (5,7): {KnightMatrix(4, 5, 4, 7)}");

        Console.WriteLine($"Dziu nvazaguyn qaylery (1,1)-ic (8,8): {MinKnightMoves(1, 5, 8, 8)}");


        Console.WriteLine("\n=== PXHI ARDYUNQNER ===");

        int x1 = 2, y1 = 2;
        int x2 = 5, y2 = 5;
        int bx = 4, by = 4;

        bool canMove = CanBishopMove(x1, y1, x2, y2, bx, by);
        Console.WriteLine($"Karox e hasnel ketin: {canMove}");

        Console.WriteLine("\n Hnaravor qayleri tarberak:");
        Console.WriteLine("(2 = Skizb, 3 = Xochyndot, 1 = Qayler)");

        int[,] bBoard = CanBishopMov(x1, y1, bx, by);

        for (int i = 1; i <= 8; i++)
        {
            for (int j = 1; j <= 8; j++)
            {
                Console.Write(bBoard[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.ReadKey();
    }

    //navaky mi qaylov nshvac ket?
    public static bool CanRookMove(int x1, int y1, int x2, int y2)
    {
        if (x1 == x2 || y1 == y2)
        {
            return true;
        }

        return false;
    }


    //Dzu hnaravor qaylery
    static bool KnightMatrix(int x0, int x1, int y0, int y1)
    {
        if (Math.Abs(x0 - x1) * Math.Abs(y0 - y1) == 2)
            return true;
        else
            return false;
    }

    //Dzu hamar amenakarch chanaparhy depi trvac ket
    static int MinKnightMoves(int sx, int sy, int ex, int ey)
    {
        int[] dx = { 2, 2, -2, -2, 1, 1, -1, -1 };
        int[] dy = { 1, -1, 1, -1, 2, -2, 2, -2 };

        bool[,] visited = new bool[9, 9];

        Queue<(int x, int y, int steps)> q =
            new Queue<(int x, int y, int steps)>();

        q.Enqueue((sx, sy, 0));
        visited[sx, sy] = true;

        while (q.Count > 0)
        {
            var cur = q.Dequeue();

            if (cur.x == ex && cur.y == ey)
                return cur.steps;

            for (int i = 0; i < 8; i++)
            {
                int nx = cur.x + dx[i];
                int ny = cur.y + dy[i];

                if (nx >= 1 && nx <= 8 &&
                    ny >= 1 && ny <= 8 &&
                    !visited[nx, ny])
                {
                    visited[nx, ny] = true;
                    q.Enqueue((nx, ny, cur.steps + 1));
                }
            }
        }

        return -1;
    }

    //pixy mi qaylov nshvac ket
    static bool Karox_e_pixy_mi_qaylov_hasnel(int x1, int y1, int x2, int y2)
    {
        return Math.Abs(x1 - x2) == Math.Abs(y1 - y2);
    }

    //pixy mi qaylov nshvac ket erb ka xochyndot
    static bool CanBishopMove(int x1, int y1, int x2, int y2, int bx, int by)
    {
        if (Math.Abs(x1 - x2) != Math.Abs(y1 - y2))
            return false;

        int dx = (x2 > x1) ? 1 : -1;
        int dy = (y2 > y1) ? 1 : -1;

        int currentX = x1 + dx;
        int currentY = y1 + dy;

        while (true)
        {

            if (currentX == bx && currentY == by)
                return false;

            if (currentX == x2 && currentY == y2)
                break;

            currentX += dx;
            currentY += dy;
        }

        return true;
    }
    

    //pxi hnaravor qaylery taxtaki vra erb ka xochyndot
    static int[,] CanBishopMov(int x1, int y1, int bx, int by)
    {
        int[,] board = new int[9, 9];
        board[x1, y1] = 2;

        int[] dirX = { 1, -1, 1, -1 };
        int[] dirY = { 1, 1, -1, -1 };

        for (int i = 0; i < 4; i++)
        {
            int dx = dirX[i];
            int dy = dirY[i];


            int currentX = x1 + dx;
            int currentY = y1 + dy;


            while (currentX >= 1 && currentX <= 8 && currentY >= 1 && currentY <= 8)
            {

                if (currentX == bx && currentY == by)
                    break;

                board[currentX, currentY] = 1;
                currentX += dx;
                currentY += dy;
            }

            if (bx >= 1 && bx <= 8 && by >= 1 && by <= 8)
                board[bx, by] = 3;
        }

        return board;
    }
}