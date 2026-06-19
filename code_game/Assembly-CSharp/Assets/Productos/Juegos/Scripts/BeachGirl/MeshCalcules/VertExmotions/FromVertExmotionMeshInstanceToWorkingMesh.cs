using System;
using Assets.Scripts.MeshCalcules;
using Kalagaan;
using UnityEngine;

namespace Assets.Productos.Juegos.Scripts.BeachGirl.MeshCalcules.VertExmotions
{
	// Token: 0x02000094 RID: 148
	[RequireComponent(typeof(IUnmaganedWorkingMesh))]
	[RequireComponent(typeof(VertExmotionBase))]
	public class FromVertExmotionMeshInstanceToWorkingMesh : CustomMonobehaviour
	{
		// Token: 0x060002FB RID: 763 RVA: 0x00010C38 File Offset: 0x0000EE38
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			IUnmaganedWorkingMesh component = base.GetComponent<IUnmaganedWorkingMesh>();
			VertExmotionBase component2 = base.GetComponent<VertExmotionBase>();
			if (component.isInitiated)
			{
				throw new InvalidOperationException();
			}
			if (!component2.m_meshCopy)
			{
				throw new NotSupportedException();
			}
			component.SetWorkingMesh(component2.m_mesh);
		}
	}
}
