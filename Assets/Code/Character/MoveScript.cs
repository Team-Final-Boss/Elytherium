using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class MoveScript : MonoBehaviour
{
    public float velocidade = 6f;
    public float distanciaChao = 1.5f;
    public Image DashStamina;
    public Image FundoBarra;

    private ConfigScript configScript;

    private Rigidbody corpo;
    private bool noChao;

    public float dragForce = 3f;
    private RaycastHit hitChao;

    private float moveX = 0f;
    private float moveZ = 0f;

    private bool barraDashAparece = false;
    private float cronometroDash = -3f;
    private float tempoDash = 0.15f;
    private float intervaloDash = 3f;
    private float velocidadeDash = 40f;

    void Start()
    {
        corpo = GetComponent<Rigidbody>();

        corpo.freezeRotation = true;
        corpo.interpolation = RigidbodyInterpolation.Interpolate;
        corpo.collisionDetectionMode = CollisionDetectionMode.Continuous;

        GameObject gm = GameObject.FindGameObjectWithTag("GameController");
        configScript = gm.GetComponent<ConfigScript>();

        DashStamina.fillAmount = 0f;
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
        if (cronometroDash <= 0f)
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

        if (Input.GetKey(KeyCode.Space) && cronometroDash < intervaloDash * -1)
        {
            velocidade = velocidadeDash;
            cronometroDash = tempoDash;
            DashStamina.fillAmount = 0f;

            AdicionarBarraStamina();
        }

        cronometroDash -= Time.deltaTime;
        DashStamina.fillAmount = Mathf.Clamp(cronometroDash / 3 * -1, 0f, 1f);

        if(cronometroDash < intervaloDash * -1 - 1.5f)
        {
            RemoverBarraStamina();
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

    void RemoverBarraStamina()
    {
        Color cor1 = DashStamina.color;
        cor1.a = Mathf.MoveTowards(cor1.a, 0f, 1f * Time.deltaTime);
        DashStamina.color = cor1;

        Color cor2 = FundoBarra.color;
        cor2.a = 0f;
        FundoBarra.color = cor2;
    }

    void AdicionarBarraStamina()
    {
        Color cor2 = DashStamina.color;
        cor2.a = 1f;
        DashStamina.color = cor2;

        cor2 = FundoBarra.color;
        cor2.a = 1f;
        FundoBarra.color = cor2;
    }
}
