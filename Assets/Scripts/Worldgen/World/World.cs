using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : GraphStructure<Chunk>, IChunk
{
    public int AtmosphereLimit { get; set; } = 100;
    public int ElevationLimit  { get; set; } = 100;

    public int Space { get; private set; }

    public int Width { get; private set; }

    public int Height { get; private set; }

    public int Depth { get; private set; }

    public World(int width, int height)
    {
        Space = width * height
        Width = width;
        Height = height;
    
    }


    public Chunk GetChunk(string uid) => GetChunk(Uid.ToUid(uid));
    public Chunk GetChunk(Uid uid) => GetNodeByUid<Chunk>(uid);
    public IEnumerable<Chunk> GetChunks() => adjacencyList.Keys;
}
