using System;
using Assets.Base.Plugins.Runtime;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases
{
	// Token: 0x020000B2 RID: 178
	public class BuffOnEmocionAddEffecto : Efecto<BuffOnEmocionAddEffecto, BuffOnEmocionAddArg>
	{
		// Token: 0x060003B1 RID: 945 RVA: 0x00015268 File Offset: 0x00013468
		public override void Apply(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			BuffOnEmocionAddArg buffOnEmocionAddArg = argument as BuffOnEmocionAddArg;
			if (buffOnEmocionAddArg == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			EmocionesHumanasBase emocionesHumanasBase = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (emocionesHumanasBase == null)
			{
				return;
			}
			Emotion emo = buffOnEmocionAddArg.emo;
			ReaccionHumana reaccionHumana = emo.Parse();
			Emocion emocion = emocionesHumanasBase.ObtenerEmocion(reaccionHumana);
			if (emocion == null)
			{
				Debug.LogError("no se puedo encontrar emo " + emo.ToString(), caster as MonoBehaviour);
				return;
			}
			emocion.sumadorDeValor.ObtenerModificadorNotNull(buffEvento.id).valor.valor = buffOnEmocionAddArg.add;
			float num;
			if (emo.IsGood())
			{
				num = 100f;
			}
			else
			{
				num = -100f;
			}
			buffEvento.quality = (ItemQuality)Mathf.RoundToInt(Mathf.Lerp(1f, 13f, MathfExtension.InverseLerpConMedio(-num, 0f, num, buffOnEmocionAddArg.add * (float)stacks).InInOutOutPow(2f, 2f, 0.5f)));
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x000148CD File Offset: 0x00012ACD
		public override void Stay(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			this.Apply(affected, argument, stacks, buff, caster);
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x00015374 File Offset: 0x00013574
		public override void Remove(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			BuffEvento buffEvento = buff as BuffEvento;
			if (buffEvento == null)
			{
				return;
			}
			BuffOnEmocionAddArg buffOnEmocionAddArg = argument as BuffOnEmocionAddArg;
			if (buffOnEmocionAddArg == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			EmocionesHumanasBase emocionesHumanasBase = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (emocionesHumanasBase == null)
			{
				return;
			}
			Emotion emo = buffOnEmocionAddArg.emo;
			ReaccionHumana reaccionHumana = emo.Parse();
			Emocion emocion = emocionesHumanasBase.ObtenerEmocion(reaccionHumana);
			if (emocion == null)
			{
				Debug.LogError("no se puedo encontrar emo " + emo.ToString(), caster as MonoBehaviour);
				return;
			}
			if (!emocion.sumadorDeValor.TryRemoverModificador(buffEvento.id))
			{
				Debug.LogError("no se puedo remover buff " + buffEvento.id + " no existia en modificables ", caster as MonoBehaviour);
			}
		}
	}
}
