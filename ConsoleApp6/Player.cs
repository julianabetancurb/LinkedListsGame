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
        Console.WriteLine("llego");
        Node nextNode = position.GetUp();

        if (nextNode != null && !nextNode.IsBlocked && !nextNode.GetValue().Contains("[ X ]") && !nextNode.GetValue().Contains("[ Y ]"))
        {
            Console.WriteLine("llego");
            position.SetValue("[  ]"); 
            position = position.GetUp();
            position.SetValue("[ " + symbol + " ]");

            if (symbol == "X")
            {
                
                LinkedMatrix.UpdatePlayerXPosition(position);
            }
            else if (symbol == "Y")
            {
                LinkedMatrix.UpdatePlayerYPosition(position);
            }
        }

        else
        {
            Console.WriteLine("No te puedes mover hacia arriba");
        }
        
    }
    public void MoveDown()
    {
        Node nextNode = position.GetDown();

        if (nextNode != null && !nextNode.IsBlocked && !nextNode.GetValue().Contains("[ X ]") && !nextNode.GetValue().Contains("[ Y ]"))
        {
            position.SetValue("[  ]"); 
            position = position.GetDown();
            position.SetValue("[ " + symbol + " ]");
            if (symbol == "X")
            {
                LinkedMatrix.UpdatePlayerXPosition(position);
            }
            else if (symbol == "Y")
            {
                LinkedMatrix.UpdatePlayerYPosition(position);
            }

        }
        else
        {
            Console.WriteLine("No puedes moverte hacia abajo");
        }
    }
    public void MoveLeft()
    {
        Node nextNode = position.GetLeft();

        if (nextNode != null && !nextNode.IsBlocked && !nextNode.GetValue().Contains("[ X ]") && !nextNode.GetValue().Contains("[ Y ]"))
        {
            position.SetValue("[  ]");
            position = position.GetLeft(); 
            position.SetValue("[ " + symbol + " ]");
            if (symbol == "X")
            {
                LinkedMatrix.UpdatePlayerXPosition(position);
            }
            else if (symbol == "Y")
            {
                LinkedMatrix.UpdatePlayerYPosition(position);
            }
        }
        else { Console.WriteLine("No puedes moverte hacia la izquierda"); }
    }
    public void MoveRight()
    {
        Node nextNode = position.GetRight();

        if (nextNode != null && !nextNode.IsBlocked && !nextNode.GetValue().Contains("[ X ]") && !nextNode.GetValue().Contains("[ Y ]"))
        {
            position.SetValue("[  ]"); 
            position = position.GetRight(); 
            position.SetValue("[ " + symbol + " ]");

            if (symbol == "X")
            {
                LinkedMatrix.UpdatePlayerXPosition(position);
            }
            else if (symbol == "Y")
            {
                LinkedMatrix.UpdatePlayerYPosition(position);
            }

        }
        else { Console.WriteLine("No puedes moverte hacia la derecha"); }
        
    }
    private bool CanBlockNode(Node nodeToBlock)
    {
        
        return !nodeToBlock.IsBlocked;
    }
    public void BlockNodes(Node nodeToBlock)
    {

        if (CanBlockNode(nodeToBlock))
        {

            nodeToBlock.Block();
        }
        else { Console.WriteLine("El nodo ya esta bloqueado"); }
    }
    public void BlockNode(Node nodeToBlock)
    {
        if (nodeToBlock == null || nodeToBlock.IsBlocked)
        {
            Console.WriteLine("La casilla seleccionada ya está bloqueada o no es válida para bloquear.");
            return;
        }

        // Marca la casilla temporalmente como bloqueada
        nodeToBlock.Block();

        // Verifica si todavía puedes ganar después de bloquear
        if (!LinkedMatrix.BothPlayersHaveAvailablePaths())
        {
            // El bloqueo no es válido; desbloquea la casilla
            nodeToBlock.Unblock();
            Console.WriteLine("El bloqueo no es válido, ya que afecta la ruta para ganar.");
        }
        else
        {
            Console.WriteLine("Casilla bloqueada con éxito.");
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