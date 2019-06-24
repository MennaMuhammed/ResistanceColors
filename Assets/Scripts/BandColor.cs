﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandColor : MonoBehaviour
{
    static Color brown = new Color(102f / 255f, 51f / 255f, 0f / 255f);
    static Color orange = new Color(255f / 255f, 116f / 255f, 0f / 255f);
    static Color violet = new Color(204f / 255f, 51f / 255f, 255f / 255f);
    static Color gold = new Color(229f / 255f, 193f / 255f, 0f / 255f);
    static Color silver = new Color(198f / 255f, 198f / 255f, 198f / 255f);
    
    public Color [] BandColors = { Color.black, brown, Color.red, orange, Color.yellow, Color.green,Color.blue,violet,Color.grey,Color.white,gold,silver};

    int[] tolerancePoss = { 1, 2, 5, 6, 7, 8, 10, 11 };

    Material band;

    public bool Multiplier = false;
    public bool Tolerance = false;

    int range;
    public int CurrentColor;
    // Start is called before the first frame update
    void Start()
    {
        band = GetComponent<Renderer>().materials[0];
        if (Tolerance)
        {
            band.color = BandColors[tolerancePoss[Random.Range(0, tolerancePoss.Length)]];
        }
        else
        {
            if (Multiplier)
            {
                range = BandColors.Length;
            }
            else
            {
                range = BandColors.Length - 2;
            }
            CurrentColor = 0;
            band.color = BandColors[CurrentColor];
        }
    }
    public void Restart()
    {
        if (Tolerance)
        {
            band.color = BandColors[tolerancePoss[Random.Range(0, tolerancePoss.Length)]];
        }
        else
        {
            if (Multiplier)
            {
                range = BandColors.Length;
            }
            else
            {
                range = BandColors.Length - 2;
            }
            CurrentColor = 0;
            band.color = BandColors[CurrentColor];
        }
    }
    private void OnMouseDown()
    {
        if (!Tolerance)
        {
            CurrentColor = (CurrentColor + 1) % range;
            band.color = BandColors[CurrentColor];
        }
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!Tolerance)
            {
                CurrentColor = (range + (CurrentColor - 1)) % range;
                band.color = BandColors[CurrentColor];
            }
        }
    }
}
