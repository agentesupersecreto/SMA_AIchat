using System;
using Assets._ReusableScripts;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Penes
{
	// Token: 0x02000097 RID: 151
	public class ControlladorIPeneEsEstirable : ControllerColaDePrioridadBase<ControlladorIPeneEsEstirable.Stado, ControlladorIPeneEsEstirable.Orden, ControlladorIPeneEsEstirable.Colas, ControlladorIPeneEsEstirable, int>
	{
		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x0000E9FB File Offset: 0x0000CBFB
		protected override int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x0000E9FE File Offset: 0x0000CBFE
		protected override GlobalUpdater.UpdateType? updateTypeAutomatico
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x0000EA06 File Offset: 0x0000CC06
		public override int cantidadMaximaEnCola
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x0000EA0C File Offset: 0x0000CC0C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			IPeneEstirable componentEnRoot = this.GetComponentEnRoot(false);
			if (componentEnRoot == null)
			{
				throw new ArgumentNullException("m_IPeneEstirable", "m_IPeneEstirable null reference.");
			}
			this.m_esEstirable = componentEnRoot.estirandoOR.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x0000EA4C File Offset: 0x0000CC4C
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeBool esEstirable = this.m_esEstirable;
			if (esEstirable == null)
			{
				return;
			}
			esEstirable.TryRemoverDeOwner(true);
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x0000EA68 File Offset: 0x0000CC68
		public bool HacerEstirable(int prioridad, ControllerPrioridadConfig priConfig, float duracion)
		{
			bool flag = false;
			ControlladorIPeneEsEstirable.Orden orden;
			bool flag2;
			bool flag3;
			if (!base.VerificarSiPuedeEjecutarse(out orden, out flag2, 0, prioridad, priConfig, out flag3, ref flag, true))
			{
				return false;
			}
			ControlladorIPeneEsEstirable.Orden orden2;
			ControllerColaDePrioridadBaseBase.TipoDeReUsoDeOrden tipoDeReUsoDeOrden;
			if (base.PuedeAcumularseORevivir(orden, out orden2, priConfig, 0, out tipoDeReUsoDeOrden))
			{
				base.AcumularseORevivir(orden2, duracion, prioridad, tipoDeReUsoDeOrden, null, null);
				return true;
			}
			if (flag3 && !flag)
			{
				return false;
			}
			ControlladorIPeneEsEstirable.Orden orden3 = new ControlladorIPeneEsEstirable.Orden(prioridad, priConfig, duracion);
			base.Procesar(orden == null, flag2, priConfig, orden3, false, false);
			return true;
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x0000EACF File Offset: 0x0000CCCF
		public override int ParseIndexToTipoId(int index)
		{
			return index;
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x0000EAD2 File Offset: 0x0000CCD2
		public override int ParseTipoIdToindex(int tipoId)
		{
			return tipoId;
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x0000EAD5 File Offset: 0x0000CCD5
		protected override ControlladorIPeneEsEstirable ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x040002A7 RID: 679
		[SerializeField]
		private ModificadorDeBool m_esEstirable;

		// Token: 0x02000186 RID: 390
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<ControlladorIPeneEsEstirable.Stado, ControlladorIPeneEsEstirable.Orden, ControlladorIPeneEsEstirable.Colas, ControlladorIPeneEsEstirable, int>.OrdenBaseDeControllador
		{
			// Token: 0x06000EAA RID: 3754 RVA: 0x000322CC File Offset: 0x000304CC
			public Orden(int prioridad, ControllerPrioridadConfig priConfig, float duracion)
				: base(0, prioridad, duracion, priConfig, false)
			{
			}

			// Token: 0x06000EAB RID: 3755 RVA: 0x000322D9 File Offset: 0x000304D9
			protected override void OnDetenidaPorUsuario(ControlladorIPeneEsEstirable dataUpdate)
			{
			}

			// Token: 0x06000EAC RID: 3756 RVA: 0x000322DB File Offset: 0x000304DB
			protected override bool OnTerminando(ControlladorIPeneEsEstirable dataUpdate, bool primerUpdate, ControlladorIPeneEsEstirable.Orden ordenEsperandoDetencion)
			{
				return true;
			}

			// Token: 0x06000EAD RID: 3757 RVA: 0x000322DE File Offset: 0x000304DE
			protected override void OnTerminada(ControlladorIPeneEsEstirable dataUpdate, bool abruptamente)
			{
				dataUpdate.m_esEstirable.valor.valor = false;
			}

			// Token: 0x06000EAE RID: 3758 RVA: 0x000322F1 File Offset: 0x000304F1
			protected override void OnStart(ControlladorIPeneEsEstirable dataUpdate)
			{
			}

			// Token: 0x06000EAF RID: 3759 RVA: 0x000322F3 File Offset: 0x000304F3
			protected override bool UpdateOrden(ControlladorIPeneEsEstirable dataUpdate, bool esPrimerUpdate)
			{
				if (this.Termino())
				{
					return false;
				}
				dataUpdate.m_esEstirable.valor.valor = true;
				return true;
			}
		}

		// Token: 0x02000187 RID: 391
		public sealed class Colas : ControllerColaDePrioridadBase<ControlladorIPeneEsEstirable.Stado, ControlladorIPeneEsEstirable.Orden, ControlladorIPeneEsEstirable.Colas, ControlladorIPeneEsEstirable, int>.ColasBase
		{
		}

		// Token: 0x02000188 RID: 392
		public sealed class Stado : ControllerColaDePrioridadBase<ControlladorIPeneEsEstirable.Stado, ControlladorIPeneEsEstirable.Orden, ControlladorIPeneEsEstirable.Colas, ControlladorIPeneEsEstirable, int>.StadoBase
		{
		}
	}
}
