using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public TextMeshProUGUI FeetTextMeshPro;
    public TMP_Text moneyText;
    public TMP_Text needMoney1;
    private int nedMoney1;
    public Animator _animator;

    
    public float vurusGucu=20;
    private Rigidbody2D rb;

    private int money;

    private int ft;
    //public float vurusAci;
    private void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         
         SetText(PlayerPrefs.GetInt("money",0));
         vurusGucu = PlayerPrefs.GetFloat("Vurus", 20);
         nedMoney1 = PlayerPrefs.GetInt("StrengthMoney", 50);
         
         needMoney1.text = nedMoney1.ToString();
    }
    private void Update()
    {
        ft = (int)transform.position.x+4;
        FeetTextMeshPro.text =  ft +"ft";
        // atışın yönünü düzeltmek için sürekli olarak dönüş yap
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }//atış 
    public void Shoot (float vurusAci)
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        float radians = vurusAci * Mathf.Deg2Rad; // convert degrees to radians
        Vector2 shotVelocity = new Vector2(vurusGucu * Mathf.Cos(radians), vurusGucu * Mathf.Sin(radians));
        rb.velocity = shotVelocity;
        //Debug.Log("Shot velocity: " + rb.velocity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.CompareTag("Hole"))
            {
                Debug.Log("Interactable object detected!");
                PanelUp();
            }
    }

    public void PanelUp()
    {
        _animator.SetBool("is up", true);

    }

    public void PanelDown()
    {
        _animator.SetBool("is up", false);
        SetText(ft);
        StartCoroutine(WaitForNewScene());

    }

    private void SetText(int moneyCount)
    {
        money += moneyCount;
        moneyText.text = money.ToString();
        PlayerPrefs.SetInt("money",money);
    }

    IEnumerator WaitForNewScene()
    {
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(0);
    }

    public void Strength()
    {
        if (money >= nedMoney1)
        {
            SetText(-nedMoney1);
            nedMoney1 *= 2;
            PlayerPrefs.SetInt("StrengthMoney",nedMoney1);
            vurusGucu += 1;      
            PlayerPrefs.SetFloat("Vurus",vurusGucu);
            needMoney1.text = nedMoney1.ToString();

        }
    }
  
    
}
