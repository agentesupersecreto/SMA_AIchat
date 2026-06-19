using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.VertExmotions.Runtime.Scripts;
using Assets.TValle.BeachGirl.VertExmotions.Runtime.Scripts.Updaters;
using Assets._ReusableScripts.CuchiCuchi.Chars;
using Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Skins.Globales;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Kalagaan;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Controlladores.Pieles
{
	// Token: 0x02000029 RID: 41
	public abstract class ControlladorDeSemenParaInternalHole : AplicableBehaviour
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000C3 RID: 195
		public abstract ControlladorDeSemenParaInternalHole.Tipo tipo { get; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x000063A1 File Offset: 0x000045A1
		public float w
		{
			get
			{
				return this.m_currentW;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x000063A9 File Offset: 0x000045A9
		public int skinIndex
		{
			get
			{
				return this.m_skinIndex;
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000063B4 File Offset: 0x000045B4
		protected override void AwakeUnityEvent()
		{
			this.m_ShaderID = Shader.PropertyToID("_AlphaCutoff");
			base.AwakeUnityEvent();
			this.m_Internals = base.GetComponentInParent<HoleInternal>();
			if (this.m_Internals == null)
			{
				throw new ArgumentNullException("m_Internals", "m_Internals null reference.");
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00006401 File Offset: 0x00004601
		public void SetSkinIndex(int skinIndex)
		{
			this.Clear();
			this.m_skinIndex = skinIndex;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00006410 File Offset: 0x00004610
		public bool TryLoad()
		{
			if (!base.isAwaken)
			{
				base.ManualAwake();
			}
			if (this.m_skinIndex < 0)
			{
				return false;
			}
			if (this.m_instance != null && this.m_semenMaterialInstance != null)
			{
				return true;
			}
			this.ReLoad();
			return true;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00006450 File Offset: 0x00004650
		public void ReLoad()
		{
			int skinIndex = this.m_skinIndex;
			this.Clear();
			this.m_skinIndex = skinIndex;
			if (this.m_skinIndex < 0)
			{
				return;
			}
			ControlladorDeSemenParaInternalHole.Tipo tipo = this.tipo;
			SkinnedMeshRenderer skinnedMeshRenderer;
			if (tipo != ControlladorDeSemenParaInternalHole.Tipo.vag)
			{
				if (tipo != ControlladorDeSemenParaInternalHole.Tipo.anus)
				{
					throw new ArgumentOutOfRangeException(this.tipo.ToString());
				}
				skinnedMeshRenderer = Singleton<SemenSkinsParaHoleInternals>.instance.GetPrefabForAnus(this.m_skinIndex);
			}
			else
			{
				skinnedMeshRenderer = Singleton<SemenSkinsParaHoleInternals>.instance.GetPrefabForVag(this.m_skinIndex);
			}
			this.m_instance = Object.Instantiate<SkinnedMeshRenderer>(skinnedMeshRenderer, this.m_Internals.transform.position, this.m_Internals.transform.rotation, this.m_Internals.transform);
			this.m_instance.gameObject.layer = this.m_Internals.skinnedMeshRenderer.gameObject.layer;
			this.m_semenMaterialInstance = Object.Instantiate<Material>(skinnedMeshRenderer.sharedMaterial);
			this.m_instance.sharedMaterial = this.m_semenMaterialInstance;
			Skin.MountToSkeleton(this.m_instance.gameObject, this.m_Internals.skeleton.transform);
			this.UpdateWeight(0f);
			VertExmotion componentNotNull = this.m_instance.GetComponentNotNull<VertExmotion>();
			componentNotNull.m_params.usePaintDataFromMeshColors = true;
			componentNotNull.m_normalCorrection = 0f;
			componentNotNull.m_normalSmooth = 0f;
			componentNotNull.m_useVertexBufferMode = false;
			this.m_instance.GetComponentNotNull<VertExmotionUpdater>();
			LoadSensoresDeMainCharacter componentNotNull2 = this.m_instance.GetComponentNotNull<LoadSensoresDeMainCharacter>();
			componentNotNull2.layer = SensorConLayers.Layer.skin;
			componentNotNull2.loadFromMainCharacter = true;
			componentNotNull2.loadFromSelfCharacter = false;
			GenericShapeKeyCopier.Add(this.m_instance, this.m_Internals.skinnedMeshRenderer);
			this.m_instance.gameObject.SetActive(true);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000065FC File Offset: 0x000047FC
		public void UpdateWeight(float w)
		{
			this.m_currentW = w;
			float num = w.InInOutOutPowInverted(24f, 1f, 0.666f);
			float num2 = Mathf.Lerp(this.config.maxAlphaCut, 0f, num);
			this.m_semenMaterialInstance.SetFloat(this.m_ShaderID, num2);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00006650 File Offset: 0x00004850
		public void Clear()
		{
			if (this.m_instance != null)
			{
				Object.Destroy(this.m_instance.gameObject);
			}
			this.m_instance = null;
			if (this.m_semenMaterialInstance != null)
			{
				Object.Destroy(this.m_semenMaterialInstance);
			}
			this.m_semenMaterialInstance = null;
			this.m_skinIndex = -1;
		}

		// Token: 0x040000A2 RID: 162
		private int m_ShaderID;

		// Token: 0x040000A3 RID: 163
		private HoleInternal m_Internals;

		// Token: 0x040000A4 RID: 164
		[SerializeField]
		[ReadOnlyUI]
		private int m_skinIndex = -1;

		// Token: 0x040000A5 RID: 165
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentW;

		// Token: 0x040000A6 RID: 166
		[SerializeField]
		[ReadOnlyUI]
		private SkinnedMeshRenderer m_instance;

		// Token: 0x040000A7 RID: 167
		[SerializeField]
		[ReadOnlyUI]
		private Material m_semenMaterialInstance;

		// Token: 0x040000A8 RID: 168
		public ControlladorDeSemenParaInternalHole.Config config = new ControlladorDeSemenParaInternalHole.Config();

		// Token: 0x0200002A RID: 42
		[Serializable]
		public class Config
		{
			// Token: 0x040000A9 RID: 169
			public float maxAlphaCut = 0.1f;
		}

		// Token: 0x0200002B RID: 43
		public enum Tipo
		{
			// Token: 0x040000AB RID: 171
			vag,
			// Token: 0x040000AC RID: 172
			anus
		}
	}
}
