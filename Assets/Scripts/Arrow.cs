using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Arrow : MonoBehaviour
{
    public Ball ball;
    
    
    public float donmeHizi = 10.0f; // objenin dönme hızı
    public float hareketMesafesi = 2.0f; // objenin hareket edeceği mesafe

    private float minAci = 40.0f; // objenin minimum dönüş açısı
    private float maxAci = 70.0f; // objenin maksimum dönüş açısı
    private bool hareketYonuIleri = true; // objenin hareket yönü
    private bool donusYonuIleri = true; // objenin dönüş yönü

    public float aci = 0.0f; // objenin şu anki dönüş açısıpub

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0)&& !IsMouseOverUI()) // ekrana tıklanırsa
        {
            aci = transform.rotation.eulerAngles.z; // okun z eksenindeki dönüş açısını al
            ball.Shoot(aci);
            Debug.Log("Okun dönüş açısı: " + aci); // dönüş açısını Debug.Log ile yazdır
            Destroy(gameObject); // kendini sil
        }
       
        if (donusYonuIleri)
        {
            aci += donmeHizi * Time.deltaTime;
            aci = Mathf.Clamp(aci, minAci, maxAci); // açıyı minAci ve maxAci arasında sınırla
            transform.rotation = Quaternion.Euler(0, 0, aci);

            if (aci >= maxAci)
            {
                donusYonuIleri = false;
            }
        }
        else
        {
            aci -= donmeHizi * Time.deltaTime;
            aci = Mathf.Clamp(aci, minAci, maxAci); // açıyı minAci ve maxAci arasında sınırla
            transform.rotation = Quaternion.Euler(0, 0, aci);

            if (aci <= minAci)
            {
                donusYonuIleri = true;
            }
        }

        // objeyi hareket ettir
        if (hareketYonuIleri)
        {
            transform.Translate(0, 0, hareketMesafesi * Time.deltaTime);
        }
        else
        {
            transform.Translate(0, 0, -hareketMesafesi * Time.deltaTime);
        }

        // objenin hareket yönünü değiştir
        if (transform.position.z >= maxAci)
        {
            hareketYonuIleri = false;
        }
        else if (transform.position.z <= minAci)
        {
            hareketYonuIleri = true;
        }
    }

    
}