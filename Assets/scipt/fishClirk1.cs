using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fishClirk1 : MonoBehaviour
{
    [SerializeField] bool bought2;
    [SerializeField] bool buying2;
    [SerializeField] GameObject fish;
    [SerializeField] GameObject buyFishImage;
    [SerializeField] GameObject yesFish;
    [SerializeField] GameObject noFish;
    // Start is called before the first frame update
    void Start()
    {
        bought2 = false;
        buying2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(buying2){
            if(Input.GetKey(KeyCode.Y)){
                buyFish();
                buying2 = false;
            }  
            else if(Input.GetKey(KeyCode.N)){
                nobuyFish();
                buying2 = false;
            }   
        }       
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && !bought2){
            buyFishImage.SetActive(true);
            Time.timeScale = 0f;
            buying2 = true;
        }
    }

    public void buyFish(){
        gameObject.transform.parent.GetComponent<fishmanage>().fishCount++;
        bought2 = true;
        fish.SetActive(false);
        buyFishImage.SetActive(false);
        Time.timeScale = 1f;
        buying2 = false;
    }
    public void nobuyFish(){
        buyFishImage.SetActive(false);  
        Time.timeScale = 1f;
        buying2 = false;
    }

}
