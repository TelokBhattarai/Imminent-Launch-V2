using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class NewCell
{
    // Key names for each tile in StandardPalette
    //
    const string blankKey = "blankKey";
    const string roomKey = "roomKey";
    const string vertKey = "vertKey";
    const string horizKey = "horizKey";
    const string urcKey = "urcKey";
    const string ulcKey = "ulcKey";
    const string brcKey = "brcKey";
    const string blcKey = "blcKey";
    const string failedKey = "failedKey";

    public int x = -1;
    public int y = -1;

    public bool collapsed = false;

    public List<string> options = new List<string>() { blankKey, roomKey, vertKey, horizKey, urcKey, ulcKey, brcKey, blcKey };  // Total of eight options - 8 tiles

    public NewCell() { }
    public NewCell(int x, int y) { this.x = x; this.y = y; }

}