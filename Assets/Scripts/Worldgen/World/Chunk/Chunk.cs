using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chunk : GraphStructure<Tile>, IChunk
{
    public int Space  { get; private set; }
    public int Width  { get; private set; }
    public int Height { get; private set; }
    public int Depth  { get; private set; }

    public Chunk(Vector3 dimenstions)   => new Chunk((int)dimenstions.x, (int)dimenstions.y, (int)dimenstions.z);
    public Chunk(Vector3Int dimensions) => new Chunk(dimensions.x, dimensions.y, dimensions.z);
    
    /// <summary>
    /// Initializes a new Chunk with the provided dimensions for width, height, and depth. 
    /// Calculates the total space based on the dimensions and sets the width, height, and depth accordingly.
    /// </summary>
    public Chunk(int width, int height, int depth)
    {
        Space = width * height * depth;
        Width = width;
        Height = height;
        Depth = depth;
    }


    public Tile GetTile(Vector3 position) => GetNodeByPosition<Tile>(position);
    public Tile GetTile(int x, int y, int z) => GetNodeByPosition<Tile>(new Vector3(x, y, z));
    public Tile GetTile(string name) => GetNodeByName<Tile>(name);
    public Tile GetTile(Uid uid) => GetNodeByUid<Tile>(uid);
    public void SetTile(Tile tile) => AddNode(tile);

}
