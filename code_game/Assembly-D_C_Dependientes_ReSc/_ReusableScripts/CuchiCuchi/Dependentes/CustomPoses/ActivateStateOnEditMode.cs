using System;
using System.Collections.Generic;
using Assets.Base.Bones.Gizmos.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using InterfaceFields;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.CustomPoses
{
	// Token: 0x02000190 RID: 400
	public class ActivateStateOnEditMode : CustomMonobehaviour
	{
		// Token: 0x06000970 RID: 2416 RVA: 0x0002EE8C File Offset: 0x0002D08C
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_modificadoresDeTargets.Clear();
			for (int i = 0; i < this.m_IActivableModificableObjects.Count; i++)
			{
				IActivableModificable activableModificable = this.m_IActivableModificableObjects[i] as IActivableModificable;
				if (activableModificable != null)
				{
					ModificadorDeBool modificadorDeBool = activableModificable.activadoModificable.ObtenerModificadorNotNull(this);
					modificadorDeBool.valor.valor = true;
					this.m_modificadoresDeTargets.Add(modificadorDeBool);
				}
			}
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x0002EEFC File Offset: 0x0002D0FC
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			for (int i = 0; i < this.m_modificadoresDeTargets.Count; i++)
			{
				ModificadorDeBool modificadorDeBool = this.m_modificadoresDeTargets[i];
				if (modificadorDeBool != null)
				{
					modificadorDeBool.TryRemoverDeOwner(true);
				}
			}
			this.m_modificadoresDeTargets.Clear();
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x0002EF4C File Offset: 0x0002D14C
		private void Update()
		{
			bool flag = (Singleton<SkeletonEditorMode>.instance.activado ? this.stateOnEditing : this.stateOnNoEditing);
			if (this.lastState != null)
			{
				bool? flag2 = this.lastState;
				bool flag3 = flag;
				if ((flag2.GetValueOrDefault() == flag3) & (flag2 != null))
				{
					return;
				}
			}
			this.lastState = new bool?(flag);
			for (int i = 0; i < this.m_modificadoresDeTargets.Count; i++)
			{
				this.m_modificadoresDeTargets[i].valor.valor = flag;
			}
		}

		// Token: 0x040006FF RID: 1791
		private bool? lastState;

		// Token: 0x04000700 RID: 1792
		public bool stateOnEditing;

		// Token: 0x04000701 RID: 1793
		public bool stateOnNoEditing;

		// Token: 0x04000702 RID: 1794
		[ConstraintType(typeof(IActivableModificable), true)]
		[SerializeField]
		private List<Object> m_IActivableModificableObjects = new List<Object>();

		// Token: 0x04000703 RID: 1795
		private List<ModificadorDeBool> m_modificadoresDeTargets = new List<ModificadorDeBool>();
	}
}
