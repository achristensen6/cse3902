﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame2
{
    public class SClimbingUpLeftSmallMario : ISmallMarioState, IClimbingMarioState, ILeftMarioState
    {
        public IPlayer Player { get; set; }

        public SClimbingUpLeftSmallMario(IPlayer player)
        {
            this.Player = player;
            Player.Sprite = new MarioAnimation(HUD.currentPlayer == 0 ? Textures.mario0 : Textures.luigi0, Textures.smallLeftClimbing);

            Player.Hitbox.SetOffset(Hitboxes.SMALL_MARIO_CLIMBING_OFFSET_X, Hitboxes.SMALL_MARIO_CLIMBING_OFFSET_Y);
            Player.Hitbox.Clear();
            SetHitbox();

            Player.Acceleration = Vector2.Zero;
            Player.Velocity = new Vector2(0f, -1f);
        }

        public void Update()
        {
            HUD.HangTime = 0;
            Player.SequenceCounter = 0;
            Player.Hitbox.Cycle();
            SetHitbox();
        }

        private void SetHitbox()
        {
            Player.Hitbox.AddRectHitbox(
                    (int)Player.Position.X,
                    (int)Player.Position.Y,
                    Hitboxes.SMALL_MARIO_CLIMBING_WIDTH,
                    Hitboxes.SMALL_MARIO_CLIMBING_HEIGHT
                );
        }

        public void GoLeft()
        {
            Player.Position = new Vector2(Player.Position.X - Hitboxes.SMALL_MARIO_CLIMBING_WIDTH - Hitboxes.ROPE_WIDTH + 2, Player.Position.Y);
            Player.State = new SClimbingIdleRightSmallMario(Player);
        }

        public void GoRight()
        {
            Player.State = new SIdleRightSmallMario(Player);
            Player.Position = new Vector2(Player.Position.X + 1, Player.Position.Y);
        }

        public void GoUp()
        {

        }

        public void GoDown()
        {
            Player.State = new SClimbingDownLeftSmallMario(Player);
        }

        public void GoNowhere()
        {
            Player.State = new SClimbingIdleLeftSmallMario(Player);
        }

        public void Jump()
        {

        }

        public void HoldJump()
        {

        }

        public void Run()
        {
            ((Mario)Player).IsRunning = true;
        }

        public void Climb()
        {

        }

        public void PowerUp()
        {
            Player.State = new SMarioTansition(Player, typeof(SIdleLeftBigMario), Textures.smallBigTransitionLeft); 
        }

        public void PowerDown()
        {
            Player.State = new SDeadMario(Player);
        }

        public void KillMe()
        {
            Player.State = new SDeadMario(Player);
        }


    }
}