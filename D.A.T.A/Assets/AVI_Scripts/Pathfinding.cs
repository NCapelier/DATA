using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    Grid grid;

    private void Awake()
    {
        grid = GetComponent<Grid>();
    }

    public List<Node> FindPath( Vector3 a_startPosition, Vector3 a_target)
    {
        Node startNode = grid.NodeFromWorldPosition(a_startPosition);
        Node targetNode = grid.NodeFromWorldPosition(a_target);

        List<Node> openList = new List<Node>();
        HashSet<Node> closedList = new HashSet<Node>();

        List<Node> a_finalPath = new List<Node>();

        openList.Add(startNode);

        while(openList.Count > 0)
        {
            Node currentNode = openList[0];
            for (int i = 1; i < openList.Count; i++)
            {
                if (openList[i].Fcost < currentNode.Fcost || openList[i].Fcost == currentNode.Fcost && openList[i].hCost < currentNode.hCost)
                {
                    currentNode = openList[i];
                }
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            if (currentNode == targetNode)
            {
                foreach (Node nodef in closedList)
                {
                    // if closedList[nodef-2] en diagonalle et les 2 cases entre pas des murs alors delet closedlist[nodef-1]
                }
                a_finalPath = GetFinalPath(startNode, targetNode);
                return a_finalPath;
            }

            foreach (Node neighborNode in grid.GetNeighboringNodes(currentNode))
            {
                if (!neighborNode.isWall  || closedList.Contains(neighborNode))
                {
                    continue;
                }

                int moveCost = currentNode.gCost + GetManhattenDistance(currentNode, neighborNode);

                if(moveCost < neighborNode.Fcost || !openList.Contains(neighborNode))
                {
                    neighborNode.gCost = moveCost;
                    neighborNode.hCost = GetManhattenDistance(neighborNode, targetNode);
                    neighborNode.parent = currentNode;

                    if (!openList.Contains(neighborNode))
                    {
                        openList.Add(neighborNode);
                    }
                }
            }
        }
        return new List<Node>();
    }

    List<Node> GetFinalPath(Node a_startNode, Node a_endNode)
    {
        List<Node> finalPath = new List<Node>();
        Node currentNode = a_endNode;

        while (currentNode != a_startNode)
        {
            finalPath.Add(currentNode);
            currentNode = currentNode.parent;
        }

        finalPath.Reverse();

        grid.finalPath = finalPath;
        return finalPath;
    }

    int GetManhattenDistance(Node a_nodeA, Node a_nodeB)
    {
        int ix = Mathf.Abs(a_nodeA.gridX - a_nodeB.gridX);
        int iy = Mathf.Abs(a_nodeA.gridY - a_nodeB.gridY);

        return ix + iy;
    }
}
