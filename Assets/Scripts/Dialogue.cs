using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class Dialogue
{
    public Person person;
    [TextArea(3,10)]
    public string[] sentences;
}
