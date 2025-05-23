﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.VisualBasic;

namespace JuegoConsola
{

    public enum TipoBala
    {
        Normal,Especial,Enemigo
    }
    class Bala
    {
        public Point Posicion { get; set; }
        public ConsoleColor Color { get; set; }
        public TipoBala TipoBalaB { get; set; }
        public List<Point> PosicionesBala { get; set; }
        private DateTime _tiempo;
        public Bala(Point Posicion,ConsoleColor Color, TipoBala TipoBala)
        {
            this.Posicion = Posicion;
            this.Color = Color;
            this.TipoBalaB = TipoBala;
            PosicionesBala = new List<Point>();
            _tiempo = DateTime.Now;
        }
        public void Dibujar()
        {
            Console.ForegroundColor = Color;
            int x = Posicion.X;
            int y = Posicion.Y;

            PosicionesBala.Clear();

            switch (TipoBalaB)
            {
                case TipoBala.Normal:
                    Console.SetCursorPosition(x, y);
                    Console.Write("o");
                    PosicionesBala.Add(new Point(x, y));
                    break;
                case TipoBala.Especial:
                    Console.SetCursorPosition(x + 1, y);
                    Console.Write("_");
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write("( )");
                    Console.SetCursorPosition(x + 1, y + 2);
                    Console.Write("W");

                    PosicionesBala.Add(new Point(x + 1, y));
                    PosicionesBala.Add(new Point(x , y+1));
                    PosicionesBala.Add(new Point(x + 2, y+1));
                    PosicionesBala.Add(new Point(x + 1, y+2));

                    break;
                case TipoBala.Enemigo:
                    Console.SetCursorPosition(x, y);
                    Console.Write("█");
                    PosicionesBala.Add(new Point(x, y));
                    break;


            }
        }
        public void Borrar()
        {
            foreach(Point item in PosicionesBala)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(" ");
            }
        }
        public bool Mover(int velocidad, int limite,List<Enemigo> enemigos)
        {
            if (DateTime.Now > _tiempo.AddMilliseconds(30))
            {
                Borrar();
                switch (TipoBalaB)
                {
                    case TipoBala.Normal:
                        Posicion = new Point(Posicion.X, Posicion.Y - velocidad);
                        if (Posicion.Y <= limite)
                            return true;
                        foreach(Enemigo enemigo in enemigos)
                        {
                            foreach (Point posicionE in enemigo.PosicionesEnemigo)
                            {
                                if(posicionE.X == Posicion.X && posicionE.Y == Posicion.Y)
                                {
                                    enemigo.Vida -= 7;
                                    if (enemigo.Vida <= 0)
                                    {
                                        enemigo.Vivo = false;
                                        enemigo.Vida = 0;
                                        enemigo.Muerte();
                                    }
                                    return true;

                                }
                            }
                        }
                        break;
                    case TipoBala.Especial:
                        Posicion = new Point(Posicion.X, Posicion.Y - velocidad);
                        if (Posicion.Y <= limite)
                            return true;

                        foreach (Enemigo enemigo in enemigos)
                        {
                            foreach (Point posicionE in enemigo.PosicionesEnemigo)
                            {
                               foreach(Point posicionB in PosicionesBala)
                                {
                                    if(posicionE.X == posicionB.X && posicionE.Y == posicionB.Y)
                                    {
                                        enemigo.Vida -= 40;
                                        if (enemigo.Vida <= 0)
                                        {
                                            enemigo.Vivo = false;
                                            enemigo.Vida = 0;
                                            enemigo.Muerte();
                                        }
                                        return true;
                                    }
                                }
                            }
                        }

                        break;
                }
                Dibujar();
                _tiempo = DateTime.Now;
            }
            
            return false;

        }
        public bool Mover(int velocidad, int limite,Nave nave)
        {
            if (DateTime.Now > _tiempo.AddMilliseconds(30))
            {
                Borrar();

                Posicion = new Point(Posicion.X, Posicion.Y + velocidad);
                if (Posicion.Y >= limite)
                    return true;

                foreach(Point posicionN in nave.PosicionesNave)
                {
                    if (posicionN.X == Posicion.X && posicionN.Y == Posicion.Y)
                    {
                        nave.Vida -= 5;
                        return true;
                    }
                }

                Dibujar();
                _tiempo = DateTime.Now;
            }

            return false;

        }

    }
}
