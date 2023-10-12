public class Program
{
    public static void Main()
    {
        LinkedMatrix.InitializeGame();

        Player playerX = new Player(LinkedMatrix.GetInitialPositionForPlayerX(), "X");
        Player playerY = new Player(LinkedMatrix.GetInitialPositionForPlayerY(), "Y");
        
        
        LinkedMatrix.PrintMap();

        Node nodeToBlockByX = LinkedMatrix.GetNodeToBlock(0, 1);
        if (nodeToBlockByX != null)
        {
            playerX.BlockNode(nodeToBlockByX);
        }
        else
        {
            Console.WriteLine("La casilla seleccionada ya está bloqueada.");
        }
        LinkedMatrix.PrintMap();


        playerX.MoveRight();
        LinkedMatrix.PrintMap();
    }
}