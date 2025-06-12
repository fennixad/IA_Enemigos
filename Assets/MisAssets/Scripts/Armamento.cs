using System;
using UnityEngine;

/// <summary>
/// DESCRIPCION:
/// 
/// </summary>

public class Armamento : MonoBehaviour
{
    // ***********************************************
    #region 1) Definicion de variables
    public int armaActual;
    public ArmaData[] armas;

    #endregion
// ***********************************************
    #region 2) Funciones de Unity
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MostrarArmaActual();
    }

    // Update is called once per frame
    void Update()
    {
        if (SeleccionDeArma(out int armaSeleccionada))
        {
            Debug.Log($"Presionas la tecla del arma {armaSeleccionada}");

            Debug.Log($"El arma esta desbloqueada? {ArmaDesbloqueada(armaSeleccionada)}");

            if (ArmaDesbloqueada(armaSeleccionada))
            {
                armaActual = armaSeleccionada; 
                MostrarArmaActual();
            }
        }
    }
    #endregion
// ***********************************************
    #region 3) Funciones originales
    bool SeleccionDeArma(out int indice)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            indice = 0;
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            indice = 1;
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            indice = 2;
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            indice = 3;
            return true;
        }

        indice = -1;
        return false;
    }

    bool ArmaDesbloqueada (int indice)
    {
        return armas[indice].armaDesbloqueada == true;
    }

    void MostrarArmaActual()
    {
        for (int i = 0; i < armas.Length; i++)
        {
            if (i == armaActual) armas[armaActual].arma.SetActive(true);
            else armas[i].arma.SetActive(false);
        }
    }


    #endregion
// ***********************************************
}

[Serializable]
public class ArmaData
{
    public bool armaDesbloqueada;
    public GameObject arma;
}
