using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class spawner : MonoBehaviour
{
    public Transform planodeenemigo;

    public Transform puntodeaparicion;

    public float tiempoentreoleadas = 5f;

    private float contador = 1f ;

    public Text contadoroleada;

    //numero de bichos *elbichopelao
    private int[] oleadas = {3, 4, 2, 2};

    private int oleada = 0;

    private int numeroDeEnemgios ;

    void Update() {
        if (contador < 0f && oleada < 4)
        {
            StartCoroutine(SpawnWave());
            contador = tiempoentreoleadas;
        }
        contador -= Time.deltaTime;
        contadoroleada.text = Mathf.Round(contador).ToString();
    }


    IEnumerator SpawnWave (){
        numeroDeEnemgios = oleadas[oleada];
        oleada++;
        for (int i = 0; i < numeroDeEnemgios; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1.5f);
        }

    }
    void SpawnEnemy(){
        Instantiate(planodeenemigo, puntodeaparicion.position, puntodeaparicion.rotation);
    }
}
