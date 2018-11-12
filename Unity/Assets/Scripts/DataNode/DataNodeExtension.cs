using GameFramework;
using GameFramework.DataNode;
using GameFramework.DataTable;
using System;
using UnityGameFramework.Runtime;

namespace ProjectZGL
{
    public static class DataNodeExtension
    {
        public static void SetGameInfo(this DataNodeComponent dataNode)
        {
            IDataNode gameNode = dataNode.GetOrAddNode(Constant.DataNode.GameNode);
            GameInfo gameInfo = new GameInfo(){
                NowSite = 1,
                NowTime = 0
            };
            dataNode.SetGameInfo(gameInfo);
            dataNode.SetData<VarInt>("GameTest",99,gameNode);
        }
        //设置Game信息
        public static void SetGameInfo(this DataNodeComponent dataNode, GameInfo game)
        {
            IDataNode gameNode = dataNode.GetOrAddNode(Constant.DataNode.GameNode);
            dataNode.SetData<VarGameInfo>(Constant.DataNode.GameInfo, game, gameNode);
        }
        //获取当前时间
        public static int GetNowTime(this DataNodeComponent dataNode)
        {
            return dataNode.GetGameInfo().NowTime;
        }
        //获取当前地点
        public static SiteInfo GetNowSite(this DataNodeComponent dataNode)
        {
            int nowSiteId = dataNode.GetGameInfo().NowSite;
            return dataNode.GetSiteById(nowSiteId);
        }
        //获取Game信息
        public static GameInfo GetGameInfo(this DataNodeComponent dataNode)
        {
            IDataNode gameNode = dataNode.GetNode(Constant.DataNode.GameNode);
            if (gameNode == null)
            {
                Log.Error("gameNode data is empty");
                return null;
            }
            GameInfo gameInfo = dataNode.GetData<VarGameInfo>(Constant.DataNode.GameInfo, gameNode);
            if (gameInfo == null)
            {
                Log.Error("playerInfo data is empty");
                return null;
            }
            return gameInfo;
        }

        //设置玩家信息
        public static void SetPlayerInfo(this DataNodeComponent dataNode, PlayerInfo player)
        {
            IDataNode playerNode = dataNode.GetOrAddNode(Constant.DataNode.PlayerNode);
            dataNode.SetData<VarPlayerInfo>(Constant.DataNode.PlayerInfo, player, playerNode);
            GameEntry.Event.Fire(dataNode,new PlayerStateChangedEventArgs(player));
        }
        //获取玩家信息
        public static PlayerInfo GetPlayerInfo(this DataNodeComponent dataNode)
        {
            IDataNode playerNode = dataNode.GetNode(Constant.DataNode.PlayerNode);
            if (playerNode == null)
            {
                Log.Error("Player Node is empty");
                return null;
            }
            PlayerInfo playerInfo = dataNode.GetData<VarPlayerInfo>(Constant.DataNode.PlayerInfo, playerNode);
            if (playerInfo == null)
            {
                Log.Error("Player Info is empty");
                return null;
            }
            return playerInfo;
        }

        //根据配置表加载全部地点
        public static void LoadAllSiteByTable(this DataNodeComponent dataNode)
        {
            IDataNode siteNode = dataNode.GetOrAddNode(Constant.DataNode.SiteList);
            IDataTable<DRSite> dtSite = GameEntry.DataTable.GetDataTable<DRSite>();
            DRSite[] drSites = dtSite.GetAllDataRows();
            foreach (DRSite drSite in drSites)
            {
                dataNode.SetData<VarSiteInfo>(drSite.Id.ToString(), new SiteInfo(drSite.Id), siteNode);
            }
        }

        //根据ID获取地点信息
        public static SiteInfo GetSiteById(this DataNodeComponent dataNode, int siteId)
        {
            IDataNode siteNode = dataNode.GetNode(Constant.DataNode.SiteList);
            if (siteNode == null)
            {
                dataNode.LoadAllSiteByTable();
                siteNode = dataNode.GetNode(Constant.DataNode.SiteList);
            }
            return dataNode.GetData<VarSiteInfo>(siteId.ToString(), siteNode);
        }
    }
}
