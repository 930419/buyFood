using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vegmanage : MonoBehaviour
{
    public int vegCount = 0;
    public Text vega1text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vega1text.text = "×" + vegCount.ToString();        
    }
}
