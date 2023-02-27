using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Cell
<<<<<<< HEAD
{
    // Key names for each tile in StandardPalette
    const string t = "top";
    const string b = "bottom";
    const string vh = "vertical";
    const string hh = "horizontal";
    const string tr = "topRight";
    const string tl = "topLeft";
    const string br = "bottomRight";
    const string bl = "bottomLeft";
    const string l = "left";
    const string r = "right";
    const string g = "ground";


    public int x = -1;
    public int y = -1;

    public bool collapsed = false;

    public List<string> options = new List<string>() { t, b, vh, hh, tl, tr, bl, br, l, r, g };  // Total of five options - 5 tiles

    public Cell() { }
    public Cell(int x, int y) { this.x = x; this.y = y; }

}
=======
{
        // Key names for each tile in StandardPalette
        //
        const string blankKey = "blankKey";
        const string upKey = "upKey";
        const string rightKey = "rightKey";
        const string downKey = "downKey";
        const string leftKey = "leftKey";

        public int x = -1;
        public int y = -1;

        public bool collapsed = false;

        public List<string> options = new List<string>(){ blankKey, upKey, rightKey, downKey, leftKey };  // Total of five options - 5 tiles

        public Cell() { }
        public Cell(int x, int y) { this.x = x; this.y = y; }

    }
>>>>>>> 9eb292b794f8a8253593078a02ee7798ace8a9a2
