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

#  N'a que des cartes de la même couleur
##  public static bool HasOnlySameColorCards(int[] cardsInHandOfTheSameColors)

### recoit et retour de la methode

### la methode recoit:
- les cartes de la main qui sont tous deja vérifier et de la meme couleur

### la methode retourne:
- l'addition des cartes dans la main du joueur

## algo
1 - créé int handScore = 0;

2 - boucle for tant que i est plus petit que le nb de carte en main

3 - handScore += cardsInHandOfTheSameColors[i]

4 - Ce qui addition les cartes dans une variable qui est retourneé 


---
#################################














