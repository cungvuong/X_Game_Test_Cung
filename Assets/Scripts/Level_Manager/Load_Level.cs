using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load_Level : MonoBehaviour
{
    public Text text_Level;
    private void Start()
    {
        if (!Load_Data_Level.instance.list.level[int.Parse(GetComponentInChildren<Text>().text) - 1].lock_level)
        {
            GetComponent<Image>().color = Color.white;
            GetComponent<Button>().enabled = true;
        }
        else
        {
            GetComponent<Image>().color = Color.black;
            GetComponent<Button>().enabled = false;
        }
        text_Level.text = "Level " + Load_Data_Level.instance.list.level_Current.ToString();
    }

    public void Change_Level()
    {
        Load_Data_Level.instance.list.level_Current = int.Parse(GetComponentInChildren<Text>().text);
        Save_Data.Save(Load_Data_Level.instance.list);
        SceneManager.LoadScene(0);
        text_Level.text = "Level " + Load_Data_Level.instance.list.level_Current.ToString();
    }
}
