using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputHandler : MonoBehaviour
{
    // Start is called before the first frame update

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if(!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if(!rayHit.collider) return;
        
        //rayHit.gameObject.InteractableObject.activateTrigger();
        //rayHit.collider.transform.parent.gameObject.GetComponent<InteractableObject>().activateTrigger();
        Debug.Log(rayHit.collider.name);
        InteractableObject script = rayHit.collider.gameObject.GetComponent<InteractableObject>();
        if(script != null) script.activateTrigger();
        //Debug.Log(rayHit.collider.gameObject.name);
    }
}
