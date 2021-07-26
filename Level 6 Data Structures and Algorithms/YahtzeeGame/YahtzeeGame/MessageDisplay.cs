using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace YahtzeeGame
{
    public class MessageDisplay
    {
        RectangleShape messageBackground;
        RectangleShape exitButton;
        RectangleShape newGameButton;
        Text textMessage;
        Text exitText;
        Text newGameText;
        public static Vector2f exitButtonPosition;
        public static Vector2f buttonSize;
        public static Vector2f newGameButtonPosition;


        /// <summary>
        /// Constructor method
        /// </summary>
        public MessageDisplay()
        {
            messageBackground = new RectangleShape();
            exitButton = new RectangleShape();
            newGameButton = new RectangleShape();
            textMessage = new Text();
            exitText = new Text();
            newGameText = new Text();
        }

        /// <summary>
        /// Overloaded Constructor method to customeise the message being delivered.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="size"></param>
        /// <param name="message"></param>
        /// <param name="messageType"></param>
        /// <param name="colour"></param>
        public MessageDisplay(Vector2f position, Vector2f size, string message, string messageType, Color colour):  this()
        {
            // Creates the message box
            messageBackground.Size = size;
            messageBackground.Position = position;
            messageBackground.FillColor = colour;
            messageBackground.OutlineThickness = 4;
            messageBackground.OutlineColor = Color.Black;

            // Creates the text to go inside the message box
            Vector2f textPosition = new Vector2f(position.X + 5, position.Y + 5);
            textMessage.DisplayedString = message;
            textMessage.Font = GameDisplay.font;
            textMessage.FillColor = Color.Black;
            textMessage.CharacterSize = GameDisplay.menuBoxTextCharacterSize;
            textMessage.Position = textPosition;
            
            // Creates the "Return to Game" or "Exit Game" buttons
            buttonSize = new Vector2f(125, 25);
            exitButtonPosition = new Vector2f(((position.X + size.X) - (buttonSize.X + 5)), ((position.Y + size.Y) - (buttonSize.Y + 5)));
            exitButton.Size = buttonSize;
            exitButton.Position = exitButtonPosition;
            exitButton.FillColor = Color.Blue;
            exitButton.OutlineThickness = 2;
            exitButton.OutlineColor = Color.Black;

            // Creates the "Return to Game" or "Exit Game" text for the buttons
            Vector2f exitTextPosition = new Vector2f(exitButtonPosition.X + 5, exitButtonPosition.Y + 5);
            if (messageType == "Finished")
            {
                exitText.DisplayedString = "Exit Game";
            }
            else
            {
                exitText.DisplayedString = "Return to Game";
            }
            exitText.Font = GameDisplay.font;
            exitText.FillColor = Color.White;
            exitText.CharacterSize = GameDisplay.menuBoxTextCharacterSize;
            exitText.Position = exitTextPosition;

            if (messageType == "Finished")
            {
                // Creates an additional button 
                newGameButtonPosition = new Vector2f((position.X + 5), (position.Y + size.Y - buttonSize.Y - 5));
                newGameButton.Size = buttonSize;
                newGameButton.Position = newGameButtonPosition;
                newGameButton.FillColor = Color.Blue;
                newGameButton.OutlineThickness = 2;
                newGameButton.OutlineColor = Color.Black;

                // Creates the text for the additional button
                Vector2f newGameTextPosition = new Vector2f(newGameButtonPosition.X + 5, newGameButtonPosition.Y + 5);

                newGameText.DisplayedString = "Play a New Game";
                newGameText.Font = GameDisplay.font;
                newGameText.FillColor = Color.White;
                newGameText.CharacterSize = GameDisplay.menuBoxTextCharacterSize;
                newGameText.Position = newGameTextPosition;
            }
        }

        // Finds the message for the specific situation and returns it.
        public string GetMessage(string messageType)
        {
            string message = "";
            switch (messageType)
            {
                case "How To Play":
                    message = GetInstructions();
                    break;
                case "Maxed Rolls":
                    message = GetMaxedOutRolls();
                    break;
                case "Finished":
                    message = GetFinishedGame();
                    break;
                case "Choose Another Category":
                    message = GetChooseAnotherCategory();
                    break;
                case "Roll Dice":
                    message = GetRollDice();
                    break;
                default:
                    break;
            }
            return message;
        }
        
        // Draw method
        public void Draw(RenderTarget target, RenderStates state)
        {
            // draws the background first
            target.Draw(this.messageBackground, state);

           // draws the message on the background            
            target.Draw(this.textMessage, state);

            // draws the Return To Game / Exit Game button
            target.Draw(this.exitButton, state);

            // draws the Return To Game / Exit Game button text
            target.Draw(this.exitText, state);

            // draws the additional button
            target.Draw(this.newGameButton, state);

            // draw the additional button text
            target.Draw(this.newGameText, state);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////MESSAGE TEXTS/////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Returns the "How To Play" instructions
        /// </summary>
        /// <returns></returns>
        public string GetInstructions()
        {
            string instructions = "How To Play:" +
                "\n\n1. To begin a game, roll the dice by pressing the SPACE bar, or" +
                "\n    by clicking on the ROLL DICE button." +
                "\n2. If you are happy with the dice that have been rolled, select " +
                "\n    a scoring category by clicking on the desired category." +
                "\n3. If you would like to roll different dice, select the ones you " +
                "\n    wish to keep (they will appear yellow) and then roll again. " +
                "\n    You can re-roll dice twice before you must choose a scoring " +
                "\n    category." +
                "\n4. When all of the scoring categories have been scored in, the " +
                "\n    game is over." +
                "\n5. To play a new game, click the NEW GAME button." +
                "\n6. To exit the game, press the ESC key, or click the EXIT button.";
            return instructions;
        }

        /// <summary>
        /// Returns the message when a user has already rolled the dice 3 times in a turn and must choose a scoring category.
        /// </summary>
        /// <returns></returns>
        public string GetMaxedOutRolls()
        {
            string maxedOutRolls = "You have already used all your re-rolls for this turn." +
                "\n\nPlease choose a scoring category.";
            return maxedOutRolls;
        }

        /// <summary>
        /// Returns the text when a player has completed their game.
        /// </summary>
        /// <returns></returns>
        public string GetFinishedGame()
        {
            string finishedGame = "Congratulations! " +
                "\n\nYou have completed your game." +
                "\n\nYour final score is " + Convert.ToString(GameDisplay.ScoreCard.totalScore) + ".";
            return finishedGame;
        }

        /// <summary>
        /// Returns the text when a player has already scored in a category previously.
        /// </summary>
        /// <returns></returns>
        public string GetChooseAnotherCategory()
        {
            string chooseAnother = "You have already scored in this category." +
                "\n\nPlease choose another.";
            return chooseAnother;
        }

        // Returns the text for prompting the player to roll the dice.
        private string GetRollDice()
        {
            string rollDice = "You have already selected a category to score this round in." +
                "\n\nPlease roll the dice to begin a new round.";
            return rollDice;
        }
    }
}
 