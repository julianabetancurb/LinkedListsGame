
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LinkedMatrix
{
    private static Node head;
    public static Node PlayerXPosition;
    public static Node PlayerYPosition;



        public static void PrintMap()
    {
        Node currentRow = head;
        string matrix = "";

        for (int i = 0; i < Map.GetRows(); i++)
        {
            Node currentColumn = currentRow;

            for (int j = 0; j < Map.GetColumns(); j++)
            {
                matrix += currentColumn.GetValue();
                currentColumn = currentColumn.GetRight();
            }
            Console.WriteLine(matrix);
            matrix = "";
            currentRow = currentRow.GetDown();
        }
    }

    public static void CreateColumns()
    {
        for (int column = 0; column < Map.GetColumns(); column++)
        {
            Node newnode = new Node();
            if (column == 0)
            {
                head = newnode;
            }
            else
            {
                head.SetLeft(newnode);
                newnode.SetRight(head);
                head = newnode;
            }
        }
        CreateRows();
    }

    public static void  CreateRows()
    {
        Node currentColumn = head;
        for (int i = 0; i < Map.GetColumns(); i++)
        {
            Node currentRow = currentColumn;
            for (int j = 0; j < Map.GetRows() - 1; j++)
            {
                Node newnode = new Node();
                currentRow.SetDown(newnode);
                newnode.SetUp(currentRow);
                currentRow = newnode;
            }
            currentColumn = currentColumn.GetRight();
        }
        Connect();
    }

    public static void Connect()
    {
        Node predecessorColumn = head;
        Node successorColumn = head.GetRight();
        for (int i = 0; i < Map.GetColumns() - 1; i++)
        {
            Node currentPredecessor = predecessorColumn;
            Node currentSuccessor = successorColumn;
            for (int j = 0; j < Map.GetRows() - 1; j++)
            {
                currentPredecessor = currentPredecessor.GetDown();
                currentSuccessor = currentSuccessor.GetDown();
                currentPredecessor.SetRight(currentSuccessor);
                currentSuccessor.SetLeft(currentPredecessor);
            }
            predecessorColumn = successorColumn;
            successorColumn = successorColumn.GetRight();
        }
       
    }
    public static Node GetInitialPositionForPlayerX()
    {
        
        Random random = new Random();
        int randomColumnForPlayerX = random.Next(Map.GetColumns());

        Node initialPositionX = head;
       
        for (int i = 0; i < randomColumnForPlayerX; i++)
        {
            if (initialPositionX.GetRight() != null)
            {
                initialPositionX = initialPositionX.GetRight();
            }
            else
            {
               
                break;
            }
        }
        UpdatePlayerXPosition(initialPositionX);
        initialPositionX.SetValue("[ X ]");
        
        return initialPositionX;
    }

    public static Node GetInitialPositionForPlayerY()
    {
        Random random = new Random();
        int randomColumnForPlayerY = random.Next(Map.GetColumns());

        Node initialPositionY = head;
        while (initialPositionY.GetDown() != null)
        {
            initialPositionY = initialPositionY.GetDown();
        }

  
        for (int i = 0; i < randomColumnForPlayerY; i++)
        {
            if (initialPositionY.GetRight() != null)
            {
                initialPositionY = initialPositionY.GetRight();
            }
            else
            {
              
                break;
            }
        }
        UpdatePlayerYPosition(initialPositionY);
        initialPositionY.SetValue("[ Y ]");
        return initialPositionY;
    }

    public static Node GetNodeToBlock(int rowIndex, int columnIndex)
    {
        Node currentNode = head;

     
        for (int i = 0; i < rowIndex; i++)
        {
            if (currentNode.GetDown() != null)
            {
                currentNode = currentNode.GetDown();
            }
            else
            {
             
                return null;
            }
        }

      
        for (int j = 0; j < columnIndex; j++)
        {
            if (currentNode.GetRight() != null)
            {
                currentNode = currentNode.GetRight();
            }
            else
            {
               
                return null;
            }
        }

        // Verifica si la casilla ya está bloqueada o ocupada por un jugador
        if (!currentNode.GetValue().Contains("[ X ]") && !currentNode.GetValue().Contains("[ Y ]"))
        {
            return currentNode;
        }

        return null; 
    }
    //CAMBIOS------------------------------------------------------------------------------------------
    public static void UpdatePlayerXPosition(Node newPosition)
    {
        Console.WriteLine("Se actualizo x");
        PlayerXPosition = newPosition;
    }

    public static void UpdatePlayerYPosition(Node newPosition)
    {
        Console.WriteLine("Se actualizo y");
        PlayerYPosition = newPosition;
    }
    public static bool BothPlayersHaveAvailablePaths()
    {
        return CanPlayerXWin() && CanPlayerYWin();
    }
    public static bool CanPlayerXWin()
    {
        // Encuentra el nodo inicial para Player X
        Node initialNode = PlayerXPosition;

        // Marca todos los nodos como no visitados
        ResetVisitedStatus();

        // Realiza una búsqueda en profundidad desde el nodo inicial
        if (DFS(initialNode, Map.GetRows() - 1))
        {
            Console.WriteLine("SIIII x");
            return true; // Player X puede ganar
        }
        Console.WriteLine("no x");
        return false; // No hay una ruta ganadora para Player X
    }

    public static bool CanPlayerYWin()
    {
        // Encuentra el nodo inicial para Player Y
        Node initialNode = PlayerYPosition;

        // Marca todos los nodos como no visitados
        ResetVisitedStatus();

        // Realiza una búsqueda en profundidad desde el nodo inicial
        if (DFS(initialNode, 0))
        {
            Console.WriteLine("SIIII Y");
            return true; // Player Y puede ganar
        }
        Console.WriteLine("no Y");
        return false; // No hay una ruta ganadora para Player Y
    }

    private static bool DFS(Node currentNode, int targetRow)
    {
        //CASO BASE
        if (currentNode == null || currentNode.IsBlocked || currentNode.IsVisited)
        {
            return false; // Casilla bloqueada, visitada o nula, no es una ruta válida.
        }

        if (currentNode.GetUp() == null && targetRow == 0)
        {
            return true; // Jugador Y ha alcanzado la fila objetivo.
        }

        if (currentNode.GetDown() == null && targetRow == Map.GetRows() - 1)
        {
            return true; // Jugador X ha alcanzado la fila objetivo.
        }

        currentNode.IsVisited = true; // Marcar el nodo como visitado.

        // Recursivamente intenta moverse en todas las direcciones posibles.
        bool canWin = DFS(currentNode.GetUp(), targetRow) ||
                      DFS(currentNode.GetDown(), targetRow) ||
                      DFS(currentNode.GetLeft(), targetRow) ||
                      DFS(currentNode.GetRight(), targetRow);

        return canWin;
    }



    private static void ResetVisitedStatus()
    {
        Node currentRow = head;
        for (int i = 0; i < Map.GetRows(); i++)
        {
            Node currentColumn = currentRow;
            for (int j = 0; j < Map.GetColumns(); j++)
            {
                currentColumn.IsVisited = false;
                currentColumn = currentColumn.GetRight();
            }
            currentRow = currentRow.GetDown();
        }
    }
    public static void InitializeGame() 
    {
        Console.WriteLine("Ingrese el tamaño del tablero:");
        int n = int.Parse(Console.ReadLine());
        Map.SetRows(n);
        Map.SetColumns(n);
        CreateColumns();
    }

}




