using GameFramework;
using GameFramework.DataTable;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace ProjectZGL
{
    public static class EntityExtension
    {
        // 关于 EntityId 的约定：
        // 0 为无效
        // 正值用于和服务器通信的实体（如玩家角色、NPC、怪等，服务器只产生正值）
        // 负值用于本地生成的临时实体（如特效、FakeObject等）
        private static int s_SerialId = 0;

        public static Entity GetGameEntity(this EntityComponent entityComponent, int entityId)
        {
            UnityGameFramework.Runtime.Entity entity = entityComponent.GetEntity(entityId);
            if (entity == null)
            {
                return null;
            }

            return (Entity)entity.Logic;
        }

        public static void HideEntity(this EntityComponent entityComponent, Entity entity)
        {
            entityComponent.HideEntity(entity.Entity);
        }

        public static void AttachEntity(this EntityComponent entityComponent, Entity entity, int ownerId, string parentTransformPath = null, object userData = null)
        {
            entityComponent.AttachEntity(entity.Entity, ownerId, parentTransformPath, userData);
        }

        public static void ShowMyCharacter(this EntityComponent entityComponent, MyCharacterData data)
        {
            entityComponent.ShowEntity(typeof(MyCharacter), "Character", Constant.AssetPriority.MyAircraftAsset, data);
        }

        public static void ShowAllSite(this EntityComponent entityComponent)
        {
            IDataTable<DRSite> dtSite = GameEntry.DataTable.GetDataTable<DRSite>();
            DRSite[] dRSites = dtSite.GetAllDataRows();
            foreach (var dRSite in dRSites)
            {
                entityComponent.ShowSite(new SiteData(dRSite.Id,2){

                });
            }
        }

        public static void ShowSite(this EntityComponent entityComponent, SiteData data)
        {
            entityComponent.ShowEntity(typeof(Site), "Site", Constant.AssetPriority.MyAircraftAsset, data);
        }

        public static void GetMyCharacter(this EntityComponent entityComponent)
        {
            entityComponent.GetEntity(-1);
            //		    entityComponent.ShowEntity(typeof(MyCharacter), "Character", Constant.AssetPriority.MyAircraftAsset, data);
        }

		/// <summary>
		/// 生成网格地图
		/// </summary>
		/// <param name="data">CellData</param>
		/// <param name="x">宽</param>
		/// <param name="y">高</param>
		/// <param name="generatorType">生成类型</param>
	    public static void CreateCellGrid(this EntityComponent entityComponent, CellData data, int x, int y,
		    GridGeneratorType generatorType)
	    {
		    switch (generatorType)
		    {
			    case GridGeneratorType.RectangularHexGrid:
				    entityComponent.RectangularHexGridGenerator((HexagonData)data, x, y);
				    break;
			}

		    Log.Info("CreateCellGrid");
	    }

		/// <summary>
		/// 生成网格地图
		/// </summary>
		/// <param name="data">CellData</param>
		/// <param name="x">半径</param>
		/// <param name="generatorType">生成类型</param>
		public static void CreateCellGrid(this EntityComponent entityComponent, CellData data, int x, GridGeneratorType generatorType)
	    {

	    }

        public static void ShowEffect(this EntityComponent entityComponent, EffectData data)
        {
            entityComponent.ShowEntity(typeof(Effect), "Effect", Constant.AssetPriority.EffectAsset, data);
        }

        private static void ShowEntity(this EntityComponent entityComponent, Type logicType, string entityGroup, int priority, EntityData data)
        {
            if (data == null)
            {
                Log.Warning("Data is invalid.");
                return;
            }

            IDataTable<DREntity> dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            DREntity drEntity = dtEntity.GetDataRow(data.TypeId);
            if (drEntity == null)
            {
                Log.Warning("Can not load entity id '{0}' from data table.", data.TypeId.ToString());
                return;
            }

            entityComponent.ShowEntity(data.Id, logicType, AssetUtility.GetEntityAsset(drEntity.AssetName), entityGroup, priority, data);
        }

        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return --s_SerialId;
        }

	    private static void RectangularHexGridGenerator(this EntityComponent entityComponent, HexagonData data, int height, int width)
	    {
		    HexGridType hexGridType = width % 2 == 0 ? HexGridType.even_q : HexGridType.odd_q;

		    for (int i = 0; i < height; i++)
		    {
			    for (int j = 0; j < width; j++)
			    {
				    data.Position = new Vector3(i, j);
					entityComponent.ShowEntity(typeof(Hexagon), "Cell", Constant.AssetPriority.AircraftAsset, data);
				}
		    }
		    Log.Info("RectangularHexGridGenerator");
		}
	}
}
