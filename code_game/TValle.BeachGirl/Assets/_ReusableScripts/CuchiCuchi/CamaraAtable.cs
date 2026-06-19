using System;
using System.Collections;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000C4 RID: 196
	public class CamaraAtable : CustomMonobehaviour, IPertenecibleDeCharacter
	{
		// Token: 0x17000243 RID: 579
		// (get) Token: 0x060005DC RID: 1500 RVA: 0x000128CF File Offset: 0x00010ACF
		public ICharacter inmediateOwner
		{
			get
			{
				return this.m_owner;
			}
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x000128D7 File Offset: 0x00010AD7
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_checker = new CoroutineCapsule(this.CheckRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x00012904 File Offset: 0x00010B04
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			Rigidbody collisionDetection = this.m_collisionDetection;
			this.m_defScale = ((collisionDetection != null) ? new float?(collisionDetection.transform.localScale.Escala()) : null).GetValueOrDefault(1f);
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x00012953 File Offset: 0x00010B53
		public Camera GetCamara()
		{
			return base.GetComponentInChildren<Camera>();
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x0001295B File Offset: 0x00010B5B
		public void OnAtada(Character character)
		{
			if (!base.isStared)
			{
				base.ManualStart();
			}
			if (character == null)
			{
				this.OnDesatada();
				return;
			}
			this.m_owner = character;
			this.UpdateColisionDetectionScale();
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x00012988 File Offset: 0x00010B88
		public void OnDesatada()
		{
			if (!base.isStared)
			{
				base.ManualStart();
			}
			this.m_owner = null;
			this.UpdateColisionDetectionScale();
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x000129A5 File Offset: 0x00010BA5
		private IEnumerator CheckRutine()
		{
			WaitForSeconds w = new WaitForSeconds(2f.Random(0.2f));
			yield return w;
			while (!base.isStared)
			{
				yield return w;
			}
			for (;;)
			{
				this.UpdateColisionDetectionScale();
				yield return w;
			}
			yield break;
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x000129B4 File Offset: 0x00010BB4
		private void UpdateColisionDetectionScale()
		{
			if (this.m_collisionDetection != null)
			{
				if (this.m_owner != null)
				{
					this.m_collisionDetection.transform.localScale = Vector3.Lerp(Vector3.one * this.m_defScale, Vector3.one * this.m_defScale * this.m_owner.escala, 0.75f);
					return;
				}
				this.m_collisionDetection.transform.localScale = Vector3.one * this.m_defScale;
			}
		}

		// Token: 0x040003C6 RID: 966
		[ReadOnlyUI]
		[SerializeField]
		private Character m_owner;

		// Token: 0x040003C7 RID: 967
		[SerializeField]
		private Rigidbody m_collisionDetection;

		// Token: 0x040003C8 RID: 968
		private float m_defScale;

		// Token: 0x040003C9 RID: 969
		private CoroutineCapsule m_checker;
	}
}
