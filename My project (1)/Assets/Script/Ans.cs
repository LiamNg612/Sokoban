using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ans : MonoBehaviour
{
    public static Vector2[] TheAns;
    public Vector2[] Ans1 = { new Vector2(0, -1), new Vector2(-1, 0), new Vector2(0, -1), new Vector2(1, 0), new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 0), new Vector2(1, 0), new Vector2(0, -1), new Vector2(0, -1), new Vector2(-1, 0) };
    public Vector2[] Ans2 = {new Vector2(0,1),new Vector2(-1,0),
    new Vector2(0,1),
    new Vector2(0,1),
    new Vector2(1,0),
    new Vector2(0,1),
    new Vector2(-1,0),
     new Vector2(0,-1),
      new Vector2(0,-1),
      new Vector2(-1,0),
      new Vector2(-1,0),
      new Vector2(-1,0),
      new Vector2(-1,0),
      new Vector2(0,-1),
      new Vector2(0,-1),
      new Vector2(-1,0),
      new Vector2(0,1)};
    public Vector2[] Ans3={new Vector2(-1, 0),
    new Vector2(0,-1),
    new Vector2(1,0),new Vector2(1,0),new Vector2(1,0),new Vector2(-1,0),new Vector2(-1,0),
    new Vector2(0,-1),new Vector2(0,-1),new Vector2(0,-1),new Vector2(0,-1),new Vector2(-1, 0),
    new Vector2(-1, 0),new Vector2(0,1),new Vector2(1,0),new Vector2(0,-1),new Vector2(1,0),
    new Vector2(0,1),new Vector2(0,1),new Vector2(0,1),new Vector2(0,1),new Vector2(0,1),
    new Vector2(1,0),new Vector2(0,1),new Vector2(-1, 0),new Vector2(0,1),new Vector2(1,0),
    new Vector2(1,0),new Vector2(0,-1),new Vector2(0,-1),new Vector2(0,-1),new Vector2(-1,0),
      new Vector2(-1,0),
      new Vector2(0,-1),
      new Vector2(0,-1),
       new Vector2(0,-1),
       new Vector2(0,-1),
       new Vector2(1,0),
       new Vector2(0,1),
       new Vector2(0,1),
       new Vector2(0,1),
       new Vector2(0,1),
       new Vector2(-1,0),
       new Vector2(0,1),
       new Vector2(1,0),
    }   ;

    public static bool start=false;
    public static bool stop = false;
    public Handler handler;
    [SerializeField]Sprite Off;
    bool flag;
    string stored;
    public static int step;
    // Start is called before the first frame update
    void Start()
    {
        start = false;
        stop = false;
        TheAns = null;
        step = 0;
        switch (SceneManager.GetActiveScene().name)
        {
            case "Lv1":
                TheAns = Ans1;
                break;
            case "Lv2":
                TheAns = Ans2;
                break;
            case "Lv3":
                TheAns = Ans3;
                break;
            case "Lv4":
                TheAns = Ans1;
                break;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startBtn()
    {
        
        start = true;
            if (step==0)
            {
                StartCoroutine(Example());
            }
            else
            {
                StartCoroutine(Example(step));
            }
        
        
        start = false;

    }
    public void stopBtn()
    {
        stop = true;
    }
    public void Back()
    {
        if (step >= 0)
        {
            Handler.P.Move(-TheAns[step-1]);
        }
            foreach (var box in Box.LastPos)
            {
                foreach (var steps in box.Value)
                {
                    if (steps.Key == step)
                    {
                       stored = box.Key;
                        GameObject.Find(box.Key).transform.position = new Vector2(steps.Value.x, steps.Value.y);
                   // if(!Box.onPosition(GameObject.Find(box.Key).transform.position)){
                    //    GameObject.Find(box.Key).transform.GetComponent<SpriteRenderer>().sprite = Off;
                    //}
                    if (Box.OnBox.ContainsKey(box.Key) && !Box.onPosition(GameObject.Find(box.Key).transform.position))
                    {
                        Box.OnBox.Remove(box.Key);
                        GameObject.Find(box.Key).transform.GetComponent<SpriteRenderer>().sprite = Off;
                    }


                    flag = true;
                        
                    }
                }

            }
        if (flag)
        {
            Box.LastPos[stored].Remove(step);
            Debug.Log("step the steppppppppppp now" + step);
            flag = false;
        }
        
        if (step > 0)
        {
            step--;
            Handler.i--;
        }
        
    }
    public void Forward()
    {
        Debug.Log("Step"+step);
        handler.DetectMove(TheAns[step]);
        step++;
        
    }

    IEnumerator Example()
    {
    for(int i=0;i< TheAns.Length; i++)
    {
            if (!stop)
            {
                yield return new WaitForSeconds(0.5f);
                Debug.Log(TheAns);
                handler.DetectMove(TheAns[i]);
                step = i+1;
                Debug.Log(step);
            }
            
    }
        
    }
    IEnumerator Example(int index)
    {
        stop = false;
        for (int i = index; i < TheAns.Length; i++)
        {
            if (!stop)
            {
                yield return new WaitForSeconds(0.7f);
                handler.DetectMove(TheAns[i]);
                step = i+1;
            }
        }

    }

}
