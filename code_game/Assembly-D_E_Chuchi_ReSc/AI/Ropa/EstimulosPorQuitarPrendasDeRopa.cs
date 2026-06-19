using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos.Clases;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Ropa.Clases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Ropa
{
	// Token: 0x02000381 RID: 897
	public sealed class EstimulosPorQuitarPrendasDeRopa : AplicableBehaviour, IRopaLoaderFrameData
	{
		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x06001372 RID: 4978 RVA: 0x0001A9BC File Offset: 0x00018BBC
		public override int updateEvent1Index
		{
			get
			{
				return 69;
			}
		}

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x06001373 RID: 4979 RVA: 0x000550D2 File Offset: 0x000532D2
		public ConjuntoDeRopaLoader conjuntoDeRopaLoader
		{
			get
			{
				return this.m_ConjuntoDeRopaLoader;
			}
		}

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x06001374 RID: 4980 RVA: 0x000550DA File Offset: 0x000532DA
		public SiendoDesvestidoPorCharacter siendoDesvestidoPorCharacter
		{
			get
			{
				return this.m_SiendoDesvestidoPorCharacter;
			}
		}

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x06001375 RID: 4981 RVA: 0x000550E2 File Offset: 0x000532E2
		public SiendoPedidoDesvestirPorCharacter siendoPedidoDesvestirPorCharacter
		{
			get
			{
				return this.m_SiendoPedidoDesvestirPorCharacter;
			}
		}

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x06001376 RID: 4982 RVA: 0x000550EA File Offset: 0x000532EA
		IReadOnlyList<SiendoDesvestidoFrameData> IRopaLoaderFrameData.enRemoverFrame
		{
			get
			{
				return this.m_pedidosEnFrame;
			}
		}

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x06001377 RID: 4983 RVA: 0x000550F2 File Offset: 0x000532F2
		[Obsolete("Se unificaron los mapas", true)]
		RopaTipoDeSingleton IRopaLoaderFrameData.ropaTipoDeSingleton
		{
			get
			{
				return this.m_ConjuntoDeRopaLoader.ropaTipoDeSingleton;
			}
		}

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x06001378 RID: 4984 RVA: 0x000550FF File Offset: 0x000532FF
		Character IRopaLoaderFrameData.character
		{
			get
			{
				return this.m_ConjuntoDeRopaLoader.character;
			}
		}

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06001379 RID: 4985 RVA: 0x0005510C File Offset: 0x0005330C
		public IRopaManager manager
		{
			get
			{
				return ((IRopaLoaderFrameData)this.m_ConjuntoDeRopaLoader).manager;
			}
		}

		// Token: 0x0600137A RID: 4986 RVA: 0x0005511C File Offset: 0x0005331C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_Character = this.GetComponentEnRoot(false);
			if (this.m_Character == null)
			{
				throw new ArgumentNullException("m_Character", "m_Character null reference.");
			}
			this.m_ConcentNecesario = this.GetComponentEnRoot(false);
			if (this.m_ConcentNecesario == null)
			{
				throw new ArgumentNullException("m_ConcentNecesario", "m_ConcentNecesario null reference.");
			}
			this.m_PrioridadesDeObjetoEstimulado = this.GetComponentEnRoot(false);
			if (this.m_PrioridadesDeObjetoEstimulado == null)
			{
				throw new ArgumentNullException("m_PrioridadesDeObjetoEstimulado", "m_PrioridadesDeObjetoEstimulado null reference.");
			}
			this.m_ConjuntoDeRopaLoader = this.GetComponentEnRoot(false);
			if (this.m_ConjuntoDeRopaLoader != null)
			{
				this.m_SiendoDesvestidoPorCharacter = new SiendoDesvestidoPorCharacter(this.m_ConjuntoDeRopaLoader, this.m_PrioridadesDeObjetoEstimulado);
				this.m_SiendoPedidoDesvestirPorCharacter = new SiendoPedidoDesvestirPorCharacter(this, this.m_PrioridadesDeObjetoEstimulado);
			}
		}

		// Token: 0x0600137B RID: 4987 RVA: 0x000551EE File Offset: 0x000533EE
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (this.m_ConjuntoDeRopaLoader != null)
			{
				this.m_ConjuntoDeRopaLoader.cleaningFrameData += this.M_ConjuntoDeRopaLoader_cleaningFrameData;
			}
		}

		// Token: 0x0600137C RID: 4988 RVA: 0x0005521B File Offset: 0x0005341B
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_ConjuntoDeRopaLoader != null)
			{
				this.m_ConjuntoDeRopaLoader.cleaningFrameData -= this.M_ConjuntoDeRopaLoader_cleaningFrameData;
			}
		}

		// Token: 0x0600137D RID: 4989 RVA: 0x00055249 File Offset: 0x00053449
		private void M_ConjuntoDeRopaLoader_cleaningFrameData(ConjuntoDeRopaLoader obj)
		{
			SiendoDesvestidoPorCharacter siendoDesvestidoPorCharacter = this.m_SiendoDesvestidoPorCharacter;
			if (siendoDesvestidoPorCharacter == null)
			{
				return;
			}
			siendoDesvestidoPorCharacter.Update_();
		}

		// Token: 0x0600137E RID: 4990 RVA: 0x0005525C File Offset: 0x0005345C
		public override void OnUpdateEvent1()
		{
			try
			{
				SiendoPedidoDesvestirPorCharacter siendoPedidoDesvestirPorCharacter = this.m_SiendoPedidoDesvestirPorCharacter;
				if (siendoPedidoDesvestirPorCharacter != null)
				{
					siendoPedidoDesvestirPorCharacter.Update_();
				}
				this.ResolverPedidos();
			}
			finally
			{
				this.m_pedidosEnFrame.Clear();
			}
		}

		// Token: 0x0600137F RID: 4991 RVA: 0x000552A0 File Offset: 0x000534A0
		private void ResolverPedidos()
		{
			for (int i = 0; i < this.m_pedidosEnFrame.Count; i++)
			{
				SiendoDesvestidoFrameData siendoDesvestidoFrameData = this.m_pedidosEnFrame[i];
				if (!siendoDesvestidoFrameData.flagToFail)
				{
					RopaCubre ropaCubre = this.m_ConjuntoDeRopaLoader.CurrentPiezaCubreFlags(siendoDesvestidoFrameData.piezaID, true);
					if (siendoDesvestidoFrameData.por != this.m_Character && ropaCubre != RopaCubre.None)
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano = ropaCubre.ObtenerLaDeMayorPrioridad(Sexo.femenino).ParceToParteDelCuerpoHumano();
						float num;
						float num2;
						if (!this.m_ConcentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.boca, out num, out num2, 1f, null, null, null))
						{
							goto IL_009A;
						}
					}
					PiezaDeRopaBase piezaDeRopaBase;
					this.m_ConjuntoDeRopaLoader.piezasLoader.OcultarPieza(siendoDesvestidoFrameData.piezaID, true, out piezaDeRopaBase);
				}
				IL_009A:;
			}
		}

		// Token: 0x06001380 RID: 4992 RVA: 0x0005535C File Offset: 0x0005355C
		public bool TryRegistrarPedido(string PiezaID, bool puedeDesvestir, bool forzar, Object by)
		{
			if (this.m_ConjuntoDeRopaLoader == null)
			{
				return false;
			}
			if (forzar)
			{
				this.m_ConjuntoDeRopaLoader.FlagPiezaID = PiezaID;
				return this.m_ConjuntoDeRopaLoader.OcultarPieza(true, by);
			}
			PiezaDeRopaBase piezaDeRopaBase = this.m_ConjuntoDeRopaLoader.ObtenerPieza(PiezaID);
			if (piezaDeRopaBase == null)
			{
				return false;
			}
			Character character;
			if (by != null && SiendoDesvestidoFrameData.TryObtenerCharacter(by, out character))
			{
				SiendoDesvestidoFrameData siendoDesvestidoFrameData = new SiendoDesvestidoFrameData(character, PiezaID, this.m_ConjuntoDeRopaLoader.character, piezaDeRopaBase, false, true);
				siendoDesvestidoFrameData.flagToFail = !puedeDesvestir;
				this.m_pedidosEnFrame.Add(siendoDesvestidoFrameData);
				return true;
			}
			return false;
		}

		// Token: 0x06001381 RID: 4993 RVA: 0x000553F5 File Offset: 0x000535F5
		public void InyectData(ref SiendoDesvestidoFrameData data)
		{
			this.m_pedidosEnFrame.Add(data);
		}

		// Token: 0x06001382 RID: 4994 RVA: 0x00055408 File Offset: 0x00053608
		protected override CustomMonobehaviourBotonConfig Boton5()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "CrearPedido",
				editorTimeVisible = false
			};
		}

		// Token: 0x06001383 RID: 4995 RVA: 0x00055421 File Offset: 0x00053621
		protected override void OnAplicar5()
		{
			base.OnAplicar5();
			this.TryRegistrarPedido(this.m_flagID_Debug, true, this.m_forzar_Debug, MainChar.current);
			this.m_flagID_Debug = string.Empty;
		}

		// Token: 0x04001050 RID: 4176
		private Character m_Character;

		// Token: 0x04001051 RID: 4177
		private ConsentNecesario m_ConcentNecesario;

		// Token: 0x04001052 RID: 4178
		private ConjuntoDeRopaLoader m_ConjuntoDeRopaLoader;

		// Token: 0x04001053 RID: 4179
		private SiendoDesvestidoPorCharacter m_SiendoDesvestidoPorCharacter;

		// Token: 0x04001054 RID: 4180
		private SiendoPedidoDesvestirPorCharacter m_SiendoPedidoDesvestirPorCharacter;

		// Token: 0x04001055 RID: 4181
		[ReadOnlyUI]
		[SerializeField]
		private List<SiendoDesvestidoFrameData> m_pedidosEnFrame = new List<SiendoDesvestidoFrameData>();

		// Token: 0x04001056 RID: 4182
		private IParteDelCuerpoHumanoPrioridades m_PrioridadesDeObjetoEstimulado;

		// Token: 0x04001057 RID: 4183
		[ComboBox(typeof(ProveedorPiezasDeRopaIDAttribute))]
		[SerializeField]
		private string m_flagID_Debug;

		// Token: 0x04001058 RID: 4184
		[SerializeField]
		private bool m_forzar_Debug;
	}
}
