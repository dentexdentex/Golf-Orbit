using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    public float minSize = 5f;
    public float maxSize = 10f;
    public Transform target;
    public float topOffset = 2f;
    
   public Camera camera;

    void Start() {
        camera = GetComponent<Camera>();
       
    }
    void Update() {
        // Hedefin konumunu kameranın konumu olarak ayarla
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    
        // Hedef yüksekliğini kullanarak kamera boyutunu ayarla
        float topHeight = target.position.y + target.localScale.y * topOffset;
        float targetSize = Mathf.Clamp(topHeight, minSize, maxSize);
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetSize, Time.deltaTime);
    }

  
}