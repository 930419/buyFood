using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class meatmanage : MonoBehaviour
{
    public int meatCount = 0;
    public Text meata1text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meata1text.text = "×" + meatCount.ToString();
    }
}
