using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.TValle.BeachGirl.Runtime.Characteres;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Props
{
	// Token: 0x0200014A RID: 330
	public class GrabbableDefinedPropConSensores : GrabbableDefinedProp, IGrabablePropConSensores, IGrabableProp
	{
		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000679 RID: 1657 RVA: 0x00023970 File Offset: 0x00021B70
		public bool propEstaActivo
		{
			get
			{
				return base.estado == GrabbablePropEstado.Grabbed || base.estado == GrabbablePropEstado.NotGrabbedButActivated;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x0600067A RID: 1658 RVA: 0x00023986 File Offset: 0x00021B86
		[TupleElementNames(new string[] { "sensorTransform", "sensorWorldRadius" })]
		public IReadOnlyList<ValueTuple<Transform, float>> sensorsData
		{
			[return: TupleElementNames(new string[] { "sensorTransform", "sensorWorldRadius" })]
			get
			{
				return this.m_sensoresData;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x0600067B RID: 1659 RVA: 0x0002398E File Offset: 0x00021B8E
		public bool linkedSensors
		{
			get
			{
				return this.m_sensoresLinked;
			}
		}

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x0600067C RID: 1660 RVA: 0x00023998 File Offset: 0x00021B98
		// (remove) Token: 0x0600067D RID: 1661 RVA: 0x000239D0 File Offset: 0x00021BD0
		public event Action<EmulatedSphereTrigger[], GrabbableDefinedPropConSensores> updatingSensoresData;

		// Token: 0x0600067E RID: 1662 RVA: 0x00023A08 File Offset: 0x00021C08
		public void UpdateSensorsData()
		{
			Action<EmulatedSphereTrigger[], GrabbableDefinedPropConSensores> action = this.updatingSensoresData;
			if (action != null)
			{
				action(this.m_sensores, this);
			}
			if (this.m_sensoresData == null || this.m_sensoresData.Length != this.m_sensores.Length)
			{
				this.m_sensoresData = new ValueTuple<Transform, float>[this.m_sensores.Length];
			}
			float num = this.m_root.lossyScale.Escala();
			for (int i = 0; i < this.m_sensores.Length; i++)
			{
				EmulatedSphereTrigger emulatedSphereTrigger = this.m_sensores[i];
				this.m_sensoresData[i] = new ValueTuple<Transform, float>(emulatedSphereTrigger.transform, emulatedSphereTrigger.radius * num);
			}
		}

		// Token: 0x04000531 RID: 1329
		[TupleElementNames(new string[] { "sensorTransform", "sensorWorldRadius" })]
		private ValueTuple<Transform, float>[] m_sensoresData;

		// Token: 0x04000532 RID: 1330
		[Header("Sensores")]
		[SerializeField]
		private EmulatedSphereTrigger[] m_sensores = new EmulatedSphereTrigger[0];

		// Token: 0x04000533 RID: 1331
		[SerializeField]
		private bool m_sensoresLinked;
	}
}
