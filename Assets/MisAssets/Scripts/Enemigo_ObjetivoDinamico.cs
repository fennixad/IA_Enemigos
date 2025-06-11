using System.Collections;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// DESCRIPCION:
/// 
/// </summary>

[RequireComponent(typeof(NavMeshAgent))]
public class Enemigo_ObjetivoDinamico : MonoBehaviour
{
    // ***********************************************
    #region 1) Definicion de variables
    public bool modoSeguimiento;

    NavMeshAgent agente;
    GameObject player;

    Coroutine seguimientoCoro;
    #endregion
    // ***********************************************
    #region 2) Funciones de Unity
    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            modoSeguimiento = !modoSeguimiento;

            if (modoSeguimiento) EmpezarCorrutina();
            else TerminarCorrutina();
        }
    }
    #endregion
// ***********************************************
    #region 3) Funciones originales
    void EmpezarCorrutina()
    {
        if (seguimientoCoro == null) seguimientoCoro = StartCoroutine(SeguimientoCoro());
    }

    void TerminarCorrutina()
    {
        if (seguimientoCoro != null)
        {
            StopCoroutine(seguimientoCoro);
            seguimientoCoro = null;
        }
    }

    IEnumerator SeguimientoCoro()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            agente.SetDestination(player.transform.position);
        }
    }

    #endregion
// ***********************************************
}
