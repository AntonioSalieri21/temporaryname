using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressScript : MonoBehaviour
{
    public Vector3 endPosition;
    public float speed;
    public void startMoving()
    {
        var step =  speed * Time.deltaTime; 
        
    }
}
