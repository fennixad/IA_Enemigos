using UnityEngine;

/// <summary>
/// DESCRIPCION:
/// 
/// </summary>

public class Pistola : MonoBehaviour
{
    // ***********************************************
    #region 1) Definicion de variables
    public Transform origen;
    public Rigidbody balaPrefab;

    Transform cam;

    public LayerMask mascara;


    [Range(1f, 25f)]
    public float fuerzaBala;

    [Range(1f, 50f)]
    public float distanciaMax;
    #endregion
    // ***********************************************
    #region 2) Funciones de Unity
    private void Awake()
    {
        cam = Camera.main.transform;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown (0))
        {
            Ray ray = new Ray(cam.position, cam.forward);
            bool resultado = Physics.Raycast(ray, out RaycastHit hit, distanciaMax, mascara);

            if (resultado)
            {
                // RAYCAST FRONTAL
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 1f);

                // Direccion de punto de origen a punto de contacto
                Vector3 dirHaciaContacto = hit.point - origen.position;
                Quaternion rotFrontal = Quaternion.LookRotation(dirHaciaContacto);
                CrearBala(rotFrontal);

                Debug.DrawRay(origen.position, dirHaciaContacto, Color.black, 1f);
                Debug.Log($"Raycast de pistola detecta: {hit.collider.name}");
            }
            else
            {

                Vector3 _a = origen.position;
                Vector3 _b = ray.origin + ray.direction * distanciaMax;
                Vector3 _dirHaciaB = _b - _a;
                Quaternion rotFrontal = Quaternion.LookRotation (_dirHaciaB);
                CrearBala(rotFrontal);

                // RAYCAST FRONTAL
                Debug.DrawRay(ray.origin, ray.direction * distanciaMax, Color.yellow, 1f);

                // Direccion de punto de origen a punto final
                Debug.DrawRay(_a, _dirHaciaB, Color.green, 2f);
            }            
        }
    }
    #endregion
    // ***********************************************
    #region 3) Funciones originales
    void CrearBala(Quaternion _dirFrontal)
    {
        Rigidbody balaClon = Instantiate(balaPrefab, origen.position, _dirFrontal);
        balaClon.AddForce(balaClon.transform.forward * fuerzaBala, ForceMode.VelocityChange);

        Destroy(balaClon, 10f);
    }

    #endregion
    // ***********************************************
}
