using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveScript : MonoBehaviour
{
    public float velocidade = 6f;
    public float distanciaChao = 1.5f;
    public TextMeshProUGUI DashStamina;

    private ConfigScript configScript;

    private Rigidbody corpo;
    private bool noChao;

    public float dragForce = 3f;
    private RaycastHit hitChao;

    private float moveX = 0f;
    private float moveZ = 0f;
    private float tempoDash = -3f;
    void Start()
    {
        corpo = GetComponent<Rigidbody>();

        corpo.freezeRotation = true;
        corpo.interpolation = RigidbodyInterpolation.Interpolate;
        corpo.collisionDetectionMode = CollisionDetectionMode.Continuous;

        GameObject gm = GameObject.FindGameObjectWithTag("GameController");
        configScript = gm.GetComponent<ConfigScript>();

        DashStamina.text = "0";
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
        if (tempoDash <= 0f)
        {
            velocidade = 6f;
            moveX = 0f;
            moveZ = 0f;


            if (configScript.controls == 1)
            {
                if (Input.GetKey(KeyCode.W))
                    moveZ = 1f;

                if (Input.GetKey(KeyCode.S))
                    moveZ = -1f;

                if (Input.GetKey(KeyCode.A))
                    moveX = -1f;

                if (Input.GetKey(KeyCode.D))
                    moveX = 1f;
            }
            else if (configScript.controls == 0)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                    moveZ = 1f;

                if (Input.GetKey(KeyCode.DownArrow))
                    moveZ = -1f;

                if (Input.GetKey(KeyCode.LeftArrow))
                    moveX = -1f;

                if (Input.GetKey(KeyCode.RightArrow))
                    moveX = 1f;
            }
        }
       
        tempoDash -= Time.deltaTime;
        DashStamina.text = tempoDash.ToString();

        if (Input.GetKey(KeyCode.Space) && tempoDash < -2.9f)
        {
            velocidade = 40f;
            tempoDash = 0.15f;
        }

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
