using System.Collections.Generic;
using Unit04.Game.Casting;
using Unit04.Game.Services;
using System;

using System.IO;
using System.Linq;

using Unit04.Game.Directing;



namespace Unit04.Game.Directing
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private KeyboardService keyboardService = null;
        private VideoService videoService = null;
        int score = 500;

        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this.keyboardService = keyboardService;
            this.videoService = videoService;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void StartGame(Cast cast)
        {
            Actor banner = cast.GetFirstActor("banner");
            
            
            banner.SetText("Money = "+ score);
            videoService.OpenWindow();
            while (videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            videoService.CloseWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the robot.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void GetInputs(Cast cast)
        {
            Actor robot = cast.GetFirstActor("robot");
            Point velocity = keyboardService.GetDirection();
            robot.SetVelocity(velocity);     
        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {
Random random = new Random();
            string text = ((char)random.Next(42, 44)).ToString();
                

                int x = random.Next(1, 60);
                int y = random.Next(0, 5);
                Point position = new Point(x, y);
                position = position.Scale(15);

                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);
                Color color = new Color(r, g, b);

                Artifact newGuy = new Artifact();
                newGuy.SetText(text);
                newGuy.SetFontSize(15);
                newGuy.SetColor(color);
                newGuy.SetPosition(position);
                
            
                cast.AddActor("artifacts", newGuy);
            


            Actor banner = cast.GetFirstActor("banner");
            Actor robot = cast.GetFirstActor("robot");
            List<Actor> artifacts = cast.GetActors("artifacts");

            
            int maxX = videoService.GetWidth();
            int maxY = videoService.GetHeight();
            robot.MoveNext(maxX, maxY);
Point bottom = new Point(0, 600);
            foreach (Actor actor in artifacts)
            {
                Point Fall = actor.GetPosition();
                Point Speed = new Point(0, 5);
                Fall = Fall.Add(Speed);
                actor.SetPosition(Fall);
                 if(Fall.Equals(bottom)){
                    cast.RemoveActor("Artifact", actor);

                }

                if (robot.GetPosition().Equals(actor.GetPosition()))
                {
                    string check = actor.GetText();
                    if(check.Equals("+")){
                        score += 1;
                        banner.SetText("Money = "+ score);
                    }
                    else{
                        score -= 1;
                        banner.SetText("Money = "+ score);
                    }
                    Artifact artifact = (Artifact) actor;
                    string message = artifact.GetMessage();
                   
                }
            } 
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            videoService.ClearBuffer();
            videoService.DrawActors(actors);
            videoService.FlushBuffer();
        }

    }
}