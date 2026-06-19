using System;
using System.Collections;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.Globales.Clases;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Penes
{
	// Token: 0x02000098 RID: 152
	public class PenisLocalRotationUserControl : AplicableBehaviour
	{
		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x0600048B RID: 1163 RVA: 0x0000EAE0 File Offset: 0x0000CCE0
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update2);
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x0600048C RID: 1164 RVA: 0x0000EAE8 File Offset: 0x0000CCE8
		public bool activo
		{
			get
			{
				return this.m_activadoOR.Or(this.m_activado) && base.enabled;
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x0600048D RID: 1165 RVA: 0x0000EB05 File Offset: 0x0000CD05
		public ModificableDeBool activadoOR
		{
			get
			{
				return this.m_activadoOR;
			}
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x0000EB0D File Offset: 0x0000CD0D
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetYieldStart();
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x0000EB1B File Offset: 0x0000CD1B
		protected override IEnumerator YieldStartUnityEvent()
		{
			while (this.m_penis == null)
			{
				this.m_penis = this.GetComponentEnRoot(false);
				yield return null;
			}
			while (!this.m_penis.isStared)
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x0000EB2A File Offset: 0x0000CD2A
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_penis.userLocalRotation = Quaternion.identity;
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x0000EB44 File Offset: 0x0000CD44
		public override void OnUpdateEvent1()
		{
			if (!this.activo)
			{
				this.m_penis.userLocalRotation = Quaternion.Slerp(this.m_penis.userLocalRotation, Quaternion.identity, Time.deltaTime);
				return;
			}
			if (!Singleton<PlayerInputProxy>.instance.fire1.heldDown)
			{
				return;
			}
			if (Singleton<PlayerInputProxy>.instance.fire2.heldDown)
			{
				return;
			}
			InputProxyVirtuales toolMovement = Singleton<PlayerInputProxy>.instance.toolMovement;
			if (!toolMovement.goingDown || toolMovement.wheelAxis != 0f)
			{
				return;
			}
			ConfiguracionGeneralDeInputs.Axis2D viewportRotation = Singleton<ConfiguracionGeneralDeInputs>.instance.viewportRotation;
			float num = 1f;
			if (toolMovement.goingFaster)
			{
				num *= 2f;
			}
			if (toolMovement.goingSlower)
			{
				num /= 2f;
			}
			float num2 = viewportRotation.sensivilidadGeneral * this.m_sensivilidadRotation * num;
			float num3 = toolMovement.MouseXAxis * num2 * viewportRotation.sensivilidadX;
			float num4 = toolMovement.MouseYAxis * num2 * viewportRotation.sensivilidadY;
			this.m_penis.userLocalRotation *= Quaternion.AngleAxis(num3, Vector3.up) * Quaternion.AngleAxis(-num4, Vector3.right);
			Vector3 vector = this.m_penis.userLocalRotation.eulerAngles.PolarizarAngulos();
			this.m_penis.userLocalRotation = Quaternion.AngleAxis(Mathf.Clamp(vector.y, -this.m_maxUpAngle, this.m_maxUpAngle), Vector3.up) * Quaternion.AngleAxis(Mathf.Clamp(vector.x, -this.m_maxRightAngle, this.m_maxRightAngle), Vector3.right);
		}

		// Token: 0x040002A8 RID: 680
		[SerializeField]
		private bool m_activado;

		// Token: 0x040002A9 RID: 681
		[SerializeField]
		private float m_sensivilidadRotation = 2f;

		// Token: 0x040002AA RID: 682
		[SerializeField]
		private float m_maxUpAngle = 60f;

		// Token: 0x040002AB RID: 683
		[SerializeField]
		private float m_maxRightAngle = 60f;

		// Token: 0x040002AC RID: 684
		private ModificableDeBool m_activadoOR = new ModificableDeBool(false);

		// Token: 0x040002AD RID: 685
		private Penis m_penis;
	}
}
