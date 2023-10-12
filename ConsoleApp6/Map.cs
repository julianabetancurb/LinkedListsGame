using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Map
{
    static int rows;
    static int columns;

    public static int GetRows()
    {
        return rows;
    }

    public static int GetColumns()
    {
        return columns;
    }

    public static void SetRows(int rowCount)
    {
        Map.rows = rowCount;
    }

    public static void SetColumns(int columnCount)
    {
        Map.columns = columnCount;
    }
}
