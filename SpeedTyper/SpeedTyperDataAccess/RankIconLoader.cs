using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SpeedTyperDataAccess
{
    public class RankIconLoader
    {

        private ResourceDictionary _resDictionary;

        public RankIconLoader()
        {
            _resDictionary = new ResourceDictionary();
            _resDictionary.Source =
                new Uri("/SpeedTyper;component/Resources/images.xaml",
                    UriKind.RelativeOrAbsolute);
        }

        public ImageSource LoadRankIcon(int rankID)
        {
            ImageSource rankIcon;
            string fileName;
            if (rankID < 10)
            {
                fileName = "Rank0" + rankID;
            }
            else
            {
                fileName = "Rank" + rankID;
            }
            try
            {
                rankIcon = (ImageSource)_resDictionary[fileName];
            }
            catch (Exception)
            {

                throw;
            }

            return rankIcon;
        }
    }
}
