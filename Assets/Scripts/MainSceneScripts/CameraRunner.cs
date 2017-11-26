using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRunner : MonoBehaviour {
    [SerializeField]
    float x_offset;

    [SerializeField]
    float y_offset;
    public Transform player;

    // Have the camera follow the Player.
	void Update () {
        if (player != null) {
            // transform.position = new Vector3(player.position.x + (float)8 + x_offset, (float)0.57 + y_offset, -10);
            transform.position = new Vector3(player.position.x + (float)8, (float)0.57, -10);
        }
	}
}