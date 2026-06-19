using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Tools.Runtime.Moddding.Clothing.Maps;
using Assets._ReusableScripts.Modding.Singletones;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x02000106 RID: 262
	[ProveedorPiezasDeRopaID("ids", "labels")]
	public sealed class RopaParaAvatarUnificado : RopaParaAvatarBase<RopaParaAvatarUnificado>
	{
		// Token: 0x06000668 RID: 1640 RVA: 0x0001EBA0 File Offset: 0x0001CDA0
		public string ConvertirID(int ID)
		{
			string text;
			if (!this.m_conversorDeIDs.TryGetValue(ID, out text))
			{
				Debug.LogWarning("no se pudo convertir id antigua: " + ID.ToString() + " a id nueva");
				return null;
			}
			return text;
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x0001EBDB File Offset: 0x0001CDDB
		public void InyectMap(MapaDeRopa map)
		{
			if (map == null)
			{
				throw new ArgumentNullException("map", "map null reference.");
			}
			this.m_mapas.Add(map);
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x0001EC02 File Offset: 0x0001CE02
		protected override IEnumerator PreInitData()
		{
			if (!this.m_loadMods)
			{
				yield break;
			}
			if (Singleton<LoadingPanel>.IsInScene)
			{
				this.m_hideLoadingPanel = Singleton<LoadingPanel>.instance.hidingModificable.ObtenerModificadorNotNull(this);
				this.m_hideLoadingPanel.valor.valor = false;
				Singleton<LoadingPanel>.instance.nextUserText = "Loading Mods...";
			}
			Singleton<CustomScriptsModsLoader>.TryIniciar();
			yield return ClothingModsLoader.LoadModsRutine(delegate(ClothingItemMap[] cmaps, MaterialMap[] mmaps, MapaDeRopa r, MapaDeMaterialesParaRopa m)
			{
				this.m_loadedClothingMaps = cmaps;
				this.m_loadedMaterialMaps = mmaps;
				this.m_moddingRopaMap = r;
				this.m_moddingMaterialMap = m;
			});
			base.FixCubreAndSex(this.m_moddingRopaMap);
			this.InyectMap(this.m_moddingRopaMap);
			AsyncSingleton<MaterialesParaRopa>.inyectableDataInstance.InyectMap(this.m_moddingMaterialMap);
			if (this.m_hideLoadingPanel != null)
			{
				this.m_hideLoadingPanel.valor.valor = true;
			}
			yield break;
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x0001EC11 File Offset: 0x0001CE11
		protected override void OnDestroyed(bool wasInitiated)
		{
			base.OnDestroyed(wasInitiated);
			ClothingModsLoader.DestroyModdingMap(ref this.m_moddingRopaMap);
			ClothingModsLoader.DestroyModdingMap(ref this.m_moddingMaterialMap);
		}

		// Token: 0x0400044C RID: 1100
		[SerializeField]
		private bool m_loadMods = true;

		// Token: 0x0400044D RID: 1101
		[SerializeField]
		private IntKeyStringValueDictionary m_conversorDeIDs = new IntKeyStringValueDictionary();

		// Token: 0x0400044E RID: 1102
		[SerializeReference]
		private ModificadorDeBool m_hideLoadingPanel;

		// Token: 0x0400044F RID: 1103
		[SerializeField]
		[ReadOnlyUI]
		private MapaDeRopa m_moddingRopaMap;

		// Token: 0x04000450 RID: 1104
		[SerializeField]
		[ReadOnlyUI]
		private MapaDeMaterialesParaRopa m_moddingMaterialMap;

		// Token: 0x04000451 RID: 1105
		[SerializeField]
		[ReadOnlyUI]
		private ClothingItemMap[] m_loadedClothingMaps;

		// Token: 0x04000452 RID: 1106
		[SerializeField]
		[ReadOnlyUI]
		private MaterialMap[] m_loadedMaterialMaps;
	}
}
