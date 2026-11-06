# Flappy-Birds-Prática (PJ 2026.2)



Link do Jogo no Unity Play: https://play.unity.com/en/games/98096ed1-0c64-404a-a3e1-eedabc1d5d63/flappy-bird-aula



Sobre o Projeto



Felpudo decolou em seu avião e precisa atravessar um céu cheio de perigos. Inspirado na jogabilidade de Flappy Bird, o jogo mistura voo e tiro: o jogador mantém a altura com cliques do mouse, desvia dos inimigos que avançam pela tela e usa sua munição limitada para abrir caminho. Depois de uma onda de inimigos, o Boss aparece e precisa ser derrotado para vencer o jogo. Encostar em qualquer inimigo ou sair dos limites do mapa significa derrota.



Como Jogar

Botão esquerdo do mouse	Impulsiona o Felpudo para cima

Barra de espaço	Atira

tecla "R" Reinicia o jogo após vitória ou derrota

Funcionalidades Implementadas



Controle do Jogador (ControlaJogadorMouseEsquerdo)



Movimento por impulso com Rigidbody2D, iniciando o jogo apenas no primeiro clique.

Sistema de tiro com munição limitada e contador exibido na tela (TextMeshPro).

Condição de derrota ao sair dos limites verticais do mapa ou ao colidir com inimigos e Boss (detecção por tags Inimigo e Boss).

Condição de vitória ao derrotar o Boss, com textos de vitória e derrota na interface.

Reinício da cena com a tecla R.



Gerador de Inimigos (GeradorInimigos)



Geração de inimigos a partir de prefabs em intervalos regulares e em alturas aleatórias.

Movimentação dos inimigos da direita para a esquerda, com destruição ao saírem da tela.

Após uma quantidade definida de inimigos, o gerador para e invoca o Boss.



Boss (BossController)



Sistema de vida com contador exibido na tela.

Perde vida a cada bala que o atinge e, ao chegar a zero, aciona a vitória do jogador.



Fundo em Movimento (MoveFundo)



Rolagem contínua do cenário através do deslocamento (offset) da textura do material.

Material configurado com o shader Universal Render Pipeline/Unlit e textura com Wrap Mode em Repeat, já que o shader Sprite-Lit ignora tiling e offset.



Publicação



Build em WebGL, publicado no Unity Play.

Tecnologias

Unity 6

C#

TextMeshPro

Universal Render Pipeline (URP)



Aluna:Maria Clara Santos.

