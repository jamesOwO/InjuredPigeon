using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject leftsharkspawn, rightsharkspawn;
    Stopwatch watch;
    void Start()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
