using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torreta : MonoBehaviour
{
    public Transform apuntado;
    public Transform rotacion;
    public GameObject balaPre;
    public Transform puntodedisparo;

    [Header("disparar")]

    public float rango = 3f;
    public float velocidadedisparo = 1f;
    private float cuentadedisparo = 0f;

    void Start() {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);    
    }

    void UpdateTarget (){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float caminocorto = Mathf.Infinity;
        GameObject enemigomascercano = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy< caminocorto){
                caminocorto = distanceToEnemy;
                enemigomascercano = enemy;
            }
        }
        if (enemigomascercano != null && caminocorto <= rango)
        {
            apuntado = enemigomascercano.transform;
        }
        else
        {
            apuntado = null;
        }
    }

    void Update (){

        if(apuntado == null)
            return; 

        /*Vector3 dir = apuntado.position - transform.position;
        Quaternion lookRotation =  Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles; */
        //rotacion.rotation = Quaternion.Euler(0f,0f, rotation.z);
        transform.right = apuntado.position - transform.position;
        if (cuentadedisparo <= 0)
        {
            Disparar();
            cuentadedisparo = 1f / velocidadedisparo;          
        }

        cuentadedisparo -= Time.deltaTime;
    }

    void Disparar(){
        GameObject bulletGO = (GameObject)Instantiate(balaPre, puntodedisparo.position, puntodedisparo.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Buscar(apuntado);
        else
        return;
    }


    void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, rango);
    }

}
