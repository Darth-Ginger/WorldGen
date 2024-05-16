using UnityEngine;

public interface INamed
{
    string Name { get; }
}
public interface IPositioned
{
    Vector3 Position { get; }
}

public interface IUid
{
    Uid Uid { get; } 

}
public interface IChunk
{
    int Space { get; }
    int Width { get; }
    int Height { get; }
    int Depth { get; } 
}