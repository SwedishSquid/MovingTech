using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject playerObject;

    // Update is called once per frame
    void LateUpdate()
    {
        var p = playerObject.transform.position;
        transform.position = new Vector3(p.x, p.y, transform.position.z);
    }
}
