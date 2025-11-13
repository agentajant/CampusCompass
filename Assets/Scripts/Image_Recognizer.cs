using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Image_Recognizer : MonoBehaviour
{
    private ARTrackedImageManager arTrackedImageManager;
    public ARSession session;
    // Start is called before the first frame update
    void Awake()
    {
        arTrackedImageManager = GetComponent<ARTrackedImageManager>();
    }
    void Update()
    {
        if (arTrackedImageManager.trackables.count > 1)
        {
            Debug.Log("More than one image detected");
            session.Reset();
        }
    }
    void OnEnable()
    {
        arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }
    void OnDisable()
    {
        arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }
    void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage trackedImage in args.added)
        {
            Debug.Log("Added Image: " + trackedImage.referenceImage.name);
        }
        foreach (ARTrackedImage trackedImage in args.removed)
        {
            Debug.Log("Removed Image: " + trackedImage.referenceImage.name);
        }
    }

    public void remove_objs()
    {
        session.Reset();
    }
    
}
