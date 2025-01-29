using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 3f; // Velocidad de movimiento
    private Vector3 moveDirection = Vector3.forward; // Dirección inicial

    void Update()
    {
        // Mover al personaje en la dirección actual
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // Verificar si estamos cerca del borde del terreno
        if (!CheckGroundAhead())
        {
            ChangeDirection(); // Si no hay suelo adelante, cambiar de dirección
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Cambiar dirección al chocar con un objeto
        ChangeDirection();
    }

    bool CheckGroundAhead()
    {
        // Raycast desde el personaje hacia adelante y abajo para detectar suelo
        RaycastHit hit;
        Vector3 rayOrigin = transform.position + (moveDirection * 0.5f); // Posición adelante
        Vector3 rayDirection = Vector3.down; // Mirando hacia abajo

        if (Physics.Raycast(rayOrigin, rayDirection, out hit, 2f))
        {
            return hit.collider.CompareTag("Ground"); // Solo sigue si el objeto detectado es el terreno
        }
        
        return false; // No hay suelo adelante, debe cambiar de dirección
    }

    void ChangeDirection()
    {
        float randomAngle = Random.Range(90f, 180f); // Gira entre 90° y 180°
        transform.Rotate(0, randomAngle, 0);
        moveDirection = transform.forward; // Actualizar la dirección de movimiento
    }
}


