# Analyse


### En Grande ligne
 - Gestion des stocks
 - Objet composant de l'armoire
 - Gestion des erreurs
 - Interface graphique
 - DB


### Bloc
- pas de porte ou 2 portes
- une hauteur définie par les blocs
- une planche pour faire le plafond et une planche pour le sol d'un bloc


## Détail

### Gestion des erreurs
- hauteur max

# Analyse fonctionnement de l'application

#### Choix du client
- Définir la profondeur voulue de l'armoire.
- Définir la largueur de l'armoire => En fonction de cela on peut lui proposer avec ou sans portes.
- Il choisit un premier bloc (minimum 1) les blocs doivent avoir la meme largueur et profondeur, seule la hauteur est à définir par le client => il faut qu'il précise avec ou sans porte
- Puis il doit choisir tout les autres blocs en présisant à chaque fois la hauteur de celui ci (+portes)
  -  La hauteur maximum possible d'une armoir est de 280cm , donc il faut limiter le client quand il se raproche de cette valeur


#### A gerer en fonction de la demande
- Le programme doit gere les différente élément à commander en fonction de la taille voulue du bloc par le client.
- Il faut aussi gerer la cornirère qui elle, à une hauteur calculé en fonction de la somme des hauteurs des blocs. La hauteur max de cornière est 280 d'ou la hauteur max de l'armoire.
- Si la hauteur de l'armoir n'atteint pas une hauteur strandarisé de cornière, il faut en prévoire une plus grande, et la découpée (la découpe rajoute des frais supplémentaires).
