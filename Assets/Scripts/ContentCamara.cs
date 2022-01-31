using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentCamara : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerCamera.transform.position + Vector3.forward * 100;
        transform.rotation = playerCamera.transform.rotation;
    }
}
