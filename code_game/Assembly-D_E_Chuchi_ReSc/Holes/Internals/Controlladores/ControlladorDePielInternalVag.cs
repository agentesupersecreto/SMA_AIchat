using System;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Controlladores
{
	// Token: 0x020001B9 RID: 441
	public class ControlladorDePielInternalVag : AplicableBehaviour
	{
		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000A63 RID: 2659 RVA: 0x000260A9 File Offset: 0x000242A9
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterFixedUpdates1);
			}
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x0002F2E0 File Offset: 0x0002D4E0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_vagInternals = base.GetComponentInParent<VagInternals>();
			if (this.m_vagInternals == null)
			{
				throw new ArgumentNullException("m_vagInternals", "m_vagInternals null reference.");
			}
			this.m_shapes = base.GetComponent<ControlladorDeShapeDeVagInternals>();
			if (!this.m_shapes.isAwaken)
			{
				this.m_shapes.ManualAwake();
			}
			ControlladorDePielInternalVag.InitMaxValues(ControlladorDePielInternalVag.canal000Shapes, this.m_shapes, this, ref this.canal000MaxValues);
			ControlladorDePielInternalVag.InitMaxValues(ControlladorDePielInternalVag.canal001Shapes, this.m_shapes, this, ref this.canal001MaxValues);
			ControlladorDePielInternalVag.InitMaxValues(ControlladorDePielInternalVag.canal002Shapes, this.m_shapes, this, ref this.canal002MaxValues);
			ControlladorDePielInternalVag.InitMaxValues(ControlladorDePielInternalVag.canal003Shapes, this.m_shapes, this, ref this.canal003MaxValues);
			ControlladorDePielInternalVag.InitMaxValues(ControlladorDePielInternalVag.canal004Shapes, this.m_shapes, this, ref this.canal004MaxValues);
			ControlladorDePielInternalVag.InitMaxValues(ControlladorDePielInternalVag.canal005Shapes, this.m_shapes, this, ref this.canal005MaxValues);
			ControlladorDePielInternalVag.InitMaxValues(ControlladorDePielInternalVag.capsuleShapes, this.m_shapes, this, ref this.capsuleMaxValues);
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x0002F3E4 File Offset: 0x0002D5E4
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeFloat[] array = this.canal000MaxValues;
			if (array != null)
			{
				array.ForEach(delegate(ModificadorDeFloat m)
				{
					if (m != null)
					{
						m.TryRemoverDeOwner(true);
					}
				});
			}
			ModificadorDeFloat[] array2 = this.canal001MaxValues;
			if (array2 != null)
			{
				array2.ForEach(delegate(ModificadorDeFloat m)
				{
					if (m != null)
					{
						m.TryRemoverDeOwner(true);
					}
				});
			}
			ModificadorDeFloat[] array3 = this.canal002MaxValues;
			if (array3 != null)
			{
				array3.ForEach(delegate(ModificadorDeFloat m)
				{
					if (m != null)
					{
						m.TryRemoverDeOwner(true);
					}
				});
			}
			ModificadorDeFloat[] array4 = this.canal003MaxValues;
			if (array4 != null)
			{
				array4.ForEach(delegate(ModificadorDeFloat m)
				{
					if (m != null)
					{
						m.TryRemoverDeOwner(true);
					}
				});
			}
			ModificadorDeFloat[] array5 = this.canal004MaxValues;
			if (array5 != null)
			{
				array5.ForEach(delegate(ModificadorDeFloat m)
				{
					if (m != null)
					{
						m.TryRemoverDeOwner(true);
					}
				});
			}
			ModificadorDeFloat[] array6 = this.canal005MaxValues;
			if (array6 != null)
			{
				array6.ForEach(delegate(ModificadorDeFloat m)
				{
					if (m != null)
					{
						m.TryRemoverDeOwner(true);
					}
				});
			}
			ModificadorDeFloat[] array7 = this.capsuleMaxValues;
			if (array7 == null)
			{
				return;
			}
			array7.ForEach(delegate(ModificadorDeFloat m)
			{
				if (m != null)
				{
					m.TryRemoverDeOwner(true);
				}
			});
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x0002F548 File Offset: 0x0002D748
		private static void InitMaxValues(string[] shapeNames, ControlladorDeShapeDeVagInternals shapesMods, ControlladorDePielInternalVag controller, ref ModificadorDeFloat[] result)
		{
			result = new ModificadorDeFloat[shapeNames.Length];
			for (int i = 0; i < shapeNames.Length; i++)
			{
				string text = shapeNames[i];
				result[i] = shapesMods.GetModificablesDeShape(text).ObtenerMaxValorableNotNull(controller);
			}
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x0002F584 File Offset: 0x0002D784
		public override void OnUpdateEvent1()
		{
			ControlladorDePielInternalVag.UpdateBoneMods(this.canal000Bone, this.m_vagInternals, this.canal000MaxValues);
			ControlladorDePielInternalVag.UpdateBoneMods(this.canal001Bone, this.m_vagInternals, this.canal001MaxValues);
			ControlladorDePielInternalVag.UpdateBoneMods(this.canal002Bone, this.m_vagInternals, this.canal002MaxValues);
			ControlladorDePielInternalVag.UpdateBoneMods(this.canal003Bone, this.m_vagInternals, this.canal003MaxValues);
			ControlladorDePielInternalVag.UpdateBoneMods(this.canal004Bone, this.m_vagInternals, this.canal004MaxValues);
			ControlladorDePielInternalVag.UpdateBoneMods(this.canal005Bone, this.m_vagInternals, this.canal005MaxValues);
			ControlladorDePielInternalVag.UpdateBoneMods(this.capsuleBone, this.m_vagInternals, this.capsuleMaxValues);
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x0002F634 File Offset: 0x0002D834
		private static void UpdateBoneMods(Transform bone, VagInternals internals, ModificadorDeFloat[] maxValues)
		{
			HoleInternal.InternalPoint internalPoint = internals.allPuntosDicc[bone];
			float num = (1f - internalPoint.penetrationInfluenceW) * 100f;
			for (int i = 0; i < maxValues.Length; i++)
			{
				maxValues[i].valor.valor = num;
			}
		}

		// Token: 0x04000844 RID: 2116
		private static readonly string[] canal000Shapes = new string[] { "CanalCama", "BeforePenSurfDefCanal000", "BeforePenSurfDef2Canal000" };

		// Token: 0x04000845 RID: 2117
		private static readonly string[] canal001Shapes = new string[] { "BeforePenSurfDefCanal001", "BeforePenSurfDef2Canal001" };

		// Token: 0x04000846 RID: 2118
		private static readonly string[] canal002Shapes = new string[] { "BeforePenSurfDefCanal002", "BeforePenSurfDef2Canal002" };

		// Token: 0x04000847 RID: 2119
		private static readonly string[] canal003Shapes = new string[] { "BeforePenSurfDefCanal003", "BeforePenSurfDef2Canal003" };

		// Token: 0x04000848 RID: 2120
		private static readonly string[] canal004Shapes = new string[] { "BeforePenSurfDefCanal004", "BeforePenSurfDef2Canal004" };

		// Token: 0x04000849 RID: 2121
		private static readonly string[] canal005Shapes = new string[] { "BeforePenSurfDefCanal005", "BeforePenSurfDef2Canal005" };

		// Token: 0x0400084A RID: 2122
		private static readonly string[] capsuleShapes = new string[] { "CervixCapsulePliegues1", "CervixCapsulePliegues2", "CervixCapsulePliegues3", "CervixCapsulePliegues4", "CervixCapsulePliegues5", "CervixCapsuleVariacion1", "CervixCapsuleVariacion2", "CervixCapsuleVariacion3", "CervixCapsuleApertura" };

		// Token: 0x0400084B RID: 2123
		private VagInternals m_vagInternals;

		// Token: 0x0400084C RID: 2124
		private ControlladorDeShapeDeVagInternals m_shapes;

		// Token: 0x0400084D RID: 2125
		private ModificadorDeFloat[] canal000MaxValues;

		// Token: 0x0400084E RID: 2126
		private ModificadorDeFloat[] canal001MaxValues;

		// Token: 0x0400084F RID: 2127
		private ModificadorDeFloat[] canal002MaxValues;

		// Token: 0x04000850 RID: 2128
		private ModificadorDeFloat[] canal003MaxValues;

		// Token: 0x04000851 RID: 2129
		private ModificadorDeFloat[] canal004MaxValues;

		// Token: 0x04000852 RID: 2130
		private ModificadorDeFloat[] canal005MaxValues;

		// Token: 0x04000853 RID: 2131
		private ModificadorDeFloat[] capsuleMaxValues;

		// Token: 0x04000854 RID: 2132
		[SerializeField]
		private Transform canal000Bone;

		// Token: 0x04000855 RID: 2133
		[SerializeField]
		private Transform canal001Bone;

		// Token: 0x04000856 RID: 2134
		[SerializeField]
		private Transform canal002Bone;

		// Token: 0x04000857 RID: 2135
		[SerializeField]
		private Transform canal003Bone;

		// Token: 0x04000858 RID: 2136
		[SerializeField]
		private Transform canal004Bone;

		// Token: 0x04000859 RID: 2137
		[SerializeField]
		private Transform canal005Bone;

		// Token: 0x0400085A RID: 2138
		[SerializeField]
		private Transform capsuleBone;
	}
}
