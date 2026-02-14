using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookingAt1 : MonoBehaviour
{
    public Transform player; // arraste o Transform do jogador ou da câmera aqui
    public bool onlyY = true; // se true, só gira no eixo Y (ideal para objetos no chão)

    void Update()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
            direction.x = 0; 
            direction.z = 0; 

        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;
        }
    }
}
