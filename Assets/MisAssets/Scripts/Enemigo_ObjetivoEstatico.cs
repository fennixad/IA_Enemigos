using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// DESCRIPCION: Al hacer clic izquierdo con el raton sobre el suelo, el enemigo se desplaza navegando por la malla bakeada
/// y su 
/// 
/// </summary>

[RequireComponent(typeof(NavMeshAgent))]
public class Enemigo_ObjetivoEstatico : MonoBehaviour
{
    // ***********************************************
    #region 1) Definicion de variables
    NavMeshAgent agente;
    Vector3 puntoOrigen;

    #endregion
    // ***********************************************
    #region 2) Funciones de Unity
    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        puntoOrigen = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // AL HACER CLIC IZQUIERDO DEL RATO...
        if (Input.GetMouseButtonDown(0)) DetectorSuelo();
    }
    #endregion
// ***********************************************
    #region 3) Funciones originales
    void DetectorSuelo()
    {
        // Se crea un rayo invisible que se origina en la posicion actual del raton y se
        // traslada desde la camara principal de la escena hacia delante
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool resultado = Physics.Raycast(ray, out RaycastHit hit, 500f);

        // El raycast detecta algo...
        if (resultado)
        {
            Debug.Log($"El raycast detecta: {hit.collider.name}");

            bool esSueloDetectado = hit.collider.CompareTag("Suelo");

            Color colorDetectado = esSueloDetectado ? Color.red : Color.yellow;
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, colorDetectado, 1f);

            Vector3 destino = esSueloDetectado == true ? hit.point : puntoOrigen;
            
            // al agente se le establece el destino "punto de contacto del rayo sobre el suelo"
            agente.SetDestination(destino);
        }
        else
        {
            Debug.Log($"El raycast no detecta nada");
            Debug.DrawRay(ray.origin, ray.direction * 500f, Color.blue, 1f);
            agente.SetDestination(puntoOrigen);
        }
    }
    #endregion
    // ***********************************************
}
