using Exo4.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exo4.Core
{
    public class Frame
    {
        public int score;
        private bool _lastFrame;
        private IGenerateur _generateur;
        private List<Roll> rolls { get; set; }

        public Frame(IGenerateur generateur, bool lastFrame)
        {
            _lastFrame = lastFrame;
            _generateur = generateur;
        }

        public bool MakeRoll()
        {
            // Roll_SimpleFrame_FirstRoll_CheckScore
            if (rolls == null)
            {
                rolls = new List<Roll>();
            }

            int remainingPins = 10;
            if (!_lastFrame && rolls.Count == 1)
            {
                remainingPins -= rolls[0].pins;
            }


            int pins = _generateur.RandomPin(remainingPins);
            rolls.Add(new Roll { pins = pins });

            score += pins;

            if (_lastFrame)
            {
                if (rolls.Count == 2 && rolls[0].pins + rolls[1].pins >= 10)
                {
                    // troisième roll possible
                    return true;
                }
                else if (rolls.Count < 2)
                {
                    // deuxième roll encore possible
                    return true;
                }
            }
            else
            {
                // frame normal : true seulement pour le premier roll
                return rolls.Count == 1;
            }

            return false;

        }
    }
}
