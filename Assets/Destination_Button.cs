using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Destination_Button : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    // Start is called before the first frame update
    public void OnClick()
    {
        Debug.Log(dropdown.value);
    }
}
