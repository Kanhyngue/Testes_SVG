using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject menuPause;
    public GameObject confirmacao;
    public GameObject curiosidadesPanel;
    public GameObject opcoesPanel;
    [SerializeField]
    private Animator boxAnimator;
    [SerializeField]
    private GameObject PopUp; 
    private bool menuActive = false;
    private bool exitConfirmation = false;
    private bool opcoesConfirmation = false;
    private bool curiosidadesConfirmation = false;

    void LateUpdate()
    {
        // Enquanto a condição for falsa, o jogo espera que o jogador aperte o botão de pause
        if(!menuActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !Player.gameOver && boxAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Closed") && !PopUp.activeInHierarchy) // se o jogador apertar o botão de pause e ele não estiver morto o jogo pausa
            {
                Time.timeScale = 0.0001f; // time scale é colocado bem baixo para diminuir a velocidade de renderização
                menuPause.SetActive(true); // Painel contendo a interface de pause é ativado
                menuActive = true; // condição que indica que o jogo está pausado é tornado verdadeiro

                if(!exitConfirmation)
                {
                    confirmacao.SetActive(false);
                }
                
                if(!opcoesConfirmation)
                {
                    opcoesPanel.SetActive(false);
                }

                if(!curiosidadesConfirmation)
                {
                    curiosidadesPanel.SetActive(false);
                }
            }
        }
        else
        {
            // SE enquanto o jogo estiver pausado o jogador apertar no botão para despausar, logo o jogo despausa
            if(Input.GetKeyDown(KeyCode.Escape)) // Botão ESC para despausar
            {
                Continuar(); // Método para sair do menu de pause é colocado em execução
                
            }
        }
    }

    // Comando do botão para o jogador retomar ao jogo
    public void Continuar()
    {
        Time.timeScale = 1f; // time scale retorna ao normal
        menuPause.SetActive(false); // painel contendo a interface de pausa é desativado
        menuActive = false; // condição para otimização do script torna-se falsa
        exitConfirmation = false;
        opcoesConfirmation = false;
        curiosidadesConfirmation = false;
    }

    // Acessa o menu de opções dentro do menu de pause
    public void Opcoes()
    {
        opcoesPanel.SetActive(true);
        opcoesConfirmation = true;
    }

    // Acessa o menu de curiosidades dentro do menu de pause
    public void Curiosidades()
    {
        curiosidadesPanel.SetActive(true);
        curiosidadesConfirmation = true;
    }

    // Se o jogador optar por voltar ao Menu Principal e sair do gameplay, haverá uma mensagem de confirmação
    public void VoltarMenu()
    {
        confirmacao.SetActive(true);
        exitConfirmation = true;
    }

    // Se o jogador confirmar sua saída do jogo, e voltar para o menu principal, isso será feito mediante o método abaixo
    public void ConfirmacaoVoltarMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); // Carrega a cena do menu
    }

    // O jogador pode mudar de ideia e não voltar para o menu principal
    public void NonConfirmacaoVoltarMenu()
    {
        confirmacao.SetActive(false);
    }

    // Função para delay de comandos
    /*IEnumerator WaitForCommand()
    {
        yield return new WaitForSeconds(0.1f); // Espera 100ms para rodar os códigos abaixo
        if(!menuActive)
        {
            
        }
        else
        {
            
        }
    }*/
}
