using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;  
using System.IO;  
using System.Text;

public class MainMenu : MonoBehaviour
{
    // public HighScore highScore;
    public Text highScoreValue;
    public GameObject highScoreMenu;


    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenHighScore()
    {
        string path = Application.persistentDataPath + "/ScoreDB4.txt";
        highScoreMenu.SetActive(true);
        string temp="";
        
        if(File.Exists(path))
        {
            StreamReader reader = new StreamReader(path);
            string line;
            List<int> l =new List<int>();
            while((line = reader.ReadLine()) != null)
            {
                l.Add(Int16.Parse(line));
            }

            l.Sort();
            l.Reverse();

            Debug.Log(l.Count);

            // for(int i=0;i<10;i++)
            //     highScoreValue.text=l[i]+"\n";
            
            if(l.Count >= 10)
            {
                for(int i=0;i<10;i++)
                {
                    temp +=(i+1) + " - " + l[i].ToString() + " , ";
                }
            }
            else
            {
                for(int i=0;i<l.Count;i++)
                {
                    temp +=(i+1) + " - " + l[i].ToString() + " , ";
                }
            }
        }

        highScoreValue.text = temp;

        // foreach(var val in highScore.highScore)
        //     {
        //         highScoreValue.text+=val+"\n";
        //     }    
        // highScoreValue.text=highScore.highScore.ToString();
        // Debug.Log(temp);
    }

    public void CloseHighScore()
    {
        highScoreMenu.SetActive(false);
    }

    public void ResetHighScore()
    {
        // highScore.highScore=0;
        // highScoreValue.text=highScore.highScore.ToString();
    }
}
