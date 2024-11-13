[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/UEbzVLZg)
# TP2_W10_DFC_A2024


---
# BLOC LEGO
## Methode

### Booleen :
```c#
public static bool HasOnlySameColorCards(int[] colorValues)

public static bool HasAllSameCardValues(int[] cardValues)

public static bool HasAllFaces(int[] values)

public static bool HasOnlyFaces(int[] values)

public static bool HasSameColorSequence(int[] values, int[] colo
    
public static bool HasSequence(int[] values)
```

## int[] :
```c#
public static int[] SwitchAceValues(int[] cardValues)
    
public static int[] PutCardInOrder(int[] values)
```

## int :
```c#
public static int GetSuitFromCardIndex(int index)
    
public static int GetValueFromCardIndex(int index)

public static int GetHighestCardValue(int[] cardsValues)

public static int GetScoreFromMultipleCardsOfASuit(int suit, int[] values, int[] suits)
```

## void
```c#
public static void ShowScore(int[] cardIndexes)
```


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
1 - dans une boucle for j'inspecte le tableau de carte selectedCards

2 - si la carte selectionner est false

3 - créé variable newCard

4 - boucle do tant que la nouvelle carte nest pas dipo soit true

5 - mettre mes variables a leur place

```c#
        public static void DistributeCard(int[] cardValues, bool[] selectedCards, bool[] availableCards)
        {
            for (int i = 0; i < selectedCards.Length; i++)
            {
                if (selectedCards[i] == false)
                {
                    int newCard;

                    do
                    {
                        newCard = new Random().Next(0, 52);
                    } while (!availableCards[newCard]);

                    availableCards[newCard] = true;
                    cardValues[i] = newCard;
                    availableCards[newCard] = false;
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
- un tableau avec la valeur des couleur de chaques carte s

### la methode retourne:
- true si les cartes sont de la meme couleur, soit toutes rouge ou toutes noir
- false si les cartes sont pas toute de la meme couleur, soit toutes rouge ou toutes noir

## algo
1 - créé int temp qui représente la premiere carte de la main

2 - boucle for pour inspecter les deux derniere cartes

3 - si GetValueFromCardIndex[i] < 26 = true ;

4 - sinon = false

```c#
     public static bool HasOnlySameColorCards(int[] colorValues)
        {
            bool isRed = false;
            bool isBlack = false;
            
            for (int i = 0; i < colorValues.Length; i++)
            {
                int[] redCard = { HEART, DIAMOND };

                if (colorValues[i] > CLUB)
                {
                    return false;
                }
                {
                    
                }
                if (redCard.Contains(colorValues[i]))
                {
                    isRed = true;
                }
                else
                {
                    isBlack = true;
                }
            }

            if (isRed && isBlack)
            {
                return false;
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



1 - boucle for pour inspecter cartes

2 - si carte 1 != carte 2 ;

```c#
        public static bool HasAllSameCardValues(int[] cardValues)
        {
            for (int i = 1; i < cardValues.Length - 1; i++)
            {
                if (cardValues[i] != cardValues[i + 1])
                {
                    return false;
                }
            }

            return true;
        } return true;
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
il a changer et je suis lache... 


```c#
        public static bool HasAllFaces(int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (HasOnlyFaces(values) && HasSequence(values))
                {
                    return true;
                }
            }

            return false;
        }  return true;
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

# Avoir la même séquence de couleurs 
même couleur
## public static bool HasSameColorSequence(int[] values, int[] suits)

### recoit et retour de la methode

### la methode recoit:
- un tableau des valeurs des carte
- un tableau de valeur de la couleur des cartes

### la methode retourne:
- true si tout les valeurs des carte sont inférieur a 26 = rouge sinon = noir
- false si ce nest pas le cas

## algo
- mettre les cartes en ordre

- boucle for pour inspecter chaques couleurs

- si la couleur des la carte 1 != a la couleur inspeccter retourne false

- sinon retourne true

```c#
        public static bool HasSameColorSequence(int[] values, int[] colors)
        {
            int[] arrayEnOrdre = PutCardInOrder(values);

            if ((!HasOnlySameColorCards(colors)) || !HasSequence(arrayEnOrdre))
            {
                return false;
            }

            return true;
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
- int = 0

## algo
- créé compteur pour compter les carte de la couleur spécifique

- boucle for pour inpecter les carte de la main

- si la cartes est de la meme couleur que la couleur spécifique rechercher addtionne au compteur 

```c#
        public static int GetScoreFromMultipleCardsOfASuit(int suit, int[] values, int[] suits)
        {
            int temp = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (suits[i] == suit)
                {
                    temp += GetScoreFromCardValue(values[i]);
                }
            }

            return temp;
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
il a changé et je suis lache...

```c#
        public static int GetHandScore(int[] cardIndexes)
        {
            int[] colorsValues = new int[cardIndexes.Length];
            int[] cardValues = new int[cardIndexes.Length];
            for (int i = 0; i < cardIndexes.Length; i++)
            {
                colorsValues[i] = GetSuitFromCardIndex(cardIndexes[i]);
                cardValues[i] = GetValueFromCardIndex(cardIndexes[i]);
            }
            
            return new int[] { GetHandScoreWithSpecialCombinasion(cardValues, colorsValues), GetHighestCardValue(cardValues), GetHighestColorScore(colorsValues, cardValues) }.Max();
        }

        private static int GetHighestColorScore(int[] colorsValues, int[] cardValues)
        {
            int bestSuitScore = 0;
            for (int i = 0; i < colorsValues.Length; i++)
            {
                int suitScore = GetScoreFromMultipleCardsOfASuit(colorsValues[i], cardValues, colorsValues);
                if (bestSuitScore < suitScore)
                {
                    bestSuitScore = suitScore;
                }
            }
            return bestSuitScore;
        }
```

# Get Hand Score Wit hSpecial Combinasion
## private static int GetHandScoreWithSpecialCombinasion(int[] cardValues, int[] colorsValues)


## algo
il a changé et je suis lache...

```c#
        private static int GetHandScoreWithSpecialCombinasion(int[] cardValues, int[] colorsValues)
        {
            int handScoreWithSpecialCombinasion = 0;
            if (HasAllSameCardValues(cardValues))
            {
                if (handScoreWithSpecialCombinasion < ALL_SAME_CARDS_VALUE_SCORE)
                {
                    handScoreWithSpecialCombinasion = ALL_SAME_CARDS_VALUE_SCORE;
                }
            }

            if (HasOnlyFaces(cardValues))
            {
                if (handScoreWithSpecialCombinasion < ONLY_FACES_SCORE)
                {
                    handScoreWithSpecialCombinasion = ONLY_FACES_SCORE;
                }
            }

            if (HasOnlySameColorCards(colorsValues))
            {
                if (handScoreWithSpecialCombinasion < SAME_COLOR_SCORE)
                {
                    handScoreWithSpecialCombinasion = SAME_COLOR_SCORE;
                }
            }

            if (HasSequence(cardValues))
            {
                if (handScoreWithSpecialCombinasion < SEQUENCE_SCORE)
                {
                    handScoreWithSpecialCombinasion = SEQUENCE_SCORE;
                }
            }

            if (HasSameColorSequence(cardValues, colorsValues))
            {
                if (handScoreWithSpecialCombinasion < SAME_COLOR_SEQUENCE_SCORE)
                {
                    handScoreWithSpecialCombinasion = SAME_COLOR_SEQUENCE_SCORE;
                }
            }

            if (HasAllFaces(cardValues))
            {
                if (handScoreWithSpecialCombinasion < ALL_FACES_SCORE)
                {
                    handScoreWithSpecialCombinasion = ALL_FACES_SCORE;
                }
            }

            return handScoreWithSpecialCombinasion;
        }
```

# Carte distribution
##  public static void DrawFaces(int[] cardValues, bool[] selectedCards, bool[] availableCards)


## algo
il a changé et je suis lache...


```c#
        public static void DrawFaces(int[] cardValues, bool[] selectedCards, bool[] availableCards)
        {
            for (int i = 0; i < selectedCards.Length; i++)
            {
                if (selectedCards[i] == false)
                {
                    int newCard;

                    do
                    {
                        newCard = new Random().Next(0, 52);
                    } while (!availableCards[newCard]);

                    availableCards[newCard] = true;
                    cardValues[i] = newCard;
                    availableCards[newCard] = false;
                }
            }
        }
```






















