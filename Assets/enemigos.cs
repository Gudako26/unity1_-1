using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigos : MonoBehaviour
{
    public float speed = 2f;
    private Transform destino;
    private int contendodepuntos = 0;



    private void Start() {
        destino = Waypoints.puntos[0];
    }

    void Update() {
        Vector3 dir= destino.position - transform.position;
        transform.Translate(dir.normalized* speed * Time.deltaTime); 

        if (Vector3.Distance(transform.position, destino.position) <= 0.1f)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint(){
        if(contendodepuntos >= Waypoints.puntos.Length-1){
            Destroy(gameObject);
            return;
        }
        contendodepuntos++;
        destino = Waypoints.puntos[contendodepuntos];
    }
}
