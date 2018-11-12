using UnityGameFramework.Runtime;

namespace ProjectZGL{
    public static class TimeUtility{
        public static string TimeFormat(int time)
        {
            // string h = s.Substring(s.Length - 2);
            // string day = s.Substring(0, s.Length - 2);
            string h = (time%24).ToString();
            string day = (time/24).ToString();

            string nowTime = string.Format(GameEntry.Localization.GetString("PlayerUI.TimeText"), h, day);
            return nowTime;
        }

    }
}