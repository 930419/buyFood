using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meatClirk : MonoBehaviour
{
    [SerializeField] bool bought1;
    [SerializeField] bool buying4;
    [SerializeField] GameObject meat;
    [SerializeField] GameObject buyMeatImage;
    [SerializeField] GameObject yesMeat;
    [SerializeField] GameObject noMeat;
    // Start is called before the first frame update
    void Start()
    {
        bought1 = false;
        buying4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(buying4){
            if(Input.GetKey(KeyCode.Y)){
                buyMeat();
                buying4 = false;
            }  
            else if(Input.GetKey(KeyCode.N)){
                nobuyMeat();
                buying4 = false;
            }   
        } 
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && !bought1){
            buyMeatImage.SetActive(true);
            Time.timeScale = 0f;
            buying4 = true;
        }
    }

    public void buyMeat(){
        gameObject.transform.parent.GetComponent<meatmanage>().meatCount++;
        bought1 = true;
        meat.SetActive(false);
        buyMeatImage.SetActive(false);
        Time.timeScale = 1f;
        buying4 = false;
    }
    public void nobuyMeat(){
        buyMeatImage.SetActive(false);
        Time.timeScale = 1f;
        buying4 = false;
    } 

}
