﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("level", 1);
    }
}
