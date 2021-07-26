using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace YahtzeeGame
{
    public class GameDisplay
    {
        public static RenderWindow window;

        // Creates ScoreLinkedList and Dice objects
        public static ScoreLinkedList ScoreCard;
        Dice newRound;
        
        // Lists to hold scores to be displayed as text in the window
        static List<string> displayCategoryScores = new List<string>();
        static List<string> displayTotalScores = new List<string>();
        
        // Arrays to keep track of button types, score types, and various dice related arrays
        public const int maxButtons = 22;
        public const int maxVariables = 5;
        public const int maxScoreTypes = 17;
        int buttonTypesIndex;
        int scoreTypesIndex;
        string[,] buttonTypes = new string[maxButtons, maxVariables];
        string[,] scoreTypes = new string[maxScoreTypes, maxVariables];
        string[] diceText = new string[Dice.maxDice];
        int[] currentRound = new int[Dice.maxDice];
        public static int[] diceToKeep = new int[Dice.maxDice];


        // Menu container dimension and position variables
        int menuBoxWidth = 100;
        int menuBoxHeight = 20;
        int menuBoxPositionX = 20;
        int menuBoxPositionY = 20;
        int menuBoxIncrementX = 120;

        // Category container dimension and position variables
        int categoryBoxWidth;
        int categoryBoxHeight;
        int categoryBoxPositionX;
        int categoryBoxPositionY;
        int categoryBoxResetPosX;
        int categoryBoxResetPosY;
        int categoryBoxIncrementX;
        int categoryBoxIncrementY;

        // Text values
        public static Font font = new Font("C:/Windows/Fonts/arial.ttf");
        public static uint menuBoxTextCharacterSize;
        public static uint categoryBoxTextCharacterSize;

        // Menu text position variables
        int menuBoxTextPositionX;
        int menuBoxTextPositionY;

        // Category text position variables
        int categoryBoxTextPositionX;
        int categoryBoxTextPositionY;
        int categoryBoxTextResetPosX;
        int categoryBoxTextResetPosY;

        // Dice text position variables
        int diceTextPositionX;
        int diceTextPositionY;
        int diceTextPositionIncrementX;

        // Roll Bar text position variables
        int rollBarTextPositionX;
        int rollBarTextPositionY;

        // Display text strings
        string[] menuItemsText = { "New Game", "How To Play", "Exit" };
        string[] upperSectionText = { "1's", "2's", "3's", "4's", "5's", "6's" };
        string[] scoreTotalsText = { "Upper\nSection\nBonus", "Upper\nSection\nScore", "Lower\nSection\nTotal", "Grand\nTotal" };
        string[] lowerSectionText = { "3 of\na Kind", "4 of\na Kind", "Full\nHouse", "Small\nStraight", "Large\nStraight",
            "Yahtzee", "Chance" };

        // Variables for pop up message windows.
        string messageText;
        string messageType;
        MessageDisplay message;
        bool messageOpen = false;
        Vector2f messagePosition = new Vector2f(15, 200);
        Vector2f messageSize = new Vector2f(350, 250);
        Color colour;

        /// <summary>
        /// Constructor method
        /// </summary>
        public GameDisplay()
        {
            VideoMode mode = new VideoMode(380, 670);
            window = new RenderWindow(mode, "Yahtzee");

            window.Closed += Window_Closed;
            window.KeyPressed += Window_KeyPressed;
            window.MouseButtonPressed += Window_MouseButtonPressed;

            ScoreCard = new ScoreLinkedList();
            newRound = new Dice();
        }
        /// <summary>
        /// Run method which holds the game logic
        /// </summary>
        public void Run()
        {
            ScoreCategoryBinaryTree.PopulateNodes();
            while (window.IsOpen)
            {
                if (ScoreCard.numberOfRounds >= ScoreLinkedList.maxRounds)
                {
                    messageType = "Finished";
                    message = new MessageDisplay();
                    colour = Color.Green;
                    messageText = message.GetMessage(messageType);
                    messageOpen = true;

                }
                Update();
                Draw();
            }
        }

        /// <summary>
        /// Updates the score values to their appropriate lists, unless the message box is open.
        /// </summary>
        public void Update()
        {
            window.DispatchEvents();
            if (messageOpen)
            {
            }
            else {
                displayCategoryScores.Clear();
                displayTotalScores.Clear();

                for (int i = 0; i < ScoreLinkedList.maxRounds; i++)
                {
                    // Searches current entries in the Score Card to add their values to the displayCategoryScores list.
                    if (ScoreCard.ContainsNode(ScoreCategoryBinaryTree.scoringCategories[i]))
                    {
                        displayCategoryScores.Add(Convert.ToString(ScoreCard.RetrieveScore(ScoreCategoryBinaryTree.scoringCategories[i])));
                    }
                    else
                    {
                        displayCategoryScores.Add("");
                    }
                }

                // Checks for the Upper Section Bonus
                if (ScoreCard.hasUpperSectionBonus == true)
                {
                    displayTotalScores.Add(Convert.ToString(Scoring.upperSectionBonus));
                }
                else
                {
                    displayTotalScores.Add("");
                }
                // Adds the Score Card totals to the displayTotalScores list
                displayTotalScores.Add(Convert.ToString(ScoreCard.upperSectionScore));
                displayTotalScores.Add(Convert.ToString(ScoreCard.lowerSectionScore));
                displayTotalScores.Add(Convert.ToString(ScoreCard.totalScore));

                // Checks the current round of dice rolled to add to the diceText array to be printed inside the dice containers
                for (int i = 0; i < Dice.maxDice; i++)
                {
                    if (currentRound[i] > 0)
                    {
                        diceText[i] = Convert.ToString(currentRound[i]);
                    }
                    else
                    {
                        diceText[i] = "";
                    }
                }
            }
            VariableReset();
        }
        /// <summary>
        /// Clears the screen and draws containers and text.
        /// </summary>
        public void Draw()
        {
            window.Clear(Color.Magenta);
 
            DrawMenu();
            DrawHeader();
            DrawUpperSectionCategories();
            DrawUpperSectionScores();
            DrawTotalScoreCategories();
            DrawTotalScores();
            DrawLowerSectionCategories();
            DrawLowerSectionScores();
            DrawDice();
            DrawRollBar();
           
            // if the message box container is open, draw the below message
            if (messageOpen)
            {
                message = new MessageDisplay(messagePosition, messageSize, messageText, messageType, colour);
                message.Draw(window, RenderStates.Default);
            }
            window.Display();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////EVENT HANDLER METHODS/////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Event handler for the window.Closed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Window_Closed(object sender, EventArgs e)
        {

                Window window = (Window)sender;
                window.Close();
        }

        /// <summary>
        ///  Event handler for keyboard presses.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
            {
                if (messageOpen)
                {
                    messageOpen = false;
                }
                else
                {
                    Window_Closed(sender, e);
                }
            }
            if (e.Code == Keyboard.Key.Space)
            {
                DisplayRoll();                
            }
        }

        /// <summary>
        /// Event Handler for mouse click events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            int button = Intersects(e);
            
            switch (button)
            {
                case -1: // Mouse clicked in an unclickable area
                    break;
                case 0: // New Game
                    Menu_NewGame_Click(sender, e);
                    break;
                case 1: // How To Play
                    Menu_HowToPlay_Click(sender, e);
                    break;
                case 2: // Exit
                    Window_Closed(sender, e);
                    break;
                case 16: // Dice 1
                    diceToKeep = newRound.DiceToKeep(currentRound, diceToKeep, 0);
                    break;
                case 17: // Dice 2
                    diceToKeep = newRound.DiceToKeep(currentRound, diceToKeep, 1);
                    break;
                case 18: // Dice 3
                    diceToKeep = newRound.DiceToKeep(currentRound, diceToKeep, 2);
                    break;
                case 19: // Dice 4
                    diceToKeep = newRound.DiceToKeep(currentRound, diceToKeep, 3);
                    break;
                case 20: // Dice 5
                    diceToKeep = newRound.DiceToKeep(currentRound, diceToKeep, 4);
                    break;
                case 21: // Roll Bar
                    DisplayRoll();
                    break;
                case 22: /// closes the messageOpen box, exits game if the game is over and the player does not wish to play a
                    /// new game
                    if (messageType == "Finished")
                    {
                        Window_Closed(sender, e);
                    }
                    else
                    {
                        messageOpen = false;
                    }
                    break;
                case 23: // starts a new game
                    Menu_NewGame_Click(sender, e);
                    messageOpen = false;
                    break;
                default:
                    if (newRound.numberRolls == 0 && ScoreCard.numberOfRounds > 0)
                    { 
                        messageType = "Roll Dice";
                        message = new MessageDisplay();
                        colour = Color.Red;
                        messageText = message.GetMessage(messageType);
                        messageOpen = true;
                    }
                    else
                    {
                        if (!ScoreCard.AddNode(newRound.DiceTotals(currentRound), (ScoreCategoryBinaryTree.ScoringCategories)button - menuItemsText.Length))
                        {
                            messageType = "Choose Another Category";
                            message = new MessageDisplay();
                            colour = Color.Red;
                            messageText = message.GetMessage(messageType);
                            messageOpen = true;
                        }
                        else
                        {
                            newRound.numberRolls = 0;
                            newRound.ClearArray(diceToKeep);
                        }
                    }
                    break;
            }
        }
        /// <summary>
        /// Displays the How To Play instructions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_HowToPlay_Click(object sender, MouseButtonEventArgs e)
        {
            messageType = "How To Play";
            message = new MessageDisplay();
            colour = Color.Green;
            messageText = message.GetMessage(messageType);
            messageOpen = true;

        }

        /// <summary>
        /// Starts a new game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_NewGame_Click(object sender, MouseButtonEventArgs e)
        {
            ScoreCard.EmptyList();
            newRound.numberRolls = 0;
            newRound.ClearArray(currentRound);

        }

        /// <summary>
        /// Conducts (or attempts to conduct) a new roll of the dice to display in the GameDisplay.
        /// </summary>
        private void DisplayRoll()
        {
            if (newRound.numberRolls < Dice.maxRolls)
            {
                currentRound = newRound.Round();
            }
            else
            {
                messageType = "Maxed Rolls";
                message = new MessageDisplay();
                messageText = message.GetMessage(messageType);
                colour = Color.Red;
                messageOpen = true;
            }
        }
        /// <summary>
        /// Finds the button that has been clicked in the mouse event.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public int Intersects(MouseButtonEventArgs e)
        {
            int intersectsWith = -1; // default casemof no intersection
            float mouseX = e.X;
            float mouseY = e.Y;

            if (messageOpen)
            {
                if (mouseX > Convert.ToInt32(MessageDisplay.exitButtonPosition.X) && mouseX < (Convert.ToInt32(MessageDisplay.exitButtonPosition.X) + Convert.ToInt32(MessageDisplay.buttonSize.X)))
                {
                    if (mouseY > Convert.ToInt32(MessageDisplay.exitButtonPosition.Y) && mouseY < (Convert.ToInt32(MessageDisplay.exitButtonPosition.Y) + Convert.ToInt32(MessageDisplay.buttonSize.Y)))
                    {
                        intersectsWith = 22;
                    }
                }
                else if (mouseX > Convert.ToInt32(MessageDisplay.newGameButtonPosition.X) && mouseX < (Convert.ToInt32(MessageDisplay.newGameButtonPosition.X) + Convert.ToInt32(MessageDisplay.buttonSize.X)))
                {
                    if (mouseY > Convert.ToInt32(MessageDisplay.newGameButtonPosition.Y) && mouseY < (Convert.ToInt32(MessageDisplay.newGameButtonPosition.Y) + Convert.ToInt32(MessageDisplay.buttonSize.Y)))
                    {
                        intersectsWith = 23;
                    }
                }
            }
            else
            {
                for (int i = 0; i < buttonTypes.Length / 5; i++)
                {
                    if (mouseX > Convert.ToInt32(buttonTypes[i, 1]) && mouseX < (Convert.ToInt32(buttonTypes[i, 1]) + Convert.ToInt32(buttonTypes[i, 3])))
                    {
                        if (mouseY > Convert.ToInt32(buttonTypes[i, 2]) && mouseY < (Convert.ToInt32(buttonTypes[i, 2]) + Convert.ToInt32(buttonTypes[i, 4])))
                        {
                            intersectsWith = i;
                        }
                    }
                }
            }
            return intersectsWith;
        }

        
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////GAME DISPLAY DRAW METHODS///////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       
        /// <summary>
        /// Draws the menu in the game window.
        /// </summary>
        public void DrawMenu()
        {
            for (int i = 0; i < 3; i++)
            {
                // Draws the Menu description containers
                Vector2f menuBoxSize = new Vector2f(menuBoxWidth, menuBoxHeight);
                Vector2f menuBoxPosition = new Vector2f(menuBoxPositionX, menuBoxPositionY);

                RectangleShape menuBox = new RectangleShape(menuBoxSize);
                menuBox.FillColor = Color.Cyan;
                menuBox.OutlineThickness = 2;
                menuBox.OutlineColor = Color.Black;
                menuBox.Position = menuBoxPosition;
                window.Draw(menuBox);
                menuBoxPositionX += menuBoxIncrementX;

                // Draws the Menu text to go inside the Menu description containers
                Vector2f menuTextPosition = new Vector2f(menuBoxTextPositionX, menuBoxTextPositionY);
                Text menuText = new Text(menuItemsText[i], font);
                menuText.CharacterSize = menuBoxTextCharacterSize;
                menuText.FillColor = Color.Blue;
                menuText.Position = menuTextPosition;
                window.Draw(menuText);
                menuBoxTextPositionX += menuBoxIncrementX;

                // Adds the Menu description containers to the buttonTypes array
                buttonTypes[buttonTypesIndex, 0] = Convert.ToString(menuText);
                buttonTypes[buttonTypesIndex, 1] = Convert.ToString(menuBoxPosition.X);
                buttonTypes[buttonTypesIndex, 2] = Convert.ToString(menuBoxPosition.Y);
                buttonTypes[buttonTypesIndex, 3] = Convert.ToString(menuBoxSize.X);
                buttonTypes[buttonTypesIndex, 4] = Convert.ToString(menuBoxSize.Y);
                buttonTypesIndex++;
            }
        }

        /// <summary>
        /// Draws the Yahtzee header in the game window.
        /// </summary>
        public void DrawHeader()
        {
            Vector2f headerPosition = new Vector2f(75, 45);
            Text textHeader = new Text("YAHTZEE", font);
            textHeader.CharacterSize = 50;
            textHeader.FillColor = Color.Blue;
            textHeader.Style = Text.Styles.Bold;
            textHeader.Position = headerPosition;
            window.Draw(textHeader);
        }

        /// <summary>
        /// Draws the Upper Section category containers and text in the game window.
        /// </summary>
    public void DrawUpperSectionCategories()
        {
            for (int i = 0; i < 6; i++)
            {
                // Draws the Upper Section category description containers
                Vector2f categoryBoxSize = new Vector2f(categoryBoxWidth, categoryBoxHeight);
                Vector2f categoryBoxPosition = new Vector2f(categoryBoxPositionX, categoryBoxPositionY);

                RectangleShape categoryBox = new RectangleShape(categoryBoxSize);
                categoryBox.FillColor = Color.Cyan;
                categoryBox.OutlineThickness = 2;
                categoryBox.OutlineColor = Color.Black;
                categoryBox.Position = categoryBoxPosition;
                window.Draw(categoryBox);
                categoryBoxPositionY += categoryBoxIncrementY;

                // Draws the Upper Section category descriptions inside the containers
                Vector2f categoryTextPosition = new Vector2f(categoryBoxTextPositionX, categoryBoxTextPositionY);
                Text categoryText = new Text(upperSectionText[i], font);
                categoryText.CharacterSize = categoryBoxTextCharacterSize;
                categoryText.FillColor = Color.Blue;
                categoryText.Position = categoryTextPosition;
                window.Draw(categoryText);
                categoryBoxTextPositionY += categoryBoxIncrementY;

                // Adds the Upper Section Category description containers to the buttonTypes array
                buttonTypes[buttonTypesIndex, 0] = Convert.ToString(categoryText);
                buttonTypes[buttonTypesIndex, 1] = Convert.ToString(categoryBoxPosition.X);
                buttonTypes[buttonTypesIndex, 2] = Convert.ToString(categoryBoxPosition.Y);
                buttonTypes[buttonTypesIndex, 3] = Convert.ToString(categoryBoxSize.X);
                buttonTypes[buttonTypesIndex, 4] = Convert.ToString(categoryBoxSize.Y);
                buttonTypesIndex++;
            }
        }
        /// <summary>
        /// Draws the Upper Section Scores in the game window.
        /// </summary>
    public void DrawUpperSectionScores()
        {
            // Sets new column & row positions
            categoryBoxPositionX += categoryBoxIncrementX;
            categoryBoxPositionY = categoryBoxResetPosY;

            categoryBoxTextPositionX += categoryBoxIncrementX;
            categoryBoxTextPositionY = categoryBoxTextResetPosY;

            for (int i = 0; i < 6; i++)
            {
                // Draws the Upper Section score containers
                Vector2f categoryBoxSize = new Vector2f(categoryBoxWidth, categoryBoxHeight);
                Vector2f categoryBoxPosition = new Vector2f(categoryBoxPositionX, categoryBoxPositionY);

                RectangleShape categoryBox = new RectangleShape(categoryBoxSize);
                categoryBox.FillColor = Color.Cyan;
                categoryBox.OutlineThickness = 2;
                categoryBox.OutlineColor = Color.Black;
                categoryBox.Position = categoryBoxPosition;
                window.Draw(categoryBox);
                categoryBoxPositionY += categoryBoxIncrementY;

                // Draws the Upper Section scores inside the containers
                Vector2f scoreTextPosition = new Vector2f(categoryBoxTextPositionX, categoryBoxTextPositionY);
                Text categoryText = new Text(displayCategoryScores[i], font);
                categoryText.CharacterSize = categoryBoxTextCharacterSize;
                categoryText.FillColor = Color.Blue;
                categoryText.Position = scoreTextPosition;
                window.Draw(categoryText);
                categoryBoxTextPositionY += categoryBoxIncrementY;

                // Adds the Upper Section scores to the scoreTypes array
                scoreTypes[scoreTypesIndex, 0] = Convert.ToString(categoryText);
                scoreTypes[scoreTypesIndex, 1] = Convert.ToString(scoreTextPosition.X);
                scoreTypes[scoreTypesIndex, 2] = Convert.ToString(scoreTextPosition.Y);
                scoreTypes[scoreTypesIndex, 3] = Convert.ToString(categoryBoxSize.X);
                scoreTypes[scoreTypesIndex, 4] = Convert.ToString(categoryBoxSize.Y);
                scoreTypesIndex++;
            }
        }

        /// <summary>
        /// Draws the Score Totals containers and descriptions in the central column in the game window.
        /// </summary>
        public void DrawTotalScoreCategories()
        {
            // Sets new column & row positions
            categoryBoxPositionX += categoryBoxIncrementX + 20;
            categoryBoxPositionY = categoryBoxResetPosY;
            categoryBoxTextPositionX += categoryBoxIncrementX + 20;
            categoryBoxTextPositionY = categoryBoxTextResetPosY;

            for (int i = 0; i < 4; i++)
            {
                // Draws the Score Totals description containers
                Vector2f categoryBoxSize = new Vector2f(categoryBoxWidth, categoryBoxHeight);
                Vector2f categoryBoxPosition = new Vector2f(categoryBoxPositionX, categoryBoxPositionY);

                RectangleShape categoryBox = new RectangleShape(categoryBoxSize);
                categoryBox.FillColor = Color.Cyan;
                categoryBox.OutlineThickness = 2;
                categoryBox.OutlineColor = Color.Black;
                categoryBox.Position = categoryBoxPosition;
                window.Draw(categoryBox);
                categoryBoxPositionY += categoryBoxIncrementY;

                // Draws the Score Totals description text inside the containers
                Vector2f categoryTextPosition = new Vector2f(categoryBoxTextPositionX, categoryBoxTextPositionY);
                Text categoryText = new Text(scoreTotalsText[i], font);
                categoryText.CharacterSize = categoryBoxTextCharacterSize;
                categoryText.FillColor = Color.Blue;
                categoryText.Position = categoryTextPosition;
                window.Draw(categoryText);
                categoryBoxTextPositionY += categoryBoxIncrementY;
            }
        }

        /// <summary>
        /// Draws the Totals scores in the central column in the game window
        /// </summary>
        public void DrawTotalScores()
        {
            // Sets new column & row positions
            categoryBoxPositionX += categoryBoxIncrementX;
            categoryBoxPositionY = categoryBoxResetPosY;

            categoryBoxTextPositionX += categoryBoxIncrementX;
            categoryBoxTextPositionY = categoryBoxTextResetPosY;

            for (int i = 0; i < 4; i++)
            {
                // Draws the Total Score containers
                Vector2f categoryBoxSize = new Vector2f(categoryBoxWidth, categoryBoxHeight);
                Vector2f categoryBoxPosition = new Vector2f(categoryBoxPositionX, categoryBoxPositionY);

                RectangleShape categoryBox = new RectangleShape(categoryBoxSize);
                categoryBox.FillColor = Color.Cyan;
                categoryBox.OutlineThickness = 2;
                categoryBox.OutlineColor = Color.Black;
                categoryBox.Position = categoryBoxPosition;
                window.Draw(categoryBox);
                categoryBoxPositionY += categoryBoxIncrementY;

                // Draws the Total Score text inside the containers
                Vector2f scoreTextPosition = new Vector2f(categoryBoxTextPositionX, categoryBoxTextPositionY);
                Text categoryText = new Text(displayTotalScores[i], font);
                categoryText.CharacterSize = categoryBoxTextCharacterSize;
                categoryText.FillColor = Color.Blue;
                categoryText.Position = scoreTextPosition;
                window.Draw(categoryText);
                categoryBoxTextPositionY += categoryBoxIncrementY;
            }
        }

        /// <summary>
        /// Draws the Lower Section category containers and their text inside the game window.
        /// </summary>
        public void DrawLowerSectionCategories()
        {
            // Sets the new column & row positions
            categoryBoxPositionX += categoryBoxIncrementX + 20;
            categoryBoxPositionY = categoryBoxResetPosY;

            categoryBoxTextPositionX += categoryBoxIncrementX + 20;
            categoryBoxTextPositionY = categoryBoxTextResetPosY;

            for (int i = 0; i < 7; i++)
            {
                // Draws the Lower Section category description containers
                Vector2f categoryBoxSize = new Vector2f(categoryBoxWidth, categoryBoxHeight);
                Vector2f categoryBoxPosition = new Vector2f(categoryBoxPositionX, categoryBoxPositionY);

                RectangleShape categoryBox = new RectangleShape(categoryBoxSize);
                categoryBox.FillColor = Color.Cyan;
                categoryBox.OutlineThickness = 2;
                categoryBox.OutlineColor = Color.Black;
                categoryBox.Position = categoryBoxPosition;
                window.Draw(categoryBox);
                categoryBoxPositionY += categoryBoxIncrementY;

                // Draws the text to go inside the Lower Section category description containers
                Vector2f categoryTextPosition = new Vector2f(categoryBoxTextPositionX, categoryBoxTextPositionY);
                Text categoryText = new Text(lowerSectionText[i], font);
                categoryText.CharacterSize = categoryBoxTextCharacterSize;
                categoryText.FillColor = Color.Blue;
                categoryText.Position = categoryTextPosition;
                window.Draw(categoryText);
                categoryBoxTextPositionY += categoryBoxIncrementY;

                // Adds the Lower Section category containers to the buttonTypes array
                buttonTypes[buttonTypesIndex, 0] = Convert.ToString(categoryText);
                buttonTypes[buttonTypesIndex, 1] = Convert.ToString(categoryBoxPosition.X);
                buttonTypes[buttonTypesIndex, 2] = Convert.ToString(categoryBoxPosition.Y);
                buttonTypes[buttonTypesIndex, 3] = Convert.ToString(categoryBoxSize.X);
                buttonTypes[buttonTypesIndex, 4] = Convert.ToString(categoryBoxSize.Y);
                buttonTypesIndex++;
            }
        }

        /// <summary>
        /// Draws the Lower Section Scores onto the game display window.
        /// </summary>
        public void DrawLowerSectionScores()
        {
            // Sets the new column & row positions
            categoryBoxPositionX += categoryBoxIncrementX;
            categoryBoxPositionY = categoryBoxResetPosY;

            categoryBoxTextPositionX += categoryBoxIncrementX;
            categoryBoxTextPositionY = categoryBoxTextResetPosY;

            for (int i = 6; i < ScoreLinkedList.maxRounds; i++)
            {
                // Draws the Lower Section score containers
                Vector2f categoryBoxSize = new Vector2f(categoryBoxWidth, categoryBoxHeight);
                Vector2f categoryBoxPosition = new Vector2f(categoryBoxPositionX, categoryBoxPositionY);

                RectangleShape categoryBox = new RectangleShape(categoryBoxSize);
                categoryBox.FillColor = Color.Cyan;
                categoryBox.OutlineThickness = 2;
                categoryBox.OutlineColor = Color.Black;
                categoryBox.Position = categoryBoxPosition;
                window.Draw(categoryBox);
                categoryBoxPositionY += categoryBoxIncrementY;

                // Draws the Lower Section score text
                Vector2f scoreTextPosition = new Vector2f(categoryBoxTextPositionX, categoryBoxTextPositionY);
                Text categoryText = new Text(displayCategoryScores[i], font);
                categoryText.CharacterSize = categoryBoxTextCharacterSize;
                categoryText.FillColor = Color.Blue;
                categoryText.Position = scoreTextPosition;
                window.Draw(categoryText);
                categoryBoxTextPositionY += categoryBoxIncrementY;

                // Adds the Lower Sectin score containers and text to the scoreTypes array.
                scoreTypes[scoreTypesIndex, 0] = Convert.ToString(categoryText);
                scoreTypes[scoreTypesIndex, 1] = Convert.ToString(scoreTextPosition.X);
                scoreTypes[scoreTypesIndex, 2] = Convert.ToString(scoreTextPosition.Y);
                scoreTypes[scoreTypesIndex, 3] = Convert.ToString(categoryBoxSize.X);
                scoreTypes[scoreTypesIndex, 4] = Convert.ToString(categoryBoxSize.Y);
                scoreTypesIndex++;
            }
        }

        /// <summary>
        /// Draws the dice containers which display the current round of dice having been rolled.
        /// </summary>
        public void DrawDice()
        {
            // Sets new row & column positions
            categoryBoxPositionX = 45;
            categoryBoxPositionY = 540;

            diceTextPositionX = 47;
            diceTextPositionY = 542;
            diceTextPositionIncrementX = 60;

            for (int i = 0; i < 5; i++)
            {
                // Draws the dice containers
                Vector2f diceBoxSize = new Vector2f(categoryBoxWidth, categoryBoxHeight);
                Vector2f diceBoxPosition = new Vector2f(categoryBoxPositionX, categoryBoxPositionY);

                RectangleShape diceBox = new RectangleShape(diceBoxSize);
                if (diceToKeep[i] == 0)
                {
                    diceBox.FillColor = Color.White;
                }
                else
                {
                    diceBox.FillColor = Color.Yellow;
                }
                diceBox.OutlineThickness = 2;
                diceBox.OutlineColor = Color.Black;
                diceBox.Position = diceBoxPosition;
                window.Draw(diceBox);
                categoryBoxPositionX += categoryBoxIncrementX + 10;

                // Draws the text to go in the dice containers
                Vector2f diceTextPosition = new Vector2f(diceTextPositionX, diceTextPositionY);
                Text diceDisplayText = new Text(Convert.ToString(diceText[i]), font);
                diceDisplayText.CharacterSize = categoryBoxTextCharacterSize;
                diceDisplayText.FillColor = Color.Blue;
                diceDisplayText.Position = diceTextPosition;
                window.Draw(diceDisplayText);
                diceTextPositionX += diceTextPositionIncrementX;

                // Adds dice value and container variables to the buttonTypes array 
                buttonTypes[buttonTypesIndex, 0] = Convert.ToString(diceText);
                buttonTypes[buttonTypesIndex, 1] = Convert.ToString(diceBoxPosition.X);
                buttonTypes[buttonTypesIndex, 2] = Convert.ToString(diceBoxPosition.Y);
                buttonTypes[buttonTypesIndex, 3] = Convert.ToString(diceBoxSize.X);
                buttonTypes[buttonTypesIndex, 4] = Convert.ToString(diceBoxSize.Y);
                buttonTypesIndex++;
            }
        }

        /// <summary>
        /// Draws the Roll Bar, which is utilised in a click method to roll the dice.
        /// </summary>
        public void DrawRollBar()
        {
             // Sets new row & column position
             categoryBoxPositionX = 45;
             categoryBoxPositionY = 600;

             // Draws the Roll Bar container
             Vector2f rollBarBoxSize = new Vector2f(290, 50);
             Vector2f rollBarBoxPosition = new Vector2f(categoryBoxPositionX, categoryBoxPositionY);
             
             RectangleShape rollBar = new RectangleShape(rollBarBoxSize);
             rollBar.FillColor = Color.Cyan;
             rollBar.OutlineThickness = 2;
             rollBar.OutlineColor = Color.Black;
             rollBar.Position = rollBarBoxPosition;
             window.Draw(rollBar);
             
             // Draws the Roll Bar text
             Vector2f rollBarTextPosition = new Vector2f(rollBarTextPositionX, rollBarTextPositionY);
             Text rollBarText = new Text("Roll Dice", font);
             rollBarText.CharacterSize = menuBoxTextCharacterSize;
             rollBarText.FillColor = Color.Blue;
             rollBarText.Position = rollBarTextPosition;
             window.Draw(rollBarText);
             menuBoxTextPositionX += menuBoxIncrementX;
             
             // Adds the Roll Bar to the buttonTypes array
             buttonTypes[buttonTypesIndex, 0] = Convert.ToString(rollBarText);
             buttonTypes[buttonTypesIndex, 1] = Convert.ToString(rollBarBoxPosition.X);
             buttonTypes[buttonTypesIndex, 2] = Convert.ToString(rollBarBoxPosition.Y);
             buttonTypes[buttonTypesIndex, 3] = Convert.ToString(rollBarBoxSize.X);
             buttonTypes[buttonTypesIndex, 4] = Convert.ToString(rollBarBoxSize.Y);
             buttonTypesIndex++;
            
        }

        /// <summary>
        /// Resets the variables used to Draw the different objects in the game window
        /// </summary>
    public void VariableReset()
        {
            // Resets array indexes to 0
            buttonTypesIndex = 0;
            scoreTypesIndex = 0;

            // Menu container dimension and position variables
            menuBoxWidth = 100;
            menuBoxHeight = 20;
            menuBoxPositionX = 20;
            menuBoxPositionY = 20;
            menuBoxIncrementX = 120;

            // Category container dimension and position variables
            categoryBoxWidth = 50;
            categoryBoxHeight = 50;
            categoryBoxPositionX = 20;
            categoryBoxPositionY = 110;
            categoryBoxResetPosX = 20;
            categoryBoxResetPosY = 110;
            categoryBoxIncrementX = 50;
            categoryBoxIncrementY = 60;

            // Menu text position and size variables
            menuBoxTextPositionX = 22;
            menuBoxTextPositionY = 22;
            menuBoxTextCharacterSize = 12;

            // Category text position and size variables
            categoryBoxTextPositionX = 22;
            categoryBoxTextPositionY = 108;
            categoryBoxTextResetPosX = 22;
            categoryBoxTextResetPosY = 108;
            categoryBoxTextCharacterSize = 12;

            // Roll Bar text Position variables
            rollBarTextPositionX = 47;
            rollBarTextPositionY = 602;
        }
    }
}
