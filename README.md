# Currencies Converter

## Enoncé

Vous souhaitez créer un petit programme permettant de convertir automatiquement des montants dans une devise souhaitée.
Vous disposez des informations suivantes :
  - Un montant dans une devise initiale
  - Une devise cible
  - Une liste incomplète de taux de change
En vous servant de la liste des taux de change, vous devez arriver à convertir le montant dans la devise cible.

Afin de faciliter le calcul, les taux de change sont arrondis à 4 décimales. Chaque étape intermédiaire de calcul doit être arrondie à 4 décimales, et vous devez restituer le montant final arrondi sous la forme d'un nombre entier positif.

Si plusieurs chemins de conversion vous permettent d'atteindre la devise cible, vous devez utiliser le
chemin le plus court.

## Entrée / Sortie

### Entrée du programme

Le programme doit pouvoir être exécuté avec la ligne de commande suivante :

```cmd
LuccaDevises <chemin vers le fichier>
```

#### Exemple de contenu du fichier 

```
EUR;550;JPY
6
AUD;CHF;0.9661
JPY;KRW;13.1151
EUR;CHF;1.2053
AUD;JPY;86.0305
EUR;USD;1.2989
JPY;INR;0.6571
```

### Sortie du programme

Votre programme doit retourner le montant converti dans la devise cible arrondi à un nombre entier.

#### Exemple de sortie

```
59033
```

## Taches

  - [x] Créer le projet console sous Visual Studio
  - [x] Créer la bibliothèque des types & la bibliothèque des tests sur les types
  - [x] Implémenter le montant
  - [x] Implémenter le taux
  - [x] Implémenter la devise
  - [x] Implémenter le taux de change
  - [x] Implémenter le service de conversion
  - [x] Implementer le parser de contenu pour la demande de conversion
  - [x] Implémenter le parser de contenu pour les taux de changes
  - [x] Implémenter le programme de conversion