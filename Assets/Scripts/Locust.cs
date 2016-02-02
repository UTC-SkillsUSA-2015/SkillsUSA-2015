using UnityEngine;
using System.Collections;

public class Locust : MonoBehaviour {

    //private string[] name1 = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
    //private string[] name2 = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
    //private string[] name3 = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
    //private string[] name4 = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
    //private string[] name5 = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        [SerializeField]
        int[] Locusts;

    //int newLocust;

    //public string GetLocust()
    //{
    //    return name1[Random.Range(0, name1.Length)] + name2[Random.Range(0, name2.Length)] + name3[Random.Range(0, name3.Length)] + name4[Random.Range(0, name4.Length)] + name5[Random.Range(0, name5.Length)];
    //}

    void Update()
    {
        for(int i = 0; i < Locusts.Length; i++)
        {
            Locusts[i] = i;
            System.Array.Resize<int>(ref Locusts, Locusts.Length + 1);
        }

        Update();
    }
}
