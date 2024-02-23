using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите данные в формате: белая_фигура x1y1 черная_фигура x2y2 x3y3");
        string? input = Console.ReadLine();
        string[] data = input.Split(' ');
        try
        {

            // Парсинг данных
            string whitePiece = data[0];
            int x1WhiteFigure = int.Parse(data[1][1].ToString());
            int y1WhiteFigure = CharToInt(data[1][0]);
            int x2BlackFigure = int.Parse(data[3][1].ToString());
            int y2BlackFigure = CharToInt(data[3][0]);
            int x3EndPoint = int.Parse(data[4][1].ToString());
            int y3EndPoint = CharToInt(data[4][0]);

            // Проверка возможности хода
            bool canMove = CanWhitePieceMove(whitePiece, x1WhiteFigure, y1WhiteFigure, x2BlackFigure, y2BlackFigure, x3EndPoint, y3EndPoint);

            // Вывод результата
            if (canMove)
                Console.WriteLine("Белая фигура может дойти до заданной точки без попадания под удар черной фигуры.");
            else
                Console.WriteLine("Белая фигура не может дойти до заданной точки без попадания под удар черной фигуры.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Вы ввели неверные значения");
        }

        static int CharToInt(char c)
        {
            return (int)(c - 'a' + 1);
        }

        static bool CanWhitePieceMove(string whitePiece, int x1WhiteFigure, int y1WhiteFigure, int x2BlackFigure, int y2BlackFigure, int x3EndPoint, int y3EndPoint)
        {
            switch (whitePiece.ToLower())
            {
                case "ладья":
                    return CanRookMove(x1WhiteFigure, y1WhiteFigure, x2BlackFigure, y2BlackFigure, x3EndPoint, y3EndPoint);
                case "конь":
                    return CanKnightMove(x1WhiteFigure, y1WhiteFigure, x2BlackFigure, y2BlackFigure, x3EndPoint, y3EndPoint);
                case "слон":
                    return CanBishopMove(x1WhiteFigure, y1WhiteFigure, x2BlackFigure, y2BlackFigure, x3EndPoint, y3EndPoint);
                case "ферзь":
                    return CanQueenMove(x1WhiteFigure, y1WhiteFigure, x2BlackFigure, y2BlackFigure, x3EndPoint, y3EndPoint);
                case "король":
                    return CanKingMove(x1WhiteFigure, y1WhiteFigure, x2BlackFigure, y2BlackFigure, x3EndPoint, y3EndPoint);
                default:
                    Console.WriteLine("Неизвестный тип фигуры.");
                    return false;
            }
        }

        static bool CanRookMove(int x1WhiteFigure, int y1WhiteFigure, int x2BlackFigure, int y2BlackFigure, int x3EndPoint, int y3EndPoint)
        {
            return x1WhiteFigure == x3EndPoint || y1WhiteFigure == y3EndPoint;
        }

        static bool CanKnightMove(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            int dx = Math.Abs(x3 - x1);
            int dy = Math.Abs(y3 - y1);
            return (dx == 1 && dy == 2) || (dx == 2 && dy == 1);
        }

        static bool CanBishopMove(int x1WhiteFigure, int y1WhiteFigure, int x2BlackFigure, int y2BlackFigure, int x3EndPoint, int y3EndPoint)
        {
            return Math.Abs(x3EndPoint - x1WhiteFigure) == Math.Abs(y3EndPoint - y1WhiteFigure);
        }

        static bool CanQueenMove(int x1WhiteFigure, int y1WhiteFigure, int x2BlackFigure, int y2BlackFigure, int x3EndPoint, int y3EndPoint)
        {
            return CanRookMove(x1WhiteFigure, y1WhiteFigure, x2BlackFigure, y2BlackFigure, x3EndPoint, y3EndPoint) || CanBishopMove(x1WhiteFigure, y1WhiteFigure, x2BlackFigure, y2BlackFigure, x3EndPoint, y3EndPoint);
        }

        static bool CanKingMove(int x1WhiteFigure, int y1WhiteFigure, int x2BlackFigure, int y2BlackFigure, int x3EndPoint, int y3EndPoint)
        {
            int dx = Math.Abs(x3EndPoint - x1WhiteFigure);
            int dy = Math.Abs(y3EndPoint - y1WhiteFigure);
            return dx <= 1 && dy <= 1;
        }
    }
}
