using System;
using System.Collections;
using Assets.Productos.Juegos.Reception.Scripts.Entrevistas;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.General.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;
using Assets._ReusableScripts.CuchiCuchi.Scenas;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000125 RID: 293
	public sealed class EntrevistaScoreFemaleFromPool : EntrevistaParaCalificarFemaleCharacterFromPool
	{
		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000A64 RID: 2660 RVA: 0x00039C17 File Offset: 0x00037E17
		public override bool usesCustomLightingByUser
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000A65 RID: 2661 RVA: 0x00039C1A File Offset: 0x00037E1A
		public override string ID
		{
			get
			{
				return "TValle.Actividad.Entrevista&Calificacion";
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000A66 RID: 2662 RVA: 0x00039C21 File Offset: 0x00037E21
		public override string Name
		{
			get
			{
				return "Entrevista&Calificacion";
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000A67 RID: 2663 RVA: 0x00039C28 File Offset: 0x00037E28
		protected override bool saveNpcOnEndAvtivity
		{
			get
			{
				return this.m_modelWasHired;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000A68 RID: 2664 RVA: 0x00039C30 File Offset: 0x00037E30
		protected override bool deleteFromMemNpcOnEndAvtivity
		{
			get
			{
				return !this.m_modelWasHired && base.deleteFromMemNpcOnEndAvtivity;
			}
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x00039C42 File Offset: 0x00037E42
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x00039C4A File Offset: 0x00037E4A
		public void FlagModelWasHired()
		{
			this.m_modelWasHired = true;
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x00039C53 File Offset: 0x00037E53
		protected override IEnumerator OnEnd()
		{
			yield return base.OnEnd();
			if (this.m_modelWasHired)
			{
				Singleton<SMAGameplayController>.instance.EndCampaing();
			}
			yield break;
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x00039C62 File Offset: 0x00037E62
		protected override IEnumerator InstantiateMaleCharacter(Action<MaleChar> result)
		{
			GoToScenaManager.GoTo goTo = Singleton<GoToScenaManager>.instance.Obtener("MainOriginal_GoTo");
			Character loaded = null;
			yield return Singleton<ActividadesManager>.instance.LoadDefaultMaleCharacter(goTo.transform.position, goTo.transform.forward, delegate(Character r)
			{
				loaded = r;
			});
			if (result != null)
			{
				result(loaded as MaleChar);
			}
			yield break;
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x00039C71 File Offset: 0x00037E71
		protected override IEnumerator InstantiateFemaleCharacter(Action<FemaleChar> result)
		{
			GoToScenaManager.GoTo goTo = Singleton<GoToScenaManager>.instance.Obtener("Original_GoTo");
			Character loaded = null;
			yield return Singleton<ActividadesManager>.instance.LoadDefaultFemaleCharacter(goTo.transform.position, goTo.transform.forward, delegate(Character r)
			{
				loaded = r;
			});
			if (result != null)
			{
				result(loaded as FemaleChar);
			}
			yield break;
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x00039C80 File Offset: 0x00037E80
		public override void OnNonPlayerMaxEmotionValue(Emotion emotion)
		{
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x00039C82 File Offset: 0x00037E82
		public override bool OnNonPlayerMaxEmotionValueBuffer(Emotion emotion)
		{
			return true;
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x00039C85 File Offset: 0x00037E85
		public override void OnPlayerMaxEmotionValue(Emotion emotion)
		{
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x00039C87 File Offset: 0x00037E87
		public override bool OnPlayerMaxEmotionValueBuffer(Emotion emotion)
		{
			return true;
		}

		// Token: 0x06000A72 RID: 2674 RVA: 0x00039C8A File Offset: 0x00037E8A
		public override void BeforeAnimationsUpdate()
		{
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x00039C8C File Offset: 0x00037E8C
		public override void BeforePhysicsUpdate()
		{
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x00039C8E File Offset: 0x00037E8E
		public override void AfterPhysicsUpdate()
		{
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x00039C90 File Offset: 0x00037E90
		public override void BeforeAIUpdate()
		{
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x00039C92 File Offset: 0x00037E92
		public override void AfterAIUpdate()
		{
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x00039C94 File Offset: 0x00037E94
		public override IEnumerator Introduce()
		{
			GameplayObjectives.SingleActionObjective singleActionObjective;
			GameplayObjectives.SingleActionObjective singleActionObjective2;
			base.GetDefaultObjctivesInterviewing(delegate
			{
				if (!Singleton<PanelDeEntrevistaCalificacionGetter>.IsInScene)
				{
					return false;
				}
				PanelDeEntrevistaCalificacion panel = Singleton<PanelDeEntrevistaCalificacionGetter>.instance.panel;
				return panel.tryContactada || panel.tryDespachada || panel.tryHired;
			}, () => Singleton<PanelDeEntrevistaCalificacionGetter>.IsInScene && Singleton<PanelDeEntrevistaCalificacionGetter>.instance.panel.haSidoCalificadoPorPlayer, out singleActionObjective, out singleActionObjective2);
			this.m_actividadObjectives = new GameplayObjectives.Objective[] { singleActionObjective, singleActionObjective2 };
			Singleton<GameplayObjectives>.instance.AddObjetives(this.m_actividadObjectives, false);
			yield break;
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x00039CA3 File Offset: 0x00037EA3
		public override IEnumerator Conclude()
		{
			bool flag = base.femalePresencia == EntrevistaConFemaleCharacter.FemalePresencia.retiradaPorSiMismaDolor || base.femalePresencia == EntrevistaConFemaleCharacter.FemalePresencia.retiradaPorSiMismaRabia || base.femalePresencia == EntrevistaConFemaleCharacter.FemalePresencia.retiradaPorSiMismaDecepcion || base.femalePresencia == EntrevistaConFemaleCharacter.FemalePresencia.retiradaPorSiMismaMiedo;
			SceneCharacterFromToBuffAndDebuff sceneCharacterFromToBuffAndDebuff;
			SceneCharacterFromToBuffAndDebuff sceneCharacterFromToBuffAndDebuff2;
			Singleton<InteraccionesEnScena>.instance.DefaultBuffAndDebuffGenerate(Singleton<ActividadesManager>.instance.current.GetCachedMainPlayerComponent<SceneCharacter>(), Singleton<ActividadesManager>.instance.current.GetCachedMainNonPlayerComponent<SceneCharacter>(), flag, Singleton<TiempoDeJuego>.instance.now, out sceneCharacterFromToBuffAndDebuff, out sceneCharacterFromToBuffAndDebuff2);
			Singleton<GameplayObjectives>.instance.RemoveObjetives(this.m_actividadObjectives);
			sceneCharacterFromToBuffAndDebuff.Apply();
			yield break;
		}

		// Token: 0x04000567 RID: 1383
		public const string actividadName = "Entrevista&Calificacion";

		// Token: 0x04000568 RID: 1384
		[SerializeField]
		[ReadOnlyUI]
		private bool m_modelWasHired;

		// Token: 0x04000569 RID: 1385
		[SerializeReference]
		private GameplayObjectives.Objective[] m_actividadObjectives;
	}
}
