using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moving : MonoBehaviour
{
    

    void Update()
    {

    }
    public bool Move(Vector2 dir)
    {
        if (Mathf.Abs(dir.x) < 0.5)
        {
            dir.x = 0;
        }
        else dir.y = 0;
        dir.Normalize();
        if (Blocked(transform.position, dir))
        {
            return false;
        }
        else
        {
            transform.Translate(dir);
            return true;
        } 
    }
        bool Blocked(Vector3 position, Vector2 direction)
        {
            Vector2 newPos = new Vector2(position.x, position.y) + direction;
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
            foreach(var wall in walls)
            {
                if(wall.transform.position.x==newPos.x&&wall.transform.position.y==newPos.y)
                {
                    return true;
                }
            }
            GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
            foreach(var box in boxes)
            {
                if(box.transform.position.x == newPos.x && box.transform.position.y == newPos.y)
                {
                    Box b = box.GetComponent<Box>();
                    if (b && b.Move(direction))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }
        }
        if (SceneManager.GetActiveScene().name == "Lv4") {
            GameObject nbox = GameObject.FindGameObjectWithTag("New Box");
            if (nbox.transform.position.x == newPos.x && nbox.transform.position.y == newPos.y)
            {
                Box nb = nbox.GetComponent<Box>();
                if (nb && nb.Move(direction))
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }
        
        return false;
        }
    }
