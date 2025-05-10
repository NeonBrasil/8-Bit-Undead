using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static int money = 100;

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
