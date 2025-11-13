using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Compass : MonoBehaviour
{
    float true_north = 0f;
    float mag_north = 0f;
    float compass_accuracy = 0f;

    public TMP_Text tn, mn, ca;
    // Start is called before the first frame update
    void Start()
    {
        Input.location.Start();
        Input.compass.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        true_north = Input.compass.trueHeading;
        mag_north = Input.compass.magneticHeading;
        compass_accuracy = Input.compass.headingAccuracy;

        transform.localEulerAngles = new Vector3(0, 0, (float)true_north);

        tn.text = "True North: " + true_north.ToString("F2");
        mn.text = "Mag North: " + mag_north.ToString("F2");
        ca.text = "Accuracy: " + compass_accuracy.ToString("F2");
    }
}
