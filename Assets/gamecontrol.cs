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
    public TextMeshProUGUI timer;
    public Resistance resistance;

    private float randGoal;
    private int score_num=0;
    float[] factors = new float[] {10f, 100f, 1000f, 10000f, 100000f, 1000000f,10000000f,100000000f, 1f, 0.1f, 0.01f};

    //timer
    private float timer_val = 120; //2 minutes
    private bool canCount=true;
    private bool doOnce=false;

    // Start is called before the first frame update
    void Start()
    {
        updategoal();
        //InvokeRepeating("updategoal",15,15);
        InvokeRepeating("checkScore",1f,0.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        value.text= resistance.value.ToString("N");
        countDown();
        //checkScore(); 
    }

    void updategoal()
    {

        int r = UnityEngine.Random.Range(0, factors.Length);
        randGoal = UnityEngine.Random.Range(1,20) * factors[r];
        goal.text= randGoal.ToString("N");
        reset_timer();
        
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


    void countDown()
    {
        if(timer_val >= 0.0f && canCount)
        {
            timer_val -= Time.deltaTime;
            int seconds = (int) (timer_val % 60);
            int minutes = (int) (timer_val / 60 ) % 60;

            string timeformat = string.Format("{0:00}:{1:00}", minutes,seconds);
            timer.text=timeformat;
        }

        else if(timer_val<= 0.0f && ! doOnce)
        {
            canCount=false;
            doOnce=true;
            timer.text="00:00";
            timer_val=0;
            Debug.Log("Game Over");
        }
    }


    void reset_timer()
    {
        timer_val=120;
        canCount=true;
        doOnce=false;
    }

}
