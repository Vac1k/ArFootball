using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public TextMesh score;
    public TextMesh timeTable;
    float time;
    int count;
    public int end_time;
    public AudioSource play_sound;
    public float height_bar;
    public Image ball_image;
    public float start_ball_position;
    public Image bar_black;
    public GameObject panel_win;

    void Start()
    {
        CommonDATA.end_round = false;


        panel_win.SetActive(false);

        start_ball_position = ball_image.rectTransform.anchoredPosition.y;


        height_bar = bar_black.rectTransform.sizeDelta.y;

        time = end_time;
        play_sound = GetComponent<AudioSource>();

        play_sound.Play();

        timeTable = GameObject.Find("Timer").GetComponent<TextMesh>();
        timeTable.text = end_time.ToString();

        score = GameObject.Find("Score").GetComponent<TextMesh>();
        score.text = "0";

    }

    public void Size_Bar(float force)
    {
        //Debug.Log(force);

        float height = -(height_bar / CommonDATA.max_force) * force + height_bar;

        Debug.Log(height);


        bar_black.rectTransform.sizeDelta = new Vector2(bar_black.rectTransform.sizeDelta.x, height);
        float y_ball = (bar_black.rectTransform.anchoredPosition.y - start_ball_position) / CommonDATA.max_force * force + start_ball_position;
        ball_image.rectTransform.anchoredPosition = new Vector2(ball_image.rectTransform.anchoredPosition.x, y_ball);

    }
    //_image.rectTransform.sizeDelta = new Vector2(width, height)


    // Update is called once per frame
    void Update()
    {
        if (!CommonDATA.end_round)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                End_Round();


            }
            int t = (int)time;
            timeTable.text = t.ToString();
        }
    }

    void End_Round()
    {
        panel_win.SetActive(true);
        CommonDATA.end_round = true;

    }
    public void Restart_Level()
    {
        CommonDATA.end_round = false;
        panel_win.SetActive(false);

        count = 0;
        score.text = count.ToString();
        time = end_time;


    }
    public void SetScore(int sc)
    {
        count += sc;
        score.text = count.ToString();
    }
}
