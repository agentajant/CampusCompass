using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_changing_to_Selector : MonoBehaviour
{
    public int scene_index;
    public bool back;
    public void OnClick()
    {
        if(back)
        {
            PlayerPrefs.DeleteAll();
        }
        SceneManager.LoadScene(scene_index);
    }
}
