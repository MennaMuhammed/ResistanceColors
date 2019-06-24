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
    private int i = 0;

    float[] goals = new float[] { 10f, 100f, 1000f, 1200f, 2500f, 6000f, 70000f, 88000f, 900f, 6500f, 700f, 220f, 770f };
    // Start is called before the first frame update
    void Start()
    {
        updategoal();
        //InvokeRepeating("updategoal",15,15);
        //InvokeRepeating("checkScore",0.2f,0.2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        value.text= resistance.value.ToString();
        checkScore(); 
    }

    void updategoal()
    {
        //System.Random random = new System.Random();
        int r = UnityEngine.Random.Range(0, goals.Length);
        //randGoal = random.Next(1, 1000) * 10;
        //randGoal = goals[i];
        randGoal = goals[r];
        goal.text= randGoal.ToString();
        //i++;
        
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
