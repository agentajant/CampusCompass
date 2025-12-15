using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.ARFoundation;
public class Debug_texts : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public TMP_Text state;
    public TMP_Text image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        state.text = "AR Session State: " + ARSession.state.ToString();
    }
    void OnChanged(ARTrackedImagesChangedEventArgs e)
    {
        foreach (var trackedImage in e.added)
        {
            image.text = "Added: " + trackedImage.referenceImage.name;
        }
        foreach (var trackedImage in e.updated)
        {
            image.text = "Updated: " + trackedImage.referenceImage.name + " Tracking State: " + trackedImage.trackingState.ToString();
        }
        foreach (var trackedImage in e.removed)
        {
            image.text = "Removed: " + trackedImage.referenceImage.name;
        }
    }
}
