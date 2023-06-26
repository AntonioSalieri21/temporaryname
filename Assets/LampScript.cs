using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class LampScript : MonoBehaviour
{
    [SerializeField] private Light2D LampLight;
    [SerializeField] private bool isEnabled = true;

    public void toggleLight()
    {
        LampLight.enabled = !isEnabled;
        isEnabled = !isEnabled;
    }
}
