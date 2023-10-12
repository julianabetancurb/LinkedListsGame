public class Program
{
    public static void Main()
    {

        Console.WriteLine("Bienvenido a Quoridor.");
        LinkedMatrix.InitializeGame();

        Player playerX = new Player(LinkedMatrix.GetInitialPositionForPlayerX(), "X");
        Player playerY = new Player(LinkedMatrix.GetInitialPositionForPlayerY(), "Y");
        LinkedMatrix.PrintMap();
        bool gameOver = false;

        while (!gameOver)
        {
            Console.WriteLine("-------------TURNO JUGADOR X-------------");
            Console.WriteLine("Qué desea hacer? Moverse o bloquear [1/2]");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Elija su dirección. arriba, abajo, izquierda, derecha [1/2/3/4]");
                    int mover = int.Parse(Console.ReadLine());
                    if (mover == 1)
                    {
                        playerX.MoveUp();
                        
                    }
                    if (mover == 2)
                    {
                        playerX.MoveDown();
                    }
                    if (mover == 3)
                    {
                        playerX.MoveLeft();
                    }
                    if (mover == 4)
                    {
                        playerX.MoveRight();
                    }
                  
                    LinkedMatrix.PrintMap();
                    if (playerX.XHasWon())
                    {
                        Console.WriteLine("¡Jugador X ha ganado!");
                        gameOver = true;
                        break;
                    }
                    
                    break;
                case 2:
                    Console.WriteLine("Tenga en cuenta la fila y columna de la celda a bloquear.");
                    Console.WriteLine("Ingrese la fila:");
                    int fila = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese la columna:");
                    int columna = int.Parse(Console.ReadLine());
                    playerX.BlockNode(LinkedMatrix.GetNodeToBlock(fila, columna));
                    LinkedMatrix.PrintMap();

                    break;
            }
            Console.WriteLine("-------------TURNO JUGADOR Y-------------");
            Console.WriteLine("Qué desea hacer? Moverse o bloquear [1/2]");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.WriteLine("Elija su dirección.  arriba, abajo, izquierda, derecha  [1/2/3/4]");
                    int mover = int.Parse(Console.ReadLine());
                    if (mover == 1)
                    {
                        playerY.MoveUp(); 
                    }
                    if (mover == 2)

                    {
                        playerY.MoveDown();
                        
                    }
                    if (mover == 3)
                    {
                        playerY.MoveLeft();
                    }
                    if (mover == 4)
                    {
                        playerY.MoveRight();
                    }
       
                    LinkedMatrix.PrintMap();

                    if (playerY.YHasWon())
                    {
                        Console.WriteLine("¡Jugador Y ha ganado!");
                        gameOver = true;
                        break;
                    }
    

                    break;

                case 2:
                    Console.WriteLine("Tenga en cuenta la fila y columna de la celda a bloquear.");
                    Console.WriteLine("Ingrese la fila:");
                    int row = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese la columna:");
                    int column = int.Parse(Console.ReadLine());
                    playerY.BlockNode(LinkedMatrix.GetNodeToBlock(row, column));
                    LinkedMatrix.PrintMap();

                    break;
            }
        }

       



    }

}