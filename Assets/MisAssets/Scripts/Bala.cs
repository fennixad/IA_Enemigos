using UnityEngine;

/// <summary>
/// DESCRIPCION:
/// 
/// </summary>

public class Bala : MonoBehaviour
{
// ***********************************************
    #region 1) Definicion de variables

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
        
    }
    #endregion
    // ***********************************************
    #region 3) Funciones originales
    private void OnCollisionEnter(Collision collision)
    {
        // La bala sola se destruye al detectar lo que sea
        Destroy(gameObject);
    }
    #endregion
    // ***********************************************
}
