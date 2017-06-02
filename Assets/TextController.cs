using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
	private enum Estados {cela, espelho, trapo_0, fecho_0, cela_espelho, trapo_1, fecho_1,
		escadas_0, escadas_1, escadas_2, patio, piso, corredor_0, corredor_1, 
		corredor_2, corredor_3, closet_porta, dentro_closet};
	private Estados meuEstado;

	// Use this for initialization
	void Start () {
		meuEstado = Estados.cela;
	}

	// Update is called once per frame
	void Update () {
		print (meuEstado);
		if		(meuEstado == Estados.cela)			{ estado_Cela(); }
		else if (meuEstado == Estados.trapo_0)		{ estado_trapo_0(); }
		else if (meuEstado == Estados.trapo_1)		{ trapo_1(); }
		else if (meuEstado == Estados.fecho_0)		{ estado_fecho_0(); }
		else if (meuEstado == Estados.fecho_1)		{ fecho_1(); }
		else if (meuEstado == Estados.espelho)		{ espelho(); }
		else if (meuEstado == Estados.cela_espelho)	{ cela_espelho(); }
		//else if (meuEstado == Estados.liberdade)	{ estado_liberdade(); }

		else if (meuEstado == Estados.corredor_0) 	{corredor_0();}
		else if (meuEstado == Estados.escadas_0) 	{escadas_0();}
		else if (meuEstado == Estados.escadas_1) 	{escadas_1();}
		else if (meuEstado == Estados.escadas_2) 	{escadas_2();}
		else if (meuEstado == Estados.patio) 		{patio();}
		else if (meuEstado == Estados.piso) 		{piso();}
		else if (meuEstado == Estados.corredor_1) 	{corredor_1();}
		else if (meuEstado == Estados.corredor_2) 	{corredor_2();}
		else if (meuEstado == Estados.corredor_3) 	{corredor_3();}
		else if (meuEstado == Estados.closet_porta)	{closet_porta();}
		else if (meuEstado == Estados.dentro_closet){dentro_closet();}
	}

	void estado_Cela(){
		text.text = "Você está em uma cela de prisão e quer escapar. Existe alguns " +
			"trapos sujos em cima da cama, um espelho na parede e a porta, " +
			"trancada pelo lado de fora :(\n\n"+
			"Pressione T para sentir os TRAPOS, E para ver o ESPELHO e F para ver a FECHADURA";
		if 		(Input.GetKeyDown(KeyCode.T)) 	{meuEstado = Estados.trapo_0;}
		else if (Input.GetKeyDown(KeyCode.M)) 	{meuEstado = Estados.espelho;}
		else if (Input.GetKeyDown(KeyCode.L)) 	{meuEstado = Estados.fecho_0;}
	}

	void estado_trapo_0(){
		text.text = "Você não acredita que dormiu em cima dessas coisas nojentas. " +
			"Certamente está na hora de troca-los. Prazeres da vida eu suponho... " +
			"\n\n"+
			"Pressione R para retornar a exploração de sua cela";
		if (Input.GetKeyDown(KeyCode.R))	{meuEstado = Estados.cela;}
	}

	void estado_fecho_0(){
		text.text = "Parece ser uma dessas fechaduras por combinação. Você não tem ideia " +
			"de qual combinação poderia ser. Você deseja que pudesse, de alguma forma, " +
			"ver onde as impressões digitais estão, talvez aquilo deva ajudar.\n\n"+
			"Pressione R para retornar a exploração de sua cela";
		if (Input.GetKeyDown(KeyCode.R))	{meuEstado = Estados.cela;}
	}

	void dentro_closet() {
		text.text = "Dentro do closet você vê o uniforme do faxineiro que parece ter quase seu tamanho! " +
			"Parece seu dia de sote.\n\n" +
			"Pressione D para vestir-se ou R para retornar ao corredor";
		if 		(Input.GetKeyDown(KeyCode.R)) 	{meuEstado = Estados.corredor_2;}
		else if (Input.GetKeyDown(KeyCode.D)) 	{meuEstado = Estados.corredor_3;}
	}

	void closet_porta() {
		text.text = "Você está olhando para a porta do closet, infelizmente está trancada. " +
			"Talvez você encontra algo ao regor para encorajar o arrombamento?\n\n" +
			"Pressione R para retornar ao corredor";
		if (Input.GetKeyDown(KeyCode.R)) 		{meuEstado = Estados.corredor_0;}
	}

	void corredor_3() {
		text.text = "Você está de pé no corredor, agora vestido de forma convincente como um faxineiro. " +
			"Você considera fortemente a corrida para a liberdade.\n\n" +
			"Pressione S para pegar as escadas ou U para despir";
		if 		(Input.GetKeyDown(KeyCode.S)) 	{meuEstado = Estados.patio;}
		else if (Input.GetKeyDown(KeyCode.U))	{meuEstado = Estados.dentro_closet;}
	}

	void corredor_2() {
		text.text = "De volta ao corredor, tendo recusado a vestir-se como um faxineiro.\n\n" +
			"Pressione C para revisitar o Closet e S para escalar as escadas";
		if 		(Input.GetKeyDown(KeyCode.C)) 	{meuEstado = Estados.dentro_closet;}
		else if (Input.GetKeyDown(KeyCode.S)) 	{meuEstado = Estados.escadas_2;}
	}

	void corredor_1() {
		text.text = "Ainda no corredor. Piso ainda sujo. Grampo na mão. " +
			"E agora? Você quer saber se esse bloqueio no armário sucumbiria " +
			"a um lock-picking?\n\n" +
			"P para escolher a fechadura e S para subir as escadas";
		if (Input.GetKeyDown(KeyCode.P)) 		{meuEstado = Estados.dentro_closet;}
		else if (Input.GetKeyDown(KeyCode.S)) 	{meuEstado = Estados.escadas_1;}
	}

	void piso () {
		text.text = "Vasculhando ao redor do chão sujo, você encontra , ao que parece, um clip de cabelo.\n\n" +
			"Pressione R para retornar à posição, ou H para pegar o grampo de cabelo." ;
		if 		(Input.GetKeyDown(KeyCode.R)) 	{meuEstado = Estados.corredor_0;}
		else if (Input.GetKeyDown(KeyCode.H)) 	{meuEstado = Estados.corredor_1;}
	}	

	void patio () {
		text.text = "Você atravessa o pátio vestido como um faxineiro. " +
			"O guarda lhe cumprimenta com seu chapéu enquanto você vira, reivindicando " +
			"sua liberdade. O coração bate forte quando você entra no pôr-do-sol..\n\n" +
			"Pressione P para jogar de novo." ;
		if (Input.GetKeyDown(KeyCode.P)) 		{meuEstado = Estados.cela;}
	}	

	void escadas_0 () {
		text.text = "Você começa a subir as escadas para a luz externa. " +
			"Você percebe que não é tempo de descanso e você será pego imediatamente. " +
			"Você desliza de volta pelas escadas e reconsidera.\n\n" +
			"Pressione R para retornar ao corredor." ;
		if (Input.GetKeyDown(KeyCode.R)) 		{meuEstado = Estados.corredor_0;}
	}

	void escadas_1 () { //perigo
		text.text = "Infelizmente, um clipe de cabelo insignificante não lhe deu a " +
			"confiança para caminhar para um pátio cercado por guardas armados\n\n" +
			"Pressione R para se retirar até as escadas" ;
		if (Input.GetKeyDown(KeyCode.R)) 		{meuEstado = Estados.corredor_1;}
	}

	void escadas_2() {
		text.text = "Você se sente presunçoso por escolher a porta do armário aberta, e ainda está armado com " +
			"um grampo de cabelo (agora mal inclinado). Todas estas conquistas juntas não dão " +
			"a você a coragem de subir as escadas para a sua morte!\n\n" +
			"Pressione R para retornar ao corredor.";
		if (Input.GetKeyDown(KeyCode.R)) 		{meuEstado = Estados.corredor_2;}
	}

	void espelho() {
		text.text = "O velho e sujo espelho na parede parece solto.\n\n" +
			"Pressione T para pegar o espelho, ou R para Retornar a cela" ;
		if 		(Input.GetKeyDown(KeyCode.T)) 	{meuEstado = Estados.cela_espelho;}
		else if (Input.GetKeyDown(KeyCode.R)) 	{meuEstado = Estados.cela;}
	}

	void cela_espelho() {
		text.text = "Você ainda está em sua cela e você AINDA quer escapar! Existe " +
			"alguns trapos sujos em cima da cama, uma marca mostrando onde estava um espelho, " +
			"e essa maldita porta ainda se encontra ali, firme e forte!\n\n" +
			"Pressione S para ver trapos ou L para ver a fechadura" ;
		if 		(Input.GetKeyDown(KeyCode.S)) 	{meuEstado = Estados.trapo_1;}
		else if (Input.GetKeyDown(KeyCode.L)) 	{meuEstado = Estados.fecho_1;}
	}

	void trapo_1() {
		text.text = "Segurando um espelho em suas mãos não fazem os trapos " +
			"parecerem melhores.\n\n" +
			"Pressione R para retornar a exploração de sua cela" ;
		if (Input.GetKeyDown(KeyCode.R)) 		{meuEstado = Estados.cela_espelho;}
	}

	void fecho_1() {
		text.text = "Você cuidadozamente põe o espelho através das barras e o vira " +
			"assim podendo ver a fechadura. You can just make out fingerprints ao redor " +
			"dos botões. Você pressiona os botões sujos e escuta um click.\n\n" +
			"Pressione O para Abrir, ou R para retornar à sua cela." ;
		if 		(Input.GetKeyDown(KeyCode.O)) 	{meuEstado = Estados.corredor_0;}
		else if (Input.GetKeyDown(KeyCode.R)) 	{meuEstado = Estados.cela_espelho;}
	}

	void corredor_0() {
		text.text = "Você está fora de sua cela, mas não fora de perigo." +
			"Você está no corredor, existe um closet e algumas escadas levando ao " +
			"pátio. Há também vários detritos no chão.\n\n" +
			"C para ver o Closet, F para inspecionar o piso e S para subir as escadas";
		if 		(Input.GetKeyDown(KeyCode.S)) 	{meuEstado = Estados.escadas_0;}
		else if (Input.GetKeyDown(KeyCode.F)) 	{meuEstado = Estados.piso;}
		else if (Input.GetKeyDown(KeyCode.C)) 	{meuEstado = Estados.closet_porta;}  
	}
}
	