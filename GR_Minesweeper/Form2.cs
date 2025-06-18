using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GR_Minesweeper
{
    public partial class Form2 : Form
    {
        private int rangs, colonnes, bombes, drapeaux;
        private string texte;

        private byte[,] Positions;
        private Button[,] BoutonListe;

        //Determine l'information assigner selon la niveau choisit dans le 1er form
        public Form2(int rangs, int colonnes, int bombes, int drapeaux, string texte)
        {
            InitializeComponent();

            this.rangs = rangs;
            this.colonnes = colonnes;
            this.bombes = bombes;
            this.drapeaux = drapeaux;
            this.texte = texte;

            Text = texte;

            this.Size = new Size(rangs * 22 + 100, colonnes * 25 + 50);

            pnlBody.Size = new Size(rangs * 22 + 100, colonnes * 25 + 50);

            Positions = new byte[rangs, colonnes];
            BoutonListe = new Button[rangs, colonnes];

            GenererBombes();
            GenererPositionValeur();
            GenererBoutons();

        }

        Random rnd = new Random();

        //0 represente qu'il n'a pas de valeur assigner
        //10 represente qu'une bombe est assigner sur cette position
        //Une valeur de 1 a 8 represente le nombre de bombe adjacente à cette position
        //20 represente une espace vide ou aucun bombe adjacent

        private void GenererBombes()
        {
            int bombe = 0;
            
            while (bombe < bombes)
            {
                int x = rnd.Next(0, (rangs - 1));
                int y = rnd.Next(0, (colonnes - 1));

                if (Positions[x, y] == 0)
                {
                    //Assigne une bombe sur cette position aléatoire
                    Positions[x, y] = 10;
                    bombe++;
                }
            }
        }

        private void GenererPositionValeur()
        {

            //Ces 2 boucles est pour boucler chaque position avec une valeur
            //Sur laquelle que ca va etre assigner
            for (int x = 0; x < rangs; x++)
            {
                for (int y = 0; y < colonnes; y++)
                {

                    //Eviter de verifier la position d'un bombe
                    if (Positions[x, y] == 10)
                        continue;

                    byte compteurBombes = 0;
                    //Ces 2 boucles est pour determiner ou de compter
                    //Combien de bombes adjacente qu'il a sur chaque position
                    for (int compteurX = -1; compteurX < 2; compteurX++)
                    {
                        int verificateurX = x + compteurX;

                        for (int compteurY = -1; compteurY < 2; compteurY++)
                        {
                            int verificateurY = y + compteurY;

                            //Signifie hors de limites, n'a pas besoin de verifier ces positions
                            if (verificateurX == -1 || verificateurY == -1 || verificateurX > rangs - 1 || verificateurY > colonnes - 1)
                                continue;

                            //Aussi si la position est similaire à x, y signifie que c'est la meme position
                            //Pas besoin de verifier
                            if (verificateurX == x && verificateurY == y)
                                continue;

                            if (Positions[verificateurX, verificateurY] == 10)
                                compteurBombes++;
                        }
                    }

                    //Signifie vide ou pas de bombe adjacente
                    if (compteurBombes == 0)
                        Positions[x, y] = 20;

                    else
                        Positions[x, y] = compteurBombes;
                }
            }
        }

        private void GenererBoutons()
        {

            //Commencer la position x du bouton
            int xLoc = 3;

            //Commencer la position y du bouton
            int yLoc = 6;

            for (int x = 0; x < rangs; x++)
            {
                for (int y = 0; y < colonnes; y++)
                {
                    Button boutons = new Button();
                    boutons.Parent = pnlBody;
                    boutons.Location = new Point(xLoc, yLoc);
                    boutons.Size = new Size(25, 22);
                    boutons.Tag = $"{x},{y}";
                    boutons.Click += BoutonsClick;
                    boutons.MouseUp += ClicDroitBoutons;
                    xLoc += 25;
                    BoutonListe[x, y] = boutons;
                }

                //Nouveau rang, besoin de configurer le xLoc
                //au position de commencement et augmenter la
                //Position yLoc
                yLoc += 22;
                xLoc = 3;
            }
        }

        int points = 0;

        private void BoutonsClick(object sender, EventArgs e)
        {
            Button boutons = (Button)sender;

            //...
            int x = Convert.ToInt32(boutons.Tag.ToString().Split(',').GetValue(0));
            int y = Convert.ToInt32(boutons.Tag.ToString().Split(',').GetValue(1));
            byte valeur = Positions[x, y];

            //Signifie qu'un bombe est ici
            if (valeur == 10)
            {
                boutons.Image = Properties.Resources.bomb;

                MessageBox.Show("Fin de la partie !");
                pnlBody.Enabled = false;
            }

            //Valeur vide
            else if (valeur == 20)
            {
                boutons.FlatStyle = FlatStyle.Flat;
                boutons.FlatAppearance.BorderSize = 1;
                boutons.FlatAppearance.BorderColor = SystemColors.ControlDark;
                boutons.Enabled = false;
                //...s'il en a/sont adjacente des tuiles vide, ca devra l'ouvrir tous au long

                OuvrirTuileVideAdjacente(boutons);

                points++;
            }

            else 
            {
                //Ceci est la celle pour les tuiles qui contient un ou plus de bombes adjacente
                boutons.FlatStyle = FlatStyle.Flat;
                boutons.FlatAppearance.BorderColor = SystemColors.ControlDark;
                boutons.FlatAppearance.MouseDownBackColor = boutons.BackColor;
                boutons.FlatAppearance.MouseOverBackColor = boutons.BackColor;
                boutons.Text = Positions[x, y].ToString();
                //...
                points++;
            }

            //Enleve l'auditeur de clic apres le cliquer
            boutons.Click -= BoutonsClick;
            
            //Pour afficher le score ou le nombre de tuiles ouvert
            Score.Text = points.ToString();
        }


        private void OuvrirTuileVideAdjacente(Button boutons)
        {
            int x = Convert.ToInt32(boutons.Tag.ToString().Split(',').GetValue(0));
            int y = Convert.ToInt32(boutons.Tag.ToString().Split(',').GetValue(1));

            //Cet liste est la liste des tuiles adjacentes qui sont vide
            List<Button> boutonsVide = new List<Button>();

            for (int compteurX = -1; compteurX < 2; compteurX++)
            {
                int verificateurX = x + compteurX;

                for (int compteurY = -1; compteurY < 2; compteurY++)
                {
                    int verificateurY = y + compteurY;

                    //Signifie hors de limites, n'a pas besoin de verifier ces positions
                    if (verificateurX == -1 || verificateurY == -1 || verificateurX > rangs - 1 || verificateurY > colonnes - 1)
                        continue;

                    //Aussi si la position est similaire à x, y signifie que c'est la meme position
                    //Pas besoin de verifier
                    if (verificateurX == x && verificateurY == y)
                        continue;

                    Button boutonsAdjacente = BoutonListe[verificateurX, verificateurY];

                    int xAdjacente = Convert.ToInt32(boutonsAdjacente.Tag.ToString().Split(',').GetValue(0));
                    int yAdjacente = Convert.ToInt32(boutonsAdjacente.Tag.ToString().Split(',').GetValue(1));

                    byte valeur = Positions[xAdjacente, yAdjacente];

                    if (valeur == 20)
                    {
                        //Pour verifier si la boutonsadjacente est deja
                        //Ouvert ou cliquer
                        if (boutonsAdjacente.FlatStyle != FlatStyle.Flat)
                        {
                            boutonsAdjacente.FlatStyle = FlatStyle.Flat;
                            boutonsAdjacente.FlatAppearance.BorderSize = 1;
                            boutons.FlatAppearance.BorderColor = SystemColors.ControlDark;
                            boutonsAdjacente.Enabled = false;
                            boutonsVide.Add(boutonsAdjacente);
                            points++;
                        }

                    }
                    
                    //Si ce n'est pas une bombe ni un bouton vide
                    //Ca ouvra quand meme, mais pas besoin d'ouvrir
                    //Les tuiles adjacente
                    else if (valeur != 10) 
                    { 
                        boutonsAdjacente.PerformClick();
                    }
                }
            }

            foreach (var boutonVide in boutonsVide) 
            {
                OuvrirTuileVideAdjacente(boutonVide);
            }

            Score.Text = points.ToString();
        }


        //Determine si s'ajoute ou enleve une drapeau
        //Selon la clic du bouton droit de l'utilisateur
        private void ClicDroitBoutons(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Button boutons = (Button)sender;
                
                if (boutons.FlatStyle != FlatStyle.Flat)
                {
                    if (boutons.Image == null)
                    {
                        
                        //Prevenir l'utilisateur de mettre plusieurs drapeaux
                        if (drapeaux > 0)
                        {
                            boutons.Image = Properties.Resources.drapeau;
                            boutons.Click -= BoutonsClick;
                            drapeaux--;
                        }

                        else
                        {
                            boutons.Image = null;
                        }

                    }
                    
                    else
                    {
                        boutons.Click += BoutonsClick;
                        boutons.Image = null;
                        drapeaux++;
                    }
                }


                Drapeau.Text = drapeaux.ToString();


            }

        }
    }
}
