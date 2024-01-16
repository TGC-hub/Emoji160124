using UnityEngine;

namespace CoreGame {
    public partial class UserData {
        public static int CurrrentLevel {
            get { return PlayerPrefs.GetInt("CurrentLevel", 1); }
            set { PlayerPrefs.SetInt("CurrentLevel", value > 0 ? value : 1);}
        }
        public static float Cash {
            get { return PlayerPrefs.GetFloat("CurrentCash", 0); }
            set { PlayerPrefs.SetFloat("CurrentCash", value >= 0 ? value : 0);}
        }

        public static bool RunAppFirst {
            get { 
                if(!PlayerPrefs.HasKey("RunFirst")) return true;
                return PlayerPrefs.GetInt("RunFirst") == 0;
            }
            set => PlayerPrefs.SetInt("RunFirst",value ? 1 : 0);
        }
    }
}

