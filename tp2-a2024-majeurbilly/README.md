[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/UEbzVLZg)
# TP2_W10_DFC_A2024


---


# Obtenir la combinaison à partir de l'index des cartes
## public static int GetSuitFromCardIndex(int "index de la carte selectionner dans le paquet de 51 index == 52 cartes") :

### recoit et retour de la methode
- la methode **recoit** l'index d'une carte et **retourne** 0 , 1 , 2 ou 3 ce qui équivaux a coeur, trefle , pique et careau

### algorytme 
- index de la carte selectionner dans le paquet de 51 index / 13 = un int donc pas de reste.

```c#
 public static int GetSuitFromCardIndex(int index)
        {
            return index / NUM_CARDS_PER_SUIT;
        }
```

---

# Obtenir la valeur à partir de l'index de la carte
## public static int GetValueFromCardIndex(int index de la carte selectionner dans le paquet de 51 index || 52 cartes)

- la methode retourne la valeur de la carte de 1 a 13

- en fessant index % 13 j'obtiens une valeur entre 0 et 12 d'une carte dans le jeu de carte. 0 etant l'ass et le 12 le roi

```c#
  public static int GetValueFromCardIndex(int index)
        {
            return index % 13;
        }
```
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

```c#
 public static void DistributeCard(int[] cardValues, bool[] selectedCards, bool[] availableCards)
        {
            for (int i = 0; i < selectedCards.Length; i++)
            {
                if (selectedCards[i] == false)
                {
                    int newCarte;

                    do
                    {
                        newCarte = new Random().Next(0, 52);
                    } while (!availableCards[newCarte]);

                    cardValues[i] = newCarte;
                    availableCards[newCarte] = false;
                }
            }
        }
```
---
#################################

# Obtenez le score  à partir de la valeur de la carte
## public static int GetScoreFromCardValue(int cardValue)

### recoit et retour de la methode

### la methode recoit:
- la valeur de la carte = cardValue

### et la methode retourne :
- la valeur du score de la carte

## algo
- si cest un ass retourne 11

- sinon si le tableau de faces contient la face la valeur de la carte retourne 10

- sinon cest une carte entre 2 et 10 inclu. donc la valeur de la carte plus 1 correspont a sa valeur score

```c#
       public static int GetScoreFromCardValue(int cardValue)
        {
            if (cardValue == ACE)
            {
                return ACES_SCORE;
            }
            else if (FACES.Contains(cardValue))
            {
                return FACES_SCORE;
            }
            else
            {
                return GetValueFromCardIndex(cardValue) + 1;
            }
        }
```

---
#################################

# Afficher la note
## public static void ShowScore(int[] cardIndexes)

### recoit et retour de la methode

### la methode recoit: 
- int[] cardIndexes qui est l'index des carte en main
- 
### et la methode retourne :
rien (void)

## algo
1 - la variable int hand = GetHandScore(cardIndexes) acceuil les points
que le joueur a en main
2 - WriteLine les points

```c#
        public static void ShowScore(int[] cardIndexes)
        {
            int hand = GetHandScore(cardIndexes);
            Display.WriteString($"Votre score est de : {hand}", 0, Display.CARD_HEIGHT + 14, ConsoleColor.Black);
        }
```

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
- créé int highestValue = 0

- pour le nombre de valeur des cartes

- crée un int cardValue qui contient la carte que je veux inspecter

- si cardValue == un ass retourne la valeur de la carte

- sinon si la valeur de la carte inspecter est plus grande que highestValue

- highestValue stock la carte inspecté

- return highestValue;

```c#
        public static int GetHighestCardValue(int[] cardsValues)
        {
            int highestValue = 0;
            for (int i = 0; i < cardsValues.Length; i++)
            {
                int cardValue = cardsValues[i];
                if (cardValue == ACE)
                {
                    return cardValue;
                }
                
                else if (cardValue > highestValue)
                {
                    highestValue = cardValue;
                }
            }
            
            return highestValue;
        }
```

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

```c#
        public static bool HasOnlySameColorCards(int[] colorValues)
        {
            int temp = colorValues[0];
            int[] red = { HEART, DIAMOND };
            int[] black = { DIAMOND, SPADE };
            for (int i = 1; i < colorValues.Length; i++)
            {
                if (colorValues[i] != temp)
                {
                    return false;
                }
            }

            return true;
        }
```

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

```c#
        public static bool HasAllSameCardValues(int[] cardValues)
        {
            int temp = GetValueFromCardIndex(cardValues[0]);
            for (int i = 1; i < cardValues.Length; i++)
            {
                if (GetValueFromCardIndex(cardValues[i]) != temp)
                {
                    return false;
                }
            }

            return true;
        }
```


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


```c#
        public static bool HasAllFaces(int[] values)
        {
            const int ALL_FACES_SUM = JACK + QUEEN + KING;
            int counter = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (!FACES.Contains(GetValueFromCardIndex(values[i])))
                {
                    return false;
                }

                counter += GetValueFromCardIndex(values[i]);
            }

            if (counter != ALL_FACES_SUM)
            {
                return false;
            }

            return true;
        }
```

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


```c#
         public static bool HasOnlyFaces(int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (!FACES.Contains(GetValueFromCardIndex(values[i])))
                {
                    return false;
                }
            }

            return true;
        }
```

---
#################################

# A la même séquence de couleurs
## public static bool HasSameColorSequence(int[] values, int[] suits)

### recoit et retour de la methode

### la methode recoit:
- un tableau de valeurs et un tableau de couleur

### la methode retourne:
- true si le tableau de valeur est pareil que le tableau de couleur 
- false si ce nest pas le cas

## algo
- boucle for pour inspecter chaques couleurs

- si la couleur des la carte 1 != a la couleur inspeccter retourne false

- sinon retourne true

```c#
        public static bool HasSameColorSequence(int[] values, int[] colors)
        {
            for (int i = 0; i < colors.Length; i++)
            {
                if (GetSuitFromCardIndex(values[i]) != colors[i])
                {
                    return false;
                }
            }
```

---
#################################


# Avoir une séquence
## public static bool HasSequence(int[] values)

### recoit et retour de la methode

### la methode recoit:
- une tableau de valeur 

### la methode retourne:
- true si les éléments dans le tableau sont une suite

## algo

- boule for pour inspecter le tableau de valeur - 1 pour ne pas inspecter la derniere carte

- si l'élément 1 != a l'élement 2 retourne false

- si l'élément 2 != a l'élement 3 retourne false

- sinon retourne true car 1+1 = 2 && 2+1 = 3 

```c#
        public static bool HasSequence(int[] values)
        {
            for (int i = 0; i < values.Length - 1; i++)
            {
                if (values[i] != values[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
```

---
#################################

# Obtenez le score de plusieurs cartes d'une même couleur
##  public static int GetScoreFromMultipleCardsOfASuit(int suit, int[] values, int[] suits)

### recoit et retour de la methode

### la methode recoit:
- un nombre représentant la couleur de la carte
- un tableau avec les valeurs contenu dans la main du joeur
- et un tableau de la suit de couleur contenu dans la main du joeur

### la methode retourne:
- int = score des cartes de la meme couleur additionner

## algo
- créé compteur pour compter les carte de la couleur spécifique

- boucle for pour inpecter les carte de la main

- si la cartes est de la meme couleur que la couleur spécifique rechercher addtionne au compteur 

```c#
        public static int GetScoreFromMultipleCardsOfASuit(int suit, int[] values, int[] suits)
        {
            int counter = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (GetSuitFromCardIndex(values[i]) == suit)
                {
                    counter++;
                }
            }

            return counter;
        }
```


---
#################################
FINIAL
#################################

# Obtenir le score de la main
## public static int GetHandScore(int[] cardIndexes)

### recoit et retour de la methode

### la methode recoit:
- un tableau d'entier comportant index des cartes de la main

### la methode retourne:
- un nombre entier qui est le score du joueur selon est regle du 31

## algo
- créé int handScore = 0 ;
- if (HasOnlySameColorCards)
-  boucle for pour inspecter la main 
- additionner la valeur de la cartee dans le handScore

```c#
        public static int GetHandScore(int[] cardIndexes)
        {
            int handScore = 0;
            if (HasOnlySameColorCards(cardIndexes))
            {
                for (int i = 0; i < cardIndexes.Length - 1; i++)
                {
                    int fris = GetSuitFromCardIndex(cardIndexes[i]);
                    if (GetSuitFromCardIndex(cardIndexes[i]) == GetSuitFromCardIndex(cardIndexes[i + 1]))
                    {
                        handScore += GetValueFromCardIndex(cardIndexes[i]) + GetValueFromCardIndex(cardIndexes[i + 1]);
                    }
                }
            }

            return 0;
        }
```

























