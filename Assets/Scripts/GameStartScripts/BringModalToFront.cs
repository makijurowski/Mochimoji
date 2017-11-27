using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringModalToFront : MonoBehaviour {

    private void OnEnable()
    {
        // Make this the last object in the hierarchy of its layer
        transform.SetAsLastSibling();
    }
}