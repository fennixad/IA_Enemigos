using UnityEngine;

/// <summary>
/// DESCRIPCION:
/// 
/// </summary>

public class CharacterControlerEmpuje : MonoBehaviour
{
    // ***********************************************
    #region 1) Definicion de variables
    public float pushPower;

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

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody o el rigidbody que tiene es kinematico o el objeto no tiene asignado el tag "Interactivo" se omita el resto de la función
        if (body == null || body.isKinematic || !hit.collider.CompareTag("Interactivos")) return;

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.AddForce(pushDir * pushPower, ForceMode.Impulse);
    }

    #endregion
    // ***********************************************
    #region 3) Funciones originales

    #endregion
    // ***********************************************
}
