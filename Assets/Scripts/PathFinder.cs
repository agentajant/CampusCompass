using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    private Dijkstra_Code pathfinder;
    Dictionary<string, Dictionary<string, float>> graph = new Dictionary<string, Dictionary<string, float>>()
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
    Dictionary<string, Dictionary<string, float>> angles = new Dictionary<string, Dictionary<string, float>>()
        {
            { "A", new Dictionary<string, float>{{"B", 0}}},
            { "B", new Dictionary<string, float>{{"A", 180}, {"C", 0}, {"K", 270}} },
            { "C", new Dictionary<string, float>{{"B", 180}, {"D", 90}, {"I",0}} },
            { "D", new Dictionary<string, float>{{"C", 270}, {"H", 0}, {"E", 90}} },
            { "E", new Dictionary<string, float>{{"D", 270}, {"F", 180}, {"G", 0}} },
            { "F", new Dictionary<string, float>{{"E", 0}}},
            { "G", new Dictionary<string, float>{{"E", 180}, {"H", 270}, {"J", 87}} },
            { "H", new Dictionary<string, float>{{"D", 180}, {"G", 90}, {"I", 270}} },
            { "I", new Dictionary<string, float>{{"C", 180}, {"H", 90}, {"J", 0}, {"K", 315}} },
            { "J", new Dictionary<string, float>{{"G", 90}, {"I", 180}, {"K", 0}} },
            { "K", new Dictionary<string, float>{{"B", 225}, {"J", 0}, {"L", 135}, {"I", 315}} },
            { "L", new Dictionary<string, float>{{"K", 135}} }
        };
    
    public string finder(char startnode, char endnode)
    {
        pathfinder = gameObject.GetComponent<Dijkstra_Code>();

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

        var path = pathfinder.FindShortestPath(graph, startnode.ToString(), endnode.ToString());
        // Debug.Log("Shortest Path:");
        // foreach (string p in path.pathing)
        // {
        //     Debug.Log(p);
        // }
        // Debug.Log("Total Distance: " + path.distance);
        return path.distance;

    }

    public float Angle(char currentnode, char nextnode)
    {
        return angles[currentnode.ToString()][nextnode.ToString()];
    }
}
