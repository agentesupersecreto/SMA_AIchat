using System;
using System.Collections.Generic;
using Assets;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000031 RID: 49
	public class SequencerCommandDesvestirPartePor : SequencerCommand
	{
		// Token: 0x060000F0 RID: 240 RVA: 0x000095C8 File Offset: 0x000077C8
		private Character ObtenerCharacter(string id)
		{
			Guid guid = Guid.Parse(id);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x000095E8 File Offset: 0x000077E8
		public void Start()
		{
			try
			{
				Character character = this.ObtenerCharacter(base.GetParameter(4, string.Empty));
				bool parameterAsBool = base.GetParameterAsBool(0, true);
				EstimulosPorQuitarPrendasDeRopa estimulosPorQuitarPrendasDeRopa;
				ConjuntoDeRopaLoader conjuntoDeRopaLoader;
				if (parameterAsBool)
				{
					estimulosPorQuitarPrendasDeRopa = base.Sequencer.Speaker.GetComponentEnRoot(true);
					conjuntoDeRopaLoader = base.Sequencer.Speaker.GetComponentEnRoot(true);
				}
				else
				{
					estimulosPorQuitarPrendasDeRopa = base.Sequencer.Listener.GetComponentEnRoot(true);
					conjuntoDeRopaLoader = base.Sequencer.Listener.GetComponentEnRoot(true);
				}
				if (conjuntoDeRopaLoader == null)
				{
					Debug.LogError("ConjuntoDeRopaLoader no existe en objeto.", parameterAsBool ? base.Sequencer.Speaker : base.Sequencer.Listener);
				}
				else if (estimulosPorQuitarPrendasDeRopa == null)
				{
					Debug.LogError("EstimulosPorQuitarPrendasDeRopa no existe en objeto.", parameterAsBool ? base.Sequencer.Speaker : base.Sequencer.Listener);
				}
				else
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano = base.GetParameter(1, "None").ToEnum(ParteDelCuerpoHumano.pecho);
					conjuntoDeRopaLoader.CantidadPiezasCubriendo(parteDelCuerpoHumano.Parce(), true, this.m_idsEnropaCubre);
					if (!base.GetParameterAsBool(2, true))
					{
						throw new NotImplementedException();
					}
					int num = Mathf.Min(base.GetParameterAsInt(5, int.MaxValue), this.m_idsEnropaCubre.Count);
					for (int i = 0; i < num; i++)
					{
						string text = this.m_idsEnropaCubre[i];
						estimulosPorQuitarPrendasDeRopa.TryRegistrarPedido(text, true, base.GetParameterAsBool(3, false), character);
					}
				}
			}
			finally
			{
				base.Stop();
				this.m_idsEnropaCubre.Clear();
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00009780 File Offset: 0x00007980
		public void Update()
		{
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00009782 File Offset: 0x00007982
		public void OnDestroy()
		{
		}

		// Token: 0x0400009F RID: 159
		private List<string> m_idsEnropaCubre = new List<string>();
	}
}
