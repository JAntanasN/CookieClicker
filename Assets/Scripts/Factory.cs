using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{

    public Clicker clicker;
    public int workers = 0;
    public float interval = 5;
    public int cookies = 2; //cookies per worker

    void Start()
    {
        InvokeRepeating(nameof(Bake), interval, interval);
    }

    void Bake()
    {
        clicker.Clicks += cookies + workers;
    }

    
}
