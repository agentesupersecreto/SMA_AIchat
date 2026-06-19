using System;
using Assets.Base.Behaviours.Runtime.Bones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using InterfaceFields;
using UnityEngine;

namespace Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones.Utilidades
{
	// Token: 0x0200003D RID: 61
	[RequireComponent(typeof(Interaccion))]
	public class BlendInteractionRootJustBeforeExecuting : CustomMonobehaviour
	{
		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000299 RID: 665 RVA: 0x0000DB0D File Offset: 0x0000BD0D
		// (set) Token: 0x0600029A RID: 666 RVA: 0x0000DB1A File Offset: 0x0000BD1A
		private IBlender blender
		{
			get
			{
				return this.m_blender as IBlender;
			}
			set
			{
				this.m_blender = value as Object;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x0600029B RID: 667 RVA: 0x0000DB28 File Offset: 0x0000BD28
		// (set) Token: 0x0600029C RID: 668 RVA: 0x0000DB35 File Offset: 0x0000BD35
		private IPoseTarget target
		{
			get
			{
				return this.m_target as IPoseTarget;
			}
			set
			{
				this.m_target = value as Object;
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000DB43 File Offset: 0x0000BD43
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Interaccion = base.GetComponent<Interaccion>();
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000DB57 File Offset: 0x0000BD57
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (this.blender == null)
			{
				throw new ArgumentNullException("blender", "blender null reference.");
			}
			if (this.target == null)
			{
				throw new ArgumentNullException("target", "target null reference.");
			}
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000DB8F File Offset: 0x0000BD8F
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_Interaccion.justAntesDeEjecutar += this.M_Interaccion_justAntesDeEjecutar;
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000DBAE File Offset: 0x0000BDAE
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_Interaccion.justAntesDeEjecutar -= this.M_Interaccion_justAntesDeEjecutar;
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000DBCE File Offset: 0x0000BDCE
		private void M_Interaccion_justAntesDeEjecutar(Interaccion obj)
		{
			this.blender.Blend(this.m_Interaccion.owner.character, this.target, base.transform);
		}

		// Token: 0x040001C8 RID: 456
		private Interaccion m_Interaccion;

		// Token: 0x040001C9 RID: 457
		[ConstraintType(typeof(IBlender), true)]
		[SerializeField]
		private Object m_blender;

		// Token: 0x040001CA RID: 458
		[ConstraintType(typeof(IPoseTarget), true)]
		[SerializeField]
		private Object m_target;
	}
}
