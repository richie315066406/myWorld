using GameFramework;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.Resource;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace ProjectZGL
{
    /// <summary>
    /// 所有预加载相关的流程
    /// </summary>
    public class ProcedurePreload : ProcedureBase
    {
        private Dictionary<string, bool> m_LoadedFlag = new Dictionary<string, bool>();
        //        private string[] DataTableFiles = null;

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

            GameEntry.Event.Subscribe(LoadConfigSuccessEventArgs.EventId, OnLoadConfigSuccess);
            GameEntry.Event.Subscribe(LoadConfigFailureEventArgs.EventId, OnLoadConfigFailure);
            GameEntry.Event.Subscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
            GameEntry.Event.Subscribe(LoadDataTableFailureEventArgs.EventId, OnLoadDataTableFailure);
            GameEntry.Event.Subscribe(LoadDictionarySuccessEventArgs.EventId, OnLoadDictionarySuccess);
            GameEntry.Event.Subscribe(LoadDictionaryFailureEventArgs.EventId, OnLoadDictionaryFailure);

            m_LoadedFlag.Clear();

            PreloadResources();
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            GameEntry.Event.Unsubscribe(LoadConfigSuccessEventArgs.EventId, OnLoadConfigSuccess);
            GameEntry.Event.Unsubscribe(LoadConfigFailureEventArgs.EventId, OnLoadConfigFailure);
            GameEntry.Event.Unsubscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
            GameEntry.Event.Unsubscribe(LoadDataTableFailureEventArgs.EventId, OnLoadDataTableFailure);
            GameEntry.Event.Unsubscribe(LoadDictionarySuccessEventArgs.EventId, OnLoadDictionarySuccess);
            GameEntry.Event.Unsubscribe(LoadDictionaryFailureEventArgs.EventId, OnLoadDictionaryFailure);

            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            IEnumerator<bool> iter = m_LoadedFlag.Values.GetEnumerator();
            while (iter.MoveNext())
            {
                Log.Warning(iter);
                if (!iter.Current)
                {
                    return;
                }
            }

            procedureOwner.SetData<VarInt>(Constant.ProcedureData.NextSceneId, GameEntry.Config.GetInt("Scene.Menu"));
	        ChangeState<ProcedureChangeScene>(procedureOwner);
        }

        private void PreloadResources()
        {
            // Preload configs
            LoadConfig("DefaultConfig");

            // Preload data tables
            LoadDataTable("Character");
            LoadDataTable("Commodity");
            LoadDataTable("Entity");
            LoadDataTable("Function");
            LoadDataTable("Item");
            LoadDataTable("Shop");
            LoadDataTable("Site");
	        LoadDataTable("Scene");
			// LoadDataTable("Sound");
			LoadDataTable("UIForm");
            // LoadDataTable("UISound");

            // Preload dictionaries
            LoadDictionary("Default");

            // Preload fonts
            LoadFont("MainFont");

            // Preload ItemPic
            LoadItemPic("Rune-1");
            LoadItemPic("Rune-2");
            LoadItemPic("Rune-3");
            LoadItemPic("Rune-4");
            LoadItemPic("Rune-5");
            LoadItemPic("Rune-6");
            LoadItemPic("Rune-7");
            LoadItemPic("Rune-8");
            LoadItemPic("Rune-9");
            LoadItemPic("Rune-10");

	        // Preload BgPic
			LoadBgImageAsset("beijingzhan");
		}

		private void LoadConfig(string configName)
        {
            m_LoadedFlag.Add(string.Format("Config.{0}", configName), false);
            GameEntry.Config.LoadConfig(configName, this);
        }

        private void LoadDataTable(string dataTableName)
        {
            m_LoadedFlag.Add(string.Format("DataTable.{0}", dataTableName), false);
            GameEntry.DataTable.LoadDataTable(dataTableName, this);
        }

        private void LoadDictionary(string dictionaryName)
        {
            m_LoadedFlag.Add(string.Format("Dictionary.{0}", dictionaryName), false);
            GameEntry.Localization.LoadDictionary(dictionaryName, this);
        }

        private void LoadFont(string fontName)
        {
            m_LoadedFlag.Add(string.Format("Font.{0}", fontName), false);
            GameEntry.Resource.LoadAsset(AssetUtility.GetFontAsset(fontName), Constant.AssetPriority.FontAsset, new LoadAssetCallbacks(
                (assetName, asset, duration, userData) =>
                {
                    m_LoadedFlag[string.Format("Font.{0}", fontName)] = true;
                    UGuiForm.SetMainFont((Font)asset);
                    Log.Info("Load font '{0}' OK.", fontName);
                },

                (assetName, status, errorMessage, userData) =>
                {
                    Log.Error("Can not load font '{0}' from '{1}' with error message '{2}'.", fontName, assetName, errorMessage);
                }));
        }

        private void LoadItemPic(string PicName)
        {
            m_LoadedFlag.Add(string.Format("Pic.{0}", PicName), false);
            GameEntry.Resource.LoadAsset(AssetUtility.GetItemAsset(PicName), Constant.AssetPriority.UIFormAsset, new LoadAssetCallbacks(
                (assetName, asset, duration, userData) =>
                {
                    m_LoadedFlag[string.Format("Pic.{0}", PicName)] = true;
                    // UGuiForm.SetMainFont((Font)asset);
                    // Item.ImageList.Add((Sprite)asset);
                    // Item.AddImageAsset((Texture2D)asset);
                    Sprite sprite = Sprite.Create((Texture2D)asset, new Rect(0, 0, 128, 128), Vector2.zero);
                    Item.AddImageAsset(sprite);
                    Log.Info("Load Pic '{0}' OK.", asset.GetType());
                    Log.Info("Load Pic '{0}' OK.", PicName);
                },

                (assetName, status, errorMessage, userData) =>
                {
                    Log.Error("Can not load font '{0}' from '{1}' with error message '{2}'.", PicName, assetName, errorMessage);
                }));
        }

        private void LoadBgImageAsset(string BgName)
        {
            m_LoadedFlag.Add(string.Format("Pic.{0}", BgName), false);
            GameEntry.Resource.LoadAsset(AssetUtility.GetBackgroundAsset(BgName), Constant.AssetPriority.UIFormAsset, new LoadAssetCallbacks(
                (assetName, asset, duration, userData) =>
                {
                    m_LoadedFlag[string.Format("Pic.{0}", BgName)] = true;
                    // UGuiForm.SetMainFont((Font)asset);
                    // Item.ImageList.Add((Sprite)asset);
                    // Item.AddImageAsset((Texture2D)asset);
                    Sprite sprite = Sprite.Create((Texture2D)asset, new Rect(0, 0, 128, 128), Vector2.zero);
                    CommonForm.AddBgImage(sprite);
                    // Log.Info("Load Pic '{0}' OK.", asset.GetType());
                    Log.Info("Load Pic '{0}' OK.", BgName);
                },

                (assetName, status, errorMessage, userData) =>
                {
                    Log.Error("Can not load font '{0}' from '{1}' with error message '{2}'.", BgName, assetName, errorMessage);
                }));
        }


        private void OnLoadConfigSuccess(object sender, GameEventArgs e)
        {
            LoadConfigSuccessEventArgs ne = (LoadConfigSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            m_LoadedFlag[string.Format("Config.{0}", ne.ConfigName)] = true;
            Log.Info("Load config '{0}' OK.", ne.ConfigName);
        }

        private void OnLoadConfigFailure(object sender, GameEventArgs e)
        {
            LoadConfigFailureEventArgs ne = (LoadConfigFailureEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Error("Can not load config '{0}' from '{1}' with error message '{2}'.", ne.ConfigName, ne.ConfigAssetName, ne.ErrorMessage);
        }

        private void OnLoadDataTableSuccess(object sender, GameEventArgs e)
        {
            LoadDataTableSuccessEventArgs ne = (LoadDataTableSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            m_LoadedFlag[string.Format("DataTable.{0}", ne.DataTableName)] = true;
            Log.Info("Load data table '{0}' OK.", ne.DataTableName);
        }

        private void OnLoadDataTableFailure(object sender, GameEventArgs e)
        {
            LoadDataTableFailureEventArgs ne = (LoadDataTableFailureEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Error("Can not load data table '{0}' from '{1}' with error message '{2}'.", ne.DataTableName, ne.DataTableAssetName, ne.ErrorMessage);
        }

        private void OnLoadDictionarySuccess(object sender, GameEventArgs e)
        {
            LoadDictionarySuccessEventArgs ne = (LoadDictionarySuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            m_LoadedFlag[string.Format("Dictionary.{0}", ne.DictionaryName)] = true;
            Log.Info("Load dictionary '{0}' OK.", ne.DictionaryName);
        }

        private void OnLoadDictionaryFailure(object sender, GameEventArgs e)
        {
            LoadDictionaryFailureEventArgs ne = (LoadDictionaryFailureEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Error("Can not load dictionary '{0}' from '{1}' with error message '{2}'.", ne.DictionaryName, ne.DictionaryAssetName, ne.ErrorMessage);
        }
    }
}
