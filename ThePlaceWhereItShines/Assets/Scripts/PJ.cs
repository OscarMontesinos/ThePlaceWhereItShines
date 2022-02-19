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

        rotX = playerCamera.eulerAngles.x; // Recuperamos la rotacion "vertical" de la c�mara

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

        // M�todo que se encarga de actualizar la rotaci�n de la c�mara
        MovePlayerCamera();

    }

    private void FixedUpdate()
    {

        _rigidbody.velocity = transform.forward * speed * -inputMov.y  // Movimiento hacia adelante y atr�s del PJ
                              + transform.right * speed * inputMov.x  // Movimiento hacia izquierda y derecha del PJ
                              + new Vector3(0, _rigidbody.velocity.y, 0); // Para hacer que baje por la gravedad


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



}
