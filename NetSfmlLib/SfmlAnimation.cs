﻿using System;
using SFML.Graphics;

namespace NetSfmlLib
{    
    // Класс анимации - реализуем сами на основе спрайта
    public class SfmlAnimation: Sprite
    {
        private enum PlayState
        {
            Played, PlayedOnce, Stopped
        }
        private Texture[] frames;
        private int FrameCount;
        private float sec_per_frame;
        private float tekt;
        private PlayState playstate;

        // Добавить опции спрайтов обычные
        public SfmlAnimation(String filename, int FrameCount, float FPS): base()
        {
            this.FrameCount = FrameCount;
            sec_per_frame = 1.0f / FPS;
            playstate = PlayState.Stopped;
            frames = new Texture[FrameCount];

            var img = new Image(filename);

            IntRect area = new IntRect(0, 0, (int)img.Size.X / FrameCount, (int)img.Size.Y);
            for (int i=0; i<FrameCount; i++)
            {
                frames[i] = new Texture(img, area);
                area.Left += area.Width;
            }
            tekt = 0;
            setFrame(0);
        }

        public SfmlAnimation(String filename, int framew, int frameh, int FrameCount, float FPS) : base()
        {
            this.FrameCount = FrameCount;
            sec_per_frame = 1.0f / FPS;
            playstate = PlayState.Stopped;
            frames = new Texture[FrameCount];

            var img = new Image(filename);

            IntRect area = new IntRect(0, 0, framew, frameh);
            for (int i = 0; i < FrameCount; i++)
            {
                frames[i] = new Texture(img, area);
                area.Left += framew;
                if (area.Left >= (int)img.Size.X)
                {
                    area.Left = 0;
                    area.Top += frameh;
                }
            }
            tekt = 0;
            setFrame(0);
        }

        public void Update(float dt)
        {
            if (!isPlayed()) return;

            tekt += dt;
            int tekframe = (int)(tekt / sec_per_frame);
            if (tekframe>=FrameCount)
            {
                tekframe = 0;
                tekt-=FrameCount * sec_per_frame;
                if (playstate == PlayState.PlayedOnce) playstate = PlayState.Stopped;
            }
            setFrame(tekframe);
        }
        public bool isPlayed()
        {
            return playstate != PlayState.Stopped;
        }
        public void Play()
        {
            playstate = PlayState.Played;
        }
        public void Stop()
        {
            playstate = PlayState.Stopped;
        }
        public void PlayOnce()
        {
            playstate = PlayState.PlayedOnce;
        }
        public int getFrameCount()
        {
            return FrameCount;
        }
        public void setFrame(int n)
        {
            Texture = frames[n];
        }
    }
}
