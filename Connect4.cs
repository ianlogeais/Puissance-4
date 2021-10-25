using System;
using System.Collections.Generic;
using System.Text;

namespace Puissance4
{
    public class Connect4
    {
        private int ligne = 6;
        public int NombreLigne
        {
            get { return ligne; }
        }

        private int col = 7;
        public int NombreColonne => col;

        public char[,] tableau = new char[6, 7] {
            {' ',' ',' ',' ',' ',' ',' ', },
            {' ',' ',' ',' ',' ',' ',' ', },
            {' ',' ',' ',' ',' ',' ',' ', },
            {' ',' ',' ',' ',' ',' ',' ', },
            {' ',' ',' ',' ',' ',' ',' ', },
            {' ',' ',' ',' ',' ',' ',' ' }
        };

        public char Pion(int col, int line) => tableau[line, col];

        public char joueur = 'x';
        private int joueur1 = 1;
        public int Joueur1 => joueur1;

        public void Jouer(int col)
        {
            if (col > 0 && col < 8)
            {
                int dligne = DernierSlot(col - 1);
                if (dligne != -1)
                {
                    tableau[dligne, col - 1] = joueur;
                    if (Victoire() == '#')
                    {
                        if (joueur == 'x')
                        {
                            joueur = 'o';
                            joueur1 = 2;
                        }
                        else
                        {
                            joueur = 'x';
                            joueur1 = 1;
                        }
                    }
                }
            }
            else
            {
                Console.Error.WriteLine("Numéro de colonne invalide");
            }
        }

        // Etape 4 
        // Améliorer le Jouer pour qu'il détecte la victoire/nul et implémenter gagnant et Ended
        private int gagnant = 0;
        public int Gagnant => gagnant;

        public int SlotsDispo()
        {
            int slots = 0;
            for (int y = 0; y < ligne; y++)
            {
                for (int x = 0; x < col; x++)
                {
                    if (tableau[y, x] == ' ')
                    {
                        slots += 1;
                    }
                }
            }
            return slots;
        }

        public char Victoire()
        {
            for (int i = ligne - 1; i >= 0; --i)
            {

                for (int ix = col - 1; ix >= 0; --ix)
                {
                    try
                    {
                        if (tableau[i, ix] == joueur &&
                        tableau[i - 1, ix - 1] == joueur &&
                        tableau[i - 2, ix - 2] == joueur &&
                        tableau[i - 3, ix - 3] == joueur)
                        {
                            ended = true;
                            gagnant = joueur1;
                            return joueur;
                        }
                    }
                    catch { }


                    try
                    {
                        if (tableau[i, ix] == joueur &&
                        tableau[i, ix - 1] == joueur &&
                        tableau[i, ix - 2] == joueur &&
                        tableau[i, ix - 3] == joueur)
                        {
                            ended = true;
                            gagnant = joueur1;
                            return joueur;
                        }
                    }
                    catch { }

                    try
                    {
                        if (tableau[i, ix] == joueur &&
                        tableau[i - 1, ix] == joueur &&
                        tableau[i - 2, ix] == joueur &&
                        tableau[i - 3, ix] == joueur)
                        {
                            ended = true;
                            gagnant = joueur1;
                            return joueur;
                        }
                    }
                    catch { }


                    try
                    {
                        if (tableau[i, ix] == joueur &&
                        tableau[i - 1, ix + 1] == joueur &&
                        tableau[i - 2, ix + 2] == joueur &&
                        tableau[i - 3, ix + 3] == joueur)
                        {
                            ended = true;
                            gagnant = joueur1;
                            return joueur;
                        }
                    }
                    catch { }


                    try
                    {
                        if (tableau[i, ix] == joueur &&
                        tableau[i, ix + 1] == joueur &&
                        tableau[i, ix + 2] == joueur &&
                        tableau[i, ix + 3] == joueur)
                        {
                            ended = true;
                            gagnant = joueur1;
                            return joueur;
                        }
                    }
                    catch { }

                }

            }
            if (SlotsDispo() == 0)
            {
                ended = true;
                gagnant = 0;
                return '"';
            }
            return '#';
        }

        public int DernierSlot(int col)
        {
            for (int y = 5; y >= 0; y--)
            {

                if (tableau[y, col] == ' ')
                {
                    return y;
                }

            }
            return -1;
        }

        private bool ended = false;
        public bool Ended => ended;
    }
}
