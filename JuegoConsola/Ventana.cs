using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoConsola
{
    class Ventana
    {
        public int Ancho { get; set; }
        public int Altura { get; set; }
        public ConsoleColor Color { get; set; }
        public Point LimiteSuperior { get; set; }
        public Point LimiteInferior { get; set; }

        public Ventana(int Ancho, int Altura,ConsoleColor Color,Point LimiteSuperior, Point LimiteInferior)
        {
            this.Ancho = Ancho;
            this.Altura = Altura;
            this.Color = Color;
            this.LimiteSuperior = LimiteSuperior;
            this.LimiteInferior = LimiteInferior;
            Init();
        }
        private void Init()
        {
            Console.SetBufferSize(Ancho, Altura);
            Console.SetWindowSize(Ancho, Altura);
            Console.CursorVisible = false;
            Console.Title = "Nave";
            Console.BackgroundColor = Color;
            Console.Clear();
        }
        public void DibujarMarco()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = LimiteSuperior.X; i<= LimiteInferior.X; i++)
            {
                Console.SetCursorPosition(i, LimiteSuperior.Y);
                Console.Write("═");
                Console.SetCursorPosition(i, LimiteInferior.Y);
                Console.Write("═");
            }
            for (int i = LimiteSuperior.Y; i <= LimiteInferior.Y; i++)
            {
                Console.SetCursorPosition(LimiteSuperior.X,i);
                Console.Write("║");
                Console.SetCursorPosition(LimiteInferior.X,i);
                Console.Write("║");
            }
            Console.SetCursorPosition(LimiteSuperior.X, LimiteSuperior.Y);
            Console.Write("╔");
            Console.SetCursorPosition(LimiteSuperior.X, LimiteInferior.Y);
            Console.Write("╚");
            Console.SetCursorPosition(LimiteInferior.X, LimiteSuperior.Y);
            Console.Write("╗");
            Console.SetCursorPosition(LimiteInferior.X, LimiteInferior.Y);
            Console.Write("╝");


        }
        public void Peligro()
        {
            Console.Clear();
            DibujarMarco();
            for (int i = 0; i < 6; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(LimiteInferior.X / 2 - 5, LimiteSuperior.Y / 2);
                Console.Write("PELIGRO!!");
                Thread.Sleep(200);
                Console.SetCursorPosition(LimiteInferior.X / 2 - 5, LimiteSuperior.Y / 2);
                Console.Write("            ");
                Thread.Sleep(200);

            }
        }
    }
}
