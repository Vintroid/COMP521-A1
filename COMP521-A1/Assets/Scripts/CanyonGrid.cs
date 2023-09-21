using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CanyonGrid : MonoBehaviour
{
    // The grid will be an array of nodes
    CanyonNode[,] grid;

    // Prefabs
    [SerializeField] GameObject stonePrefab;
    [SerializeField] GameObject badStonePrefab;
    [SerializeField] GameObject bridgePrefab;

    // Paths that will be activated
    CanyonNode[] truePath = { };
    CanyonNode[] falsePath = { };

    // Grid measurements
    [SerializeField] int width = 8;
    [SerializeField] int length = 10;
    [SerializeField] float cellSize = 10f;

    // Create grid on startup
    private void Awake()
    {
        GenerateCanyonGrid();
        GenerateRandomPaths();
    }

    private void GenerateCanyonGrid()
    {
        grid = new CanyonNode[width, length];

        for (int y = 0; y < length; y++)
        {
            for (int x = 0; x < width; x++)
            {
                grid[x, y] = new CanyonNode();
                grid[x,y].positionX= x;
                grid[x,y].positionY= y;
            }
        }
    }

    // We will generate two paths across the canyon that can't go backwards.
    private void GenerateRandomPaths()
    {
        // To keep track where we are in the grid.
        int pointerX = 3;
        int pointerY = 0;

        // To keep track where we are in the paths arrays
        int truePathPointer = 0;
        int falsePathPointer = 0;

        // We insert the starting in both paths
        CanyonNode[] copy = truePath;
        Array.Resize(ref copy, truePath.Length + 1);
        truePath = copy;
        truePath[truePathPointer] = grid[3, 0];
        grid[3, 0].activated = true;
        truePathPointer++;

        CanyonNode[] cpy = falsePath;
        Array.Resize(ref cpy, falsePath.Length + 1);
        falsePath = cpy;
        falsePath[falsePathPointer] = grid[3, 0];
        falsePathPointer++;

        // To keep track of a possible edge case where second path gets stuck.
        bool stuck = false;

        // First path generation, we want to stop when we path crosses canyon.
        while(pointerY != length-1)
        {
            // Get a random move on grid
            int rn = UnityEngine.Random.Range(0, 3);

            // Check if move is possible

            // Left Move
            if (rn == 0 && pointerX > 0 && isValidPath(pointerX - 1, pointerY, truePathPointer, falsePathPointer))
            {
                CanyonNode[] tmp = truePath;
                Array.Resize(ref tmp, truePath.Length + 1);
                truePath = tmp;
                truePath[truePathPointer] = grid[pointerX - 1, pointerY];
                grid[pointerX - 1, pointerY].activated = true;
                truePathPointer++;
                pointerX--;
 
            }

            // Up Move
            else if (rn == 1 && pointerY < length - 1 && isValidPath(pointerX, pointerY + 1, truePathPointer, falsePathPointer))
            {
                CanyonNode[] tmp = truePath;
                Array.Resize(ref tmp, truePath.Length + 1);
                truePath = tmp;
                truePath[truePathPointer] = grid[pointerX, pointerY + 1];
                grid[pointerX, pointerY + 1].activated = true;
                truePathPointer++;
                pointerY++;
                
            }

            //Right Move
            else if (rn == 2 && pointerX < width - 1 && isValidPath(pointerX + 1, pointerY, truePathPointer, falsePathPointer))
            {
                CanyonNode[] tmp = truePath;
                Array.Resize(ref tmp, truePath.Length + 1);
                truePath = tmp;
                truePath[truePathPointer] = grid[pointerX + 1, pointerY];
                grid[pointerX + 1, pointerY].activated = true;
                truePathPointer++;
                pointerX++;
                
            }
            
        }

        // Reset pointers
        pointerX = 3;
        pointerY = 0;

        // First path generation, we want to stop when we path crosses canyon.
        while (pointerY != length - 1 && !stuck)
        {
            // Get a random move on grid
            int rn = UnityEngine.Random.Range(0, 3);

            // Check if move is possible

            // Left Move
            if (rn == 0 && pointerX > 0 && isValidPath(pointerX - 1, pointerY, truePathPointer, falsePathPointer))
            {
                CanyonNode[] tmp = falsePath;
                Array.Resize(ref tmp, falsePath.Length + 1);
                falsePath = tmp;
                falsePath[falsePathPointer] = grid[pointerX - 1, pointerY];
                grid[pointerX - 1, pointerY].activated = true;
                falsePathPointer++;
                pointerX--;
                continue;
            }

            // Up Move
            if (rn == 1 && pointerY < length - 1 && isValidPath(pointerX, pointerY + 1, truePathPointer, falsePathPointer))
            {
                CanyonNode[] tmp = falsePath;
                Array.Resize(ref tmp, falsePath.Length + 1);
                falsePath = tmp;
                falsePath[falsePathPointer] = grid[pointerX, pointerY + 1];
                grid[pointerX, pointerY+1].activated = true;
                falsePathPointer++;
                pointerY++;
                continue;
            }

            // Right move
            if (rn == 2 && pointerX < width - 1 && isValidPath(pointerX + 1, pointerY, truePathPointer, falsePathPointer))
            {
                CanyonNode[] tmp = falsePath;
                Array.Resize(ref tmp, falsePath.Length + 1);
                falsePath = tmp;
                falsePath[falsePathPointer] = grid[pointerX + 1, pointerY];
                grid[pointerX+1,pointerY].activated= true;
                falsePathPointer++;
                pointerX++;
                continue;
            }
            
            if(isStuck(pointerX, pointerY))
            {
                stuck = true;
            }

        }

    }

    // Drawing gizmos for visualization
    private void OnDrawGizmos()
    {
        if (grid == null)
        {
            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < length; x++)
                {
                    // Checking where we are on the grid
                    Vector3 pos = GetMapPosition(x, y);
                    Gizmos.color = Color.white;
                    Gizmos.DrawCube(pos, Vector3.one);

                }
            }
        }
    }

    // Method to get position on map
    private Vector3 GetMapPosition(int x, int y)
    {
        // We have an offset based on where the canyon is positioned on map
        return new Vector3(-x * cellSize -45, 0f, y * cellSize -35);
    }


    // Checking if node is already in the current path
    public bool isValidPath(int x, int y, int truePathPointer, int falsePathPointer)
    {
        bool valid = true;
        
        // Iterating through path nodes to see if node is valid
        for(int i=0; i<truePathPointer; i++)
        {
            if (truePath[i].positionX == x && truePath[i].positionY == y)
            {
                valid = false;
            }
        }
     
        // Iterating through path nodes to see if node is valid
        for (int i = 0; i < falsePathPointer; i++)
        {
            if (falsePath[i].positionX == x && falsePath[i].positionY == y)
            {
                valid = false;
            }
        }

        return valid;
    }

    // Making the path of stones and bridges appear on the map
    public void InstantiatePaths()
    {

        // True path instantiation

        // Starts at i=1 since we have the starting point active already
        for(int i = 1; i< truePath.Length; i++)
        {
            // Instantiating bridge and rock of true path knowing previous point
            // Second vector is a known offset of the CanyonGrid
            Vector3 stonePos =  new Vector3(-truePath[i].positionY * cellSize, 0f, truePath[i].positionX * cellSize) + new Vector3(-45f, -0.6f, -35f);
            GameObject.Instantiate(stonePrefab, stonePos, stonePrefab.gameObject.transform.rotation);
            
            Vector3 bridgePos = new Vector3(-((truePath[i].positionY + truePath[i-1].positionY)/2f)*cellSize,0f,
                ((truePath[i].positionX + truePath[i-1].positionX)/2f)*cellSize)
                + new Vector3(-45f,-0.45f,-35f);
            GameObject.Instantiate(bridgePrefab, bridgePos, bridgePrefab.gameObject.transform.rotation);
        }

        // Last bridge to cross canyon
        Vector3 lastTrueBridge = new Vector3(-truePath[truePath.Length - 1].positionY * cellSize, 0f,
            truePath[truePath.Length - 1].positionX * cellSize) + new Vector3(-50f, -0.45f, -35f); // -5 to x coordinate so bridge can exit canyon.
        GameObject.Instantiate(bridgePrefab, lastTrueBridge, bridgePrefab.gameObject.transform.rotation);

        // False Path instantiation

        // Random stone to be destroyable
        int breakable = UnityEngine.Random.Range(1, falsePath.Length);

        // Starts at i=1 since we have the starting point active already
        for (int i = 1; i < falsePath.Length; i++)
        {
            // Instantiating bridge and rock of true path knowing previous point
            // Second vector is a known offset of the CanyonGrid
            Vector3 stonePos = new Vector3(-falsePath[i].positionY * cellSize, 0f, falsePath[i].positionX * cellSize) + new Vector3(-45f, -0.6f, -35f);
            
            // Instantiating a random stone as breakable rock
            if(i == breakable)
            {
                GameObject.Instantiate(badStonePrefab, stonePos, stonePrefab.gameObject.transform.rotation);
            }
            else
            {
                GameObject.Instantiate(stonePrefab, stonePos, stonePrefab.gameObject.transform.rotation);
            }

            Vector3 bridgePos = new Vector3(-((falsePath[i].positionY + falsePath[i - 1].positionY) / 2f) * cellSize, 0f,
                ((falsePath[i].positionX + falsePath[i - 1].positionX) / 2f) * cellSize)
                + new Vector3(-45f, -0.45f, -35f);
            GameObject.Instantiate(bridgePrefab, bridgePos, bridgePrefab.gameObject.transform.rotation);
        }

        // Last bridge to cross canyon
        Vector3 lastFalseBridge = new Vector3(-falsePath[falsePath.Length - 1].positionY * cellSize, 0f,
            falsePath[falsePath.Length - 1].positionX * cellSize) + new Vector3(-50f, -0.45f, -35f); // -5 to x coordinate so bridge can exit canyon.
        GameObject.Instantiate(bridgePrefab, lastFalseBridge, bridgePrefab.gameObject.transform.rotation);
    }

    // Checking if false path is stuck because of true path.
    bool isStuck(int x, int y)
    {
        bool stuck = false;

        // Checking left side
        if (x<=0 || grid[x - 1, y].activated)
        {
            // Checking up side
            if (y>=length-1 || grid[x, y + 1].activated)
            {
                // Checking right side
                if(x>=width-1 || grid[x + 1, y].activated)
                {
                    stuck = true;
                }
            }
        }
        return stuck;
    }
}
