using UnityEngine;

public class GunsShop : MonoBehaviour
{
    public GameObject lojaPanel;

    public GameObject mouseFollowerPrefab;
    public void BuyItem(ItemButton item){
        if(GameManager.money >= item.price){
            GameManager.DecreaseMoney(item.price);
            GameObject seguidor = Instantiate(mouseFollowerPrefab);
            MouseFollower followerScript = seguidor.GetComponent<MouseFollower>();
            seguidor.GetComponent<SpriteRenderer>().sprite = item.sprite_arma;
            followerScript.arma = item.arma;
            followerScript.lojaPanel = lojaPanel;
            lojaPanel.SetActive(false);
        }
        else{
            Debug.Log("Pobre AHAHAHHAHAHA");
        }
        
    }
}
