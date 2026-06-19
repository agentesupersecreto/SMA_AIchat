using System;
using System.Collections.Generic;
using Assets.Base.Genetica.Runtime.NPCs;
using Assets.Productos.Juegos.Reception;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.Globales;
using InterfaceFields;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.TValle.Pro.Entrevista.Runtime.General.Scenas
{
	// Token: 0x020000BB RID: 187
	public sealed class StandAloneRatingScene : ScenaManager<StandAloneRatingScene>
	{
		// Token: 0x060006EF RID: 1775 RVA: 0x00027E56 File Offset: 0x00026056
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void BeforeJuegoLanzado()
		{
			SceneSingletonV2.Finalizar();
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x00027E60 File Offset: 0x00026060
		protected override void OnAwake()
		{
			base.OnAwake();
			if (this.m_femaleToRatePrefab == null)
			{
				throw new ArgumentNullException("m_femaleToRate", "m_femaleToRate null reference.");
			}
			this.m_stadoLuces = Singleton<LucesEnEscena>.instance.GetCurrentState();
			Singleton<LucesEnEscena>.instance.SetDirectionalsState(false);
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x00027EAC File Offset: 0x000260AC
		protected override void OnSceneCargada(LoadSceneMode arg1)
		{
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x00027EB0 File Offset: 0x000260B0
		protected override void OnSceneDescargada()
		{
			foreach (StandAloneRatingScene.Slot slot in this.m_slotsEnUso)
			{
				if (slot != null)
				{
					slot.Destroy();
				}
			}
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x00027F08 File Offset: 0x00026108
		protected override void OnDestroyed()
		{
			base.OnDestroyed();
			for (int i = 0; i < this.m_pool.Count; i++)
			{
				FemaleChar femaleChar = this.m_pool[i];
				Object.Destroy((femaleChar != null) ? femaleChar.gameObject : null);
			}
			if (this.m_stadoLuces != null)
			{
				Singleton<LucesEnEscena>.instance.SetState(this.m_stadoLuces);
			}
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00027F68 File Offset: 0x00026168
		public StandAloneRatingScene.Slot GetSlot()
		{
			StandAloneRatingScene.Slot slot = new StandAloneRatingScene.Slot();
			slot.Init(new Func<Scene, FemaleChar>(this.Instantiator), this);
			this.m_slotsEnUso.Add(slot);
			return slot;
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00027F9B File Offset: 0x0002619B
		internal void DestroySlot(StandAloneRatingScene.Slot slot)
		{
			this.m_slotsEnUso.Remove(slot);
			this.m_pool.Add(slot.instantiatedFemale);
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00027FBC File Offset: 0x000261BC
		private FemaleChar Instantiator(Scene scene)
		{
			if (this.m_pool.Count > 0)
			{
				FemaleChar femaleChar = this.m_pool[0];
				this.m_pool.RemoveAt(0);
				return femaleChar;
			}
			Transform transform = this.m_slotsTransforms[0];
			this.m_slotsTransforms.RemoveAt(0);
			FemaleChar femaleChar2 = Object.Instantiate<FemaleChar>(this.m_femaleToRatePrefab, transform.position, transform.rotation);
			SceneManager.MoveGameObjectToScene(femaleChar2.gameObject, scene);
			return femaleChar2;
		}

		// Token: 0x0400041F RID: 1055
		[SerializeField]
		private FemaleChar m_femaleToRatePrefab;

		// Token: 0x04000420 RID: 1056
		[SerializeField]
		private List<Transform> m_slotsTransforms = new List<Transform>();

		// Token: 0x04000421 RID: 1057
		[SerializeField]
		private List<StandAloneRatingScene.Slot> m_slotsEnUso = new List<StandAloneRatingScene.Slot>();

		// Token: 0x04000422 RID: 1058
		[SerializeField]
		private List<FemaleChar> m_pool = new List<FemaleChar>();

		// Token: 0x04000423 RID: 1059
		private Dictionary<LuzEnEscena, bool> m_stadoLuces;

		// Token: 0x0200023D RID: 573
		[Serializable]
		public class Slot
		{
			// Token: 0x170002BF RID: 703
			// (get) Token: 0x060010A2 RID: 4258 RVA: 0x0004F3E1 File Offset: 0x0004D5E1
			public FemaleChar instantiatedFemale
			{
				get
				{
					return this.m_instantiatedFemale;
				}
			}

			// Token: 0x060010A3 RID: 4259 RVA: 0x0004F3E9 File Offset: 0x0004D5E9
			internal void Init(Func<Scene, FemaleChar> instantiator, StandAloneRatingScene manager)
			{
				this.m_manager = manager;
				this.m_instantiator = instantiator;
			}

			// Token: 0x060010A4 RID: 4260 RVA: 0x0004F3F9 File Offset: 0x0004D5F9
			public void SetData(ISujetoIdentificableNpc npc)
			{
				this.m_RequiredData.npc = npc;
				if (!this.m_RequiredData.IsValid())
				{
					throw new InvalidOperationException();
				}
			}

			// Token: 0x060010A5 RID: 4261 RVA: 0x0004F41A File Offset: 0x0004D61A
			public void Instantiate(Scene scene)
			{
				if (!this.m_RequiredData.IsValid())
				{
					throw new InvalidOperationException();
				}
				this.m_instantiatedFemale = this.m_instantiator(scene);
			}

			// Token: 0x060010A6 RID: 4262 RVA: 0x0004F444 File Offset: 0x0004D644
			public void LoadNPCToFemaleChar()
			{
				if (!this.m_RequiredData.IsValid())
				{
					throw new InvalidOperationException();
				}
				if (this.m_instantiatedFemale == null)
				{
					throw new ArgumentNullException("m_instantiatedFemale", "m_instantiatedFemale null reference.");
				}
				LoaderDeNpcFemeninos.Load(this.m_instantiatedFemale, this.m_RequiredData.npc, true, null, true);
			}

			// Token: 0x060010A7 RID: 4263 RVA: 0x0004F49C File Offset: 0x0004D69C
			public object DoAutoRating(out IReadOnlyDictionary<string, float> aparienciaRatingResult, out IReadOnlyDictionary<string, float> personalidadRatingResult)
			{
				if (this.m_instantiatedFemale == null)
				{
					throw new ArgumentNullException("m_instantiatedFemale", "m_instantiatedFemale null reference.");
				}
				ICharacterAutoRateable componentEnRoot = this.m_instantiatedFemale.GetComponentEnRoot<ICharacterAutoRateable>();
				if (componentEnRoot == null)
				{
					throw new ArgumentNullException("ICharacterAutoRateable", "ICharacterAutoRateable null reference.");
				}
				return componentEnRoot.DoAutoRating(out aparienciaRatingResult, out personalidadRatingResult);
			}

			// Token: 0x060010A8 RID: 4264 RVA: 0x0004F4EC File Offset: 0x0004D6EC
			public void Destroy()
			{
				StandAloneRatingScene manager = this.m_manager;
				if (manager != null)
				{
					manager.DestroySlot(this);
				}
				this.m_instantiatedFemale = null;
			}

			// Token: 0x04000AAF RID: 2735
			private StandAloneRatingScene m_manager;

			// Token: 0x04000AB0 RID: 2736
			[SerializeField]
			[ReadOnlyUI]
			private StandAloneRatingScene.Slot.RequiredData m_RequiredData = new StandAloneRatingScene.Slot.RequiredData();

			// Token: 0x04000AB1 RID: 2737
			[SerializeField]
			[ReadOnlyUI]
			private FemaleChar m_instantiatedFemale;

			// Token: 0x04000AB2 RID: 2738
			private Func<Scene, FemaleChar> m_instantiator;

			// Token: 0x020002FE RID: 766
			[Serializable]
			public class RequiredData
			{
				// Token: 0x06001381 RID: 4993 RVA: 0x00056ADE File Offset: 0x00054CDE
				public bool IsValid()
				{
					return this.npc != null;
				}

				// Token: 0x1700035B RID: 859
				// (get) Token: 0x06001382 RID: 4994 RVA: 0x00056AE9 File Offset: 0x00054CE9
				// (set) Token: 0x06001383 RID: 4995 RVA: 0x00056AF6 File Offset: 0x00054CF6
				public ISujetoIdentificableNpc npc
				{
					get
					{
						return this.m_npc as ISujetoIdentificableNpc;
					}
					set
					{
						this.m_npc = value as Object;
					}
				}

				// Token: 0x04000D69 RID: 3433
				[ConstraintType(typeof(ISujetoIdentificableNpc), true)]
				[SerializeField]
				private Object m_npc;
			}
		}
	}
}
