using System;
using System.Collections.Generic;
using Assets;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200000C RID: 12
	public class SequencerCommandCalculadorEmocionIgnorarParte : SequencerCommand
	{
		// Token: 0x06000040 RID: 64 RVA: 0x00006248 File Offset: 0x00004448
		public void Start()
		{
			try
			{
				EmocionesFemeninas componentEnCharacter = base.Sequencer.Speaker.GetComponentEnCharacter(false);
				if (componentEnCharacter == null)
				{
					Debug.LogWarning("no se encontraron emociones humanas en " + base.Sequencer.Speaker.name);
				}
				else
				{
					string[] array = base.GetParameter(0, string.Empty).Replace(" ", "").Split('|', StringSplitOptions.None);
					List<ParteDelCuerpoHumano> list = new List<ParteDelCuerpoHumano>();
					for (int i = 0; i < array.Length; i++)
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano;
						if (Enum.TryParse<ParteDelCuerpoHumano>(array[i], out parteDelCuerpoHumano))
						{
							list.Add(parteDelCuerpoHumano);
						}
					}
					bool parameterAsBool = base.GetParameterAsBool(1, false);
					if (list.Count == 0)
					{
						Debug.LogWarning("Ninguna ParteDelCuerpoHumano en " + string.Join(" ", array));
					}
					else
					{
						string[] array2 = base.GetParameter(2, string.Empty).Replace(" ", "").Split('|', StringSplitOptions.None);
						ReaccionHumana reaccionHumana = ReaccionHumana.None;
						for (int j = 0; j < array2.Length; j++)
						{
							ReaccionHumana reaccionHumana2;
							if (Enum.TryParse<ReaccionHumana>(array2[j], out reaccionHumana2))
							{
								reaccionHumana |= reaccionHumana2;
							}
						}
						if (reaccionHumana == ReaccionHumana.None)
						{
							Debug.LogWarning("no se reconoce ReaccionHumana " + base.GetParameter(2, "N/D"));
						}
						else
						{
							TipoDeEstimulo tipoDeEstimulo = base.GetParameter(3, "None").ToEnum(TipoDeEstimulo.None);
							if (tipoDeEstimulo == TipoDeEstimulo.None)
							{
								Debug.LogWarning("no se reconoce TipoDeEstimulo " + base.GetParameter(3, "N/D"));
							}
							else
							{
								DireccionDeEstimulo direccionDeEstimulo = base.GetParameter(4, null).ToEnum(DireccionDeEstimulo.recibida);
								ICalculadorDeEstimuloClasificable[] componentsInChildren = componentEnCharacter.GetComponentsInChildren<ICalculadorDeEstimuloClasificable>(true);
								if (componentsInChildren.Length == 0)
								{
									Debug.LogWarning("Ningun ICalculadorDeEstimuloClasificable en " + componentEnCharacter.name);
								}
								else
								{
									foreach (ICalculadorDeEstimuloClasificable calculadorDeEstimuloClasificable in componentsInChildren)
									{
										if (((int)reaccionHumana).HasFlag((int)calculadorDeEstimuloClasificable.reaccion) && calculadorDeEstimuloClasificable.tipoDeEstimulo == tipoDeEstimulo && calculadorDeEstimuloClasificable.direccionDeEstimulo == direccionDeEstimulo)
										{
											ICalculadorDeEstimuloIgnoradorEnPartesHumanas calculadorDeEstimuloIgnoradorEnPartesHumanas = calculadorDeEstimuloClasificable as ICalculadorDeEstimuloIgnoradorEnPartesHumanas;
											if (calculadorDeEstimuloIgnoradorEnPartesHumanas != null)
											{
												calculadorDeEstimuloIgnoradorEnPartesHumanas.IgnorarPartesHumanas(list, parameterAsBool);
											}
										}
									}
								}
							}
						}
					}
				}
			}
			finally
			{
				base.Stop();
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00006474 File Offset: 0x00004674
		public void Update()
		{
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00006476 File Offset: 0x00004676
		public void OnDestroy()
		{
		}
	}
}
