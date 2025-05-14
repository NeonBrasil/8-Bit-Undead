using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines = { "Na década de 2030 São Francisco ainda era símbolo de inovação e diversidade ,Mas nas entrelinhas da cidade viva ... crescia uma tensão invisível.", "Grupos radicais tomavam as ruas com teorias conspiratórias.Alegavam corrupção, manipulação e segredos obscuros do governo.Entre eles, nascia o enigmático Vulturis Oculi",
    "Cientistas renegados, ativistas, ex-agentes.Unidos por uma ideia:Destruir o sistema para salvar o mundo.","Nos subterrâneos, um plano ganhava forma.Uma arma bioquímica.Criada com precisão científica… e propósito sombrio.",
    "Seu criador: Dr. Malcolm Vetrani.Gênio em biotecnologia.Ferido por tragédias causadas pelo próprio governo." , "Ele acreditava em uma única verdade:O mundo atual é podre.Só a destruição pode purificá-lo.",
    "Enquanto a cidade ignorava os sinais… Desaparecimentos, infiltrações e experimentos avançavam. Ninguém agia a tempo." , "Então, veio o dia fatídico. Um lançamento aéreo disfarçado de missão humanitária. E o caos foi liberado.",
    "A arma foi ativada sobre a Ponte… Em horas, 99% da cidade caiu. E voltou… como mortos-vivos.","As ruas viraram inferno. Famílias se desfizeram em gritos. E a civilização… em ruínas.",
    "O governo hesitou. Mas logo reagiu com medo e desespero. A cidade foi isolada.","Nos bastidores, surgiu um novo plano: Se ninguém contivesse o surto…","São Francisco seria apagada com uma bomba nuclear.", "Agora, é uma corrida contra o tempo. Salve quem puder. Ou aceite o fim.",
    "Você é um dos últimos conscientes. A cura pode existir… Ou talvez só reste sobreviver.", "Dr. Vetrani observa. Ele acredita que está certo. A pergunta é: você acredita também?"};
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
            SceneManager.LoadScene("LevelSelect");
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
