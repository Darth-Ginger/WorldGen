using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;

/// <summary>
/// Represents an abstract graph structure with nodes of type T and their connections.
/// </summary>
/// <typeparam name="T">The type of nodes in the graph structure.</typeparam>
public abstract class GraphStructure<T> : IUid where T : IUid
{
    private Uid uid;
    public Uid Uid { get => uid; private set => uid = new Uid(typeof(T).ToString());}

    protected Dictionary<T, List<T>> adjacencyList;
    
    protected List<Uid> nodeUids;

    /// <summary>
    /// Initializes a new instance of the GraphStructure class with an empty adjacency list.
    /// </summary>
    protected GraphStructure()
    {
        adjacencyList = new Dictionary<T, List<T>>();
        nodeUids = new List<Uid>();
    }

    /// <summary>
    /// Adds a node to the graph structure if it does not already exist.
    /// </summary>
    /// <param name="node">The node to add.</param>
    public virtual void AddNode(T node)
    {
        if (!adjacencyList.ContainsKey(node))
        {
            adjacencyList[node] = new List<T>();
            nodeUids.Add(node.Uid);
        }
    }
    

    /// <summary>
    /// Removes a node from the graph structure along with its associated edges.
    /// </summary>
    /// <param name="node">The node to remove.</param>
    public virtual void RemoveNode(T node)
    {
        if (adjacencyList.ContainsKey(node))
        {
            // Remove all edges associated with the node
            adjacencyList.Remove(node);
            nodeUids.Remove(node.Uid);
            foreach (var entry in adjacencyList)
            {
                entry.Value.Remove(node);
            }
        }
    }

    /// <summary>
    /// Adds an edge between two nodes in the graph structure.
    /// </summary>
    /// <param name="from">The starting node.</param>
    /// <param name="to">The ending node.</param>
    public virtual void AddEdge(T from, T to)
    {
        if (adjacencyList.ContainsKey(from) && !adjacencyList[from].Contains(to))
        {
            adjacencyList[from].Add(to);
        }
    }

    /// <summary>
    /// Removes an edge between two nodes in the graph structure.
    /// </summary>
    /// <param name="from">The starting node.</param>
    /// <param name="to">The ending node.</param>
    public virtual void RemoveEdge(T from, T to)
    {
        if (adjacencyList.ContainsKey(from) && adjacencyList[from].Contains(to))
        {
            adjacencyList[from].Remove(to);
        }
    }

    /// <summary>
    /// Returns a string representation of the graph structure showing nodes and their neighbors.
    /// </summary>
    /// <returns>A string representing the graph structure.</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var node in adjacencyList)
        {
            sb.AppendLine($"Node {node.Key} -> Neighbors: {string.Join(", ", node.Value)}");
        }
        return sb.ToString();;
    }


#region Getters
    /// <summary>
    /// Gets the neighbors of a specific node in the graph structure.
    /// </summary>
    /// <param name="node">The node to get neighbors for.</param>
    /// <returns>An IEnumerable of neighbors for the node.</returns>
    public virtual IEnumerable<T> GetNeighbors(T node)
    {
        return adjacencyList.ContainsKey(node) ? adjacencyList[node] : new List<T>();
    }

    /// <summary>
    /// Gets a node from the graph structure based on its Uid.
    /// </summary>
    /// <param name="uid">The Uid of the node.</param>
    /// <returns>The node matching the Uid.</returns>
    public virtual T GetNodeByUid<TNode>(Uid uid) where TNode : IUid => (T)adjacencyList.Keys.Where(node => ((IUid)node).Uid == uid);

    /// <summary>
    /// Gets a node from the graph structure based on its name.
    /// </summary>
    /// <param name="name">The name of the node.</param>
    /// <returns>The node matching the name.</returns>
    public virtual T GetNodeByName<TNode>(string name) where TNode : INamed => (T)adjacencyList.Keys.Where(node => ((INamed)node).Name == name);

    /// <summary>
    /// Gets a node from the graph structure based on its position.
    /// </summary>
    /// <param name="position">The position of the node.</param>
    /// <returns>The node matching the position.</returns>
    public virtual T GetNodeByPosition<TNode>(Vector3 position) where TNode : IPositioned => (T)adjacencyList.Keys.Where(node => ((IPositioned)node).Position == position);
#endregion Getters

}
