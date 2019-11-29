using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Transform startPosition;
    public LayerMask wallMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public float distance;

    Node[,] grid;
    public List<Node> finalPath;

    float nodeDiameter;
    int gridSizeX;
    int gridSizeY;

    public float timeToWait;


    private void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);

        StartCoroutine(WaitForLD(timeToWait));
    }

    IEnumerator WaitForLD(float timer)
    {
        yield return new WaitForSeconds(timer);
        CreateGrid();
    }

    void CreateGrid()  // crée la grille en vérifiant si mur ou pas
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector3 bottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.up * gridWorldSize.y / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = bottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.up * (y * nodeDiameter + nodeRadius);
                Vector2 worldPoint2d = new Vector2(worldPoint.x, worldPoint.y);

                bool wall = true; // booléen inversé

                if (Physics.CheckSphere(worldPoint, nodeRadius, wallMask))
                {
                    wall = false;
                }

                else if (Physics2D.OverlapCircle(worldPoint2d, nodeRadius, wallMask))
                {
                    wall = false;
                }

                grid[x, y] = new Node(wall, worldPoint, x, y);
            }
        }
    }

    public Node NodeFromWorldPosition(Vector3 a_worldPosition)
    {
        float xpoint = ((a_worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x);
        float ypoint = ((a_worldPosition.y + gridWorldSize.y / 2) / gridWorldSize.y);

        xpoint = Mathf.Clamp01(xpoint);
        ypoint = Mathf.Clamp01(ypoint);

        int x = Mathf.RoundToInt((gridSizeX - 1) * xpoint);
        int y = Mathf.RoundToInt((gridSizeY - 1) * ypoint);

        return grid[x, y];
    }

    public List<Node> GetNeighboringNodes(Node a_node)
    {
        List<Node> neighboringNodes = new List<Node>();
        int xCheck;
        int yCheck;

        //vérification de la tuile a droite
        xCheck = a_node.gridX + 1;
        yCheck = a_node.gridY;

        if (xCheck >= 0 && xCheck < gridSizeY)
        {
            if(yCheck >= 0 && yCheck < gridSizeY)
            {
                neighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //vérification de la tuile a gauche
        xCheck = a_node.gridX - 1;
        yCheck = a_node.gridY;

        if (xCheck >= 0 && xCheck < gridSizeY)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                neighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //vérification de la tuile en haut
        xCheck = a_node.gridX;
        yCheck = a_node.gridY + 1;

        if (xCheck >= 0 && xCheck < gridSizeY)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                neighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //vérification de la tuile en bas
        xCheck = a_node.gridX;
        yCheck = a_node.gridY - 1;

        if (xCheck >= 0 && xCheck < gridSizeY)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                neighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        return neighboringNodes;
    }

    private void OnDrawGizmos() // dessine la grille avec les murs en jaune, le sol en blanc et le chemin en rouge
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, 1));

        if (grid != null)
        {
            foreach (Node node in grid)
            {
                if (node.isWall)
                {
                    Gizmos.color = Color.yellow;
                }
                else
                {
                    Gizmos.color = Color.white;
                }

                if (finalPath != null)
                {
                    if (finalPath.Contains(node))//If the current node is in the final path
                    {
                        Gizmos.color = Color.red;
                    }
                }

                Gizmos.DrawCube(node.pos, Vector3.one * (nodeDiameter - distance));
            }
        }
    }
}
