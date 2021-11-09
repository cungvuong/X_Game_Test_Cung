using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Ong : MonoBehaviour
{
    public static Manager_Ong instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public Ong ong;
    public GameObject[] Bong;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < ong.bong.Count; i++)
        {
            if (ong.bong[i].GetId() == 0)
            {
                break;
            }
            else
            {
                Instantiate(Bong[ong.bong[i].GetId() - 1], transform); // khoi tao bong vao ong
            }
        }
    }

    public void Click_Ong()
    {
        if (!Manager_Init.instance.click_Ong) // chon ong 1
        {
            Bong[] late_Child = GetComponentsInChildren<Bong>();
            if (late_Child[late_Child.Length - 1] != null)
            {
                late_Child[late_Child.Length - 1].gameObject.transform.Translate(0f, 20f, 0f);
            }
            Manager_Init.instance.current_Ong = this;
            Manager_Init.instance.click_Ong = !Manager_Init.instance.click_Ong;
        }
        else // chon ong 2
        {
            Manager_Init.instance.next_Ong = this;
            Manager_Init.instance.click_Ong = !Manager_Init.instance.click_Ong;
            Manager_Init.instance.Set_Click_Ong_2();
        }
    }
}
