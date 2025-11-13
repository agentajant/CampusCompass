using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class options : MonoBehaviour
{
    public Location_storage locationStorage;
    public TMP_Dropdown locationDropdown;
    // Start is called before the first frame update
    void Start()
    {
        List<string> locationNames = new List<string>();
        foreach (LocationEntry entry in locationStorage.locations)
        {
            locationNames.Add(entry.locationName);
        }
        locationDropdown.ClearOptions();
        locationDropdown.AddOptions(locationNames);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
