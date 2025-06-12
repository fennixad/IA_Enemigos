using UnityEngine;

/// <summary>
/// DESCRIPCION:
/// 
/// </summary>

[RequireComponent (typeof(RaycastAbanico))]
public class Enemigo_Ataca : MonoBehaviour
{
    // ***********************************************
    #region 1) Definicion de variables
    RaycastAbanico raycastScript;

    public enum Estados{ Reposo, AtacaPlayer, Muerto}
    public Estados estado;

    Animator anim;
    
    #endregion
    // ***********************************************
    #region 2) Funciones de Unity
    private void Awake()
    {
        raycastScript = GetComponent<RaycastAbanico>();
        anim = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (estado == Estados.Reposo && raycastScript.PlayerDetectado())
        {
            CambioEstado(Estados.AtacaPlayer);
        }

        if (estado == Estados.AtacaPlayer && !raycastScript.PlayerDetectado())
        {
            CambioEstado(Estados.Reposo);
        }
    }
    #endregion
// ***********************************************
    #region 3) Funciones originales
    public void CambioEstado (Estados nuevoEstado)
    {
        estado = nuevoEstado;
        Debug.Log($"Estado Enemigo = <color=green>{estado}</color>");

        switch (estado)
        {
            case Estados.Reposo:

                anim.SetBool("atacando", false);
                break;
            case Estados.AtacaPlayer:

                anim.SetBool("atacando", true);

                break;
            case Estados.Muerto:
                break;
        }
    }

    #endregion
    // ***********************************************
}
