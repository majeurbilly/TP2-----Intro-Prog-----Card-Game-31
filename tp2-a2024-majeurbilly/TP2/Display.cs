namespace TP2
{
    class Display
    {
        public const int CARD_WIDTH = 30;
        public const int CARD_HEIGHT = 14;
        public static readonly string[] BACKGROUND_LOGO = {
      "                         ",
      "                         ",
      "                         ",
      "                         ",
      "                         ",
      "                         ",
      "                         ",
      "                         ",
      "                         ",
      "                         ",
      "                         ",
      "                         "
    };

        public static void DrawArrayOfStrings(string[] logo, int posX, int posY, ConsoleColor color)
        {
            for (int i = 0; i < logo.Length; i++)
            {
                WriteString(logo[i], posX, posY + i, color);
            }
        }
        public static void DrawCard(int value, int suit, int posX, int posY)
        {
            string[] border ={
      "*****************************",
      "*                           *",
      "*                           *",
      "*                           *",
      "*                           *",
      "*                           *",
      "*                           *",
      "*                           *",
      "*                           *",
      "*                           *",
      "*                           *",
      "*                           *",
      "*                           *",
      "*****************************",
      };

            ConsoleColor color = ConsoleColor.White;
            string[] logo = BACKGROUND_LOGO;
            
            DrawArrayOfStrings(border, posX, posY, ConsoleColor.Black);

            Console.BackgroundColor = color;
            DrawArrayOfStrings(logo, posX + 2, posY + 1, color);

            // haut gauche
            DrawSuit(posX + 2, posY + 2, suit);

            // Bas droite
            DrawCardValue(posX + 22, posY + 8, value, suit);

            Console.BackgroundColor = ConsoleColor.White;
        }
        public static void DrawDiamond(int centerPosX, int centerPosY)
        {
            WriteString("  X  ", centerPosX, centerPosY - 1, ConsoleColor.Red);
            WriteString(" XXX ", centerPosX, centerPosY, ConsoleColor.Red);
            WriteString(" XXX ", centerPosX, centerPosY + 1, ConsoleColor.Red);
            WriteString("  X  ", centerPosX, centerPosY + 2, ConsoleColor.Red);
        }

        public static void DrawHeart(int centerPosX, int centerPosY)
        {
            WriteString("XX XX", centerPosX, centerPosY - 1, ConsoleColor.Red);
            WriteString("XXXXX", centerPosX, centerPosY, ConsoleColor.Red);
            WriteString(" XXX ", centerPosX, centerPosY + 1, ConsoleColor.Red);
            WriteString("  X  ", centerPosX, centerPosY + 2, ConsoleColor.Red);
        }

        public static void DrawClub(int centerPosX, int centerPosY)
        {
            WriteString("  X  ", centerPosX, centerPosY - 1, ConsoleColor.Black);
            WriteString("X X X", centerPosX, centerPosY, ConsoleColor.Black);
            WriteString(" XXX ", centerPosX, centerPosY + 1, ConsoleColor.Black);
            WriteString("  X  ", centerPosX, centerPosY + 2, ConsoleColor.Black);
        }

        public static void DrawSpade(int centerPosX, int centerPosY)
        {
            WriteString("  X  ", centerPosX, centerPosY - 1, ConsoleColor.Black);
            WriteString(" XXX ", centerPosX, centerPosY, ConsoleColor.Black);
            WriteString("XXXXX", centerPosX, centerPosY + 1, ConsoleColor.Black);
            WriteString("  X  ", centerPosX, centerPosY + 2, ConsoleColor.Black);
        }

        public static void DrawSuit(int centerPosX, int centerPosY, int suit)
        {
            switch (suit)
            {
                case Game.HEART:
                    DrawHeart(centerPosX, centerPosY); 
                    break;
                case Game.DIAMOND:
                    DrawDiamond(centerPosX, centerPosY);
                    break;
                case Game.SPADE:
                    DrawSpade(centerPosX, centerPosY);
                    break;
                case Game.CLUB:
                    DrawClub(centerPosX, centerPosY);
                    break;
            }
        }

        public static void DrawCardValue(int posX, int posY, int value, int suit)
        {
            ConsoleColor color = suit > Game.DIAMOND ? ConsoleColor.Black : ConsoleColor.Red;

            switch (value)
            {
                case Game.ACE:
                    WriteString("XXXXX", posX, posY, color);
                    WriteString("X   X", posX, posY + 1, color);
                    WriteString("XXXXX", posX, posY + 2, color);
                    WriteString("X   X", posX, posY + 3, color);
                    WriteString("X   X", posX, posY + 4, color);
                    break;
                case Game.TWO:
                    WriteString(" XXX ", posX, posY, color);
                    WriteString("X  XX", posX, posY + 1, color);
                    WriteString("  XX ", posX, posY + 2, color);
                    WriteString(" XX ", posX, posY + 3, color);
                    WriteString("XXXXX", posX, posY + 4, color);
                    break;
                case Game.THREE:
                    WriteString(" XXX ", posX, posY, color);
                    WriteString("X  XX", posX, posY + 1, color);
                    WriteString("  XX ", posX, posY + 2, color);
                    WriteString("X  XX", posX, posY + 3, color);
                    WriteString(" XXX", posX, posY + 4, color);
                    break;
                case Game.FOUR:
                    WriteString("XX XX", posX, posY, color);
                    WriteString("XX XX", posX, posY + 1, color);
                    WriteString("XXXXX", posX, posY + 2, color);
                    WriteString("   XX", posX, posY + 3, color);
                    WriteString("   XX", posX, posY + 4, color);
                    break;
                case Game.FIVE:
                    WriteString("XXXXX", posX, posY, color);
                    WriteString("XX   ", posX, posY + 1, color);
                    WriteString("XXXX ", posX, posY + 2, color);
                    WriteString("  XXX", posX, posY + 3, color);
                    WriteString("XXXX ", posX, posY + 4, color);
                    break;
                case Game.SIX:
                    WriteString(" X   ", posX, posY, color);
                    WriteString("X    ", posX, posY + 1, color);
                    WriteString("XXXX ", posX, posY + 2, color);
                    WriteString("X   X", posX, posY + 3, color);
                    WriteString(" XXX ", posX, posY + 4, color);
                    break;
                case Game.SEVEN:
                    WriteString("XXXXX", posX, posY, color);
                    WriteString("   XX", posX, posY + 1, color);
                    WriteString("  XX ", posX, posY + 2, color);
                    WriteString(" XX  ", posX, posY + 3, color);
                    WriteString("XX   ", posX, posY + 4, color);
                    break;
                case Game.EIGHT:
                    WriteString(" XXX ", posX, posY, color);
                    WriteString("X   X", posX, posY + 1, color);
                    WriteString(" XXX ", posX, posY + 2, color);
                    WriteString("X   X", posX, posY + 3, color);
                    WriteString(" XXX ", posX, posY + 4, color);
                    break;
                case Game.NINE:
                    WriteString(" XXX ", posX, posY, color);
                    WriteString("X   X", posX, posY + 1, color);
                    WriteString("XXXXX", posX, posY + 2, color);
                    WriteString("   XX", posX, posY + 3, color);
                    WriteString(" XX  ", posX, posY + 4, color);
                    break;
                case Game.TEN:
                    WriteString("X XXX", posX, posY, color);
                    WriteString("X X X", posX, posY + 1, color);
                    WriteString("X X X", posX, posY + 2, color);
                    WriteString("X X X", posX, posY + 3, color);
                    WriteString("X XXX", posX, posY + 4, color);
                    break;
                case Game.JACK:
                    WriteString("   XX", posX, posY, color);
                    WriteString("   XX", posX, posY + 1, color);
                    WriteString("   XX", posX, posY + 2, color);
                    WriteString("XX XX", posX, posY + 3, color);
                    WriteString("XXXXX", posX, posY + 4, color);
                    break;
                case Game.QUEEN:
                    WriteString(" XXX ", posX, posY, color);
                    WriteString("X   X", posX, posY + 1, color);
                    WriteString("X   X", posX, posY + 2, color);
                    WriteString(" XXX ", posX, posY + 3, color);
                    WriteString("   X ", posX, posY + 4, color);
                    break;
                case Game.KING:
                    WriteString("XX XX", posX, posY, color);
                    WriteString("XXX  ", posX, posY + 1, color);
                    WriteString("XXX  ", posX, posY + 2, color);
                    WriteString("XX X ", posX, posY + 3, color);
                    WriteString("XX  X", posX, posY + 4, color);
                    break;
            }
        }


        public static void WriteString(string message, int posX, int posY, ConsoleColor color)
        {
            Console.SetCursorPosition(posX, posY);
            Console.ForegroundColor = color;
            Console.Write(message);
        }
        public static void Clear()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.CursorVisible = false;
        }
        public static void ShowCards(int[] cardValues)
        {
            Clear();
            for (int i = 0; i < cardValues.Length; i++)
            {
                DrawCard(Game.GetValueFromCardIndex(cardValues[i]), 
                         Game.GetSuitFromCardIndex(cardValues[i]), i * CARD_WIDTH, 0);
            }
        }

        public static void ShowSelectedMarks(bool[] selectedCards)
        {
            for (int i = 0; i < selectedCards.Length; i++)
            {
                string text = "[ ]";
                if (selectedCards[i])
                    text = "[X]";
                WriteString(text, (CARD_WIDTH - text.Length) / 2 + i * CARD_WIDTH, CARD_HEIGHT + 2, ConsoleColor.Black);
            }
        }
        public static bool IsKeyAvailable()
        {
            return Console.KeyAvailable;
        }
        public static void HighLightText(String message, int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public static void SelectCards(bool[] selectedCards)
        {
            ShowSelectedMarks(selectedCards);
            int current = 0;
            String symbol = " ";
            if (selectedCards[current])
                symbol = "X";
            HighLightText(symbol, (Display.CARD_WIDTH - symbol.Length) / 2 + current * Display.CARD_WIDTH, Display.CARD_HEIGHT + 2);

            while (true)
            {
                if (IsKeyAvailable())
                {
                    ConsoleKey currentKey = Console.ReadKey().Key;
                    if (currentKey == ConsoleKey.Enter)
                        break;
                    if (currentKey == ConsoleKey.Tab)
                    {
                        current = (current + 1) % selectedCards.Length;
                    }
                    if (currentKey == ConsoleKey.Spacebar)
                        selectedCards[current] = !selectedCards[current];

                    ShowSelectedMarks(selectedCards);
                    symbol = " ";
                    if (selectedCards[current])
                        symbol = "X";
                    HighLightText(symbol, (CARD_WIDTH - symbol.Length) / 2 + current * CARD_WIDTH, CARD_HEIGHT + 2);
                }
            }
        }
        public static void ShowInstructions()
        {
            WriteString("Appuyez sur espace pour sélectionner/désélectionner la carte.", 0, CARD_HEIGHT + 10, ConsoleColor.Black);
            WriteString("Appuyez sur tab pour passer à la carte suivante.", 0, CARD_HEIGHT + 11, ConsoleColor.Black);
            WriteString("Appuyez sur enter pour relancer les cartes non sélectionnées.", 0, CARD_HEIGHT + 12, ConsoleColor.Black);
        }

        public static void ShowRemainingDraws(int remainingDraws)
        {
            WriteString($"Il vous reste {remainingDraws} relance{AddPlural(remainingDraws)}", 0, CARD_HEIGHT + 13, ConsoleColor.Black);
        }

        public static string AddPlural(int quantity)
        {
            return quantity > 1 ? "s" : "";
        }

    }
}







