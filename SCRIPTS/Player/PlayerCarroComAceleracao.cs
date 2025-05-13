using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCarroComAceleracao : MonoBehaviour
{
    public float aceleracaoInicial = 10f;  // Acelera��o inicial
    public float velocidadeMaxima = 30f;   // Velocidade m�xima
    public float rotacao = 100f;           // Velocidade de rota��o
    public float aceleracaoPorSegundo = 2f; // Quanto a acelera��o aumenta por segundo

    public float velocidadeAtual;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocidadeAtual = 0f; // Come�a parado
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        // Input de acelera��o (frente/tr�s)
        float inputVertical = Input.GetAxis("Vertical");

        // Aumenta a velocidade ao longo do tempo
        if (inputVertical != 0)
        {
            velocidadeAtual += aceleracaoPorSegundo * Time.fixedDeltaTime;
            velocidadeAtual = Mathf.Clamp(velocidadeAtual, 0f, velocidadeMaxima); // Limita a velocidade m�xima
        }

        // Move o carro para frente/tr�s
        rb.AddForce(transform.forward * inputVertical * aceleracaoInicial * velocidadeAtual * Time.fixedDeltaTime);

        // Input de rota��o (esquerda/direita)
        float inputHorizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * inputHorizontal * rotacao * Time.fixedDeltaTime);
    }
}
