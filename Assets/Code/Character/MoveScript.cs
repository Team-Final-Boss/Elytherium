using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
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

    
    void FixedUpdate()
    {

        Movimentacao();
              

    }
   

    void Movimentacao() {

    float moveZ = 0f;
    float moveX = 0f;

    if (Input.GetKey(KeyCode.UpArrow))
        moveZ = 1f;

    if (Input.GetKey(KeyCode.DownArrow))
        moveZ = -1f;

    if (Input.GetKey(KeyCode.LeftArrow))
        moveX = -1f;

    if (Input.GetKey(KeyCode.RightArrow))
        moveX = 1f;

    Vector3 movimento = transform.forward * moveZ + transform.right * moveX;
    movimento.y = 0;
    movimento.Normalize();

    corpo.linearVelocity = new Vector3(
        movimento.x * velocidade,
        corpo.linearVelocity.y,
        movimento.z * velocidade
    );
        

        
    }

  

}
