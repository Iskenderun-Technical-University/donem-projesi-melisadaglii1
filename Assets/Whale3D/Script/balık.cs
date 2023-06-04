using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class balık : MonoBehaviour
{
    public Rigidbody rb;
    public float speed =10f;
  
   
    public int puan = 0;
    public TextMeshProUGUI puanGoster;
    AudioSource audioSource;

    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    
    void Update()
    {
        
        float xHorizontal = Input.GetAxis("Horizontal");
       float zVertical = Input.GetAxis("Vertical");
        Vector3 moveSystem = new Vector3(xHorizontal, 0.0f, zVertical);
        transform.position += moveSystem * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag=="altın")
        {
            puan++;
            Destroy(other.gameObject);
            puanGoster.text = "Yem sayısı = " + puan;
        }
    }
     
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Engel")
        {
            Invoke("restart", 1f);
            audioSource.Play();
        }
    }
    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
