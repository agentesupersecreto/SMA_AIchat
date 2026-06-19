using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Materiales.Mapas;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Mapas
{
	// Token: 0x0200013A RID: 314
	[CreateAssetMenu(fileName = "MapaSingletonDeFemaleMainSkinsConfig", menuName = "Objetos/Characters/Mapa Singleton De Main Skins Config ")]
	public class MapaSingletonDeFemaleMainSkinsConfig : MapaSingleton<MapaSingletonDeFemaleMainSkinsConfig>
	{
		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x06000D8E RID: 3470 RVA: 0x0002EEAE File Offset: 0x0002D0AE
		public List<MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig> mainSkins
		{
			get
			{
				if (this.m_mainSkins == null || this.m_mainSkins.Count == 0)
				{
					this.Init();
				}
				return this.m_mainSkins;
			}
		}

		// Token: 0x06000D8F RID: 3471 RVA: 0x0002EED4 File Offset: 0x0002D0D4
		private void Init()
		{
			this.m_mainSkins = new List<MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig>();
			this.Add(this.head);
			this.Add(this.body);
			this.Add(this.scalp);
			this.Add(this.cejas);
			this.Add(this.ojos);
			this.Add(this.lengua);
			this.Add(this.dientes);
			this.Add(this.pesones);
			this.Add(this.xRayPelvis);
			this.Add(this.xRayBoca);
			this.Add(this.pubes);
		}

		// Token: 0x06000D90 RID: 3472 RVA: 0x0002EF70 File Offset: 0x0002D170
		private void Add(MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig msk)
		{
			if (!msk.esValido)
			{
				return;
			}
			this.m_mainSkins.Add(msk);
		}

		// Token: 0x06000D91 RID: 3473 RVA: 0x0002EF87 File Offset: 0x0002D187
		protected override void OnJuegoLanzado()
		{
		}

		// Token: 0x0400078A RID: 1930
		[NonSerialized]
		private List<MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig> m_mainSkins;

		// Token: 0x0400078B RID: 1931
		public MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig head;

		// Token: 0x0400078C RID: 1932
		public MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig body;

		// Token: 0x0400078D RID: 1933
		public MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig scalp;

		// Token: 0x0400078E RID: 1934
		public MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig cejas;

		// Token: 0x0400078F RID: 1935
		[Obsolete("", true)]
		[NonSerialized]
		public MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig cejaR;

		// Token: 0x04000790 RID: 1936
		[Obsolete("", true)]
		[NonSerialized]
		public MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig cejaL;

		// Token: 0x04000791 RID: 1937
		public MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig ojos;

		// Token: 0x04000792 RID: 1938
		public MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig lengua;

		// Token: 0x04000793 RID: 1939
		public MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig dientes;

		// Token: 0x04000794 RID: 1940
		public MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig pesones;

		// Token: 0x04000795 RID: 1941
		public MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig xRayPelvis;

		// Token: 0x04000796 RID: 1942
		public MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig xRayBoca;

		// Token: 0x04000797 RID: 1943
		public MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig pubes;

		// Token: 0x0200020B RID: 523
		[Serializable]
		public class MainSkinConfig : SkinConfig
		{
			// Token: 0x06001005 RID: 4101 RVA: 0x00035A18 File Offset: 0x00033C18
			public string ObtenerSkinName()
			{
				return MapaSingleton<MapaSingletonDeMainSkins>.instance.ObtenerValorDeField(this.m_name);
			}

			// Token: 0x17000542 RID: 1346
			// (get) Token: 0x06001006 RID: 4102 RVA: 0x00035A2A File Offset: 0x00033C2A
			public bool esValido
			{
				get
				{
					return !string.IsNullOrEmpty(this.m_name);
				}
			}

			// Token: 0x04000B2A RID: 2858
			[SerializeField]
			[StringSelector(typeof(MapaSingletonDeMainSkins), "fieldsEditor")]
			private string m_name;

			// Token: 0x04000B2B RID: 2859
			[StringSelector(typeof(MapaSingletonDeFemaleMateriales), "fieldsEditor")]
			public List<string> ignorarTessellationEn = new List<string>();

			// Token: 0x04000B2C RID: 2860
			public float phongSmoothingMod = 1f;

			// Token: 0x04000B2D RID: 2861
			public MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig.LayerConfig layerConfig = new MapaSingletonDeFemaleMainSkinsConfig.MainSkinConfig.LayerConfig();

			// Token: 0x02000261 RID: 609
			[Serializable]
			public class LayerConfig
			{
				// Token: 0x04000B55 RID: 2901
				public bool overrideLayer;

				// Token: 0x04000B56 RID: 2902
				public int overridingLayer;
			}
		}
	}
}
