using System;
using System.Collections.Generic;
using System.Linq;
using Assets.MeshCalcules.ImplementacionLayer.LocalSkining_NormalRecalcules;
using Assets.Scripts.MeshCalcules.ImplementacionLayer.LocalSkining;
using Assets.Scripts.MeshCalcules.ImplementacionLayer.LocalSkining_NormalRecalcules;
using Assets.Scripts.MeshCalcules.ImplementacionLayer.RecalculeNormals;
using Assets.TValle.MeshCalcules.BeachGirl.Runtime;
using Assets.TValle.MeshCalcules.BeachGirl.Runtime.MeshCalcules;
using Assets.TValle.MeshCalcules.Runtime.ImplementacionLayer.RecalculeNormals;
using Assets.TValle.MeshCalcules.TUpdaters.Runtime;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Scriptables
{
	// Token: 0x0200011E RID: 286
	[CreateAssetMenu(fileName = "NormalRecalculadorBoneMap", menuName = "Objetos/Characters/Normal Recalculador Bone Map")]
	public class NormalRecalculadorBoneMap : MapaSingleton<NormalRecalculadorBoneMap>
	{
		// Token: 0x06000C52 RID: 3154 RVA: 0x000299D4 File Offset: 0x00027BD4
		private void InitDicc()
		{
			if (this.m_dic == null || this.m_dic.Count != this.items.Count)
			{
				this.m_dic = new DiccionaryEnum<NormalRecalculadorBoneMap.Tipo, NormalRecalculadorBoneMap.Info>((NormalRecalculadorBoneMap.Tipo i) => (int)i);
				for (int j = this.items.Count - 1; j >= 0; j--)
				{
					NormalRecalculadorBoneMap.Info info = this.items[j];
					NormalRecalculadorBoneMap.Info info2;
					if (this.m_dic.TryGetValue(info.tipo, out info2))
					{
						Debug.LogWarning("tipo de normal recalculator repetido, " + info.tipo.ToString(), this);
						this.items.RemoveAt(j);
					}
					else
					{
						this.m_dic.Add(info.tipo, info);
					}
				}
			}
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x00029AAC File Offset: 0x00027CAC
		public NormalRecalculadorBoneMap.InfoParametros GetInfoV2(NormalRecalculadorBoneMap.Tipo tipo)
		{
			this.InitDicc();
			NormalRecalculadorBoneMap.Info info;
			if (this.m_dic.TryGetValue(tipo, out info))
			{
				return info.parametrosV2;
			}
			return null;
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x00029AD8 File Offset: 0x00027CD8
		public List<NormalRecalculadorBoneMap.InfoParametros> GetInfosV2(IList<NormalRecalculadorBoneMap.Tipo> tipos)
		{
			List<NormalRecalculadorBoneMap.InfoParametros> list = new List<NormalRecalculadorBoneMap.InfoParametros>();
			foreach (NormalRecalculadorBoneMap.Tipo tipo in tipos)
			{
				NormalRecalculadorBoneMap.InfoParametros infoV = this.GetInfoV2(tipo);
				if (infoV != null)
				{
					list.Add(infoV);
				}
			}
			return list;
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x00029B34 File Offset: 0x00027D34
		public static void AñadirRecalculadoresV2(SkinnedMeshRenderer renderer, List<NormalRecalculadorBoneMap.Tipo> recalculadores)
		{
			NormalRecalculadorBoneMap.ClearRecalculatorsV2(renderer);
			if (recalculadores != null && recalculadores.Count > 0)
			{
				List<NormalRecalculadorBoneMap.InfoParametros> infosV = MapaSingleton<NormalRecalculadorBoneMap>.instance.GetInfosV2(recalculadores);
				NormalRecalculadorBoneMap.AddNormalsRecalculators(renderer, infosV);
			}
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x00029B68 File Offset: 0x00027D68
		public static void AñadirFullMeshRecalculadores(SkinnedMeshRenderer renderer)
		{
			if (renderer == null)
			{
				throw new ArgumentNullException("skrendererin", "renderer null reference.");
			}
			NormalRecalculadorBoneMap.ClearFullMeshRecalculators(renderer);
			Transform transform = renderer.transform.CreateChild("FullMeshNormalRecalculator");
			MeshNormalRecalculatorHybrid meshNormalRecalculatorHybrid = transform.gameObject.AddComponent<MeshNormalRecalculatorHybrid>();
			meshNormalRecalculatorHybrid.customNormalsVGIgnoreV3 = NormalRecalculadorBoneMap.customNormalsVGIgnoreV3;
			meshNormalRecalculatorHybrid.customNormalsVGIgnoreInterceptingV3 = NormalRecalculadorBoneMap.customNormalsVGIgnoreInterceptingV3;
			meshNormalRecalculatorHybrid.calculedNormalsVGIgnoreInterceptingV3 = NormalRecalculadorBoneMap.calculedNormalsVGIgnoreInterceptingV3;
			meshNormalRecalculatorHybrid.calculedNormalsVGIgnoreManyV3 = NormalRecalculadorBoneMap.calculedNormalsVGIgnoreManyV3;
			meshNormalRecalculatorHybrid.calculedNormalsVGExagerate = NormalRecalculadorBoneMap.calculedNormalsVGExagerate;
			transform.gameObject.AddComponent<MeshNormalRecalculatorUpdater>();
			renderer.gameObject.AddComponent<NormalRecalculateModeChanger>();
		}

		// Token: 0x06000C57 RID: 3159 RVA: 0x00029BFC File Offset: 0x00027DFC
		public static void AddNormalsRecalculators(SkinnedMeshRenderer skin, IList<NormalRecalculadorBoneMap.InfoParametros> infos)
		{
			if (skin == null)
			{
				throw new ArgumentNullException("skin", "skin null reference.");
			}
			foreach (NormalRecalculadorBoneMap.InfoParametros infoParametros in infos)
			{
				NormalRecalculadorBoneMap.AddNormalsRecalculator(skin, infoParametros);
			}
		}

		// Token: 0x06000C58 RID: 3160 RVA: 0x00029C60 File Offset: 0x00027E60
		public static void AddNormalsRecalculator(SkinnedMeshRenderer skin, NormalRecalculadorBoneMap.InfoParametros info)
		{
			string text = string.Empty;
			foreach (NormalRecalculadorBoneMap.VertexGroupParametros vertexGroupParametros in info.vertexGroups)
			{
				text = text + vertexGroupParametros.name + "_";
			}
			Transform transform = skin.transform.CreateChild(text);
			MapaSingletonDeFemaleBones mapa = MapaSingleton<MapaSingletonDeFemaleBones>.instance;
			string text2 = mapa.ObtenerNombreDeHueso(info.padreEnComunBone);
			string text3 = mapa.ObtenerNombreDeHueso(info.semiparent.name);
			List<string> list = info.vertexGroups.Select((NormalRecalculadorBoneMap.VertexGroupParametros vgf) => mapa.ObtenerNombreDeHueso(vgf.name)).ToList<string>();
			VertexGroupSkinner vertexGroupSkinner = transform.gameObject.AddComponent<VertexGroupSkinner>();
			vertexGroupSkinner.vertexGroups = list;
			vertexGroupSkinner.semiPadreEnComunBone = text3;
			vertexGroupSkinner.padreEnComunBone = text2;
			vertexGroupSkinner.buscarSemiPadreEnComun = info.buscarPadreEnComun;
			vertexGroupSkinner.buscarPadreEnComun = info.buscarPadreEnComun;
			transform.gameObject.AddComponent<VertexGroupNormalRecalculator>().vertexGroups = list;
			transform.gameObject.AddComponent<NormalRecalculatorLayoutProductor>();
			VertexGroupNormalChanger vertexGroupNormalChanger = transform.gameObject.AddComponent<VertexGroupNormalChanger>();
			vertexGroupNormalChanger.soloSiMatrixCambiaron = info.soloSiMatrixCambiaron;
			vertexGroupNormalChanger.soloSiEsVisible = info.soloSiEsVisible;
			vertexGroupNormalChanger.semiBoneConfig = info.semiparent.config;
			vertexGroupNormalChanger.UserBonesConfig = info.vertexGroups.Select((NormalRecalculadorBoneMap.VertexGroupParametros c) => c.config).ToArray<VertexGroupNormalChanger.ConfigDeUserBone>();
			transform.gameObject.AddComponent<VertexGroupNormalChangerUpdater>();
			if (info.offsetWeightsWithScale.usar)
			{
				NormalOffsetWeightsPorScale normalOffsetWeightsPorScale = transform.gameObject.AddComponent<NormalOffsetWeightsPorScale>();
				normalOffsetWeightsPorScale.weight = info.offsetWeightsWithScale.weight;
				normalOffsetWeightsPorScale.scalerBone = mapa.ObtenerNombreDeHueso(info.offsetWeightsWithScale.scalerBone);
				normalOffsetWeightsPorScale.config = info.offsetWeightsWithScale.config;
			}
		}

		// Token: 0x06000C59 RID: 3161 RVA: 0x00029E30 File Offset: 0x00028030
		public static void ClearRecalculatorsV2(SkinnedMeshRenderer skin)
		{
			List<GameObject> list = new List<GameObject>();
			VertexGroupNormalChanger[] componentsInChildren = skin.GetComponentsInChildren<VertexGroupNormalChanger>();
			list.AddRange(componentsInChildren.Select((VertexGroupNormalChanger t) => t.gameObject));
			foreach (GameObject gameObject in list)
			{
				if (skin.gameObject == gameObject)
				{
					Debug.LogError("No se puede borrar recalculador en :" + gameObject.name + ", recalculadores NO pueden estar en el skin", gameObject);
				}
				else if (Application.isPlaying)
				{
					Object.Destroy(gameObject);
				}
				else
				{
					Object.DestroyImmediate(gameObject);
				}
			}
		}

		// Token: 0x06000C5A RID: 3162 RVA: 0x00029EF0 File Offset: 0x000280F0
		public static void ClearFullMeshRecalculators(SkinnedMeshRenderer skin)
		{
			List<GameObject> list = new List<GameObject>();
			MeshNormalRecalculatorHybrid[] componentsInChildren = skin.GetComponentsInChildren<MeshNormalRecalculatorHybrid>();
			list.AddRange(componentsInChildren.Select((MeshNormalRecalculatorHybrid t) => t.gameObject));
			foreach (GameObject gameObject in list)
			{
				if (skin.gameObject == gameObject)
				{
					Debug.LogError("No se puede borrar recalculador en :" + gameObject.name + ", recalculadores NO pueden estar en el skin", gameObject);
				}
				else if (Application.isPlaying)
				{
					Object.Destroy(gameObject);
				}
				else
				{
					Object.DestroyImmediate(gameObject);
				}
			}
		}

		// Token: 0x06000C5B RID: 3163 RVA: 0x00029FB0 File Offset: 0x000281B0
		protected override void OnJuegoLanzado()
		{
		}

		// Token: 0x040006A3 RID: 1699
		public static readonly List<string> customNormalsVGIgnoreV3 = new string[] { "DEF_PechoBase.R", "DEF_PechoBase.L" }.ToList<string>();

		// Token: 0x040006A4 RID: 1700
		public static readonly List<MeshNormalRecalculatorHybrid.IgnorarVgMaskingNames> customNormalsVGIgnoreInterceptingV3 = new List<MeshNormalRecalculatorHybrid.IgnorarVgMaskingNames>();

		// Token: 0x040006A5 RID: 1701
		public static readonly List<MeshNormalRecalculatorHybrid.IgnorarVgMaskingNames> calculedNormalsVGIgnoreInterceptingV3 = new List<MeshNormalRecalculatorHybrid.IgnorarVgMaskingNames>
		{
			new MeshNormalRecalculatorHybrid.IgnorarVgMaskingNames
			{
				mains = new string[] { "CC_Base_UpperarmTwist01.R" },
				mask = new string[0]
			},
			new MeshNormalRecalculatorHybrid.IgnorarVgMaskingNames
			{
				mains = new string[] { "CC_Base_UpperarmTwist01.L" },
				mask = new string[0]
			}
		};

		// Token: 0x040006A6 RID: 1702
		public static readonly List<MeshNormalRecalculatorHybrid.IgnorarVgNames> calculedNormalsVGIgnoreManyV3 = new List<MeshNormalRecalculatorHybrid.IgnorarVgNames>
		{
			new MeshNormalRecalculatorHybrid.IgnorarVgNames
			{
				mains = new string[]
				{
					"CC_Base_Head", "CC_Base_JawRoot", "Labio_Up_DEF.R", "Labio_Up_DEF.L", "Labio_Down_DEF.L", "Labio_Down_DEF.R", "Labio_Up_DEF.L.001", "Labio_Up_DEF.R.001", "Labio_Down_DEF.L.001", "Labio_Down_DEF.R.001",
					"Labio_Up_Out_DEF.R", "Labio_Up_Out_DEF.L", "Labio_Down_Out_DEF.R", "Labio_Down_Out_DEF.L", "Labio_Up_Out_DEF.Center", "Labio_Down_Out_DEF.Center", "Labio_Out_DEF.L", "Labio_Out_DEF.R", "TValle_NarizSkin_DEF_SCALER", "TValle_NarizSkin_DEF_STRETCHED",
					"DEF_SkinOjoCara.L", "DEF_SkinOjoCara.R", "DEF_SkinOjoParpado_Inf.L", "DEF_SkinOjoParpado_Inf.R", "DEF_SkinOjoParpado_Sup.L", "DEF_SkinOjoParpado_Sup.R"
				}
			},
			new MeshNormalRecalculatorHybrid.IgnorarVgNames
			{
				mains = new string[] { "CC_Base_UpperarmTwist02.R", "CC_Base_UpperarmTwist02.L" }
			}
		};

		// Token: 0x040006A7 RID: 1703
		public static readonly List<string> calculedNormalsVGExagerate = new string[0].ToList<string>();

		// Token: 0x040006A8 RID: 1704
		private DiccionaryEnum<NormalRecalculadorBoneMap.Tipo, NormalRecalculadorBoneMap.Info> m_dic;

		// Token: 0x040006A9 RID: 1705
		public List<NormalRecalculadorBoneMap.Info> items = new List<NormalRecalculadorBoneMap.Info>();

		// Token: 0x020001F4 RID: 500
		[Serializable]
		public class Info
		{
			// Token: 0x04000AD1 RID: 2769
			public NormalRecalculadorBoneMap.Tipo tipo;

			// Token: 0x04000AD2 RID: 2770
			public NormalRecalculadorBoneMap.InfoParametros parametrosV2 = new NormalRecalculadorBoneMap.InfoParametros();
		}

		// Token: 0x020001F5 RID: 501
		[Serializable]
		public class InfoParametros
		{
			// Token: 0x04000AD3 RID: 2771
			[Header("hace modificaciones en el mesh SOLO si las matrices de los bones especificos cambiaron")]
			public bool soloSiMatrixCambiaron = true;

			// Token: 0x04000AD4 RID: 2772
			[Header("hace modificaciones en el mesh SOLO si es visible")]
			public bool soloSiEsVisible = true;

			// Token: 0x04000AD5 RID: 2773
			[Header("Buscar config")]
			public bool buscarSemiPadreEnComun;

			// Token: 0x04000AD6 RID: 2774
			public bool buscarPadreEnComun;

			// Token: 0x04000AD7 RID: 2775
			[Header("Parent config")]
			[StringSelector(typeof(MapaSingletonDeFemaleBones), "fieldNamesEditor")]
			public string padreEnComunBone = string.Empty;

			// Token: 0x04000AD8 RID: 2776
			[Header("SemiParents config")]
			public NormalRecalculadorBoneMap.BoneParametros semiparent = new NormalRecalculadorBoneMap.BoneParametros();

			// Token: 0x04000AD9 RID: 2777
			[Header("vertexGroups Config config")]
			public NormalRecalculadorBoneMap.VertexGroupParametros[] vertexGroups;

			// Token: 0x04000ADA RID: 2778
			[Header("Extra config: Offset Weights With Scale")]
			public NormalRecalculadorBoneMap.NormalOffsetWeightsWithScale offsetWeightsWithScale = new NormalRecalculadorBoneMap.NormalOffsetWeightsWithScale();
		}

		// Token: 0x020001F6 RID: 502
		[Serializable]
		public class NormalOffsetWeightsWithScale
		{
			// Token: 0x04000ADB RID: 2779
			public bool usar;

			// Token: 0x04000ADC RID: 2780
			public float weight = 1f;

			// Token: 0x04000ADD RID: 2781
			[StringSelector(typeof(MapaSingletonDeFemaleBones), "fieldNamesEditor")]
			public string scalerBone;

			// Token: 0x04000ADE RID: 2782
			public NormalOffsetWeightsPorScale.Config config = new NormalOffsetWeightsPorScale.Config();
		}

		// Token: 0x020001F7 RID: 503
		[Serializable]
		public class BoneParametros : NormalRecalculadorBoneMap.BoneParametrosBase<VertexGroupNormalChanger.ConfigDeBone>
		{
			// Token: 0x1700052F RID: 1327
			// (get) Token: 0x06000FCD RID: 4045 RVA: 0x000353B2 File Offset: 0x000335B2
			public override VertexGroupNormalChanger.ConfigDeBone config
			{
				get
				{
					return this.m_config;
				}
			}

			// Token: 0x17000530 RID: 1328
			// (get) Token: 0x06000FCE RID: 4046 RVA: 0x000353BA File Offset: 0x000335BA
			public override string name
			{
				get
				{
					return this.m_bone;
				}
			}

			// Token: 0x04000ADF RID: 2783
			[SerializeField]
			[StringSelector(typeof(MapaSingletonDeFemaleBones), "fieldNamesEditor")]
			private string m_bone;

			// Token: 0x04000AE0 RID: 2784
			[SerializeField]
			private VertexGroupNormalChanger.ConfigDeBone m_config = new VertexGroupNormalChanger.ConfigDeBone();
		}

		// Token: 0x020001F8 RID: 504
		[Serializable]
		public class VertexGroupParametros : NormalRecalculadorBoneMap.BoneParametrosBase<VertexGroupNormalChanger.ConfigDeUserBone>
		{
			// Token: 0x17000531 RID: 1329
			// (get) Token: 0x06000FD0 RID: 4048 RVA: 0x000353D5 File Offset: 0x000335D5
			public override VertexGroupNormalChanger.ConfigDeUserBone config
			{
				get
				{
					return this.m_config;
				}
			}

			// Token: 0x17000532 RID: 1330
			// (get) Token: 0x06000FD1 RID: 4049 RVA: 0x000353DD File Offset: 0x000335DD
			public override string name
			{
				get
				{
					return this.m_vertexGroup;
				}
			}

			// Token: 0x04000AE1 RID: 2785
			[SerializeField]
			[StringSelector(typeof(MapaSingletonDeFemaleBones), "fieldNamesEditor")]
			private string m_vertexGroup;

			// Token: 0x04000AE2 RID: 2786
			[SerializeField]
			private VertexGroupNormalChanger.ConfigDeUserBone m_config = new VertexGroupNormalChanger.ConfigDeUserBone();
		}

		// Token: 0x020001F9 RID: 505
		public abstract class BoneParametrosBase<T> where T : VertexGroupNormalChanger.ConfigDeBone
		{
			// Token: 0x17000533 RID: 1331
			// (get) Token: 0x06000FD3 RID: 4051
			public abstract string name { get; }

			// Token: 0x17000534 RID: 1332
			// (get) Token: 0x06000FD4 RID: 4052
			public abstract T config { get; }
		}

		// Token: 0x020001FA RID: 506
		public enum Tipo
		{
			// Token: 0x04000AE4 RID: 2788
			None,
			// Token: 0x04000AE5 RID: 2789
			senoR,
			// Token: 0x04000AE6 RID: 2790
			senoL,
			// Token: 0x04000AE7 RID: 2791
			anusApertureR,
			// Token: 0x04000AE8 RID: 2792
			anusApertureL,
			// Token: 0x04000AE9 RID: 2793
			nalgaR,
			// Token: 0x04000AEA RID: 2794
			nalgaL
		}
	}
}
