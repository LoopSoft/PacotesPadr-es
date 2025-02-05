﻿/// <summary>
/// Script message avaliar.
/// 
/// Esse script nao pode nunca esta no obj Msg.Avaliar, ele precisa ser colocado em um loga que sempre esteja ativo,
/// ele vai funcionar da seguinte forma.
/// 
/// -O programador vai ter a opçao de criar uma forma externa de ativaçao, ou usar a desse script ou fazer um conjuto das duas
/// ela faz o seguite, e definido um tempo em segundos que sera o tempo que leva para a messagem ser ativada na tela.
/// 
/// -As variaveis:
/// flagDeAtivacao - ela serve para integrar o scrit com outros para fazer a ativaçao externa do objeto msg.
/// TempoDeEsperaParaAtivar - sempre vai ser necessario colocar um valor maior que zero, para ativaçao externa ou interna.
///  
/// -Melhor forma de usar e criar um objeto no Canvas onde vai ficar guardado todas as menssagens do aplicativo, e colocar o script nesse objeto,
/// onde vai esta sempre ativado.
/// 
/// OBS: depois que o usuario avaliar uma vez, essa msg nunca mais vai aparecer outra vez.
/// </summary>
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ScriptMsgAvaliar : MonoBehaviour {

	public string URL_Link;//Variavel onde sera colocado o link da loja onde o aplicativo esta
	public GameObject Messagem_Avaliacao;//Obj Messgem Avaliacao para ser ativado
	public Text CaixaDeTexto;
	public string MessagemCaixaDeTexto;

	public float TempoDeEsperaParaAtivar = 100;//Tempo de espera para ativar
	public bool flagDeAtivacao = false;//varifica se o obj ja nao foi ativado

	void Starte ()
	{
        PlayerPrefs.SetInt("Avaliaçao", 0);
        if (PlayerPrefs.GetInt("Avaliaçao") == 0 && flagDeAtivacao == false && TempoDeEsperaParaAtivar > 0)
		{
			StartCoroutine(EsperaParaAtiva());
		}
	}
	/// <summary>
	/// Esperas the para ativa.
	/// Coroutine para esperar o tempo de ativaçao do obj
	/// </summary>
	/// <returns>The para ativa.</returns>
	IEnumerator EsperaParaAtiva()
	{
		yield return new WaitForSeconds(TempoDeEsperaParaAtivar);

		CaixaDeTexto.text = MessagemCaixaDeTexto;
		Messagem_Avaliacao.SetActive(true);

		flagDeAtivacao = true;
		TempoDeEsperaParaAtivar = 0;
	}
	/// <summary>
	/// Buttons the confirma avaliacao.
	/// funçao para abrir o site desejado.
	/// </summary>
	public void ButtonConfirmaAvaliacao()
	{
		PlayerPrefs.SetInt("Avaliaçao", 1);
		Application.OpenURL(URL_Link);
	}
}
