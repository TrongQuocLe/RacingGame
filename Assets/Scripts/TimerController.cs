using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class TimerController : MonoBehaviour
{
//     public static float time = 0f;
//     public static bool running;
//     public static bool updatedTime;
//     public bool isStartingLine;
//     [Header("UI Setting")]
//     public TMP_Text timer;
//     public TMP_Text highscore;
//     public int maxHighscoreCount = 3;
//     private List<float> timeList = new List<float>();
//     // Starting is called once before the first execution of UPdate after the MonoBehaviour is created
//     void Start()
//     {
//         timer.text = "0.00";
//     }
//     // Update is called once per frame
//     void Update()
//     {
//         if (running)
//         {
//             time += Time.deltaTime;
//             timer.text = time.ToString("#.00");
//         }
//     }
//     private void UpdateTimeList()
//     {
//         timeList.Add(time);
//         timeList.Sort();

//         if (timeList.Count > maxHighscoreCount) 
//         {
//             timeList.RemoveAt(timeList.Count - 1);
//         }
//         highscore.text = "";
//         foreach(float item in timeList)
//         {
//             highscore.text += item.ToString("#.00\n");
//         }
//     }
//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.CompareTag("Player"))
//         {
//             if (isStartingLine && !running) 
//             {
//                 time = 0f;
//                 running = true;
//             }
//             else if (!isStartingLine && running) 
//             {
//                 running = false;
//                 UpdateTimeList();
//             }
//         }
//     }
    public GameObject player;
    public Transform respawnPoint;
    public static float time = 0f;
    public static bool running;
    public static bool updatedTime = true;
    
    [SerializeField] bool resetTimerOnTrigger;
    [SerializeField] bool isFinishline;

    [SerializeField] bool respawnWhenFinish;

    [Header("UI Settings")]
    [SerializeField] TMP_Text timer;
    [SerializeField] TMP_Text timeListText;

    [SerializeField] int maxTimeList;
    
    
    List<float> timeList = new List<float>();

    private void Awake()
    {
        timer.text = "0.00";
    }

    public void ResetTimer()
    {
        time = 0f;
        // running = false;
        // updatedTime = true;
        timer.text = "0.00";
    }
    private void Update()
    {
        if (running && isFinishline)
        {
            time += Time.deltaTime;
            timer.text = time.ToString("#.00");
        }
    }



    void UpdateTimeList()
    {
        timeList.Add(time);
        timeList.Sort();

        if(timeList.Count > maxTimeList) timeList.RemoveAt(timeList.Count - 1);

        timeListText.text = "";
        foreach (float item in timeList)
        {
            timeListText.text += item.ToString("#.00\n");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(resetTimerOnTrigger && updatedTime)
            {
                time = 0f;
                running = true;
                updatedTime = false;
            }
            else if (isFinishline && running)
            {
                running = false;
                updatedTime = true;
                UpdateTimeList();
                if (respawnWhenFinish)
                {
                    player.transform.position = respawnPoint.position;
                    player.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
    }

}
