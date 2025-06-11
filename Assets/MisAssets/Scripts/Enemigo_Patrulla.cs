using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// DESCRIPCION:
/// 
/// </summary>

public class Enemigo_Patrulla : MonoBehaviour
{
    // ***********************************************
    #region 1) Definicion de variables
    Transform conjuntoParadas;
    public int paradaActual;

    NavMeshAgent agente;
    Animator anim;
    #endregion
    // ***********************************************
    #region 2) Funciones de Unity
    private void Awake()
    {
        conjuntoParadas = transform.parent.GetChild(1);
        agente = GetComponent<NavMeshAgent>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IrParadaActual();
    }

    // Update is called once per frame
    void Update()
    {
        if (HaLLegadoParada())
        {
            SiguienteParada();
            StartCoroutine(EsperandoCoro());
        }
    }

    private void OnDrawGizmos()
    {

        conjuntoParadas = transform.parent.GetChild(1);
        int numParadas = conjuntoParadas.childCount;

        for (int i = 0; i < numParadas; i++)
        {
            if (i + 1 < numParadas) {

                Transform a = conjuntoParadas.GetChild(i);
                Transform b = conjuntoParadas.GetChild(i + 1);
                Debug.DrawLine(a.position, b.position, Color.red);
            }
            else
            {
                Transform a = conjuntoParadas.GetChild (numParadas - 1);
                Transform b = conjuntoParadas.GetChild(0);
                Debug.DrawLine (a.position, b.position, Color.red);
            }       
        }
    }
    #endregion
    // ***********************************************
    #region 3) Funciones originales
    IEnumerator EsperandoCoro()
    {
        float esperaAleatoria = Random.Range(0.5f, 2.5f);

        anim.SetBool("camina", false);
        yield return new WaitForSeconds(esperaAleatoria);
        IrParadaActual();
    }

    void IrParadaActual()
    {
        anim.SetBool("camina", true);
        agente.SetDestination(conjuntoParadas.GetChild(paradaActual).position);
    }

    void SiguienteParada()
    {
        int numParadas = conjuntoParadas.childCount;
        if (paradaActual + 1 < numParadas) paradaActual++;
        else paradaActual = 0;
    }

    bool HaLLegadoParada()
    {
        float distancia = Vector3.Distance(transform.position, PosParadaActual());
        Debug.Log($"Distancia entre enemigo y parada actual {distancia}");
        return distancia < 0.1f;
    }

    Vector3 PosParadaActual()
    {
        return conjuntoParadas.GetChild(paradaActual).position;
    }
    #endregion
    // ***********************************************
}
