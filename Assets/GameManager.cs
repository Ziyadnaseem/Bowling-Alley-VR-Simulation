using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;  
using System.IO;  
using System.Text;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    int score=0;
    int turnCounter=0;
    GameObject[] pins;
    Vector3[] positions;
    // public HighScore highScore;
    List<int> l;
    public GameObject yourScoreMenu;
    public Text yourScoreValue;

    public Text score1;
    public Text score2;
    public Text score3;
    public Text score4;
    public Text score5;
    public Text score6;
    public Text score7;
    public Text score8;
    public Text score9;
    public Text score10;
    
    public string[] scoreboard = new string[]{"-","-","-","-","-","-","-","-","-","-"};

    string path;

    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/ScoreDB4.txt";
        pins = GameObject.FindGameObjectsWithTag("Pin");
        positions = new Vector3[pins.Length];

        for(int i=0;i<pins.Length;i++)
        {
            positions[i]=pins[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ball.transform.position.y < -20)
        {
            CountPinsDown();
            turnCounter++;
            ResetPins();
            if(turnCounter == 10)
            {
                writeInFile();
                openYourScore();
                turnCounter = 0;
                score = 0;
                initializeScoreboard();
                updateScoreboard();
                menu.SetActive(true);
            }
        }
    }

    void CountPinsDown()
    {
        int j=0;
        for (int i=0;i<pins.Length;i++)
        {
            if(pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf)
            {
                j++;
                score++;
                pins[i].SetActive(false);
            }
        }
        scoreboard[turnCounter]=j.ToString();
        
        updateScoreboard();

        //StreamWriter writer = new StreamWriter(path,true);
        //writer.WriteLine(j.ToString());
        //writer.Close();

        // if(score > highScore.highScore)
        // {
        //     highScore.highScore=score;
        // }
        
        
        // StreamReader reader = new StreamReader(path);
        // string line;
        // l =new List<int>();
        // while((line = reader.ReadLine()) != null)
        // {
        //     l.Add(Int16.Parse(line));
        // }
        // l.Sort();
        // l.Reverse();


        // for(int i=0;i<10;i++)
        //     highScore.highScore.Add(l[i]);

        // highScore.highScore = l;
        
        
        // string temp="";
        // for(int i=0;i<10;i++)
        //     {
        //         temp +=(i+1) + " " + l[i].ToString + "\n";
        //     }


            // Debug.Log(l[i]);
        // highScore.highScore = temp;
    }


    void writeInFile()
    {
        StreamWriter writer = new StreamWriter(path,true);
        writer.WriteLine(score.ToString());
        writer.Close();
    }

    void openYourScore()
    {
        yourScoreMenu.SetActive(true);
        yourScoreValue.text=score.ToString();
    }

    public void CloseYourScore()
    {
        yourScoreMenu.SetActive(false);
    }

    void initializeScoreboard()
    {
        for(int i=0;i<10;i++)
        {
            scoreboard[i]="-";
        }
    }

    void updateScoreboard()
    {
        score1.text=scoreboard[0];
        score2.text=scoreboard[1];
        score3.text=scoreboard[2];
        score4.text=scoreboard[3];
        score5.text=scoreboard[4];
        score6.text=scoreboard[5];
        score7.text=scoreboard[6];
        score8.text=scoreboard[7];
        score9.text=scoreboard[8];
        score10.text=scoreboard[9];
    }

    void ResetPins()
    {
        for(int i=0;i<pins.Length;i++)
        {
            pins[i].SetActive(true);
            pins[i].transform.position=positions[i];
            pins[i].GetComponent<Rigidbody>().velocity=Vector3.zero;
            pins[i].GetComponent<Rigidbody>().angularVelocity=Vector3.zero;
            pins[i].transform.rotation=Quaternion.identity;
        }    

        ball.transform.position=new Vector3(0,0.107f,0.8f);
        ball.GetComponent<Rigidbody>().velocity=Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity=Vector3.zero;
        ball.transform.rotation=Quaternion.identity;    
    }
}