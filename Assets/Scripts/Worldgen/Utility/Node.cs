using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

public abstract class Node : INamed, IPositioned, IUid
{
    public string type;

    public string Name { get; set; }
    public Vector3 Position { get; set; }

    private Uid uid;
    public Uid Uid { get => uid; private set => uid = new Uid(typeof(This).ToString(), Name);}

    protected Node(Vector3 position)
    {
        type = GetType().Name;

        Name = $"{position}";
        Position = position;
    }

    public override string ToString()
    {
        return $"{type} Node at {Position}";
    }
}
