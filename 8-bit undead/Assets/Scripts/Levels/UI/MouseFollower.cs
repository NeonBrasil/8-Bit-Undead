using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    private Camera mainCamera;
    public GameObject arma;

    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false; // Esconde o cursor original
    }

    void Update()
    {
        
        Mover_Arma();

    }

    void Mover_Arma(){
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0f;
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);
        worldPos.z = 0f; // Garante que fique no plano correto
        transform.position = worldPos;
        if(Input.GetMouseButtonDown(0) && arma != null){
            Instantiate(arma, worldPos, Quaternion.identity);
            Cursor.visible = true;
            Destroy(gameObject);
        }
    }
}
