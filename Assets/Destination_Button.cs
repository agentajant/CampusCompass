using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Destination_Button : MonoBehaviour
{
    public Location_storage storage;
    public TMP_Dropdown dropdown;
    // Start is called before the first frame update
    public void OnClick()
    {
        Debug.Log(dropdown.value);
        PlayerPrefs.SetString("node1", storage.locations[dropdown.value].nodeA);
        PlayerPrefs.SetString("node2", storage.locations[dropdown.value].nodeB);
        Debug.Log("Destination Set To: " + PlayerPrefs.GetString("node1") + " and " + PlayerPrefs.GetString("node2"));
    }
}
