using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : Node
{

    public float Elevation { get; set; }
    public string Type { get; set; } // More properties can be added later.

    public Tile(Vector3 position) : base(position) { }
    public Tile(Vector3 position, string type) : base(position) => Type = type;
}