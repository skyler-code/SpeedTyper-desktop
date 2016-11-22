using SpeedTyperDataObjects;
using SpeedTyperDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTyperLogicLayer
{
    public class LevelManager
    {
        public int CalculateXP(decimal WPM, decimal WPMXPModifier, decimal timeXPModifier)
        {
            int returnXP = 0;

            try
            {
                returnXP = (int)(WPM * (WPMXPModifier + timeXPModifier));
            }
            catch (Exception)
            {

                throw;
            }

            return returnXP;
        }

        public decimal GetWPMXPModifier(decimal WPM)
        {
            decimal xpModifier = 1.0M;
            try
            {
                xpModifier = LevelAccessor.RetrieveWPMXPModifier(WPM);
            }
            catch (Exception)
            {
                throw;
            }
            return xpModifier;
        }

        public decimal GetTimeMXPModifier(decimal secondsElapsed)
        {
            decimal xpModifier = 1.0M;
            try
            {
                xpModifier = LevelAccessor.RetrieveTimeXPModifier(secondsElapsed);
            }
            catch (Exception)
            {
                throw;
            }
            return xpModifier;
        }

    }
}
