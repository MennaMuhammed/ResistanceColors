using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class gamecontrol : MonoBehaviour
{
    public TextMeshProUGUI value;
    public TextMeshProUGUI goal;
    public TextMeshProUGUI score;
    public Resistance resistance;

    private float randGoal;
    private int score_num=0;
    float[] factors = new float[] {10f, 100f, 1000f, 10000f, 100000f, 1000000f,10000000f,100000000f, 1f, 0.1f, 0.001f};

    // Start is called before the first frame update
    void Start()
    {
        updategoal();
        //InvokeRepeating("updategoal",15,15);
        InvokeRepeating("checkScore",1f,1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        value.text= resistance.value.ToString();
        //checkScore(); 
    }

    void updategoal()
    {

        int r = UnityEngine.Random.Range(0, factors.Length);
        randGoal = UnityEngine.Random.Range(1,20) * factors[r];
        goal.text= randGoal.ToString();
        
    }

    void checkScore()
    {
        if (resistance.value == randGoal)
        {
            score_num++;
            score.text= score_num.ToString();
            updategoal();
            resistance.Restart();
            value.text="0";
            
        }
    }

}
