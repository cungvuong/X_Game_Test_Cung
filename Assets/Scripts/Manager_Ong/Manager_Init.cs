using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager_Init : MonoBehaviour
{
    public static Manager_Init instance;
    private Manager_Ong[] list_Ong;
    private GameObject _Reset_Init;
    [HideInInspector]
    public Manager_Ong current_Ong;
    [HideInInspector]
    public Manager_Ong next_Ong;
    public GameObject win_Ui;
    public GameObject menu_Ui;
    [HideInInspector] public Bong[] list_Child_Current_Ong;
    [HideInInspector] public Bong[] list_Child_Next_Ong;
    [HideInInspector] public bool click_Ong;
    public GameObject Ong;
    public Text text_Level;

    private int[] mang_range; 
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        Init_Ong();
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void Init_Ong()
    {
        win_Ui.SetActive(false);
        menu_Ui.SetActive(false);
        current_Ong = null;
        next_Ong = null;
        int so_Ong = Random.Range(6, 8);
        int so_Ong_Co_Bong = so_Ong - 2;
        for(int i=0; i<so_Ong; i++)
        {
            Instantiate(Ong, transform);
        }
        list_Ong = GetComponentsInChildren<Manager_Ong>();

        for (int i=0; i<so_Ong_Co_Bong; i++)
        {
            if(so_Ong == 6)
                list_Ong[i].ong = new Ong(1, 2, 3, 4);
            else if (so_Ong == 7) {
                switch (i)
                {
                    case 0:
                        list_Ong[i].ong = new Ong(1, 2, 5, 4);
                        break;
                    case 1:
                        list_Ong[i].ong = new Ong(1, 2, 3, 4);
                        break;
                    case 2:
                        list_Ong[i].ong = new Ong(1, 5, 3, 4);
                        break;
                    case 3:
                        list_Ong[i].ong = new Ong(5, 2, 3, 4);
                        break;
                    case 4:
                        list_Ong[i].ong = new Ong(1, 2, 3, 5);
                        break;
                }
            }
            else if (so_Ong == 8)
            {
                switch (i)
                {
                    case 0:
                        list_Ong[i].ong = new Ong(6, 2, 3, 5);
                        break;
                    case 1:
                        list_Ong[i].ong = new Ong(1, 6, 3, 4);
                        break;
                    case 2:
                        list_Ong[i].ong = new Ong(1, 2, 5, 4);
                        break;
                    case 3:
                        list_Ong[i].ong = new Ong(5, 2, 3, 4);
                        break;
                    case 4:
                        list_Ong[i].ong = new Ong(1, 6, 3, 4);
                        break;
                    case 5:
                        list_Ong[i].ong = new Ong(1, 2, 6, 5);
                        break;
                }
            }
        }
        for(int i=so_Ong_Co_Bong; i< so_Ong; i++)
        {
            list_Ong[i].ong = new Ong(0, 0, 0, 0);
        }

        // get gameObject de reset 
        Manager_Reset._Reset_Object = gameObject;
    }

    private int Range_Bong()
    {

        return 0;
    }  

    public void Set_Click_Ong_2()
    {
        // neu cung 1 ong
        Update_Child_Ong();
        if(current_Ong == next_Ong)
        {
            //current_Bong.transform.Translate(new Vector3(0f, -20f, 0f));
            list_Child_Current_Ong[list_Child_Current_Ong.Length-1].gameObject.transform.Translate(new Vector3(0f, -20f, 0f));
            Reset();
        }
        else
        {
            if (Check_Empty_Ball())
            {
                Get_Late_Bong_Current().transform.SetParent(next_Ong.transform);
                Reset();
            }
            else if (Check_Full_Ball())
            {
                Debug.Log("full");
                list_Child_Current_Ong[list_Child_Current_Ong.Length - 1].gameObject.transform.Translate(new Vector3(0f, -20f, 0f));
                Reset();
            }
            else
            {
                if (Get_Late_Bong_Current().GetComponent<Bong>().id == Get_Late_Bong_Next().GetComponent<Bong>().id) { // neu 2 qua cung mau
                    Debug.Log("Cung Mau");
                    Get_Late_Bong_Current().transform.SetParent(next_Ong.transform);
                    Reset();
                }
                else // khong cung mau se re turn ve ong
                {
                    Debug.Log("Khac Mau");
                    list_Child_Current_Ong[list_Child_Current_Ong.Length - 1].gameObject.transform.Translate(new Vector3(0f, -20f, 0f));
                    Reset();
                }
            }
        }
        if (Check_To_Win())
        {
            win_Ui.SetActive(true);
        }
    }

    private bool Check_Full_Ball()
    {
        if (list_Child_Next_Ong.Length==4)
        {
            return true;
        }
        return false;
    }

    private bool Check_Empty_Ball()
    {
        if (list_Child_Next_Ong.Length == 0)
        {
            return true;
        }
        return false;
    }

    private void Update_Child_Ong()
    {
        list_Child_Current_Ong = current_Ong.GetComponentsInChildren<Bong>();
        list_Child_Next_Ong = next_Ong.GetComponentsInChildren<Bong>();
    }

    public GameObject Get_Late_Bong_Current()
    {
        return list_Child_Current_Ong[list_Child_Current_Ong.Length-1].gameObject;
    }

    public GameObject Get_Late_Bong_Next()
    {
        return list_Child_Next_Ong[list_Child_Next_Ong.Length - 1].gameObject;
    }

    public Bong[] list_Child_Check(Manager_Ong x)
    {
        return x.GetComponentsInChildren<Bong>();
    }

    private void Reset()
    {
        current_Ong = null;
        next_Ong = null;
        click_Ong = false;
    }

    private bool Check_To_Win()
    {
        foreach(Manager_Ong x in list_Ong)
        {
            if (list_Child_Check(x).Length == 0) continue;
            if (list_Child_Check(x).Length < 4) return false;
            if (list_Child_Check(x).Length ==4)
            {
                for(int i=0; i<=2; i++) // check 4 qua co cung mau ko
                {
                    if(list_Child_Check(x)[i].id == list_Child_Check(x)[i+1].id) // neu 2 qua canh nhau cung mau
                    {
                        continue; // tiep tuc check
                    }
                    else
                    {
                        return false; // khac mau se return luon
                    }
                }
                continue; // het bong thi se tiep tuc check ong sau
            }
        }
        return true;
    }

    public void Next_Level()
    {
        Load_Data_Level.instance.list.level[Load_Data_Level.instance.list.level_Current].lock_level = false;
        Load_Data_Level.instance.list.level_Current++;
        Save_Data.Save(Load_Data_Level.instance.list);
        Debug.Log(Load_Data_Level.instance.list.level_Current + "done Load" );
        SceneManager.LoadScene(0);
        text_Level.text = "Level " + Load_Data_Level.instance.list.level_Current++.ToString();
    }

    public void Menu_Ui()
    {
        menu_Ui.SetActive(true);
    }

    public void Hide_Menu_Ui()
    {
        menu_Ui.SetActive(false);
    }
}
