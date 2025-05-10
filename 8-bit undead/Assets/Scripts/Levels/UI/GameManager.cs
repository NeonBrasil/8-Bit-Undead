using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static int money = 100;
    public GUISkin layout;
    void OnGUI () {
        GUI.skin = layout;
        GUIStyle estilo = new GUIStyle(GUI.skin.label);
        estilo.fontSize = 50; // Altere o tamanho aqui
        estilo.normal.textColor = Color.white;
            
        GUI.Label(new Rect(20, 20, 500, 500), "Denero " + money);
    }

    void OnEnable()
    {
        HealthComponent.OnDeath += HandleEnemyDeath;
    }

    void OnDisable()
    {
        HealthComponent.OnDeath -= HandleEnemyDeath; 
    }

    void HandleEnemyDeath(GameObject enemy)
    {
        var enemyBase = enemy.GetComponent<MoneyComponent>();
        if (enemyBase != null)
        {
            money += enemyBase.moneyReward;
            //Debug.Log($"Inimigo morto, ganhou {enemyBase.moneyReward}. Dinheiro total: {money}");
        }
    }

    public static void DecreaseMoney(int price){
        money -= price;
    }
}
