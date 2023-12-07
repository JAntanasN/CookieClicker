using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Factory : MonoBehaviour
{

    public Clicker clicker;

    public float interval = 5;
    public int cookies = 2; //cookies per worker
    public float price = 10;

    [Header("UI")]
    public Button babushkaButton;
    public TextMeshProUGUI babushkaPrice;
    public TextMeshProUGUI babushkaCount;

    int workers = 0;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        InvokeRepeating(nameof(Bake), interval, interval);

        babushkaButton.onClick.AddListener(Buy);

    }

    private void Update()
    {
        if(clicker.Clicks >= price)
        {
            babushkaButton.enabled = true;
        }
        else
        {
            babushkaButton.enabled = false;
        }
    }

    void Bake()
    {
        clicker.Clicks += cookies + workers;
    }

    public void Buy()
    {
        if (clicker.Clicks < price) return;

        clicker.Clicks -= (int)Mathf.Ceil(price);
        price *= 1.2f;
        babushkaPrice.text = $"Price: {Mathf.Ceil(price)}";

        babushkaCount.text = ++workers + "";
        audio.Play();
    }

    
}
