using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vegClirk : MonoBehaviour
{
    [SerializeField] bool bought1;
    [SerializeField] bool buying7;
    [SerializeField] GameObject veg;
    [SerializeField] GameObject buyVegImage;
    [SerializeField] GameObject yesVeg;
    [SerializeField] GameObject noVeg;
    // Start is called before the first frame update
    void Start()
    {
        bought1 = false; 
        buying7 = false;      
    }

    // Update is called once per frame
    void Update()
    {
        if(buying7){
            if(Input.GetKey(KeyCode.Y)){
                buyVeg();
                buying7 = false;
            }  
            else if(Input.GetKey(KeyCode.N)){
                nobuyVeg();
                buying7 = false;
            }   
        } 
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && !bought1){
            buyVegImage.SetActive(true);
            Time.timeScale = 0f;
            buying7 = true;  
        }
    }

    public void buyVeg(){
        gameObject.transform.parent.GetComponent<vegmanage>().vegCount++;
        bought1 = true;
        veg.SetActive(false);
        buyVegImage.SetActive(false);
        Time.timeScale = 1f;
        buying7 = false;  
    }
    public void nobuyVeg(){
        buyVegImage.SetActive(false);
        Time.timeScale = 1f;
        buying7 = false;  
    }
}
