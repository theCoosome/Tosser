using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public static int Score = 0;
    public Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = string.Concat("Score:\n", Score);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(100, 100, 100, 100), string.Concat("Score:\n", Score));
    }
}
