using System;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000039 RID: 57
	public abstract class JointedSkinBase : ConvexDynamicSkin, IJoinedHitSkin
	{
		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060001B8 RID: 440
		public abstract RecalculableJointBase recalculableJoint { get; }

		// Token: 0x060001B9 RID: 441 RVA: 0x00007657 File Offset: 0x00005857
		public void Suavizar(float springVal, float damperVal, bool silence, Object modificadorOrigen)
		{
			if (!this.recalculableJoint.isStared)
			{
				throw new NotSupportedException("Joint no ha comenzado");
			}
			this.recalculableJoint.suavizaciones.suavisable.ObtenerModificadorNotNull(modificadorOrigen).SetAllTo(springVal, damperVal, silence);
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00007690 File Offset: 0x00005890
		public void DejarDeSuavizar(Object modificadorOrigen)
		{
			if (!this.recalculableJoint.isStared)
			{
				throw new NotSupportedException("Joint no ha comenzado");
			}
			this.recalculableJoint.suavizaciones.suavisable.RemoverModificador(modificadorOrigen);
		}

		// Token: 0x060001BB RID: 443 RVA: 0x000076C0 File Offset: 0x000058C0
		public void Distanciar(float pezonDistanceMod, bool silence, Object modificadorOrigen)
		{
			if (!this.recalculableJoint.isStared)
			{
				throw new NotSupportedException("Joint no ha comenzado");
			}
			this.recalculableJoint.estiraciones.estirable.ObtenerModificadorNotNull(modificadorOrigen).SetZTargetPositionTo(pezonDistanceMod, silence);
		}

		// Token: 0x060001BC RID: 444 RVA: 0x000076F7 File Offset: 0x000058F7
		public void DejarDeDistanciar(Object modificadorOrigen)
		{
			if (!this.recalculableJoint.isStared)
			{
				throw new NotSupportedException("Joint no ha comenzado");
			}
			this.recalculableJoint.estiraciones.estirable.RemoverModificador(modificadorOrigen);
		}
	}
}
