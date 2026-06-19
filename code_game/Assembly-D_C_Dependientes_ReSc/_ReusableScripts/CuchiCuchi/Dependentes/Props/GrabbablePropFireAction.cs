using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime.Characteres;
using Assets._ReusableScripts.Globales.Clases;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Props
{
	// Token: 0x02000142 RID: 322
	public abstract class GrabbablePropFireAction : AplicableBehaviour
	{
		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000651 RID: 1617 RVA: 0x0000B284 File Offset: 0x00009484
		public sealed override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000652 RID: 1618 RVA: 0x00023474 File Offset: 0x00021674
		public float fireActionWeight
		{
			get
			{
				return this.m_currentFireActionValue;
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000653 RID: 1619 RVA: 0x0002347C File Offset: 0x0002167C
		public float fireInActionSpeed
		{
			get
			{
				return this.m_fireInActionSpeed;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000654 RID: 1620 RVA: 0x00023484 File Offset: 0x00021684
		public float fireOutActionSpeed
		{
			get
			{
				return this.m_fireOutActionSpeed;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000655 RID: 1621 RVA: 0x0002348C File Offset: 0x0002168C
		public float currentFireActionSpeedPerSecond
		{
			get
			{
				return this.m_currentFireActionSpeedPerSecond;
			}
		}

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000656 RID: 1622 RVA: 0x00023494 File Offset: 0x00021694
		// (remove) Token: 0x06000657 RID: 1623 RVA: 0x000234CC File Offset: 0x000216CC
		public event GrabbablePropFireAction.OnFireActionWeightUpdatedHandler fireActionUpdated;

		// Token: 0x06000658 RID: 1624 RVA: 0x00023501 File Offset: 0x00021701
		protected override void AwakeUnityEvent()
		{
			this.m_currentFireActionSpeedMod = 1f;
			base.AwakeUnityEvent();
			this.m_GrabbableProp = base.GetComponent<GrabbableProp>();
			if (this.m_GrabbableProp == null)
			{
				throw new ArgumentNullException("m_GrabbableToy", "m_GrabbableToy null reference.");
			}
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x00023540 File Offset: 0x00021740
		public sealed override void OnUpdateEvent1()
		{
			InputProxyVirtuales toolMovement = Singleton<PlayerInputProxy>.instance.toolMovement;
			this.m_currentFireActionSpeedMod = 1f;
			if (toolMovement.goingFaster)
			{
				this.m_currentFireActionSpeedMod *= 3f;
			}
			if (toolMovement.goingSlower)
			{
				this.m_currentFireActionSpeedMod /= 3f;
			}
			if (this.m_GrabbableProp.estado == GrabbablePropEstado.Grabbed)
			{
				InputProxyFiring fire = Singleton<PlayerInputProxy>.instance.fire1;
				if (this.m_waitForInputRelease && (fire.clickedUp || !fire.heldDown))
				{
					this.m_waitForInputRelease = false;
				}
				if (!this.m_waitForInputRelease)
				{
					if (fire.heldDown)
					{
						this.m_currentFireActionTarget = 1f;
					}
					else
					{
						this.m_currentFireActionTarget = 0f;
					}
				}
			}
			else if (this.m_GrabbableProp.estado == GrabbablePropEstado.NotGrabbed)
			{
				this.m_currentFireActionTarget = 0f;
				this.m_waitForInputRelease = true;
			}
			else
			{
				this.m_waitForInputRelease = true;
			}
			float currentFireActionTarget = this.m_currentFireActionTarget;
			bool flag;
			float num;
			if (this.m_currentFireActionValue < this.m_currentFireActionTarget)
			{
				flag = true;
				num = this.m_fireInActionSpeed;
			}
			else
			{
				flag = false;
				num = this.m_fireOutActionSpeed;
			}
			float currentFireActionValue = this.m_currentFireActionValue;
			this.m_currentFireActionValue = Mathf.MoveTowards(this.m_currentFireActionValue, this.m_currentFireActionTarget, Time.deltaTime * num * this.m_currentFireActionSpeedMod);
			this.m_currentFireActionSpeedPerSecond = (this.m_currentFireActionValue - currentFireActionValue) / Time.deltaTime;
			bool flag2 = !currentFireActionValue.AlmostEqualV2(this.m_currentFireActionValue, float.Epsilon);
			this.OnFireActionWeightUpdated(flag2, flag);
			GrabbablePropFireAction.OnFireActionWeightUpdatedHandler onFireActionWeightUpdatedHandler = this.fireActionUpdated;
			if (onFireActionWeightUpdatedHandler == null)
			{
				return;
			}
			onFireActionWeightUpdatedHandler(currentFireActionValue, this.m_currentFireActionValue, this.m_currentFireActionSpeedPerSecond, flag2, flag, this);
		}

		// Token: 0x0600065A RID: 1626
		protected abstract void OnFireActionWeightUpdated(bool changed, bool increasing);

		// Token: 0x0400051A RID: 1306
		protected GrabbableProp m_GrabbableProp;

		// Token: 0x0400051B RID: 1307
		[Header("Fire Action")]
		[SerializeField]
		protected float m_fireInActionSpeed = 6f;

		// Token: 0x0400051C RID: 1308
		[SerializeField]
		protected float m_fireOutActionSpeed = 6f;

		// Token: 0x0400051D RID: 1309
		[SerializeField]
		[ReadOnlyUI]
		protected float m_currentFireActionTarget;

		// Token: 0x0400051E RID: 1310
		[SerializeField]
		[ReadOnlyUI]
		protected float m_currentFireActionValue;

		// Token: 0x0400051F RID: 1311
		[SerializeField]
		[ReadOnlyUI]
		protected float m_currentFireActionSpeedMod = 1f;

		// Token: 0x04000520 RID: 1312
		[SerializeField]
		[ReadOnlyUI]
		protected float m_currentFireActionSpeedPerSecond;

		// Token: 0x04000522 RID: 1314
		private bool m_waitForInputRelease;

		// Token: 0x02000143 RID: 323
		// (Invoke) Token: 0x0600065D RID: 1629
		public delegate void OnFireActionWeightUpdatedHandler(float lastValue, float currentValue, float changeVelocityPerSecond, bool changed, bool increasing, GrabbablePropFireAction sender);
	}
}
