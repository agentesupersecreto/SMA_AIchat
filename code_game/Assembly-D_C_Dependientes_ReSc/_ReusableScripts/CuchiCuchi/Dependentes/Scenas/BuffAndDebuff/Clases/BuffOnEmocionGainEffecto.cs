using System;
using Assets.Base.Plugins.Runtime;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000B4 RID: 180
	public class BuffOnEmocionGainEffecto : Efecto<BuffOnEmocionGainEffecto, BuffOnEmocionGainArg>
	{
		// Token: 0x060003B8 RID: 952 RVA: 0x00015498 File Offset: 0x00013698
		public override void Apply(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			BuffOnEmocionGainArg buffOnEmocionGainArg = argument as BuffOnEmocionGainArg;
			if (buffOnEmocionGainArg == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			EmocionesHumanasBase emocionesHumanasBase = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (emocionesHumanasBase == null)
			{
				return;
			}
			Emotion emo = buffOnEmocionGainArg.emo;
			ReaccionHumana reaccionHumana = emo.Parse();
			Emocion emocion = emocionesHumanasBase.ObtenerEmocion(reaccionHumana);
			if (emocion == null)
			{
				Debug.LogError("no se puedo encontrar emo " + emo.ToString(), caster as MonoBehaviour);
				return;
			}
			emocion.multiplicadorDeAumento.ObtenerModificadorNotNull(buffEvento.id).valor.valor = buffOnEmocionGainArg.gainMod;
			float num;
			if (emo.IsGood())
			{
				num = 10f;
			}
			else
			{
				num = 0.1f;
			}
			buffEvento.quality = (ItemQuality)Mathf.RoundToInt(Mathf.Lerp(1f, 13f, MathfExtension.InverseLerpConMedio(1f / num, 1f, num, buffOnEmocionGainArg.gainMod * (float)stacks).InInOutOutPow(2f, 2f, 0.5f)));
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x000148CD File Offset: 0x00012ACD
		public override void Stay(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			this.Apply(affected, argument, stacks, buff, caster);
		}

		// Token: 0x060003BA RID: 954 RVA: 0x000155A8 File Offset: 0x000137A8
		public override void Remove(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			BuffOnEmocionGainArg buffOnEmocionGainArg = argument as BuffOnEmocionGainArg;
			if (buffOnEmocionGainArg == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			EmocionesHumanasBase emocionesHumanasBase = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (emocionesHumanasBase == null)
			{
				return;
			}
			Emotion emo = buffOnEmocionGainArg.emo;
			ReaccionHumana reaccionHumana = emo.Parse();
			Emocion emocion = emocionesHumanasBase.ObtenerEmocion(reaccionHumana);
			if (emocion == null)
			{
				Debug.LogError("no se puedo encontrar emo " + emo.ToString(), caster as MonoBehaviour);
				return;
			}
			if (!emocion.multiplicadorDeAumento.TryRemoverModificador(buffEvento.id))
			{
				Debug.LogError("no se puedo remover buff " + buffEvento.id + " no existia en modificables ", caster as MonoBehaviour);
			}
		}
	}
}
