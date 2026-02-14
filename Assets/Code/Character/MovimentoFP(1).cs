using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoFP : MonoBehaviour
{
    public Transform PlayerTransform;
    private Rigidbody corpo;
    public float velocidade = 5f;
    private bool noChao;




    //camera
    public Transform CameraTransform;
    Vector2 rotacaoMouse;
   
    
    
    void Start()
    {
        
        corpo = gameObject.GetComponent<Rigidbody>();
        
        
    }

    
    void Update()
    {

        Movimentacao();
              

    }
   

    void Movimentacao() {

        corpo.linearVelocity = new Vector3(0, corpo.linearVelocity.y, 0);
        
        

        if (Input.GetKey(KeyCode.W))
        {
            
            corpo.linearVelocity = new Vector3(transform.forward.x * velocidade, corpo.linearVelocity.y, transform.forward.z * velocidade);
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            corpo.linearVelocity = new Vector3(-transform.forward.x * velocidade, corpo.linearVelocity.y, -transform.forward.z * velocidade);



        }
        if (Input.GetKey(KeyCode.A))
        {
            corpo.linearVelocity = new Vector3(-transform.right.x * velocidade, corpo.linearVelocity.y, -transform.right.z * velocidade);

        }
        if (Input.GetKey(KeyCode.D))
        {
            corpo.linearVelocity = corpo.linearVelocity = new Vector3(transform.right.x * velocidade, corpo.linearVelocity.y, transform.right.z * velocidade);

        }
        
    }

    

    void OnTriggerEnter(Collider other)
    {
        
            noChao = true;
            Debug.Log("No ch�o");
            


        
    }

    void OnTriggerExit(Collider other)
    {
        
            noChao = false;
            

            Debug.Log("No ar");




        
    }

  

}
