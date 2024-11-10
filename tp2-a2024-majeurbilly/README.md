[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/UEbzVLZg)
# TP2_W10_DFC_A2024


---


# Obtenir la combinaison à partir de l'index des cartes
## public static int GetSuitFromCardIndex(int "index de la carte selectionner dans le paquet de 51 index == 52 cartes") :

### recoit et retour de la methode
- la methode **recoit** l'index d'une carte et **retourne** 0 , 1 , 2 ou 3 ce qui équivaux a coeur, trefle , pique et careau

### algorytme 
- index de la carte selectionner dans le paquet de 51 index / 13 = un int donc pas de reste.

---

# Obtenir la valeur à partir de l'index de la carte
## public static int GetValueFromCardIndex(int index de la carte selectionner dans le paquet de 51 index || 52 cartes)

- la methode retourne la valeur de la carte de 1 a 13

- en fessant index % 13 j'obtiens une valeur entre 0 et 12 (+1 et j'obtient 1 a 13 pour les 51 index || 52 cartes)

---
#################################

# Distribution de carte
## public static void DistributeCard(int[] cardValues, bool[] selectedCards, bool[] availableCards)

### Énoncer dit :
Cette fonction a pour objectif de distribuer des cartes au joueur. 

### Elle possède trois paramètres :
1 - **int[] cardValues** : les 3 valeurs (index) de cartes que possède déjà le joueur. Ce tableau contient que
des valeurs entre 0 et 51.


2 - **bool[] selectedCards** : des booléens indiquant si le joueur veut garder la face(true) ou s’il souhaite
l’échanger (false). Ce tableau a la même taille que facesValues. Au début de la partie, 
les 3 booléens sont initialisés par le code fourni à false.

3 - **bool[] availableCards** : des booléens indiquant si chacune des 52 cartes est disponible (true) ou
non (false). Évidemment, il ne sera possible de distribuer que les cartes
disponibles. Lorsqu’une carte est rejetée par le joueur, elle redevient disponible lors des tours suivants.
Au début de la partie, les 52 booléens sont initialisés par le code fourni à true. (main)

## recoit et retour de la methode

### la methode recoit: 
1 - **int[] cardValues** 3 valeurs des cartes

2 - **bool[] selectedCards** indiquant si le joueur veut garder la face(true) ou s’il souhaite l’échanger (false)

3 - **bool[] availableCards** indiquant si chacune des 52 cartes est disponible (true) ou non (false)
### et la methode retourne : 
rien (void)

## Algo
1 - dans une boule for qui va rouler 3 fois

2 - le if va regarder si le joueur désir échanger sa carte pour une autre.

3 - si la carte est a false, une 4eme carte est créé et est rajouter dans le jeu. un fois que la 4eme carte prendre la place
  de la carte a échanger celle-ci redevient disponible dans le jeu.

---
#################################

# Afficher la note
## public static void ShowScore(int[] cardIndexes)

### recoit et retour de la methode

### la methode recoit: 
- int[] cardIndexes qui est l'index des carte en main
C
rien (void)

## algo
1 - la variable int hand = GetHandScore(cardIndexes) acceuil les points
que le joueur a en main
2 - WriteLine les points

---
#################################

# Obtenez la valeur de carte la plus élevée
## public static int GetHighestCardValue(int[] cardsValues)

### recoit et retour de la methode

### la methode recoit:
- les cartes en main

### la methode retourne: 
la valeur la plus haute entre les cartes en main 

## algo
1 - créé int highestValue = 0

2 - foreach int i in cardsValue

3- si cardsValues[i] > highestValue

4 - highestValue = cardsValues[i];

5 - return highestValue;

---
#################################

#  Avoir que des cartes de la même couleur
##  public static bool HasOnlySameColorCards(int[] cardsInHandOfTheSameColors)

### recoit et retour de la methode

### la methode recoit:
- la valeur des cartes en tableau

### la methode retourne:
- true si les cartes sont de la meme couleur
- false si les cartes sont pas toute du meme couleur

## algo
1 - créé int temp qui représente la premiere carte de la main

2 - boucle for pour inspecter les deux derniere cartes

3 - si temp != false ;


---
#################################

# Avoir toutes les mêmes valeurs de cartes
## public static bool HasAllSameCardValues(int[] values)

### recoit et retour de la methode

### la methode recoit:
- les valeurs des catres en main sous forme de tableau

### la methode retourne:
- true si les cartes ont tous la meme valeur
- false si les cartes sont d'une valeur différente


1 - créé int temp qui représente la premiere carte de la main

2 - boucle for pour inspecter les deux derniere cartes

3 - si temp != false ;


---
#################################

# A tous les visages >> valet dame roi
## public static bool HasAllFaces(int[] values)

### recoit et retour de la methode

### la methode recoit:
- une tableau de valeur 

### la methode retourne:
- true si les cartes sont valet dame roi
- false si les cartes ne le sont pas

## algo
1 - créé int[] faces avec les trois faces jack queen king appeler **faces**

2 - créé int allFace jack 11 + queen 12 + king 13 = 36

3 - compteur a 0

4 - boucle for inspecte le tableau de valeur 

5 - si dans le tableau **faces** on ne retrouve pas la valeur de la carte inspecter retourne false car ce nest pas un face

6 - si la cartes inspecter est une face elle est aditionné au compteur

7 - si le compteur n'est pas égale a allFace retourne false

8 - sinon true


---
#################################


# N'a que des visages 
## public static bool HasOnlyFaces(int[] values)

### recoit et retour de la methode

### la methode recoit:
- une tableau de valeur

### la methode retourne:
- true si le tableau de valeur a que des figures
- false si le talbeau n'a pas que des figures 

## algo
1 - boule for pour inspecter le tableau de valeur 

2 - si la carte inspecter n'est pas une figure retourne false 

3 - sinon retourne true 

---
#################################

# A la même séquence de couleurs
## public static bool HasSameColorSequence(int[] values, int[] suits)

### recoit et retour de la methode

### la methode recoit:
- un tableau de valeurs et un tableau de couleur





