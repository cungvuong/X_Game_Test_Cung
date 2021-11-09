using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Levels
{
    public int id;
    public int gold;
    public bool lock_level;

    public Levels(int _id, int _gold, bool _lock_level)
    {
        this.id = _id;
        this.gold = _gold;
        this.lock_level = _lock_level;
    }
}
