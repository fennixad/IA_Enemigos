using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public GameObject arma;

    public GameObject hud;
    public Image barraVida;
    public TextMeshProUGUI barraVidaText;

    Animator anim;

    [Header("-------------")]
    public float vida;
    public float vidaMax;
    #endregion
    // ***********************************************
    #region 2) Funciones de Unity
    private void Awake()
    {
        raycastScript = GetComponent<RaycastAbanico>();
        anim = GetComponent<Animator>();

        vida = vidaMax;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VisibilidadHud(true);
        ActualizarBarraVida();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Balas"))
        {
            EnemigoRecibeBalazo(50f);
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

                VisibilidadHud(false);
                anim.SetTrigger("muerto");
                break;
        }
    }

    public void EnemigoRecibeBalazo(float _impacto)
    {
        if (estado != Estados.Muerto)
        {
            vida -= _impacto;
            ActualizarBarraVida();

            if (vida <= 0f) CambioEstado(Estados.Muerto);
        }
    }

    public void ActualizarBarraVida()
    {
        float _vidaNormalizada = vida / vidaMax;
        barraVida.fillAmount = _vidaNormalizada;

        barraVidaText.text = $"{vida}/{vidaMax}";
    }

    void VisibilidadHud (bool _esVisible)
    {
        hud.SetActive(_esVisible);
    }

    public void DesactivarArma()
    {
        //arma.SetActive(false);

        arma.GetComponent<Collider>().isTrigger = false;
        arma.GetComponent<Rigidbody>().useGravity = true;
        arma.GetComponent<Rigidbody>().isKinematic = false;

        arma.transform.SetParent(null);
    }

    public void FinAnimacionMuerte()
    {
        Destroy(gameObject);
    }

    #endregion
    // ***********************************************
}
