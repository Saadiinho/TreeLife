# Projet Arbre de Vie

# PolyTech Paris-Saclay C# & .NET

## Description du Projet

Ce projet, intitulé **"Arbre de Vie"**, est une application interactive permettant aux utilisateurs d'explorer un arbre phylogénétique représentant les relations entre différents groupes d'êtres vivants. Elle est basée sur le jeu de données "Tree of Life" disponible sur Kaggle.

## Installation et Prérequis

### Prérequis

- **.NET Core SDK** (v6 ou supérieure)
- **Visual Studio** (ou tout autre IDE compatible avec .NET)

### Installation

1. Clonez le dépôt :
   ```bash
   git clone https://github.com/Saadiinho/TreeLife.git
   cd ./TreeLife
   ```
2. Exécutez le projet via l'IDE


## Fonctionnalités Principales

- **Visualisation de l'Arbre de Vie** : Les clusters importants sont regroupés avec une étiquette indiquant leur racine. /!\ Soit la hiérarchie A -> B -> C, pour regrouper le cluster de B, vous devez préalablement regrouper celui de C. Suivre la même démarche avec B pour regrouper le cluster de A. **ATTENTION** avant de découvrir un noeud, nous conseillons de zoomer le plus que possible sur ce dernier afin d'éviter les chevauchements !				
  
  `Survoler (ou cliquer) pour découvrir/regrouper les nœuds/enfants directs.`

- **Déplacer l'arbre** : Possibilité de déplacer tout l'arbre.
  
  `Maintenir clique gauche + bouger dans la direction souhaitée`

- **Zoom/Dézoom** : Possibilité de zoomer et dézoomer sur les différentes branches de l'arbre, en fonction de la position de la souris:
  
  `Positionnement souris + Molette ↑ (ou Molette ↓)`


- **Informations détaillées** : Affichage des informations d'une feuille dans la bannière située à droite lors de la sélection.
  
  `Survoler/Cliquer sur une feuille.`

## Quelques captures

![image](https://github.com/user-attachments/assets/e4bb5a8f-6505-4690-85e1-5c01e59b8ea9)

*Figure 1 : Découvrir/regrouper un cluster*

![image](https://github.com/user-attachments/assets/8d425011-fd21-4816-871d-e90cc7b7cc26)

*Figure 2 : Déplacer l'arborescence*

![image](https://github.com/user-attachments/assets/b06f4277-670f-4336-b3f6-5a0a21dd5b27)

*Figure 3 : Zoomer/Dézoomer l'arborescence*

![image](https://github.com/user-attachments/assets/3e2d5c69-f482-490f-9b02-0e879d40c75e)

*Figure 4 : Obtenir les informations sur les feuilles*
