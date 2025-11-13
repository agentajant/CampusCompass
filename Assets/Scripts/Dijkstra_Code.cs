using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra_Code : MonoBehaviour
{
    // Call this to compute a path
    public (List<string> pathing, float distance) FindShortestPath(
        Dictionary<string, Dictionary<string, float>> graph,
        string start, 
        string end)
    {
        // Distance from start to each node
        Dictionary<string, float> dist = new Dictionary<string, float>();
        // Previous node in best path
        Dictionary<string, string> prev = new Dictionary<string, string>();
        // All nodes that are not yet processed
        List<string> unvisited = new List<string>();

        // Initialize structures
        foreach (var node in graph.Keys)
        {
            dist[node] = Mathf.Infinity;
            prev[node] = null;
            unvisited.Add(node);
        }

        dist[start] = 0f;

        // Main Loop
        while (unvisited.Count > 0)
        {
            // Find unvisited node with smallest distance
            string current = null;
            float smallestDist = Mathf.Infinity;

            foreach (string node in unvisited)
            {
                if (dist[node] < smallestDist)
                {
                    smallestDist = dist[node];
                    current = node;
                }
            }

            // No reachable nodes left
            if (current == null)
                break;

            // If reached destination, stop early
            if (current == end)
                break;

            // Remove from unvisited
            unvisited.Remove(current);

            // Relax edges
            foreach (var neighbor in graph[current])
            {
                float newDist = dist[current] + neighbor.Value;

                if (newDist < dist[neighbor.Key])
                {
                    dist[neighbor.Key] = newDist;
                    prev[neighbor.Key] = current;
                }
            }
        }

        // Build path by backtracking from end
        List<string> path = new List<string>();
        string curr = end;

        while (curr != null)
        {
            path.Add(curr);
            curr = prev[curr];
        }

        path.Reverse();
        return (path, dist[end]);
    }
}