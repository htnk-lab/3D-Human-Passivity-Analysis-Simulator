using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

[Serializable]
public class LogData
{
    public float time;

    public Vector3 y_h;

    public Vector3 u_h;

    public Vector3[] drones;

    public Vector3 ez;

    public int gameCount;

    public Vector3 target;
}

[Serializable]
public class LogDataArray
{
    public int InterfaceType;

    public int ParticipantID;

    public int ExNum;

    public LogData[] log;
}

public class txtoutput : MonoBehaviour
{
    public inputmn inputmn;

    public Transform target;

    public Transform drone;

    public Transform[] drones;

    private List<LogData> logList;

    private DateTime now = DateTime.Now;

    private float time = 0;

    private float starttime = 0;

    private float pausetime = 0;

    private string fileName;

    // Start is called before the first frame update
    void Start()
    {
        fileName =
            "Log_" +
            DateTime.Now.ToString("yyyyMMdd_HHmmss") +
            "_Interface" +
            inputmn.InterfaceType +
            "_ID" +
            inputmn.ParticipantID +
            "_" +
            inputmn.exnum;
        logList = new List<LogData>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inputmn.start == 1 && inputmn.pause == 0)
        {
            starttime = Time.realtimeSinceStartup;
            inputmn.start = 2;
        }
        if (inputmn.pause == 1)
        {
            pausetime += Time.deltaTime;
        }
        time = Time.realtimeSinceStartup - starttime - pausetime;
        if (inputmn.start == 2)
        {
            log(time, inputmn.count);
        }
        if (inputmn.finish == 1)
        {
            var sw =
                new StreamWriter(Application.dataPath +
                    "/Scenes/Saves/" +
                    fileName +
                    ".json");
            var logArray = new LogDataArray();
            logArray.log = logList.ToArray();
            logArray.InterfaceType = inputmn.InterfaceType;
            logArray.ParticipantID = inputmn.ParticipantID;
            logArray.ExNum = inputmn.exnum;
            string json = JsonUtility.ToJson(logArray, true);
            sw.Write (json);
            sw.Flush();
            sw.Close();
            inputmn.finish = 2;
        }
    }

    void log(float time, int gameCount)
    {
        LogData logData = new LogData();
        logData.time = time;
        logData.u_h = new Vector3(inputmn.xaxis, inputmn.yaxis, inputmn.zaxis);
        logData.y_h = drone.position;
        logData.drones = new Vector3[drones.Length];
        for (int i = 0; i < drones.Length; i++)
        {
            logData.drones[i] = drones[i].position;
        }
        logData.ez = target.position - drone.position;
        logData.gameCount = gameCount;
        logData.target = target.position;
        logList.Add (logData);
    }
}
