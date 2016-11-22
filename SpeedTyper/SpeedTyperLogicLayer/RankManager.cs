using SpeedTyperDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SpeedTyperLogicLayer
{
    public class RankManager
    {
        private RankIconLoader rankIconLoader = new RankIconLoader();
        public string RetrieveUserRankName(int rankID)
        {
            string rankName;

            try
            {
                rankName = UserAccessor.RetrieveUserRankName(rankID);
            }
            catch (Exception)
            {
                throw;
            }
            return rankName;
        }

        public ImageSource RetrieveRankIcon(int rankID)
        {
            ImageSource rankIcon;

            try
            {
                rankIcon = rankIconLoader.LoadRankIcon(rankID);
            }
            catch (Exception)
            {
                throw;
            }

            return rankIcon;
        }

        public List<ImageSource> RetrieveRankIcons(List<int> rankIDs)
        {
            List<ImageSource> returnList = new List<ImageSource>();

            try
            {
                foreach (int rankID in rankIDs)
                {
                    returnList.Add(rankIconLoader.LoadRankIcon(rankID));
                }
            }
            catch (Exception)
            {

                throw;
            }
            return returnList;
        }

    }
}
