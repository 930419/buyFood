using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fishClirk : MonoBehaviour
{
    [SerializeField] bool bought1;
    [SerializeField] bool buying1;
    [SerializeField] GameObject fish;
    [SerializeField] GameObject buyFishImage;
    [SerializeField] GameObject yesFish;
    [SerializeField] GameObject noFish;
    // Start is called before the first frame update
    void Start()
    {
        bought1 = false;
        buying1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(buying1){
            if(Input.GetKey(KeyCode.Y)){
                buyFish();
                buying1 = false;
            }  
            else if(Input.GetKey(KeyCode.N)){
                nobuyFish();
                buying1 = false;
            }   
        }     
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && !bought1){
            buyFishImage.SetActive(true);
            Time.timeScale = 0f;
            buying1 = true;
        }
    }

    public void buyFish(){
        gameObject.transform.parent.GetComponent<fishmanage>().fishCount++;
        bought1 = true;
        fish.SetActive(false);
        buyFishImage.SetActive(false);
        Time.timeScale = 1f;
        buying1 = false;
    }
    public void nobuyFish(){
        buyFishImage.SetActive(false);  
        Time.timeScale = 1f;
        buying1 = false;
    }

}
