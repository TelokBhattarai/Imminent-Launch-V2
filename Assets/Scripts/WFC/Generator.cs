using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Generator
{


    public Tilemap realTilemap;
    public List<Tile> realTiles;
    private Camera cam;
    // Key names for each tile in StandardPalette
    const string blankKey = "blankKey";
    const string upKey = "upKey";
    const string rightKey = "rightKey";
    const string downKey = "downKey";
    const string leftKey = "leftKey";

    public static int world_width = 10;
    public static int world_heigth = 10;

    public string[,] stringMap = new string[0, 0];

    public Cell[,] grid;
    public int[] gridValues;
    public UnityEngine.Grid gameGrid;
    public UnityEngine.Tilemaps.Tilemap tmap;

    public UnityEngine.Tilemaps.Tile blankImg;
    public UnityEngine.Tilemaps.Tile upImg;
    public UnityEngine.Tilemaps.Tile rightImg;
    public UnityEngine.Tilemaps.Tile downImg;
    public UnityEngine.Tilemaps.Tile leftImg;

    Dictionary<string, StandardCell> standardPallette = new Dictionary<string, StandardCell>();
    Dictionary<string, UnityEngine.Tilemaps.Tile> tilePair = new Dictionary<string, UnityEngine.Tilemaps.Tile>();
    string[] tiles = { "blank", " up  ", "right", "down ", "left " };

    bool DisplayDebug = false;

    public Generator(int xDimension, int yDimension)
    {
        world_width = xDimension;
        world_heigth = yDimension;
        stringMap = new string[world_width, world_heigth];
        grid = new Cell[world_width, world_heigth];
    }

    private void SetupStandardPallette()
    {
        StandardCell blankSC = new StandardCell(blankKey);
        StandardCell upSC = new StandardCell(upKey);
        StandardCell rightSC = new StandardCell(rightKey);
        StandardCell downSC = new StandardCell(downKey);
        StandardCell leftSC = new StandardCell(leftKey);

        // Blank - Neighbors
        blankSC.upNeighbors = new List<string>() { blankKey, upKey };
        blankSC.rightNeighbors = new List<string>() { blankKey, rightKey };
        blankSC.downNeighbors = new List<string>() { blankKey, downKey };
        blankSC.leftNeighbors = new List<string>() { blankKey, leftKey };

        // Up - Neighbors
        upSC.upNeighbors = new List<string>() { rightKey, leftKey, downKey };
        upSC.rightNeighbors = new List<string>() { leftKey, upKey, downKey };
        upSC.downNeighbors = new List<string>() { blankKey, downKey };
        upSC.leftNeighbors = new List<string>() { rightKey, upKey, downKey };

        // Right - Neighbors
        rightSC.upNeighbors = new List<string>() { rightKey, leftKey, downKey };
        rightSC.rightNeighbors = new List<string>() { leftKey, upKey, downKey };
        rightSC.downNeighbors = new List<string>() { rightKey, leftKey, upKey };
        rightSC.leftNeighbors = new List<string>() { blankKey, leftKey };

        // Down - Neighbors
        downSC.upNeighbors = new List<string>() { blankKey, upKey };
        downSC.rightNeighbors = new List<string>() { leftKey, upKey, downKey };
        downSC.downNeighbors = new List<string>() { rightKey, leftKey, upKey };
        downSC.leftNeighbors = new List<string>() { rightKey, upKey, downKey };

        // Left - Neighbors
        leftSC.upNeighbors = new List<string>() { rightKey, leftKey, downKey };
        leftSC.rightNeighbors = new List<string>() { blankKey, rightKey };
        leftSC.downNeighbors = new List<string>() { rightKey, leftKey, upKey };
        leftSC.leftNeighbors = new List<string>() { upKey, downKey, rightKey };

        // Add all the created cells to the standard pallette
        standardPallette.Add(blankKey, blankSC);
        tilePair.Add(blankKey, blankImg);
        standardPallette.Add(upKey, upSC);
        tilePair.Add(upKey, upImg);
        standardPallette.Add(rightKey, rightSC);
        tilePair.Add(rightKey, rightImg);
        standardPallette.Add(downKey, downSC);
        tilePair.Add(downKey, downImg);
        standardPallette.Add(leftKey, leftSC);
        tilePair.Add(leftKey, leftImg);
    }

    private void SetupInitialGrid()
    {
        // grid = new Cell[world_width, world_heigth];

        for (int i = 0; i < world_width; i++)
        {
            for (int j = 0; j < world_heigth; j++)
            {
                // Create new cell with current location in grid for convenience later
                Cell newCell = new Cell(i, j);
                grid[i, j] = newCell;
            }
        }
    }


    private Cell FindCellLowestEntropy(Cell[,] grid)
    {
        int lowestEntropy = 999999; // arbitrarially large value for start Entropy
        List<Cell> lowestCells = new List<Cell>();
        Cell chosenLowestCell = null;

        for (int j = 0; j < world_heigth; j++)
        {
            for (int i = 0; i < world_width; i++)
            {
                Cell tmpCell = grid[i, j];
                if (!tmpCell.collapsed)
                {
                    // If found a NEW "lowest value", begin a new list
                    // of cells with that lowest value.
                    //
                    // If found a cell matching current lowest entropy
                    // simply add it to the list of lowest entropy cells
                    int cellEnt = tmpCell.options.Count;
                    if (cellEnt < lowestEntropy)
                    {
                        lowestEntropy = cellEnt;
                        lowestCells.Clear();
                        lowestCells.Add(tmpCell);
                    }
                    else if (cellEnt == lowestEntropy)
                    {
                        lowestCells.Add(tmpCell);
                    }
                }
            }
        }

        // Pick random cell from list of all that have the lowest entropy value
        if (lowestCells.Count > 0)
        {
            int randCellIdx = new System.Random().Next(0, lowestCells.Count);
            chosenLowestCell = lowestCells[randCellIdx];
        }

        return chosenLowestCell;
    }

    private List<string> CombineValidNeighbors(Cell curRefCell, string direction)
    {
        List<string> combinedAllowedNeigbhors = new List<string>();
        int optCount = curRefCell.options.Count;

        foreach (string curOpt in curRefCell.options)
        {
            StandardCell tmpStandardCell = standardPallette[curOpt];

            if (direction == "up") combinedAllowedNeigbhors.AddRange(tmpStandardCell.upNeighbors);
            if (direction == "right") combinedAllowedNeigbhors.AddRange(tmpStandardCell.rightNeighbors);
            if (direction == "down") combinedAllowedNeigbhors.AddRange(tmpStandardCell.downNeighbors);
            if (direction == "left") combinedAllowedNeigbhors.AddRange(tmpStandardCell.leftNeighbors);
        }
        return combinedAllowedNeigbhors;
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////
    // Return true if the coordinates are INSIDE the grid and the cell has not
    // already been collapsed
    /////////////////////////////////////////////////////////////////////////////////////////////////
    private bool CanCellBePropagated(int x, int y)
    {
        bool result = false;
        if (IsValidCellLoc(x, y))
        {
            Cell curCell = grid[x, y];
            if (!curCell.collapsed) { result = true; }
        }
        return result;
    }


    /////////////////////////////////////////////////////////////////////////////////////////////////
    // Loop through all possible options for current neighbor cell
    // Delete any options in this neighbor cell that are not allowed
    // by the reference cell's Allowed Neighbors
    //
    // return true, if the current neighbor had options restricted during this process
    // This lets the calling method know this neighbor must be added to stack of 
    // cells that need to be considered for further propagating restrictions to its neighboring cells
    /////////////////////////////////////////////////////////////////////////////////////////////////
    public bool RemoveInvalidOptionsFromNeighbor(List<string> allowedNeighbors, int neighborX, int neighborY)
    {
        bool wasModifed = false;

        if (IsValidCellLoc(neighborX, neighborY))
        {
            Cell curNeighborCell = grid[neighborX, neighborY];

            int numOpt = curNeighborCell.options.Count;
            for (int lp = numOpt - 1; lp >= 0; lp--)
            {
                string posOpt = curNeighborCell.options[lp];
                if (!allowedNeighbors.Contains(posOpt))
                {
                    wasModifed = true;
                    curNeighborCell.options.Remove(posOpt);
                }
            }
        }

        return wasModifed;
    }


    // Ensure coordinates are inside the grid
    public bool IsValidCellLoc(int x, int y)
    {
        bool result = false;
        if ((x >= 0 && x < world_width)
              && (y >= 0 && y < world_heigth))
        {
            result = true;
        }

        return result;
    }

    ////////////////////////////////////////////////////////
    ///  Helper Methods
    ////////////////////////////////////////////////////////

    public void DumpStackNames(Stack<Cell> stack)
    {
        // A stack can be enumerated without disturbing its contents.
        Console.WriteLine(" ");
        Console.WriteLine("-----------------");
        Console.WriteLine(" Current Stack ");
        Console.WriteLine("-----------------");
        foreach (Cell cell in stack)
        {
            Console.WriteLine(DumpCellOptions(cell.options));
        }
        Console.WriteLine(" ");
        Console.WriteLine(" ");
    }

    public string DumpCellOptions(List<string> options)
    {
        string results = "";
        foreach (string opt in options)
        {
            results += opt + "-";
        }
        return results;
    }


    public void DrawGrid()
    {
        // realTilemap.ClearAllTiles();
        for (int j = 0; j < world_heigth; j++)
        {
            String output = "";
            for (int i = 0; i < world_width; i++)
            {
                ///////////////////////////////////////////////////////////////////////////////
                // NOTE: For clarity on screen, we are ONLY to display first letter of ID
                ///////////////////////////////////////////////////////////////////////////////
                // http://www.unicode.org/charts/PDF/U2500.pdf
                Cell cell = grid[i, j];
                if (cell.collapsed == true)
                {
                    //int index = cell.options[0];
                    //output += tiles[index];
                    string opt = (cell.options[0]).Substring(0, 1);
                    string txt = "";
                    if (opt == "u")
                    {
                        txt = "┴";
                        // tmap.SetTile(new Vector3Int(i, j, -10), tilePair["upKey"]);
                    }
                    else if (opt == "r")
                    {
                        txt = "├";
                        // tmap.SetTile(new Vector3Int(i, j, -10), tilePair["rightKey"]);
                    }
                    else if (opt == "d")
                    {
                        txt = "┬";
                        // tmap.SetTile(new Vector3Int(i, j, -10), tilePair["downKey"]);
                    }
                    else
                    {
                        txt = "┤";
                        // tmap.SetTile(new Vector3Int(i, j, -10), tilePair["leftKey"]);
                    }

                    output += txt;
                    stringMap[i, j] = txt;
                }
                
                else
                {
                    output += "(";
                    // Draw all possible options of the cell
                    int numOpts = cell.options.Count;
                    for (int lp = 0; lp < numOpts; lp++)
                    {
                        string opt = (cell.options[lp]).Substring(0, 1);
                        output += opt;
                        if (lp < numOpts - 1) output += ":";
                    }
                    output += ")";
                    output += "|";
                }

            }

            System.Console.WriteLine(output);
        }
    }



    //////////////////////////////////////////////////////////////////////////////////////////
    // This will mark the specificy cell collapsed and pick a
    // random value from its remaining options.
    //
    // For convenience, this returns the collapsed Value to the caller
    //
    // NOTE: Cell is being passed by reference so changes are visible outside this function
    //////////////////////////////////////////////////////////////////////////////////////////
    private string CollapseCell(ref Cell cell)
    {
        string collapsedVal = "";

        // SAFEGUARD - Do NOT attempt to collapse already collapsed cell
        if (!cell.collapsed)
        {
            System.Random rnd = new System.Random();
            int numOptions = cell.options.Count;

            if (numOptions >= 1)
            {
                int randIndex = rnd.Next(0, numOptions);
                collapsedVal = cell.options[randIndex];
            }
            else  // ???  I think this represents a Failed situation -- defaulting to blank spot
                  //      I am not sure how better to address this 
            {
                collapsedVal = blankKey;
            }


            // Rebuild cell.options with ONLY a SINGLE value -- the collapsed value
            // We are keeping it as an array so all the code has the same datatype 
            // for the options at all times.  An options list with a SINGLE value
            // represents a COLLAPSED value
            cell.options.Clear();
            cell.options.Add(collapsedVal);
            cell.collapsed = true;
        }

        return collapsedVal;
    }


    //////////////////////////////////////////////////////////////////////////////////////////
    // For the given cell at the grid[curCellX, curCellY], process each neighbor cell
    // up, right, down, left.
    //
    // Remove from the options of a given neighbor, values that are NOT allowed by
    // this curCell -  which has just been fully collapsed -- to the posible neighbors
    // allowed by curCell
    //
    // This version shows ALL steps in this single method for algorithm readability
    //////////////////////////////////////////////////////////////////////////////////////////
    private void Propagate_Expanded(Cell collapsedCell)
    {
        // We will use a stack to hold the cells that need to be propagated
        // Add the current cell to the stack to start off
        Stack<Cell> cellsToAddress = new Stack<Cell>();
        cellsToAddress.Push(collapsedCell);

        // process all cells until the remaining stack is empty
        while (cellsToAddress.Count > 0)
        {
            Cell curRefCell = cellsToAddress.Pop();

            // Get location of current collapsed cell in the grid
            int curCellX = curRefCell.x;
            int curCellY = curRefCell.y;

            /////////////////////////////////////////////////////////////////////////////
            // Check each neighbor to see if their options need to be
            // limited based on the current options of this reference
            // Remove all options from neighborings cells that are not allowed by the 
            // StandardCell rules for the currect collapsed cell
            // If the neighbor was modified during this step, add them to the 
            // cells to address stack so that it will be processed in the next
            // round of propagation
            //
            // NOTE:  This CAN cause the current cell to get added back to the 
            //        stack of cells to be further restricted. This is correct
            //        and should eventually end naturally in this flow
            /////////////////////////////////////////////////////////////////////////////

            // Process UP neighbor
            if (CanCellBePropagated(curCellX, curCellY - 1))
            {
                Cell neighborCell = grid[curCellX, curCellY - 1];
                List<string> allowedNeigbhors = CombineValidNeighbors(curRefCell, "up");

                bool cellWasModified = RemoveInvalidOptionsFromNeighbor(allowedNeigbhors, curCellX, curCellY - 1);
                if (cellWasModified) { cellsToAddress.Push(neighborCell); }
            }

            // Process RIGHT neighbor
            if (CanCellBePropagated(curCellX + 1, curCellY))
            {
                Cell neighborCell = grid[curCellX + 1, curCellY];
                List<string> allowedNeigbhors = CombineValidNeighbors(curRefCell, "right");

                bool cellWasModified = RemoveInvalidOptionsFromNeighbor(allowedNeigbhors, curCellX + 1, curCellY);
                if (cellWasModified) { cellsToAddress.Push(neighborCell); }
            }

            // Process DOWN neighbor
            if (CanCellBePropagated(curCellX, curCellY + 1))
            {
                Cell neighborCell = grid[curCellX, curCellY + 1];
                List<string> allowedNeigbhors = CombineValidNeighbors(curRefCell, "down");

                bool cellWasModified = RemoveInvalidOptionsFromNeighbor(allowedNeigbhors, curCellX, curCellY + 1);
                if (cellWasModified) { cellsToAddress.Push(neighborCell); }
            }

            // Process LEFT neighbor
            if (CanCellBePropagated(curCellX - 1, curCellY))
            {
                Cell neighborCell = grid[curCellX - 1, curCellY];
                List<string> allowedNeigbhors = CombineValidNeighbors(curRefCell, "left");

                bool cellWasModified = RemoveInvalidOptionsFromNeighbor(allowedNeigbhors, curCellX - 1, curCellY);
                if (cellWasModified) { cellsToAddress.Push(neighborCell); }
            }

            // LOG: Dump current stack to see progress
            if (DisplayDebug)
            {
                DumpStackNames(cellsToAddress);
            }
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////
    // For the given cell at the grid[curCellX, curCellY], process each neighbor cell
    // up, right, down, left.
    //
    // Remove from the options of a given neighbor, values that are NOT allowed by
    // this curCell -  which has just been fully collapsed -- to the posible neighbors
    // allowed by curCell
    //
    // This version uses separate method to process each neighbor restriction'
    // 
    //////////////////////////////////////////////////////////////////////////////////////////
    private void Propagate_Condensed(Cell collapsedCell)
    {
        // We will use a stack to hold the cells that need to be propagated
        // Add the current cell to the stack to start off
        Stack<Cell> cellsToAddress = new Stack<Cell>();
        cellsToAddress.Push(collapsedCell);

        // process all cells until the remaining stack is empty
        while (cellsToAddress.Count > 0)
        {
            Cell curRefCell = cellsToAddress.Pop();

            // Get location of current reference cell in the grid
            int curCellX = curRefCell.x;
            int curCellY = curRefCell.y;

            /////////////////////////////////////////////////////////////////////////////
            // Check each neighbor to see if their options need to be
            // limited based on the current options of this reference
            // Remove all options from neighborings cells that are not allowed by the 
            // StandardCell rules for the currect collapsed cell
            // If the neighbor was modified during this step, add them to the 
            // cells to address stack so that it will be processed in the next
            // round of propagation
            //
            // NOTE:  This CAN cause the current cell to get added back to the 
            //        stack of cells to be further restricted. This is correct
            //        and should eventually end naturally in this flow
            /////////////////////////////////////////////////////////////////////////////

            ProcessNeighborRestrictions(cellsToAddress, curRefCell, curCellX, curCellY - 1, "up");
            ProcessNeighborRestrictions(cellsToAddress, curRefCell, curCellX + 1, curCellY, "right");
            ProcessNeighborRestrictions(cellsToAddress, curRefCell, curCellX, curCellY + 1, "down");
            ProcessNeighborRestrictions(cellsToAddress, curRefCell, curCellX - 1, curCellY, "left");

            // LOG: Dump current stack to see progress
            if (DisplayDebug)
            {
                DumpStackNames(cellsToAddress);
            }
        }
    }

    private void ProcessNeighborRestrictions(Stack<Cell> cellsToAddress, Cell curRefCell, int tmpX, int tmpY, string direction)
    {
        if (CanCellBePropagated(tmpX, tmpY))
        {
            Cell neighborCell = grid[tmpX, tmpY];
            List<string> allowedNeigbhors = CombineValidNeighbors(curRefCell, direction);

            bool cellWasModified = RemoveInvalidOptionsFromNeighbor(allowedNeigbhors, tmpX, tmpY);

            if (cellWasModified)
            {
                cellsToAddress.Push(neighborCell);
            }
        }
    }

    //////////////////////////////////////////////////////////////
    //
    //    Main WFC Algorithm Implemenation
    //
    // Perform the entire process to setup and execute the WFC
    // cycle for the pallette defined in SetupStandardPallette()
    //
    //////////////////////////////////////////////////////////////
    public void PerformWFC()
    {
        SetupStandardPallette();
        SetupInitialGrid();

        if (DisplayDebug)
        {
            System.Console.WriteLine("--------------");
            System.Console.WriteLine("Initial Grid");
            System.Console.WriteLine("--------------");
            System.Console.WriteLine("");
            DrawGrid();
        }

        bool moreToProcess = true;
        int lp = 0;
        while (moreToProcess)
        {
            if (DisplayDebug)
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("");
                System.Console.WriteLine("===============");
                System.Console.WriteLine(" Loop " + lp++);
                System.Console.WriteLine("===============");
                System.Console.WriteLine("");
            }

            Cell cellToCollapse = FindCellLowestEntropy(grid);
            moreToProcess = (cellToCollapse != null);

            if (moreToProcess)
            {
                string collapsedCellValue = CollapseCell(ref cellToCollapse);

                if (DisplayDebug)
                {
                    string msg = string.Format(" Collapse: {0} : {1}", cellToCollapse.x, cellToCollapse.y);
                    System.Console.WriteLine("");
                    System.Console.WriteLine("");
                    System.Console.WriteLine("--------------");
                    System.Console.WriteLine(msg);
                    System.Console.WriteLine("--------------");
                    System.Console.WriteLine("");
                    System.Console.WriteLine("--------------");
                    System.Console.WriteLine("After Collapse");
                    System.Console.WriteLine("--------------");
                    DrawGrid();
                }

                // Propagate the changes of this collapsed cell to its neighbors
                Propagate_Condensed(cellToCollapse);

                if (DisplayDebug)
                {
                    System.Console.WriteLine("");
                    System.Console.WriteLine("");
                    System.Console.WriteLine("----------------");
                    System.Console.WriteLine("After Propagate");
                    System.Console.WriteLine("----------------");
                    DrawGrid();
                }
            }
        }

        DrawGrid();
    }
}
