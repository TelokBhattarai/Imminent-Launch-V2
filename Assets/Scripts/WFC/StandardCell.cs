using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

// This represents the definition of each type of "Cell Value" with
// its valid possible neighbors.  This will be used to build the 
// Cell Pallette

// The Pallette with use a dictionary with the "id" as the key of each
// neighbor of the StandardCell

public class StandardCell : MonoBehaviour
{
        public List<string> upNeighbors = new List<string>();
        public List<string> rightNeighbors = new List<string>();
        public List<string> downNeighbors = new List<string>();
        public List<string> leftNeighbors = new List<string>();

        public string id = "NoId";  // This is the name of the StandardCell.  
        // public string id = "";         // This is the value that is used for "keys" of allowed neigbors

        public StandardCell() { id = "NotSet"; }
        // public StandardCell() { id = "blank.jpg"; }
        public StandardCell(string cellId) { id = cellId; }

    }
