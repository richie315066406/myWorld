namespace ProjectZGL
{
    public static class AssetUtility
    {
        public static string GetConfigAsset(string assetName)
        {
            return string.Format("Assets/Datas/Configs/{0}.txt", assetName);
        }

        public static string GetDataTableAsset(string assetName)
        {
            return string.Format("Assets/Datas/DataTables/{0}.txt", assetName);
        }

        public static string GetDictionaryAsset(string assetName)
        {
            return string.Format("Assets/Datas/Localization/{0}/Dictionaries/{1}.xml", GameEntry.Localization.Language.ToString(), assetName);
        }

        public static string GetFontAsset(string assetName)
        {
            return string.Format("Assets/Datas/Localization/{0}/Fonts/{1}.ttf", GameEntry.Localization.Language.ToString(), assetName);
        }

        public static string GetSceneAsset(string assetName)
        {
            return string.Format("Assets/Scenes/{0}.unity", assetName);
        }

        public static string GetMusicAsset(string assetName)
        {
            //TODO 声音文件改路径
            return string.Format("Assets/ProjectZGL/Music/{0}.mp3", assetName);
        }

        public static string GetSoundAsset(string assetName)
        {
            //TODO 声音文件改路径
            return string.Format("Assets/ProjectZGL/Sounds/{0}.wav", assetName);
        }

        public static string GetEntityAsset(string assetName)
        {
            return string.Format("Assets/Entitas/{0}.prefab", assetName);
        }
        public static string GetUIFormAsset(string assetName)
        {
            return string.Format("Assets/Entitas/UI/UIForms/{0}.prefab", assetName);
        }

        public static string GetUISoundAsset(string assetName)
        {
            return string.Format("Assets/Entitas/UI/UISounds/{0}.wav", assetName);
        }

        public static string GetBackgroundAsset(string assetName){
            return string.Format("Assets/Entitas/UI/UISprites/Backgrounds/{0}.png", assetName);
        }
        
        public static string GetCharacter(string assetName){
            return string.Format("Assets/ProjectZGL/UI/UISprites/Character/{0}.png", assetName);
        }

        public static string GetItemAsset(string assetName){
            return string.Format("Assets/ProjectZGL/UI/UISprites/Items/{0}.png", assetName);
        }

	    public static string GetUIItemAsset(string assetName)
	    {
		    return string.Format("Assets/ProjectZGL/UI/UIItems/{0}.prefab", assetName);
	    }
	}
}
