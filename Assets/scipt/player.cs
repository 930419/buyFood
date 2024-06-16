using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    // Start is called before the first frame update
    public bool jumpingCheck = false;
    public bool fallingCheck = false;
    public float FallingSpeed;
    public float jumpforce = 5f;
    public bool groundCheck = false;
    public bool jumptofallcheck = false;
    public bool ending = false;
    [SerializeField] GameObject replayButton;
    [SerializeField] GameObject replayImage;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject startImage;
    public Text fisha2text;
    public Text meata2text;
    public Text vega2text;
    public GameObject nomoneytext;
    public GameObject back;
   [SerializeField] GameObject endGameImage;
    [SerializeField] GameObject yesEnd;
    [SerializeField] GameObject noEnd;
    [SerializeField] int a; [SerializeField] int b; [SerializeField] int c;  // 食材購買數
    [SerializeField] GameObject fishmanage;
    [SerializeField] GameObject meatmanage;
    [SerializeField] GameObject vegmanage;
    [SerializeField] GameObject congrats;
    [SerializeField] GameObject winback;
    [SerializeField] GameObject wrongamount;
    AudioSource winsound;
    AudioSource startsound;
    AudioSource losesound;
    [SerializeField] GameObject startaudio;
    [SerializeField] GameObject loseaudio;
    [SerializeField] int fisha; [SerializeField] int meata; [SerializeField] int vega;
    void Start()
    {
        Time.timeScale = 0f;
        startButton.SetActive(true);
        startImage.SetActive(true);
        a = Random.Range(0,4); b = Random.Range(0,4); c = Random.Range(0,4);
        if(a+b+c < 2){
            a = Random.Range(1,4); b = Random.Range(1,4); c = Random.Range(1,4);
        }
        winsound = GetComponent<AudioSource>();
        startsound = startaudio.GetComponent<AudioSource>();
        losesound = loseaudio.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        run();
        jumpUp();
        JumpToFall();
        FallingFunction();
        if(ending){
            if(Input.GetKey(KeyCode.Y)){
                endGame();
                ending = false;
            }  
            else if(Input.GetKey(KeyCode.N)){
                dontEnd();
                ending = false;
            }              
        }
    }   
    void run(){
         if(Input.GetKey(KeyCode.D)){
            transform.Translate(runSpeed*Time.deltaTime, 0, 0);
            GetComponent<SpriteRenderer>().flipX= true;
        }
        else if(Input.GetKey(KeyCode.A)){
            transform.Translate(-runSpeed*Time.deltaTime, 0, 0);
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    void OnCollisionEnter2D (Collision2D selfbody){
        if (selfbody.gameObject.tag == "ground"){
            selfbody.gameObject.GetComponent<AudioSource>().Play();
            groundCheck = true;
            jumpingCheck = false;
        }
        else if(selfbody.gameObject.tag == "Ground") {
            groundCheck = true;
            jumpingCheck = false;
        }
    }
    void OnCollisionExit2D(Collision2D selfbodyexit){
        if(selfbodyexit.gameObject.tag == "ground" || selfbodyexit.gameObject.tag == "Ground"){
            groundCheck = false;
        }   
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "enemy"){
            Time.timeScale = 0f;
            replayButton.SetActive(true);
            replayImage.SetActive(true);
            nomoneytext.SetActive(true);
            back.SetActive(true);
            GetComponent<AudioSource>().Play();
        }
        else if(other.gameObject.tag == "home"){
            Time.timeScale = 0f;
            endGameImage.SetActive(true);
            yesEnd.SetActive(true);
            noEnd.SetActive(true);
            ending = true;
        }
    }
    void jumpUp(){
        if (Input.GetKeyDown(KeyCode.W) && groundCheck == true) {
            jumpingCheck = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpforce);
        }
    }    
    void JumpToFall(){
        FallingSpeed = GetComponent<Rigidbody2D>().velocity.y;
        if(FallingSpeed <= 1 && groundCheck == false){
            jumptofallcheck = true;
            jumpingCheck = false;   
        }
    }
    void FallingFunction(){
        if (FallingSpeed < 0 && groundCheck == false && jumptofallcheck == true) {
            fallingCheck = true;
        }
    }

    public void play(){
        Time.timeScale = 1f;
        startButton.SetActive(false);
        startImage.SetActive(false);
        fisha2text.text = "×" + a.ToString();
        meata2text.text = "×" + b.ToString();
        vega2text.text = "×" + c.ToString();
        startsound.Play();
    }
    public void replay(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void endGame(){
        Time.timeScale = 0f;
        endGameImage.SetActive(false);
        yesEnd.SetActive(false);
        noEnd.SetActive(false);
        ending = false;
        fisha = fishmanage.GetComponent<fishmanage>().fishCount;
        meata = meatmanage.GetComponent<meatmanage>().meatCount;
        vega = vegmanage.GetComponent<vegmanage>().vegCount;
        if(a == fisha && b == meata && c == vega){
            winback.SetActive(true);
            congrats.SetActive(true);
            replayButton.SetActive(true);
            winsound.Play();
        }
        else{
            losesound.Play();
            replayButton.SetActive(true);
            replayImage.SetActive(true);
            wrongamount.SetActive(true);
            back.SetActive(true);           
        }
    }
    public void dontEnd(){
        ending = false;
        endGameImage.SetActive(false);
        yesEnd.SetActive(false);
        noEnd.SetActive(false);
        Time.timeScale = 1f;
    }
}