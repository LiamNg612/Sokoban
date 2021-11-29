using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box : MonoBehaviour
{
    public Sprite On;
    public Sprite Off;
    public static Dictionary<string,Vector2> OnBox = new Dictionary<string, Vector2>();
    public static Dictionary<string, Vector2> OnnBox = new Dictionary<string, Vector2>();
    public static Dictionary<string, Dictionary<int, Vector3>> LastPos = new Dictionary<string,Dictionary<int, Vector3>>();
    public static Vector2 BoxnewPos;
    public bool Move(Vector2 dir)
    {
        if (BoxBlocked(transform.position, dir))
        {
            return false;
        }
        else
        {
            if (onPosition(dir))
            {
                OnBox.Add(gameObject.name, BoxnewPos);
                Handler.checkWin();
            }
            if (OnBox.ContainsKey(gameObject.name) &&OnBox[gameObject.name] != BoxnewPos)
            {
                OnBox.Remove(gameObject.name);
            }
            
            transform.Translate(dir);
            return true;
        }
    }
    bool BoxBlocked(Vector3 position,Vector2 direction)
    {
        BoxnewPos = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach(var wall in walls)
        {
            if (wall.transform.position.x == BoxnewPos.x && wall.transform.position.y == BoxnewPos.y)
            {
                return true;
            }
        }
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes)
        {
            if (box.transform.position.x == BoxnewPos.x && box.transform.position.y == BoxnewPos.y)
            {
                return true;
            }
        }
        if (SceneManager.GetActiveScene().name == "Lv4")
        {
            GameObject nbox = GameObject.FindGameObjectWithTag("New Box");
            if (nbox.transform.position.x == BoxnewPos.x && nbox.transform.position.y == BoxnewPos.y)
                return true;
        }
            
        if (LastPos.ContainsKey(gameObject.name))
        {
            Debug.Log("i the steppppp nowwwww"+(Handler.i + 1));
            LastPos[gameObject.name].Add((Handler.i+1), position);
            
        }
        else
        {
            Debug.Log(Handler.i + 1);
            LastPos.Add(gameObject.name, new Dictionary<int, Vector3>());
            LastPos[gameObject.name].Add(Handler.i, position);
            Debug.Log("Init" + " " + (Handler.i ) + " " + position);
        }
        return false;
    }
    bool onPosition(Vector2 dir)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Point");
        foreach (var target in targets)
        { 
            if (target.transform.position.x == transform.position.x+dir.x && target.transform.position.y == transform.position.y+dir.y)
            {
                transform.GetComponent<SpriteRenderer>().sprite = On;
                return true;
            }
        }
        if(gameObject.tag=="New Box"&& GameObject.FindGameObjectsWithTag("New Box")== GameObject.FindGameObjectsWithTag("New Point"))
        {
            transform.GetComponent<SpriteRenderer>().sprite = On;
            return true;
        }
        transform.GetComponent<SpriteRenderer>().sprite = Off;
        return false;
    }
    public static bool onPosition(Vector3 v3)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Point");
        foreach (var target in targets)
        {
            if (target.transform.position==v3)
            {
                return true;
            }
        }
        return false;
    }

}
