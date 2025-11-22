using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Direction : MonoBehaviour
{
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, y - 0.1f, transform.position.z);
        transform.localRotation = Quaternion.Euler(-90, 0, PlayerPrefs.GetFloat("Angle") - 90);
        Debug.Log("Angle Set To: " + PlayerPrefs.GetFloat("Angle"));
    }
}
