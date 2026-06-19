using System;
using System.Collections.Generic;
using Assets;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000038 RID: 56
	public class SequencerCommandCambioEmocionEnListener : SequencerCommand
	{
		// Token: 0x06000118 RID: 280 RVA: 0x0000AAB4 File Offset: 0x00008CB4
		public void Start()
		{
			try
			{
				FemaleChar componentEnRoot = base.Sequencer.Listener.GetComponentEnRoot(false);
				float parameterAsFloat = base.GetParameterAsFloat(0, 0f);
				if (parameterAsFloat != 0f)
				{
					Personalidad.TipoDeRespuestaDeDialogoDePlayer tipoDeRespuestaDeDialogoDePlayer = base.GetParameter(1, "None").ToEnum(Personalidad.TipoDeRespuestaDeDialogoDePlayer.None);
					if (tipoDeRespuestaDeDialogoDePlayer == Personalidad.TipoDeRespuestaDeDialogoDePlayer.None)
					{
						Debug.LogWarning("no se reconoce TipoDeRespuestaDeDialogo " + base.GetParameter(1, "None"));
					}
					else
					{
						float parameterAsFloat2 = base.GetParameterAsFloat(2, 0f);
						ReaccionHumana reaccionHumana = base.GetParameter(3, "None").ToEnum(ReaccionHumana.None);
						float parameterAsFloat3 = base.GetParameterAsFloat(4, 0f);
						ReaccionHumana reaccionHumana2 = base.GetParameter(5, "None").ToEnum(ReaccionHumana.None);
						float parameterAsFloat4 = base.GetParameterAsFloat(6, 0f);
						ReaccionHumana reaccionHumana3 = base.GetParameter(7, "None").ToEnum(ReaccionHumana.None);
						this.m_Temp.Add(new ValueTuple<ReaccionHumana, float>(reaccionHumana2, parameterAsFloat3));
						this.m_Temp.Add(new ValueTuple<ReaccionHumana, float>(reaccionHumana3, parameterAsFloat4));
						SequencerCommandCambioEmocion.Calcular(componentEnRoot, tipoDeRespuestaDeDialogoDePlayer, parameterAsFloat, reaccionHumana, parameterAsFloat2, this.m_Temp, false);
					}
				}
			}
			finally
			{
				this.m_Temp.Clear();
				base.Stop();
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000ABF4 File Offset: 0x00008DF4
		public void Update()
		{
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000ABF6 File Offset: 0x00008DF6
		public void OnDestroy()
		{
		}

		// Token: 0x040000A9 RID: 169
		private List<ValueTuple<ReaccionHumana, float>> m_Temp = new List<ValueTuple<ReaccionHumana, float>>();
	}
}
