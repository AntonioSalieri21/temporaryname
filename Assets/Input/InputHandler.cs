using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputHandler : MonoBehaviour
{
    // Start is called before the first frame update

    private Camera mainCamera;
    
    [SerializeField] private float maxActionDistance;
    private void Awake()
    {
        //player = gameObject;
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

        Vector3 itemPos = rayHit.transform.position;
        Vector3 playerPos = gameObject.transform.position;//player.transform.position;
        float distance = Vector3.Distance(itemPos, playerPos);

        Debug.Log(distance);

        if(script != null && distance <= maxActionDistance) script.activateTrigger();
        //Debug.Log(rayHit.collider.gameObject.name);
    }
}
