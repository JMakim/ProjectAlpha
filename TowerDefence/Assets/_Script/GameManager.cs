using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    public Tower selectedTower;
    public int waveCount;
    public int resourceCount;
    public int healthCount;
    void Start()
    {
        Init_();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init_()
    {
        waveCount = 0;
        resourceCount = 0;
        healthCount = 100;
    }

}
