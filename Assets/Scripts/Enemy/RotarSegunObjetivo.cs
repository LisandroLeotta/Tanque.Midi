using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Descripcion:
 * Se encarga de rotar al objeto que lo contega,
 * segun la posicion de un objetivo asignado.
 */
public class RotarSegunObjetivo : MonoBehaviour
{
    [Header("Set Objetive")]
    [SerializeField] private Transform objetive;
    [SerializeField] private bool isCenitnella;

    [Header("Set Centinella")]
    [SerializeField] private float alertRange;
    [SerializeField] private LayerMask layerObjetive;
    [SerializeField] private float atacSpeed;
    private bool isAlert;

    private void Update()
    {
        if (isCenitnella)
        {
            isAlert = Physics.CheckSphere(transform.position, alertRange, layerObjetive);
            if (isAlert)
            {
                Vector3 positionObjetive = new Vector3 (objetive.position.x, transform.position.y, objetive.position.z);
                transform.LookAt(positionObjetive);
                transform.position = Vector3.MoveTowards(transform.position, positionObjetive, atacSpeed);
            }
        }
        else
        {
            Rotar();
        }
    }

    private void Rotar()
    {
        Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);                    //toma posicion del jugador.
        Vector3 objetiveOneScreen = (Vector2)Camera.main.WorldToViewportPoint(objetive.position);           //toma posicion del objetivo.

        Vector3 direction = objetiveOneScreen - positionOnScreen;                                           //calcula el vector o la distancia entre ambos puntos.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90.0f;                        //calcula los radianes y lo cmobierte a angulo.

        transform.rotation = Quaternion.Euler(0, -angle, 0);                                                 //Modifica la rotacion.
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, alertRange);
    }
}