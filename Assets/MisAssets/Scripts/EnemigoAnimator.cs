using UnityEngine;

/// <summary>
/// DESCRIPCION:
/// 
/// </summary>

public class EnemigoAnimator : MonoBehaviour
{
    // ***********************************************
    #region 1) Definicion de variables
    public Transform objetivo;
    [Range(0, 1f)]
    public float influenciaGeneral, influenciaCuerpo, influenciaCabeza;

    Animator anim;
    #endregion
    // ***********************************************
    #region 2) Funciones de Unity
    private void Awake()
    {
        anim = GetComponent<Animator>();
        objetivo = Camera.main.transform;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnAnimatorIK()
    {
        anim.SetLookAtPosition(objetivo.position);
        anim.SetLookAtWeight(influenciaGeneral, influenciaCuerpo, influenciaCabeza);
    }
    #endregion
    // ***********************************************
    #region 3) Funciones originales

    #endregion
    // ***********************************************
}
