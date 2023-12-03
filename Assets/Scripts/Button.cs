using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Button : MonoBehaviour
{
    public TextMeshProUGUI Count;

    int counter;

    public void Counter()
    {
        Count.text = ++counter + "";
    }

    
}
