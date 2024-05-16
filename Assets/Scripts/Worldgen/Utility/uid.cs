using System;
using UnityEngine;

/// Represents a unique identifier with a type, name, and ID.
public class Uid
{
    /// Initializes a new Uid instance with the specified type and name.
    /// Args: type (string) - The type of the identifier, name (string) - The name of the identifier.
    /// Returns: A Uid instance with truncated type and name, and a unique ID.
    
    /// Initializes a new Uid instance with the specified type and a null name.
    /// Args: type (string) - The type of the identifier.
    /// Returns: A Uid instance with truncated type and a unique ID.
    
    /// Returns a string representation of the Uid in the format "type-id" or "type-name-id".
    /// Returns: A string representing the Uid.
    
    private string     type;
    private string     name      = null;
    private int        id        = 0;
    private static int maxLength = 6;

    /// <summary>
    /// Initializes a new Uid instance with the specified type and name.
    /// </summary>
    /// <param name="type">The type of the identifier.</param>
    /// <param name="name">The name of the identifier.</param>
    /// <returns>A Uid instance with truncated type and name, and a unique ID.</returns>
    public Uid(string type, string name)
    {
        this.type = type[..Math.Min(type.Length, maxLength)];
        this.name = name[..Math.Min(name.Length, maxLength)];
        id = System.Guid.NewGuid().GetHashCode();
    }

    // <summary>
    // Initializes a new Uid instance with the specified type.
    // </summary>
    // <param name="type">The type parameter for the Uid.</param>
    public Uid (string type)
    {
        this.type = type[..Math.Min(type.Length, maxLength)];
        id = System.Guid.NewGuid().GetHashCode();
    }

    public override string ToString()
    {
        return name == null ? $"{type}-{id}" : $"{type}-{name}-{id}";
    }

    public static Uid ToUid(string uid)
    {
        var regex = new System.Text.RegularExpressions.Regex(@"^([a-zA-Z0-9]{1," + maxLength + @"})(-([a-zA-Z0-9]{1," + maxLength + @"})-)?(\d+)$");

        if (!regex.IsMatch(uid))
        {
            throw new System.ArgumentException($"{uid} is not a valid Uid string. It should be in the format 'type-name-id' or 'type-id'");
        }


        return new Uid(uid);
    }

}


