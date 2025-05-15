using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class DialogueFinal : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines = { "Depois de horas de terror você finalmente acorda.",
    "Você estava em coma por ter ingerido quantidades massivas de amaciante de roupa...","Nem os médicos sabiam o porque... Mas você ficou muito louco.",
    "Você acabou alucinando tudo que viu. Achava que estava a lutar contra zumbis, quando na verdade..." , "Você estava freneticamente lutando contra bichinhos de pelúcia de uma loja.",
    "As pessoas chamaram a polícia, que te deu uns choques e te apagou." , "Você ficou desacordado por 3 horas mas finalmente está tudo bem.",
    "Você então decidiu sair do hospital sem pagar nenhuma das contas e usar todo seu dinheiro restante para se mudar para uma ilha tropical.","Aqui as bebidas são uma delicia, pessoas educadas e comida saborosa.",
    "Será que um dia vão te encontrar? Quem sabe...","O importante é você aproveitar o momento...","Você", "O mar",
    "E uma deliciosa Pina Colada", "A única dúvida que resta em sua mente é... De onde viam aquelas músicas..."};
    public float textSpeed = 5f;
    private int index;

    void Start()
    {
        StartDialog();
    }

    void StartDialog()
    {
        index = 0;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false); // Fecha a caixa de diálogo
            SceneManager.LoadScene("Sample Scene");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
}
