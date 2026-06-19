using System;
using System.Collections.Generic;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000EA RID: 234
	public sealed class InteraccionController : CustomUpdatedMonobehaviourBase, IInteractionController, IEffectorIsLooked
	{
		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06000878 RID: 2168 RVA: 0x00026846 File Offset: 0x00024A46
		public override int updateEvent1Index
		{
			get
			{
				return 8;
			}
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x00026849 File Offset: 0x00024A49
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_InteraccionesDeCharacter = this.GetComponentEnRoot(false);
			if (this.m_InteraccionesDeCharacter == null)
			{
				throw new ArgumentNullException("m_InteraccionesDeCharacter", "m_InteraccionesDeCharacter null reference.");
			}
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x00026876 File Offset: 0x00024A76
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x00026880 File Offset: 0x00024A80
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_updater = this.GetComponentEnRoot(false);
			if (this.m_updater == null)
			{
				throw new ArgumentNullException("updater", "updater null reference.");
			}
			this.m_InteraccionTransicionController = this.GetComponentEnRoot(false);
			this.m_slaveDeIK.Clear();
			for (int i = 0; i < this.m_constrollersSlaves.Count; i++)
			{
				InteraccionController.Slave slave = this.m_constrollersSlaves[i];
				slave.Init(this, this.m_updater);
				this.m_slaveDeIK.Add(slave.ik, slave);
			}
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x00026912 File Offset: 0x00024B12
		private bool GetSlave(Component ik, int layer, out InteraccionController.Slave par)
		{
			return this.m_slaveDeIK.TryGetValue(ik, out par);
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x00026924 File Offset: 0x00024B24
		public override void OnUpdateEvent1()
		{
			IReadOnlyList<Component> sortedIKs = this.m_updater.sortedIKs;
			for (int i = 0; i < sortedIKs.Count; i++)
			{
				Component component = sortedIKs[i];
				InteraccionController.Slave slave;
				if (this.GetSlave(component, -1, out slave))
				{
					slave.controller.ActualizarControllador();
				}
			}
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x00026970 File Offset: 0x00024B70
		public InteractionEffectorControllerSlave GetSlaveDeIK(FullBodyBipedIK ik, int layerOrPass = -1)
		{
			InteraccionController.Slave slave;
			if (!this.GetSlave(ik, layerOrPass, out slave))
			{
				return null;
			}
			return slave.controller;
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x00026994 File Offset: 0x00024B94
		[Obsolete("", true)]
		public bool IsFijaPorAnimacionEnLayers(FullBodyBipedEffector fullBodyBipedEffector, int layerMinimo, int layerMaximo = 2147483647, bool OApoyando = true)
		{
			for (int i = 0; i < this.m_constrollersSlaves.Count; i++)
			{
				if (i >= layerMinimo && i < layerMaximo && this.m_constrollersSlaves[i].controller.IsFijaPorAnimacion(fullBodyBipedEffector, OApoyando))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x000269E0 File Offset: 0x00024BE0
		public bool IsFijaPorAnimacionEnLayers(FullBodyBipedEffector fullBodyBipedEffector, IKLayerFlag paraFlags, bool OApoyando = true)
		{
			IReadOnlyList<Component> sortedIKs = this.m_updater.sortedIKs;
			for (int i = 0; i < sortedIKs.Count; i++)
			{
				Component component = sortedIKs[i];
				InteraccionController.Slave slave;
				if (this.GetSlave(component, -1, out slave) && paraFlags.EsParaCurrentIkLayer(slave.layer) && slave.controller.IsFijaPorAnimacion(fullBodyBipedEffector, OApoyando))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x00026A40 File Offset: 0x00024C40
		public bool IsFijaPorAnimacion(FullBodyBipedEffector fullBodyBipedEffector, bool OApoyando = true)
		{
			IReadOnlyList<Component> sortedIKs = this.m_updater.sortedIKs;
			for (int i = 0; i < sortedIKs.Count; i++)
			{
				Component component = sortedIKs[i];
				InteraccionController.Slave slave;
				if (this.GetSlave(component, -1, out slave) && slave.controller.IsFijaPorAnimacion(fullBodyBipedEffector, OApoyando))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x00026A90 File Offset: 0x00024C90
		public bool PuedeTrasladarse(FullBodyBipedEffector fullBodyBipedEffector)
		{
			IReadOnlyList<Component> sortedIKs = this.m_updater.sortedIKs;
			for (int i = sortedIKs.Count - 1; i >= 0; i--)
			{
				Component component = sortedIKs[i];
				InteraccionController.Slave slave;
				if (this.GetSlave(component, -1, out slave) && !slave.controller.PuedeTrasladarse(fullBodyBipedEffector))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x00026AE4 File Offset: 0x00024CE4
		public bool PuedeApoyarse(FullBodyBipedEffector fullBodyBipedEffector, bool esExtencion)
		{
			IReadOnlyList<Component> sortedIKs = this.m_updater.sortedIKs;
			for (int i = sortedIKs.Count - 1; i >= 0; i--)
			{
				Component component = sortedIKs[i];
				InteraccionController.Slave slave;
				if (this.GetSlave(component, -1, out slave) && !slave.controller.PuedeApoyarse(fullBodyBipedEffector, esExtencion))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x00026B38 File Offset: 0x00024D38
		[Obsolete("", true)]
		public bool InteractuandoEnLayers(FullBodyBipedEffector fullBodyBipedEffector, int layerMinimo, int layerMaximo = 2147483647)
		{
			for (int i = 0; i < this.m_constrollersSlaves.Count; i++)
			{
				if (i >= layerMinimo && i < layerMaximo && this.m_constrollersSlaves[i].controller.Interactuando(fullBodyBipedEffector))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x00026B80 File Offset: 0x00024D80
		public bool InteractuandoEnLayers(FullBodyBipedEffector fullBodyBipedEffector, IKLayerFlag paraFlags)
		{
			IReadOnlyList<Component> sortedIKs = this.m_updater.sortedIKs;
			for (int i = 0; i < sortedIKs.Count; i++)
			{
				Component component = sortedIKs[i];
				InteraccionController.Slave slave;
				if (this.GetSlave(component, -1, out slave) && paraFlags.EsParaCurrentIkLayer(slave.layer) && slave.controller.Interactuando(fullBodyBipedEffector))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x00026BE0 File Offset: 0x00024DE0
		public void ObtenerEjecutandose(FullBodyBipedEffector fullBodyBipedEffector, int layer, IList<IInteractionOrden> result)
		{
			IReadOnlyList<Component> readOnlyList = this.m_updater.SortedIKsDeLayer(layer);
			for (int i = 0; i < readOnlyList.Count; i++)
			{
				Component component = readOnlyList[i];
				InteraccionController.Slave slave;
				if (this.GetSlave(component, layer, out slave))
				{
					InteractionEffectorControllerSlave.Orden orden = slave.controller.currentStado[fullBodyBipedEffector];
					if (orden != null && !orden.Termino())
					{
						result.Add(orden);
					}
				}
			}
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x00026C48 File Offset: 0x00024E48
		public bool InteractuarTodos(InteraccionEstado estado, bool terminarDeInmediato, InteractionCallBackHandler justBeforeEjecucionCallBack = null)
		{
			IReadOnlyList<Component> readOnlyList = this.m_updater.SortedIKsDeLayer(estado.interactionLayer);
			bool flag = this.m_InteraccionTransicionController != null;
			bool flag2 = estado.parametros.usarTransicionEntreInteracionesEnMismoLayerSiDisponible && flag;
			bool flag3 = this.m_InteraccionesDeCharacter.ConflictuaConAlgunaEjecutandose(estado.interaccion);
			if (flag2 && readOnlyList.Count != 1 && flag3)
			{
				return flag3 && this.m_InteraccionTransicionController.Transicionar(estado, justBeforeEjecucionCallBack, 10, ControllerPrioridadConfig.prioridad, true);
			}
			if (flag && (this.m_InteraccionTransicionController.AlgunaOrndeEjecutandose() || this.m_InteraccionTransicionController.AlgunaOrndeDeteniendose() || this.m_InteraccionTransicionController.enCola > 0))
			{
				return false;
			}
			Component component = readOnlyList[0];
			InteraccionController.Slave slave;
			return this.GetSlave(component, estado.interactionLayer, out slave) && slave.controller.InteractuarTodos(estado, terminarDeInmediato, justBeforeEjecucionCallBack);
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x00026D0F File Offset: 0x00024F0F
		public bool EstaTransicionando(int layer)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x00026D18 File Offset: 0x00024F18
		public bool AlgunaEstaInteractuando(InteraccionInfo datos, int layer)
		{
			IReadOnlyList<Component> readOnlyList = this.m_updater.SortedIKsDeLayer(layer);
			for (int i = 0; i < readOnlyList.Count; i++)
			{
				Component component = readOnlyList[i];
				InteraccionController.Slave slave;
				if (this.GetSlave(component, layer, out slave) && slave.controller.AlgunaEstaInteractuando(datos))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x00026D68 File Offset: 0x00024F68
		public void DetenerInteracciones(InteraccionInfo info, int layer)
		{
			IReadOnlyList<Component> readOnlyList = this.m_updater.SortedIKsDeLayer(layer);
			for (int i = 0; i < readOnlyList.Count; i++)
			{
				Component component = readOnlyList[i];
				InteraccionController.Slave slave;
				if (this.GetSlave(component, layer, out slave))
				{
					slave.controller.DetenerInteraccion(info);
				}
			}
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x00026DB4 File Offset: 0x00024FB4
		public bool AreBothHandsFree()
		{
			return this.IsLHandsFree() && this.IsRHandsFree();
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x00026DC6 File Offset: 0x00024FC6
		public bool IsRHandsFree()
		{
			return !this.InteractuandoEnLayers(FullBodyBipedEffector.RightHand, IKLayerFlag.todos) || !this.IsFijaPorAnimacionEnLayers(FullBodyBipedEffector.RightHand, IKLayerFlag.todos, true);
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x00026DE2 File Offset: 0x00024FE2
		public bool IsLHandsFree()
		{
			return !this.InteractuandoEnLayers(FullBodyBipedEffector.LeftHand, IKLayerFlag.todos) || !this.IsFijaPorAnimacionEnLayers(FullBodyBipedEffector.LeftHand, IKLayerFlag.todos, true);
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x00026E00 File Offset: 0x00025000
		public bool TryGetFreeNotLockedHand(out Side handSide, out FullBodyBipedEffector handEffector)
		{
			if (!this.InteractuandoEnLayers(FullBodyBipedEffector.RightHand, IKLayerFlag.todos))
			{
				handSide = Side.R;
				handEffector = FullBodyBipedEffector.RightHand;
				return true;
			}
			if (!this.InteractuandoEnLayers(FullBodyBipedEffector.LeftHand, IKLayerFlag.todos))
			{
				handSide = Side.L;
				handEffector = FullBodyBipedEffector.LeftHand;
				return true;
			}
			if (!this.IsFijaPorAnimacionEnLayers(FullBodyBipedEffector.RightHand, IKLayerFlag.todos, true))
			{
				handSide = Side.R;
				handEffector = FullBodyBipedEffector.RightHand;
				return true;
			}
			if (!this.IsFijaPorAnimacionEnLayers(FullBodyBipedEffector.LeftHand, IKLayerFlag.todos, true))
			{
				handSide = Side.L;
				handEffector = FullBodyBipedEffector.LeftHand;
				return true;
			}
			handSide = Side.L;
			handEffector = FullBodyBipedEffector.LeftHand;
			return false;
		}

		// Token: 0x04000584 RID: 1412
		[SerializeField]
		[CoolArrayItem(reorderable = false)]
		private List<InteraccionController.Slave> m_constrollersSlaves = new List<InteraccionController.Slave>();

		// Token: 0x04000585 RID: 1413
		private Dictionary<Component, InteraccionController.Slave> m_slaveDeIK = new Dictionary<Component, InteraccionController.Slave>();

		// Token: 0x04000586 RID: 1414
		private InteraccionTransicionController m_InteraccionTransicionController;

		// Token: 0x04000587 RID: 1415
		private IIKUpdater m_updater;

		// Token: 0x04000588 RID: 1416
		private IInteraccionesDeCharacter m_InteraccionesDeCharacter;

		// Token: 0x020001B9 RID: 441
		[Serializable]
		public class Slave
		{
			// Token: 0x17000271 RID: 625
			// (get) Token: 0x06000CDC RID: 3292 RVA: 0x00039537 File Offset: 0x00037737
			public int layer
			{
				get
				{
					return this.m_layer;
				}
			}

			// Token: 0x17000272 RID: 626
			// (get) Token: 0x06000CDD RID: 3293 RVA: 0x0003953F File Offset: 0x0003773F
			public int id
			{
				get
				{
					return this.m_id;
				}
			}

			// Token: 0x06000CDE RID: 3294 RVA: 0x00039548 File Offset: 0x00037748
			public void Init(InteraccionController owner, IIKUpdater updater)
			{
				this.m_layer = updater.LayerDeIK(this.ik);
				this.m_id = updater.IDDeIK(this.ik);
				this.controller.Init(owner, this.ik, this.ik.GetComponent<InteractionSystemV3>());
			}

			// Token: 0x040009B0 RID: 2480
			[HideInInspector]
			[Obsolete("", true)]
			public int interactionLayer = -1;

			// Token: 0x040009B1 RID: 2481
			public InteractionEffectorControllerSlave controller;

			// Token: 0x040009B2 RID: 2482
			public FullBodyBipedIK ik;

			// Token: 0x040009B3 RID: 2483
			[Tooltip("Opcional, solo si slavesArePases es true")]
			[SerializeField]
			private InteractionSystemV3 interactionSystemV3;

			// Token: 0x040009B4 RID: 2484
			[ReadOnlyUI]
			[SerializeField]
			private int m_layer;

			// Token: 0x040009B5 RID: 2485
			[ReadOnlyUI]
			[SerializeField]
			private int m_id;
		}
	}
}
