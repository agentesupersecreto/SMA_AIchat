using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;

namespace Assets.TValle.Pro.Entrevista.Runtime.Actividades
{
	// Token: 0x02000124 RID: 292
	public sealed class EntrevistaComenzarATrabajar : ActividadConMaleCharacter
	{
		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000A52 RID: 2642 RVA: 0x00039BAF File Offset: 0x00037DAF
		public override string ID
		{
			get
			{
				return "TValle.Actividad.ComenzarATrabajar";
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000A53 RID: 2643 RVA: 0x00039BB6 File Offset: 0x00037DB6
		public override bool usesCustomLightingByUser
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000A54 RID: 2644 RVA: 0x00039BB9 File Offset: 0x00037DB9
		public override string Name
		{
			get
			{
				return "ComenzarATrabajar";
			}
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x00039BC0 File Offset: 0x00037DC0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x06000A56 RID: 2646 RVA: 0x00039BC8 File Offset: 0x00037DC8
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

		// Token: 0x06000A57 RID: 2647 RVA: 0x00039BD7 File Offset: 0x00037DD7
		public override IEnumerator Introduce()
		{
			yield break;
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x00039BDF File Offset: 0x00037DDF
		public override IEnumerator Conclude()
		{
			yield break;
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x00039BE7 File Offset: 0x00037DE7
		public override void BeforeAnimationsUpdate()
		{
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x00039BE9 File Offset: 0x00037DE9
		public override void AfterAnimationsUpdate()
		{
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x00039BEB File Offset: 0x00037DEB
		public override void BeforePhysicsUpdate()
		{
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x00039BED File Offset: 0x00037DED
		public override void AfterPhysicsUpdate()
		{
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x00039BEF File Offset: 0x00037DEF
		public override void BeforeAIUpdate()
		{
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x00039BF1 File Offset: 0x00037DF1
		public override void AfterAIUpdate()
		{
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x00039BF3 File Offset: 0x00037DF3
		public override void OnNonPlayerMaxEmotionValue(Emotion emotion)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x00039BFA File Offset: 0x00037DFA
		public override bool OnNonPlayerMaxEmotionValueBuffer(Emotion emotion)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x00039C01 File Offset: 0x00037E01
		public override void OnPlayerMaxEmotionValue(Emotion emotion)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x00039C08 File Offset: 0x00037E08
		public override bool OnPlayerMaxEmotionValueBuffer(Emotion emotion)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000566 RID: 1382
		public const string actividadName = "ComenzarATrabajar";
	}
}
