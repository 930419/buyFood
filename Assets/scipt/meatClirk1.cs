using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meatClirk1 : MonoBehaviour
{
    [SerializeField] bool bought2;
    [SerializeField] bool buying5;
    [SerializeField] GameObject meat;
    [SerializeField] GameObject buyMeatImage;
    [SerializeField] GameObject yesMeat;
    [SerializeField] GameObject noMeat;
    // Start is called before the first frame update
    void Start()
    {
        bought2 = false;
        buying5 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(buying5){
            if(Input.GetKey(KeyCode.Y)){
                buyMeat();
                buying5 = false;
            }  
            else if(Input.GetKey(KeyCode.N)){
                nobuyMeat();
                buying5 = false;
            }   
        } 
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && !bought2){
            buyMeatImage.SetActive(true);
            Time.timeScale = 0f;
            buying5 = true;
        }
    }

    public void buyMeat(){
        gameObject.transform.parent.GetComponent<meatmanage>().meatCount++;
        bought2 = true;
        meat.SetActive(false);
        buyMeatImage.SetActive(false);
        Time.timeScale = 1f;
        buying5 = false;
    }
    public void nobuyMeat(){
        buyMeatImage.SetActive(false);
        Time.timeScale = 1f;
        buying5 = false;
    } 

}
