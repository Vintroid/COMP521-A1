using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanyonNode 
{
    public GameObject stone;

    // To see if it will be part of the paths or not
    public bool activated = false;

    // This node will break when stepped on.
    public bool broken;

    // Position on grid.
    public int positionX;
    public int positionY;

}
