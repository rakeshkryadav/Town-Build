using System;
using UnityEngine;

public class CameraManger : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 newPosition;
    private bool drag = false;

    [SerializeField] private float zoomChange;
    [SerializeField] private float smoothChange;
    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;

    private new Camera camera;
    private float cameraHeight;
    
    void Start(){
        camera = GetComponent<Camera>();
        cameraHeight = camera.transform.position.y;
    }

    void Update(){
        if(Input.GetKey(KeyCode.X)){
            camera.orthographicSize -= zoomChange * Time.deltaTime * smoothChange;
        }
        else if(Input.GetKey(KeyCode.Z)){
            camera.orthographicSize += zoomChange * Time.deltaTime * smoothChange;
        }

        camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, minSize, maxSize);
    }
    public void LateUpdate(){
        if(Input.GetMouseButton(0)){
            newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position;
            if(drag == false){
                drag = true;
                initialPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else{
            drag = false;
        }

        if(drag){
            Camera.main.transform.position = new Vector3(initialPosition.x - newPosition.x, cameraHeight, initialPosition.z - newPosition.z);
        }
    }
}

