using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meatclirk2 : MonoBehaviour
{
    [SerializeField] bool bought3;
    [SerializeField] bool buying6;
    [SerializeField] GameObject meat;
    [SerializeField] GameObject buyMeatImage;
    [SerializeField] GameObject yesMeat;
    [SerializeField] GameObject noMeat;
    // Start is called before the first frame update
    void Start()
    {
        bought3 = false;
        buying6 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(buying6){
            if(Input.GetKey(KeyCode.Y)){
                buyMeat();
                buying6 = false;
            }  
            else if(Input.GetKey(KeyCode.N)){
                nobuyMeat();
                buying6 = false;
            }   
        } 
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && !bought3){
            buyMeatImage.SetActive(true);
            Time.timeScale = 0f;
            buying6 = true;
        }
    }

    public void buyMeat(){
        gameObject.transform.parent.GetComponent<meatmanage>().meatCount++;
        bought3 = true;
        meat.SetActive(false);
        buyMeatImage.SetActive(false);
        Time.timeScale = 1f;
        buying6 = false;
    }
    public void nobuyMeat(){
        buyMeatImage.SetActive(false);
        Time.timeScale = 1f;
        buying6 = false;
    } 

}

