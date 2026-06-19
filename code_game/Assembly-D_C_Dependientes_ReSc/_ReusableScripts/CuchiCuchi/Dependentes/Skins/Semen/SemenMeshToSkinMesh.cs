using System;
using Assets.TValle.MeshCalcules.ShapingSkinningPoints.Runtime.Triangles.SkinningShaping;
using Assets._ReusableScripts.CuchiCuchi.Skins.Semen;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Skins.Semen
{
	// Token: 0x02000048 RID: 72
	[RequireComponent(typeof(SemenPuntoCollisionContraSkin))]
	public class SemenMeshToSkinMesh : CustomMonobehaviour
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060001AA RID: 426 RVA: 0x0000BEF0 File Offset: 0x0000A0F0
		public SemenPuntoCollisionContraSkin semenPuntoCollisionContraSkin
		{
			get
			{
				return this.m_SemenPuntoCollisionContraSkin;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060001AB RID: 427 RVA: 0x0000BEF8 File Offset: 0x0000A0F8
		public SkinAndShapeTransformToTriangleSurfaceUser triangleAttachmentUser
		{
			get
			{
				return this.m_SemenPuntoCollisionContraSkin.triangleAttachmentUser;
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000BF05 File Offset: 0x0000A105
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_SemenPuntoCollisionContraSkin = base.GetComponent<SemenPuntoCollisionContraSkin>();
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0000BF1C File Offset: 0x0000A11C
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_SemenPuntoCollisionContraSkin.onAttached += this.M_SemenPuntoCollisionContraSkin_onAttached;
			this.m_SemenPuntoCollisionContraSkin.onNextAttached += this.M_SemenPuntoCollisionContraSkin_onNextAttached;
			this.m_SemenPuntoCollisionContraSkin.onNextBrokenAfterAttached += this.M_SemenPuntoCollisionContraSkin_onNextBrokenAfterAttached;
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0000BF74 File Offset: 0x0000A174
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.UnSub();
		}

		// Token: 0x060001AF RID: 431 RVA: 0x0000BF84 File Offset: 0x0000A184
		private void UnSub()
		{
			if (this.m_SemenPuntoCollisionContraSkin != null)
			{
				this.m_SemenPuntoCollisionContraSkin.onAttached -= this.M_SemenPuntoCollisionContraSkin_onAttached;
				this.m_SemenPuntoCollisionContraSkin.onNextAttached -= this.M_SemenPuntoCollisionContraSkin_onNextAttached;
				this.m_SemenPuntoCollisionContraSkin.onNextBrokenAfterAttached -= this.M_SemenPuntoCollisionContraSkin_onNextBrokenAfterAttached;
			}
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0000BFE4 File Offset: 0x0000A1E4
		private void M_SemenPuntoCollisionContraSkin_onAttached(SemenPuntoCollisionContraSkin obj)
		{
			if (!obj.IsNextNullOrAttachedToSameSkin())
			{
				return;
			}
			this.AddToController(true);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x0000BFF6 File Offset: 0x0000A1F6
		private void M_SemenPuntoCollisionContraSkin_onNextAttached(SemenPuntoCollisionContraSkin obj)
		{
			if (!obj.isAttachedToSkin || !obj.IsNextNullOrAttachedToSameSkin())
			{
				return;
			}
			this.AddToController(true);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0000C010 File Offset: 0x0000A210
		private void M_SemenPuntoCollisionContraSkin_onNextBrokenAfterAttached(SemenPuntoCollisionContraSkin obj)
		{
			if (!obj.isAttachedToSkin)
			{
				return;
			}
			this.AddToController(false);
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00002BEA File Offset: 0x00000DEA
		public void OnConvertedToSkin()
		{
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0000C024 File Offset: 0x0000A224
		public bool CanBeDestroyedWhenConvertedToSkin()
		{
			return !(this.m_SemenPuntoCollisionContraSkin.semenPunto.previus != null) || !(this.m_SemenPuntoCollisionContraSkin.semenPunto.previus.GetComponent<SemenPuntoCollisionContraSkin>().attachedTo != this.m_SemenPuntoCollisionContraSkin.attachedTo);
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x0000C078 File Offset: 0x0000A278
		private void AddToController(bool tryIncludeNext)
		{
			SemenSkinController componentNotNull = this.m_SemenPuntoCollisionContraSkin.attachedTo.GetComponentNotNull<SemenSkinController>();
			if (tryIncludeNext && this.m_SemenPuntoCollisionContraSkin.semenPunto.next != null)
			{
				componentNotNull.Add(this, this.m_SemenPuntoCollisionContraSkin.semenPunto.next.GetComponent<SemenMeshToSkinMesh>());
			}
			else
			{
				componentNotNull.Add(this, null);
			}
			this.UnSub();
		}

		// Token: 0x0400018A RID: 394
		private SemenPuntoCollisionContraSkin m_SemenPuntoCollisionContraSkin;
	}
}
