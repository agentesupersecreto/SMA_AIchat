using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Vagis;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts.Vags
{
	// Token: 0x0200010B RID: 267
	public class Clitoris : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x06000BBD RID: 3005 RVA: 0x00027332 File Offset: 0x00025532
		public ClitorisCollider clitorisCollider
		{
			get
			{
				return this.clitorisPhysics.clitorisCollider;
			}
		}

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x06000BBE RID: 3006 RVA: 0x0002733F File Offset: 0x0002553F
		public ClitorisPhysics clitorisPhysics
		{
			get
			{
				return this.m_ClitorisPhysics;
			}
		}

		// Token: 0x06000BBF RID: 3007 RVA: 0x00027348 File Offset: 0x00025548
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.transform.ExecDeepChild(delegate(Transform t)
			{
				t.gameObject.layer = Singleton<ConfiguracionGeneral>.instance.layers.holeExtras;
			}, true);
			this.m_ClitorisPhysics = this.GetComponentNotNull<ClitorisPhysics>();
			this.m_ClitorisPhysics.SetManualStart();
		}

		// Token: 0x06000BC0 RID: 3008 RVA: 0x0002739D File Offset: 0x0002559D
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_ClitorisPhysics.ManualStart();
		}

		// Token: 0x0400064D RID: 1613
		private ClitorisPhysics m_ClitorisPhysics;
	}
}
