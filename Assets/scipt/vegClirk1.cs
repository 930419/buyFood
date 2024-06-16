using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vegClirk1 : MonoBehaviour
{
    [SerializeField] bool bought2;
    [SerializeField] bool buying8;
    [SerializeField] GameObject veg;
    [SerializeField] GameObject buyVegImage;
    [SerializeField] GameObject yesVeg;
    [SerializeField] GameObject noVeg;
    // Start is called before the first frame update
    void Start()
    {
        bought2 = false;    
        buying8 = false;     
    }

    // Update is called once per frame
    void Update()
    {
        if(buying8){
            if(Input.GetKey(KeyCode.Y)){
                buyVeg();
                buying8 = false;
            }  
            else if(Input.GetKey(KeyCode.N)){
                nobuyVeg();
                buying8 = false;
            }   
        } 
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && !bought2){
            buyVegImage.SetActive(true);
            Time.timeScale = 0f;
            buying8 = true;
        }
    }

    public void buyVeg(){
        gameObject.transform.parent.GetComponent<vegmanage>().vegCount++;
        bought2 = true;
        veg.SetActive(false);
        buyVegImage.SetActive(false);
        Time.timeScale = 1f;
        buying8 = false;
    }
    public void nobuyVeg(){
        buyVegImage.SetActive(false);
        Time.timeScale = 1f;
        buying8 = false;
    }
}
