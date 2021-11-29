using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Handler : MonoBehaviour
{
    private bool InputX;
    public static Moving P;
    public static int On = 0;
    public static int totalbox;
    public static int totalnbox;
    public static Text message;
    public static int i = 0;
    public GameObject[] AnsBtn;
    public static GameObject nbox;
    public static GameObject ntar;
    public static bool won = false;
    // Start is called before the first frame update
    private void Awake()
    {
        

    }
    void Start()
    {
        message = GameObject.FindGameObjectWithTag("Win").GetComponent<Text>();
        AnsBtn= GameObject.FindGameObjectsWithTag("AnsBtn");
    }

    // Update is called once per frame
    void Update()
    {
        DetectMove();
    }
    public static void checkWin()
    {
        if (SceneManager.GetActiveScene().name == "Lv4")
        {
            if (totalbox == Box.OnBox.Count && ntar.transform.position == nbox.transform.position)
            {
                message.text = "You Win";
                won = true;
            }
            else message.text = "";
        }
        else
        {
            if (totalbox == Box.OnBox.Count)
            {
                message.text = "You Win";
                won = true;
            }
            else message.text = "";
        }
    }
    public void Return()
    {
        won = false;
        SceneManager.LoadScene("Main");
        Ans.TheAns = null;
        Ans.step= 0;
        Box.OnBox.Clear();
        Ans.start = false;
        Ans.stop = false;
        Box.LastPos.Clear();
        foreach(var box in Box.LastPos)
        {
            Debug.Log("boxxxxx key"+box.Key);
        }
        i = 0;

}
    public void DetectMove()
    {
        if (!won) {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();
        if (moveInput.sqrMagnitude > 0.5)
        {
            if (InputX)
                {
                    Debug.Log("DetectMove "+i +" " +moveInput);
                    InputX = false;
                P.Move(moveInput);
                    i++;
                }
        }
        else
        {
            InputX = true;
        }
        }
    }
    public void DetectMove(Vector2 v2)
    {
        if (InputX){
            Debug.Log("DetectMoveby object "+i );
            P.Move(v2);
            i++;
        }
        else{
            InputX = true;
           }
     }
    
    public void ShowAns()
    {
        foreach(var btns in AnsBtn)
        {
            btns.GetComponent<Button>().interactable = true;
        }
    }
}
