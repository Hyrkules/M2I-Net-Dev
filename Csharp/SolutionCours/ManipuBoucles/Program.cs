#region While

int unNombre = 5;

while (unNombre < 10)
{
    Console.WriteLine("Je continue... " + unNombre);
    unNombre++;
}

Console.WriteLine("Fin de Boucle...");

#endregion

#region Do...While, utile quand on veut par exemple un nom utilisateur

do
{
    Console.WriteLine("Je continue... " + unNombre);
    unNombre++;
} while (unNombre < 10);

#endregion

#region Continue...BREAK

int nombreEntier = 0;

while (nombreEntier <= 10)
{
    nombreEntier++;
    if (nombreEntier % 2 != 0) continue;
    Console.WriteLine(nombreEntier);
}

while (true)
{
    Console.WriteLine("Veuillez entrer stop pour arrêter la boucle");
    string monMot = Console.ReadLine();
    if (monMot == "STOP") break;
}

Console.WriteLine("Fin de la boucle");

#endregion

#region FOR 

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}

#endregion

#region FOR EACH

string unMotPlusOuMoinsLong = "Pomme de Terre";

for (int i = 0;i < unMotPlusOuMoinsLong.Length; i++) Console.WriteLine(unMotPlusOuMoinsLong[i]);

foreach (var item in unMotPlusOuMoinsLong) Console.WriteLine(item);

#endregion