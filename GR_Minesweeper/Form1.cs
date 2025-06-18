/* Gabriel Robinson
 * Ecole secondaire catholique Nouvelle-Alliance
 * ICS3U, Semestre 2, 2024-2025
 * 
 * Derniere modification : 18-06-2025
 * 
 * Description:
 * 
 * Cette programme est fait pour jouer le jeu de Minesweeper
 * Auquel que le but de ce jeu est de decouvrir tous les tuiles
 * Sans trouver une mine pour gagner. Ainsi, tu peux placer une
 * Drapeau pour marquer que cette tuile contient une bombe. Tu
 * perds le jeu quand tu ouvre une tuile qui a une bombe.
 * 
 * Hypothese:
 * 
 * L'utilisateur choisit la difficulte qu'il veut puis joue le jeu
 * Comme s'il jouait Minesweeper et essaie de gagner
*/

namespace GR_Minesweeper
{
    public partial class Niveau : Form
    {
        public Niveau()
        {
            InitializeComponent();
        }

        //Change de couleur si c'est marquer vrai ou pas
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (facile.Checked)
            {
                facile.ForeColor = Color.DarkGreen;
            }

            else 
            {
                facile.ForeColor = Color.Black;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (intermediaire.Checked)
            {
                intermediaire.ForeColor = Color.Goldenrod;
            }

            else
            {
                intermediaire.ForeColor = Color.Black;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (Expert.Checked)
            {
                Expert.ForeColor = Color.IndianRed;
            }

            else
            {
                Expert.ForeColor = Color.Black;
            }
        }

        //Ajuste le montant de mine, drapeau, rang et colonne
        private void Demarrer(object sender, EventArgs e)
        {
            int rangs = 0, colonnes = 0, bombes = 0, drapeaux = 0;
            String texte = "";

            //Si facile, intermediaire ou difficile est choisit
            if (facile.Checked)
            {
                rangs = colonnes = 10;
                bombes = drapeaux = 20;
                texte = "Minesweeper - Facile";
            }

            else if (intermediaire.Checked)
            {
                rangs = 10;
                colonnes = 20;
                bombes = drapeaux = 60;
                texte = "Minesweeper - Intermédiaire";
            }

            else if (Expert.Checked)
            {
                rangs = colonnes = 20;
                bombes = drapeaux = 150;
                texte = "Minesweeper - Expert";
            }

            else
                return;
            
            Form2 demarrer = new Form2(rangs, colonnes, bombes, drapeaux, texte);
            demarrer.Show();
        }
    }
}
