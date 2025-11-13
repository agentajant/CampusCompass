using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LocationDatabase", menuName = "CampusCompass/LocationDatabase")]
public class Location_storage : ScriptableObject
{
    public List<LocationEntry> locations;
}

[System.Serializable]
public class LocationEntry
{
    public string locationName;
    public string nodeA;
    public string nodeB;
}