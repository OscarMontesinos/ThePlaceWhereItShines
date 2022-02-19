using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJ : MonoBehaviour
{
    // Atributes
    [SerializeField] private float speed;
    [SerializeField] private float sensiblityMouse;
    [SerializeField] private Transform playerCamera;


    private Vector2 inputMov;
    private Vector2 inputRot;
    private Rigidbody _rigidbody;
    private float rotX;

    bool grounded;


    void Start()
    {
        // Recuperamos el componente Rigidbody del player para poder trabajar con el
        _rigidbody = GetComponent<Rigidbody>();

        rotX = playerCamera.eulerAngles.x; // Recuperamos la rotacion "vertical" de la cámara

        Physics.gravity = new Vector3(0, -72f, 0);
    }

    void Update()
    {

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

        // Método que se encarga de actualizar la rotación de la cámara
        MovePlayerCamera();

    }

    private void FixedUpdate()
    {

        _rigidbody.velocity = transform.forward * speed * -inputMov.y  // Movimiento hacia adelante y atrás del PJ
                              + transform.right * speed * inputMov.x  // Movimiento hacia izquierda y derecha del PJ
                              + new Vector3(0, _rigidbody.velocity.y, 0); // Para hacer que baje por la gravedad


    }


    public void MovePlayerCamera()
    {
        rotX -= inputRot.y;
        rotX = Mathf.Clamp(rotX, -65, 65); // Establecemos límites en la rotación vertical de la cámara
        transform.Rotate(0, inputRot.x * -sensiblityMouse, 0f); // Rotación horizontal de la cámara
        playerCamera.transform.localRotation = Quaternion.Euler(rotX +180, 0f, 0f); // Rotación vertical de la cámara
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }



}
