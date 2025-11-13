using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    private Dijkstra_Code pathfinder;
    public string finder(char startnode, char endnode)
    {
        pathfinder = gameObject.GetComponent<Dijkstra_Code>();

        var graph = new Dictionary<string, Dictionary<string, float>>()
        {
            { "A", new Dictionary<string, float>{{"B", 0.3f}}},
            { "B", new Dictionary<string, float>{{"A", 0.3f}, {"C", 0.2f}, {"K", 0.8f}} },
            { "C", new Dictionary<string, float>{{"B", 0.2f}, {"D", 0.1f}, {"I",0.5f}} },
            { "D", new Dictionary<string, float>{{"C", 0.1f}, {"H", 0.5f}, {"E", 0.2f}} },
            { "E", new Dictionary<string, float>{{"D", 0.2f}, {"F", 0.2f}, {"G", 0.5f}} },
            { "F", new Dictionary<string, float>{{"E", 0.2f}}},
            { "G", new Dictionary<string, float>{{"E", 0.5f}, {"H", 0.2f}, {"J", 0.7f}} },
            { "H", new Dictionary<string, float>{{"D", 0.5f}, {"G", 0.2f}, {"I", 0.1f}} },
            { "I", new Dictionary<string, float>{{"C", 0.5f}, {"H", 0.1f}, {"J", 0.2f}, {"K", 0.5f}} },
            { "J", new Dictionary<string, float>{{"G", 0.7f}, {"I", 0.2f}, {"K", 0.8f}} },
            { "K", new Dictionary<string, float>{{"B", 0.8f}, {"J", 0.8f}, {"L", 0.3f}, {"I", 0.5f}} },
            { "L", new Dictionary<string, float>{{"K", 0.3f}} }
        };

        var path = pathfinder.FindShortestPath(graph, startnode.ToString(), endnode.ToString());

        return path.pathing[1];
        // Debug.Log("Shortest Path:");
        // foreach (string p in path.pathing)
        // {
        //     Debug.Log(p);
        // }

        // Debug.Log("Total Distance: " + path.distance);
    }

    public float distance(char startnode, char endnode)
    {
        pathfinder = gameObject.GetComponent<Dijkstra_Code>();

        var graph = new Dictionary<string, Dictionary<string, float>>()
        {
            { "A", new Dictionary<string, float>{{"B", 0.3f}}},
            { "B", new Dictionary<string, float>{{"A", 0.3f}, {"C", 0.2f}, {"K", 0.8f}} },
            { "C", new Dictionary<string, float>{{"B", 0.2f}, {"D", 0.1f}, {"I",0.5f}} },
            { "D", new Dictionary<string, float>{{"C", 0.1f}, {"H", 0.5f}, {"E", 0.2f}} },
            { "E", new Dictionary<string, float>{{"D", 0.2f}, {"F", 0.2f}, {"G", 0.5f}} },
            { "F", new Dictionary<string, float>{{"E", 0.2f}}},
            { "G", new Dictionary<string, float>{{"E", 0.5f}, {"H", 0.2f}, {"J", 0.7f}} },
            { "H", new Dictionary<string, float>{{"D", 0.5f}, {"G", 0.2f}, {"I", 0.1f}} },
            { "I", new Dictionary<string, float>{{"C", 0.5f}, {"H", 0.1f}, {"J", 0.2f}, {"K", 0.5f}} },
            { "J", new Dictionary<string, float>{{"G", 0.7f}, {"I", 0.2f}, {"K", 0.8f}} },
            { "K", new Dictionary<string, float>{{"B", 0.8f}, {"J", 0.8f}, {"L", 0.3f}, {"I", 0.5f}} },
            { "L", new Dictionary<string, float>{{"K", 0.3f}} }
        };

        var path = pathfinder.FindShortestPath(graph, startnode.ToString(), endnode.ToString());

        return path.distance;
        // Debug.Log("Shortest Path:");
        // foreach (string p in path.pathing)
        // {
        //     Debug.Log(p);
        // }

        // Debug.Log("Total Distance: " + path.distance);
    }
}
