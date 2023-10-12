using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player
{
    private Node position;
    private string symbol;

    public Player(Node startPosition, string symbol)
    {
        position = startPosition;
        this.symbol = symbol;
    }

    public Node GetPosition()
    {
        return position;
    }

    public void MoveUp()
    {
        Node nextNode = position.GetUp();

        if (nextNode != null && !nextNode.IsBlocked())
        {
            position.SetValue("[  ]"); 
            position = position.GetUp();
            position.SetValue("[ " + symbol + " ]"); 
        }
        else
        {
            Console.WriteLine("No te puedes mover hacia arriba");
        }
        
    }
    public void MoveDown()
    {
        Node nextNode = position.GetDown(); 

        if (nextNode != null && !nextNode.IsBlocked())
        {
            position.SetValue("[  ]"); 
            position = position.GetDown();
            position.SetValue("[ " + symbol + " ]"); 
        }
        else
        {
            Console.WriteLine("No puedes moverte hacia abajo");
        }
    }
    public void MoveLeft()
    {
        Node nextNode = position.GetLeft(); 

        if (nextNode != null && !nextNode.IsBlocked())
        {
            position.SetValue("[  ]");
            position = position.GetLeft(); 
            position.SetValue("[ " + symbol + " ]"); 
        }
        else { Console.WriteLine("No puedes moverte hacia la izquierda"); }
    }
    public void MoveRight()
    {
        Node nextNode = position.GetRight(); 

        if (nextNode != null && !nextNode.IsBlocked())
        {
            position.SetValue("[  ]"); 
            position = position.GetRight(); 
            position.SetValue("[ " + symbol + " ]"); 

        }
        else { Console.WriteLine("No puedes moverte hacia la derecha"); }
        
    }
    private bool CanBlockNode(Node nodeToBlock)
    {
        
        return !nodeToBlock.IsBlocked();
    }
    public void BlockNode(Node nodeToBlock)
    {
        
        if (CanBlockNode(nodeToBlock))
        {
           
            nodeToBlock.Block();
        }
    }

   
    public bool XHasWon()
    {
        // Para el Jugador X, verifica si ha llegado a la última fila
        return position.GetDown() == null;
    }
    public bool YHasWon()
    {
        // Para el Jugador X, verifica si ha llegado a la última fila
        return position.GetUp() == null;
    }




}