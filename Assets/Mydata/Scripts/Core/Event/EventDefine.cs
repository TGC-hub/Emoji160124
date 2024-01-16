using System;
namespace CoreGame {
    public partial class EventDefine {
        //Define all Action in game
        public static Action StartGame;
        public static Action PauseGame;
        public static Action ContinueGame;
        public static Action EndGame;
        public static Action EndPhase;
        public static Action NextPhase;
        public static Action EndIntro;
        public static Action<TypeEmojiArrow> LoadNewModel;
    }
}

