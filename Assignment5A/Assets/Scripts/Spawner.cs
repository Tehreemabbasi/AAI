using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using System;

public class Spawner : MonoBehaviour
{
    public static int count=0;
    public GameObject cube;
    public static System.Random random = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        int c = 0;
        for (int i = 0; i <= 9;) 
        {
           
            //create random positions and pass this position variable to Instantiate function to create cube at these locations
            Vector3 position = new Vector3(UnityEngine.Random.Range(-9, 9), UnityEngine.Random.Range(0.5f, 0.5f), UnityEngine.Random.Range(-9, 9));

            float x = 0;
            if (Physics.CheckSphere(position, x))
            {

            }
            else
            {
                //generate randome cubes at random positions with random string
                GameObject newCube=Instantiate(cube, position, Quaternion.identity);
                cube.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
                string cubeText =  RandomString(random.Next(9, 15));
                //convert random string into palindrome
                System.Random rn = new System.Random();
                if (c<=3)
                {
                    string first = cubeText.Substring(0, cubeText.Length / 2);
                    char[] arr = first.ToCharArray();
                    Array.Reverse(arr);
                    string temp = new string(arr);
                    cubeText = first + temp;
                    cube.transform.GetChild(0).GetComponent<TMPro.TextMeshPro>().text = cubeText;
                    c++;
                }
                else
                    cube.transform.GetChild(0).GetComponent<TMPro.TextMeshPro>().text = cubeText;
                i++;
            
                //check for palindrome, if string is palindrome send status to PlayerController then player collect it
                string reverse = string.Empty;
                for (int j = cubeText.Length - 1; j >= 0; j--)
                {
                    reverse += cubeText[j].ToString();
                }
                if (reverse == cubeText)
                {
                    newCube.tag = "palindrome";
                    count++;
                }

               
            }
        }
       
    }
    //func that generate random strings
    public static string RandomString(int length)
    {
        const string chars = "xt8";
        return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }
    //this function is called in playerController class
   

    // Update is called once per frame
    void Update()
    {
        
    }
  


}
