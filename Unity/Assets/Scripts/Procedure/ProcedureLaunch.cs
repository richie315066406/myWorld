using GameFramework.Localization;
using System;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace ProjectZGL
{
    public class ProcedureLaunch : ProcedureBase
    {
        public override bool UseNativeDialog
        {
            get
            {
                return true;
            }
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            // ������Ϣ�������汾ʱ����һЩ������ Json �ĸ�ʽд�� Assets/GameMain/Configs/BuildInfo.txt������Ϸ�߼���ȡ��
            //			GameEntry.BuiltinData.InitBuildInfo();

            // �������ã����õ�ǰʹ�õ����ԣ���������ã���Ĭ��ʹ�ò���ϵͳ���ԡ�
            InitLanguageSettings();

            // �������ã�����ʹ�õ����ԣ�֪ͨ�ײ���ض�Ӧ����Դ���塣
            //			InitCurrentVariant();

            // �������ã����ݼ�⵽��Ӳ����Ϣ Assets/Main/Configs/DeviceModelConfig ���û��������ݣ����ü���ʹ�õĻ���ѡ�
            //			InitQualitySettings();

            // �������ã������û��������ݣ����ü���ʹ�õ�����ѡ�
            //			InitSoundSettings();

            // Ĭ���ֵ䣺����Ĭ���ֵ��ļ� Assets/GameMain/Configs/DefaultDictionary.xml��
            // ���ֵ��ļ���¼����Դ����ǰʹ�õĸ������Ե��ַ��������� App һ�𷢲����ʲ��ɸ��¡�
            GameEntry.BuiltinData.InitDefaultDictionary();
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            ChangeState<ProcedureSplash>(procedureOwner);
        }

        private void InitLanguageSettings()
        {
            if (GameEntry.Base.EditorResourceMode && GameEntry.Base.EditorLanguage != Language.Unspecified)
            {
                // �༭����Դģʽֱ��ʹ�� Inspector �����õ�����
                return;
            }

            Language language = GameEntry.Localization.Language;
            string languageString = GameEntry.Setting.GetString(Constant.Setting.Language);
            if (!string.IsNullOrEmpty(languageString))
            {
                try
                {
                    language = (Language)Enum.Parse(typeof(Language), languageString);
                }
                catch
                {

                }
            }

            if (language != Language.English
                && language != Language.ChineseSimplified
                && language != Language.ChineseTraditional
                && language != Language.Korean)
            {
                // �����ݲ�֧�ֵ����ԣ���ʹ��Ӣ��
                language = Language.English;

                GameEntry.Setting.SetString(Constant.Setting.Language, language.ToString());
                GameEntry.Setting.Save();
            }

            GameEntry.Localization.Language = language;

            Log.Info("Init language settings complete, current language is '{0}'.", language.ToString());
        }

        private void InitCurrentVariant()
        {
            if (GameEntry.Base.EditorResourceMode)
            {
                // �༭����Դģʽ��ʹ�� AssetBundle��Ҳ��û�б�����
                return;
            }

            string currentVariant = null;
            switch (GameEntry.Localization.Language)
            {
                case Language.English:
                    currentVariant = "en-us";
                    break;
                case Language.ChineseSimplified:
                    currentVariant = "zh-cn";
                    break;
                case Language.ChineseTraditional:
                    currentVariant = "zh-tw";
                    break;
                case Language.Korean:
                    currentVariant = "ko-kr";
                    break;
                default:
                    currentVariant = "zh-cn";
                    break;
            }

            GameEntry.Resource.SetCurrentVariant(currentVariant);

            Log.Info("Init current variant complete.");
        }

        private void InitQualitySettings()
        {
            //			QualityLevelType defaultQuality = GameEntry.BuiltinData.DeviceModelConfig.GetDefaultQualityLevel();
            //			int qualityLevel = GameEntry.Setting.GetInt(Constant.Setting.QualityLevel, (int)defaultQuality);
            //			QualitySettings.SetQualityLevel(qualityLevel, true);
            //
            //			Log.Info("Init quality settings complete.");
        }

        private void InitSoundSettings()
        {
            //TODO ������ص�֮�����
            //			GameEntry.Sound.Mute("Music", GameEntry.Setting.GetBool(Constant.Setting.MusicMuted, false));
            //			GameEntry.Sound.SetVolume("Music", GameEntry.Setting.GetFloat(Constant.Setting.MusicVolume, 0.3f));
            //			GameEntry.Sound.Mute("Sound", GameEntry.Setting.GetBool(Constant.Setting.SoundMuted, false));
            //			GameEntry.Sound.SetVolume("Sound", GameEntry.Setting.GetFloat(Constant.Setting.SoundVolume, 1f));
            //			GameEntry.Sound.Mute("UISound", GameEntry.Setting.GetBool(Constant.Setting.UISoundMuted, false));
            //			GameEntry.Sound.SetVolume("UISound", GameEntry.Setting.GetFloat(Constant.Setting.UISoundVolume, 1f));
            //
            //			Log.Info("Init sound settings complete.");
        }
    }

}