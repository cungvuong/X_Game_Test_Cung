using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Reset : MonoBehaviour
{
    public static Manager_Reset instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    [HideInInspector]
    public static GameObject _Reset_Object;

    public void Reset_Init_Play()
    {
        Destroy(GameObject.FindObjectOfType<Manager_Init>().gameObject);
        Instantiate(_Reset_Object, null);
    }

    public void Exit_Game()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }
}
