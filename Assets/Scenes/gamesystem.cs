using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamesystem : MonoBehaviour
{
    public inputmn inputmn;
    Text PauseStats;
    Text count;

    // Start is called before the first frame update
    void Start()
    {
        PauseStats = GameObject.Find("PauseStats").GetComponent<Text>();
        count = GameObject.Find("count").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {


        count.text = inputmn.count.ToString();
        if (inputmn.start == 0||inputmn.pause==1)
        {
            PauseStats.text = "Press B";
        }
        else
        {
            PauseStats.text = "";
        }

        if (inputmn.finish == 1)
        {
            PauseStats.text = "saving...";
        }
        if (inputmn.finish == 2)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        //if (time>90)UnityEditor.EditorApplication.isPlaying = false;
    }
}
