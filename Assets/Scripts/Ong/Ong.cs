using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Ong
{
    public List<Bong> bong = new List<Bong>();

    public Ong(int id1, int id2, int id3, int id4)
    {
        int id = Random.Range(1, 6);
        switch(id){
            case 1: {
                    bong.Add(new Bong(id1));
                    bong.Add(new Bong(id2));
                    bong.Add(new Bong(id3));
                    bong.Add(new Bong(id4));
                break;
                }
            case 2:
                {
                    bong.Add(new Bong(id4));
                    bong.Add(new Bong(id2));
                    bong.Add(new Bong(id3));
                    bong.Add(new Bong(id1));
                break;
                }
            case 3:
                {
                    bong.Add(new Bong(id1));
                    bong.Add(new Bong(id2));
                    bong.Add(new Bong(id4));
                    bong.Add(new Bong(id3));
                break;
                }
            case 4:
                {
                    bong.Add(new Bong(id3));
                    bong.Add(new Bong(id4));
                    bong.Add(new Bong(id2));
                    bong.Add(new Bong(id1));
                break;
                }
            case 5:
                {
                    bong.Add(new Bong(id4));
                    bong.Add(new Bong(id1));
                    bong.Add(new Bong(id3));
                    bong.Add(new Bong(id2));
                break;
                }
            case 6:
                {
                    bong.Add(new Bong(id1));
                    bong.Add(new Bong(id4));
                    bong.Add(new Bong(id3));
                    bong.Add(new Bong(id2));
                    break;
                }
        }
    }
}
