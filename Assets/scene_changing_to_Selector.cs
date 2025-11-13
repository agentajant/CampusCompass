using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_changing_to_Selector : MonoBehaviour
{
    public int scene_index;
    public void OnClick()
    {
        SceneManager.LoadScene(scene_index);
    }
}
