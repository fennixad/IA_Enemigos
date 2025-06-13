using UnityEngine;

/// <summary>
/// DESCRIPCION:
/// 
/// </summary>

public class EnemigoHitBox : MonoBehaviour
{
    // ***********************************************
    #region 1) Definicion de variables
    public Enemigo_Ataca scriptEnemigo;
    public float impacto;

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
        if (collision.collider.CompareTag("Balas"))
        {
            scriptEnemigo.EnemigoRecibeBalazo(impacto);
        }
    }
    #endregion
    // ***********************************************
}
