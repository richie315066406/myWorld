using GameFramework.Resource;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ProjectZGL
{
	public static class ResourceExtension
	{
		public static void LoadUIItemAsset(this ResourceComponent resource, string UIItemAssetName)
		{
			resource.LoadAsset(AssetUtility.GetUIItemAsset(UIItemAssetName), Constant.AssetPriority.UIFormAsset, new LoadAssetCallbacks(
				(assetName, asset, duration, userData) =>
				{
//					m_LoadedFlag[string.Format("Font.{0}", fontName)] = true;
//					UGuiForm.SetMainFont((Font)asset);

					Log.Info("Load font '{0}' OK.", UIItemAssetName);
				},

				(assetName, status, errorMessage, userData) =>
				{
					Log.Error("Can not load font '{0}' from '{1}' with error message '{2}'.", UIItemAssetName, assetName, errorMessage);
				}));
		}

		public static void LoadBackground(this ResourceComponent resource, string UIBackgroundAssetName)
		{
			resource.LoadAsset(AssetUtility.GetBackgroundAsset(UIBackgroundAssetName), Constant.AssetPriority.UIFormAsset, new LoadAssetCallbacks(
				(assetName, asset, duration, userData) =>
				{
					//					m_LoadedFlag[string.Format("Font.{0}", fontName)] = true;
					//					UGuiForm.SetMainFont((Font)asset);
//					MainForm.ChangeBackgroundImage((Sprite)asset);
					Log.Info("Load Background '{0}' OK.", UIBackgroundAssetName);
				},

				(assetName, status, errorMessage, userData) =>
				{
					Log.Error("Can not load Background '{0}' from '{1}' with error message '{2}'.", UIBackgroundAssetName, assetName, errorMessage);
				}));
		}

	}
}

