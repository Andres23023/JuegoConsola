using JuegoConsola;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Reflection.PortableExecutable;

//Ventana ventana = new Ventana(170,45,ConsoleColor.Black,new Point (5,5), new Point(165,40));
//Ventana ventana = new Ventana(120, 30, ConsoleColor.Black, new Point(5, 5), new Point(115, 25));
//ventana.DibujarMarco();
Ventana ventana;
Nave nave;
bool jugar = true;
bool bossFinal = false;
Enemigo enemigo1;
Enemigo enemigo2;
Enemigo enemigoBoss;

void Iniciar()
{
    ventana = new Ventana(120, 30, ConsoleColor.Black, new Point(5, 5), new Point(115, 25));
    //ventana = new Ventana(180, 90, ConsoleColor.Black, new Point(5, 5), new Point(175, 60));
    ventana.DibujarMarco();
    nave = new Nave(new Point(60, 20), ConsoleColor.White, ventana);
    nave.Dibujar();
    enemigo1 = new Enemigo(new Point(50,10),ConsoleColor.Cyan,ventana,TipoEnemigo.Normal,nave);
    enemigo1.Dibujar();
     enemigo2 = new Enemigo(new Point(20, 12), ConsoleColor.Red, ventana, TipoEnemigo.Normal,nave);
    enemigo2.Dibujar();
    enemigoBoss = new Enemigo(new Point(100, 10), ConsoleColor.Magenta, ventana, TipoEnemigo.Boss,nave);
    
    nave.Enemigos.Add(enemigo1);
    nave.Enemigos.Add(enemigo2);
    nave.Enemigos.Add(enemigoBoss);


}
void Game()
{
    while (jugar)
    {
        if(!enemigo1.Vivo && !enemigo2.Vivo && !bossFinal)
        {
            bossFinal = true;
            ventana.Peligro();
        }
        if (bossFinal)
        {
            enemigoBoss.Mover();
            enemigoBoss.Informacion(100);
        }
        else
        {
            enemigo1.Mover();
            enemigo1.Informacion(65);
            enemigo2.Mover();
            enemigo2.Informacion(83);
        }
        nave.Mover(1);
        nave.Disparar();
        //Thread.Sleep(50);
        if (nave.Vida <= 0)
        {
            jugar = false;
            nave.Muerte();
        }
        if (!enemigoBoss.Vivo)
            jugar = false;

    }
}
Iniciar();
Game();

//Console.ReadKey();
