using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using NetSfmlLib;

namespace ExampleProject
{
    public class SceneStart : Scene
    {
        private Sprite sprite;
        private Font font;
        private Text text ;
        private float angle = 0.0f ;

        public override void Init()
        {
            sprite = SfmlHelper.LoadSprite(@"sfml-logo-small.png",SpriteLoaderOptions.sloCentered);
            sprite.Position = new Vector2f(ObjModule.opt.getWindowWidth() / 2, 300);

            font = new Font(@"arial.ttf");
            text = new Text("", font, 22);
        }

        public override void UnInit()
        {
            
        }
        
        public override SceneResult Frame(float dt, IEnumerable<EventArgsEx> events)
        {
            // Обход событий, для Esc - выход из игры
            foreach (EventArgsEx args in events)
            {
                if (args.released) continue;

                if (args.e is KeyEventArgs keyEventArg)
                {
                    if (keyEventArg.Code == Keyboard.Key.Escape)
                    	return SceneResult.Exit;
                }

            }
            angle+=50*dt ;
            sprite.Rotation=angle ;
            return SceneResult.Normal;
        }

        public override void Render(RenderWindow window)
        {
        	window.Draw(sprite);
		DrawTextCentered(window, text, 
                    "Press Esc to exit", 
                    ObjModule.opt.getWindowWidth() / 2, 50);
        }
    }
}
