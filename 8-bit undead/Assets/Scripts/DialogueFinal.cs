using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class DialogueFinal : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines = { "Depois de horas de terror voc� finalmente acorda.",
    "Voc� estava em coma por ter ingerido quantidades massivas de amaciante de roupa...","Nem os m�dicos sabiam o porque... Mas voc� ficou muito louco.",
    "Voc� acabou alucinando tudo que viu. Achava que estava a lutar contra zumbis, quando na verdade..." , "Voc� estava freneticamente lutando contra bichinhos de pel�cia de uma loja.",
    "As pessoas chamaram a pol�cia, que te deu uns choques e te apagou." , "Voc� ficou desacordado por 3 horas mas finalmente est� tudo bem.",
    "Voc� ent�o decidiu sair do hospital sem pagar nenhuma das contas e usar todo seu dinheiro restante para se mudar para uma ilha tropical.","Aqui as bebidas s�o uma delicia, pessoas educadas e comida saborosa.",
    "Ser� que um dia v�o te encontrar? Quem sabe...","O importante � voc� aproveitar o momento...","Voc�", "O mar",
    "E uma deliciosa Pina Colada", "A �nica d�vida que resta em sua mente �... De onde viam aquelas m�sicas..."};
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
            gameObject.SetActive(false); // Fecha a caixa de di�logo
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
