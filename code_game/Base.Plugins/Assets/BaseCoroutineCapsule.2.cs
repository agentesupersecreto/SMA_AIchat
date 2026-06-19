using System;
using System.Collections;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000114 RID: 276
	public abstract class BaseCoroutineCapsule<TMono, TCoroutineCapsuleConfig> : BaseCoroutineCapsule<TMono> where TMono : MonoBehaviour, IComponentEnabable, IComponentStartable where TCoroutineCapsuleConfig : CoroutineCapsuleConfig, new()
	{
		// Token: 0x060007C1 RID: 1985 RVA: 0x0001B0A0 File Offset: 0x000192A0
		protected override void OnConstruct()
		{
			this.m_mono.onEnabled += this.M_mono_onEnable;
			this.m_mono.onDisabled += this.M_mono_onDisable;
			if (!this.m_mono.isStared)
			{
				this.m_mono.stared += this.M_mono_stared;
			}
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x0001B113 File Offset: 0x00019313
		public BaseCoroutineCapsule(TMono mono, TCoroutineCapsuleConfig config)
			: base(mono)
		{
			if (config == null)
			{
				throw new ArgumentNullException("config", "config null reference.");
			}
			this.m_config = config;
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x0001B146 File Offset: 0x00019346
		public BaseCoroutineCapsule(IEnumerator routine, TMono mono, TCoroutineCapsuleConfig config)
			: this(mono, config)
		{
			this.m_routine = routine;
			if (this.m_mono.isStared)
			{
				this.M_mono_stared(this.m_mono);
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060007C4 RID: 1988 RVA: 0x0001B17A File Offset: 0x0001937A
		public Coroutine current
		{
			get
			{
				return this.m_Coroutine;
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060007C5 RID: 1989 RVA: 0x0001B182 File Offset: 0x00019382
		public TCoroutineCapsuleConfig config
		{
			get
			{
				return this.m_config;
			}
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x0001B18C File Offset: 0x0001938C
		public void Start()
		{
			if (this.m_routine == null)
			{
				throw new ArgumentNullException("m_routine", "m_routine null reference.");
			}
			base.Start(this.m_routine, null, null);
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x0001B1C8 File Offset: 0x000193C8
		public override void Destroy()
		{
			TMono mono = this.m_mono;
			base.Destroy();
			if (mono != null)
			{
				mono.onEnabled -= this.M_mono_onEnable;
				mono.onDisabled -= this.M_mono_onDisable;
				mono.stared -= this.M_mono_stared;
			}
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x0001B230 File Offset: 0x00019430
		private void M_mono_onEnable(object obj)
		{
			if (this.m_mono.isStared && this.m_config.autoRestart && this.m_routine != null && this.m_Coroutine == null && this.m_currentContexto != null)
			{
				this.m_Coroutine = this.m_mono.StartCoroutine(BaseCoroutineCapsule<TMono>.RunThrowingIterator(this.m_routine, this.m_currentContexto));
			}
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x0001B2A0 File Offset: 0x000194A0
		private void M_mono_stared(object sender)
		{
			if (this.m_config.autoStart && this.m_routine != null)
			{
				base.Start(this.m_routine, null, null);
			}
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x0001B2DE File Offset: 0x000194DE
		private void M_mono_onDisable(object obj)
		{
			if (this.m_Coroutine != null)
			{
				this.m_mono.StopCoroutine(this.m_Coroutine);
			}
			this.m_Coroutine = null;
		}

		// Token: 0x04000226 RID: 550
		private TCoroutineCapsuleConfig m_config = new TCoroutineCapsuleConfig();
	}
}
