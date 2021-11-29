using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Build : MonoBehaviour
{
    public GameObject Wall;
    public GameObject Player;
    public GameObject Box;
    public GameObject Target;
    public GameObject NBox;
    public GameObject NTarget;
    public Levels Levels;
    public static Moving pm;
    int i = 0;
    int j = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (string row in Levels.Row)
        {
            char[] rowChar = row.ToCharArray();
            for (int k = 0; k < rowChar.Length; k++)
            {
                switch (rowChar[k])
                {
                    case '#':
                        Instantiate(Wall, new Vector3(k, -i, 0), Quaternion.identity);
                        break;
                    case 'P':
                        Instantiate(Player, new Vector3(k, -i, 0), Quaternion.identity);
                        break;
                    case '0':
                        Instantiate(Box, new Vector3(k, -i, 0), Quaternion.identity).name = j.ToString() ;
                        j++;
                        break;
                    case 'X':
                        Instantiate(Target, new Vector3(k, -i, 0), Quaternion.identity);
                        break;
                    case 'M':
                        Instantiate(NBox, new Vector3(k, -i, 0), Quaternion.identity);
                        break;
                    case 'N':
                        Instantiate(NTarget, new Vector3(k, -i, 0), Quaternion.identity);
                        break;
                    default:
                        break;

                }

            }
            i++;
        }
        Handler.P = GameObject.FindGameObjectWithTag("Player").GetComponent<Moving>();
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        Handler.totalbox = boxes.Length;
        if (SceneManager.GetActiveScene().name == "Lv4")
        {
            Handler.nbox = GameObject.FindGameObjectWithTag("New Box");
            Handler.ntar = GameObject.FindGameObjectWithTag("New Point");
        }
    }
}
