﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Cell
{
        // Key names for each tile in StandardPalette
        //
        const string blankKey = "blankKey";
        const string upKey = "upKey";
        const string rightKey = "rightKey";
        const string downKey = "dowbKey";
        const string leftKey = "leftKey";

        public int x = -1;
        public int y = -1;

        public bool collapsed = false;

        public List<string> options = new List<string>(){ blankKey, upKey, rightKey, downKey, leftKey };  // Total of five options - 5 tiles

        public Cell() { }
        public Cell(int x, int y) { this.x = x; this.y = y; }

    }