using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCarroComAceleracao : MonoBehaviour
{
    public float aceleracaoInicial = 10f;  // Aceleração inicial
    public float velocidadeMaxima = 30f;   // Velocidade máxima
    public float rotacao = 100f;           // Velocidade de rotação
    public float aceleracaoPorSegundo = 2f; // Quanto a aceleração aumenta por segundo

    public float velocidadeAtual;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocidadeAtual = 0f; // Começa parado
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        // Input de aceleração (frente/trás)
        float inputVertical = Input.GetAxis("Vertical");

        // Aumenta a velocidade ao longo do tempo
        if (inputVertical != 0)
        {
            velocidadeAtual += aceleracaoPorSegundo * Time.fixedDeltaTime;
            velocidadeAtual = Mathf.Clamp(velocidadeAtual, 0f, velocidadeMaxima); // Limita a velocidade máxima
        }

        // Move o carro para frente/trás
        rb.AddForce(transform.forward * inputVertical * aceleracaoInicial * velocidadeAtual * Time.fixedDeltaTime);

        // Input de rotação (esquerda/direita)
        float inputHorizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * inputHorizontal * rotacao * Time.fixedDeltaTime);
    }
}
