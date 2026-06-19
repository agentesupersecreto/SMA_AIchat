using System;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.UI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Ropa.UI;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000034 RID: 52
	[Obsolete]
	public class SequencerCommandQuitarPiezaRopaCurrentClickedSendANY : SequencerCommand
	{
		// Token: 0x06000104 RID: 260 RVA: 0x0000A188 File Offset: 0x00008388
		public void Start()
		{
			try
			{
				bool parameterAsBool = base.GetParameterAsBool(0, true);
				EstimulosPorQuitarPrendasDeRopa estimulosPorQuitarPrendasDeRopa;
				OpcionesDeTHSDonaDeRopaCubreConTextoMutado opcionesDeTHSDonaDeRopaCubreConTextoMutado;
				OpcionesDeTHSDonaDePiezaDeRopaPuesta opcionesDeTHSDonaDePiezaDeRopaPuesta;
				ConjuntoDeRopaLoader conjuntoDeRopaLoader;
				Character character;
				if (parameterAsBool)
				{
					estimulosPorQuitarPrendasDeRopa = base.Sequencer.Speaker.GetComponentEnRoot(true);
					opcionesDeTHSDonaDeRopaCubreConTextoMutado = base.Sequencer.Speaker.GetComponentEnRoot(true);
					opcionesDeTHSDonaDePiezaDeRopaPuesta = base.Sequencer.Speaker.GetComponentEnRoot(true);
					conjuntoDeRopaLoader = base.Sequencer.Speaker.GetComponentEnRoot(true);
					character = base.Sequencer.Listener.GetComponentEnRoot(true);
				}
				else
				{
					estimulosPorQuitarPrendasDeRopa = base.Sequencer.Listener.GetComponentEnRoot(true);
					opcionesDeTHSDonaDeRopaCubreConTextoMutado = base.Sequencer.Listener.GetComponentEnRoot(true);
					opcionesDeTHSDonaDePiezaDeRopaPuesta = base.Sequencer.Listener.GetComponentEnRoot(true);
					conjuntoDeRopaLoader = base.Sequencer.Listener.GetComponentEnRoot(true);
					character = base.Sequencer.Speaker.GetComponentEnRoot(true);
				}
				if (conjuntoDeRopaLoader == null)
				{
					Debug.LogError("ConjuntoDeRopaLoader no existe en objeto.", parameterAsBool ? base.Sequencer.Speaker : base.Sequencer.Listener);
				}
				else if (estimulosPorQuitarPrendasDeRopa == null)
				{
					Debug.LogError("EstimulosPorQuitarPrendasDeRopa no existe en objeto.", parameterAsBool ? base.Sequencer.Speaker : base.Sequencer.Listener);
				}
				else if (opcionesDeTHSDonaDeRopaCubreConTextoMutado == null && opcionesDeTHSDonaDePiezaDeRopaPuesta == null)
				{
					Debug.LogError("Opciones no existen", parameterAsBool ? base.Sequencer.Speaker : base.Sequencer.Listener);
				}
				else if (opcionesDeTHSDonaDeRopaCubreConTextoMutado.selected.Count == 0 && opcionesDeTHSDonaDePiezaDeRopaPuesta.selected.Count == 0)
				{
					Debug.LogError("no existe current clicked. ", parameterAsBool ? base.Sequencer.Speaker : base.Sequencer.Listener);
				}
				else
				{
					if (!base.GetParameterAsBool(1, true))
					{
						throw new NotImplementedException();
					}
					if (opcionesDeTHSDonaDeRopaCubreConTextoMutado.selected.Count > 0)
					{
						RopaCubre ropaCubre = opcionesDeTHSDonaDeRopaCubreConTextoMutado.selectedEnums.Last<RopaCubre>();
						conjuntoDeRopaLoader.CantidadPiezasCubriendo(ropaCubre, true, this.m_idsEnropaCubre);
						foreach (string text in this.m_idsEnropaCubre)
						{
							estimulosPorQuitarPrendasDeRopa.TryRegistrarPedido(text, opcionesDeTHSDonaDeRopaCubreConTextoMutado.puedeDesvestir, base.GetParameterAsBool(2, false), character);
						}
					}
					if (opcionesDeTHSDonaDePiezaDeRopaPuesta.selected.Count > 0)
					{
						string text2 = opcionesDeTHSDonaDePiezaDeRopaPuesta.selectedKeys.Last<string>();
						estimulosPorQuitarPrendasDeRopa.TryRegistrarPedido(text2, opcionesDeTHSDonaDePiezaDeRopaPuesta.puedeDesvestirse, base.GetParameterAsBool(2, false), character);
					}
				}
			}
			finally
			{
				base.Stop();
				this.m_idsEnropaCubre.Clear();
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000A44C File Offset: 0x0000864C
		public void Update()
		{
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000A44E File Offset: 0x0000864E
		public void OnDestroy()
		{
		}

		// Token: 0x040000A7 RID: 167
		private List<string> m_idsEnropaCubre = new List<string>();
	}
}
