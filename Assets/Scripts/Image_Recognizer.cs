using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Image_Recognizer : MonoBehaviour
{
    private ARTrackedImageManager arTrackedImageManager;
    public ARSession session;
    public PathFinder find;
    public scene_changing_to_Selector change;
    private string final_node = null;
    // Start is called before the first frame update
    void Awake()
    {
        arTrackedImageManager = GetComponent<ARTrackedImageManager>();
    }
    void Update()
    {
        if (arTrackedImageManager.trackables.count > 1)
        {
            // Debug.Log("More than one image detected");
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
            // if (final_node != null && trackedImage.referenceImage.name[0] == final_node[0])
            // {
            //     Debug.Log("You have reached your destination: ");
            //     change.OnClick();
            // }

            if (trackedImage.referenceImage.name[0] == PlayerPrefs.GetString("node1")[0])
            {
                final_node = PlayerPrefs.GetString("node2");
                Debug.Log("Last Node " + final_node);
            }

            else if(trackedImage.referenceImage.name[0] == PlayerPrefs.GetString("node2")[0])
            {
                final_node = PlayerPrefs.GetString("node1");
                Debug.Log("Last Node " + final_node);
            }

            else if (find.distance(trackedImage.referenceImage.name[0], PlayerPrefs.GetString("node1")[0]) <= find.distance(trackedImage.referenceImage.name[0], PlayerPrefs.GetString("node2")[0]))
            {
                Debug.Log(PlayerPrefs.GetString("node1")[0]);
                Debug.Log("Next Node " + find.finder(trackedImage.referenceImage.name[0], PlayerPrefs.GetString("node1")[0]));
            }
            else
            {
                Debug.Log(PlayerPrefs.GetString("node2")[0]);
                Debug.Log("Next Node " + find.finder(trackedImage.referenceImage.name[0], PlayerPrefs.GetString("node2")[0]));
            }
            
        }
        // foreach (ARTrackedImage trackedImage in args.removed)
        // {
        //     Debug.Log("Removed Image: " + trackedImage.referenceImage.name);
        // }
    }

    public void remove_objs()
    {
        session.Reset();
    }
    
}
