using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveScript : MonoBehaviour
{
    public float velocidade = 6f;
    public float distanciaChao = 1.5f;

    private Rigidbody corpo;
    private bool noChao;

    public float dragForce = 3f;
    private RaycastHit hitChao;

    void Start()
    {
        corpo = GetComponent<Rigidbody>();

        corpo.freezeRotation = true;
        corpo.interpolation = RigidbodyInterpolation.Interpolate;
        corpo.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void Update()
    {
        // Raycast sai um pouco mais baixo (perto do pé da cápsula)
        Vector3 origem = transform.position + Vector3.down * 0.5f;

        noChao = Physics.Raycast(origem, Vector3.down, out hitChao, distanciaChao);
    }

    void FixedUpdate()
    {
        Movimentacao();
          corpo.AddForce(Vector3.down * dragForce, ForceMode.Acceleration);
    }

    void Movimentacao()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
            moveZ = 1f;

        if (Input.GetKey(KeyCode.DownArrow))
            moveZ = -1f;

        if (Input.GetKey(KeyCode.LeftArrow))
            moveX = -1f;

        if (Input.GetKey(KeyCode.RightArrow))
            moveX = 1f;

        Vector3 direcao = transform.forward * moveZ + transform.right * moveX;
        direcao.Normalize();

        Vector3 velocidadeAtual = corpo.linearVelocity;

        if (noChao)
        {
            Vector3 movimentoNaRampa = Vector3.ProjectOnPlane(direcao, hitChao.normal);

            velocidadeAtual.x = movimentoNaRampa.x * velocidade;
            velocidadeAtual.z = movimentoNaRampa.z * velocidade;
        }
        else
        {
            // Controle no ar reduzido
            velocidadeAtual.x = direcao.x * velocidade * 0.5f;
            velocidadeAtual.z = direcao.z * velocidade * 0.5f;
        }

        corpo.linearVelocity = velocidadeAtual;
    }
}
