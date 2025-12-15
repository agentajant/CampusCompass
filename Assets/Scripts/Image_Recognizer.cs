using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.XR.ARSubsystems;

public class Image_Recognizer : MonoBehaviour
{
    public XRReferenceImageLibrary lib;
    public ARTrackedImageManager arTrackedImageManager;
    public ARCameraManager cameraManager;
    public ARSession session;
    public PathFinder find;
    public scene_changing_to_Selector change;
    private bool first_node = true;

    public TMP_Text debug_text, debug_text2, debug_text3, debug_text4;
    // Start is called before the first frame update
    void Start()
    {
        arTrackedImageManager.referenceLibrary = lib;
        arTrackedImageManager.enabled = true;
    }
    void Update()
    {
        if (arTrackedImageManager.trackables.count > 1)
        {
            session.Reset();
        }

        debug_text3.text = "LibraryCount: " + arTrackedImageManager.referenceLibrary.count;
        debug_text4.text = arTrackedImageManager.trackables.count.ToString();
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
            debug_text.text = "Detected: " + trackedImage.referenceImage.name;
            // debug_text2.text = "State: " + trackedImage.trackingState.ToString();
            // debug_text3.text = "LibraryCount: " + arTrackedImageManager.referenceLibrary.count;

            Debug.Log("Detected Image " + PlayerPrefs.GetString("node1"));
            // Single Node System
            if (PlayerPrefs.GetString("node1") == PlayerPrefs.GetString("node2"))
            {
                if (trackedImage.referenceImage.name[0] == PlayerPrefs.GetString("node1")[0])
                {
                    arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
                    cameraManager.enabled = false;
                    arTrackedImageManager.enabled = false;
                    change.OnClick();
                }
                else
                {
                    // Debug.Log("Next Node " + find.finder(trackedImage.referenceImage.name[0], PlayerPrefs.GetString("node1")[0]));
                    PlayerPrefs.SetFloat("Angle", find.Angle(trackedImage.referenceImage.name[0], find.finder(trackedImage.referenceImage.name[0], PlayerPrefs.GetString("node1")[0])[0]));
                }
            }
            // Multi Node System
            else
            {
                if(first_node == true)
                {
                    if (find.distance(trackedImage.referenceImage.name[0], PlayerPrefs.GetString("node1")[0]) > find.distance(trackedImage.referenceImage.name[0], PlayerPrefs.GetString("node2")[0]))
                    {
                        PlayerPrefs.SetString("FinalNode", PlayerPrefs.GetString("node1"));
                        PlayerPrefs.SetString("SemiNode", PlayerPrefs.GetString("node2"));
                        
                    }
                    else
                    {
                        PlayerPrefs.SetString("FinalNode", PlayerPrefs.GetString("node2"));
                        PlayerPrefs.SetString("SemiNode", PlayerPrefs.GetString("node1"));
                    }
                    // Debug.Log("Final Node " + PlayerPrefs.GetString("FinalNode"));
                    first_node = false;
                }
                else
                {
                    if (trackedImage.referenceImage.name[0] == PlayerPrefs.GetString("FinalNode")[0])
                    {
                        arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
                        cameraManager.enabled = false;
                        arTrackedImageManager.enabled = false;
                        change.OnClick();
                    }
                    else if(trackedImage.referenceImage.name[0] == PlayerPrefs.GetString("SemiNode")[0])
                    {
                        // Debug.Log("Final Node " + PlayerPrefs.GetString("FinalNode")[0]);
                        PlayerPrefs.SetFloat("Angle", find.Angle(trackedImage.referenceImage.name[0], PlayerPrefs.GetString("FinalNode")[0]));
                    }
                    else
                    { 
                        // Debug.Log("Next Node " + find.finder(trackedImage.referenceImage.name[0], PlayerPrefs.GetString("SemiNode")[0]));
                        PlayerPrefs.SetFloat("Angle", find.Angle(trackedImage.referenceImage.name[0], find.finder(trackedImage.referenceImage.name[0], PlayerPrefs.GetString("SemiNode")[0])[0]));
                    }
                }
            }          
        }
    }

    public void Remove_objs()
    {
        session.Reset();
    }
    
}
