[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/UEbzVLZg)
# TP2_W10_DFC_A2024


---

# Obtenir la combinaison à partir de l'index des cartes
## public static int GetSuitFromCardIndex(int "index de la carte selectionner dans le paquet de 51 index == 52 cartes") :

- la methode retourne 0 , 1 , 2 ou 3 ce qui équivaux a coeur, trefle , pique et careau

- index de la carte selectionner dans le paquet de 51 index / 13 = un int donc pas de reste.

---
# Obtenir la valeur à partir de l'index de la carte
## public static int GetValueFromCardIndex(int index de la carte selectionner dans le paquet de 51 index || 52 cartes)

- la methode retourne la valeur de la carte de 1 a 13

- en fessant index % 13 j'obtiens une valeur entre 0 et 12 (+1 et j'obtient 1 a 13 pour les 51 index || 52 cartes)

---
