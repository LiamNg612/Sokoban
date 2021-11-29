using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public string file;
    public List<string> Row = new List<String>();
    public int Height { get { return Row.Count; } }
    public int Width
    {
        get
        {
            int maxLength = 0;
            foreach (var r in Row)
            {
                if (r.Length > maxLength) maxLength = r.Length;
            }
            return maxLength;
        }
    }

    private void Awake()
    {
        TextAsset textAsset = (TextAsset)Resources.Load(file);
        if (!textAsset)
        {
            Debug.Log("Levels not exist");
            return;
        }
        else
        {
            Debug.Log("Imported");
        }
        string complete = textAsset.text;
        string[] lines;
        lines = complete.Split(new string[] { "\n" }, StringSplitOptions.None);
        for (long i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
                Row.Add(line); 
        }


    }
}
