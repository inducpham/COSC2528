using UnityEngine;
using System.Collections;

public class ScoreDisplay : MonoBehaviour
{
    public static int Score = 0;

    public Rect ScoreRect;

    protected void Start()
    {
        Score = 0;
    }

    protected void OnGUI()
    {
        GUI.Label(ScoreRect, "Score: " + Score);
    }
}
