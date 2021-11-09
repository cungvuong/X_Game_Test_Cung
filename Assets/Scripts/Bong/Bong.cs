using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bong : MonoBehaviour
{
    public int id;
    public int vitri = 0;

    public Bong(int id_Bong)
    {
        this.id = id_Bong;
    }

    public int GetId()
    {
        return this.id;
    }

    public void SetId(int id)
    {
        this.id = id;
    }

    public int GetViTri()
    {
        return this.vitri;
    }

    public void SetViTri(int vt)
    {
        this.vitri = vt;
    }
}
