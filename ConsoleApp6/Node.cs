using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Node
{
    string value;
    Node left;
    Node right;
    Node up;
    Node down;
    bool isBlocked;
    bool isVisited;



    public Node(string value = "[  ]")
    {
        this.value = value;
        this.left = null;
        this.right = null;
        this.up = null;
        this.down = null;
        this.isBlocked = false;
    }

    public string GetValue()
    {
        if (IsBlocked)
        {
            return "[ # ]"; // Si la celda está bloqueada, mostrar [ # ]
        }
        return this.value; // De lo contrario, mostrar el valor actual
    }

    public void SetValue(string val)
    {
        this.value = val;
    }

    public Node GetLeft()
    {
        return this.left;
    }

    public void SetLeft(Node node)
    {
        this.left = node;
    }

    public Node GetRight()
    {
        return this.right;
    }

    public void SetRight(Node node)
    {
        this.right = node;
    }

    public Node GetUp()
    {
        return this.up;
    }

    public void SetUp(Node node)
    {
        this.up = node;
    }

    public Node GetDown()
    {
        return this.down;
    }

    public void SetDown(Node node)
    {
        this.down = node;
    }
    public void Block()
    {
        isBlocked = true;
        value = "[ # ]"; // Marcar la casilla como bloqueada
    }
    public void Unblock()
    {
        isBlocked = false; // Cambiar el estado de la celda a desbloqueada
                           // Restaurar el valor original de la celda (por ejemplo, "[  ]")
        value = "[  ]";
    }

    public bool IsBlocked
    {
        get { return isBlocked; }
        set { isBlocked = value; }
    }
    public bool IsVisited
    {
        get { return isVisited; }
        set { isVisited = value; }
    }
}
