using System;
using System.Collections.Generic;
using Assets.Scripts.MeshCalcules.ImplementacionLayer.Skinning;
using Assets.Scripts.MeshCalcules.ImplementacionLayer.WorkingMeshCalcules.Semis;
using Assets.Scripts.MeshCalcules.ImplementacionLayer.WorkingMeshCalcules.Semis.Abstracts;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Skins;
using Assets.TValle.MeshCalcules.Runtime.ImplementacionLayer.WorkingMeshCalcules;
using Assets.TValle.MeshCalcules.TUpdaters.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Scriptables;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Mapas
{
	// Token: 0x0200013B RID: 315
	[Serializable]
	public class SkinConfig
	{
		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x06000D93 RID: 3475 RVA: 0x0002EF94 File Offset: 0x0002D194
		public static SkinConfig nothing
		{
			get
			{
				return new SkinConfig
				{
					clonarMateriales = false,
					copiaShapesDe = new List<string>(),
					copiaShapesDeMale = new List<string>(),
					recalculadores = new List<NormalRecalculadorBoneMap.Tipo>(),
					usarTessellation = false,
					canBeBakedIntoACollider = false,
					usarVertExmotion = false,
					canTriangleSurfaceAttachment = false,
					forceNoNormalRecalculation = true
				};
			}
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x0002EFF4 File Offset: 0x0002D1F4
		public static void AñadirComponentesExtras(SkinnedMeshRenderer renderer, Animator source, SkinConfig config, ICharacterSkinMeshConfig charConfig = null, object extraData = null, Transform ownArmature = null)
		{
			Singleton<ConfiguradorDeSkins>.instance.AddComponentesExtras(renderer, source, config, charConfig, extraData, ownArmature);
			if ((charConfig == null && config.usarTessellation) || (config.usarTessellation && ((charConfig != null) ? new bool?(charConfig.arreglaNormalesMagnitud) : null).GetValueOrDefault()))
			{
				if (GraphicsSettings.renderPipelineAsset == null)
				{
					renderer.GetComponentNotNull<BaseWorkingMeshSemiWritable, SkinnedWorkingMesh>();
					renderer.GetComponentNotNull<WorkingMeshUpdater>();
					renderer.GetComponentNotNull<MeshSkeleton>();
					renderer.GetComponentNotNull<ShapeKeysWeightsGetter>();
					SkinConfig.AddNormalsFixerV2Updater(SkinConfig.AddNormalsFixerV2(renderer));
				}
				else
				{
					Debug.LogWarning("no es necesario arreglar normales magnitud en con renderPipelineAsset", renderer);
				}
			}
			if ((charConfig == null && config.copiaShapesDe.Count > 0) || (config.copiaShapesDe.Count > 0 && ((charConfig != null) ? new bool?(charConfig.copiaShapeKeys) : null).GetValueOrDefault()))
			{
				SkinConfig.AddCopiadores(renderer, source, config.copiaShapesDe);
			}
			if ((charConfig == null && config.copiaShapesDeMale.Count > 0) || (config.copiaShapesDeMale.Count > 0 && ((charConfig != null) ? new bool?(charConfig.copiaShapeKeys) : null).GetValueOrDefault()))
			{
				SkinConfig.AddCopiadores(renderer, source, config.copiaShapesDeMale);
			}
		}

		// Token: 0x06000D95 RID: 3477 RVA: 0x0002F129 File Offset: 0x0002D329
		public static SkinnerNormalsMagnitudesJobedLite AddNormalsFixerV2(SkinnedMeshRenderer target)
		{
			return target.transform.CreateChild("NormalsMagnitudesFixer").GetComponentNotNull<SkinnerNormalsMagnitudesJobedLite>();
		}

		// Token: 0x06000D96 RID: 3478 RVA: 0x0002F140 File Offset: 0x0002D340
		public static SkinnerUpdater AddNormalsFixerV2Updater(SkinnerNormalsMagnitudesJobedLite target)
		{
			return target.GetComponentNotNull<SkinnerUpdater>();
		}

		// Token: 0x06000D97 RID: 3479 RVA: 0x0002F148 File Offset: 0x0002D348
		public static void AddCopiadores(SkinnedMeshRenderer target, Animator source, IList<string> skinSourcesNames)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target", "target null reference.");
			}
			target.RemoveComponents<GenericShapeKeyCopier>();
			if (source == null)
			{
				throw new ArgumentNullException("anim", "anim null reference.");
			}
			foreach (string text in skinSourcesNames)
			{
				SkinConfig.AddCopiador(target, source, text);
			}
		}

		// Token: 0x06000D98 RID: 3480 RVA: 0x0002F1CC File Offset: 0x0002D3CC
		private static void AddCopiador(SkinnedMeshRenderer target, Animator source, string skinSourceNames)
		{
			if (source == null)
			{
				throw new ArgumentNullException("anim", "anim null reference.");
			}
			string text = MapaSingleton<MapaSingletonDeMainSkins>.instance.ObtenerValorDeField(skinSourceNames);
			Transform transform = source.transform.FindDeepChild(text, true);
			if (transform == null)
			{
				transform = source.transform.FindDeepChild(skinSourceNames, true);
			}
			if (transform == null)
			{
				throw new ArgumentNullException("skinTRans", "skinTRans null reference.");
			}
			SkinnedMeshRenderer component = transform.GetComponent<SkinnedMeshRenderer>();
			if (component == null)
			{
				throw new ArgumentNullException("sourceSkinnedMeshRenderer", "sourceSkinnedMeshRenderer null reference.");
			}
			GenericShapeKeyCopier.Add(target, component);
		}

		// Token: 0x04000798 RID: 1944
		public bool clonarMateriales;

		// Token: 0x04000799 RID: 1945
		public bool usarTessellation;

		// Token: 0x0400079A RID: 1946
		public bool usarVertExmotion;

		// Token: 0x0400079B RID: 1947
		public bool usarVertExmotionVB = true;

		// Token: 0x0400079C RID: 1948
		public bool canBeBakedIntoACollider;

		// Token: 0x0400079D RID: 1949
		public bool canTriangleSurfaceAttachment = true;

		// Token: 0x0400079E RID: 1950
		[StringSelector(typeof(MapaSingletonDeMainSkins), "fieldsEditor")]
		public List<string> copiaShapesDe = new List<string>();

		// Token: 0x0400079F RID: 1951
		[StringSelector(typeof(MapaSingletonDeMaleMainSkins), "fieldsEditor")]
		public List<string> copiaShapesDeMale = new List<string>();

		// Token: 0x040007A0 RID: 1952
		public bool forceNoNormalRecalculation;

		// Token: 0x040007A1 RID: 1953
		[CoolArrayItem]
		public List<NormalRecalculadorBoneMap.Tipo> recalculadores = new List<NormalRecalculadorBoneMap.Tipo>();
	}
}
