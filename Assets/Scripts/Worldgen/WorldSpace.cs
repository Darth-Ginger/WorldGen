using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpace 
{
    private List<World> worlds;

    public WorldSpace()
    {
        worlds = new List<World>();
    }

    public void AddWorld(World newWorld)
    {
        worlds.Add(newWorld);
    }

    public IEnumerable<World> GetWorlds()
    {
        return worlds;
    } 
}
