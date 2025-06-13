using UnityEngine;

/// <summary>
/// DESCRIPCION:
/// 
/// </summary>

public class RespawnEnemigo : MonoBehaviour
{
    // ***********************************************
    #region 1) Definicion de variables
    public Transform enemigoPrefab;

    public Vector3 tamanno;
    public int numEnemigos;

    #endregion
// ***********************************************
    #region 2) Funciones de Unity
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            for (int i = 0; i < numEnemigos; i++)
            {
                float izqX = transform.position.x - tamanno.x * .5f;
                float derX = transform.position.x + tamanno.x * .5f;

                float izqZ = transform.position.z - tamanno.z * .5f;
                float derZ = transform.position.z + tamanno.z * .5f;

                float randomX = Random.Range(izqX, derX);
                float randomZ = Random.Range(izqZ, derZ);

                float _y = transform.position.y;

                //Vector3 posDer = transform.position + transform.right * 2f * i;
                Vector3 posClon = new Vector3(randomX, _y, randomZ);
                Transform enemigoClonado = Instantiate(enemigoPrefab, posClon, transform.rotation);
            }
        }
    }
    #endregion
    // ***********************************************
    #region 3) Funciones originales
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, tamanno);
    }

    #endregion
    // ***********************************************
}
