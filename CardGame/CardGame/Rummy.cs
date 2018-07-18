using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
    

    public partial class Rummy : Form
    {
        public Rummy()
        {
            Cards[] DOC = new Cards[52];
            Cards[] P1Cards = new Cards[7];
            Cards[] P2Cards = new Cards[7];
            Cards Back = new Cards();
            List<Cards> DeckDis = new List<Cards>();
            List<Cards> StackDis = new List<Cards>();
            int[] P1No = new int[7];
            int[] P2No = new int[7];
            List<int> Deck = new List<int>();
            List<int> Stack = new List<int>();
            for (int i = 0; i < 52; i++)
            {
                DOC[i] = new Cards();
            }
            for (int i = 0; i < 7; i++)
            {
                P1Cards[i] = new Cards();
            }
            for (int i = 0; i < 7; i++)
            {
                P2Cards[i] = new Cards();
            }
            Back.Image = Properties.Resources.BackCard;
            DeclareCards(ref DOC); //Sets up the images of each card.
            SepCardsPlayers(ref P1No, ref P2No);
            PlayersCards(ref DOC, P1Cards, ref P1No, ref P2No, P2Cards);
            DeclareDeck(ref Deck, ref P1No, ref P2No); //Finds the cards for the deck
            DeckCards(ref DOC, ref Deck,ref DeckDis);
            StackCards(ref Stack, ref StackDis, ref DeckDis, ref Deck, ref DOC);
            InitializeComponent();
            Bitmap bmp = new Bitmap(PicGame.Width,PicGame.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                for (int i = 0; i < 7; i++)
                {//Stack has to be 115 for the location.
                    g.DrawImage(P1Cards[i].Image,P1Cards[i].Location.X,P1Cards[i].Location.Y,P1Cards[i].SizeY,P1Cards[i].SizeX);
                    g.DrawImage(Back.Image, P2Cards[i].Location.X, P2Cards[i].Location.Y, P2Cards[i].SizeY, P2Cards[i].SizeX);
                }
                for (int i = 0; i < Deck.Count; i++)
                {
                    g.DrawImage(Back.Image, DeckDis[i].Location.X, DeckDis[i].Location.Y, DeckDis[i].SizeY, DeckDis[i].SizeX);
                }
                for (int i = 0; i < Stack.Count; i++)
                {
                    g.DrawImage(StackDis[i].Image, StackDis[i].Location.X, StackDis[i].Location.Y, StackDis[i].SizeY, StackDis[i].SizeX);
                }
       
            }
            PicGame.Image = bmp;   
        }
        void DeclareCards(ref Cards[] DOC)
        {
            for (int i = 0; i < 52; i++) //Differentiating between the suits.
            {
                if (i < 13)
                {
                    DOC[i].House = "Clubs"; //There are 13 cards in each suit
                }
                else if (i >= 13 && i < 26)
                {
   
                    DOC[i].House = "Hearts";
                }
                else if (i >= 26 && i < 39)
                {
                    DOC[i].House = "Diamonds";
                }
                else if (i >= 39 && i < 52)
                {
                    DOC[i].House = "Spades";
                }
                if (i == 0 || i == 13 || i == 26 || i == 39) //Separating the different number of cards
                {
                    DOC[i].Name = "Ace"; // For the four different suits.
                }
                else if (i == 1 || i == 14 || i == 27 || i == 40)
                {
                    DOC[i].Name = "Two";
                }
                else if (i == 2 || i == 15 || i == 28 || i == 41)
                {
                    DOC[i].Name = "Three";
                }
                else if (i == 3 || i == 16 || i == 29 || i == 42)
                {
                    DOC[i].Name = "Four";
                }
                else if (i == 4 || i == 17 || i == 30 || i == 43)
                {
                    DOC[i].Name = "Five";
                }
                else if (i == 5 || i == 18 || i == 31 || i == 44)
                {
                    DOC[i].Name = "Six";
                }
                else if (i == 6 || i == 19 || i == 32 || i == 45)
                {
                    DOC[i].Name = "Seven";
                }
                else if (i == 7 || i == 20 || i == 33 || i == 46)
                {
                    DOC[i].Name = "Eight";
                }
                else if (i == 8 || i == 21 || i == 34 || i == 47)
                {
                    DOC[i].Name = "Nine";
                }
                else if (i == 9 || i == 22 || i == 35 || i == 48)
                {
                    DOC[i].Name = "Ten";
                }
                else if (i == 10 || i == 23 || i == 36 || i == 49)
                {
                    DOC[i].Name = "Jack";
                }
                else if (i == 11 || i == 24 || i == 37 || i == 50)
                {
                    DOC[i].Name = "Queen";
                }
                else if (i == 12 || i == 25 || i == 38 || i == 51)
                {
                    DOC[i].Name = "King";
                }   
            }
            //Declare of the Image section
            //1
            //2
            //...
            //52
            DOC[0].Image = Properties.Resources.AceClubs;
            DOC[1].Image = Properties.Resources.TwoClubs;
            DOC[2].Image = Properties.Resources.ThreeClubs;
            DOC[3].Image = Properties.Resources.FourClubs;
            DOC[4].Image = Properties.Resources.FiveClubs;
            DOC[5].Image = Properties.Resources.SixClubs;
            DOC[6].Image = Properties.Resources.SevenClubs;
            DOC[7].Image = Properties.Resources.EightClubs;
            DOC[8].Image = Properties.Resources.NineClubs;
            DOC[9].Image = Properties.Resources.TenClubs;
            DOC[10].Image = Properties.Resources.JackClubs;
            DOC[11].Image = Properties.Resources.QueenClubs;
            DOC[12].Image = Properties.Resources.KingClubs;
            DOC[13].Image = Properties.Resources.AceHearts;
            DOC[14].Image = Properties.Resources.TwoHearts;
            DOC[15].Image = Properties.Resources.ThreeHearts;
            DOC[16].Image = Properties.Resources.FourHearts;
            DOC[17].Image = Properties.Resources.FiveHearts;
            DOC[18].Image = Properties.Resources.SixHearts;
            DOC[19].Image = Properties.Resources.SevenHearts;
            DOC[20].Image = Properties.Resources.EightHearts;
            DOC[21].Image = Properties.Resources.NineHearts;
            DOC[22].Image = Properties.Resources.TenofHearts;
            DOC[23].Image = Properties.Resources.JackHearts;
            DOC[24].Image = Properties.Resources.QueenHearts;
            DOC[25].Image = Properties.Resources.KingHearts;
            DOC[26].Image = Properties.Resources.AceDiamonds;
            DOC[27].Image = Properties.Resources.TwoDiamonds;
            DOC[28].Image = Properties.Resources.ThreeDiamonds;
            DOC[29].Image = Properties.Resources.FourDiamonds;
            DOC[30].Image = Properties.Resources.FiveDiamonds;
            DOC[31].Image = Properties.Resources.SixDiamonds;
            DOC[32].Image = Properties.Resources.SevenDiamonds;
            DOC[33].Image = Properties.Resources.EightDiamonds;
            DOC[34].Image = Properties.Resources.NineDiamonds;
            DOC[35].Image = Properties.Resources.TenDiamonds;
            DOC[36].Image = Properties.Resources.JackDiamonds;
            DOC[37].Image = Properties.Resources.QueenDiamonds;
            DOC[38].Image = Properties.Resources.KingsDiamonds;
            DOC[39].Image = Properties.Resources.AceSpades;
            DOC[40].Image = Properties.Resources.TwoSpades;
            DOC[41].Image = Properties.Resources.ThreeSpades;
            DOC[42].Image = Properties.Resources.FourSpades;
            DOC[43].Image = Properties.Resources.FiveSpades;
            DOC[44].Image = Properties.Resources.SixSpades;
            DOC[45].Image = Properties.Resources.SevenSpades;
            DOC[46].Image = Properties.Resources.EightSpades;
            DOC[47].Image = Properties.Resources.NineSpades;
            DOC[48].Image = Properties.Resources.TenSpades;
            DOC[49].Image = Properties.Resources.JackSpades;
            DOC[50].Image = Properties.Resources.QueenSpades;
            DOC[51].Image = Properties.Resources.KingSpades;





        }
        void SepCardsPlayers(ref int[] P1No, ref int[] P2No)
        {
            List<int> Dump = new List<int>();
            int Deck = 0;
            int RC = 0;
            Random RNG = new Random();
            for (int i = 0; i < 2; i++) //Multiple Players
              //Randomly assigning the numbers for the 14 individual cards.
            { //These should be unique.
                for (int j = 0; j < 7; j++) //Number of cards in the players hands.
            {
                Deck = RNG.Next(51);
                Dump.Add(Deck);
                    if (i == 0)
                    {
                     P1No[j] = Deck;
                 
                    }
                    else
                    {
                     P2No[j] = Deck;
                    }
            } //End For
            } //End For
              //Check for duplications using player 1 and play 2 hands.
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < Dump.Count; k++)
                        {
                        do
                        {
                        RC = RNG.Next(51);
                        if (P1No[i] == P2No[j] || P2No[j] == Dump[k])
                        {
                        P2No[j] = RC;
                        
                        }
                       } while (RC == Dump[k]);
                    }//Next is to focus on and use this same method but adjust it for the detection of the possiable duplication   
                } 
            }
            for (int i = 0; i < 7; i++) //Player 1
            {
                for (int j = 0; j < 7; j++)
                {
                    RC = RNG.Next(51);
                    if (P1No[i] == P1No[j] && i != j)
                    {
                        for (int k = 0; k <  Dump.Count; k++)
                        {
                            if (RC != Dump[k])
                            {
                                P1No[j] = RC;
                                Dump.Add(RC);
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < 7; i++) //Player 2
            {
                for (int j = 0; j < 7; j++)
                {
                    RC = RNG.Next(51);
                    if (P2No[i] == P2No[j] && i != j)
                    {
                        for (int k = 0; k < Dump.Count; k++)
                        {
                            if (RC != Dump[k])
                            {
                                P2No[j] = RC;
                                Dump.Add(RC);
                            }
                        }
                    }
                }
            }
        } //End Sub
        void PlayersCards(ref Cards[] DOC, Cards[] P1Cards, ref int[] P1No, ref int[] P2No, Cards[] P2Cards)
        {
            for (int PlayerNo = 0; PlayerNo < 2; PlayerNo++)
            {
            for (int C = 0; C < 7; C++)
            {
                    if (PlayerNo == 0)
                    {
                    P1Cards[C].House = DOC[P1No[C]].House;
                    P1Cards[C].Image = DOC[P1No[C]].Image;
                    P1Cards[C].Name = DOC[P1No[C]].Name;
                    P1Cards[C].Location = new Point(30+(C*50),250);
                    //P1Cards[C].Location = New point(<Insert Point Here>);    
                    }
                    else
                    {
                    P2Cards[C].House = DOC[P2No[C]].House;
                    P2Cards[C].Image = DOC[P2No[C]].Image;
                    P2Cards[C].Name = DOC[P2No[C]].Name;
                    P2Cards[C].Location = new Point(30+(C*50),20);

                        //P2Cards[C].Location = New point(<Insert Point Here>);    
                    } //End If
                }//End For
            } //End For
        } //End Sub
        void DeclareDeck(ref List<int> Deck, ref int[] P1No, ref int[] P2No) 
        {
            int[] CardsHeld = new int[14];
            for (int i = 0; i < 14; i++)
            {
                if (i < 7)
                {
                    CardsHeld[i] = P1No[i];
                }
                else
                {
                    CardsHeld[i] = P2No[i - 7];
                }
            }
            for (int i = 0; i < 52; i++) //adds all of the cards
            {
                Deck.Add(i);
            }
            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 52; j++)
                {
                    if (CardsHeld[i] == j)
                    {
                        Deck.Remove(j); //removes the cards which have been used.
                }

                }
            }
        }
        void DeckCards(ref Cards[] DOC,ref List<int> Deck, ref List<Cards> DeckDis)
        {
            for (int i = 0; i < Deck.Count; i++)
            {
                DeckDis.Add(DOC[i]);
            }
        }
        void StackCards(ref List<int> Stack, ref List<Cards> StackDis, ref List<Cards> DeckDis, ref List<int> Deck, ref Cards[] DOC)
        {
            int CurrentStack = 0;
            for (int i = 0; i < Deck.Count; i++)
            {
            CurrentStack = Deck[i];
            }
                
            
            Stack.Add(CurrentStack);
            Deck.Remove(CurrentStack);
            StackDis.Add(DOC[CurrentStack]);
            DeckDis.Remove(DOC[CurrentStack]);
            StackDis.ToArray();
            for (int i = 0; i < StackDis.Count; i++)
            {
                StackDis[i].Location = new Point(200, 130);
            }
            StackDis.ToList();
        }

        private void CmdTfs_Click(object sender, EventArgs e)
        {

        }
    }
    }

