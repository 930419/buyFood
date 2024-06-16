using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fishmanage : MonoBehaviour
{
    public int fishCount = 0;
    public Text fisha1text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fisha1text.text = "×" + fishCount.ToString();
    }
}
