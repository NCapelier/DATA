using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int gridX; // position x dans la grille
    public int gridY; // position Y dans la grille

    public bool isWall; 
    public Vector3 pos; // position réele de la node dans le monde

    public Node parent; // pour l'algo a*, permet de retracer le chemin à l'envers

    public int gCost; // cout pour se déplacer à la case suivante
    public int hCost; // distance jusqu'a l'objectif

    public int Fcost
    {
        get
        {
            return gCost + hCost;
        }
    }

    public Node(bool a_isWall, Vector3 a_pos, int a_gridX, int a_gridY) // constructeur de classe
    {
        isWall = a_isWall; // initialisation des valeurs
        pos = a_pos;
        gridX = a_gridX;
        gridY = a_gridY;
    }
}
