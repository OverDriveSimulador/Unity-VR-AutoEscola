using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovimento : MonoBehaviour
{
    public float velocidade = 5f;

    private Rigidbody rb;
    private Vector3 direcao;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // trava o cursor no centro da tela
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        direcao = transform.right * h + transform.forward * v;
    }

    void FixedUpdate()
    {
        Vector3 movimento = direcao.normalized * velocidade * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movimento);
    }
}
