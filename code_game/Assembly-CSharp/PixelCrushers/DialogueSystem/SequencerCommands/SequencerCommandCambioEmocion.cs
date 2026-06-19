using System;
using System.Collections.Generic;
using Assets;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000036 RID: 54
	public class SequencerCommandCambioEmocion : SequencerCommand
	{
		// Token: 0x0600010C RID: 268 RVA: 0x0000A558 File Offset: 0x00008758
		public void Start()
		{
			try
			{
				Character character;
				if (base.GetParameterAsBool(0, true))
				{
					character = base.Sequencer.Listener.GetComponentEnRoot(false);
				}
				else
				{
					character = base.Sequencer.Speaker.GetComponentEnRoot(false);
				}
				bool parameterAsBool = base.GetParameterAsBool(1, false);
				float parameterAsFloat = base.GetParameterAsFloat(2, 0f);
				if (parameterAsFloat != 0f)
				{
					Personalidad.TipoDeRespuestaDeDialogoDePlayer tipoDeRespuestaDeDialogoDePlayer = base.GetParameter(3, "None").ToEnum(Personalidad.TipoDeRespuestaDeDialogoDePlayer.None);
					if (tipoDeRespuestaDeDialogoDePlayer == Personalidad.TipoDeRespuestaDeDialogoDePlayer.None)
					{
						Debug.LogWarning("no se reconoce TipoDeRespuestaDeDialogo " + base.GetParameter(3, "None"));
					}
					else
					{
						float parameterAsFloat2 = base.GetParameterAsFloat(4, 0f);
						ReaccionHumana reaccionHumana = base.GetParameter(5, "None").ToEnum(ReaccionHumana.None);
						float parameterAsFloat3 = base.GetParameterAsFloat(6, 0f);
						ReaccionHumana reaccionHumana2 = base.GetParameter(7, "None").ToEnum(ReaccionHumana.None);
						float parameterAsFloat4 = base.GetParameterAsFloat(8, 0f);
						ReaccionHumana reaccionHumana3 = base.GetParameter(9, "None").ToEnum(ReaccionHumana.None);
						this.m_Temp.Add(new ValueTuple<ReaccionHumana, float>(reaccionHumana2, parameterAsFloat3));
						this.m_Temp.Add(new ValueTuple<ReaccionHumana, float>(reaccionHumana3, parameterAsFloat4));
						SequencerCommandCambioEmocion.Calcular(character, tipoDeRespuestaDeDialogoDePlayer, parameterAsFloat, reaccionHumana, parameterAsFloat2, this.m_Temp, parameterAsBool);
					}
				}
			}
			finally
			{
				this.m_Temp.Clear();
				base.Stop();
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000A6C0 File Offset: 0x000088C0
		public static void Calcular(Character character, Personalidad.TipoDeRespuestaDeDialogoDePlayer tipoDeRespuesta, float puntajeDeRespuesta, ReaccionHumana reaccion, float aumento, List<ValueTuple<ReaccionHumana, float>> overflows, bool autoGestuar = false)
		{
			EmocionesFemeninasBase componentEnCharacter = character.GetComponentEnCharacter(false);
			if (componentEnCharacter == null)
			{
				Debug.LogWarning("no se encontraron emociones humanas en " + character.name);
				return;
			}
			Personalidad componentEnCharacter2 = componentEnCharacter.GetComponentEnCharacter(false);
			if (componentEnCharacter2 == null)
			{
				Debug.LogWarning("no se encontro Personalidad en " + character.name);
				return;
			}
			float num2;
			float num = componentEnCharacter2.CalcularModificadorDeRespuesta(out num2, tipoDeRespuesta, puntajeDeRespuesta, 1f);
			if (!autoGestuar)
			{
				SequencerCommandCambioEmocion.ChangeValue(componentEnCharacter, reaccion, aumento * num);
			}
			else
			{
				SequencerCommandCambioEmocion.ChangeValueAutoReacc(character, componentEnCharacter, reaccion, aumento * num);
			}
			if (num2 >= 1f)
			{
				num2 -= 1f;
				for (int i = 0; i < overflows.Count; i++)
				{
					if (!autoGestuar)
					{
						SequencerCommandCambioEmocion.ChangeValue(componentEnCharacter, overflows[i].Item1, overflows[i].Item2 * num2);
					}
					else
					{
						SequencerCommandCambioEmocion.ChangeValueAutoReacc(character, componentEnCharacter, overflows[i].Item1, overflows[i].Item2 * num2);
					}
				}
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0000A7C0 File Offset: 0x000089C0
		public static void ChangeValue(EmocionesFemeninasBase emos, ReaccionHumana reaccion, float valor)
		{
			if (reaccion == ReaccionHumana.None)
			{
				return;
			}
			if (valor == 0f)
			{
				return;
			}
			Emocion emocion = emos.ObtenerEmocion(reaccion);
			if (emocion == null)
			{
				return;
			}
			if (valor < 0f)
			{
				emocion.ReduceValueNextUpdate(-valor);
				return;
			}
			emocion.IncreaseValueNextUpdate(valor);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000A804 File Offset: 0x00008A04
		public static void ChangeValueAutoReacc(Character femaleChar, EmocionesFemeninasBase emos, ReaccionHumana reaccion, float valor)
		{
			if (reaccion == ReaccionHumana.None)
			{
				return;
			}
			if (valor == 0f)
			{
				return;
			}
			Emocion emocion = emos.ObtenerEmocion(reaccion);
			if (emocion == null)
			{
				return;
			}
			if (valor < 0f)
			{
				emocion.ReduceValueNextUpdate(-valor);
			}
			else
			{
				emocion.IncreaseValueNextUpdate(valor);
			}
			if (femaleChar == null)
			{
				return;
			}
			float num = Mathf.InverseLerp(0f, 10f, valor).OutPow(2f);
			float num2 = Mathf.Clamp01(num.Random(0.75f));
			float num3 = Mathf.Clamp01(num.Random(0.75f));
			float num4 = Mathf.Lerp(3f, 10f, num);
			if (reaccion <= ReaccionHumana.arousal)
			{
				if (reaccion <= ReaccionHumana.dolor)
				{
					if (reaccion != ReaccionHumana.concentToHero)
					{
						if (reaccion != ReaccionHumana.dolor)
						{
							goto IL_012B;
						}
						goto IL_00F5;
					}
				}
				else
				{
					if (reaccion == ReaccionHumana.rabia)
					{
						SequencerCommandEnojar.Gestuar(femaleChar, num, num2, num3, num4 * 2f);
						return;
					}
					if (reaccion != ReaccionHumana.placer && reaccion != ReaccionHumana.arousal)
					{
						goto IL_012B;
					}
				}
			}
			else if (reaccion <= ReaccionHumana.miedo)
			{
				if (reaccion == ReaccionHumana.tristeza)
				{
					goto IL_00F5;
				}
				if (reaccion != ReaccionHumana.miedo)
				{
					goto IL_012B;
				}
				SequencerCommandAsustar.Gestuar(femaleChar, num, num2, num3, num4 * 2f);
				return;
			}
			else if (reaccion != ReaccionHumana.alegria && reaccion != ReaccionHumana.felicidad && reaccion != ReaccionHumana.desHielo)
			{
				goto IL_012B;
			}
			SequencerCommandSonrreir.Gestuar(femaleChar, num, num2, num3, num4);
			return;
			IL_00F5:
			SequencerCommandSufrir.Gestuar(femaleChar, num, num2, num3, num4 * 1.5f);
			return;
			IL_012B:
			throw new ArgumentOutOfRangeException(reaccion.ToString());
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0000A94E File Offset: 0x00008B4E
		public void Update()
		{
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000A950 File Offset: 0x00008B50
		public void OnDestroy()
		{
		}

		// Token: 0x040000A8 RID: 168
		private List<ValueTuple<ReaccionHumana, float>> m_Temp = new List<ValueTuple<ReaccionHumana, float>>();
	}
}
