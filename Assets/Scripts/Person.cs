using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "PersonData")]
public class Person : ScriptableObject
{
    public string p_name; //p - prefix for person
    public Sprite p_image;
}
