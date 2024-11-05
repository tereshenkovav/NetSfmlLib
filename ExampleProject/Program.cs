using NetSfmlLib;
using System;
using SFML.Window;
using SFML.Graphics;

namespace ExampleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjModule.opt = new Options();
            ObjModule.opt.setWindowParams(800, 600);
            ObjModule.texts.addText("gametitle","NetSfmlLib example") ;
            var window = new NetSfmlLib.Window();
            window.Show(typeof(SceneStart), typeof(SceneStart));
        }
    }
}
