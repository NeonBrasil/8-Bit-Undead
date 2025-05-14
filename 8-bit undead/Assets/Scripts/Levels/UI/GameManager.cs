using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static int money = 100;
    public static int lifes = 5;
    public int kills_to_win = 1;
    public static int enemies_killed = 0;
    public GUISkin layout;
    void OnGUI () {
        GUI.skin = layout;
        GUIStyle estilo = new GUIStyle(GUI.skin.label);
        estilo.fontSize = 50; // Altere o tamanho aqui
        estilo.normal.textColor = Color.white;
            
        GUI.Label(new Rect(20, 20, 500, 500), "Dinheiro " + money);
        GUI.Label(new Rect(500, 20, 500, 500), "Vidas " + lifes);
        GUI.Label(new Rect(900, 20, 500, 500), "Inimigos Mortos " + enemies_killed);

    }

    void Update()
    {
        Lose();
        Win();
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

    public static void DecreaseLife(int damage){
        lifes -= damage;
    }

    public static void IncreaseKills(){
        enemies_killed++;
    }

    public void Lose(){
        if(lifes <= 0){
            SceneManager.LoadScene("GameOver"); 
        }  
    }


    public void Win(){
        if(enemies_killed >= kills_to_win){
            if(SceneManager.GetActiveScene().name == "Level_1"){
                SceneManager.LoadScene("Level_2");
                enemies_killed = 0;
                money += 100;
            }
            else if(SceneManager.GetActiveScene().name == "Level_2"){
                SceneManager.LoadScene("Level_3");
                enemies_killed = 0;
                money += 200;
            }
            else if(SceneManager.GetActiveScene().name == "Level_3"){
                SceneManager.LoadScene("Level_4");
                enemies_killed = 0;
                money += 300;
            }
            else if(SceneManager.GetActiveScene().name == "Level_4"){
                SceneManager.LoadScene("Win");
                enemies_killed = 0;
            }
        }
        
    }
}
