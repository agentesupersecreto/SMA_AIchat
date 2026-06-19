using System;
using Assets._ReusableScripts.CuchiCuchi;
using InterfaceFields;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000012 RID: 18
	public sealed class CurrentMainChar : CurrentMainCharacter<CurrentMainChar, MainChar>
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00002526 File Offset: 0x00000726
		public CurrentMainChar.ICamera camara
		{
			get
			{
				if (this.m_Camera == null)
				{
					return null;
				}
				return this.m_Camera as CurrentMainChar.ICamera;
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002543 File Offset: 0x00000743
		public void SetCamera(CurrentMainChar.ICamera camara)
		{
			if (camara == null)
			{
				throw new ArgumentNullException("camara", "camara null reference.");
			}
			this.m_Camera = camara as Object;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002564 File Offset: 0x00000764
		public void ClearCamera()
		{
			this.m_Camera = null;
		}

		// Token: 0x0400003E RID: 62
		[ConstraintType(typeof(CurrentMainChar.ICamera), true)]
		[SerializeField]
		private Object m_Camera;

		// Token: 0x0200013F RID: 319
		public interface ICamera
		{
			// Token: 0x170004C3 RID: 1219
			// (get) Token: 0x06000D9E RID: 3486
			// (set) Token: 0x06000D9F RID: 3487
			CurrentMainChar.AnchorMode anchorMode { get; set; }

			// Token: 0x170004C4 RID: 1220
			// (get) Token: 0x06000DA0 RID: 3488
			Camera camara { get; }

			// Token: 0x170004C5 RID: 1221
			// (get) Token: 0x06000DA1 RID: 3489
			Transform cameraTransform { get; }

			// Token: 0x06000DA2 RID: 3490
			void UpdateCamera();

			// Token: 0x06000DA3 RID: 3491
			void Ver(Vector3 point);

			// Token: 0x06000DA4 RID: 3492
			void ForzarVista(Vector3 point);

			// Token: 0x06000DA5 RID: 3493
			void DejarDeForzarVista();
		}

		// Token: 0x02000140 RID: 320
		public enum AnchorMode
		{
			// Token: 0x040007AA RID: 1962
			animatorRootMotion,
			// Token: 0x040007AB RID: 1963
			interactedRootMotion
		}
	}
}
