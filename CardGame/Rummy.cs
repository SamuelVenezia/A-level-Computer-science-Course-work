using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CardGame
{
    public partial class Rummy : Form
    {
       
        NeuralNet net1 = new NeuralNet();
        Random RNG = new Random();
        Cards[] DOC = new Cards[52];
        Cards[] P1Cards = new Cards[7];
        Cards[] P2Cards = new Cards[7];
        Cards Back = new Cards();
        Cards LimboCard = new Cards();
        List<Cards> DeckDis = new List<Cards>();
        List<Cards> StackDis = new List<Cards>();
        string[] NAMEHOUSE = new string[8];
        string PriorCardName = "";
        int NoOfMoves = 0;
        float Player1Points;
        float Player2Points;
        bool PkFmDk = true;
        bool DeckVal = false;
        int FirstButton = 4;
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
            DecPlayerCards(ref P1Cards, ref P2Cards); //Seporates players opening cards from the deck.
            PlayersCards(ref DOC, ref P1Cards, ref P2Cards);
            DeclareDeck(ref DeckDis, ref P1Cards, ref P2Cards); //Finds the cards for the deck
   //         DeckCards(ref DOC, ref DeckDis);
            StackCards(ref StackDis, ref DeckDis, ref DOC, ref RNG);
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
                for (int i = 0; i < StackDis.Count; i++)
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
                DOC[i].Number = i;
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
                    DOC[i].Score = 1;
                }
                else if (i == 1 || i == 14 || i == 27 || i == 40)
                {
                    DOC[i].Score = 2;
                    DOC[i].Name = "Two";
                }
                else if (i == 2 || i == 15 || i == 28 || i == 41)
                {
                    DOC[i].Score = 3;
                    DOC[i].Name = "Three";
                }
                else if (i == 3 || i == 16 || i == 29 || i == 42)
                {
                    DOC[i].Score = 4;
                    DOC[i].Name = "Four";
                }
                else if (i == 4 || i == 17 || i == 30 || i == 43)
                {
                    DOC[i].Score = 5;
                    DOC[i].Name = "Five";
                }
                else if (i == 5 || i == 18 || i == 31 || i == 44)
                {
                    DOC[i].Score = 6;
                    DOC[i].Name = "Six";
                }
                else if (i == 6 || i == 19 || i == 32 || i == 45)
                {
                    DOC[i].Score = 7;
                    DOC[i].Name = "Seven";
                }
                else if (i == 7 || i == 20 || i == 33 || i == 46)
                {
                    DOC[i].Score = 8;
                    DOC[i].Name = "Eight";
                }
                else if (i == 8 || i == 21 || i == 34 || i == 47)
                {
                    DOC[i].Score = 9;
                    DOC[i].Name = "Nine";
                }
                else if (i == 9 || i == 22 || i == 35 || i == 48)
                {
                    DOC[i].Score = 10;
                    DOC[i].Name = "Ten";
                }
                else if (i == 10 || i == 23 || i == 36 || i == 49)
                {
                    DOC[i].Score = 10;
                    DOC[i].Name = "Jack";
                }
                else if (i == 11 || i == 24 || i == 37 || i == 50)
                {
                    DOC[i].Score = 10;
                    DOC[i].Name = "Queen";
                }
                else if (i == 12 || i == 25 || i == 38 || i == 51)
                {
                    DOC[i].Score = 10;
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
            net1.Initialize(1,52,16,3);
            //List<double> InValue = new List<double>();
            //List<double> InWeight = new List<double>();
            //    using (StreamReader CurrentFile = new StreamReader("Net1.txt"))
            //    {
            //        CurrentFile.ReadLine(); //Neuron
            //        CurrentFile.ReadLine(); //Output
            //        CurrentFile.ReadLine(); //Error
            //        CurrentFile.ReadLine(); //Last Error
            //        CurrentFile.ReadLine(); //Bias
            //    for (int i = 0; i < 16; i++)
            //    {
            //        CurrentFile.ReadLine(); //Input Name/Number
            //        InValue.Add(double.Parse(CurrentFile.ReadLine())); //Input Value
            //        InWeight.Add(double.Parse(CurrentFile.ReadLine())); //Input Weight
            //    }
            //    CurrentFile.ReadLine(); //Parent Bias
            //    CurrentFile.ReadLine(); //Sigmoid Function output
            //    CurrentFile.ReadLine(); //Neuron
            //    }

            //int l = 0;
            //foreach (Neuron on in net1.HiddenLayer)

            //    net1.OutputLayer[l].Input[on].Weight = InValue[l];
            //  //  foreach (KeyValuePair<INeuronSignal, NeuralFactor> f in on.Input)
            //        //{

            //    //    f.Value.Weight = InWeight[l];
            //    //    f.Key.Output = InValue[l];
            //    //}

            //    //  net1.OutputLayer[l].Input[on].
            //    l++;
          //  StringBuilder bld = new StringBuilder();
          //foreach (Neuron on in net1.OutputLayer)
          //  {
          //      ReadingNeuron(bld, on, net1);
          //  }
          //  MessageBox.Show(net1.OutputLayer[0].Output.ToString());
          //  MessageBox.Show(net1.OutputLayer[1].Output.ToString());
          //  MessageBox.Show(net1.OutputLayer[2].Output.ToString());
            //Neural Net Reading Into The Program
        } //Pseudo-Code Written
        private static void ReadingNeuron(StringBuilder bld, INeuron neuron, NeuralNet Net1)
        {
            #region Declarations

            int i;

            #endregion

            #region Initialization

            i = 0;

            #endregion
            using (StreamReader CurrentFile = new StreamReader("Net1.txt"))
            {
                CurrentFile.ReadLine();
                neuron.Output = double.Parse(CurrentFile.ReadLine());
                neuron.Error = double.Parse(CurrentFile.ReadLine());
                neuron.LastError = double.Parse(CurrentFile.ReadLine());
                neuron.Bias.Weight = double.Parse(CurrentFile.ReadLine());
                foreach (KeyValuePair<INeuronSignal, NeuralFactor> f in neuron.Input)
                {
                    CurrentFile.ReadLine();
                    Net1.HiddenLayer[i].Output = double.Parse(CurrentFile.ReadLine());
                    Net1.HiddenLayer[i].Bias.Weight = double.Parse(CurrentFile.ReadLine());
                    i++;
                }
                neuron.Bias.Weight = double.Parse(CurrentFile.ReadLine());
                Neuron.Sigmoid(double.Parse(CurrentFile.ReadLine()));

            }


        }
        void DecPlayerCards(ref Cards[] P1Cards, ref Cards[] P2Cards)
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
                P1Cards[i].Number = CardsAv[PlCard];
                CardsAv.RemoveAt(PlCard);
            }
            for (int i = 0; i < 7; i++)
            {
                PlCard = RNG.Next(CardsAv.Count);
                P2Cards[i].Number = CardsAv[PlCard];
                CardsAv.RemoveAt(PlCard);
            }
        } //Pseudo-Code Written
        void PlayersCards(ref Cards[] DOC, ref Cards[] P1Cards, ref Cards[] P2Cards)
        {
            for (int PlayerNo = 0; PlayerNo < 2; PlayerNo++)
            {
                for (int C = 0; C < 7; C++)
                {
                    if (PlayerNo == 0)
                    {
                        P1Cards[C].House = DOC[P1Cards[C].Number].House;
                        P1Cards[C].Image = DOC[P1Cards[C].Number].Image; 
                        P1Cards[C].Name = DOC[P1Cards[C].Number].Name;
                        P1Cards[C].Location = new Point(30 + (C * 50), 250);
                        //P1Cards[C].Location = New point(<Insert Point Here>);    
                    }
                    else
                    {
                        P2Cards[C].House = DOC[P2Cards[C].Number].House;
                        P2Cards[C].Image = DOC[P2Cards[C].Number].Image;
                        P2Cards[C].Name = DOC[P2Cards[C].Number].Name;
                        P2Cards[C].Location = new Point(30 + (C * 50), 20);
                        //P2Cards[C].Location = New point(<Insert Point Here>);    
                    } //End If
                }//End For
            } //End For

        } //Pseudo-code Written
        void DeclareDeck(ref List<Cards> DeckDis, ref Cards[] P1Cards, ref Cards[] P2Cards) 
        {
            int[] P1P2Com = new int[14];
            for (int i = 0; i < 14; i++)
            {
                if (i < 7)
                {
                    P1P2Com[i] = P1Cards[i].Number;
                }
                else if (i >= 7)
                {
                    P1P2Com[i] = P2Cards[i - 7].Number;
                }
            }
            for (int i = 0; i < 52; i++)
            {
                DeckDis.Add(DOC[i]);
            }
            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 52; j++)
                {
                    if (P1P2Com[i] == j)
                    {
                        DeckDis.Remove(DOC[j]);
                    }
                }
            }
        } //Pseudo-Code Written
        void StackCards(ref List<Cards> StackDis, ref List<Cards> DeckDis, ref Cards[] DOC, ref Random RNG)
        {
            int RNGCount = 0;
            int CurrentStack = 0;
            RNGCount = RNG.Next(DeckDis.Count);
            CurrentStack = DeckDis[RNGCount].Number;
            StackDis.Add(DOC[CurrentStack]);
            DeckDis.Remove(DOC[CurrentStack]);
            StackDis.ToArray();
            for (int i = 0; i < StackDis.Count; i++)
            {
                StackDis[i].Location = new Point(200, 130);
            }
            StackDis.ToList();
        } //Pseudo-Code Written
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
                    NAMEHOUSE[i] = P1Cards[i].Name + " " + P1Cards[i].House;
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
        void CheckDeck(ref List<Cards> StackDis, ref List<Cards> DeckDis, ref int ElementLim)
        {
            for (int i = 0; i < StackDis.Count; i++)
            {
                do
                {
                    if (DeckDis[ElementLim] == StackDis[i])
                    {
                        ElementLim = RNG.Next(DeckDis.Count);
                        CheckDeck(ref StackDis, ref DeckDis, ref ElementLim);
                    }
                } while (DeckDis[ElementLim] == StackDis[i]);
            }
        } //Pseudo-Code Written
        //Neural Network Subroutines for the Outputs for the first NN.
        void NNTFD()
        {
            int ElementLim = 0;
            if (StackDis.Count == 38)
            {
                ElementLim = RNG.Next(DeckDis.Count);
                for (int i = 0; i < 37; i++)
                {
                    StackDis.RemoveAt(0);
                }
                MessageBox.Show("Suffle cards");
            }
            CheckDeck(ref StackDis, ref DeckDis, ref ElementLim);

            LimboCard = DeckDis[ElementLim];
            LimboCard.Location = new Point(400, 250);
            ComboDecision(ref NAMEHOUSE, ref LimboCard);
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
                for (int i = 0; i < StackDis.Count; i++)
                {
                    g.DrawImage(StackDis[i].Image, StackDis[i].Location.X, StackDis[i].Location.Y, StackDis[i].SizeY, StackDis[i].SizeX);
                }

            }
            PicGame.Image = bmp;
            PkFmDk = false;
            DeckVal = true;
    }
        void NNTFS()
        {
            LimboCard = StackDis[StackDis.Count - 1];
            LimboCard.Location = new Point(400, 250);
            StackDis.Remove(LimboCard);
            DeckDis.Remove(LimboCard);
            ComboDecision(ref NAMEHOUSE, ref LimboCard);

            Bitmap bmp = new Bitmap(PicGame.Width, PicGame.Height);
            using (Graphics g = Graphics.FromImage(bmp)) //Update the grid view display
            {
                for (int i = 0; i < 7; i++)
                {
                    g.DrawImage(P1Cards[i].Image, P1Cards[i].Location.X, P1Cards[i].Location.Y, P1Cards[i].SizeY, P1Cards[i].SizeX);
                    g.DrawImage(Back.Image, P2Cards[i].Location.X, P2Cards[i].Location.Y, P2Cards[i].SizeY, P2Cards[i].SizeX);
                }
                for (int i = 0; i < DeckDis.Count; i++)
                {
                    g.DrawImage(Back.Image, DeckDis[i].Location.X, DeckDis[i].Location.Y, DeckDis[i].SizeY, DeckDis[i].SizeX);
                }
                for (int i = 0; i < StackDis.Count; i++)
                {
                    g.DrawImage(StackDis[i].Image, StackDis[i].Location.X, StackDis[i].Location.Y, StackDis[i].SizeY, StackDis[i].SizeX);

                }
                g.DrawImage(LimboCard.Image, LimboCard.Location.X, LimboCard.Location.Y, LimboCard.SizeY, LimboCard.SizeX);

            }
            PicGame.Image = bmp;
            PkFmDk = false;

        }
        void Call()
        {
            Bitmap bmp = new Bitmap(PicGame.Width, PicGame.Height);
            string Winner;
            int[] CaUsed = new int[4];
            int[] Ca3Used = new int[3];
            int[] Ca32Used = new int[3];
            int[] CaUsed2 = new int[4];
            int[] Ca3Used2 = new int[3];
            int[] Ca32Used2 = new int[3];
            bool Check = false;
            FirstButton = 0;
            //Showing the player the rival players cards.
            using (Graphics g = Graphics.FromImage(bmp))
            {
                for (int i = 0; i < 7; i++)
                {
                    g.DrawImage(P1Cards[i].Image, P1Cards[i].Location.X, P1Cards[i].Location.Y, P1Cards[i].SizeY, P1Cards[i].SizeX);
                    g.DrawImage(P2Cards[i].Image, P2Cards[i].Location.X, P2Cards[i].Location.Y, P2Cards[i].SizeY, P2Cards[i].SizeX);
                }
                g.DrawImage(Back.Image, Back.Location.X, Back.Location.Y, Back.SizeY, Back.SizeX);

                for (int i = 0; i < StackDis.Count; i++)
                {
                    g.DrawImage(StackDis[i].Image, StackDis[i].Location.X, StackDis[i].Location.Y, StackDis[i].SizeY, StackDis[i].SizeX);
                }

            }
            PicGame.Image = bmp;
            for (int i = 0; i < 3; i++)
            {
                CaUsed[i] = 0;
            }
            for (int i = 0; i < 3; i++)
            {
                Ca3Used[i] = 0;
            }
            //Player 1
            //4 Card Run
            for (int C4 = 0; C4 < 7; C4++)
            {
                for (int C3 = 0; C3 < 7; C3++)
                {
                    for (int C2 = 0; C2 < 7; C2++)
                    {
                        for (int C1 = 0; C1 < 7; C1++)
                        {
                            if ((P1Cards[C1].Number + 1 == P1Cards[C2].Number || P1Cards[C1].Number + 2 == P1Cards[C2].Number) &&
                                (P1Cards[C2].Number + 1 == P1Cards[C3].Number || P1Cards[C2].Number + 2 == P1Cards[C3].Number) &&
                                (P1Cards[C3].Number + 1 == P1Cards[C4].Number || P1Cards[C3].Number + 2 == P1Cards[C4].Number) &&
                                (C1 != C2 && C1 != C3 && C1 != C4 && C2 != C3 && C2 != C4 && C3 != C4) &&
                                (P1Cards[C1].House == P1Cards[C2].House && P1Cards[C1].House == P1Cards[C3].House && P1Cards[C1].House == P1Cards[C4].House && 
                                 P1Cards[C2].House == P1Cards[C3].House && P1Cards[C2].House == P1Cards[C4].House && P1Cards[C3].House == P1Cards[C4].House))
                            {
                                Player1Points = Player1Points+ (P1Cards[C1].Number % 13 + 1) + (P1Cards[C2].Number % 13 + 1) + (P1Cards[C3].Number % 13 + 1 + (P1Cards[C4].Number % 13 + 1));
                                CaUsed[0] = P1Cards[C1].Number;
                                CaUsed[1] = P1Cards[C2].Number;
                                CaUsed[2] = P1Cards[C3].Number;
                                CaUsed[3] = P1Cards[C4].Number;
                            }
                        }
                    }
                }
            }
            //3 Card Run
            for (int C3 = 0; C3 < 7; C3++)
            {
                for (int C2 = 0; C2 < 7; C2++)
                {
                    for (int C1 = 0; C1 < 7; C1++)
                    { //If P1Card[C1].Number 
                        if ((P1Cards[C1].Number + 1 == P1Cards[C2].Number && P1Cards[C2].Number + 1 == P1Cards[C3].Number && P1Cards[C1].Number + 2 == P1Cards[C3].Number) &&
                            (C2 != C1 && C2 != C3 && C1 != C3) && 
                            (P1Cards[C1].House == P1Cards[C2].House && P1Cards[C1].House == P1Cards[C3].House && P1Cards[C2].House == P1Cards[C3].House))
                        {
                            if ((CaUsed[0] == P1Cards[C3].Number || CaUsed[0] == P1Cards[C2].Number || CaUsed[0] == P1Cards[C1].Number) ||
                                (CaUsed[1] == P1Cards[C3].Number || CaUsed[1] == P1Cards[C2].Number || CaUsed[0] == P1Cards[C1].Number) ||
                                (CaUsed[2] == P1Cards[C3].Number || CaUsed[2] == P1Cards[C2].Number || CaUsed[2] == P1Cards[C1].Number) ||
                                (CaUsed[3] == P1Cards[C3].Number || CaUsed[3] == P1Cards[C2].Number || CaUsed[3] == P1Cards[C1].Number) && Check == true 
                                && (CaUsed[0] == 0 && CaUsed[1] == 0 && CaUsed[2] == 0 && CaUsed[3] == 0) &&
                                   (Ca32Used[0] == P1Cards[C3].Number || Ca32Used[0] == P1Cards[C2].Number || Ca32Used[0] == P1Cards[C1].Number) ||
                                   (Ca32Used[1] == P1Cards[C3].Number || Ca32Used[1] == P1Cards[C2].Number || Ca32Used[0] == P1Cards[C1].Number) ||
                                   (Ca32Used[2] == P1Cards[C3].Number || Ca32Used[2] == P1Cards[C2].Number || Ca32Used[2] == P1Cards[C1].Number))
                            {
                            }
                            else
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    Ca32Used[i] = Ca3Used[i];
                                }
                                Check = true;
                                Player1Points = Player1Points + (P1Cards[C1].Number % 13 + 1) + (P1Cards[C2].Number % 13 + 1) + (P1Cards[C3].Number % 13 + 1);
                                Ca3Used[0] = P1Cards[C1].Number;
                                Ca3Used[1] = P1Cards[C2].Number;
                                Ca3Used[2] = P1Cards[C3].Number;
                            }

                        }
                    }
                }
            }
            //4 of a kind ... Working
            for (int C1 = 0; C1 < 7; C1++)
            {
                for (int C2 = 0; C2 < 7; C2++)
                {
                    for (int C3 = 0; C3 < 7; C3++)
                    {
                        for (int C4 = 0; C4 < 7; C4++)
                        {
                            if ((P1Cards[C1].Name == P1Cards[C2].Name) && (P1Cards[C2].Name == P1Cards[C3].Name) && (P1Cards[C3].Name == P1Cards[C4].Name) &&
                                C1 != C2 && C1 != C3 && C1 != C4 && C2 != C3 && C2 != C4 && C3 != C4)
                            {
                                if ((CaUsed[0] == P1Cards[C4].Number) || (CaUsed[0] == P1Cards[C3].Number || CaUsed[0] == P1Cards[C2].Number || CaUsed[0] == P1Cards[C1].Number) ||
                                    (CaUsed[1] == P1Cards[C4].Number) || (CaUsed[1] == P1Cards[C3].Number || CaUsed[1] == P1Cards[C2].Number || CaUsed[0] == P1Cards[C1].Number) ||
                                    (CaUsed[2] == P1Cards[C4].Number) || (CaUsed[2] == P1Cards[C3].Number || CaUsed[2] == P1Cards[C2].Number || CaUsed[2] == P1Cards[C1].Number) ||
                                    (CaUsed[3] == P1Cards[C4].Number) || (CaUsed[3] == P1Cards[C3].Number || CaUsed[3] == P1Cards[C2].Number || CaUsed[3] == P1Cards[C1].Number))
                                {
                                }
                                else
                                {
                                    if ((Ca3Used[0] == P1Cards[C4].Number || Ca3Used[0] == P1Cards[C3].Number || Ca3Used[0] == P1Cards[C2].Number || Ca3Used[0] == P1Cards[C1].Number) ||
                                        (Ca3Used[1] == P1Cards[C4].Number || Ca3Used[1] == P1Cards[C3].Number || Ca3Used[1] == P1Cards[C2].Number || Ca3Used[0] == P1Cards[C1].Number) ||
                                        (Ca3Used[2] == P1Cards[C4].Number || Ca3Used[2] == P1Cards[C3].Number || Ca3Used[2] == P1Cards[C2].Number || Ca3Used[2] == P1Cards[C1].Number) /*&& Check == true*/)
                                    {
                                    }
                                    else
                                    {
                                        Player1Points = Player1Points + (P1Cards[C1].Number % 13 + 1)+ (P1Cards[C2].Number % 13 + 1) + (P1Cards[C3].Number % 13 + 1) + (P1Cards[C4].Number % 13 + 1);
                                        CaUsed[0] = P1Cards[C1].Number;
                                        CaUsed[1] = P1Cards[C2].Number;
                                        CaUsed[2] = P1Cards[C3].Number;
                                        CaUsed[3] = P1Cards[C4].Number;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //3 of a Kind
            for (int C3 = 0; C3 < 7; C3++)
            {
                for (int C2 = 0; C2 < 7; C2++)
                {
                    for (int C1 = 0; C1 < 7; C1++)
                    { //If P1Card[C1].Number 
                        if ((P1Cards[C1].Name == P1Cards[C2].Name) && (P1Cards[C2].Name == P1Cards[C3].Name) && 
                            (P1Cards[C1].Name == P1Cards[C3].Name) && (C2 != C1 && C2 != C3 && C1 != C3))
                        {
                            if ((CaUsed[0] == P1Cards[C3].Number || CaUsed[0] == P1Cards[C2].Number || CaUsed[0] == P1Cards[C1].Number) ||
                               (CaUsed[1] == P1Cards[C3].Number || CaUsed[1] == P1Cards[C2].Number || CaUsed[0] == P1Cards[C1].Number) ||
                               (CaUsed[2] == P1Cards[C3].Number || CaUsed[2] == P1Cards[C2].Number || CaUsed[2] == P1Cards[C1].Number) ||
                               (CaUsed[3] == P1Cards[C3].Number || CaUsed[3] == P1Cards[C2].Number || CaUsed[3] == P1Cards[C1].Number))
                            {
                            }
                            else
                            {
                                if ((Ca3Used[0] == P1Cards[C3].Number || Ca3Used[0] == P1Cards[C2].Number || Ca3Used[0] == P1Cards[C1].Number) ||
                                    (Ca3Used[1] == P1Cards[C3].Number || Ca3Used[1] == P1Cards[C2].Number || Ca3Used[0] == P1Cards[C1].Number) ||
                                    (Ca3Used[2] == P1Cards[C3].Number || Ca3Used[2] == P1Cards[C2].Number || Ca3Used[2] == P1Cards[C1].Number) &&
                                    (CaUsed[0] == 0 && CaUsed[1] == 0 && CaUsed[2] == 0 && CaUsed[3] == 0) &&
                                    (Ca32Used[0] == P1Cards[C3].Number || Ca32Used[0] == P1Cards[C2].Number || Ca32Used[0] == P1Cards[C1].Number) ||
                                    (Ca32Used[1] == P1Cards[C3].Number || Ca32Used[1] == P1Cards[C2].Number || Ca32Used[0] == P1Cards[C1].Number) ||
                                    (Ca32Used[2] == P1Cards[C3].Number || Ca32Used[2] == P1Cards[C2].Number || Ca32Used[2] == P1Cards[C1].Number))
                                {
                                }
                                else {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        Ca32Used[i] = Ca3Used[i];
                                    }
                                Player1Points = Player1Points + (P1Cards[C1].Number % 13 + 1) + (P1Cards[C2].Number % 13 + 1) + (P1Cards[C3].Number % 13 + 1); //Scoring adjusted.
                                Ca3Used[0] = P1Cards[C1].Number;
                                Ca3Used[1] = P1Cards[C2].Number;
                                Ca3Used[2] = P1Cards[C3].Number;
                                }
                            
                            }                          
                        }
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                CaUsed2[i] = 0;
            }
            for (int i = 0; i < 3; i++)
            {
                Ca3Used2[i] = 0;
            }
            //Player 2
            //4 Card Run
            Check = false;
            for (int C4 = 0; C4 < 7; C4++)
            {
                for (int C3 = 0; C3 < 7; C3++)
                {
                    for (int C2 = 0; C2 < 7; C2++)
                    {
                        for (int C1 = 0; C1 < 7; C1++)
                        {
                            if ((P2Cards[C1].Number + 1 == P2Cards[C2].Number || P2Cards[C1].Number + 2 == P2Cards[C2].Number) &&
                                (P2Cards[C2].Number + 1 == P2Cards[C3].Number || P2Cards[C2].Number + 2 == P2Cards[C3].Number) &&
                                (P2Cards[C3].Number + 1 == P2Cards[C4].Number || P2Cards[C3].Number + 2 == P2Cards[C4].Number) &&
                                (C1 != C2 && C1 != C3 && C1 != C4 && C2 != C3 && C2 != C4 && C3 != C4) &&
                                (P2Cards[C1].House == P2Cards[C2].House && P2Cards[C1].House == P2Cards[C3].House && P2Cards[C1].House == P2Cards[C4].House &&
                                 P2Cards[C2].House == P2Cards[C3].House && P2Cards[C2].House == P2Cards[C4].House && P2Cards[C3].House == P2Cards[C4].House))
                            {
                                Player2Points = Player2Points + (P2Cards[C1].Number % 13 + 1) + (P2Cards[C2].Number % 13 + 1) + (P2Cards[C3].Number % 13 + 1 + (P2Cards[C4].Number % 13 + 1));
                                CaUsed2[0] = P2Cards[C1].Number;
                                CaUsed2[1] = P2Cards[C2].Number;
                                CaUsed2[2] = P2Cards[C3].Number;
                                CaUsed2[3] = P2Cards[C4].Number;
                            }
                        }
                    }
                }
            }
            //3 Card Run
            for (int C3 = 0; C3 < 7; C3++)
            {
                for (int C2 = 0; C2 < 7; C2++)
                {
                    for (int C1 = 0; C1 < 7; C1++)
                    { //If P2Card[C1].Number 
                        if ((P2Cards[C1].Number + 1 == P2Cards[C2].Number && P2Cards[C2].Number + 1 == P2Cards[C3].Number && P2Cards[C1].Number + 2 == P2Cards[C3].Number) &&
                            (C2 != C1 && C2 != C3 && C1 != C3) &&
                            (P2Cards[C1].House == P2Cards[C2].House && P2Cards[C1].House == P2Cards[C3].House && P2Cards[C2].House == P2Cards[C3].House))
                        {
                            if ((CaUsed2[0] == P2Cards[C3].Number || CaUsed2[0] == P2Cards[C2].Number || CaUsed2[0] == P2Cards[C1].Number) ||
                                (CaUsed2[1] == P2Cards[C3].Number || CaUsed2[1] == P2Cards[C2].Number || CaUsed2[0] == P2Cards[C1].Number) ||
                                (CaUsed2[2] == P2Cards[C3].Number || CaUsed2[2] == P2Cards[C2].Number || CaUsed2[2] == P2Cards[C1].Number) ||
                                (CaUsed2[3] == P2Cards[C3].Number || CaUsed2[3] == P2Cards[C2].Number || CaUsed2[3] == P2Cards[C1].Number) && Check == true
                                && (CaUsed2[0] == 0 && CaUsed2[1] == 0 && CaUsed2[2] == 0 && CaUsed2[3] == 0) &&
                                   (Ca32Used2[0] == P2Cards[C3].Number || Ca32Used2[0] == P2Cards[C2].Number || Ca32Used2[0] == P2Cards[C1].Number) ||
                                   (Ca32Used2[1] == P2Cards[C3].Number || Ca32Used2[1] == P2Cards[C2].Number || Ca32Used2[0] == P2Cards[C1].Number) ||
                                   (Ca32Used2[2] == P2Cards[C3].Number || Ca32Used2[2] == P2Cards[C2].Number || Ca32Used2[2] == P2Cards[C1].Number))
                            {
                            }
                            else
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    Ca32Used2[i] = Ca3Used2[i];
                                }
                                Check = true;
                                Player2Points = Player2Points + (P2Cards[C1].Number % 13 + 1) + (P2Cards[C2].Number % 13 + 1) + (P2Cards[C3].Number % 13 + 1);
                                Ca3Used2[0] = P2Cards[C1].Number;
                                Ca3Used2[1] = P2Cards[C2].Number;
                                Ca3Used2[2] = P2Cards[C3].Number;
                            }

                        }
                    }
                }
            }
            //4 of a kind
            for (int C1 = 0; C1 < 7; C1++)
            {
                for (int C2 = 0; C2 < 7; C2++)
                {
                    for (int C3 = 0; C3 < 7; C3++)
                    {
                        for (int C4 = 0; C4 < 7; C4++)
                        {
                            if ((P2Cards[C1].Name == P2Cards[C2].Name) && (P2Cards[C2].Name == P2Cards[C3].Name) && (P2Cards[C3].Name == P2Cards[C4].Name) &&
                                C1 != C2 && C1 != C3 && C1 != C4 && C2 != C3 && C2 != C4 && C3 != C4)
                            {
                                if ((CaUsed2[0] == P2Cards[C4].Number) || (CaUsed2[0] == P2Cards[C3].Number || CaUsed2[0] == P2Cards[C2].Number || CaUsed2[0] == P2Cards[C1].Number) ||
                                    (CaUsed2[1] == P2Cards[C4].Number) || (CaUsed2[1] == P2Cards[C3].Number || CaUsed2[1] == P2Cards[C2].Number || CaUsed2[0] == P2Cards[C1].Number) ||
                                    (CaUsed2[2] == P2Cards[C4].Number) || (CaUsed2[2] == P2Cards[C3].Number || CaUsed2[2] == P2Cards[C2].Number || CaUsed2[2] == P2Cards[C1].Number) ||
                                    (CaUsed2[3] == P2Cards[C4].Number) || (CaUsed2[3] == P2Cards[C3].Number || CaUsed2[3] == P2Cards[C2].Number || CaUsed2[3] == P2Cards[C1].Number))
                                {
                                }
                                else
                                {
                                    if ((Ca3Used2[0] == P2Cards[C4].Number || Ca3Used2[0] == P2Cards[C3].Number || Ca3Used2[0] == P2Cards[C2].Number || Ca3Used2[0] == P2Cards[C1].Number) ||
                                        (Ca3Used2[1] == P2Cards[C4].Number || Ca3Used2[1] == P2Cards[C3].Number || Ca3Used2[1] == P2Cards[C2].Number || Ca3Used2[0] == P2Cards[C1].Number) ||
                                        (Ca3Used2[2] == P2Cards[C4].Number || Ca3Used2[2] == P2Cards[C3].Number || Ca3Used2[2] == P2Cards[C2].Number || Ca3Used2[2] == P2Cards[C1].Number) /*&& Check == true*/)
                                    {
                                    }
                                    else
                                    {
                                        Player2Points = Player2Points + (P2Cards[C1].Number % 13 + 1) + (P2Cards[C2].Number % 13 + 1) + (P2Cards[C3].Number % 13 + 1) + (P2Cards[C4].Number % 13 + 1);
                                        CaUsed2[0] = P2Cards[C1].Number;
                                        CaUsed2[1] = P2Cards[C2].Number;
                                        CaUsed2[2] = P2Cards[C3].Number;
                                        CaUsed2[3] = P2Cards[C4].Number;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //3 of a Kind
            for (int C3 = 0; C3 < 7; C3++)
            {
                for (int C2 = 0; C2 < 7; C2++)
                {
                    for (int C1 = 0; C1 < 7; C1++)
                    { //If P2Card[C1].Number 
                        if ((P2Cards[C1].Name == P2Cards[C2].Name) && (P2Cards[C2].Name == P2Cards[C3].Name) &&
                            (P2Cards[C1].Name == P2Cards[C3].Name) && (C2 != C1 && C2 != C3 && C1 != C3))
                        {
                            if ((CaUsed2[0] == P2Cards[C3].Number || CaUsed2[0] == P2Cards[C2].Number || CaUsed2[0] == P2Cards[C1].Number) ||
                               (CaUsed2[1] == P2Cards[C3].Number || CaUsed2[1] == P2Cards[C2].Number || CaUsed2[0] == P2Cards[C1].Number) ||
                               (CaUsed2[2] == P2Cards[C3].Number || CaUsed2[2] == P2Cards[C2].Number || CaUsed2[2] == P2Cards[C1].Number) ||
                               (CaUsed2[3] == P2Cards[C3].Number || CaUsed2[3] == P2Cards[C2].Number || CaUsed2[3] == P2Cards[C1].Number))
                            {
                            }
                            else
                            {
                                if ((Ca3Used2[0] == P2Cards[C3].Number || Ca3Used2[0] == P2Cards[C2].Number || Ca3Used2[0] == P2Cards[C1].Number) ||
                                    (Ca3Used2[1] == P2Cards[C3].Number || Ca3Used2[1] == P2Cards[C2].Number || Ca3Used2[0] == P2Cards[C1].Number) ||
                                    (Ca3Used2[2] == P2Cards[C3].Number || Ca3Used2[2] == P2Cards[C2].Number || Ca3Used2[2] == P2Cards[C1].Number) &&
                                    (CaUsed2[0] == 0 && CaUsed2[1] == 0 && CaUsed2[2] == 0 && CaUsed2[3] == 0) &&
                                    (Ca32Used2[0] == P2Cards[C3].Number || Ca32Used2[0] == P2Cards[C2].Number || Ca32Used2[0] == P2Cards[C1].Number) ||
                                    (Ca32Used2[1] == P2Cards[C3].Number || Ca32Used2[1] == P2Cards[C2].Number || Ca32Used2[0] == P2Cards[C1].Number) ||
                                    (Ca32Used2[2] == P2Cards[C3].Number || Ca32Used2[2] == P2Cards[C2].Number || Ca32Used2[2] == P2Cards[C1].Number))
                                {
                                }
                                else
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        Ca32Used2[i] = Ca3Used2[i];
                                    }
                                    Player2Points = Player2Points + (P2Cards[C1].Number % 13 + 1) + (P2Cards[C2].Number % 13 + 1) + (P2Cards[C3].Number % 13 + 1); //Scoring adjusted.
                                    Ca3Used2[0] = P2Cards[C1].Number;
                                    Ca3Used2[1] = P2Cards[C2].Number;
                                    Ca3Used2[2] = P2Cards[C3].Number;
                                }

                            }
                        }
                    }
                }
            }





            ///Section for declaring the winner
            ///This is the section which shows the Message box and thus ending the game, it also shows some statistics of what has happened in the game.
            ///As well as showing who won the game and their points. This can be changed at a later date if it needs to.
            if (Player1Points > Player2Points)
            {
                Winner = "Player 1 has won the game with " + Player1Points.ToString() + " points, compaired to " + Player2Points.ToString() + " for player 2. With " + NoOfMoves + " Cards taken.";
            }
            else if (Player1Points < Player2Points)
            {
                Winner = "Player 2 has won the game with " + Player2Points.ToString() + " points, compaired to " + Player1Points.ToString() + " for player 1. With " + NoOfMoves + " Cards taken.";
            }
            else
            {
                Winner = "The game was a tie with " + Player1Points.ToString() + " points each. With " + NoOfMoves + " Cards taken.";
            }
            MessageBox.Show(Winner);
            this.Hide();
            var Menu = new MMenu();
            Menu.Show();
        }
        //Neural Network 1 for the three options: Call, Take from Deck or Stack.
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
                FirstButton = 1;
                int ElementLim = RNG.Next(DeckDis.Count);
                //If the stack has 38 elements then LCardDis (Card) LCard (Int) equals to last element in stack. 
                //Stack.Remove all exept the last element and StackDis.Remove all exept the last element.
                if (StackDis.Count == 38)
                {
                    for (int i = 0; i < StackDis.Count - 1; i++)
                    {
                        StackDis.RemoveAt(0);
                    }
                    MessageBox.Show("Suffle of cards");
                }
                CheckDeck(ref StackDis, ref DeckDis, ref ElementLim);

                LimboCard = DeckDis[ElementLim];
                LimboCard.Location = new Point(400, 250);
                ComboDecision(ref NAMEHOUSE, ref LimboCard);
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
                    for (int i = 0; i < StackDis.Count; i++)
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
                FirstButton = 2;
                LimboCard = StackDis[StackDis.Count - 1];
                LimboCard.Location = new Point(400, 250);
                StackDis.Remove(LimboCard);
                DeckDis.Remove(LimboCard);
                ComboDecision(ref NAMEHOUSE, ref LimboCard);

                Bitmap bmp = new Bitmap(PicGame.Width, PicGame.Height);
                using (Graphics g = Graphics.FromImage(bmp)) //Update the grid view display
                {
                    for (int i = 0; i < 7; i++)
                    {
                        g.DrawImage(P1Cards[i].Image, P1Cards[i].Location.X, P1Cards[i].Location.Y, P1Cards[i].SizeY, P1Cards[i].SizeX);
                        g.DrawImage(Back.Image, P2Cards[i].Location.X, P2Cards[i].Location.Y, P2Cards[i].SizeY, P2Cards[i].SizeX);
                    }
                    for (int i = 0; i < DeckDis.Count; i++)
                    {
                        g.DrawImage(Back.Image, DeckDis[i].Location.X, DeckDis[i].Location.Y, DeckDis[i].SizeY, DeckDis[i].SizeX);
                    }
                    for (int i = 0; i < StackDis.Count; i++)
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
        private void CmdPcb_Click(object sender, EventArgs e)
        {
            Cards PickedDump = new Cards();
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
                        }
                    }
                    if (LimboCard.Name == Value2 && LimboCard.House == Value3)
                    {
                        PickedDump = LimboCard;
                    }

                    PkFmDk = true;
                    if (DeckVal == true)
                    {
                        DeckDis.Remove(LimboCard);
                    }
                    DeckDis.Add(PickedDump);
                    if (PickedDump == LimboCard)
                    {
                        StackDis.Add(LimboCard);
                        for (int i = 0; i < StackDis.Count; i++)
                        {
                            StackDis[i].Location = new Point(200, 130);
                        }
                    }
                    else if (PickedDump == P1Cards[0])
                    {
                        StackDis.Add(P1Cards[0]);
                        for (int i = 0; i < StackDis.Count; i++)
                        {
                            StackDis[i].Location = new Point(200, 130);
                        }
                        P1Cards[0] = LimboCard;
                        P1Cards[0].Location = new Point(30, 250);
                    }
                    else if (PickedDump == P1Cards[1])
                    {
                        StackDis.Add(P1Cards[1]);
                        for (int i = 0; i < StackDis.Count; i++)
                        {
                            StackDis[i].Location = new Point(200, 130);
                        }
                        P1Cards[1] = LimboCard;
                        P1Cards[1].Location = new Point(80, 250);
                    }
                    else if (PickedDump == P1Cards[2])
                    {
                        StackDis.Add(P1Cards[2]);
                        for (int i = 0; i < StackDis.Count; i++)
                        {
                            StackDis[i].Location = new Point(200, 130);
                        }
                        P1Cards[2] = LimboCard;
                        P1Cards[2].Location = new Point(130, 250);
                    }
                    else if (PickedDump == P1Cards[3])
                    {
                        StackDis.Add(P1Cards[3]);
                        for (int i = 0; i < StackDis.Count; i++)
                        {
                            StackDis[i].Location = new Point(200, 130);
                        }
                        P1Cards[3] = LimboCard;
                        P1Cards[3].Location = new Point(180, 250);
                    }
                    else if (PickedDump == P1Cards[4])
                    {
     
                        StackDis.Add(P1Cards[4]);
                        for (int i = 0; i < StackDis.Count; i++)
                        {
                            StackDis[i].Location = new Point(200, 130);
                        }
                        P1Cards[4] = LimboCard;
                        P1Cards[4].Location = new Point(230, 250);
                    }
                    else if (PickedDump == P1Cards[5])
                    {
                        StackDis.Add(P1Cards[5]);
                        for (int i = 0; i < StackDis.Count; i++)
                        {
                            StackDis[i].Location = new Point(200, 130);
                        }
                        P1Cards[5] = LimboCard;
                        P1Cards[5].Location = new Point(280, 250);
                    }
                    else if (PickedDump == P1Cards[6])
                    {
                        StackDis.Add(P1Cards[6]);
                        for (int i = 0; i < StackDis.Count; i++)
                        {
                            StackDis[i].Location = new Point(200, 130);
                        }
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
                        for (int i = 0; i < StackDis.Count; i++)
                        {
                            g.DrawImage(StackDis[i].Image, StackDis[i].Location.X, StackDis[i].Location.Y, StackDis[i].SizeY, StackDis[i].SizeX);

                        }
                    }
                    PicGame.Image = bmp;
                    PriorCardName = Value;
                    DeckVal = false;
                    //NN Start
                  //  DecitionP2();
                    //First Button
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
            Call();
        }
        void DecitionP2()
        {
            if ((net1.OutputLayer[0].Output > net1.OutputLayer[1].Output && net1.OutputLayer[0].Output > net1.OutputLayer[2].Output))
            {
                //Call
                Call();
            }
            else if (net1.OutputLayer[1].Output > net1.OutputLayer[0].Output && net1.OutputLayer[1].Output > net1.OutputLayer[2].Output)
            {
                //Pick from Deck
                NNTFD();
            }
            else if (net1.OutputLayer[2].Output > net1.OutputLayer[0].Output && net1.OutputLayer[2].Output > net1.OutputLayer[1].Output)
            {
                //Pick From Stack
                NNTFS();
            }
            //Next Decition and Part
        }
        private void btnTNN_Click(object sender, EventArgs e)
        {
            double High = 0.99;
            double Low = 0.01;
            //For output values.
            double Choice1 = 0.5;
            double Choice2 = 0.5;
            double Choice3 = 0.5;
            StringBuilder bld = new StringBuilder();
            int Iterations = 1;
       
            //Options Change.
            if (FirstButton == 0)
            {
                Choice1 = High;
                Choice2 = Low;
                Choice3 = Low;
            }
            else if (FirstButton == 1)
            {
                Choice1 = Low;
                Choice2 = High;
                Choice3 = Low;
            }
            else if (FirstButton == 2)
            {
                Choice1 = Low;
                Choice2 = Low;
                Choice3 = High;
            }
            
            StackDis.ToList();
            double[][] input, output;
            net1.Initialize(1,52,16,3);
            double[] PlayerHL;
            //This will make it easier to determine between them compaired to the current way of doint it.
            PlayerHL = new double[52];
            StackDis.ToArray();
            for (int i = 0; i < 52; i++)
            {
                PlayerHL[i] = Low;
            }  //Defults the Player High/Low to Low, this will then change if the card is being used.

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 52; j++)
                {
                    if (P1Cards[i].Number == j)
                    {
                        PlayerHL[j] = High;
                    }
                    else if ( LimboCard.Number == j)
                    {
                        PlayerHL[j] = High;
                    }
                }
                
            }
            StackDis.ToList();
            //Inputs
            input = new double[1][]; //52 inputs, the cards will then have either a poitivve 1 if they are active or a o if they are not.
            input[0] = new double[] { PlayerHL[0], PlayerHL[1], PlayerHL[2], PlayerHL[3], PlayerHL[4], PlayerHL[5], PlayerHL[6], PlayerHL[7], PlayerHL[8], PlayerHL[9], PlayerHL[10], PlayerHL[11], PlayerHL[12],
                                      PlayerHL[13], PlayerHL[14], PlayerHL[15], PlayerHL[16], PlayerHL[17], PlayerHL[18], PlayerHL[19], PlayerHL[20], PlayerHL[21], PlayerHL[22], PlayerHL[23], PlayerHL[24], PlayerHL[25],
                                      PlayerHL[26], PlayerHL[27], PlayerHL[28], PlayerHL[29], PlayerHL[30], PlayerHL[31], PlayerHL[32], PlayerHL[33], PlayerHL[34], PlayerHL[35], PlayerHL[36], PlayerHL[37], PlayerHL[38],
                                      PlayerHL[39], PlayerHL[40], PlayerHL[41], PlayerHL[42], PlayerHL[43], PlayerHL[44], PlayerHL[45], PlayerHL[46], PlayerHL[47], PlayerHL[48], PlayerHL[49], PlayerHL[50], PlayerHL[51]};
            StackDis.ToList();
            //Outputs
            output = new double[1][];
            output[0] = new double[] {Choice1, Choice2, Choice3}; //Choice 1,2,3

            //Initialize with
            //52 input neurons
            //16 hidden neurons
            //3 output neurons
            net1.LearningRate = 3;


            net1.Train(input, output, TrainingType.BackPropogation, Iterations);
            net1.ApplyLearning();
                for (int i = 0; i < 52; i++)
                {
                    net1.InputLayer[i].Output = PlayerHL[i];
                }

                net1.Pulse();

                Choice1 = net1.OutputLayer[0].Output; //Choice 1

                //for (int i = 0; i < 52; i++)
                //{
                //    net1.InputLayer[i].Output = PlayerHL[i];
                //}

                //net1.Pulse();

                //Choice2 = net1.OutputLayer[0].Output; //Choice 2

                //for (int i = 0; i < 52; i++)
                //{
                //    net1.InputLayer[i].Output = PlayerHL[i];
                //}

                //net1.Pulse();

                //Choice3 = net1.OutputLayer[0].Output; //Choice 3

            foreach (Neuron on in net1.OutputLayer)    

                AppendNeuronInfo(bld, on);

        }
        private static void AppendNeuronInfo(StringBuilder bld, INeuron neuron)
        {
            #region Declarations

            int i;
            double value;

            #endregion

            #region Initialization

            i = 1;
            value = 0;

            #endregion

            #region Execution
            using (StreamWriter CurrentFile = new StreamWriter("Net1.txt"))
            {
                CurrentFile.WriteLine(bld.Append("Neuron" + Environment.NewLine));
                CurrentFile.WriteLine(bld.Append(neuron.Output.ToString() + Environment.NewLine)); //Output
                CurrentFile.WriteLine(bld.Append(neuron.Error.ToString() + Environment.NewLine)); //Error
                CurrentFile.WriteLine(bld.Append(neuron.LastError.ToString() + Environment.NewLine)); //Last Error
                CurrentFile.WriteLine(bld.Append(neuron.Bias.Weight.ToString() + Environment.NewLine)); //Bias
                foreach (KeyValuePair<INeuronSignal, NeuralFactor> f in neuron.Input)
                {
                    CurrentFile.WriteLine(bld.Append("input ").Append(i++ + Environment.NewLine));
                    CurrentFile.WriteLine(bld .Append("value = ").Append(f.Key.Output + Environment.NewLine)); //Value
                    CurrentFile.WriteLine(bld.Append("weight = ").Append(f.Value.Weight + Environment.NewLine)); //Weight
                    
                    value += f.Value.Weight * f.Key.Output;
                }
                //for (int j = 0; j < bld.Append(neuron.Input.Count).Length; j++)
                //{
                //    CurrentFile.WriteLine("Hi"+ Environment.NewLine);

                //}
                CurrentFile.WriteLine(bld.Append(neuron.Bias.Weight + Environment.NewLine)); //Parent Bias
                CurrentFile.WriteLine(bld.Append(Neuron.Sigmoid(value + neuron.Bias.Weight) + Environment.NewLine)); //Sigmoid Function

            }


            #endregion


        }
    }
}


