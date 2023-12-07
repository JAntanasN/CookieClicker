using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class Clicker : MonoBehaviour
{

    public ParticleSystem cookieParticles;
    public TextMeshProUGUI ScoreBox;
    int click = 0;

    [Header("Tweeening settings")]
    public float duration = 0.5f;
    public LoopType loop;

    [Header("ClickingSound")]
    public AudioClip AudioClick;

    public int Clicks
    {
        get 
        {
            return clicks;
        }
        set
        {
            cookieParticles.Emit(value - clicks); ;
            clicks = value;

            ScoreBox.text = clicks + "";
        }
    }

    int clicks = 0;
    AudioSource audio;

    private void Start()
    {
       audio = GetComponent<AudioSource>();

       //LoadData();
    }

    private void OnMouseDown()
    {
        ++Clicks;

        ScoreBox.text = ++click + ""; // + "" - to string // ++ gale atsilieka vienu kartu


        transform.DOScale(Vector3.one * 2, duration).SetLoops(2, loop); //transform.DOScale(Vector3.one, duration).ChangeStartValue(Vector3.one * 2);

        audio?.PlayOneShot(AudioClick);
    }


    void LoadData()
    {
        if (PlayerPrefs.HasKey(nameof(clicks)))
        {
            Clicks = PlayerPrefs.GetInt(nameof(clicks));
        }
    }

    void SaveData()
    {
        PlayerPrefs.SetInt(nameof(clicks), clicks);
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveData();
        }
    }

}
