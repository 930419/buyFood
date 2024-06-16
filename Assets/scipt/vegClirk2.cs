using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vegClirk2 : MonoBehaviour
{
    [SerializeField] bool bought3;
    [SerializeField] bool buying9;
    [SerializeField] GameObject veg;
    [SerializeField] GameObject buyVegImage;
    [SerializeField] GameObject yesVeg;
    [SerializeField] GameObject noVeg;
    // Start is called before the first frame update
    void Start()
    {
        bought3 = false;     
        buying9 = false;  
    }

    // Update is called once per frame
    void Update()
    {
        if(buying9){
            if(Input.GetKey(KeyCode.Y)){
                buyVeg();
                buying9 = false;
            }  
            else if(Input.GetKey(KeyCode.N)){
                nobuyVeg();
                buying9 = false;
            }   
        } 
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && !bought3){
            buyVegImage.SetActive(true);
            Time.timeScale = 0f;
            buying9 = true;
        }
    }

    public void buyVeg(){
        gameObject.transform.parent.GetComponent<vegmanage>().vegCount++;
        bought3 = true;
        veg.SetActive(false);
        buyVegImage.SetActive(false);
        Time.timeScale = 1f;
        buying9 = false;
    }
    public void nobuyVeg(){
        buyVegImage.SetActive(false);
        Time.timeScale = 1f;
        buying9 = false;
    }
}
