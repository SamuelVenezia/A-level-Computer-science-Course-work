using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame //The game is throwing player one and player two cards can now be the same...?? Why. How???
{
    public partial class Rummy : Form
    {
        Random RNG = new Random();
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
        int Limbo = 0;
        Cards LimboCard = new Cards();
        string PriorCardName = "";
        bool PkFmDk = true;
        String[] NAMEHOUSE = new string[8];
        float Player1Points;
        float Player2Points;
        int NoOfMoves = 0;
        bool DeckVal = false;
        public Rummy()
        {

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
            DecPlayerCards(ref P1No, ref P2No); //Seporates players opening cards from the deck.
            PlayersCards(ref DOC, P1Cards, ref P1No, ref P2No, P2Cards);
            DeclareDeck(ref Deck, ref P1No, ref P2No); //Finds the cards for the deck
            DeckCards(ref DOC, ref Deck, ref DeckDis);
            StackCards(ref Stack, ref StackDis, ref DeckDis, ref Deck, ref DOC, ref RNG);
            Back.Location = new Point(120, 130);
            InitializeComponent();
            ComboStart(ref NAMEHOUSE);
            Bitmap bmp = new Bitmap(PicGame.Width, PicGame.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                for (int i = 0; i < 7; i++)
                {
                    g.DrawImage(P1Cards[i].Image, P1Cards[i].Location.X, P1Cards[i].Location.Y, P1Cards[i].SizeY, P1Cards[i].SizeX);
                    g.DrawImage(Back.Image, P2Cards[i].Location.X, P2Cards[i].Location.Y, P2Cards[i].SizeY, P2Cards[i].SizeX);
                }
                g.DrawImage(Back.Image, Back.Location.X, Back.Location.Y, Back.SizeY, Back.SizeX);
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
        void DecPlayerCards(ref int[] P1No, ref int[] P2No)
        {
            List<int> CardsAv = new List<int>();
            int PlCard;
            Random RNG = new Random();
            for (int i = 0; i < 52; i++)
            {
                CardsAv.Add(i);
            }
            for (int i = 0; i < 7; i++)
            {
                PlCard = RNG.Next(CardsAv.Count);
                P1No[i] = CardsAv[PlCard];
                CardsAv.RemoveAt(PlCard);
            }
            for (int i = 0; i < 7; i++)
            {
                PlCard = RNG.Next(CardsAv.Count);
                P2No[i] = CardsAv[PlCard];
                CardsAv.RemoveAt(PlCard);
            }
        }
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
                            P1Cards[C].Location = new Point(30 + (C * 50), 250);
                            //P1Cards[C].Location = New point(<Insert Point Here>);    
                        }
                        else
                        {
                            P2Cards[C].House = DOC[P2No[C]].House;
                            P2Cards[C].Image = DOC[P2No[C]].Image;
                            P2Cards[C].Name = DOC[P2No[C]].Name;
                            P2Cards[C].Location = new Point(30 + (C * 50), 20);
                            //P2Cards[C].Location = New point(<Insert Point Here>);    
                        } //End If
                    }//End For
                } //End For

            } //End Sub
        void DeclareDeck(ref List<int> Deck, ref int[] P1No, ref int[] P2No)
            {
                int[] P1P2Com = new int[14];
                for (int i = 0; i < 14; i++)
                {
                    if (i < 7)
                    {
                        P1P2Com[i] = P1No[i];
                    }
                    else if (i >= 7)
                    {
                        P1P2Com[i] = P2No[i - 7];
                    }
                }
                for (int i = 0; i < 52; i++)
                {
                    Deck.Add(i);
                }
                for (int i = 0; i < 14; i++)
                {
                    for (int j = 0; j < 52; j++)
                    {
                        if (P1P2Com[i] == j)
                        {
                            Deck.Remove(j);
                        }
                    }
                }
            }
        void DeckCards(ref Cards[] DOC, ref List<int> Deck, ref List<Cards> DeckDis)
            {
                for (int i = 0; i < Deck.Count; i++)
                {
                    DeckDis.Add(DOC[Deck[i]]);
                }
            }
        void StackCards(ref List<int> Stack, ref List<Cards> StackDis, ref List<Cards> DeckDis, ref List<int> Deck, ref Cards[] DOC, ref Random RNG)
        {
            int RNGCount = 0;
            int CurrentStack = 0;
            RNGCount = RNG.Next(Deck.Count);
            CurrentStack = Deck[RNGCount];
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
        void ComboStart(ref string[] NameHouse)
            {
            for (int i = 0; i < 7; i++)
            {
                NAMEHOUSE[i] = P1Cards[i].Name + " " + P1Cards[i].House;
                CmbCC.Items.Add(NAMEHOUSE[i]);
            }
            }
        void ComboDecision(ref string[] NameHouse, ref Cards Limbo)
            {
            for (int i = 0; i < 8; i++)
            {
                CmbCC.Items.Remove(NAMEHOUSE[i]);
            }  
            for (int i = 0; i < 8; i++)
            {
                if (i < 7)
                {
                    NAMEHOUSE[i] = P1Cards[i].Name + " " +  P1Cards[i].House;
                }
                else
                {
                    NAMEHOUSE[i] = LimboCard.Name + " " + LimboCard.House;
                }
                
            }
            for (int i = 0; i < 8; i++)
            {
                CmbCC.Items.Add(NAMEHOUSE[i]);
            }
        }
        void CheckDeck(ref List<int> Stack, ref List<int> Deck, ref int ElementLim)
            {
            for (int i = 0; i < Stack.Count; i++)
            {
                do
                {
                    if (Deck[ElementLim] == Stack[i])
                    {
                        ElementLim = RNG.Next(Deck.Count);
                        CheckDeck(ref Stack, ref Deck, ref ElementLim);
                    }
                } while (Deck[ElementLim] == Stack[i]);
            }
        }
        private void CmdMenu_Click(object sender, EventArgs e)
            {
            this.Hide();
            var Menu = new MMenu();
            Menu.Show();
            }
        private void CmdPfd_Click(object sender, EventArgs e)
        {//To renew the deck you need to remove from the deck, this will change the number inside of the list.
            if (PkFmDk == true)
            {
                int ElementLim = RNG.Next(Deck.Count);
                //If the stack has 38 elements then LCardDis (Card) LCard (Int) equals to last element in stack. 
                //Stack.Remove all exept the last element and StackDis.Remove all exept the last element.
                if (Stack.Count == 38)
                {
                    for (int i = 0; i < 37; i++)
                    {
                        Stack.RemoveAt(0);
                        StackDis.RemoveAt(0);
                    }
                    MessageBox.Show("Suffle of cards");
                }
                CheckDeck(ref Stack, ref Deck, ref ElementLim);

                Limbo = Deck[ElementLim];
                LimboCard = DOC[Limbo];
                LimboCard.Location = new Point(400,250);
                ComboDecision(ref NAMEHOUSE , ref LimboCard); 
                Bitmap bmp = new Bitmap(PicGame.Width, PicGame.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                for (int i = 0; i < 7; i++)
                {
                    g.DrawImage(P1Cards[i].Image, P1Cards[i].Location.X, P1Cards[i].Location.Y, P1Cards[i].SizeY, P1Cards[i].SizeX);
                    g.DrawImage(Back.Image, P2Cards[i].Location.X, P2Cards[i].Location.Y, P2Cards[i].SizeY, P2Cards[i].SizeX);
                }
                    g.DrawImage(Back.Image, Back.Location.X, Back.Location.Y, Back.SizeY, Back.SizeX);
                    g.DrawImage(LimboCard.Image, LimboCard.Location.X, LimboCard.Location.Y, LimboCard.SizeY, LimboCard.SizeX);
                    for (int i = 0; i < Stack.Count; i++)
                    {
                        g.DrawImage(StackDis[i].Image, StackDis[i].Location.X, StackDis[i].Location.Y, StackDis[i].SizeY, StackDis[i].SizeX);
                    }

                }
            PicGame.Image = bmp;
            PkFmDk = false;
            DeckVal = true;
            }
            else
            {
                MessageBox.Show("You need to select a card for you to put on the stack.");
            }
        }
        private void CmdPfs_Click(object sender, EventArgs e)
        {
            if (PkFmDk == true)
            {
                Limbo = Stack[Stack.Count - 1];
                LimboCard = StackDis[StackDis.Count - 1];
                LimboCard.Location = new Point(400, 250);
                Stack.Remove(Limbo);
                StackDis.Remove(LimboCard);
                Deck.Remove(Limbo);
                DeckDis.Remove(LimboCard);
                ComboDecision(ref NAMEHOUSE, ref LimboCard);

                Bitmap bmp = new Bitmap(PicGame.Width, PicGame.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    for (int i = 0; i < 7; i++)
                    {//Stack has to be 115 for the location.
                        g.DrawImage(P1Cards[i].Image, P1Cards[i].Location.X, P1Cards[i].Location.Y, P1Cards[i].SizeY, P1Cards[i].SizeX);
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
                    g.DrawImage(LimboCard.Image, LimboCard.Location.X, LimboCard.Location.Y, LimboCard.SizeY, LimboCard.SizeX);

                }
                PicGame.Image = bmp;
                PkFmDk = false;
                
            }
            else
            {
                MessageBox.Show("You need to select a card to put on the stack.");
            }
        }
        private void CmbCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Doesn't need to be used.
        }
        private void CmdPcb_Click(object sender, EventArgs e)
        {
            Cards PickedDump = new Cards();
            int PickedIntDump = 0;
            string Value;
            string Value2 = "";
            string Value3 = "";
            bool Split = false;
            Bitmap bmp = new Bitmap(PicGame.Width, PicGame.Height);
            if (PkFmDk == false)
            {
                Value = CmbCC.Text;
                if (Value != "" && Value != PriorCardName)
                {
                    char[] Val = Value.ToCharArray();
                    NoOfMoves++;
                    for (int i = 0; i < Value.Length; i++)
                    {
                        if (Val[i] == char.Parse(" "))
                        {
                            Split = true;
                        }
                        if (Val[i] != char.Parse(" ") && Split == false)
                        {
                            Value2 += Val[i].ToString();
                        }
                        else if (Val[i] != char.Parse(" ") && Split == true)
                        {
                            Value3 += Val[i].ToString();
                        }
                    } //Finding the name and house of the limbo card which has been either taken from the deck or the stack.

                    for (int j = 0; j < 7; j++)
                    {
                        if (P1Cards[j].Name == Value2 && P1Cards[j].House == Value3)
                        {
                            PickedDump = P1Cards[j]; //Picked dump is the card which will be moved from the hand.
                            PickedIntDump = P1No[j];
                        }
                    } 
                    if (LimboCard.Name == Value2 && LimboCard.House == Value3)
                    {
                        PickedDump = LimboCard;
                        PickedIntDump = Limbo;
                    }

                    PkFmDk = true;
                    if (DeckVal == true)
                    {
                        DeckDis.Remove(LimboCard);
                        Deck.Remove(Limbo);
                    }
                    
                    Deck.Add(PickedIntDump);
                    DeckDis.Add(PickedDump);
                    if (PickedDump == LimboCard)
                    {
                        
                        StackDis.Add(LimboCard);
                        Stack.Add(Limbo);
                        for (int i = 0; i < Stack.Count; i++)
                        {
                            StackDis[i].Location = new Point(200, 130);
                        }
                    }
                    else if (PickedDump == P1Cards[0])
                    {
                        StackDis.Add(P1Cards[0]);
                        Stack.Add(P1No[0]);
                        for (int i = 0; i < Stack.Count; i++)
                        {
                            StackDis[i].Location = new Point(200, 130);
                        }
                        P1No[0] = Limbo;
                        P1Cards[0] = LimboCard;
                        P1Cards[0].Location = new Point(30, 250);
                    }
                    else if (PickedDump == P1Cards[1])
                    {
                        StackDis.Add(P1Cards[1]);
                        Stack.Add(P1No[1]);
                        for (int i = 0; i < Stack.Count; i++)
                        {
                            StackDis[i].Location = new Point(200, 130);
                        }
                        P1No[1] = Limbo;
                        P1Cards[1] = LimboCard;
                        P1Cards[1].Location = new Point(80, 250);
                    }
                    else if (PickedDump == P1Cards[2])
                    {
                        StackDis.Add(P1Cards[2]);
                        Stack.Add(P1No[2]);
                        for (int i = 0; i < Stack.Count; i++)
                        {
                            StackDis[i].Location = new Point(200, 130);
                        }
                        P1No[2] = Limbo;
                        P1Cards[2] = LimboCard;
                        P1Cards[2].Location = new Point(130, 250);
                    }
                    else if (PickedDump == P1Cards[3])
                    {
                        StackDis.Add(P1Cards[3]);
                        Stack.Add(P1No[3]);
                        for (int i = 0; i < Stack.Count; i++)
                        {
                            StackDis[i].Location = new Point(200, 130);
                        }
                        P1No[3] = Limbo;
                        P1Cards[3] = LimboCard;
                        P1Cards[3].Location = new Point(180, 250);
                    }
                    else if (PickedDump == P1Cards[4])
                    {
                        StackDis.Add(P1Cards[4]);
                        Stack.Add(P1No[4]);
                        for (int i = 0; i < Stack.Count; i++)
                        {
                            StackDis[i].Location = new Point(200, 130);
                        }
                        P1No[4] = Limbo;
                        P1Cards[4] = LimboCard;
                        P1Cards[4].Location = new Point(230, 250);
                    }
                    else if (PickedDump == P1Cards[5])
                    {
                        StackDis.Add(P1Cards[5]);
                        Stack.Add(P1No[5]);
                        for (int i = 0; i < Stack.Count; i++)
                        {
                            StackDis[i].Location = new Point(200, 130);
                        }
                        P1No[5] = Limbo;
                        P1Cards[5] = LimboCard;
                        P1Cards[5].Location = new Point(280, 250);
                    }
                    else if (PickedDump == P1Cards[6])
                    {
                        StackDis.Add(P1Cards[6]);
                        Stack.Add(P1No[6]);
                        for (int i = 0; i < Stack.Count; i++)
                        {
                            StackDis[i].Location = new Point(200, 130);
                        }
                        P1No[6] = Limbo;
                        P1Cards[6] = LimboCard;
                        P1Cards[6].Location = new Point(330, 250);
                    }
                    //Needs to be the P1 card which is moved.
                    
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawImage(LimboCard.Image, LimboCard.Location.X, LimboCard.Location.Y, LimboCard.SizeY, LimboCard.SizeX);
                        for (int i = 0; i < 7; i++)
                        {
                            g.DrawImage(P1Cards[i].Image, P1Cards[i].Location.X, P1Cards[i].Location.Y, P1Cards[i].SizeY, P1Cards[i].SizeX);
                            g.DrawImage(Back.Image, P2Cards[i].Location.X, P2Cards[i].Location.Y, P2Cards[i].SizeY, P2Cards[i].SizeX);
                        }
                        g.DrawImage(Back.Image, Back.Location.X, Back.Location.Y, Back.SizeY, Back.SizeX);
                        for (int i = 0; i < Stack.Count; i++)
                        {
                            g.DrawImage(StackDis[i].Image, StackDis[i].Location.X, StackDis[i].Location.Y, StackDis[i].SizeY, StackDis[i].SizeX);

                        }
                    }
                    PicGame.Image = bmp;
                    PriorCardName = Value;
                    DeckVal = false;
                }
                else
                {
                    PkFmDk = false;
                }
            }
            else
            {
                MessageBox.Show("You need to take a card from either the Stack or the Deck.");
            }
        }//Used for the point for the NN's turn at playing.
        private void CmdCall_Click(object sender, EventArgs e)
        {//This will work by displaying player 2's last turn and then showing the user player 2's cards.
            Bitmap bmp = new Bitmap(PicGame.Width, PicGame.Height);
            string Winner;
            int[] CaUsed = new int[4];
            int[] Ca3Used = new int[3];
            int[] CaUsed2 = new int[4];
            int[] Ca3Used2 = new int[4];
            //Showing the player the rival players cards.
            using (Graphics g = Graphics.FromImage(bmp))
            {
                for (int i = 0; i < 7; i++)
                {
                    g.DrawImage(P1Cards[i].Image, P1Cards[i].Location.X, P1Cards[i].Location.Y, P1Cards[i].SizeY, P1Cards[i].SizeX);
                    g.DrawImage(P2Cards[i].Image, P2Cards[i].Location.X, P2Cards[i].Location.Y, P2Cards[i].SizeY, P2Cards[i].SizeX);
                }
                g.DrawImage(Back.Image, Back.Location.X, Back.Location.Y, Back.SizeY, Back.SizeX);

                for (int i = 0; i < Stack.Count; i++)
                {
                    g.DrawImage(StackDis[i].Image, StackDis[i].Location.X, StackDis[i].Location.Y, StackDis[i].SizeY, StackDis[i].SizeX);
                }

            }
            PicGame.Image = bmp;
            //Need to find out how to stop the code from using the same cards again
            ///Player 1 (The User)
            ///4 Card run
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 52; j++)
                {
                    if (P1No[i] == j)
                    {
                        for (int l = 0; l < 7; l++)
                        {
                            for (int m = 0; m < 7; m++)
                            {
                                for (int p = 0; p < 7; p++)
                                {
                                    if ((P1No[l] == j + 1 && P1No[m] == j - 1 && P1No[p] == j + 2) && (j != 13 || j != 26 || j != 39))
                                    {
                                        Player1Points = Player1Points + (j % 13 + 1) + ((j % 13 + 1) - 1) + ((j % 13 + 1) + 1) + ((j % 13 + 1) + 2);
                                        CaUsed[0] = j - 1;
                                        CaUsed[1] = j;
                                        CaUsed[2] = j + 1;
                                        CaUsed[3] = j + 2;
                                    }
                                }
                            }
                        }
                    }
                }
            } //End of four card run

            ///Three Card Run
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 52; j++)
                {
                    if (P1No[i] == j)
                    {
                        for (int l = 0; l < 7; l++)
                        {
                            for (int m = 0; m < 7; m++)
                            {
                                if ((P1No[l] == j + 1 && P1No[m] == j - 1) && (j != 13 || j != 26 || j != 39))
                                {
                                    if ((CaUsed[0] == P1No[m] || CaUsed[0] == P1No[i] || CaUsed[0] == P1No[l]) ||
                                        (CaUsed[1] == P1No[m] || CaUsed[1] == P1No[i] || CaUsed[0] == P1No[l]) ||
                                        (CaUsed[2] == P1No[m] || CaUsed[2] == P1No[i] || CaUsed[2] == P1No[l]) ||
                                        (CaUsed[3] == P1No[m] || CaUsed[3] == P1No[i] || CaUsed[3] == P1No[l]))
                                    {}
                                    else
                                    {
                                        if ((Ca3Used[0] == P1No[m] || Ca3Used[0] == P1No[i] || Ca3Used[0] == P1No[l]) ||
                                            (Ca3Used[1] == P1No[m] || Ca3Used[1] == P1No[i] || Ca3Used[1] == P1No[l]) ||
                                            (Ca3Used[2] == P1No[m] || Ca3Used[2] == P1No[i] || Ca3Used[2] == P1No[l]))
                                        {
                                        }
                                        else
                                        {
                                            Player1Points = Player1Points + (j % 13 + 1) + ((j % 13 + 1) + 1) + ((j % 13 + 1) - 1);
                                            Ca3Used[0] = j - 1;
                                            Ca3Used[1] = j;
                                            Ca3Used[2] = j + 1;
                                       }
                                    }
                                }
                            }
                        }
                    }
                }
            }//End of three card run

            ///Four card set for Player 1 or the User
            //Start of 4 card set
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 52; j++)
                {
                    if (P1No[i] == j)
                    {
                        for (int l = 0; l < 7; l++)
                        {
                            for (int m = 0; m < 7; m++)
                            {
                                for (int p = 0; p < 7; p++)
                                {
                                    if (P1No[l] == j + 13 && P1No[m] == j - 13 && P1No[p] == j + 26)
                                    {

                                        if (j == 0 || j == 13 || j == 26 || j == 39)
                                        {
                                            Player1Points = Player1Points + 40;
                                        }
                                        {
                                            Player1Points = Player1Points + (j % 13 + 1) + ((j % 13 + 1)) + ((j % 13 + 1)) + ((j % 13 + 1));
                                            CaUsed[0] = j - 13;
                                            CaUsed[1] = j;
                                            CaUsed[2] = j + 13;
                                            CaUsed[3] = j + 26;

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            } //End of four card set

            for (int C1 = 0; C1 < 7; C1++)
            {
                for (int i = 0; i < 52; i++)
                {
                    if (P1No[C1] == i)
                    {
                        for (int C2 = 0; C2 < 7; C2++)
                        {
                            for (int C3 = 0; C3 < 7; C3++)
                            { //Still need to validate this to make sure that it will not use any numbers for the 4 of a kinds and 4 runs. This will be used by the old three card set scorer.


                                if ((P1No[C2] == i + 13 || P1No[C2] == i - 13 || P1No[C2] == i + 26 || P1No[C2] == i - 26 || P1No[C2] == i + 39 || P1No[C2] == i - 39)
                                    && (P1No[C3] == i + 13 || P1No[C3] == i - 13 || P1No[C3] == i + 26 || P1No[C3] == i - 26 || P1No[C3] == i + 39 || P1No[C3] == i - 39)
                                    && ((P1No[C3] != P1No[C2]) && (P1No[C1] != P1No[C2]) && (P1No[C1] != P1No[C3])))
                                { //Need to make sure the odd cards can be halfed using a float. 
                                    if ((CaUsed[0] == P1No[C1] || CaUsed[0] == P1No[C2] || CaUsed[0] == P1No[C3]) ||
                                        (CaUsed[1] == P1No[C1] || CaUsed[1] == P1No[C2] || CaUsed[0] == P1No[C3]) ||
                                        (CaUsed[2] == P1No[C1] || CaUsed[2] == P1No[C2] || CaUsed[2] == P1No[C3]) ||
                                        (CaUsed[3] == P1No[C1] || CaUsed[3] == P1No[C2] || CaUsed[3] == P1No[C3]))
                                    {
                                    }
                                    else
                                    {
                                        if ((Ca3Used[0] == P1No[C1] || Ca3Used[0] == P1No[C2] || Ca3Used[0] == P1No[C3]) ||
                                           (Ca3Used[1] == P1No[C1] || Ca3Used[1] == P1No[C2] || Ca3Used[1] == P1No[C3]) ||
                                           (Ca3Used[2] == P1No[C1] || Ca3Used[2] == P1No[C2] || Ca3Used[2] == P1No[C3]))
                                        {
                                        }
                                        else
                                        {
                                            if (i == 0 || i == 13 || i == 26 || i == 39)
                                            {
                                                Player1Points = Player1Points + 30;
                                            }
                                            else
                                            {
                                                Player1Points = Player1Points + (i % 13 + 1) / 2f;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }//End of 3 of a kind.

            //End of player 1

            ///Player 2 (The Neural Network(s))
            ///4 Card run
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 52; j++)
                {
                    if (P2No[i] == j)
                    {
                        for (int l = 0; l < 7; l++)
                        {
                            for (int m = 0; m < 7; m++)
                            {
                                for (int p = 0; p < 7; p++)
                                {
                                    if ((P2No[l] == j + 1 && P2No[m] == j - 1 && P2No[p] == j + 2) && (j != 13 || j != 26 || j != 39))
                                    {
                                        Player2Points = Player2Points + (j % 13 + 1) + ((j % 13 + 1) - 1) + ((j % 13 + 1) + 1) + ((j % 13 + 1) + 2);
                                        CaUsed2[0] = j - 1;
                                        CaUsed2[1] = j;
                                        CaUsed2[2] = j + 1;
                                        CaUsed2[3] = j + 2;
                                    }
                                }
                            }
                        }
                    }
                }
            } //End of four card run

            ///Three Card Run
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 52; j++)
                {
                    if (P2No[i] == j)
                    {
                        for (int l = 0; l < 7; l++)
                        {
                            for (int m = 0; m < 7; m++)
                            {
                                if ((P2No[l] == j + 1 && P2No[m] == j - 1) && (j != 13 || j != 26 || j != 39))
                                {
                                    if ((CaUsed2[0] == P2No[m] || CaUsed2[0] == P2No[i] || CaUsed2[0] == P2No[l]) ||
                                        (CaUsed2[1] == P2No[m] || CaUsed2[1] == P2No[i] || CaUsed2[0] == P2No[l]) ||
                                        (CaUsed2[2] == P2No[m] || CaUsed2[2] == P2No[i] || CaUsed2[2] == P2No[l]) ||
                                        (CaUsed2[3] == P2No[m] || CaUsed2[3] == P2No[i] || CaUsed2[3] == P2No[l]))
                                    { }
                                    else
                                    {
                                        if ((Ca3Used2[0] == P2No[m] || Ca3Used2[0] == P2No[i] || Ca3Used2[0] == P2No[l]) ||
                                            (Ca3Used2[1] == P2No[m] || Ca3Used2[1] == P2No[i] || Ca3Used2[1] == P2No[l]) ||
                                            (Ca3Used2[2] == P2No[m] || Ca3Used2[2] == P2No[i] || Ca3Used2[2] == P2No[l]))
                                        {
                                        }
                                        else
                                        {
                                            Player2Points = Player2Points + (j % 13 + 1) + ((j % 13 + 1) + 1) + ((j % 13 + 1) - 1);
                                            Ca3Used2[0] = j - 1;
                                            Ca3Used2[1] = j;
                                            Ca3Used2[2] = j + 1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }//End of three card run

            ///Four card set for Player 2
            //Start of 4 card set
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 52; j++)
                {
                    if (P2No[i] == j)
                    {
                        for (int l = 0; l < 7; l++)
                        {
                            for (int m = 0; m < 7; m++)
                            {
                                for (int p = 0; p < 7; p++)
                                {
                                    if (P2No[l] == j + 13 && P2No[m] == j - 13 && P2No[p] == j + 26)
                                    {
                                        if (j == 0 || j == 13 || j == 26 || j == 39)
                                        {
                                            Player2Points = Player2Points + 40;
                                        }
                                        {
                                            Player2Points = Player2Points + (j % 13 + 1) + ((j % 13 + 1)) + ((j % 13 + 1)) + ((j % 13 + 1));
                                            CaUsed2[0] = j - 13;
                                            CaUsed2[1] = j;
                                            CaUsed2[2] = j + 13;
                                            CaUsed2[3] = j + 26;

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            } //End of four card set

            for (int C1 = 0; C1 < 7; C1++)
            {
                for (int i = 0; i < 52; i++)
                {
                    if (P2No[C1] == i)
                    {
                        for (int C2 = 0; C2 < 7; C2++)
                        {
                            for (int C3 = 0; C3 < 7; C3++)
                            { //Still need to validate this to make sure that it will not use any numbers for the 4 of a kinds and 4 runs. This will be used by the old three card set scorer.


                                if ((P2No[C2] == i + 13 || P2No[C2] == i - 13 || P2No[C2] == i + 26 || P2No[C2] == i - 26 || P2No[C2] == i + 39 || P2No[C2] == i - 39)
                                    && (P2No[C3] == i + 13 || P2No[C3] == i - 13 || P2No[C3] == i + 26 || P2No[C3] == i - 26 || P2No[C3] == i + 39 || P2No[C3] == i - 39)
                                    && ((P2No[C3] != P2No[C2]) && (P2No[C1] != P2No[C2]) && (P2No[C1] != P2No[C3])))
                                {
                                    if ((Ca3Used2[0] == P2No[C1] || Ca3Used2[0] == P2No[C2] || Ca3Used2[0] == P2No[C3]) ||
                                           (Ca3Used2[1] == P2No[C1] || Ca3Used2[1] == P2No[C2] || Ca3Used2[1] == P2No[C3]) ||
                                           (Ca3Used2[2] == P2No[C1] || Ca3Used2[2] == P2No[C2] || Ca3Used2[2] == P2No[C3]))
                                    {
                                    }
                                    else
                                    {
                                        Player2Points = Player2Points + (i % 13 + 1) / 2f;
                                    }
                                }
                            }
                        }
                    }
                }
            }//End of 3 of a kind.
            //End of Player 2


            ///Section for declaring the winner
            ///This is the section which shows the Message box and thus ending the game, it also shows some statistics of what has happened in the game.
            ///As well as showing who won the game and their points. This can be changed at a later date if it needs to.
            if (Player1Points > Player2Points)
            {
                Winner = "Player 1 has won the game with " + Player1Points.ToString() + " points. With " + NoOfMoves + " Cards taken.";
            }
            else if (Player1Points < Player2Points)
            {
                Winner = "Player 2 has won the game with " + Player2Points.ToString() + " points. With " + NoOfMoves + " Cards taken.";
            }
            else
            {
                Winner = "The game was a tie with "+ Player1Points.ToString() + " points each. With " + NoOfMoves + " Cards taken.";
            }
            MessageBox.Show(Winner);
            this.Hide();
            var Menu = new MMenu();
            Menu.Show();
        }
    }
    }

