using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringModalToFront : MonoBehaviour {

    private void OnEnable()
    {
        // make this the last hierarchi of its layer
        transform.SetAsLastSibling();
    }
}
