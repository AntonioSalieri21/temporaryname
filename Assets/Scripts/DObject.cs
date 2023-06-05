using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DObject : MonoBehaviour
{
    [SerializeField] public GameObject dobj;

    public void deleteObjectFromExistenceNahuy(){Destroy(dobj);}
}
