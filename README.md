# Sudoku
Ce dépôt GitHub contient le travail que j'ai effectué sur un projet de Sudoku en C#, dans le cadre scolaire.

Le projet propose à l'utilisateur de jouer au sudoku, selon 3 niveaux de difficultés.
Chaque niveau de difficulté représente un certain nombre de cases cachées (31 pour le niveau 1, 40 pour le niveau 2 et 50 pour le niveau 3).
Le joueur peut disposer comme il le souhaite les chiffres dans les cases. 
Il peut ensuite vérifier la grille, une fois cette dernière pleine. 
Les cases correctes sont mises en vert, et les incorrectes en rouge.

L'utilisateur peut également librement recommencer la grille s'il le souhaite.

# Avancements possibles

Acutellement, les cases cachées sont choisies aléatoirement. On pourrait améliorer ceci, un essayant de cacher
de manière équitable les cases de chaque ligne/colonne/carré.

De même, l'algorithme génère une grille complète dès le départ, puis cache les cases. On garde la grille de départ
généré en mémoire, pour pouvoir vérifier si celle que l'utilisateur rentre est correcte. 
Par conséquent, il y a une unique solution dans le programme actuel. Une option intéréssante pourrait être 
de dévelloper un algorithme pour vérifier si la grille rentrée par l'utilisateur est correcte, même si elle n'est pas égale 
à celle généré au départ.

Systeme de score à rajouter.