using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class FlashLightScript : MonoBehaviour
{
    [SerializeField] private GameObject flashLight;
    [SerializeField] private bool isEnabled = false;

    
    void Update()
    {
        if(Input.GetButtonUp("Flashlight"))
        {
            isEnabled = !isEnabled;
            flashLight.SetActive(isEnabled);
        }
    }
}
