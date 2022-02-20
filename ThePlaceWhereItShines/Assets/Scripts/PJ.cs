using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJ : MonoBehaviour
{
    // Atributes
    [SerializeField] private float speed;
    [SerializeField] private float speedFast;
    [SerializeField] private float sensiblityMouse;
    [SerializeField] private Transform playerCamera;


    private Vector2 inputMov;
    private Vector2 inputRot;
    private Rigidbody _rigidbody;
    private float rotX;
    public AudioSource pasosAudio;
    public float paso;
    Interactuador inter;

    public bool grounded;


    void Start()
    {
        inter = transform.GetChild(1).transform.GetChild(0).GetComponent<Interactuador>();
        Cursor.lockState = CursorLockMode.Locked;
        // Recuperamos el componente Rigidbody del player para poder trabajar con el
        _rigidbody = GetComponent<Rigidbody>();

        rotX = playerCamera.eulerAngles.x; // Recuperamos la rotacion "vertical" de la c�mara

        Physics.gravity = new Vector3(0, -72f, 0);
    }

    void Update()
    {
        paso += Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift) && !inter.cristal)
        {
            paso += Time.deltaTime;
        }
        if (paso > 0.85f)
        {
            paso = 0;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                if (grounded)
                {
                    pasosAudio.Play();
                    if (pasosAudio.pitch == 1)
                    {
                        pasosAudio.pitch = 1.50f;
                    }
                    else
                    {
                        pasosAudio.pitch = 1;
                    }
                }
            }
        }
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            
            _rigidbody.AddForce(new Vector3(0, 30, 0), ForceMode.Impulse);
            grounded = false;
        }

        // Leemos los inputs para el desplazamiento del jugador
        inputMov.x = Input.GetAxis("Horizontal");
        inputMov.y = Input.GetAxis("Vertical");

        // Leemos los inputs para la rotacion del jugador
        inputRot.x = Input.GetAxis("Mouse X") * sensiblityMouse;
        inputRot.y = Input.GetAxis("Mouse Y") * sensiblityMouse;

        // M�todo que se encarga de actualizar la rotaci�n de la c�mara
        MovePlayerCamera();

    }

    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftShift) && !inter.cristal)
        {
            _rigidbody.velocity = transform.forward * speedFast * -inputMov.y  // Movimiento hacia adelante y atr�s del PJ
                              + transform.right * speedFast * inputMov.x  // Movimiento hacia izquierda y derecha del PJ
                              + new Vector3(0, _rigidbody.velocity.y, 0); // Para hacer que baje por la gravedad
        }
        else
        {
            _rigidbody.velocity = transform.forward * speed * -inputMov.y  // Movimiento hacia adelante y atr�s del PJ
                              + transform.right * speed * inputMov.x  // Movimiento hacia izquierda y derecha del PJ
                              + new Vector3(0, _rigidbody.velocity.y, 0); // Para hacer que baje por la gravedad
        }


    }


    public void MovePlayerCamera()
    {
        rotX -= inputRot.y;
        rotX = Mathf.Clamp(rotX, -65, 65); // Establecemos l�mites en la rotaci�n vertical de la c�mara
        transform.Rotate(0, inputRot.x * -sensiblityMouse, 0f); // Rotaci�n horizontal de la c�mara
        playerCamera.transform.localRotation = Quaternion.Euler(rotX +180, 0f, 0f); // Rotaci�n vertical de la c�mara
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Empezar")
        {
            Debug.Log("ey");
            inter.contar = true;
        }
    }




}
