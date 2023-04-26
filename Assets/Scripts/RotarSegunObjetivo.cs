using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Descripcion:
 * Se encarga de rotar al objeto que lo contega,
 * segun la posicion de un objetivo asignado.
 */
public class RotarSegunObjetivo : MonoBehaviour
{
    [SerializeField] private Transform objetive;

    private void Update()
    {
        Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);                    //toma posicion del jugador.

        Vector3 objetiveOneScreen = (Vector2)Camera.main.WorldToViewportPoint(objetive.position);           //toma posicion del objetivo.

        Vector3 direction = objetiveOneScreen - positionOnScreen;                                           //calcula el vector o la distancia entre ambos puntos.

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90.0f;                        //calcula los radianes y lo cmobierte a angulo.

        transform.rotation = Quaternion.Euler(0, -angle, 0);                                                 //Modifica la rotacion.
    }
}