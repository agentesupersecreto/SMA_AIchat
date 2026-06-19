using System;
using System.Collections;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000113 RID: 275
	public abstract class BaseCoroutineCapsule<TMono> where TMono : MonoBehaviour
	{
		// Token: 0x060007B8 RID: 1976 RVA: 0x0001AF09 File Offset: 0x00019109
		public BaseCoroutineCapsule(TMono mono)
		{
			if (mono == null)
			{
				throw new ArgumentNullException("mono", "mono null reference.");
			}
			this.m_mono = mono;
			this.OnConstruct();
		}

		// Token: 0x060007B9 RID: 1977
		protected abstract void OnConstruct();

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x060007BA RID: 1978 RVA: 0x0001AF3C File Offset: 0x0001913C
		public bool ejecutandose
		{
			get
			{
				return this.m_Coroutine != null || this.m_currentContexto != null;
			}
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x0001AF54 File Offset: 0x00019154
		public BaseCoroutineCapsule<TMono>.Contexto Start(IEnumerator routine, float? maxDuration = null, Action<BaseCoroutineCapsule<TMono>.Contexto> onContextoCreated = null)
		{
			if (this.m_Coroutine != null)
			{
				Debug.LogError("Coroutine Ya estaba iniciada, no se iniciara ninguna ejecucion", this.m_mono);
				return this.m_currentContexto;
			}
			this.Clear();
			this.m_routine = routine;
			this.m_currentContexto = new BaseCoroutineCapsule<TMono>.Contexto(this, maxDuration);
			if (onContextoCreated != null)
			{
				onContextoCreated(this.m_currentContexto);
			}
			this.m_Coroutine = this.m_mono.StartCoroutine(BaseCoroutineCapsule<TMono>.RunThrowingIterator(routine, this.m_currentContexto));
			return this.m_currentContexto;
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x0001AFD8 File Offset: 0x000191D8
		public void Stop()
		{
			if (this.m_Coroutine != null)
			{
				this.m_mono.StopCoroutine(this.m_Coroutine);
				this.Clear();
				return;
			}
			if (this.m_currentContexto != null)
			{
				this.Clear();
				return;
			}
			Debug.LogError("coroutine no existe o no se esta iniciando", this.m_mono);
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x0001B02E File Offset: 0x0001922E
		public virtual void Destroy()
		{
			if (this.ejecutandose)
			{
				this.Stop();
			}
			this.Clear();
			this.m_mono = default(TMono);
			this.m_routine = null;
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x0001B057 File Offset: 0x00019257
		private void Clear()
		{
			BaseCoroutineCapsule<TMono>.Contexto currentContexto = this.m_currentContexto;
			if (currentContexto != null)
			{
				currentContexto.Stopped();
			}
			this.m_currentContexto = null;
			this.m_Coroutine = null;
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x0001B078 File Offset: 0x00019278
		private void onDone()
		{
			if (this.ejecutandose)
			{
				this.Stop();
			}
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x0001B088 File Offset: 0x00019288
		protected static IEnumerator RunThrowingIterator(IEnumerator enumerator, BaseCoroutineCapsule<TMono>.Contexto contexto)
		{
			Exception e = null;
			for (;;)
			{
				object obj;
				try
				{
					if (contexto.isFlagedToStop)
					{
						break;
					}
					if (!enumerator.MoveNext())
					{
						break;
					}
					obj = enumerator.Current;
				}
				catch (Exception ex)
				{
					e = ex;
					break;
				}
				yield return obj;
			}
			contexto.OnDone(e);
			yield break;
		}

		// Token: 0x04000222 RID: 546
		protected TMono m_mono;

		// Token: 0x04000223 RID: 547
		protected Coroutine m_Coroutine;

		// Token: 0x04000224 RID: 548
		protected IEnumerator m_routine;

		// Token: 0x04000225 RID: 549
		protected BaseCoroutineCapsule<TMono>.Contexto m_currentContexto;

		// Token: 0x020001D5 RID: 469
		[Serializable]
		public class Contexto
		{
			// Token: 0x06000C83 RID: 3203 RVA: 0x00026DDF File Offset: 0x00024FDF
			public Contexto(BaseCoroutineCapsule<TMono> owner, float? MaxDuration = null)
			{
				this.m_owner = owner;
				this.maxDuration = MaxDuration;
				this.startTime = Time.time;
			}

			// Token: 0x14000035 RID: 53
			// (add) Token: 0x06000C84 RID: 3204 RVA: 0x00026E00 File Offset: 0x00025000
			// (remove) Token: 0x06000C85 RID: 3205 RVA: 0x00026E38 File Offset: 0x00025038
			public event Action<Exception, object> onExeption;

			// Token: 0x14000036 RID: 54
			// (add) Token: 0x06000C86 RID: 3206 RVA: 0x00026E70 File Offset: 0x00025070
			// (remove) Token: 0x06000C87 RID: 3207 RVA: 0x00026EA8 File Offset: 0x000250A8
			public event Action onDone;

			// Token: 0x06000C88 RID: 3208 RVA: 0x00026EDD File Offset: 0x000250DD
			public bool IsTimeOver()
			{
				return this.maxDuration != null && Time.time - this.startTime >= this.maxDuration.Value;
			}

			// Token: 0x06000C89 RID: 3209 RVA: 0x00026F0C File Offset: 0x0002510C
			public void OnDone(Exception ex)
			{
				if (ex != null)
				{
					this.OnExeption(ex);
				}
				Action action = this.onDone;
				BaseCoroutineCapsule<TMono> owner = this.m_owner;
				this.Clear();
				if (action != null)
				{
					action();
				}
				if (owner != null)
				{
					owner.onDone();
				}
			}

			// Token: 0x06000C8A RID: 3210 RVA: 0x00026F4A File Offset: 0x0002514A
			public void Stopped()
			{
				this.Clear();
				this.isFlagedToStop = true;
			}

			// Token: 0x06000C8B RID: 3211 RVA: 0x00026F59 File Offset: 0x00025159
			private void OnExeption(Exception ex)
			{
				Debug.LogException(ex, this.m_owner.m_mono);
				Action<Exception, object> action = this.onExeption;
				if (action == null)
				{
					return;
				}
				action(ex, this);
			}

			// Token: 0x06000C8C RID: 3212 RVA: 0x00026F83 File Offset: 0x00025183
			public void Clear()
			{
				this.onExeption = null;
				this.onDone = null;
				this.m_owner = null;
				this.maxDuration = null;
				this.isFlagedToStop = false;
			}

			// Token: 0x04000461 RID: 1121
			private BaseCoroutineCapsule<TMono> m_owner;

			// Token: 0x04000464 RID: 1124
			public bool isFlagedToStop;

			// Token: 0x04000465 RID: 1125
			public float? maxDuration;

			// Token: 0x04000466 RID: 1126
			public float startTime;
		}
	}
}
