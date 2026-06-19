using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets.TValle.Tools.Runtime.SMA.Jobs;
using Assets.TValle.Tools.Runtime.SMA.Moddding.Jobs.Maps;
using Assets._ReusableScripts.CuchiCuchi;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Trabajos
{
	// Token: 0x0200005D RID: 93
	public class JobActivity : Actividad
	{
		// Token: 0x06000328 RID: 808 RVA: 0x000117C8 File Offset: 0x0000F9C8
		public void SetData(SMAJobMap JobMap, ISMAJob Job, Guid Male, Guid Female, Action<ISMAJob> onJobInit)
		{
			if (base.isInit)
			{
				throw new InvalidOperationException();
			}
			this.m_jobMap = JobMap;
			this.m_job = Job;
			this.m_male = Male;
			this.m_female = Female;
			this.m_onJobInit = onJobInit;
			Job.mainNonPlayerChanged += this.Job_mainNonPlayerChanged;
			Job.mainPlayerChanged += this.Job_mainPlayerChanged;
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000329 RID: 809 RVA: 0x0001182C File Offset: 0x0000FA2C
		public ISMAJob job
		{
			get
			{
				return this.m_job;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600032A RID: 810 RVA: 0x00011834 File Offset: 0x0000FA34
		public SMAJobMap jobMap
		{
			get
			{
				return this.m_jobMap;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600032B RID: 811 RVA: 0x0001183C File Offset: 0x0000FA3C
		public Guid male
		{
			get
			{
				return this.m_male;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600032C RID: 812 RVA: 0x00011844 File Offset: 0x0000FA44
		public Guid female
		{
			get
			{
				return this.m_female;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600032D RID: 813 RVA: 0x0001184C File Offset: 0x0000FA4C
		public override string ID
		{
			get
			{
				return this.m_job.ID;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600032E RID: 814 RVA: 0x00011859 File Offset: 0x0000FA59
		public override bool usesCustomLightingByUser
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600032F RID: 815 RVA: 0x0001185C File Offset: 0x0000FA5C
		public override string Name
		{
			get
			{
				return this.m_job.Name;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000330 RID: 816 RVA: 0x00011869 File Offset: 0x0000FA69
		public override bool isInit
		{
			get
			{
				return this.m_job.isInit && base.isInit;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000331 RID: 817 RVA: 0x00011880 File Offset: 0x0000FA80
		public override bool aborted
		{
			get
			{
				return this.m_job.isAborted || base.aborted;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000332 RID: 818 RVA: 0x00011897 File Offset: 0x0000FA97
		public override Character mainPlayerCharacter
		{
			get
			{
				return this.m_mainPlayerCharacter;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000333 RID: 819 RVA: 0x0001189F File Offset: 0x0000FA9F
		public override Character mainNonPlayerCharacter
		{
			get
			{
				return this.m_mainNonPlayerCharacter;
			}
		}

		// Token: 0x06000334 RID: 820 RVA: 0x000118A7 File Offset: 0x0000FAA7
		private void Job_mainPlayerChanged(SceneCharacter nuevo, SceneCharacter viejo, ISMAJob sender)
		{
			this.m_mainPlayerCharacter = ((nuevo != null) ? nuevo.GetComponent<Character>() : null);
		}

		// Token: 0x06000335 RID: 821 RVA: 0x000118BB File Offset: 0x0000FABB
		private void Job_mainNonPlayerChanged(SceneCharacter nuevo, SceneCharacter viejo, ISMAJob sender)
		{
			this.m_mainNonPlayerCharacter = ((nuevo != null) ? nuevo.GetComponent<Character>() : null);
		}

		// Token: 0x06000336 RID: 822 RVA: 0x000118CF File Offset: 0x0000FACF
		protected override void OnInit()
		{
			Action<ISMAJob> onJobInit = this.m_onJobInit;
			if (onJobInit == null)
			{
				return;
			}
			onJobInit(this.m_job);
		}

		// Token: 0x06000337 RID: 823 RVA: 0x000118E7 File Offset: 0x0000FAE7
		protected override IEnumerator OnStart()
		{
			return this.m_job.DoStart();
		}

		// Token: 0x06000338 RID: 824 RVA: 0x000118F4 File Offset: 0x0000FAF4
		public override IEnumerator Introduce()
		{
			return this.m_job.Introduce();
		}

		// Token: 0x06000339 RID: 825 RVA: 0x00011901 File Offset: 0x0000FB01
		public override void OnNonPlayerMaxEmotionValue(Emotion emotion)
		{
			this.m_job.OnNonPlayerMaxEmotionValue(emotion);
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0001190F File Offset: 0x0000FB0F
		public override bool OnNonPlayerMaxEmotionValueBuffer(Emotion emotion)
		{
			return this.m_job.OnNonPlayerMaxEmotionValueBuffer(emotion);
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0001191D File Offset: 0x0000FB1D
		public override void OnPlayerMaxEmotionValue(Emotion emotion)
		{
			this.m_job.OnPlayerMaxEmotionValue(emotion);
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0001192B File Offset: 0x0000FB2B
		public override bool OnPlayerMaxEmotionValueBuffer(Emotion emotion)
		{
			return this.m_job.OnPlayerMaxEmotionValueBuffer(emotion);
		}

		// Token: 0x0600033D RID: 829 RVA: 0x00011939 File Offset: 0x0000FB39
		public override void BeforeAnimationsUpdate()
		{
			this.m_job.BeforeAnimationsUpdate();
		}

		// Token: 0x0600033E RID: 830 RVA: 0x00011946 File Offset: 0x0000FB46
		public override void AfterAnimationsUpdate()
		{
			this.m_job.AfterAnimationsUpdate();
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00011953 File Offset: 0x0000FB53
		public override void BeforePhysicsUpdate()
		{
			this.m_job.BeforePhysicsUpdate();
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00011960 File Offset: 0x0000FB60
		public override void AfterPhysicsUpdate()
		{
			this.m_job.AfterPhysicsUpdate();
		}

		// Token: 0x06000341 RID: 833 RVA: 0x0001196D File Offset: 0x0000FB6D
		public override void BeforeAIUpdate()
		{
			this.m_job.BeforeAIUpdate();
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0001197A File Offset: 0x0000FB7A
		public override void AfterAIUpdate()
		{
			this.m_job.AfterAIUpdate();
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00011987 File Offset: 0x0000FB87
		public override IEnumerator Conclude()
		{
			return this.m_job.Conclude();
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00011994 File Offset: 0x0000FB94
		protected override IEnumerator OnEnd()
		{
			yield return this.m_job.End();
			if (AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter != null)
			{
				AsyncSingleton<JobsManager>.instance.DestroyCharacter(AsyncSingleton<JobsManager>.instance.current.mainNonPlayerCharacter.ID);
			}
			if (AsyncSingleton<JobsManager>.instance.current.mainPlayerCharacter != null)
			{
				AsyncSingleton<JobsManager>.instance.DestroyCharacter(AsyncSingleton<JobsManager>.instance.current.mainPlayerCharacter.ID);
			}
			yield break;
		}

		// Token: 0x040001D9 RID: 473
		[ReadOnlyUI]
		[SerializeField]
		private SMAJobMap m_jobMap;

		// Token: 0x040001DA RID: 474
		[ReadOnlyUI]
		[SerializeField]
		private Character m_mainPlayerCharacter;

		// Token: 0x040001DB RID: 475
		[ReadOnlyUI]
		[SerializeField]
		private Character m_mainNonPlayerCharacter;

		// Token: 0x040001DC RID: 476
		private ISMAJob m_job;

		// Token: 0x040001DD RID: 477
		private Guid m_male;

		// Token: 0x040001DE RID: 478
		private Guid m_female;

		// Token: 0x040001DF RID: 479
		private Action<ISMAJob> m_onJobInit;
	}
}
