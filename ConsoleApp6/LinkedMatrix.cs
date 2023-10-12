
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LinkedMatrix
{
    private static Node head;
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
        if (!currentNode.IsBlocked() && !currentNode.GetValue().Contains("[ X ]") && !currentNode.GetValue().Contains("[ Y ]"))
        {
            return currentNode;
        }

        return null; 
    }


    public static void InitializeGame() 
    {

        Map.SetRows(4);
        Map.SetColumns(4);
        CreateColumns();
    }

}




