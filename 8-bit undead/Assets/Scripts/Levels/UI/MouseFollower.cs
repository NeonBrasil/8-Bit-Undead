using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    private Camera mainCamera;
    public GameObject arma;
    public GameObject lojaPanel;
    bool podeColocar = true;
    LayerMask layerTorreOuCaminho;

    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false; // Esconde o cursor original
        layerTorreOuCaminho = LayerMask.GetMask("Tower", "Path");
    }

    void Update()
    {
       
       Collider2D colisor = Physics2D.OverlapCircle(gameObject.transform.position, gameObject.GetComponent<CircleCollider2D>().radius, layerTorreOuCaminho);

        if(colisor != null){
            podeColocar = false;
        }
        else{
            podeColocar = true;
        }
        Mover_Arma();

    }

    void Mover_Arma(){
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0f;
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);
        worldPos.z = 0f; // Garante que fique no plano correto
        transform.position = worldPos;
        if(Input.GetMouseButtonDown(0) && arma != null && podeColocar){
            Instantiate(arma, worldPos, Quaternion.identity);
            Cursor.visible = true;
            lojaPanel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
