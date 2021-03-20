using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordList : MonoBehaviour
{
    public static string[] wordlist = System.IO.File.ReadAllLines(@"D:\Unity Projects\Quiddler(Web)\Assets\scrabble_word_list.txt");
    

    void Start()
    {
       

    }

   
}
