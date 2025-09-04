// See https://aka.ms/new-console-template for more information

/*PART 1 | A*/

using System.Text.RegularExpressions;

List<string> wordsPartA = new List<string> { "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune" };



// OBJECTIVES : 
// - excluding a word by its containing letter X
// - 4 caractères ou plus
// - autant de caractères que la moyenne du nb de caractères de la liste

// list of words without x
List<string> wordsWithoutX = wordsPartA.Where(word => word.Contains("x")).ToList();

// 4 caractères ou plus 

List<string> wordsWith4MinChar = wordsWithoutX.Where(word => word.Count() < 4).ToList();

// Calculates the average of char. on the list
// ISSUE 2 | IMPOSSIBLE TO USE .Average() within .Where() due to the fact entrancy parameter in .Where() is of type string
double wordsAverageCharLength = wordsWith4MinChar.Average(word => word.Length);


// Counting the number of characters within a list 
List<string> wordsListAboveAverage = wordsWith4MinChar.Where(word => wordsAverageCharLength < word.Length).ToList();

//AFFICHAGE DES RESULTATS
// dans l’ordre inverse de celui naturellement calculé
// triés a-z
// triés z-a


// PART 1 | B (DONNEES PARASITES)

/*  OBJECTIFS : 
    - DONNEES PARASITES 
       - AU DEBUT
       - 2 DERNIERES CHAR. DE FIN
    LIMITES TECHNIQUES : 
    - CODE SOBRE
    - SIMPLE A LIRE     
 */

string[] wordspb = { "whatThe!!!", "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune", "My kingdom for a horse !", "Ooops I did it again" };

var noParasites = wordspb
/*
 Fonction pour nettoyer les données parasites au début d'une chaîne
 Par exemple, retirer 1 ou plusieurs caractères indésirables au début
 (ex : retirer tous les caractères non alphabétiques au début)
 */
.Select(word => word.Length > 1 ? word.Substring(1) : "")
 // Fonction pour retirer les 2 derniers caractères de la chaîne (si longueur suffisante)
.Select(word => word.Substring(0, word.Length - 2))
// Filtrer les données valides (ex: non vides)
.Where(word => !string.IsNullOrEmpty(word)).ToArray();



// PART 1 | C (DONNEES PARASITES 2)

/*
     
"+++++","<<<<<",">>>>>", "bonjour", "hello", "@@@@", "vert", "rouge", "bleu", "jaune","#####", "%%%%%%%"

Usage du skipWhile possible ? 



*/

string[] wordsPartC = { "+++++", "<<<<<", ">>>>>", "bonjour", "hello", "@@@@", "vert", "rouge", "bleu", "jaune", "#####", "%%%%%%%" };

var starts = wordsPartC
    //
    .SkipWhile((word, index) => word > index);

var result = wordsPartC.SkipWhile(word => Regex.IsMatch("test", "^[a-zA-Z]"));

