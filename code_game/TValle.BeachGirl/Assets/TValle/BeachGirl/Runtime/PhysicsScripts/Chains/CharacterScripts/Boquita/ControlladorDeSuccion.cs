using System;
using Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Controlladores;
using Assets._ReusableScripts;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts.Boquita
{
	// Token: 0x02000087 RID: 135
	public class ControlladorDeSuccion : ControllerColaDePrioridadBase<ControlladorDeSuccion.Stado, ControlladorDeSuccion.Orden, ControlladorDeSuccion.Colas, ControlladorDeSuccion, int>, ICharacterChupador
	{
		// Token: 0x17000196 RID: 406
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x0000B719 File Offset: 0x00009919
		public bool presionEstaAislada
		{
			get
			{
				return this.m_boca.presionEstaAislada;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x0000B726 File Offset: 0x00009926
		public bool estaChupandoPene
		{
			get
			{
				return this.m_estaChupando && this.presionEstaAislada && this.m_boca.hole.isPenetrated;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x0000B74A File Offset: 0x0000994A
		public float aislamientoWeight
		{
			get
			{
				if (!this.m_boca.presionEstaAislada)
				{
					return 0f;
				}
				return this.m_boca.aisladoWeight;
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x0000B76A File Offset: 0x0000996A
		protected override int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x060003C4 RID: 964 RVA: 0x0000B76D File Offset: 0x0000996D
		protected override GlobalUpdater.UpdateType? updateTypeAutomatico
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x060003C5 RID: 965 RVA: 0x0000B775 File Offset: 0x00009975
		public override int cantidadMaximaEnCola
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x060003C6 RID: 966 RVA: 0x0000B778 File Offset: 0x00009978
		public bool estaChupando
		{
			get
			{
				return this.m_estaChupando;
			}
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0000B780 File Offset: 0x00009980
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ControlladorDeSuccionJoints = this.GetComponentEnRoot(false);
			if (this.m_ControlladorDeSuccionJoints == null)
			{
				throw new ArgumentNullException("m_ControlladorDeSuccionJoints", "m_ControlladorDeSuccionJoints null reference.");
			}
			this.m_boca = this.GetComponentEnRoot(false);
			this.m_LabiosSuckPose = this.m_boca.labiosSuckPose;
			if (this.m_LabiosSuckPose == null)
			{
				throw new ArgumentNullException("m_LabiosSuckPose", "m_LabiosSuckPose null reference.");
			}
			this.CheckModsInstances();
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x0000B800 File Offset: 0x00009A00
		private void CheckModsInstances()
		{
			this.m_minWeigthModificador = this.m_LabiosSuckPose.minValorModificable.ObtenerModificadorNotNull(this);
			this.m_weigthModificador = this.m_LabiosSuckPose.valorModificable.ObtenerModificadorNotNull(this);
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0000B830 File Offset: 0x00009A30
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeFloat minWeigthModificador = this.m_minWeigthModificador;
			if (minWeigthModificador != null)
			{
				minWeigthModificador.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat weigthModificador = this.m_weigthModificador;
			if (weigthModificador == null)
			{
				return;
			}
			weigthModificador.TryRemoverDeOwner(true);
		}

		// Token: 0x060003CA RID: 970 RVA: 0x0000B85E File Offset: 0x00009A5E
		protected override void ControllerUpdated()
		{
			ControlladorDeSuccion.Orden orden = base.currentStado.FirstOrDefaultEjecutandose();
			this.m_estaChupando = orden != null && orden.weight > 0.01f;
		}

		// Token: 0x060003CB RID: 971 RVA: 0x0000B884 File Offset: 0x00009A84
		public bool Chupar(float weight, int prioridad, ControllerPrioridadConfig priConfig, float duracion, float InTime, float OutTime, Func<bool> isValidToSuck = null, Func<bool> isValidToJoint = null, ControlladorDeSuccion.JointData jointData = default(ControlladorDeSuccion.JointData))
		{
			bool flag = false;
			ControlladorDeSuccion.Orden orden;
			bool flag2;
			bool flag3;
			if (!base.VerificarSiPuedeEjecutarse(out orden, out flag2, 0, prioridad, priConfig, out flag3, ref flag, true))
			{
				return false;
			}
			if (isValidToSuck == null)
			{
				isValidToSuck = this.m_ConstantTrue;
			}
			if (isValidToJoint == null)
			{
				isValidToJoint = this.m_ConstantTrue;
			}
			ControlladorDeSuccion.Orden orden2;
			ControllerColaDePrioridadBaseBase.TipoDeReUsoDeOrden tipoDeReUsoDeOrden;
			if (base.PuedeAcumularseORevivir(orden, out orden2, priConfig, 0, out tipoDeReUsoDeOrden))
			{
				orden2.isValidToSuck = isValidToSuck;
				orden2.isValidToJoint = isValidToJoint;
				orden2.weight = weight;
				orden2.inTime = InTime;
				orden2.outTime = OutTime;
				orden2.jointData = jointData;
				base.AcumularseORevivir(orden2, duracion, prioridad, tipoDeReUsoDeOrden, null, null);
				return true;
			}
			if (flag3 && !flag)
			{
				return false;
			}
			ControlladorDeSuccion.Orden orden3 = new ControlladorDeSuccion.Orden(isValidToJoint, isValidToSuck, weight, prioridad, priConfig, duracion, InTime, OutTime, jointData);
			base.Procesar(orden == null, flag2, priConfig, orden3, false, false);
			return true;
		}

		// Token: 0x060003CC RID: 972 RVA: 0x0000B945 File Offset: 0x00009B45
		public override int ParseIndexToTipoId(int index)
		{
			return index;
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0000B948 File Offset: 0x00009B48
		public override int ParseTipoIdToindex(int tipoId)
		{
			return tipoId;
		}

		// Token: 0x060003CE RID: 974 RVA: 0x0000B94B File Offset: 0x00009B4B
		protected override ControlladorDeSuccion ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x0400022F RID: 559
		[SerializeField]
		[ReadOnlyUI]
		private bool m_estaChupando;

		// Token: 0x04000230 RID: 560
		[SerializeField]
		private ModificadorDeFloat m_minWeigthModificador;

		// Token: 0x04000231 RID: 561
		[SerializeField]
		private ModificadorDeFloat m_weigthModificador;

		// Token: 0x04000232 RID: 562
		private Boca m_boca;

		// Token: 0x04000233 RID: 563
		private ControlladorDeSuccionJoints m_ControlladorDeSuccionJoints;

		// Token: 0x04000234 RID: 564
		private LabiosSuckPose m_LabiosSuckPose;

		// Token: 0x04000235 RID: 565
		private Func<bool> m_ConstantTrue = () => true;

		// Token: 0x0200017B RID: 379
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<ControlladorDeSuccion.Stado, ControlladorDeSuccion.Orden, ControlladorDeSuccion.Colas, ControlladorDeSuccion, int>.OrdenBaseDeControllador
		{
			// Token: 0x06000E7F RID: 3711 RVA: 0x00031A04 File Offset: 0x0002FC04
			public Orden(Func<bool> IsValidToCreateJoint, Func<bool> IsValidToSuck, float weight, int prioridad, ControllerPrioridadConfig priConfig, float duracion, float InTime, float OutTime, ControlladorDeSuccion.JointData jointData)
				: base(0, prioridad, duracion, priConfig, false)
			{
				this.isValidToSuck = IsValidToSuck;
				this.isValidToJoint = IsValidToCreateJoint;
				this.weight = weight;
				this.inTime = Mathf.Clamp(InTime, 0.001f, float.MaxValue);
				this.outTime = Mathf.Clamp(OutTime, 0.001f, float.MaxValue);
				this.jointData = jointData;
			}

			// Token: 0x06000E80 RID: 3712 RVA: 0x00031A80 File Offset: 0x0002FC80
			public float VelPorWeight(float currentValue)
			{
				return Mathf.Clamp(Mathf.Max(this.weight, currentValue), 0.05f, float.MaxValue);
			}

			// Token: 0x06000E81 RID: 3713 RVA: 0x00031A9D File Offset: 0x0002FC9D
			protected override void OnDetenidaPorUsuario(ControlladorDeSuccion dataUpdate)
			{
			}

			// Token: 0x06000E82 RID: 3714 RVA: 0x00031AA0 File Offset: 0x0002FCA0
			protected override bool OnTerminando(ControlladorDeSuccion dataUpdate, bool primerUpdate, ControlladorDeSuccion.Orden ordenEsperandoDetencion)
			{
				if (this.m_jointOrder != null && !this.m_jointOrder.Termino())
				{
					this.m_jointOrder.Detener(false);
				}
				dataUpdate.m_minWeigthModificador.valor.valor = Mathf.MoveTowards(dataUpdate.m_minWeigthModificador.valor.valor, 0f, this.VelPorWeight(dataUpdate.m_minWeigthModificador.valor.valor) * (1f / this.outTime) * base.estadoDeltaTime);
				dataUpdate.m_weigthModificador.valor.valor = Mathf.MoveTowards(dataUpdate.m_weigthModificador.valor.valor, 1f, this.VelPorWeight(dataUpdate.m_weigthModificador.valor.valor) * (1f / this.outTime) * base.estadoDeltaTime);
				return dataUpdate.m_minWeigthModificador.valor.valor == 0f && dataUpdate.m_weigthModificador.valor.valor == 1f;
			}

			// Token: 0x06000E83 RID: 3715 RVA: 0x00031BA8 File Offset: 0x0002FDA8
			protected override void OnTerminada(ControlladorDeSuccion dataUpdate, bool abruptamente)
			{
				if (this.m_jointOrder != null && !this.m_jointOrder.Termino())
				{
					this.m_jointOrder.Detener(true);
				}
				this.m_jointOrder = null;
				dataUpdate.m_minWeigthModificador.valor.valor = 0f;
				dataUpdate.m_weigthModificador.valor.valor = 1f;
			}

			// Token: 0x06000E84 RID: 3716 RVA: 0x00031C07 File Offset: 0x0002FE07
			protected override void OnStart(ControlladorDeSuccion dataUpdate)
			{
				dataUpdate.CheckModsInstances();
				this.m_ControlladorDeSuccionJoints = dataUpdate.m_ControlladorDeSuccionJoints;
				this.DoJoint();
			}

			// Token: 0x06000E85 RID: 3717 RVA: 0x00031C24 File Offset: 0x0002FE24
			protected override void OnWasReused()
			{
				if (this.m_jointOrder != null && !this.m_jointOrder.Termino() && (this.jointData.slotID != this.m_jointOrder.tipoId || this.jointData.target != this.m_jointOrder.target))
				{
					this.m_jointOrder.Detener(true);
					this.m_jointOrder = null;
				}
				this.DoJoint();
			}

			// Token: 0x06000E86 RID: 3718 RVA: 0x00031C94 File Offset: 0x0002FE94
			private void DoJoint()
			{
				if (!this.jointData.isValid || !this.isValidToJoint())
				{
					if (this.m_jointOrder != null)
					{
						this.m_jointOrder.Detener(true);
						this.m_jointOrder = null;
					}
					return;
				}
				if (this.m_ControlladorDeSuccionJoints.DoSuccion(this.jointData.weigth, this.jointData.maxWorldDistance, this.jointData.slotID, this.jointData.target, base.prioridad, base.priConfig, base.duracion, this.jointData.InTime, this.jointData.OutTime, this.jointData.breakForce, this.isValidToJoint))
				{
					this.m_jointOrder = this.m_ControlladorDeSuccionJoints.justProcesedOrder;
				}
			}

			// Token: 0x06000E87 RID: 3719 RVA: 0x00031D5C File Offset: 0x0002FF5C
			protected override bool UpdateOrden(ControlladorDeSuccion dataUpdate, bool esPrimerUpdate)
			{
				if (this.Termino() || !this.isValidToSuck())
				{
					return false;
				}
				float num;
				float num2;
				ControlladorDeSuccion.Orden.GetMinAndModFromWeight(this.weight, out num, out num2);
				dataUpdate.m_minWeigthModificador.valor.valor = Mathf.MoveTowards(dataUpdate.m_minWeigthModificador.valor.valor, num, this.VelPorWeight(dataUpdate.m_minWeigthModificador.valor.valor) * (1f / this.inTime) * base.estadoDeltaTime);
				dataUpdate.m_weigthModificador.valor.valor = Mathf.MoveTowards(dataUpdate.m_weigthModificador.valor.valor, num2, this.VelPorWeight(dataUpdate.m_weigthModificador.valor.valor) * (1f / this.inTime) * base.estadoDeltaTime);
				return true;
			}

			// Token: 0x06000E88 RID: 3720 RVA: 0x00031E30 File Offset: 0x00030030
			private static void GetMinAndModFromWeight(float weight, out float min, out float mod)
			{
				min = 0.5f * weight.OutPow(1.59f);
				mod = Mathf.Lerp(1f, 2f, weight);
			}

			// Token: 0x04000896 RID: 2198
			public Func<bool> isValidToJoint;

			// Token: 0x04000897 RID: 2199
			public Func<bool> isValidToSuck;

			// Token: 0x04000898 RID: 2200
			public float weight;

			// Token: 0x04000899 RID: 2201
			public float inTime = 1f;

			// Token: 0x0400089A RID: 2202
			public float outTime = 1f;

			// Token: 0x0400089B RID: 2203
			public ControlladorDeSuccion.JointData jointData;

			// Token: 0x0400089C RID: 2204
			private ControlladorDeSuccionJoints m_ControlladorDeSuccionJoints;

			// Token: 0x0400089D RID: 2205
			private ControlladorDeSuccionJoints.Orden m_jointOrder;
		}

		// Token: 0x0200017C RID: 380
		[Serializable]
		public struct JointData
		{
			// Token: 0x06000E89 RID: 3721 RVA: 0x00031E58 File Offset: 0x00030058
			public static ControlladorDeSuccion.JointData Nuevo(float weigth, float maxWorldDistance, int slotID, Rigidbody target, float InTime, float OutTime, float? breakForce = null)
			{
				return new ControlladorDeSuccion.JointData
				{
					weigth = weigth,
					maxWorldDistance = maxWorldDistance,
					slotID = slotID,
					target = target,
					InTime = InTime,
					OutTime = OutTime,
					breakForce = ((breakForce != null) ? breakForce.Value : (-1f))
				};
			}

			// Token: 0x170004FC RID: 1276
			// (get) Token: 0x06000E8A RID: 3722 RVA: 0x00031EBE File Offset: 0x000300BE
			public bool isValid
			{
				get
				{
					return this.target != null;
				}
			}

			// Token: 0x0400089E RID: 2206
			public float weigth;

			// Token: 0x0400089F RID: 2207
			public float maxWorldDistance;

			// Token: 0x040008A0 RID: 2208
			public int slotID;

			// Token: 0x040008A1 RID: 2209
			public Rigidbody target;

			// Token: 0x040008A2 RID: 2210
			public float InTime;

			// Token: 0x040008A3 RID: 2211
			public float OutTime;

			// Token: 0x040008A4 RID: 2212
			public float breakForce;
		}

		// Token: 0x0200017D RID: 381
		public sealed class Colas : ControllerColaDePrioridadBase<ControlladorDeSuccion.Stado, ControlladorDeSuccion.Orden, ControlladorDeSuccion.Colas, ControlladorDeSuccion, int>.ColasBase
		{
		}

		// Token: 0x0200017E RID: 382
		public sealed class Stado : ControllerColaDePrioridadBase<ControlladorDeSuccion.Stado, ControlladorDeSuccion.Orden, ControlladorDeSuccion.Colas, ControlladorDeSuccion, int>.StadoBase
		{
		}
	}
}
