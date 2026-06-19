using System;
using Assets.Base.Bones.Gizmos.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.CustomPoses
{
	// Token: 0x02000191 RID: 401
	public class BlockearActualizacionDeCalculoDeEstimuloEnEditarPose : CustomMonobehaviour, CalculoDeEstimuloEnFrame.IPuedeActualizarse
	{
		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06000974 RID: 2420 RVA: 0x0002EFF5 File Offset: 0x0002D1F5
		public bool blockeando
		{
			get
			{
				return this.m_blockeando;
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06000975 RID: 2421 RVA: 0x0002EFFD File Offset: 0x0002D1FD
		bool CalculoDeEstimuloEnFrame.IPuedeActualizarse.puedeActualizarse
		{
			get
			{
				this.m_blockeando = Singleton<SkeletonEditorMode>.instance.activado;
				return !this.m_blockeando;
			}
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x0002F018 File Offset: 0x0002D218
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_character = base.GetComponentInParent<Character>();
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
		}

		// Token: 0x04000704 RID: 1796
		[ReadOnlyUI]
		[SerializeField]
		private bool m_blockeando;

		// Token: 0x04000705 RID: 1797
		private Character m_character;
	}
}
