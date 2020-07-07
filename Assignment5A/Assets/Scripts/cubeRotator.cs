using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class cubeRotator : MonoBehaviour
{
    

    void start()
    {
      
    }
    void Update()
    {
        transform.GetChild(0).rotation = Quaternion.identity;
        transform.GetChild(0).localPosition = new Vector3(0, 0, 0);
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

    }
}