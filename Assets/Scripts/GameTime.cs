using UnityEngine;
using TMPro;

public class GameTime : MonoBehaviour
{
    public TMP_Text gameTime;
    public float currentTime;
    private float seconds;
    private int day = 1;
    private int month = 1;
    private int year = 2024;
    void Update()
    {
        // 6 Seconds = 1 Hour
        if(seconds <= 6){
            seconds += Time.deltaTime;
        }
        else{
            currentTime++;
            seconds = 0;
        }

        if(int.Parse(currentTime.ToString("f0")) / 24 == 1){
            day++;
            gameTime.text = day.ToString("00") + "/" + month.ToString("00") + "/" + year.ToString();
            currentTime = 0;
        }
    }
}
