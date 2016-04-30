using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    bool isPaused;
    public GameObject pauseMenu;
    public Text time;
    public Text timeBig;
    public Text timeCheck1;
    public Text timeCheck2;
    public float timer = 0.0f;
    public float pTimer = 0.0f;
    public float checkTimer = 0.0f;
    public float checkTimer1 = 0.0f;
    public float checkPointTimer = 5.0f;
    public bool timerCheck = true;
    public bool timerCheck1 = true;
    public bool timerCheck2 = true;
    public bool checkPointCheck = false;
    public bool checkPointCheck1 = false;
    CarMovement car;

    // Use this for initialization
    void Start()
    {
        car = GameObject.FindGameObjectWithTag("Player").GetComponent<CarMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //starting time
        if (timerCheck != false)
        {
            timer += Time.deltaTime;
            pTimer += Time.deltaTime;
            time.text = "Time = " + timer;


        }
        timeBig.text = "Best Time = " + PlayerPrefs.GetFloat("timer");

        //check point
        if (timerCheck1 != false)
            checkTimer += Time.deltaTime;

        if (checkPointCheck != false)
        {
            timerCheck1 = false;

            PlayerPrefs.SetString("timer1", checkTimer.ToString("F2"));
            PlayerPrefs.Save();
            timeCheck1.text = "Check Point 1 = " + PlayerPrefs.GetString("timer1");
        }

        if (checkPointCheck)
        {
            checkPointTimer -= Time.deltaTime;
        }
        if (checkPointTimer <= 0)
        {
            checkPointCheck = false;
            timeCheck1.text = "";
        }

        /*//2nd Check point
        if (timerCheck2 != false)
            checkTimer1 += Time.deltaTime;

        if (checkPointCheck1 != false)
        {
            timerCheck2 = false;

            PlayerPrefs.SetString("timer1", checkTimer.ToString("F2"));
            PlayerPrefs.Save();
            timeCheck1.text = "Check Point 1 = " + PlayerPrefs.GetString("timer1");
        }

        if (checkPointCheck)
        {
            checkPointTimer -= Time.deltaTime;
        }
        if (checkPointTimer <= 0)
        {
            checkPointCheck = false;
            timeCheck1.text = "";
        }*/

        //the pause menu button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if (isPaused == true)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0.0f;
            }
            else if (isPaused == false)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
       
    }
    void OnApplicationQuit()
    {
        if (timer < pTimer)
            // save the time when you quit the game
            PlayerPrefs.SetFloat("timer", pTimer);
    }
}
        // make sure to use time difference and use invicible box for the trigger for the check time
        // destroy it after hitting the box
        // change the color of the text according to the time difference 
        // if possible use list on playerprefs

