using UnityEngine;

/// <summary>
/// DESCRIPCION:
/// 
/// </summary>

public class ControlObjetivo : MonoBehaviour
{
    // ***********************************************
    #region 1) Definicion de variables
    Vector2 input;
    #endregion
// ***********************************************
    #region 2) Funciones de Unity
    // Update is called once per frame
    void Update()
    {
        // 1) Accedo a los ejes virtuales y los almaceno
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // defino una direccion segun lo almacenado en los ejes virtuales
        Vector3 dir = new Vector3(input.x, 0f, input.y);
        dir.Normalize();

        // uso la direccion definida para trasladar al objeto a 4 u/s
        transform.Translate(dir * 4f * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R)) transform.position = new Vector3(0f, 0f, -8f);

    }
    #endregion
// ***********************************************
    #region 3) Funciones originales

    #endregion
// ***********************************************
}
