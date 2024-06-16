using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fishClirk2 : MonoBehaviour
{
    [SerializeField] bool bought3;
    [SerializeField] bool buying3;
    [SerializeField] GameObject fish;
    [SerializeField] GameObject buyFishImage;
    [SerializeField] GameObject yesFish;
    [SerializeField] GameObject noFish;
    // Start is called before the first frame update
    void Start()
    {
        bought3 = false;
        buying3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(buying3){
            if(Input.GetKey(KeyCode.Y)){
                buyFish();
                buying3 = false;
            }  
            else if(Input.GetKey(KeyCode.N)){
                nobuyFish();
                buying3 = false;
            }   
        }         
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && !bought3){
            buyFishImage.SetActive(true);
            Time.timeScale = 0f;
            buying3 = true;
        }
    }

    public void buyFish(){
        gameObject.transform.parent.GetComponent<fishmanage>().fishCount++;
        bought3 = true;
        fish.SetActive(false);
        buyFishImage.SetActive(false);
        Time.timeScale = 1f;
        buying3 = false;
    }
    public void nobuyFish(){
        buyFishImage.SetActive(false);  
        Time.timeScale = 1f;
        buying3 = false;
    }

}
